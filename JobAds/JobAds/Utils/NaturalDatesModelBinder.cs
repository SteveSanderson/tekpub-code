using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DateTimeParser;

namespace JobAds.Utils
{
    public class NaturalDatesModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, 
                                ModelBindingContext bindingContext)
        {
            // Ensure there's some incoming data
            string key = bindingContext.ModelName;
            var valueProviderResult = bindingContext.ValueProvider.GetValue(key);
            if (valueProviderResult == null || string.IsNullOrEmpty(valueProviderResult.AttemptedValue))
                return null;

            // Preserve it in case we have to redisplay the form
            bindingContext.ModelState.SetModelValue(key, valueProviderResult);

            // Now parse
            var rawText = ((string[])valueProviderResult.RawValue)[0];
            if (CanParseText(rawText))
                return DateTimeEnglishParser.ParseRelative(DateTime.Now, rawText);
            else
            {
                // There was a parsing error
                bindingContext.ModelState.AddModelError(key, "A valid DateTime is required");
                return null;
            }
        }

        private bool CanParseText(string rawText)
        {
            // Not very pretty, but DateTimeEnglishParser provides no other way
            // to determine whether parsing was successful
            var sample = new DateTime(2001, 01, 01);
            return sample != DateTimeEnglishParser.ParseRelative(sample, rawText);
        }
    }
}
