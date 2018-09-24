using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace AC.Domain
{
    [DataContract]
    public class TransactionsType : BaseEntity
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "name")]
        [Required]
        public string Name { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        public override object[] GetKey()
        {
            return new object[] { Id };
        }
    }
}
