using System;
using System.Collections.Generic;
using System.Text;

namespace AC.Domain
{
    public class ChildrenAccounts : BaseEntity
    {
        public Account ParentAccount { get; set; }

        public Account ChildrenAccount { get; set; }

        public int ChildrenAccountId { get; set; }

        public int ParentAccountId { get; set; }

        public override object[] GetKey()
        {
            return new object[] { ChildrenAccountId, ParentAccountId };
        }
    }
}
