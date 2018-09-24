using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace AC.PersonApp.DataTransferObject
{
    [DataContract]
    public class PersonLegalDTO
    {
       
        [DataMember(Name = "document")]
        [Required]
        public string Document { get; set; }

        
        [DataMember(Name = "fantasy_name")]
        [Required]
        public string FantasyName { get; set; }

       
        [DataMember(Name = "social_reason")]
        [Required]
        public string SocialReason { get; set; }
    }
}
