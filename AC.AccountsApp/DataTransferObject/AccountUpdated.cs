using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace AC.AccountsApp.DataTransferObject
{
    [DataContract]
    public class AccountUpdated
    {
        [DataMember(Name = "name")]
        [Required]
        public string Name { get; set; }

        [DataMember(Name = "status_id")]
        [Required]
        public int StatusId { get; set; }

    }
}
