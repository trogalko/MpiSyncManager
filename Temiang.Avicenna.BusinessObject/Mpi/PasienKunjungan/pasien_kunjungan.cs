using System.Xml.Serialization;

namespace Temiang.Avicenna.BusinessObject.Mpi.PasienKunjungan
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class response
    {

        private string statusField;

        private responsePatient[] patientField;

        private string generatorField;

        private string versionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string status
        {
            get
            {
                return this.statusField;
            }
            set
            {
                this.statusField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("patient", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public responsePatient[] patient
        {
            get
            {
                return this.patientField;
            }
            set
            {
                this.patientField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string generator
        {
            get
            {
                return this.generatorField;
            }
            set
            {
                this.generatorField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string version
        {
            get
            {
                return this.versionField;
            }
            set
            {
                this.versionField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class responsePatient
    {

        private responsePatientAdmission[] admissionField;

        private string patient_idField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("admission", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public responsePatientAdmission[] admission
        {
            get
            {
                return this.admissionField;
            }
            set
            {
                this.admissionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string patient_id
        {
            get
            {
                return this.patient_idField;
            }
            set
            {
                this.patient_idField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class responsePatientAdmission
    {

        private string admission_idField;

        private string admission_dttmField;

        private string inpatient_indField;

        private string payplan_idField;

        private string payplan_nmField;

        private string dischargeField;

        private string discharge_dttmField;

        private string admission_org_idField;

        private string admission_org_nmField;

        private string discharge_org_idField;

        private string discharge_org_nmField;

        private string case_regional_cdField;

        private string statusField;

        private string created_dttmField;

        private string created_user_idField;

        private string updated_dttmField;

        private string updated_user_idField;

        private string discharge_user_idField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string admission_id
        {
            get
            {
                return this.admission_idField;
            }
            set
            {
                this.admission_idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string admission_dttm
        {
            get
            {
                return this.admission_dttmField;
            }
            set
            {
                this.admission_dttmField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string inpatient_ind
        {
            get
            {
                return this.inpatient_indField;
            }
            set
            {
                this.inpatient_indField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string payplan_id
        {
            get
            {
                return this.payplan_idField;
            }
            set
            {
                this.payplan_idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string payplan_nm
        {
            get
            {
                return this.payplan_nmField;
            }
            set
            {
                this.payplan_nmField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string discharge
        {
            get
            {
                return this.dischargeField;
            }
            set
            {
                this.dischargeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string discharge_dttm
        {
            get
            {
                return this.discharge_dttmField;
            }
            set
            {
                this.discharge_dttmField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string admission_org_id
        {
            get
            {
                return this.admission_org_idField;
            }
            set
            {
                this.admission_org_idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string admission_org_nm
        {
            get
            {
                return this.admission_org_nmField;
            }
            set
            {
                this.admission_org_nmField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string discharge_org_id
        {
            get
            {
                return this.discharge_org_idField;
            }
            set
            {
                this.discharge_org_idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string discharge_org_nm
        {
            get
            {
                return this.discharge_org_nmField;
            }
            set
            {
                this.discharge_org_nmField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string case_regional_cd
        {
            get
            {
                return this.case_regional_cdField;
            }
            set
            {
                this.case_regional_cdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string status
        {
            get
            {
                return this.statusField;
            }
            set
            {
                this.statusField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string created_dttm
        {
            get
            {
                return this.created_dttmField;
            }
            set
            {
                this.created_dttmField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string created_user_id
        {
            get
            {
                return this.created_user_idField;
            }
            set
            {
                this.created_user_idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string updated_dttm
        {
            get
            {
                return this.updated_dttmField;
            }
            set
            {
                this.updated_dttmField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string updated_user_id
        {
            get
            {
                return this.updated_user_idField;
            }
            set
            {
                this.updated_user_idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string discharge_user_id
        {
            get
            {
                return this.discharge_user_idField;
            }
            set
            {
                this.discharge_user_idField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class NewDataSet
    {

        private response[] itemsField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("response")]
        public response[] Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }
    }
}
