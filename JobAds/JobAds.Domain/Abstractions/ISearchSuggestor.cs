using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JobAds.Domain.Abstractions
{
    public interface ISearchSuggestor
    {
        string GetSuggestion(string text);

        IAsyncResult BeginGetSuggestion(string text, AsyncCallback cb);
        string EndGetSuggestion(IAsyncResult asyncResult);
    }
}
