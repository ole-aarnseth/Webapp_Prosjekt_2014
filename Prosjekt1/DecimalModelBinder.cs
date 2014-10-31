using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prosjekt1
{
    /*
     * This class is a workaround for a Model validation bug in ASP.NET MVC for decimal variables.
     * Source: http://stackoverflow.com/a/19339424
     */

    public class DecimalModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            ValueProviderResult valueResult = bindingContext.ValueProvider
                .GetValue(bindingContext.ModelName);

            ModelState modelState = new ModelState { Value = valueResult };

            object actualValue = null;

            if (valueResult.AttemptedValue != string.Empty)
            {
                try
                {
                    actualValue = Convert.ToDecimal(valueResult.AttemptedValue, CultureInfo.CurrentCulture);
                }
                catch (FormatException e)
                {
                    modelState.Errors.Add(e);
                }
            }

            bindingContext.ModelState.Add(bindingContext.ModelName, modelState);

            return actualValue;
        }
    }
}