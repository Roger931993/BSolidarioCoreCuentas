namespace Core.Cuentas.Domain.Entities
{
    public class secuencial: BaseEntity
    {
        public int secuencial_id { get; set; }
        public string? descripcion { get; set; } //producto_id
        public int? valor { get; set; }
    }
}
