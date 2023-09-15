using K2_Domain.Handlers.Base.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace K2_API.Controllers.Base
{
    public class BaseController : Controller
    {
        private readonly IHandler _handler;

        protected BaseController(IHandler handler)
        {
            _handler = handler;
        }

        protected new IActionResult Response(object result)
        {
            var notifications = _handler?.Notifications();

            if (notifications?.Count == 0)
            {
                return Ok(result);
            }

            return BadRequest(notifications);
        }
    }
}
