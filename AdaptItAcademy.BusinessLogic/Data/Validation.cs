using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace AdaptItAcademy.BusinessLogic.Data
{
    public class Validation
    {

        public Boolean IsLettersOnly(string input)
        {
            return Regex.IsMatch(input, @"^[a-zA-Z]+$"); ;
        }
        public Boolean IsNumbersPhone(string input)
        {
            return Regex.IsMatch(input, "^[0-9]{10,15}$");
        }

        public Boolean IsEmailAddress(string input)
        {
            return Regex.IsMatch(input, @"^S+@\S+$");
        }

        public Boolean IsNotHarmfulToDatabase(string input)
        {
            return Regex.IsMatch(input, @"^[#$%^*_\\[\]{}\\|<>\~]+$");
        }

        public Boolean AnyNullOrEmptys(object value)
        {
            foreach (PropertyInfo objProp in value.GetType().GetProperties())
            {
                if (objProp.CanRead)
                {
                    object val = objProp.GetValue(value, null);
                    if (val.GetType() == typeof(string))
                    {
                        if (val == "" || val == null)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

    }
}
