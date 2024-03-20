using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProlabProjesi2
{
    public abstract class Person
    {
        public string ad { get; set; }
        public string soyad { get; set; }
        public string tcNo { get; set; } 
        public DateTime dogumTarih { get; set; }
    }
}
