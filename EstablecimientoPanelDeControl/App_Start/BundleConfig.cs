using System.Web;
using System.Web.Optimization;

namespace EstablecimientoPanelDeControl
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            // dataTables css styles
            bundles.Add(new StyleBundle("~/Content/dataTables/dataTablesStyles").Include(
                      "~/Content/DataTables/datatables.min.css",
                      "~/Content/DataTables/fixedColumns.dataTables.min.css",
                      "~/Content/DataTables/responsive.dataTables.min.css",
                      "~/Content/DataTables/select.dataTables.min.css"));

            // dataTables 
            bundles.Add(new ScriptBundle("~/plugins/dataTables").Include(
                      "~/Scripts/dataTables/datatables.min.js",
                      "~/Scripts/dataTables/dataTables.fixedColumns.min.js",
                      "~/Scripts/dataTables/dataTables.responsive.min.js",
                      "~/Scripts/dataTables/dataTables.select.min.js"));


        }
    }
}
