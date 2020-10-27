using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestePloomes
{
    public class RespostaDoAlterarNegociacao
    {
        public string odatacontext { get; set; }
        public DealsPATCH[] value { get; set; }
    }
    public class DealsPATCH
    {
        public string Title { get; set; }
        public int ContactId { get; set; }
        public double Amount { get; set; }
        public int StageId { get; set; }
        public Otherproperty[] OtherProperties { get; set; }
    }

}
