using K2_Domain.Commands;
using K2_Domain.Handlers.Base;
using K2_Domain.Repositories.Interfaces;
using BCrypt.Net;

namespace K2_Domain.Handlers
{
    public class ContaBancariaHandler : BaseHandler
    {
        private readonly IContaBancariaRepository _repository;

        public ContaBancariaHandler(IContaBancariaRepository repository)
        {
            _repository = repository;
        }

        public bool AdicionarNovaConta(ContaBancariaCommand command)
        {
            try
            {
                if (!command.IsValid())
                {
                    AddNotifications(command.Notifications);
                    return false;
                }

                Random random = new Random();
                command.ContaBancariaEntity.NUMERO_CONTA = random.Next(100000, 999999).ToString();

                if (!_repository.Adicionar(command.ContaBancariaEntity))
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
     }
    }
}
