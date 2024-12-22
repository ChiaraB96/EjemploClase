namespace EjemploClase.EjemploConDY
{
    public class UsuarioServiceConDY
    {
        private IEmailServiceConDY _emailServiceConDY;

        public UsuarioServiceConDY(IEmailServiceConDY emailServiceConDY)
        {
            _emailServiceConDY = emailServiceConDY;
        }

        public bool enviarNotificacionUsuarioConDY(string email) 
        {
            _emailServiceConDY.Enviar(email, "Notificacion");
            return true;
        }
    }
}
