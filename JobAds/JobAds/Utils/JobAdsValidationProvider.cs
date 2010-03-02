using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobAds.Domain.Metadata;

namespace JobAds.Utils
{
    public class JobAdsValidationProvider : AssociatedValidatorProvider
    {
        protected override IEnumerable<ModelValidator> GetValidators(ModelMetadata metadata, ControllerContext context, IEnumerable<Attribute> attributes)
        {
            var excludeWordsAttributes = attributes.OfType<ExcludeWordsAttribute>();
            foreach (var excludedWordsAttribute in excludeWordsAttributes)
                yield return new ExcludedWordsValidator(metadata, context, excludedWordsAttribute.Words);
        }

        private class ExcludedWordsValidator : ModelValidator
        {
            private readonly string[] excludedWords;
            private const string ErrorMessage = "Don't use the word '{0}'";

            public ExcludedWordsValidator(ModelMetadata metadata, ControllerContext controllerContext, string[] wordsToExclude)
                : base(metadata, controllerContext)
            {
                this.excludedWords = wordsToExclude;
            }

            public override IEnumerable<ModelValidationResult> Validate(object container)
            {
                if (Metadata.Model == null)
                    yield break;

                var model = Metadata.Model.ToString();
                foreach (var word in excludedWords)
                    if (model.Contains(word))
                        yield return new ModelValidationResult {
                            Message = string.Format(ErrorMessage, word)
                        };
            }

            public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
            {
                var rule = new ModelClientValidationRule
                {
                    ErrorMessage = ErrorMessage,
                    ValidationType = "ExcludedWords"
                };
                rule.ValidationParameters["words"] = excludedWords;
                yield return rule;
            }
        }
    }
}
