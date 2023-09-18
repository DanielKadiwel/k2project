using K2_Domain.Commands;
using K2_Domain.CommandsResults;
using K2_Domain.Entities;
using K2_Domain.Repositories.Interfaces;
using K2_Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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

        public ContaBancariaResult BuscarContaPorNumeroRepository(string NUMERO_CONTA)
        {
            try
            {
                var query = $"proc_BuscarPorNConta '{NUMERO_CONTA}'";
                var dadosConta = _context.Database.GetDbConnection().QueryFirstOrDefault<ContaBancariaResult>(query);

                return dadosConta;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int MovimentacoesContaRepository(MovimentacoesContaCommands command)
        {
            try
            {
                var query = $"proc_InserirMovimentacoesConta '{command.CONTA_ORIGEM}', '{command.CONTA_DESTINO}', {command.VALOR}, '{command.TIPO_MOVIMENTACAO}'";
                var Id = _context.Database.GetDbConnection().QueryFirstOrDefault<int>(query);

                return Id;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool AtualizarValoresConta(ContaBancariaEntity conta)
        {
            try
            {
                _context.Update(conta);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex) 
            {
                throw;
            }
        }

        public bool Login(string email, string hashedPassword)
        {
            try
            {
                var usuario = _context.ContaBancaria.FirstOrDefault(u => u.EMAIL == email);

                if (usuario == null)
                    return false;

                if (hashedPassword != usuario.PASSWORD)
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        //public ContaBancariaResult BuscarExtratoRepository(string NUMERO_CONTA)
        //{
        //    try
        //    {

        //        var query = $"proc_BuscarExtratoPorNConta '{NUMERO_CONTA}'";

        //        //var args = new
        //        //{
        //        //    @NUMERO_CONTA = NUMERO_CONTA
        //        //};

        //        var dadosConta = _context.Database.GetDbConnection().QueryFirstOrDefault<ContaBancariaResult>(query/*, args*/);

        //        return dadosConta;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}
    }
}
