﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace bibliothiki.AllReservationsManageReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="AllReservationsManageReference.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/AllReservationsManage", ReplyAction="http://tempuri.org/IService1/AllReservationsManageResponse")]
        string[] AllReservationsManage();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/AllReservationsManage", ReplyAction="http://tempuri.org/IService1/AllReservationsManageResponse")]
        System.Threading.Tasks.Task<string[]> AllReservationsManageAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : bibliothiki.AllReservationsManageReference.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<bibliothiki.AllReservationsManageReference.IService1>, bibliothiki.AllReservationsManageReference.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string[] AllReservationsManage() {
            return base.Channel.AllReservationsManage();
        }
        
        public System.Threading.Tasks.Task<string[]> AllReservationsManageAsync() {
            return base.Channel.AllReservationsManageAsync();
        }
    }
}
