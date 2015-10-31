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
    [ServiceContract]
    public interface IFilterService
    {
        [OperationContract]
        List<FeedItem> FilterFeed(List<FeedItem> feed);

        [OperationContract]
        string[] GetSources();

        [OperationContract]
        void RemoveSource(string source);

        [OperationContract]
        void AddSource(string source);
    }
}
