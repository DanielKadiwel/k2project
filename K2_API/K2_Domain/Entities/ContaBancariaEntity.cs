using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K2_Domain.Entities
{
    [Table("ContaBancaria")]
    public class ContaBancariaEntity
    {
        public int ID { get; set; }
        public string NOME { get; set; }
        public string EMAIL { get; set; }
        public string PASSWORD { get; set; }
        public string? NUMERO_CONTA { get; set; }
    }
}
