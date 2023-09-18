using K2_Domain.Commands.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K2_Domain.Commands
{
    public class LoginCommand : BaseCommand
    {
        public string EMAIL { get; set; }
        public string PASSWORD { get; set; }

        public override bool IsValid()
        {
            if (string.IsNullOrEmpty(EMAIL))
                return false;

            if (string.IsNullOrEmpty(PASSWORD))
                return false;

            return Valid;
        }
    }
}
