using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestePloomes
{
    class DealsPOST
    {
        
            public string Title { get; set; }
            public int ContactId { get; set; }
            public int Amount { get; set; }
            public int StageId { get; set; }
            public Otherproperty[] OtherProperties { get; set; }
        

    }
}
