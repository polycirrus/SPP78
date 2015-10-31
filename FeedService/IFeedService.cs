using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using CommonTypes;

namespace RssFeedService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IFeedService
    {
        [OperationContract]
        List<FeedItem> GetFeed();

        [OperationContract]
        string[] GetSources();

        [OperationContract]
        void RemoveSource(string source);

        [OperationContract]
        void AddSource(string source);
    }
}
