using Core.Cuentas.Domain.Entities;
using Core.Cuentas.Shared.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Cuentas.Persistence.Repositories.EFCore.Config
{
    public class movimientoConfig : IEntityTypeConfiguration<movimiento>
    {
        public void Configure(EntityTypeBuilder<movimiento> builder)
        {
            builder.ToTable("movimiento");
            builder.HasKey(p => p.movimiento_id);

            builder.Property(c => c.monto).HasPrecision(18, 2);
            builder.Property(c => c.saldo_resultante).HasPrecision(18, 2);

            //Relación muchos a uno
            builder.HasOne(p => p.cuenta).WithMany(p => p.movimientos).HasForeignKey(p => p.cuenta_id).IsRequired(false).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
