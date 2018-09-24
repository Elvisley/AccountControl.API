using AC.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;
using System.Collections.Generic;
using System.Text;

namespace AC.Persistence.Configuration
{
    public class PersonConfig : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("TB_PERSONS");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("ID").ValueGeneratedOnAdd();
            builder.Property(e => e.Document).HasColumnName("DOCUMENT");

            builder.HasDiscriminator<string>("PERSON_TYPE")
           .HasValue<Person>("PERSON_BASE")
           .HasValue<PersonLegal>("PERSON_LEGAL");

            builder.HasDiscriminator<string>("PERSON_TYPE")
           .HasValue<Person>("PERSON_BASE")
           .HasValue<PersonPhysical>("PERSON_PHYSICAL");
        }
    }

    public class PersonLegalConfig : IEntityTypeConfiguration<PersonLegal>
    {
        public void Configure(EntityTypeBuilder<PersonLegal> builder)
        {
            builder.Property(e => e.FantasyName).HasColumnName("FANTASY_NAME");
            builder.Property(e => e.SocialReason).HasColumnName("SOCIAL_REASON");
        }
    }

    public class PersonPhysicalConfig : IEntityTypeConfiguration<PersonPhysical>
    {
        public void Configure(EntityTypeBuilder<PersonPhysical> builder)
        {
            builder.Property(e => e.FullName).HasColumnName("FULL_NAME");
            builder.Property(e => e.Birth).HasColumnName("BIRTH");
        }
    }
}
