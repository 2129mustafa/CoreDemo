using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Areas.Admin.Models
{
    public class WriterClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }
        public bool Status { get; set; }
    }
}
