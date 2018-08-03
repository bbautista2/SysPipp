using System;
using System.Reflection;
using System.Web;

namespace CapaLibreria.General
{
    public static class Utilidades
    {
        public static class SessionStateServerSharedHelper
        {
            public static void ChangeAppDomainAppId(string name)
            {
                FieldInfo runtimeInfo = typeof(HttpRuntime).GetField("_theRuntime", BindingFlags.Static | BindingFlags.NonPublic);
                if (runtimeInfo == null) return;
                HttpRuntime theRuntime = (HttpRuntime)runtimeInfo.GetValue(null);
                if (theRuntime == null) return;
                FieldInfo appNameInfo = typeof(HttpRuntime).GetField("_appDomainAppId", BindingFlags.Instance | BindingFlags.NonPublic);
                if (appNameInfo == null) return;
                var appName = (String)appNameInfo.GetValue(theRuntime);
                if (appName != "applicationName") appNameInfo.SetValue(theRuntime, name);
            }
        }
    }
}
