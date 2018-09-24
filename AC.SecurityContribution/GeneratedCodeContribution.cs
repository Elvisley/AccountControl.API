using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace AC.SecurityContribution
{
    public class GeneratedCodeContribution
    {
        public static string GetCode()
        {
            return Guid.NewGuid().ToString().Replace("-","");
            //return Guid.NewGuid().ToString().Substring(0, Guid.NewGuid().ToString().IndexOf("-"));
        }
    }
}
