﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Proyecto_Xarxa_Desktop.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.10.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("../../data/todos.csv")]
        public string UbicacionCsvListaAlumnosGeneral {
            get {
                return ((string)(this["UbicacionCsvListaAlumnosGeneral"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("../../data/alumnosxarxa.csv")]
        public string UbicacionCsvListaAlumnosXarxa {
            get {
                return ((string)(this["UbicacionCsvListaAlumnosXarxa"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("http://xarxa.eastus.cloudapp.azure.com:8081/apixarxa/")]
        public string CadenaConexionLocalhost {
            get {
                return ((string)(this["CadenaConexionLocalhost"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C:\\Xarxa")]
        public string CarpetaXarxa {
            get {
                return ((string)(this["CarpetaXarxa"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("../../data/filtro_grupos.csv")]
        public string UbicacionCsvFiltroGrupos {
            get {
                return ((string)(this["UbicacionCsvFiltroGrupos"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("server = xarxa.eastus.cloudapp.azure.com; database = bdxarxa; Uid = juandiremoto;" +
            " pwd =1234")]
        public string CadenaConexionMySQL {
            get {
                return ((string)(this["CadenaConexionMySQL"]));
            }
        }
    }
}
