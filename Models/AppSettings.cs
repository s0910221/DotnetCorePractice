using System;

namespace DotnetCorePractice.Models {
    public class AppSettings : IAppSettings, IAppSettingsScoped, IAppSettingsSingleton {
        public AppSettings () {
            this.Name = Guid.NewGuid ().ToString ();
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}