//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.5446
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by xsd, Version=2.0.50727.3038.
// 
namespace StatusTracking_v1_0 {
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/StatusTracking_v1_0.xsd")]
    [System.Xml.Serialization.XmlRootAttribute("StatusTrackingAbstraction", Namespace="http://tempuri.org/StatusTracking_v1_0.xsd", IsNullable=false)]
    public partial class StatusTrackingAbstractionType {
        
        private StatusItemType[] statusItemsField;
        
        private GroupType[] groupsField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("StatusItem", IsNullable=false)]
        public StatusItemType[] StatusItems {
            get {
                return this.statusItemsField;
            }
            set {
                this.statusItemsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Group", IsNullable=false)]
        public GroupType[] Groups {
            get {
                return this.groupsField;
            }
            set {
                this.groupsField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/StatusTracking_v1_0.xsd")]
    public partial class StatusItemType {
        
        private StatusValueType statusValueField;
        
        private string nameField;
        
        /// <remarks/>
        public StatusValueType StatusValue {
            get {
                return this.statusValueField;
            }
            set {
                this.statusValueField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/StatusTracking_v1_0.xsd")]
    public partial class StatusValueType {
        
        private StatusValueTypeTrafficLightIndicator trafficLightIndicatorField;
        
        private decimal indicatorValueField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public StatusValueTypeTrafficLightIndicator trafficLightIndicator {
            get {
                return this.trafficLightIndicatorField;
            }
            set {
                this.trafficLightIndicatorField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal indicatorValue {
            get {
                return this.indicatorValueField;
            }
            set {
                this.indicatorValueField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/StatusTracking_v1_0.xsd")]
    public enum StatusValueTypeTrafficLightIndicator {
        
        /// <remarks/>
        red,
        
        /// <remarks/>
        yellow,
        
        /// <remarks/>
        green,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/StatusTracking_v1_0.xsd")]
    public partial class GroupRefType {
        
        private string groupNameField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string groupName {
            get {
                return this.groupNameField;
            }
            set {
                this.groupNameField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/StatusTracking_v1_0.xsd")]
    public partial class ItemRefType {
        
        private string itemNameField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string itemName {
            get {
                return this.itemNameField;
            }
            set {
                this.itemNameField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/StatusTracking_v1_0.xsd")]
    public partial class GroupType {
        
        private ItemRefType[] itemRefField;
        
        private GroupRefType[] groupRefField;
        
        private string nameField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ItemRef")]
        public ItemRefType[] ItemRef {
            get {
                return this.itemRefField;
            }
            set {
                this.itemRefField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("GroupRef")]
        public GroupRefType[] GroupRef {
            get {
                return this.groupRefField;
            }
            set {
                this.groupRefField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
    }
}
