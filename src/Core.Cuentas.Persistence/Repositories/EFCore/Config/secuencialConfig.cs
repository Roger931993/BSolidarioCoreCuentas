using Core.Cuentas.Domain.Entities;
using Core.Cuentas.Shared.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Cuentas.Persistence.Repositories.EFCore.Config
{
    public class secuencialConfig : IEntityTypeConfiguration<secuencial>
    {
        public void Configure(EntityTypeBuilder<secuencial> builder)
        {
            builder.ToTable("secuencial");
            builder.HasKey(p => p.secuencial_id);
        }
    }
}
