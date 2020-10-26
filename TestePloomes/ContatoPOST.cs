using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestePloomes
{
    public class ContatoPOST
    {
        public string Name { get; set; }
        public string Neighborhood { get; set; }
        public int ZipCode { get; set; }
        public int OriginId { get; set; }
        public object CompanyId { get; set; }
        public string StreetAddressNumber { get; set; }
        public int TypeId { get; set; }
        public Phone[] Phones { get; set; }
        public Otherproperty[] OtherProperties { get; set; }
    }

}
