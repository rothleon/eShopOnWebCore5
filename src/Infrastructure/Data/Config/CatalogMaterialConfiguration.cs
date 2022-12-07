using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.eShopWeb.ApplicationCore.Entities;

namespace Microsoft.eShopWeb.Infrastructure.Data.Config
{
    public class CatalogMaterialConfiguration : IEntityTypeConfiguration<CatalogMaterial>
    {
        //Sprint 1 - Add a new attribute, like color or gender, to catalog items. - Leon Roth
        public void Configure(EntityTypeBuilder<CatalogMaterial> builder)
        {
                builder.HasKey(ci => ci.Id);

                builder.Property(ci => ci.Id)
                   .UseHiLo("catalog_material_hilo")
                   .IsRequired();

                builder.Property(cb => cb.Material)
                    .IsRequired()
                    .HasMaxLength(100);
        }
        
    }
}
