using AdessoWorldLeague.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdessoWorldLeague.Infrastructure.EntitiesConfigurations
{
    /// <summary>
    /// Group entity konfigürasyonu
    /// </summary>
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            // Tablo adı
            builder.ToTable("Groups");

            // Primary key
            builder.HasKey(g => g.Id);

            // GroupName Value Object mapping
            //builder.OwnsOne(g => g.Name, gn =>
            //{
            //    gn.Property(g => g)
            //      .HasColumnName("Name")
            //      .IsRequired()
            //      .HasMaxLength(10);
            //});

            // İlişki: Grup ile Takımlar arasında çoktan çoğa ilişki
            builder.HasMany(g => g.Teams)
                .WithMany();
        }
    }
}
