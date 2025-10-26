using Core.Cuentas.Domain.Entities;
using Core.Cuentas.Shared.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Cuentas.Persistence.Repositories.EFCore.Config
{
    public class cuentaConfig : IEntityTypeConfiguration<cuenta>
    {
        public void Configure(EntityTypeBuilder<cuenta> builder)
        {
            builder.ToTable("cuenta");
            builder.HasKey(p => p.cuenta_id);    
            
            builder.Property(c=>c.saldo_actual).HasPrecision(18,2);
            builder.Property(c => c.saldo_disponible).HasPrecision(18, 2);
            builder.Property(c => c.tasa_interes).HasPrecision(18, 2);

            // Relación muchos a uno
            //builder.HasOne(p => p.invoice).WithMany(p => p.invoice_cancel).HasForeignKey(p => p.invoice_id).IsRequired(false).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
