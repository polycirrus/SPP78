using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using CommonTypes;

namespace RssFilterService
{
    public class FilterService : IFilterService
    {
        private List<string> sources;
        private object syncRoot;

        public FilterService()
        {
            sources = new List<string>();
            syncRoot = new object();
        }

        public List<FeedItem> FilterFeed(List<FeedItem> feed)
        {
            string[] acceptedSourcesCopy;
            lock (syncRoot)
            {
                acceptedSourcesCopy = sources.ToArray();
            }

            return feed.Where(feedItem => acceptedSourcesCopy.Contains(feedItem.Source)).ToList();
        }

        public string[] GetSources()
        {
            lock (syncRoot)
            {
                return sources.ToArray();
            }
        }

        public void RemoveSource(string source)
        {
            lock (syncRoot)
            {
                try
                {
                    sources.Remove(source);
                }
                catch (Exception e)
                {
                    throw new Exception("Unable to remove source: " + e.Message, e);
                }
            }
        }

        public void AddSource(string source)
        {
            lock (syncRoot)
            {
                sources.Add(source);
            }
        }
    }
}
