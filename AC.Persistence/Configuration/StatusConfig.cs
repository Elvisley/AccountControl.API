using AC.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;
using System.Collections.Generic;
using System.Text;

namespace AC.Persistence.Configuration
{
    public class StatusConfig : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.ToTable("TB_STATUS");

            builder.HasKey(t => t.Id);
            builder.Property(e => e.Id).HasColumnName("ID").ValueGeneratedOnAdd();
            builder.Property(t => t.Name).IsRequired().HasColumnName("NAME").HasMaxLength(60);

        }
    }
}
