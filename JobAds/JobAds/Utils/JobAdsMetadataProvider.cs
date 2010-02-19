using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobAds.Domain.Metadata;

namespace JobAds.Utils
{
    public class JobAdsMetadataProvider : DataAnnotationsModelMetadataProvider
    {
        protected override ModelMetadata CreateMetadata(IEnumerable<Attribute> attributes, Type containerType, Func<object> modelAccessor, Type modelType, string propertyName)
        {
            var metadata = base.CreateMetadata(attributes, containerType, modelAccessor, modelType, propertyName);

            if (modelType == typeof(DateTime)
                  && propertyName != null
                  && propertyName.EndsWith("Date"))
            {
                metadata.EditFormatString = "{0:yyyy/MM/dd}";
            }

            var options = attributes.OfType<OptionAttribute>();
            if (options.Any())
            {
                metadata.AdditionalValues["optionValues"]
                     = options.ToDictionary(x => x.Value, x => x.DisplayText);
                metadata.TemplateHint = "RadioButtons";
            }

            return metadata;
        }
    }
}
