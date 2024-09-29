using AdessoWorldLeague.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdessoWorldLeague.Infrastructure.EntitiesConfigurations
{
    /// <summary>
    /// Team entity konfigürasyonu
    /// </summary>
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            // Tablo adı
            builder.ToTable("Teams");

            // Primary key
            builder.HasKey(t => t.Id);

            // TeamName Value Object mapping
            builder.OwnsOne(t => t.Name, tn =>
            {
                tn.Property(t => t.Value)
                  .HasColumnName("Name")
                  .IsRequired()
                  .HasMaxLength(100);
            });

            // CountryId zorunlu
            builder.Property(t => t.CountryId)
                .IsRequired();

            // İlişki: Bir takım bir ülkeye aittir
            builder.HasOne(t => t.Country)
                .WithMany(c => c.Teams)
                .HasForeignKey(t => t.CountryId);
        }
    }
}
