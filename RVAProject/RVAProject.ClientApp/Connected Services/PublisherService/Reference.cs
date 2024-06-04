﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RVAProject.ClientApp.PublisherService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="PublisherService.IPublisherService")]
    public interface IPublisherService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPublisherService/AddPublisher", ReplyAction="http://tempuri.org/IPublisherService/AddPublisherResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(RVAProject.Common.CustomAppException), Action="http://tempuri.org/IPublisherService/AddPublisherCustomAppExceptionFault", Name="CustomAppException", Namespace="http://schemas.datacontract.org/2004/07/RVAProject.Common")]
        void AddPublisher(RVAProject.Common.DTOs.PublisherDTO.PublisherRequest publisherRequest);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPublisherService/AddPublisher", ReplyAction="http://tempuri.org/IPublisherService/AddPublisherResponse")]
        System.Threading.Tasks.Task AddPublisherAsync(RVAProject.Common.DTOs.PublisherDTO.PublisherRequest publisherRequest);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPublisherService/GetAllPublishers", ReplyAction="http://tempuri.org/IPublisherService/GetAllPublishersResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(RVAProject.Common.CustomAppException), Action="http://tempuri.org/IPublisherService/GetAllPublishersCustomAppExceptionFault", Name="CustomAppException", Namespace="http://schemas.datacontract.org/2004/07/RVAProject.Common")]
        RVAProject.Common.DTOs.PublisherDTO.PublisherInfo[] GetAllPublishers();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPublisherService/GetAllPublishers", ReplyAction="http://tempuri.org/IPublisherService/GetAllPublishersResponse")]
        System.Threading.Tasks.Task<RVAProject.Common.DTOs.PublisherDTO.PublisherInfo[]> GetAllPublishersAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPublisherService/GetPublisherById", ReplyAction="http://tempuri.org/IPublisherService/GetPublisherByIdResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(RVAProject.Common.CustomAppException), Action="http://tempuri.org/IPublisherService/GetPublisherByIdCustomAppExceptionFault", Name="CustomAppException", Namespace="http://schemas.datacontract.org/2004/07/RVAProject.Common")]
        RVAProject.Common.DTOs.PublisherDTO.PublisherInfo GetPublisherById(System.Guid id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPublisherService/GetPublisherById", ReplyAction="http://tempuri.org/IPublisherService/GetPublisherByIdResponse")]
        System.Threading.Tasks.Task<RVAProject.Common.DTOs.PublisherDTO.PublisherInfo> GetPublisherByIdAsync(System.Guid id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPublisherService/UpdatePublisher", ReplyAction="http://tempuri.org/IPublisherService/UpdatePublisherResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(RVAProject.Common.CustomAppException), Action="http://tempuri.org/IPublisherService/UpdatePublisherCustomAppExceptionFault", Name="CustomAppException", Namespace="http://schemas.datacontract.org/2004/07/RVAProject.Common")]
        void UpdatePublisher(RVAProject.Common.DTOs.PublisherDTO.UpdatePublisherRequest updatePublisherRequest);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPublisherService/UpdatePublisher", ReplyAction="http://tempuri.org/IPublisherService/UpdatePublisherResponse")]
        System.Threading.Tasks.Task UpdatePublisherAsync(RVAProject.Common.DTOs.PublisherDTO.UpdatePublisherRequest updatePublisherRequest);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPublisherService/DeletePublisher", ReplyAction="http://tempuri.org/IPublisherService/DeletePublisherResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(RVAProject.Common.CustomAppException), Action="http://tempuri.org/IPublisherService/DeletePublisherCustomAppExceptionFault", Name="CustomAppException", Namespace="http://schemas.datacontract.org/2004/07/RVAProject.Common")]
        void DeletePublisher(System.Guid id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPublisherService/DeletePublisher", ReplyAction="http://tempuri.org/IPublisherService/DeletePublisherResponse")]
        System.Threading.Tasks.Task DeletePublisherAsync(System.Guid id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IPublisherServiceChannel : RVAProject.ClientApp.PublisherService.IPublisherService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class PublisherServiceClient : System.ServiceModel.ClientBase<RVAProject.ClientApp.PublisherService.IPublisherService>, RVAProject.ClientApp.PublisherService.IPublisherService {
        
        public PublisherServiceClient() {
        }
        
        public PublisherServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public PublisherServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PublisherServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PublisherServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void AddPublisher(RVAProject.Common.DTOs.PublisherDTO.PublisherRequest publisherRequest) {
            base.Channel.AddPublisher(publisherRequest);
        }
        
        public System.Threading.Tasks.Task AddPublisherAsync(RVAProject.Common.DTOs.PublisherDTO.PublisherRequest publisherRequest) {
            return base.Channel.AddPublisherAsync(publisherRequest);
        }
        
        public RVAProject.Common.DTOs.PublisherDTO.PublisherInfo[] GetAllPublishers() {
            return base.Channel.GetAllPublishers();
        }
        
        public System.Threading.Tasks.Task<RVAProject.Common.DTOs.PublisherDTO.PublisherInfo[]> GetAllPublishersAsync() {
            return base.Channel.GetAllPublishersAsync();
        }
        
        public RVAProject.Common.DTOs.PublisherDTO.PublisherInfo GetPublisherById(System.Guid id) {
            return base.Channel.GetPublisherById(id);
        }
        
        public System.Threading.Tasks.Task<RVAProject.Common.DTOs.PublisherDTO.PublisherInfo> GetPublisherByIdAsync(System.Guid id) {
            return base.Channel.GetPublisherByIdAsync(id);
        }
        
        public void UpdatePublisher(RVAProject.Common.DTOs.PublisherDTO.UpdatePublisherRequest updatePublisherRequest) {
            base.Channel.UpdatePublisher(updatePublisherRequest);
        }
        
        public System.Threading.Tasks.Task UpdatePublisherAsync(RVAProject.Common.DTOs.PublisherDTO.UpdatePublisherRequest updatePublisherRequest) {
            return base.Channel.UpdatePublisherAsync(updatePublisherRequest);
        }
        
        public void DeletePublisher(System.Guid id) {
            base.Channel.DeletePublisher(id);
        }
        
        public System.Threading.Tasks.Task DeletePublisherAsync(System.Guid id) {
            return base.Channel.DeletePublisherAsync(id);
        }
    }
}