using AdessoWorldLeague.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdessoWorldLeague.Infrastructure.EntitiesConfigurations
{
    /// <summary>
    /// Draw entity konfigürasyonu
    /// </summary>
    public class DrawConfiguration : IEntityTypeConfiguration<Draw>
    {
        public void Configure(EntityTypeBuilder<Draw> builder)
        {
            // Tablo adı
            builder.ToTable("Draws");

            // Primary key
            builder.HasKey(d => d.Id);

            // DrawDate zorunlu
            builder.Property(d => d.DrawDate)
                .IsRequired();

            // PersonId zorunlu
            builder.Property(d => d.PersonId)
                .IsRequired();

            // İlişki: Bir kura bir kişiye aittir
            builder.HasOne(d => d.Person)
                .WithMany(p => p.Draws)
                .HasForeignKey(d => d.PersonId);

            // İlişki: Bir kuranın birden çok grubu olabilir
            builder.HasMany(d => d.Groups)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
