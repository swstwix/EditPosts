﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.17929
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EditPosts.Db.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Server=2dfe09d6-a13c-43a6-b9b3-a0fe0152b510.sqlserver.sequelizer.com;Database=db2" +
            "dfe09d6a13c43a6b9b3a0fe0152b510;User ID=qfydzrvnsncmntkc;Password=7JXa4okw2jVVME" +
            "Dk5tyZA85xNMRSbWfkpQ86q52ybKqU3cZnd5FmuFM7NzupEAud;")]
        public string ConnectionString {
            get {
                return ((string)(this["ConnectionString"]));
            }
        }
    }
}