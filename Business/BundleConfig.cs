using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace EPiCenterBaseProject.Business
{
    public class BundleConfig
    {

        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            //http://stackoverflow.com/questions/11980458/mvc4-bundler-not-including-min-files - > Read more about ignoreList. What we do now is that we are removing all the default rules for bundeling.
            //Further down u can add to the list what u want to ignore. 
            bundles.IgnoreList.Clear();
            AddDefaultIgnorePatterns(bundles.IgnoreList);
            //TODO: Find out why the minified files aren't loaded.
            //BundleTable.EnableOptimizations = false;

            bundles.Add(new StyleBundle("~/bundles/css").Include(
                        "~/UI/css/framework.css",
                        "~/UI/css/mediaqueries.css",
                        "~/UI/css/font-awesome.min.css",
                        "~/UI/css/layout.css"
                        ));


            bundles.Add(new ScriptBundle("~/bundles/netrscripts").Include(
                        "~/UI/scripts/jquery.1.9.0.min.js",
                        "~/UI/scripts/libs/jquery.cycle.all.js",
                         //"~/UI/scripts/Chart.js",
                         //"~/UI/scripts/chartdata.js",
                         //"~/UI/scripts/startup.js",
                         "~/UI/scripts/script.js"
                         //"~/UI/scripts/libs/jquery.cycle.lite.js",
                         
                        )); 




        }

        public static void AddDefaultIgnorePatterns(IgnoreList ignoreList)
        {
            if (ignoreList == null)
                throw new ArgumentNullException("ignoreList");
            //ignorelist.ignore("*.intellisense.js");
            //ignorelist.ignore("*-vsdoc.js");
            //ignorelist.ignore("*.debug.js", optimizationmode.whenenabled);
            //ignoreList.Ignore("*.min.js", OptimizationMode.WhenDisabled);
            //ignoreList.Ignore("*.min.css", OptimizationMode.WhenDisabled);

        }
    }
}