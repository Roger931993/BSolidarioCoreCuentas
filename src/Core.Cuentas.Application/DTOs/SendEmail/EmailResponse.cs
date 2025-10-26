namespace Core.Cuentas.Application.DTOs.SendEmail
{
    public class EmailResponse
    {
        public bool Success { get; set; }
        public int CodeError { get; set; }
        public string? MensajeError { get; set; }
    }
}