﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FilterExtension.FilterServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="FilterServiceReference.IFilterService")]
    public interface IFilterService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFilterService/FilterFeed", ReplyAction="http://tempuri.org/IFilterService/FilterFeedResponse")]
        CommonTypes.FeedItem[] FilterFeed(CommonTypes.FeedItem[] feed);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFilterService/FilterFeed", ReplyAction="http://tempuri.org/IFilterService/FilterFeedResponse")]
        System.Threading.Tasks.Task<CommonTypes.FeedItem[]> FilterFeedAsync(CommonTypes.FeedItem[] feed);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFilterService/GetSources", ReplyAction="http://tempuri.org/IFilterService/GetSourcesResponse")]
        string[] GetSources();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFilterService/GetSources", ReplyAction="http://tempuri.org/IFilterService/GetSourcesResponse")]
        System.Threading.Tasks.Task<string[]> GetSourcesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFilterService/RemoveSource", ReplyAction="http://tempuri.org/IFilterService/RemoveSourceResponse")]
        void RemoveSource(string source);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFilterService/RemoveSource", ReplyAction="http://tempuri.org/IFilterService/RemoveSourceResponse")]
        System.Threading.Tasks.Task RemoveSourceAsync(string source);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFilterService/AddSource", ReplyAction="http://tempuri.org/IFilterService/AddSourceResponse")]
        void AddSource(string source);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFilterService/AddSource", ReplyAction="http://tempuri.org/IFilterService/AddSourceResponse")]
        System.Threading.Tasks.Task AddSourceAsync(string source);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IFilterServiceChannel : FilterExtension.FilterServiceReference.IFilterService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class FilterServiceClient : System.ServiceModel.ClientBase<FilterExtension.FilterServiceReference.IFilterService>, FilterExtension.FilterServiceReference.IFilterService {
        
        public FilterServiceClient() {
        }
        
        public FilterServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public FilterServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FilterServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FilterServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public CommonTypes.FeedItem[] FilterFeed(CommonTypes.FeedItem[] feed) {
            return base.Channel.FilterFeed(feed);
        }
        
        public System.Threading.Tasks.Task<CommonTypes.FeedItem[]> FilterFeedAsync(CommonTypes.FeedItem[] feed) {
            return base.Channel.FilterFeedAsync(feed);
        }
        
        public string[] GetSources() {
            return base.Channel.GetSources();
        }
        
        public System.Threading.Tasks.Task<string[]> GetSourcesAsync() {
            return base.Channel.GetSourcesAsync();
        }
        
        public void RemoveSource(string source) {
            base.Channel.RemoveSource(source);
        }
        
        public System.Threading.Tasks.Task RemoveSourceAsync(string source) {
            return base.Channel.RemoveSourceAsync(source);
        }
        
        public void AddSource(string source) {
            base.Channel.AddSource(source);
        }
        
        public System.Threading.Tasks.Task AddSourceAsync(string source) {
            return base.Channel.AddSourceAsync(source);
        }
    }
}