using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    internal class Course
    {
        public string Teacher { get; set; }
        public string Class { get; set; }
        public string Openclass { get; set; }
        public string Main { get; set; }

        public override string ToString()
        {
            return $"{this.Class}";
        }
    }
}
