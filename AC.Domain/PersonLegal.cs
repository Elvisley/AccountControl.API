using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace AC.Domain
{
    [DataContract]
    public class PersonLegal : Person
    {
        [Required]
        [DataMember(Name = "fantasy_name")]
        public string FantasyName { get; set; }

        [Required]
        [DataMember(Name = "social_reason")]
        public string SocialReason { get; set; }
    }
}
