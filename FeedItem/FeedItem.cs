using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel.Syndication;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace CommonTypes
{
    [Serializable]
    [DataContract]
    public class FeedItem
    {
        [DataMember]
        public string Source { get; private set; }

        [DataMember]
        public string Title { get; private set; }

        [DataMember]
        public string Summary { get; private set; }

        [DataMember]
        public Uri Link { get; private set; }

        [DataMember]
        public DateTimeOffset PublishDate { get; private set; }

        public FeedItem(SyndicationItem item, string source)
        {
            Title = item.Title.Text;
            Summary = item.Summary.Text;
            Source = source;
            PublishDate = item.PublishDate;

            if (item.Links.Count > 0)
                Link = item.Links[0].Uri;
            else
                Link = null;
        }

        public override string ToString()
        {
            return Title;
        }
    }
}
