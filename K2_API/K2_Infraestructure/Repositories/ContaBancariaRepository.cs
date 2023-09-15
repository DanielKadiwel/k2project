using K2_Domain.Entities;
using K2_Domain.Repositories.Interfaces;
using K2_Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K2_Infraestructure.Repositories
{
    public class ContaBancariaRepository : IContaBancariaRepository
    {
        private readonly RepositoryContext _context;

        public ContaBancariaRepository(RepositoryContext context)
        {
            _context = context;
        }

        public bool Adicionar(ContaBancariaEntity entity)
        {
            try
            {
                _context.Add<ContaBancariaEntity>(entity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
