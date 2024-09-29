using AdessoWorldLeague.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdessoWorldLeague.Infrastructure.EntitiesConfigurations
{
    /// <summary>
    /// Country entity konfigürasyonu
    /// </summary>
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            // Tablo adı
            builder.ToTable("Countries");

            // Primary key
            builder.HasKey(c => c.Id);

            // Name özelliği zorunlu ve maksimum 100 karakter
            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            // İlişki: Bir ülkenin birden çok takımı olabilir
            builder.HasMany(c => c.Teams)
                .WithOne(t => t.Country)
                .HasForeignKey(t => t.CountryId);
        }
    }
}
