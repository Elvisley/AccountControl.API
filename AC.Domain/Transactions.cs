using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace AC.Domain
{

    [DataContract]
    public class Transactions : BaseEntity
    {
        [DataMember(Name = "id")]
        [Required]
        public int Id { get; set; }

        [DataMember(Name = "transaction_code")]
        [Required]
        public string TransactionCode { get; set; }

        [DataMember(Name = "created")]
        [Required]
        public DateTime Created { get; set; }

        [DataMember(Name = "money")]
        [Required]
        public Decimal Money { get; set; }

        [DataMember(Name = "transaction_type_id")]
        [Required]
        public int TransactionTypeId { get; set; }

        [DataMember(Name = "transaction_type")]
        public virtual TransactionsType TransactionType { get; set; }

        [DataMember(Name = "account_destination_id")]
        [Required]
        public int? AccountDestinationId { get; set; }

        [DataMember(Name = "account_destination")]
        public virtual Account AccountDestination { get; set; }

        [DataMember(Name = "account_source_id")]
        public int? AccountSourceId { get; set; }

        [DataMember(Name = "account_source")]
        public virtual Account AccountSource { get; set; }

        [DataMember(Name = "reversed")]
        public bool Reversed { get; set; }

        public override object[] GetKey()
        {
            return new object[] { Id };
        }
    }
}
