using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project2020.Utilities
{
    public class BCode : ValidationAttribute
    {
        private readonly string bCodeFormat;

        public BCode(string bCodeFormat)
        {
            this.bCodeFormat = bCodeFormat;
        }

        public override bool IsValid(object value)
        {
            string strings = value.ToString().Substring(0,1);
            return strings.ToUpper() == bCodeFormat.ToUpper();

        }
    }
}

