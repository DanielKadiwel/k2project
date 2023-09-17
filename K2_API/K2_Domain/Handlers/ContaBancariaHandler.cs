using K2_Domain.Commands;
using K2_Domain.Handlers.Base;
using K2_Domain.Repositories.Interfaces;
using BCrypt.Net;
using K2_Domain.Entities;
using K2_Domain.CommandsResults;

namespace K2_Domain.Handlers
{
    public class ContaBancariaHandler : BaseHandler
    {
        private readonly IContaBancariaRepository _repository;

        public ContaBancariaHandler(IContaBancariaRepository repository)
        {
            _repository = repository;
        }

        public string AdicionarNovaConta(ContaBancariaCommand command)
        {
            try
            {
                var mensagem = "";

                if (!command.IsValid())
                {
                    AddNotifications(command.Notifications);
                    throw new Exception();
                }

                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(command.PASSWORD);
                bool verificaSenha = BCrypt.Net.BCrypt.Verify(command.PASSWORD, hashedPassword);

                if (!verificaSenha)
                    throw new Exception();

                var entity = new ContaBancariaEntity();
                Random random = new Random();

                entity.EMAIL = command.EMAIL;
                entity.NOME = command.NOME;
                entity.PASSWORD = hashedPassword;
                entity.NUMERO_CONTA = random.Next(100000, 999999).ToString();
                entity.SALDO = 0;
                entity.EXTRATO = 0;

                if (!_repository.Adicionar(entity))
                {
                    throw new Exception();
                }
                else
                {
                    mensagem = $"Conta criada com sucesso. Nº da conta: {entity.NUMERO_CONTA}";
                }

                return mensagem;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public string BuscarSaldo(BuscarSaldoContaBancariaCommand command)
        {
            try
            {
                var mensagem = "";

                if (!command.IsValid())
                {
                    AddNotifications(command.Notifications);
                    throw new Exception();
                }

                var dadosConta = _repository.BuscarSaldoRepository(command.NUMERO_CONTA);

                var result = new ContaBancariaResult();

                foreach (var dados in dadosConta)
                {
                    dados.NOME = result.NOME;
                    dados.EMAIL = result.EMAIL;
                    dados.NUMERO_CONTA = result.NUMERO_CONTA;
                    dados.SALDO = result.SALDO;
                }

                mensagem = $"Saldo da conta {result.NUMERO_CONTA}: {result.SALDO}";

                return mensagem;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public string BuscarExtrato(BuscarExtratoContaBancariaCommand command)
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
