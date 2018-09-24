
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AC.Domain
{
    [DataContract]
    public class Status : BaseEntity
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "name")]
        [Required]
        public string Name { get; set; }

        public override object[] GetKey()
        {
            return new object[] { Id };
        }
    }
}
