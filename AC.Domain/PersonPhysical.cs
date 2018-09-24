using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace AC.Domain
{
    [DataContract]
    public class PersonPhysical : Person
    {
        [Required]
        [DataMember(Name = "full_name")]
        public string FullName { get; set; }

        [Required]
        [DataMember(Name = "birth")]
        public DateTime Birth { get; set; }
    }
}
