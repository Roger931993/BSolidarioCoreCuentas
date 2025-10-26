using Core.Cuentas.Domain.Entities;
using Core.Cuentas.Shared.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Cuentas.Persistence.Repositories.EFCore.Config.Logs
{
    public class api_log_Cliente_detailConfig : IEntityTypeConfiguration<api_log_cuenta_detail>
    {
        public void Configure(EntityTypeBuilder<api_log_cuenta_detail> builder)
        {
            builder.ToTable("api_log_cuenta_detail", Generals.General.schema_db_logs);
            builder.HasKey(p => p.api_log_cuenta_detail_id);
            builder.Property(x => x.data_message).HasColumnType("text");

            builder.Property(e => e.api_log_cuenta_header_id).HasColumnName("api_log_cuenta_header_id");

            builder.Property(e => e.api_log_cuenta_detail_id)
              .HasColumnName("api_log_cuenta_detail_id")
              .UseIdentityAlwaysColumn();

            builder.HasOne(x => x.api_log_cuenta_header)
               .WithMany(h => h.api_log_cuenta_detail)
               .HasForeignKey(x => x.api_log_cuenta_header_id)
               .HasConstraintName("fk_cuenta_header_detail");           
        }
    }
}
