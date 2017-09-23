using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Homework.ValidateAttribute
{
    public class DayRangeAttribute : ValidationAttribute, IClientValidatable
    {
        /// <summary>
        /// 日期範圍驗證<para>只驗證日期，不考慮時間</para>
        /// </summary>
        /// <param name="maximumDays">最大日期</param>
        public DayRangeAttribute()
        {
        }
        public override bool IsValid(object value)
        {
            if (value == null)
                return true;
            var compareDate = value as DateTime?;
            if (compareDate.HasValue)
            {
                compareDate = compareDate.Value.Date;
                return compareDate.Value <= DateTime.Today;
            }
            return false;
        }
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule
            {
                ValidationType = "dayrange",
                ErrorMessage = FormatErrorMessage(metadata.GetDisplayName())
            };
            yield return rule;
        }
    }
}