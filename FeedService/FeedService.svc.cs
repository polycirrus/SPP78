using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using CommonTypes;
using System.ServiceModel.Syndication;
using System.Xml;

namespace RssFeedService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class FeedService : IFeedService
    {
        private List<string> sources;
        private object syncRoot;

        public FeedService()
        {
            sources = new List<string>();
            syncRoot = new object();
        }

        public List<FeedItem> GetFeed()
        {
            List<FeedItem> result;

            if (sources.Count > 0)
            {
                IEnumerable<FeedItem> newFeed = null;

                string[] sourcesCopy;
                lock (syncRoot)
                {
                    sourcesCopy = sources.ToArray();
                }

                foreach (var source in sources)
                {
                    if (newFeed == null)
                        newFeed = FetchFeed(source);
                    else
                        newFeed = newFeed.Concat(FetchFeed(source));
                }

                result = newFeed.ToList();
            }
            else
                result = new List<FeedItem>();

            return result;
        }

        private IEnumerable<FeedItem> FetchFeed(string source)
        {
            XmlReader reader = null;
            SyndicationFeed syndicationFeed;

            //validate feed source
            try
            {
                reader = XmlReader.Create(source);
                syndicationFeed = (SyndicationFeed.Load(reader));
            }
            catch (Exception e)
            {
                throw new Exception("Unable to retrieve RSS feed from \"" + source + "\".", e);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }

            var result = syndicationFeed.Items.Select(syndicationItem => new FeedItem(syndicationItem, source)).ToList();
            result.SortByPublishDate();
            return result;
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
