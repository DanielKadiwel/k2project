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
                entity.SALDO = command.SALDO;
                entity.PASSWORD = hashedPassword;
                entity.NUMERO_CONTA = random.Next(100000, 999999).ToString();
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

        public string MovimentacoesConta(MovimentacoesContaCommands command)
        {
            try
            {
                if (!command.IsValid())
                {
                    AddNotifications(command.Notifications);
                    throw new Exception();
                }
                var IdMovimentacao = 0;

                var contaOrigemResult = _repository.BuscarContaPorNumeroRepository(command.CONTA_ORIGEM);
                var entityOrigem = new ContaBancariaEntity();
                var contaDestinoResult = _repository.BuscarContaPorNumeroRepository(command.CONTA_DESTINO);
                var entityDestino = new ContaBancariaEntity();

                //CONTA ORIGEM
                entityOrigem.ID = contaOrigemResult.ID;
                entityOrigem.NOME = contaOrigemResult.NOME;
                entityOrigem.NUMERO_CONTA = contaOrigemResult.NUMERO_CONTA;
                entityOrigem.EMAIL = contaOrigemResult.EMAIL;
                entityOrigem.EXTRATO = contaOrigemResult.EXTRATO;
                entityOrigem.SALDO = contaOrigemResult.SALDO - command.VALOR;
                //CONTA DESTINO
                entityDestino.ID = contaOrigemResult.ID;
                entityDestino.NOME = contaOrigemResult.NOME;
                entityDestino.NUMERO_CONTA = contaOrigemResult.NUMERO_CONTA;
                entityDestino.EMAIL = contaOrigemResult.EMAIL;
                entityDestino.EXTRATO = contaOrigemResult.EXTRATO;
                entityDestino.SALDO = contaOrigemResult.SALDO + command.VALOR;

                IdMovimentacao = _repository.MovimentacoesContaRepository(command);

                entityOrigem.ID_MOVIMENTACAO = IdMovimentacao;
                entityDestino.ID_MOVIMENTACAO = IdMovimentacao;

                var list = new List<ContaBancariaEntity>();
                list.Add(entityOrigem);
                list.Add(entityDestino);

                foreach(var item in list)
                {
                    if (!_repository.AtualizarValoresConta(item))
                    {
                        return $"Erro ao atualizar valores entre contas {command.CONTA_ORIGEM} > {command.CONTA_DESTINO}";
                    }
                }

                return $"Movimentação {IdMovimentacao} efetuada com sucesso.\n" +
                       $"Valor: {command.VALOR}.\n" +
                       $"Conta de Origem: {command.CONTA_ORIGEM}\n" +
                       $"Conta de Destino: {command.CONTA_DESTINO}\n";
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public string BuscarSaldoExtrato(BuscarSaldoExtratoContaBancariaCommand command, string TipoBusca)
        {
            try
            {
                var mensagem = "";
                //var dadosExtrato = null;

                if (!command.IsValid())
                {
                    AddNotifications(command.Notifications);
                    throw new Exception();
                }

                if (TipoBusca == "Saldo")
                {
                    var dadosSaldo = _repository.BuscarContaPorNumeroRepository(command.NUMERO_CONTA);

                    mensagem = $"Sr(a) {dadosSaldo.NOME}. Nº{command.NUMERO_CONTA} \n O seu saldo é de: {dadosSaldo.SALDO}";

                }

                //else if (TipoBusca == "Extrato")
                //{
                //    dadosExtrato = _repository.BuscarExtratoRepository(command.NUMERO_CONTA);

                //}

                return mensagem;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
