using ApiApplication.Extensions;
using Business.Interface;
using Business.Notifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiApplication.Controllers
{
    [ApiController]
    public abstract class BaseApiController : ControllerBase
    {
        protected readonly IBroadcaster _broadcaster;
         
        public BaseApiController(IBroadcaster broadcaster
                               )
        {
            _broadcaster = broadcaster;
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid)
            {
                var errors = modelState.Values.SelectMany(v => v.Errors);
                foreach (var erro in errors)
                {
                    var message = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message ;
                    _broadcaster.ToTransmit(new Notification(message));
                }
            }

            return CustomResponse();
        }

        /// <summary>
        /// Response baseado nas notificações emitidas.
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        protected ActionResult CustomResponse(object result = null)
        {

            if (_broadcaster.HasNotifications())
            {
                return BadRequest(new
                {
                    success = false,
                    errors = _broadcaster.GetNotifications().Select(i => i.Message)
                });
            }

            return Ok(new
            {
                success = true,
                data = result
            }); ;

        }

        internal void ToTransmit(string description)
        {
            _broadcaster.ToTransmit(new Notification(description));
        }

        protected void fakeError()
        {
            _broadcaster.ToTransmit(new Notification("1 fake error acionado"));
            _broadcaster.ToTransmit(new Notification("2 fake error acionado"));
        }

    }
}
