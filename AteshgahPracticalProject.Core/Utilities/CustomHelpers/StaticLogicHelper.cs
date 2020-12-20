using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AteshgahPracticalProject.Core.Utilities.CustomHelpers
{
    public static class StaticLogicHelper
    {
        public static string UpdatePhoneNumber(string phoneNumber)
        {
            phoneNumber = phoneNumber.Substring(4, phoneNumber.Length - 4);
            phoneNumber = phoneNumber.Replace("(", "");
            phoneNumber = phoneNumber.Replace(")", "");
            phoneNumber = phoneNumber.Replace("-", "");

            return phoneNumber;
        }
    }
}
