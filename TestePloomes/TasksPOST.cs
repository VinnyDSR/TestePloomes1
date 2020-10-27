using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestePloomes
{

    class TasksPOST
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
        public int ContactId { get; set; }
        public Otherproperty[] OtherProperties { get; set; }
    }


}
