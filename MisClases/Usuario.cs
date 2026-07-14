namespace MisClases
{
    public class Usuario
    {
        public int Pregunta_ID { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido {  get; set; }
        public string? Email { get; set; }
        public string? Contraseña { get; set; }
        public string? Telefono { get; set; }
        public string? Foto_Perfil { get; set; }
        public bool Suscripcion { get; set; }
        public string? Metodo_Entrega {  get; set; }
        public string? Respuesta_Seguridad {  get; set; }
    }
}
