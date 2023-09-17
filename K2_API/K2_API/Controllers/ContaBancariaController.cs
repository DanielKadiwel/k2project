using K2_API.Controllers.Base;
using K2_Domain.Commands;
using K2_Domain.CommandsResults;
using K2_Domain.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace K2_API.Controllers
{
    [Route("api/conta-bancaria")]
    [ApiController]
    public class ContaBancariaController : BaseController
    {
        private readonly ContaBancariaHandler _handler;

        public ContaBancariaController(ContaBancariaHandler handler) :base(handler)
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

        [HttpGet("saldo")]
        public string SaldoConta([FromBody] BuscarSaldoContaBancariaCommand command)
        {
            try
            {
                var result = _handler.BuscarSaldo(command);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("extrato")]
        public string ExtratoConta([FromBody] ContaBancariaCommand command)
        {
            try
            {
                var result = _handler.BuscarExtrato(command);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
