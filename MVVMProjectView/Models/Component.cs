using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MVVMProjectView.Models
{
    public class Component
    {
        public int id { get; set; }
        public string name { get; set; }
        public int categoryid { get; set; }
        public int value { get; set; }
        public string ip_adress { get; set; }
        public int arduino_id { get; set; }
        public bool status { get; set; }
        public Category category { get; set; } = new Category();

        public string btnState
        {
            get { return value > 0 ? "close" : "open"; }
        }

        public Brush stateBackGround
        {
            get { return value > 0 ? Brushes.Red : Brushes.Green; }
        }

        public string stateText
        {
            get { return value > 0 ? "open" : "close"; }
        }
    }
}
