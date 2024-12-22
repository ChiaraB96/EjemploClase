using EjemploClase.EjemploConDY;
using EjemploClase.EjemplosinDY;
using Microsoft.AspNetCore.Mvc;

namespace EjemploClase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EjemploConDYController : ControllerBase
    {
        private IEmailServiceConDY _emailServiceConDY;

        public EjemploConDYController(IEmailServiceConDY emailServiceConDY)
        {
            _emailServiceConDY = emailServiceConDY;
        }

        [HttpGet]
        public bool EnviarMail([FromQuery] string mail)
        {
            UsuarioServiceConDY usuarioServiceConDY = new UsuarioServiceConDY(_emailServiceConDY);
            return usuarioServiceConDY.enviarNotificacionUsuarioConDY(mail);
        }
    }
}
