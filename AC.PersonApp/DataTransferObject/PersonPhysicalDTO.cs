using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace AC.PersonApp.DataTransferObject
{
    [DataContract]
    public class PersonPhysicalDTO
    {
        
        [DataMember(Name = "document")]
        [Required]
        public string Document { get; set; }

        
        [DataMember(Name = "full_name")]
        [Required]
        public string FullName { get; set; }

        
        [DataMember(Name = "birth")]
        [Required]
        public DateTime Birth { get; set; }
    }
}
