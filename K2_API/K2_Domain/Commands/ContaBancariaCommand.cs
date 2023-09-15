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
        public ContaBancariaEntity ContaBancariaEntity { get; set; }

        public override bool IsValid() 
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(ContaBancariaEntity.PASSWORD);
            bool verificaSenha = BCrypt.Net.BCrypt.Verify(ContaBancariaEntity.PASSWORD, hashedPassword);

            if (!verificaSenha)
                return false;

            if (string.IsNullOrEmpty(ContaBancariaEntity.EMAIL))
                return false;

            if (string.IsNullOrEmpty(ContaBancariaEntity.NOME))
                return false;

            return Valid;
        }
    }
}
