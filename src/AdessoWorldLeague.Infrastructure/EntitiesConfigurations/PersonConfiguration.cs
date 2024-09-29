using AdessoWorldLeague.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdessoWorldLeague.Infrastructure.EntitiesConfigurations
{
    /// <summary>
    /// Person entity konfigürasyonu
    /// </summary>
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            // Tablo adı
            builder.ToTable("Persons");

            // Primary key
            builder.HasKey(p => p.Id);

            // FirstName ve LastName özellikleri zorunlu ve maksimum 50 karakter
            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(50);

            // İlişki: Bir kişinin birden çok kura çekimi olabilir
            builder.HasMany(p => p.Draws)
                .WithOne(d => d.Person)
                .HasForeignKey(d => d.PersonId);
        }
    }
}
