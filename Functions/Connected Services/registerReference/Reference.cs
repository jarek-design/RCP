﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Functions.registerReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="FirmaD", Namespace="http://schemas.datacontract.org/2004/07/progRegister")]
    [System.SerializableAttribute()]
    public partial class FirmaD : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string adresField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> createDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int idfiField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string kodpocztField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string miejscField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string nazwaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string nipField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string telField;
        
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
        public string adres {
            get {
                return this.adresField;
            }
            set {
                if ((object.ReferenceEquals(this.adresField, value) != true)) {
                    this.adresField = value;
                    this.RaisePropertyChanged("adres");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> createD {
            get {
                return this.createDField;
            }
            set {
                if ((this.createDField.Equals(value) != true)) {
                    this.createDField = value;
                    this.RaisePropertyChanged("createD");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int idfi {
            get {
                return this.idfiField;
            }
            set {
                if ((this.idfiField.Equals(value) != true)) {
                    this.idfiField = value;
                    this.RaisePropertyChanged("idfi");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string kodpoczt {
            get {
                return this.kodpocztField;
            }
            set {
                if ((object.ReferenceEquals(this.kodpocztField, value) != true)) {
                    this.kodpocztField = value;
                    this.RaisePropertyChanged("kodpoczt");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string miejsc {
            get {
                return this.miejscField;
            }
            set {
                if ((object.ReferenceEquals(this.miejscField, value) != true)) {
                    this.miejscField = value;
                    this.RaisePropertyChanged("miejsc");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string nazwa {
            get {
                return this.nazwaField;
            }
            set {
                if ((object.ReferenceEquals(this.nazwaField, value) != true)) {
                    this.nazwaField = value;
                    this.RaisePropertyChanged("nazwa");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string nip {
            get {
                return this.nipField;
            }
            set {
                if ((object.ReferenceEquals(this.nipField, value) != true)) {
                    this.nipField = value;
                    this.RaisePropertyChanged("nip");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string tel {
            get {
                return this.telField;
            }
            set {
                if ((object.ReferenceEquals(this.telField, value) != true)) {
                    this.telField = value;
                    this.RaisePropertyChanged("tel");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Order", Namespace="http://schemas.datacontract.org/2004/07/progRegister")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Functions.registerReference.OrderVerifi))]
    public partial class Order : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdfField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> OrderDateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private short ProgramField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<byte> ProgverField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string licenceNrField;
        
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
        public int Idf {
            get {
                return this.IdfField;
            }
            set {
                if ((this.IdfField.Equals(value) != true)) {
                    this.IdfField = value;
                    this.RaisePropertyChanged("Idf");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> OrderDate {
            get {
                return this.OrderDateField;
            }
            set {
                if ((this.OrderDateField.Equals(value) != true)) {
                    this.OrderDateField = value;
                    this.RaisePropertyChanged("OrderDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public short Program {
            get {
                return this.ProgramField;
            }
            set {
                if ((this.ProgramField.Equals(value) != true)) {
                    this.ProgramField = value;
                    this.RaisePropertyChanged("Program");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<byte> Progver {
            get {
                return this.ProgverField;
            }
            set {
                if ((this.ProgverField.Equals(value) != true)) {
                    this.ProgverField = value;
                    this.RaisePropertyChanged("Progver");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string licenceNr {
            get {
                return this.licenceNrField;
            }
            set {
                if ((object.ReferenceEquals(this.licenceNrField, value) != true)) {
                    this.licenceNrField = value;
                    this.RaisePropertyChanged("licenceNr");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="OrderVerifi", Namespace="http://schemas.datacontract.org/2004/07/progRegister")]
    [System.SerializableAttribute()]
    public partial class OrderVerifi : Functions.registerReference.Order {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<bool> PaymentField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int RegistrIdField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<bool> Payment {
            get {
                return this.PaymentField;
            }
            set {
                if ((this.PaymentField.Equals(value) != true)) {
                    this.PaymentField = value;
                    this.RaisePropertyChanged("Payment");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int RegistrId {
            get {
                return this.RegistrIdField;
            }
            set {
                if ((this.RegistrIdField.Equals(value) != true)) {
                    this.RegistrIdField = value;
                    this.RaisePropertyChanged("RegistrId");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="SendStatus", Namespace="http://schemas.datacontract.org/2004/07/progRegister")]
    [System.SerializableAttribute()]
    public partial class SendStatus : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int addedField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private sbyte succesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int updatedField;
        
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
        public int added {
            get {
                return this.addedField;
            }
            set {
                if ((this.addedField.Equals(value) != true)) {
                    this.addedField = value;
                    this.RaisePropertyChanged("added");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public sbyte succes {
            get {
                return this.succesField;
            }
            set {
                if ((this.succesField.Equals(value) != true)) {
                    this.succesField = value;
                    this.RaisePropertyChanged("succes");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int updated {
            get {
                return this.updatedField;
            }
            set {
                if ((this.updatedField.Equals(value) != true)) {
                    this.updatedField = value;
                    this.RaisePropertyChanged("updated");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="registerReference.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/SetFirma", ReplyAction="http://tempuri.org/IService1/SetFirmaResponse")]
        int SetFirma(Functions.registerReference.FirmaD f1);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/SetFirma", ReplyAction="http://tempuri.org/IService1/SetFirmaResponse")]
        System.Threading.Tasks.Task<int> SetFirmaAsync(Functions.registerReference.FirmaD f1);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetFirma", ReplyAction="http://tempuri.org/IService1/GetFirmaResponse")]
        Functions.registerReference.FirmaD GetFirma(string nip);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetFirma", ReplyAction="http://tempuri.org/IService1/GetFirmaResponse")]
        System.Threading.Tasks.Task<Functions.registerReference.FirmaD> GetFirmaAsync(string nip);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetFirmaById", ReplyAction="http://tempuri.org/IService1/GetFirmaByIdResponse")]
        Functions.registerReference.FirmaD GetFirmaById(int idfi);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetFirmaById", ReplyAction="http://tempuri.org/IService1/GetFirmaByIdResponse")]
        System.Threading.Tasks.Task<Functions.registerReference.FirmaD> GetFirmaByIdAsync(int idfi);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/SetOrder", ReplyAction="http://tempuri.org/IService1/SetOrderResponse")]
        Functions.registerReference.OrderVerifi SetOrder(Functions.registerReference.Order ord1);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/SetOrder", ReplyAction="http://tempuri.org/IService1/SetOrderResponse")]
        System.Threading.Tasks.Task<Functions.registerReference.OrderVerifi> SetOrderAsync(Functions.registerReference.Order ord1);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetOrder", ReplyAction="http://tempuri.org/IService1/GetOrderResponse")]
        Functions.registerReference.OrderVerifi GetOrder(string nip, short progId, string licenceNr);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetOrder", ReplyAction="http://tempuri.org/IService1/GetOrderResponse")]
        System.Threading.Tasks.Task<Functions.registerReference.OrderVerifi> GetOrderAsync(string nip, short progId, string licenceNr);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/P_register", ReplyAction="http://tempuri.org/IService1/P_registerResponse")]
        Functions.registerReference.SendStatus P_register(string nip, int RegistrId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/P_register", ReplyAction="http://tempuri.org/IService1/P_registerResponse")]
        System.Threading.Tasks.Task<Functions.registerReference.SendStatus> P_registerAsync(string nip, int RegistrId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetEncNip", ReplyAction="http://tempuri.org/IService1/GetEncNipResponse")]
        string GetEncNip(string nip, int RegistrId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetEncNip", ReplyAction="http://tempuri.org/IService1/GetEncNipResponse")]
        System.Threading.Tasks.Task<string> GetEncNipAsync(string nip, int RegistrId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/RegisterStatus", ReplyAction="http://tempuri.org/IService1/RegisterStatusResponse")]
        short RegisterStatus(int RegistrId, string encNip);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/RegisterStatus", ReplyAction="http://tempuri.org/IService1/RegisterStatusResponse")]
        System.Threading.Tasks.Task<short> RegisterStatusAsync(int RegistrId, string encNip);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/RegisterStat", ReplyAction="http://tempuri.org/IService1/RegisterStatResponse")]
        short RegisterStat(int RegistrId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/RegisterStat", ReplyAction="http://tempuri.org/IService1/RegisterStatResponse")]
        System.Threading.Tasks.Task<short> RegisterStatAsync(int RegistrId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : Functions.registerReference.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<Functions.registerReference.IService1>, Functions.registerReference.IService1 {
        
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
        
        public int SetFirma(Functions.registerReference.FirmaD f1) {
            return base.Channel.SetFirma(f1);
        }
        
        public System.Threading.Tasks.Task<int> SetFirmaAsync(Functions.registerReference.FirmaD f1) {
            return base.Channel.SetFirmaAsync(f1);
        }
        
        public Functions.registerReference.FirmaD GetFirma(string nip) {
            return base.Channel.GetFirma(nip);
        }
        
        public System.Threading.Tasks.Task<Functions.registerReference.FirmaD> GetFirmaAsync(string nip) {
            return base.Channel.GetFirmaAsync(nip);
        }
        
        public Functions.registerReference.FirmaD GetFirmaById(int idfi) {
            return base.Channel.GetFirmaById(idfi);
        }
        
        public System.Threading.Tasks.Task<Functions.registerReference.FirmaD> GetFirmaByIdAsync(int idfi) {
            return base.Channel.GetFirmaByIdAsync(idfi);
        }
        
        public Functions.registerReference.OrderVerifi SetOrder(Functions.registerReference.Order ord1) {
            return base.Channel.SetOrder(ord1);
        }
        
        public System.Threading.Tasks.Task<Functions.registerReference.OrderVerifi> SetOrderAsync(Functions.registerReference.Order ord1) {
            return base.Channel.SetOrderAsync(ord1);
        }
        
        public Functions.registerReference.OrderVerifi GetOrder(string nip, short progId, string licenceNr) {
            return base.Channel.GetOrder(nip, progId, licenceNr);
        }
        
        public System.Threading.Tasks.Task<Functions.registerReference.OrderVerifi> GetOrderAsync(string nip, short progId, string licenceNr) {
            return base.Channel.GetOrderAsync(nip, progId, licenceNr);
        }
        
        public Functions.registerReference.SendStatus P_register(string nip, int RegistrId) {
            return base.Channel.P_register(nip, RegistrId);
        }
        
        public System.Threading.Tasks.Task<Functions.registerReference.SendStatus> P_registerAsync(string nip, int RegistrId) {
            return base.Channel.P_registerAsync(nip, RegistrId);
        }
        
        public string GetEncNip(string nip, int RegistrId) {
            return base.Channel.GetEncNip(nip, RegistrId);
        }
        
        public System.Threading.Tasks.Task<string> GetEncNipAsync(string nip, int RegistrId) {
            return base.Channel.GetEncNipAsync(nip, RegistrId);
        }
        
        public short RegisterStatus(int RegistrId, string encNip) {
            return base.Channel.RegisterStatus(RegistrId, encNip);
        }
        
        public System.Threading.Tasks.Task<short> RegisterStatusAsync(int RegistrId, string encNip) {
            return base.Channel.RegisterStatusAsync(RegistrId, encNip);
        }
        
        public short RegisterStat(int RegistrId) {
            return base.Channel.RegisterStat(RegistrId);
        }
        
        public System.Threading.Tasks.Task<short> RegisterStatAsync(int RegistrId) {
            return base.Channel.RegisterStatAsync(RegistrId);
        }
    }
}
