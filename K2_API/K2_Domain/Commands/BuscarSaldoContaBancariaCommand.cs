using K2_Domain.Commands.Base;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K2_Domain.Commands
{
    public class BuscarSaldoContaBancariaCommand : BaseCommand
    {
        public int NUMERO_CONTA { get; set; }

        public override bool IsValid()
        {
            if (NUMERO_CONTA == 0)
                return false;

            return Valid;
        }
    }
}
