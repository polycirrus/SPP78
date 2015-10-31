using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using CommonTypes;

namespace RssNewsletterService
{
    [ServiceContract]
    public interface INewsletterService
    {
        [OperationContract]
        void SendNewsItems(FeedItem[] items, string[] addresses);
    }
}
