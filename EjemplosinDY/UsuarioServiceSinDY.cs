namespace EjemploClase.EjemplosinDY
{
    public class UsuarioServiceSinDY
    {
        public EmailServiceSinDY emailServiceSinDY { get; set; }

        public UsuarioServiceSinDY()
        {
            emailServiceSinDY = new EmailServiceSinDY();
        }
        public bool EnviarNotificacionUsuario(string email) 
        {
            emailServiceSinDY.Enviar(email, "notificacion");
            return true;
        }
    }
}
