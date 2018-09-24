using AC.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AC.Persistence.Configuration
{
    public class AccountsConfig : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("TB_ACCOUNTS");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).HasColumnName("ID").ValueGeneratedOnAdd();
            builder.Property(e => e.Created).HasColumnName("CREATED").IsRequired();
            builder.Property(e => e.Money).HasColumnName("MONEY").HasColumnType("decimal(10,2)").IsRequired();
            builder.Property(e => e.StatusId).HasColumnName("STATUS_ID").IsRequired();
            builder.Property(e => e.PersonId).HasColumnName("PERSON_ID").IsRequired();
            builder.Property(e => e.Master).HasColumnName("MASTER").IsRequired().HasDefaultValue(false);

            builder.HasOne(u => u.Status);

            builder.HasOne(e => e.Person).WithMany();
                
        }
    }
    public class ChildrenAccountsConfig : IEntityTypeConfiguration<ChildrenAccounts>
    {
        public void Configure(EntityTypeBuilder<ChildrenAccounts> builder)
        {
            builder.ToTable("TB_CHILDREN_ACCOUNTS");
            builder.HasKey(t => new { t.ParentAccountId, t.ChildrenAccountId });
            builder.Property(e => e.ParentAccountId).HasColumnName("PARENT_ACCOUNT_ID");
            builder.Property(e => e.ChildrenAccountId).HasColumnName("CHILDREN_ACCOUNT_ID");
            builder.HasOne(olol => olol.ParentAccount).WithMany(col => col.ChildrenAccounts).OnDelete(DeleteBehavior.Restrict);

        }
    }
}