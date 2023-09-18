using K2_API.Controllers.Base;
using K2_Domain.Commands;
using K2_Domain.CommandsResults;
using K2_Domain.Handlers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace K2_API.Controllers
{
    [Route("api/conta-bancaria")]
    [ApiController]
    public class ContaBancariaController : BaseController
    {
        private readonly ContaBancariaHandler _handler;

        public ContaBancariaController(ContaBancariaHandler handler) : base(handler)
        {
            _handler = handler;
        }

        [HttpPost("cadastrar")]
        public string CadastrarConta([FromBody] ContaBancariaCommand command)
        {
            try
            {
                var result = _handler.AdicionarNovaConta(command);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("movimentacao-conta")]
        public string MovimentacoesConta([FromBody] MovimentacoesContaCommands command)
        {
            try
            {
                var result = _handler.MovimentacoesConta(command);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("saldo")]
        public string SaldoConta([FromBody] BuscarSaldoExtratoContaBancariaCommand command)
        {
            try
            {
                var result = _handler.BuscarSaldoExtrato(command, "Saldo");
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("login")]
        public bool Login(LoginCommand command)
        {
            try
            {
                if (!_handler.Login(command))
                    return false;

                return true;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

    }
}
