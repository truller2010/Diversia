﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Diversia.Backend.BlogSVC {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="BlogSVC.IBlog")]
    public interface IBlog {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBlog/GetAll", ReplyAction="http://tempuri.org/IBlog/GetAllResponse")]
        System.Collections.Generic.List<Diversia.Models.BlogPost.BlogPostModel> GetAll();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBlog/GetAll", ReplyAction="http://tempuri.org/IBlog/GetAllResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<Diversia.Models.BlogPost.BlogPostModel>> GetAllAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IBlogChannel : Diversia.Backend.BlogSVC.IBlog, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class BlogClient : System.ServiceModel.ClientBase<Diversia.Backend.BlogSVC.IBlog>, Diversia.Backend.BlogSVC.IBlog {
        
        public BlogClient() {
        }
        
        public BlogClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public BlogClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BlogClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BlogClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Collections.Generic.List<Diversia.Models.BlogPost.BlogPostModel> GetAll() {
            return base.Channel.GetAll();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<Diversia.Models.BlogPost.BlogPostModel>> GetAllAsync() {
            return base.Channel.GetAllAsync();
        }
    }
}