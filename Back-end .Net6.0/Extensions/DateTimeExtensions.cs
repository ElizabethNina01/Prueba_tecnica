using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prueba_back.Extensions
{
    public static class DateTimeExtensions
    {
        public static int GetAgeByBirthDate(this DateTime birthday)
        {
            var today = DateTime.Today;
            var age = today.Year - birthday.Year;

            if (birthday.Date > today.AddYears(-age)) age--;

            return age;
        }
    }
}
