using EstablecimientoPanelDeControl.ViewModels;
using EstablecimientoPanelDeControl.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EstablecimientoPanelDeControl.Repositorio
{
    public class EstablecimientoRepositorio
    {
        private SqlConnection con;
        private void Connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
            con = new SqlConnection(constr);
        }

        private String NombreEstablecimiento(Int32 idEstablecimiento)
        {
            Connection();
            String nombreEstablecimiento;

            SqlCommand com = new SqlCommand("SP_OBTENER_ESTABLECIMIENTO", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            com.Parameters.AddWithValue("@id", idEstablecimiento);
            da.Fill(dt);
            con.Close();

            DataRow dr = dt.Rows[0];

            nombreEstablecimiento = dr.Field<String>(0);

            return nombreEstablecimiento;
        }

        private Int32 CantidadMedicosActivos(DateTime? fechaDesdeEvoluciones = null)
        {

            Connection();
            Int32 cantMedActivos;

            SqlCommand com = new SqlCommand("SP_TOTAL_MEDICOS_ACTIVOS", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            //Convert.ToDateTime("10/08/2019")                          -> 4  medicos activos
            //CantidadMedicosActivos(Convert.ToDateTime("10/03/2019"))  -> 40 medicos activos
            com.Parameters.AddWithValue("@fechaDesde",fechaDesdeEvoluciones == null? DateTime.Now.AddDays(-30) : fechaDesdeEvoluciones);
            da.Fill(dt);
            con.Close();

            DataRow dr = dt.Rows[0];

            cantMedActivos = dr.Field<int>(0);

            return (cantMedActivos);
        }

        public Int32 CantidadTotalProfesionales()
        {
            Connection();
            Int32 cantTotalProf;

            SqlCommand com = new SqlCommand("SP_TOTAL_PROFESIONALES", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();

            DataRow dr = dt.Rows[0];

            cantTotalProf = dr.Field<int>(0);

            return (cantTotalProf);
        }

        public Int32 CantidadTotalEvoluciones(DateTime? fechaDesdeEvoluciones = null, DateTime? fechaHastaEvoluciones = null)
        {
            Connection();
            Int32 cantTotalEvoluciones;

            SqlCommand com = new SqlCommand("SP_TOTAL_EVOLUCIONES", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            //Convert.ToDateTime("01/08/2019")                              -> 464
            //CantidadTotalEvoluciones(Convert.ToDateTime("01/01/2019"))    -> 12752
            com.Parameters.AddWithValue("@fechaDesde", fechaDesdeEvoluciones == null ? DateTime.Now.AddDays(-30) : fechaDesdeEvoluciones);
            com.Parameters.AddWithValue("@fechaHasta", fechaHastaEvoluciones == null ? DateTime.Now : fechaHastaEvoluciones);
            da.Fill(dt);
            con.Close();

            DataRow dr = dt.Rows[0];

            cantTotalEvoluciones = dr.Field<int>(0);

            return (cantTotalEvoluciones);
        }

        public Int32 CantidadTotalPracticas(DateTime? fechaDesdePractica = null, DateTime? fechaHastaPractica = null)
        {
            Connection();
            Int32 cantTotalPracticas;

            SqlCommand com = new SqlCommand("SP_TOTAL_PRACTICAS", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            //Convert.ToDateTime("01/06/2019")                              -> 7107
            //CantidadTotalPracticas(Convert.ToDateTime("01/08/2019")       -> 728
            com.Parameters.AddWithValue("@fechaDesde", fechaDesdePractica == null ? DateTime.Now.AddDays(-30) : fechaDesdePractica);
            com.Parameters.AddWithValue("@fechaHasta", fechaHastaPractica == null ? DateTime.Now : fechaHastaPractica);
            da.Fill(dt);
            con.Close();

            DataRow dr = dt.Rows[0];

            cantTotalPracticas = dr.Field<int>(0);

            return (cantTotalPracticas);
        }

        public List<SectorModel> ListarSectores()
        {
            Connection();
            List<SectorModel> listadoSectores=new List<SectorModel>();

            SqlCommand com = new SqlCommand("SP_LISTAR_SECTORES", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();

            da.Fill(dt);
            con.Close();

            listadoSectores = (from DataRow dr in dt.Rows
                               select new SectorModel()
                               {
                                     id = Convert.ToInt32(dr["id"]),
                                     nombre = Convert.ToString(dr["nombre"]),
                                     tipo = Convert.ToString(dr["tipo"]),
                                     vigente = Convert.ToBoolean(dr["vigente"]),
                                }).ToList();

            return listadoSectores;
        }

        public PanelViewModel CargaDeDatos(DateTime? fechaDesdeEvoluciones = null, DateTime? fechaHastaEvoluciones = null, DateTime? fechaDesdePracticas = null, DateTime? fechaHastaPracticas = null)
        {

            PanelViewModel miVista = new PanelViewModel(NombreEstablecimiento(5),CantidadTotalProfesionales(), CantidadMedicosActivos(),CantidadTotalEvoluciones(fechaDesdeEvoluciones, fechaHastaEvoluciones),CantidadTotalPracticas(fechaDesdePracticas, fechaHastaPracticas),ListarSectores());

            return miVista;
        }

    
    }

    //Crear un Metodo del tipo ViewModelPanel aqui y que éste llame a estos distintos metodos para ir cargando los valores de los atributos. (No mandar toda la estructura de ViewModelPanel en la Vista de el Objeto).
}