﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NumerosGallegos.ServicioNumerosGallegoWCF {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Conversion", Namespace="http://schemas.datacontract.org/2004/07/ServicioNumerosGallegoWCF")]
    [System.SerializableAttribute()]
    public partial class Conversion : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Collections.Generic.List<string> EjemplosField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Collections.Generic.List<string> EjemplosMayusculaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool ErrorRomanoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Collections.Generic.List<NumerosGallegos.ServicioNumerosGallegoWCF.Opcion> MasOpcionesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Collections.Generic.List<NumerosGallegos.ServicioNumerosGallegoWCF.Opcion> MasOpcionesMayusculaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Collections.Generic.List<string> NotasField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Collections.Generic.List<string> ReferenciasField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Collections.Generic.List<string> RespuestasField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Collections.Generic.List<string> RespuestasMayusculaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TipoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TitEjemplosField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TitNotasField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TitOpcionesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TitReferenciasField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TitValorNumericoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TituloField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ValorNumericoField;
        
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
        public System.Collections.Generic.List<string> Ejemplos {
            get {
                return this.EjemplosField;
            }
            set {
                if ((object.ReferenceEquals(this.EjemplosField, value) != true)) {
                    this.EjemplosField = value;
                    this.RaisePropertyChanged("Ejemplos");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.List<string> EjemplosMayuscula {
            get {
                return this.EjemplosMayusculaField;
            }
            set {
                if ((object.ReferenceEquals(this.EjemplosMayusculaField, value) != true)) {
                    this.EjemplosMayusculaField = value;
                    this.RaisePropertyChanged("EjemplosMayuscula");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool ErrorRomano {
            get {
                return this.ErrorRomanoField;
            }
            set {
                if ((this.ErrorRomanoField.Equals(value) != true)) {
                    this.ErrorRomanoField = value;
                    this.RaisePropertyChanged("ErrorRomano");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.List<NumerosGallegos.ServicioNumerosGallegoWCF.Opcion> MasOpciones {
            get {
                return this.MasOpcionesField;
            }
            set {
                if ((object.ReferenceEquals(this.MasOpcionesField, value) != true)) {
                    this.MasOpcionesField = value;
                    this.RaisePropertyChanged("MasOpciones");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.List<NumerosGallegos.ServicioNumerosGallegoWCF.Opcion> MasOpcionesMayuscula {
            get {
                return this.MasOpcionesMayusculaField;
            }
            set {
                if ((object.ReferenceEquals(this.MasOpcionesMayusculaField, value) != true)) {
                    this.MasOpcionesMayusculaField = value;
                    this.RaisePropertyChanged("MasOpcionesMayuscula");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.List<string> Notas {
            get {
                return this.NotasField;
            }
            set {
                if ((object.ReferenceEquals(this.NotasField, value) != true)) {
                    this.NotasField = value;
                    this.RaisePropertyChanged("Notas");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.List<string> Referencias {
            get {
                return this.ReferenciasField;
            }
            set {
                if ((object.ReferenceEquals(this.ReferenciasField, value) != true)) {
                    this.ReferenciasField = value;
                    this.RaisePropertyChanged("Referencias");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.List<string> Respuestas {
            get {
                return this.RespuestasField;
            }
            set {
                if ((object.ReferenceEquals(this.RespuestasField, value) != true)) {
                    this.RespuestasField = value;
                    this.RaisePropertyChanged("Respuestas");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.List<string> RespuestasMayuscula {
            get {
                return this.RespuestasMayusculaField;
            }
            set {
                if ((object.ReferenceEquals(this.RespuestasMayusculaField, value) != true)) {
                    this.RespuestasMayusculaField = value;
                    this.RaisePropertyChanged("RespuestasMayuscula");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Tipo {
            get {
                return this.TipoField;
            }
            set {
                if ((object.ReferenceEquals(this.TipoField, value) != true)) {
                    this.TipoField = value;
                    this.RaisePropertyChanged("Tipo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TitEjemplos {
            get {
                return this.TitEjemplosField;
            }
            set {
                if ((object.ReferenceEquals(this.TitEjemplosField, value) != true)) {
                    this.TitEjemplosField = value;
                    this.RaisePropertyChanged("TitEjemplos");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TitNotas {
            get {
                return this.TitNotasField;
            }
            set {
                if ((object.ReferenceEquals(this.TitNotasField, value) != true)) {
                    this.TitNotasField = value;
                    this.RaisePropertyChanged("TitNotas");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TitOpciones {
            get {
                return this.TitOpcionesField;
            }
            set {
                if ((object.ReferenceEquals(this.TitOpcionesField, value) != true)) {
                    this.TitOpcionesField = value;
                    this.RaisePropertyChanged("TitOpciones");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TitReferencias {
            get {
                return this.TitReferenciasField;
            }
            set {
                if ((object.ReferenceEquals(this.TitReferenciasField, value) != true)) {
                    this.TitReferenciasField = value;
                    this.RaisePropertyChanged("TitReferencias");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TitValorNumerico {
            get {
                return this.TitValorNumericoField;
            }
            set {
                if ((object.ReferenceEquals(this.TitValorNumericoField, value) != true)) {
                    this.TitValorNumericoField = value;
                    this.RaisePropertyChanged("TitValorNumerico");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Titulo {
            get {
                return this.TituloField;
            }
            set {
                if ((object.ReferenceEquals(this.TituloField, value) != true)) {
                    this.TituloField = value;
                    this.RaisePropertyChanged("Titulo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ValorNumerico {
            get {
                return this.ValorNumericoField;
            }
            set {
                if ((object.ReferenceEquals(this.ValorNumericoField, value) != true)) {
                    this.ValorNumericoField = value;
                    this.RaisePropertyChanged("ValorNumerico");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Opcion", Namespace="http://schemas.datacontract.org/2004/07/ServicioNumerosGallegoWCF")]
    [System.SerializableAttribute()]
    public partial class Opcion : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Collections.Generic.List<string> OpcionesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TituloField;
        
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
        public System.Collections.Generic.List<string> Opciones {
            get {
                return this.OpcionesField;
            }
            set {
                if ((object.ReferenceEquals(this.OpcionesField, value) != true)) {
                    this.OpcionesField = value;
                    this.RaisePropertyChanged("Opciones");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Titulo {
            get {
                return this.TituloField;
            }
            set {
                if ((object.ReferenceEquals(this.TituloField, value) != true)) {
                    this.TituloField = value;
                    this.RaisePropertyChanged("Titulo");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServicioNumerosGallegoWCF.IServicioNumerosGallegos")]
    public interface IServicioNumerosGallegos {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioNumerosGallegos/TraduciraTexto", ReplyAction="http://tempuri.org/IServicioNumerosGallegos/TraduciraTextoResponse")]
        System.Collections.Generic.List<NumerosGallegos.ServicioNumerosGallegoWCF.Conversion> TraduciraTexto(string value, string lenguaje);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioNumerosGallegos/TraduciraTexto", ReplyAction="http://tempuri.org/IServicioNumerosGallegos/TraduciraTextoResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<NumerosGallegos.ServicioNumerosGallegoWCF.Conversion>> TraduciraTextoAsync(string value, string lenguaje);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServicioNumerosGallegosChannel : NumerosGallegos.ServicioNumerosGallegoWCF.IServicioNumerosGallegos, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServicioNumerosGallegosClient : System.ServiceModel.ClientBase<NumerosGallegos.ServicioNumerosGallegoWCF.IServicioNumerosGallegos>, NumerosGallegos.ServicioNumerosGallegoWCF.IServicioNumerosGallegos {
        
        public ServicioNumerosGallegosClient() {
        }
        
        public ServicioNumerosGallegosClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServicioNumerosGallegosClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServicioNumerosGallegosClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServicioNumerosGallegosClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Collections.Generic.List<NumerosGallegos.ServicioNumerosGallegoWCF.Conversion> TraduciraTexto(string value, string lenguaje) {
            return base.Channel.TraduciraTexto(value, lenguaje);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<NumerosGallegos.ServicioNumerosGallegoWCF.Conversion>> TraduciraTextoAsync(string value, string lenguaje) {
            return base.Channel.TraduciraTextoAsync(value, lenguaje);
        }
    }
}
