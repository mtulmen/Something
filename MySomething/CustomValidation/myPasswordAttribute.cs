using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MySomething.CustomValidation
{
    public class myPasswordAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return false;
            }
            string strVal = value.ToString();

            bool intVarmi = false;
            bool stringVarmi = false;
            foreach (var item in strVal)
            {
                if (char.IsNumber(item))
                    intVarmi = true;
                else
                    stringVarmi = true;
            }
            if (stringVarmi && intVarmi)
                return true;
            else
            {
                ErrorMessage = "Password en az bir karakter ve sayı içermelidir.";
                return false;
            }
        }
    }
}