using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace AC.TransactionApp.DataTransferObject
{
    [DataContract]
    public class TransactionsReversalDTO
    {
        [DataMember(Name = "transaction_id")]
        [Required]
        public int TransactionId { get; set; }

        [DataMember(Name = "transaction_code")]
        public string TransactionCode { get; set; }

    }
}
