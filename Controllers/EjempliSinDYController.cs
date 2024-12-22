using EjemploClase.EjemplosinDY;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EjemploClase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EjempliSinDYController : ControllerBase
    {
        [HttpGet]
        public bool EnviarMail([FromQuery]string mail) 
        { 
            UsuarioServiceSinDY usuarioServiceSinDY = new UsuarioServiceSinDY();
            return usuarioServiceSinDY.EnviarNotificacionUsuario(mail);

            //new UsuarioServiceSinDY ---> new EmailServiceSinDY ---> Enviar...
        }
    }
}
