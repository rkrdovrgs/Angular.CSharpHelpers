using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Optimization;

namespace Angular.CSharpHelpers
{
    public static class BundleCollectionExtensions
    {
        public static void RegisterNgModule(this BundleCollection bundles, string moduleName, string areaName = null)
        {
            string areaPath = string.IsNullOrEmpty(areaName) ? string.Empty : string.Format("/areas/{0}", areaName),
                path = string.Format("~{0}/ng-modules/{1}", areaPath, moduleName),
                bundlePathFormat = string.Format("~/bundles/ng-modules/{0}/{{0}}", moduleName);

            //Js
            bundles.Add(new ScriptBundle(string.Format(bundlePathFormat, "js"))
                .IncludeDirectory(path, "*.js", true));
            //Css
            bundles.Add(new StyleBundle(string.Format(bundlePathFormat, "css"))
                .IncludeDirectory(path, "*.css", true));
            //Html
            bundles.Add(new Bundle(string.Format(bundlePathFormat, "html"))
                .IncludeDirectory(path, "*.tmpl.html", true));

        }
    }
}
