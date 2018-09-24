using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace AC.AccountsApp.DataTransferObject
{
    [DataContract]
    public class AccountChildrenDTO
    {
        [DataMember(Name = "name")]
        [Required]
        public string Name { get; set; }
        
        [DataMember(Name = "money")]
        [DataType(DataType.Currency)]
        public Decimal Money { get; set; }
        
        [Required]
        [DataMember(Name = "person_id")]
        public int PersonId { get; set; }

        [Required]
        [DataMember(Name = "status_id")]
        public int StatusId { get; set; }

        [Required]
        [DataMember(Name = "account_parent_id")]
        public int AccountParentId { get; set; }

    }
}
