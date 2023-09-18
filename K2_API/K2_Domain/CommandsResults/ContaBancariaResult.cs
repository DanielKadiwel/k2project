using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K2_Domain.CommandsResults
{
    public class ContaBancariaResult
    {
        public int ID { get; set; }
        public string NOME { get; set; }
        public string EMAIL { get; set; }
        public string PASSWORD { get; set; }
        public string? NUMERO_CONTA { get; set; }
        public int? SALDO { get; set; }
        public int? EXTRATO { get; set; }
        public int? ID_MOVIMENTACAO { get; set; }
    }
}
