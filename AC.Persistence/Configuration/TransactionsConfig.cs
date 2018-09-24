using AC.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AC.Persistence.Configuration
{
    public class TransactionsConfig : IEntityTypeConfiguration<Transactions>
    {
        public void Configure(EntityTypeBuilder<Transactions> builder)
        {
            builder.ToTable("TB_TRANSACTIONS");

            builder.HasKey(t => t.Id);
            builder.Property(e => e.Id).HasColumnName("ID").ValueGeneratedOnAdd();
            
            builder.Property(t => t.TransactionCode).HasColumnName("TRANSACTION_CODE").HasMaxLength(100);
            builder.HasIndex(e => e.TransactionCode).HasName("UNIQUE_TRANSACTION_CODE").IsUnique();

            builder.Property(t => t.Created).HasColumnName("CREATED").IsRequired();
            builder.Property(e => e.Money).HasColumnName("MONEY").HasColumnType("decimal(10,2)").IsRequired();
            builder.Property(t => t.TransactionTypeId).HasColumnName("TRANSACTION_TYPE_ID").IsRequired();

            builder.Property(t => t.Reversed).HasColumnName("REVERSED").HasDefaultValue(false);

            builder.Property(t => t.AccountDestinationId).IsRequired().HasColumnName("ACCOUNT_DESTINATION_ID").IsRequired(false);
            builder.Property(t => t.AccountSourceId).IsRequired().HasColumnName("ACCOUNT_SOURCE_ID").IsRequired(false);

            builder.HasOne(u => u.TransactionType).WithMany().OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(u => u.AccountDestination).WithMany().OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(u => u.AccountSource).WithMany().OnDelete(DeleteBehavior.Restrict);
            
        }
    }
}
