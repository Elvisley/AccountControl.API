using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace AC.Domain
{

    [DataContract]
    public class Account : BaseEntity
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "name")]
        [Required]
        public string Name { get; set; }

        [DataMember(Name = "created")]
        public DateTime Created { get; set; }

        [DataMember(Name = "money")]
        [DataType(DataType.Currency)]
        public Decimal Money { get; set; }

        [DataMember(Name = "master")]
        public Boolean Master { get; set; }

        [Required]
        [DataMember(Name = "person_id")]
        public int PersonId { get; set; }

        [DataMember(Name = "person")]
        public virtual Person Person { get; set; }

        [DataMember(Name = "status_id")]
        public int StatusId { get; set; }

        [DataMember(Name = "status")]
        public virtual Status Status { get; set; }

        [DataMember(Name = "children_accounts")]
        public virtual ICollection<ChildrenAccounts> ChildrenAccounts { get; set; }

        public override object[] GetKey()
        {
            return new object[] { Id };
        }

    }
}
