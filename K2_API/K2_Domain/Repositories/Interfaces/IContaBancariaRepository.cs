using K2_Domain.Commands;
using K2_Domain.CommandsResults;
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
        public int MovimentacoesContaRepository(MovimentacoesContaCommands command);
        public ContaBancariaResult BuscarContaPorNumeroRepository(string NUMERO_CONTA);
        public bool AtualizarValoresConta(ContaBancariaEntity conta);

        //public ContaBancariaResult BuscarExtratoRepository(string numeroConta);
    }
}
