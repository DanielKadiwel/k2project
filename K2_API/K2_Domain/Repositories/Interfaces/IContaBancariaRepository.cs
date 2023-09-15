using K2_Domain.Commands;
using K2_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace K2_Domain.Repositories.Interfaces
{
    public interface IContaBancariaRepository
    {
        public bool Adicionar(ContaBancariaEntity entity);
    }
}
