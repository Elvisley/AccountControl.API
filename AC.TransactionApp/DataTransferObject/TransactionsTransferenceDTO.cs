using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace AC.TransactionApp.DataTransferObject
{
    [DataContract]
    public class TransactionsTransferenceDTO
    {
        [DataMember(Name = "money")]
        [Required]
        public Decimal Money { get; set; }

        [DataMember(Name = "account_destination_id")]
        [Required]
        public int AccountDestinationId { get; set; }

        [DataMember(Name = "account_source_id")]
        [Required]
        public int AccountSourceId { get; set; }

    }
}
