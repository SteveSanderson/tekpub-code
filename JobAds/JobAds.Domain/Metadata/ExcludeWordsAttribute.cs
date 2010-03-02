using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JobAds.Domain.Metadata
{
    public class ExcludeWordsAttribute : Attribute
    {
        public string[] Words { get; private set; }

        public ExcludeWordsAttribute(params string[] words)
        {
            Words = words;
        }
    }
}
