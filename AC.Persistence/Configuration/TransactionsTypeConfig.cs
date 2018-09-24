using AC.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AC.Persistence.Configuration
{
    public class TransactionsTypeConfig : IEntityTypeConfiguration<TransactionsType>
    {
        public void Configure(EntityTypeBuilder<TransactionsType> builder)
        {
            builder.ToTable("TB_TRANSACTION_TYPE");

            builder.HasKey(t => t.Id);
            builder.Property(e => e.Id).HasColumnName("ID").ValueGeneratedOnAdd();
            builder.Property(t => t.Name).IsRequired().HasColumnName("NAME").HasMaxLength(60);
            builder.Property(t => t.Description).IsRequired(false).HasColumnName("DESCRIPTION").HasMaxLength(256);
        }
    }
}
