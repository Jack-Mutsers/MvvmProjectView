using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMProjectView.Models
{
    public class Validation
    {
        public Guid access_token { get; set; }
        public Guid userId { get; set; }
        public DateTime creation_date { get; set; }
        public DateTime expiration_date { get; set; }

        public User user { get; set; }
    }
}
