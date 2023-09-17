using K2_Domain.Commands;
using K2_Domain.CommandsResults;
using K2_Domain.Entities;
using K2_Domain.Repositories.Interfaces;
using K2_Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

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
                throw;
            }
        }

        public List<ContaBancariaResult> BuscarSaldoRepository(BuscarSaldoContaBancariaCommand command)
        {
            try
            {

                var dadosConta = _context.ContaBancaria.Select(x => x.NUMERO_CONTA).ToList();
                _context.SaveChanges();

                return dadosConta;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
