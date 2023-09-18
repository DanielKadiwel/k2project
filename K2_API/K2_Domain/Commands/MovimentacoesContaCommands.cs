using K2_Domain.Commands.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K2_Domain.Commands
{
    public class MovimentacoesContaCommands : BaseCommand
    {
        public string CONTA_ORIGEM { get; set; }
        public string CONTA_DESTINO { get; set; }
        public string TIPO_MOVIMENTACAO { get; set; }
        public int VALOR { get; set; }

        public override bool IsValid()
        {
            if (string.IsNullOrEmpty(CONTA_ORIGEM))
                return false;

            if (string.IsNullOrEmpty(CONTA_DESTINO))
                return false;

            return Valid;
        }
    }
}
