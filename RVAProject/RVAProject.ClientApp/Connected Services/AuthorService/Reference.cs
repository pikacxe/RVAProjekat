﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RVAProject.ClientApp.AuthorService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="AuthorService.IAuthorService")]
    public interface IAuthorService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthorService/AddAuthor", ReplyAction="http://tempuri.org/IAuthorService/AddAuthorResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(RVAProject.Common.CustomAppException), Action="http://tempuri.org/IAuthorService/AddAuthorCustomAppExceptionFault", Name="CustomAppException", Namespace="http://schemas.datacontract.org/2004/07/RVAProject.Common")]
        void AddAuthor(RVAProject.Common.DTOs.AuthorDTO.AuthorRequest authorRequest, string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthorService/AddAuthor", ReplyAction="http://tempuri.org/IAuthorService/AddAuthorResponse")]
        System.Threading.Tasks.Task AddAuthorAsync(RVAProject.Common.DTOs.AuthorDTO.AuthorRequest authorRequest, string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthorService/GetAllAuthors", ReplyAction="http://tempuri.org/IAuthorService/GetAllAuthorsResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(RVAProject.Common.CustomAppException), Action="http://tempuri.org/IAuthorService/GetAllAuthorsCustomAppExceptionFault", Name="CustomAppException", Namespace="http://schemas.datacontract.org/2004/07/RVAProject.Common")]
        RVAProject.Common.DTOs.AuthorDTO.AuthorInfo[] GetAllAuthors(string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthorService/GetAllAuthors", ReplyAction="http://tempuri.org/IAuthorService/GetAllAuthorsResponse")]
        System.Threading.Tasks.Task<RVAProject.Common.DTOs.AuthorDTO.AuthorInfo[]> GetAllAuthorsAsync(string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthorService/GetAuthorById", ReplyAction="http://tempuri.org/IAuthorService/GetAuthorByIdResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(RVAProject.Common.CustomAppException), Action="http://tempuri.org/IAuthorService/GetAuthorByIdCustomAppExceptionFault", Name="CustomAppException", Namespace="http://schemas.datacontract.org/2004/07/RVAProject.Common")]
        RVAProject.Common.DTOs.AuthorDTO.AuthorInfo GetAuthorById(System.Guid id, string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthorService/GetAuthorById", ReplyAction="http://tempuri.org/IAuthorService/GetAuthorByIdResponse")]
        System.Threading.Tasks.Task<RVAProject.Common.DTOs.AuthorDTO.AuthorInfo> GetAuthorByIdAsync(System.Guid id, string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthorService/UpdateAuthor", ReplyAction="http://tempuri.org/IAuthorService/UpdateAuthorResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(RVAProject.Common.CustomAppException), Action="http://tempuri.org/IAuthorService/UpdateAuthorCustomAppExceptionFault", Name="CustomAppException", Namespace="http://schemas.datacontract.org/2004/07/RVAProject.Common")]
        void UpdateAuthor(RVAProject.Common.DTOs.AuthorDTO.UpdateAuthorRequest updateAuthorRequest, string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthorService/UpdateAuthor", ReplyAction="http://tempuri.org/IAuthorService/UpdateAuthorResponse")]
        System.Threading.Tasks.Task UpdateAuthorAsync(RVAProject.Common.DTOs.AuthorDTO.UpdateAuthorRequest updateAuthorRequest, string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthorService/DeleteAuthor", ReplyAction="http://tempuri.org/IAuthorService/DeleteAuthorResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(RVAProject.Common.CustomAppException), Action="http://tempuri.org/IAuthorService/DeleteAuthorCustomAppExceptionFault", Name="CustomAppException", Namespace="http://schemas.datacontract.org/2004/07/RVAProject.Common")]
        void DeleteAuthor(System.Guid id, string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthorService/DeleteAuthor", ReplyAction="http://tempuri.org/IAuthorService/DeleteAuthorResponse")]
        System.Threading.Tasks.Task DeleteAuthorAsync(System.Guid id, string token);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAuthorServiceChannel : RVAProject.ClientApp.AuthorService.IAuthorService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AuthorServiceClient : System.ServiceModel.ClientBase<RVAProject.ClientApp.AuthorService.IAuthorService>, RVAProject.ClientApp.AuthorService.IAuthorService {
        
        public AuthorServiceClient() {
        }
        
        public AuthorServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AuthorServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AuthorServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AuthorServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        public void AddAuthor(RVAProject.Common.DTOs.AuthorDTO.AuthorRequest authorRequest, string token) {
            base.Channel.AddAuthor(authorRequest, token);
        }
        
        public System.Threading.Tasks.Task AddAuthorAsync(RVAProject.Common.DTOs.AuthorDTO.AuthorRequest authorRequest, string token) {
            return base.Channel.AddAuthorAsync(authorRequest, token);
        }
        
        public RVAProject.Common.DTOs.AuthorDTO.AuthorInfo[] GetAllAuthors(string token) {
            return base.Channel.GetAllAuthors(token);
        }
        
        public System.Threading.Tasks.Task<RVAProject.Common.DTOs.AuthorDTO.AuthorInfo[]> GetAllAuthorsAsync(string token) {
            return base.Channel.GetAllAuthorsAsync(token);
        }
        
        public RVAProject.Common.DTOs.AuthorDTO.AuthorInfo GetAuthorById(System.Guid id, string token) {
            return base.Channel.GetAuthorById(id, token);
        }
        
        public System.Threading.Tasks.Task<RVAProject.Common.DTOs.AuthorDTO.AuthorInfo> GetAuthorByIdAsync(System.Guid id, string token) {
            return base.Channel.GetAuthorByIdAsync(id, token);
        }
        
        public void UpdateAuthor(RVAProject.Common.DTOs.AuthorDTO.UpdateAuthorRequest updateAuthorRequest, string token) {
            base.Channel.UpdateAuthor(updateAuthorRequest, token);
        }
        
        public System.Threading.Tasks.Task UpdateAuthorAsync(RVAProject.Common.DTOs.AuthorDTO.UpdateAuthorRequest updateAuthorRequest, string token) {
            return base.Channel.UpdateAuthorAsync(updateAuthorRequest, token);
        }
        
        public void DeleteAuthor(System.Guid id, string token) {
            base.Channel.DeleteAuthor(id, token);
        }
        
        public System.Threading.Tasks.Task DeleteAuthorAsync(System.Guid id, string token) {
            return base.Channel.DeleteAuthorAsync(id, token);
        }
    }
}
