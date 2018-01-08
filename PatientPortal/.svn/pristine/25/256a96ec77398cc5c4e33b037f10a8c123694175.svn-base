using PatientPortal.Domain.LogManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PatientPortal.CMS.Binders
{
    public class DateTimeModelBinder: System.Web.Mvc.IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, System.Web.Mvc.ModelBindingContext bindingContext)
        {
            var vpr = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

            if (vpr == null)
            {
                return null;

            }

            var date = vpr.AttemptedValue;

            if (String.IsNullOrEmpty(date))
            {
                return null;
            }

            // Set the ModelState to the first attempted value before we have converted the date. This is to ensure that the ModelState has
            // a value. When we have converted it, we will override it with a full universal date.
            bindingContext.ModelState.SetModelValue(bindingContext.ModelName, bindingContext.ValueProvider.GetValue(bindingContext.ModelName));

            try
            {
                var realDate = DateTime.Parse(date, System.Globalization.CultureInfo.GetCultureInfoByIetfLanguageTag("en-GB"));

                // Now set the ModelState value to a full value so that it can always be parsed using InvarianCulture, which is the
                // default for QueryStringValueProvider.
                bindingContext.ModelState.SetModelValue(bindingContext.ModelName, new System.Web.Mvc.ValueProviderResult(date, realDate.ToString("yyyy-MM-dd hh:mm:ss"), System.Globalization.CultureInfo.GetCultureInfoByIetfLanguageTag("en-GB")));

                return realDate;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);

                return null;
            }
        }
    }
}