using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JobAds.Domain.Abstractions;
using System.Xml.Linq;
using System.Xml;
using System.Net;

namespace JobAds.Domain.Services
{
    public class GoogleSearchSuggestor : ISearchSuggestor
    {
        public string GetSuggestion(string text)
        {
            var req = BuildXmlPost(ApiUrl, BuildRequestXml(text));
            using (var response = req.GetResponse())
            {
                var resultXml = GetXmlFromResponse(response);
                return CreateSuggestionText(text, resultXml);
            }
        }

        public IAsyncResult BeginGetSuggestion(string text, AsyncCallback cb)
        {
            var req = BuildXmlPost(ApiUrl, BuildRequestXml(text));
            return req.BeginGetResponse(cb, 
                new AsyncState { Text = text, WebRequest = req }
            );
        }

        public string EndGetSuggestion(IAsyncResult asyncResult)
        {
            var asyncState = (AsyncState)asyncResult.AsyncState;
            using (var response = asyncState.WebRequest.EndGetResponse(asyncResult))
            {
                var resultXml = GetXmlFromResponse(response);
                return CreateSuggestionText(asyncState.Text, resultXml);
            }
        }

        private class AsyncState
        {
            public WebRequest WebRequest { get; set; }
            public string Text { get; set; }
        }

        const string ApiUrl = "https://www.google.com/tbproxy/spell?lang=en&hl=en";

        private string CreateSuggestionText(string text, XDocument spellingResult)
        {
            string originalText = text;
            var corrections = from c in spellingResult.Descendants("c")
                              where c.Attribute("s").Value == "1"
                              orderby int.Parse(c.Attribute("o").Value) descending
                              select new
                              {
                                  Offset = int.Parse(c.Attribute("o").Value),
                                  OriginalLength = int.Parse(c.Attribute("l").Value),
                                  NewWords = c.Value.Split('\t')
                              };
            foreach (var correction in corrections)
            {
                text = text.Substring(0, correction.Offset)
                       + correction.NewWords.First()
                       + text.Substring(correction.Offset + correction.OriginalLength);
            }
            return text == originalText ? null : text;
        }

        private XDocument GetXmlFromResponse(WebResponse response)
        {
            return XDocument.Load(XmlReader.Create(response.GetResponseStream()));
        }

        private XDocument BuildRequestXml(string text)
        {
            return new XDocument(
                new XElement("spellrequest",
                    new XAttribute("textalreadyclipped", "0"),
                    new XAttribute("ignoreups", "1"),
                    new XAttribute("ignoredigits", "1"),
                    new XAttribute("ignoreallcaps", "0"),
                    new XElement("text", text)
                )
            );
        }

        private WebRequest BuildXmlPost(string url, XDocument content)
        {
            var bytes = Encoding.UTF8.GetBytes(content.ToString());

            WebRequest req = WebRequest.Create(ApiUrl);
            req.Method = "POST";
            using (var reqStream = req.GetRequestStream())
            {
                reqStream.Write(bytes, 0, (int)bytes.Length);
            }
            return req;
        }
    }
}
