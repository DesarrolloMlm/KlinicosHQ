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
            String nombreEstablecimiento;

            Connection();
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
            Int32 cantMedActivos;

            Connection();
            SqlCommand com = new SqlCommand("SP_TOTAL_MEDICOS_ACTIVOS", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            com.Parameters.AddWithValue("@fechaDesde",fechaDesdeEvoluciones == null? DateTime.Now.AddDays(-30) : fechaDesdeEvoluciones);
            da.Fill(dt);
            con.Close();

            DataRow dr = dt.Rows[0];

            cantMedActivos = dr.Field<int>(0);
            return (cantMedActivos);
        }

        public Int32 CantidadTotalProfesionales()
        {
            Int32 cantTotalProf;
            Connection();

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
            Int32 cantTotalEvoluciones;
            Connection();

            SqlCommand com = new SqlCommand("SP_TOTAL_EVOLUCIONES", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
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
            Int32 cantTotalPracticas;
            Connection();

            SqlCommand com = new SqlCommand("SP_TOTAL_PRACTICAS", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
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
            List<SectorModel> listadoSectores=new List<SectorModel>();
            Connection();

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

        public PanelViewModel CargaDeDatosPanel(DateTime? fechaDesdeEvoluciones = null, DateTime? fechaHastaEvoluciones = null,
                                           DateTime? fechaDesdePracticas = null, DateTime? fechaHastaPracticas = null)
        {
            PanelViewModel miVista = new PanelViewModel(NombreEstablecimiento(5),
                                                        CantidadTotalProfesionales(),
                                                        CantidadMedicosActivos(),
                                                        CantidadTotalEvoluciones(fechaDesdeEvoluciones, fechaHastaEvoluciones),
                                                        CantidadTotalPracticas(fechaDesdePracticas, fechaHastaPracticas),
                                                        ListarSectores());
            return miVista;
        }

        public List<ProblemasSaludModel> ListarProblemasSalud(DateTime? fechaDesdeProblemas= null, DateTime? fechaHastaProblemas = null, Int32? cantidad=null)
        {
            List<ProblemasSaludModel> listadoProblemasSalud = new List<ProblemasSaludModel>();
            Connection();

            SqlCommand com = new SqlCommand("SP_LISTAR_PROBLEMAS_SALUD", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            com.Parameters.AddWithValue("@fechaDesde", fechaDesdeProblemas == null ? DateTime.Now.AddDays(-30) : fechaDesdeProblemas);
            com.Parameters.AddWithValue("@fechaHasta", fechaHastaProblemas == null ? DateTime.Now : fechaHastaProblemas);
            com.Parameters.AddWithValue("@cantidad", cantidad == null ? 1 : cantidad);
            da.Fill(dt);
            con.Close();

            listadoProblemasSalud = (from DataRow dr in dt.Rows
                               select new ProblemasSaludModel()
                               {
                                   problemaSalud = Convert.ToString(dr["Problema de Salud"]),
                                   cantidad = Convert.ToInt32(dr["cantidad"]),
                               }).ToList();

            return listadoProblemasSalud;
        }

        public ProblemaSaludViewModel CargaDeDatosProblemaSalud(DateTime? fechaDesdeProblemas= null, DateTime? fechaHastaProblemas = null, Int32? cantidad = null)
        {
            ProblemaSaludViewModel miVista = new ProblemaSaludViewModel(ListarProblemasSalud(fechaDesdeProblemas, fechaHastaProblemas, cantidad));
            return miVista;
        }


        public List<ProfesionalViewModel> ObtenerProfesionalesVM()
        {
            List<ProfesionalViewModel> lista = new List<ProfesionalViewModel>();
            Connection();
            SqlCommand com = new SqlCommand("General.Obtener_Datos_Profesional", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                da.Fill(dt);
                con.Close();

                foreach (DataRow fila in dt.Rows)
                {
                    lista.Add(CastearProfesionalVM(fila));
                }
                return lista;

            }
            catch (Exception ex)
            {
                con.Close();
                throw ex; 
            }
            

            


        }

        private ProfesionalViewModel CastearProfesionalVM(DataRow dr)
        {
            try
            {
                ProfesionalViewModel viewModel = new ProfesionalViewModel();
                viewModel.Apellido = Convert.ToString(dr["primerApellido"]);
                viewModel.Dni = Convert.ToInt32(dr["numeroDocumento"]);
                viewModel.IdProfesional = Convert.ToInt32(dr["Id"]);
                viewModel.Matricula = Convert.ToString(dr["matricula"]);
                viewModel.Nombre = Convert.ToString(dr["primerNombre"]);
                viewModel.SetEsepecialidades(ObtenerEspecialidadesProfesional(viewModel.IdProfesional));

                return viewModel;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private List<Especialidad> ObtenerEspecialidadesProfesional(int idProfesional)
        {
            List<Especialidad> lista = new List<Especialidad>();
            Connection();
            SqlCommand com = new SqlCommand("General.Obtener_Especialidad_Profesional", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            com.Parameters.AddWithValue("@idProf", idProfesional);
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                da.Fill(dt);
                con.Close();

                foreach (DataRow fila in dt.Rows)
                {
                    lista.Add(CastearEspecialidad(fila));
                }
                return lista;

            }
            catch (Exception ex)
            {
                con.Close();
                throw ex;
            }
        }

        private Especialidad CastearEspecialidad(DataRow dr)
        {
            try
            {
                Especialidad especialidad = new Especialidad();
                especialidad.Id = Convert.ToInt32(dr["idEspecialidad"]);
                especialidad.Nombre = Convert.ToString(dr["nombre"]);
                return especialidad;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }

    //Crear un Metodo del tipo ViewModelPanel aqui y que éste llame a estos distintos metodos para ir cargando los valores de los atributos.
    //(No mandar toda la estructura de ViewModelPanel en la Vista de el Objeto).
}