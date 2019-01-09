﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ToDoClient.Server {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CompositeType", Namespace="http://schemas.datacontract.org/2004/07/ToDoServer")]
    [System.SerializableAttribute()]
    public partial class CompositeType : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool BoolValueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StringValueField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool BoolValue {
            get {
                return this.BoolValueField;
            }
            set {
                if ((this.BoolValueField.Equals(value) != true)) {
                    this.BoolValueField = value;
                    this.RaisePropertyChanged("BoolValue");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StringValue {
            get {
                return this.StringValueField;
            }
            set {
                if ((object.ReferenceEquals(this.StringValueField, value) != true)) {
                    this.StringValueField = value;
                    this.RaisePropertyChanged("StringValue");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Server.IToDoServer")]
    public interface IToDoServer {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IToDoServer/GetData", ReplyAction="http://tempuri.org/IToDoServer/GetDataResponse")]
        string GetData(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IToDoServer/GetData", ReplyAction="http://tempuri.org/IToDoServer/GetDataResponse")]
        System.Threading.Tasks.Task<string> GetDataAsync(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IToDoServer/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IToDoServer/GetDataUsingDataContractResponse")]
        ToDoClient.Server.CompositeType GetDataUsingDataContract(ToDoClient.Server.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IToDoServer/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IToDoServer/GetDataUsingDataContractResponse")]
        System.Threading.Tasks.Task<ToDoClient.Server.CompositeType> GetDataUsingDataContractAsync(ToDoClient.Server.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IToDoServer/InsertNote", ReplyAction="http://tempuri.org/IToDoServer/InsertNoteResponse")]
        bool InsertNote(System.Guid guid, string token, string Data, string Title);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IToDoServer/InsertNote", ReplyAction="http://tempuri.org/IToDoServer/InsertNoteResponse")]
        System.Threading.Tasks.Task<bool> InsertNoteAsync(System.Guid guid, string token, string Data, string Title);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IToDoServer/getNotes", ReplyAction="http://tempuri.org/IToDoServer/getNotesResponse")]
        System.Collections.Generic.List<string> getNotes(System.Guid guid, string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IToDoServer/getNotes", ReplyAction="http://tempuri.org/IToDoServer/getNotesResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<string>> getNotesAsync(System.Guid guid, string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IToDoServer/Register", ReplyAction="http://tempuri.org/IToDoServer/RegisterResponse")]
        bool Register(string Username, string password, string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IToDoServer/Register", ReplyAction="http://tempuri.org/IToDoServer/RegisterResponse")]
        System.Threading.Tasks.Task<bool> RegisterAsync(string Username, string password, string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IToDoServer/Login", ReplyAction="http://tempuri.org/IToDoServer/LoginResponse")]
        string Login(string username, string password, string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IToDoServer/Login", ReplyAction="http://tempuri.org/IToDoServer/LoginResponse")]
        System.Threading.Tasks.Task<string> LoginAsync(string username, string password, string email);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IToDoServerChannel : ToDoClient.Server.IToDoServer, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ToDoServerClient : System.ServiceModel.ClientBase<ToDoClient.Server.IToDoServer>, ToDoClient.Server.IToDoServer {
        
        public ToDoServerClient() {
        }
        
        public ToDoServerClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ToDoServerClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ToDoServerClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ToDoServerClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetData(int value) {
            return base.Channel.GetData(value);
        }
        
        public System.Threading.Tasks.Task<string> GetDataAsync(int value) {
            return base.Channel.GetDataAsync(value);
        }
        
        public ToDoClient.Server.CompositeType GetDataUsingDataContract(ToDoClient.Server.CompositeType composite) {
            return base.Channel.GetDataUsingDataContract(composite);
        }
        
        public System.Threading.Tasks.Task<ToDoClient.Server.CompositeType> GetDataUsingDataContractAsync(ToDoClient.Server.CompositeType composite) {
            return base.Channel.GetDataUsingDataContractAsync(composite);
        }
        
        public bool InsertNote(System.Guid guid, string token, string Data, string Title) {
            return base.Channel.InsertNote(guid, token, Data, Title);
        }
        
        public System.Threading.Tasks.Task<bool> InsertNoteAsync(System.Guid guid, string token, string Data, string Title) {
            return base.Channel.InsertNoteAsync(guid, token, Data, Title);
        }
        
        public System.Collections.Generic.List<string> getNotes(System.Guid guid, string token) {
            return base.Channel.getNotes(guid, token);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<string>> getNotesAsync(System.Guid guid, string token) {
            return base.Channel.getNotesAsync(guid, token);
        }
        
        public bool Register(string Username, string password, string email) {
            return base.Channel.Register(Username, password, email);
        }
        
        public System.Threading.Tasks.Task<bool> RegisterAsync(string Username, string password, string email) {
            return base.Channel.RegisterAsync(Username, password, email);
        }
        
        public string Login(string username, string password, string email) {
            return base.Channel.Login(username, password, email);
        }
        
        public System.Threading.Tasks.Task<string> LoginAsync(string username, string password, string email) {
            return base.Channel.LoginAsync(username, password, email);
        }
    }
}
