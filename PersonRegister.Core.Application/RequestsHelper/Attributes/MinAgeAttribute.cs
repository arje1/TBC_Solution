using System;
using System.ComponentModel.DataAnnotations;

namespace PersonRegister.Core.Application.RequestsHelper.Attributes
{
    public class MinAgeAttribute : ValidationAttribute
    {
        private int minAge;
        public MinAgeAttribute(int minAge) => this.minAge = minAge;

        public override bool IsValid(object value)
        {
            DateTime d = Convert.ToDateTime(value);
            return d.Date.AddYears(minAge) <= DateTime.Now.Date;

        }
    }
}
