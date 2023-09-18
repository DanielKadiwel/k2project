using K2_Domain.Commands.Base;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K2_Domain.Commands
{
    public class BuscarSaldoExtratoContaBancariaCommand : BaseCommand
    {
        public string? NUMERO_CONTA { get; set; }

        public override bool IsValid()
        {
            if (string.IsNullOrEmpty(NUMERO_CONTA))
                return false;

            return Valid;
        }
    }
}
