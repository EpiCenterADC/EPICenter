using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiCenterBaseProject.Business.Interfaces;
using EPiCenterBaseProject.Entities;
using System.ServiceModel.Syndication;
using System.Net;
using System.IO;
using System.Xml;
using System.Globalization;
using System.Text.RegularExpressions;

namespace EPiCenterBaseProject.Business
{
    public class RSSService : IRSSService
    {
        public IEnumerable<RSSEntity> GetRSSData(string RSSUrl)
        {
            var RssFeed = GetNewsFeedItems(RSSUrl);
            return RssFeed;
        }

        private IEnumerable<RSSEntity> GetNewsFeedItems(string rssFeedUrl)
        {
            var newsItems = new List<RSSEntity>();
            try
            {
                WebRequest webRequest = WebRequest.Create(rssFeedUrl);

                
                var httpWebRequest = webRequest as HttpWebRequest;

                httpWebRequest.UserAgent = "EPiCenter";

                using (var webResponse = (WebResponse)httpWebRequest.GetResponse())
                {
                    using (Stream responseStream = webResponse.GetResponseStream())
                    {
                        using (var reader = new MyXmlReader(responseStream))
                        {
                            //TODO : DTD reader setting false.
                            var rssData = SyndicationFeed.Load(reader);
                            foreach (var feedItem in rssData.Items)
                            {
                                var newsitem = new RSSEntity
                                {
                                    Title = feedItem.Title.Text.ToString(),
                                    Description = string.IsNullOrEmpty(Convert.ToString(feedItem.Summary.Text)) ? 
                                                    string.Empty : 
                                                   (Convert.ToString(feedItem.Summary.Text).Length > 250 ? 
                                                        RemoveHTMLTags(Convert.ToString(feedItem.Summary.Text).Substring(0,250) + "...") : 
                                                        RemoveHTMLTags(Convert.ToString(feedItem.Summary.Text))),
                                    Link = feedItem.Links.FirstOrDefault().Uri.ToString(),
                                    Date = feedItem.PublishDate.DateTime.ToString()

                                };
                                newsItems.Add(newsitem);
                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {
            }
            return newsItems;
        }

        private string RemoveHTMLTags(string stringValueToFilter)
        {

            if (!string.IsNullOrEmpty(stringValueToFilter))
            {
                Regex objRegex = new Regex("<(.|\n)+?>");

                //Replace all HTML tag matches with the empty string
                stringValueToFilter = objRegex.Replace(stringValueToFilter, "");
                //Replace all &nbsp; with space;
                stringValueToFilter = stringValueToFilter.Replace("&nbsp;", " ");
                objRegex = null;

            } //end of If IsNothing(stringValueToFilter) = False

            return HttpContext.Current.Server.HtmlDecode(stringValueToFilter);

        }
    }



    class MyXmlReader : XmlTextReader
    {
        private bool readingDate = false;
        const string CustomUtcDateTimeFormat = "ddd MMM dd HH:mm:ss Z yyyy"; // Wed Oct 07 08:00:07 GMT 2009

        public MyXmlReader(Stream s) : base(s) { }

        public MyXmlReader(string inputUri) : base(inputUri) { }

        public override void ReadStartElement()
        {
            if (string.Equals(base.NamespaceURI, string.Empty, StringComparison.InvariantCultureIgnoreCase) &&
                (string.Equals(base.LocalName, "lastBuildDate", StringComparison.InvariantCultureIgnoreCase) ||
                string.Equals(base.LocalName, "pubDate", StringComparison.InvariantCultureIgnoreCase)))
            {
                readingDate = true;
            }
            base.ReadStartElement();
        }

        public override void ReadEndElement()
        {
            if (readingDate)
            {
                readingDate = false;
            }
            base.ReadEndElement();
        }

        public override string ReadString()
        {
            if (readingDate)
            {
                try
                {
                    string dateString = base.ReadString();
                    DateTime dt;
                    if (DateTime.TryParse(dateString, out dt))
                    {
                        return dt.ToUniversalTime().ToString("R", CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        return DateTime.MaxValue.ToString("R", CultureInfo.InvariantCulture);
                    }
                }
                catch
                {
                    return DateTime.MaxValue.ToString("R", CultureInfo.InvariantCulture);
                }
            }
            else
            {
                return base.ReadString();
            }
        }
    }

}


