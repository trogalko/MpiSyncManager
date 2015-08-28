using System.Xml.Serialization;

namespace Temiang.Avicenna.BusinessObject.Mpi.PasienKunjunganDetil
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

        private responseAdmission[] admissionField;

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
        [System.Xml.Serialization.XmlElementAttribute("admission", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public responseAdmission[] admission
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
    public partial class responseAdmission
    {

        private string admission_dttmField;

        private string dischargeField;

        private string discharge_dttmField;

        private string discharge_infoField;

        private string admission_org_idField;

        private string admission_org_nmField;

        private string discharge_org_idField;

        private string discharge_org_nmField;

        private string payplan_idField;

        private string payplan_nmField;

        private string payplan_objectField;

        private string guarantor_nmField;

        private string guarantor_addressField;

        private string guarantor_phoneField;

        private string guarantor_rel_cdField;

        private string inpatient_indField;

        private string inpatient_bed_idField;

        private string inpatient_bed_nmField;

        private string tmp_address_txtField;

        private string tmp_phoneField;

        private string case_regional_cdField;

        private string ref_doctor_nmField;

        private string ref_doctor_phoneField;

        private string ref_hospital_cdField;

        private string doctor_id1Field;

        private string doctor_id2Field;

        private string sourceField;

        private string statusField;

        private string created_user_idField;

        private string updated_user_idField;

        private string patient_idField;

        private string admission_idField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
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
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
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
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
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
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string discharge_info
        {
            get
            {
                return this.discharge_infoField;
            }
            set
            {
                this.discharge_infoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
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
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
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
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
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
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
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
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
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
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
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
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string payplan_object
        {
            get
            {
                return this.payplan_objectField;
            }
            set
            {
                this.payplan_objectField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string guarantor_nm
        {
            get
            {
                return this.guarantor_nmField;
            }
            set
            {
                this.guarantor_nmField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string guarantor_address
        {
            get
            {
                return this.guarantor_addressField;
            }
            set
            {
                this.guarantor_addressField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string guarantor_phone
        {
            get
            {
                return this.guarantor_phoneField;
            }
            set
            {
                this.guarantor_phoneField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string guarantor_rel_cd
        {
            get
            {
                return this.guarantor_rel_cdField;
            }
            set
            {
                this.guarantor_rel_cdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
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
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string inpatient_bed_id
        {
            get
            {
                return this.inpatient_bed_idField;
            }
            set
            {
                this.inpatient_bed_idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string inpatient_bed_nm
        {
            get
            {
                return this.inpatient_bed_nmField;
            }
            set
            {
                this.inpatient_bed_nmField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string tmp_address_txt
        {
            get
            {
                return this.tmp_address_txtField;
            }
            set
            {
                this.tmp_address_txtField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string tmp_phone
        {
            get
            {
                return this.tmp_phoneField;
            }
            set
            {
                this.tmp_phoneField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
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
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ref_doctor_nm
        {
            get
            {
                return this.ref_doctor_nmField;
            }
            set
            {
                this.ref_doctor_nmField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ref_doctor_phone
        {
            get
            {
                return this.ref_doctor_phoneField;
            }
            set
            {
                this.ref_doctor_phoneField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ref_hospital_cd
        {
            get
            {
                return this.ref_hospital_cdField;
            }
            set
            {
                this.ref_hospital_cdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string doctor_id1
        {
            get
            {
                return this.doctor_id1Field;
            }
            set
            {
                this.doctor_id1Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string doctor_id2
        {
            get
            {
                return this.doctor_id2Field;
            }
            set
            {
                this.doctor_id2Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string source
        {
            get
            {
                return this.sourceField;
            }
            set
            {
                this.sourceField = value;
            }
        }

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
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
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
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
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
