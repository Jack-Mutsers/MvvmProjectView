using MVVMProjectView.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMProjectView.Resources
{
    public static class API
    {
        public static MainWindow mainWindow { get; set; }

        private static Resources _resources = new Resources();
        public static Resources resources
        {
            get
            {
                return _resources;
            }
        }


        public static Guid ApiKey { get; set; } = Guid.Empty;
        public static User UserData { get; set; } = new User();


    }
}
