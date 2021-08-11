using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MTCmodel.CustomAnnotationAttributes
{
    public class EANAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string tmp = value.ToString();

            //check if the length is correct

            if (tmp.Length != 13)
            {
                return false;
            }

            //check if all chars in value are digits

            foreach (char c in tmp)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }

            //otherwise 

            return true;
        }
    }
}

