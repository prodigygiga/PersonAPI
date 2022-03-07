using System;
using System.ComponentModel.DataAnnotations;

namespace PersonDirectory.Presentation.WebApi.Attributes
{
    public class MinimumAgeAttribute : ValidationAttribute
    {
        private int minAge;
        public MinimumAgeAttribute(int minAge) => this.minAge = minAge;

        public override bool IsValid(object value)
        {
            if (value == null)
                return false;
            DateTime dt = Convert.ToDateTime(value);
            return dt.Date.AddYears(minAge) <= DateTime.Now.Date;

        }
    }
}
