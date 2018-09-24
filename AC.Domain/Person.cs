using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace AC.Domain
{

    [DataContract]
    public abstract class Person : BaseEntity
    {

        [DataMember(Name = "id")]
        public int Id { get; set; }

        [Required]
        [DataMember(Name = "document")]
        public string Document { get; set; }
        
        public override object[] GetKey()
        {
            return new object[] { Id };
        }
    }
}
