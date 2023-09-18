using K2_Domain.Commands.Base;
using K2_Domain.Entities;
using BCrypt.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace K2_Domain.Commands
{
    public class ContaBancariaCommand : BaseCommand
    {
        public string NOME { get; set; }
        public string EMAIL { get; set; }
        public string PASSWORD { get; set; }
        public int SALDO { get; set; }

        public override bool IsValid() 
        {
            if (string.IsNullOrEmpty(EMAIL))
                return false;

            if (string.IsNullOrEmpty(NOME))
                return false;

            return Valid;
        }
    }
}
