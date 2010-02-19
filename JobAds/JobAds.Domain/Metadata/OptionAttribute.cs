using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JobAds.Domain.Metadata
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple=true)]
    public class OptionAttribute : Attribute
    {
        public string DisplayText { get; set; }
        public object Value { get; set; }

        public override object TypeId
        {
            get
            {
                return this;
            }
        }
    }
}
