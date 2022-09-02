//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Radarc (http://radarc.net) - Radarc version: 4.9.1.22813 Formula: UNIR.1.1 version: 1.1
//
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated. 
//     If you want to extend or modify the code use the designated extension points / user escapes as described in the product documentation.
// </auto-generated>
//------------------------------------------------------------------------------
using System.Web.Optimization;

namespace Unir.ErpAcademico.WebCapacitaciones.Bundles.Capacitacion
{
	public class AlumnoBundleBase
    {
        public virtual void RegisterListBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/alumno/list").Include(
				"~/Scripts/Capacitacion/Alumno/List/Main.gen.js",
				"~/Scripts/Capacitacion/Alumno/List/FilterArea.gen.js",
				"~/Scripts/Capacitacion/Alumno/List/DataSetOptions.gen.js",
				"~/Scripts/Capacitacion/Alumno/List/GridArea.gen.js",
				"~/Scripts/Capacitacion/Alumno/List/GridArea/Columns.gen.js",
				"~/Scripts/Capacitacion/Alumno/List/GridArea/Rows.gen.js",
				"~/Scripts/Capacitacion/Alumno/List/GridArea/RowCallback.gen.js",
				"~/Scripts/Capacitacion/Alumno/List/GridArea/Parameters.gen.js",
				"~/Scripts/Capacitacion/Alumno/List/GridArea/OptionMenu.gen.js",
				"~/Scripts/Capacitacion/Alumno/List/States.gen.js",
				"~/Scripts/Capacitacion/Alumno/List/Delete.gen.js",
				"~/Scripts/Capacitacion/Alumno/List/Clone.gen.js",
				"~/Scripts/Capacitacion/Alumno/List/Export.gen.js",
				"~/Scripts/Capacitacion/Alumno/List/Print.gen.js"
			));
        }

        public virtual void RegisterCreateBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/alumno/create").Include(
				"~/Scripts/Capacitacion/Alumno/Create/Main.gen.js",
				"~/Scripts/Capacitacion/Alumno/Create/States.gen.js",
				"~/Scripts/Capacitacion/Alumno/Create/Components.gen.js",
				"~/Scripts/Capacitacion/Alumno/Create/Parameters.gen.js",
				"~/Scripts/Capacitacion/Alumno/Create/Validation.gen.js" 
			));
        }

        public virtual void RegisterEditBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/alumno/edit").Include(
				"~/Scripts/Capacitacion/Alumno/Edit/Main.gen.js",
				"~/Scripts/Capacitacion/Alumno/Edit/States.gen.js",
				"~/Scripts/Capacitacion/Alumno/Edit/Components.gen.js",
				"~/Scripts/Capacitacion/Alumno/Edit/LoadData.gen.js",
				"~/Scripts/Capacitacion/Alumno/Edit/Parameters.gen.js",
				"~/Scripts/Capacitacion/Alumno/Edit/Validation.gen.js"
			));
        }

        public virtual void RegisterShowBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/alumno/show").Include(
				"~/Scripts/Capacitacion/Alumno/Show/Main.gen.js",
				"~/Scripts/Capacitacion/Alumno/Show/LoadData.gen.js"
			));
        }
	}
}
