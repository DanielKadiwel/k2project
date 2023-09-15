using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K2_Domain.Commands.Base.Interface
{
    public interface ICommand
    {
        bool IsValid();
    }
}
