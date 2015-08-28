/*
===============================================================================
                    EntitySpaces 2009 by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2009.2.1214.0
EntitySpaces Driver  : SQL
Date Generated       : 11/24/2014 9:39:03 AM
===============================================================================
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.ComponentModel;
using System.Xml.Serialization;


using Temiang.Dal.Core;
using Temiang.Dal.Interfaces;
using Temiang.Dal.DynamicQuery;



namespace Temiang.Avicenna.BusinessObject
{

    [Serializable]
    abstract public class esRegistrationCollection : esEntityCollection
    {
        public esRegistrationCollection()
        {

        }

        protected override string GetCollectionName()
        {
            return "RegistrationCollection";
        }

        #region Query Logic
        protected void InitQuery(esRegistrationQuery query)
        {
            query.OnLoadDelegate = this.OnQueryLoaded;
            query.es2.Connection = ((IEntityCollection)this).Connection;
        }

        protected bool OnQueryLoaded(DataTable table)
        {
            this.PopulateCollection(table);
            return (this.RowCount > 0) ? true : false;
        }

        protected override void HookupQuery(esDynamicQuery query)
        {
            this.InitQuery(query as esRegistrationQuery);
        }
        #endregion

        virtual public Registration DetachEntity(Registration entity)
        {
            return base.DetachEntity(entity) as Registration;
        }

        virtual public Registration AttachEntity(Registration entity)
        {
            return base.AttachEntity(entity) as Registration;
        }

        virtual public void Combine(RegistrationCollection collection)
        {
            base.Combine(collection);
        }

        new public Registration this[int index]
        {
            get
            {
                return base[index] as Registration;
            }
        }

        public override Type GetEntityType()
        {
            return typeof(Registration);
        }
    }



    [Serializable]
    abstract public class esRegistration : esEntity
    {
        /// <summary>
        /// Used internally by the entity's DynamicQuery mechanism.
        /// </summary>
        virtual protected esRegistrationQuery GetDynamicQuery()
        {
            return null;
        }

        public esRegistration()
        {

        }

        public esRegistration(DataRow row)
            : base(row)
        {

        }

        #region LoadByPrimaryKey
        public virtual bool LoadByPrimaryKey(System.String registrationNo)
        {
            if (this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
                return LoadByPrimaryKeyDynamic(registrationNo);
            else
                return LoadByPrimaryKeyStoredProcedure(registrationNo);
        }

        public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.String registrationNo)
        {
            if (sqlAccessType == esSqlAccessType.DynamicSQL)
                return LoadByPrimaryKeyDynamic(registrationNo);
            else
                return LoadByPrimaryKeyStoredProcedure(registrationNo);
        }

        private bool LoadByPrimaryKeyDynamic(System.String registrationNo)
        {
            esRegistrationQuery query = this.GetDynamicQuery();
            query.Where(query.RegistrationNo == registrationNo);
            return query.Load();
        }

        private bool LoadByPrimaryKeyStoredProcedure(System.String registrationNo)
        {
            esParameters parms = new esParameters();
            parms.Add("RegistrationNo", registrationNo);
            return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
        }
        #endregion



        #region Properties


        public override void SetProperties(IDictionary values)
        {
            foreach (string propertyName in values.Keys)
            {
                this.SetProperty(propertyName, values[propertyName]);
            }
        }

        public override void SetProperty(string name, object value)
        {
            if (this.Row == null) this.AddNew();

            esColumnMetadata col = this.Meta.Columns.FindByPropertyName(name);
            if (col != null)
            {
                if (value == null || value is System.String)
                {
                    // Use the strongly typed property
                    switch (name)
                    {
                        case "RegistrationNo": this.str.RegistrationNo = (string)value; break;
                        case "SRRegistrationType": this.str.SRRegistrationType = (string)value; break;
                        case "ParamedicID": this.str.ParamedicID = (string)value; break;
                        case "GuarantorID": this.str.GuarantorID = (string)value; break;
                        case "PatientID": this.str.PatientID = (string)value; break;
                        case "ClassID": this.str.ClassID = (string)value; break;
                        case "RegistrationDate": this.str.RegistrationDate = (string)value; break;
                        case "RegistrationTime": this.str.RegistrationTime = (string)value; break;
                        case "AppointmentNo": this.str.AppointmentNo = (string)value; break;
                        case "AgeInYear": this.str.AgeInYear = (string)value; break;
                        case "AgeInMonth": this.str.AgeInMonth = (string)value; break;
                        case "AgeInDay": this.str.AgeInDay = (string)value; break;
                        case "SRShift": this.str.SRShift = (string)value; break;
                        case "SRPatientInType": this.str.SRPatientInType = (string)value; break;
                        case "InsuranceID": this.str.InsuranceID = (string)value; break;
                        case "SRPatientCategory": this.str.SRPatientCategory = (string)value; break;
                        case "SRERCaseType": this.str.SRERCaseType = (string)value; break;
                        case "SRVisitReason": this.str.SRVisitReason = (string)value; break;
                        case "SRBussinesMethod": this.str.SRBussinesMethod = (string)value; break;
                        case "PlavonAmount": this.str.PlavonAmount = (string)value; break;
                        case "DepartmentID": this.str.DepartmentID = (string)value; break;
                        case "ServiceUnitID": this.str.ServiceUnitID = (string)value; break;
                        case "RoomID": this.str.RoomID = (string)value; break;
                        case "BedID": this.str.BedID = (string)value; break;
                        case "ChargeClassID": this.str.ChargeClassID = (string)value; break;
                        case "CoverageClassID": this.str.CoverageClassID = (string)value; break;
                        case "VisitTypeID": this.str.VisitTypeID = (string)value; break;
                        case "ReferralID": this.str.ReferralID = (string)value; break;
                        case "Anamnesis": this.str.Anamnesis = (string)value; break;
                        case "Complaint": this.str.Complaint = (string)value; break;
                        case "InitialDiagnose": this.str.InitialDiagnose = (string)value; break;
                        case "MedicationPlanning": this.str.MedicationPlanning = (string)value; break;
                        case "SRTriage": this.str.SRTriage = (string)value; break;
                        case "IsPrintingPatientCard": this.str.IsPrintingPatientCard = (string)value; break;
                        case "DischargeDate": this.str.DischargeDate = (string)value; break;
                        case "DischargeTime": this.str.DischargeTime = (string)value; break;
                        case "DischargeMedicalNotes": this.str.DischargeMedicalNotes = (string)value; break;
                        case "DischargeNotes": this.str.DischargeNotes = (string)value; break;
                        case "SRDischargeCondition": this.str.SRDischargeCondition = (string)value; break;
                        case "SRDischargeMethod": this.str.SRDischargeMethod = (string)value; break;
                        case "LOSInYear": this.str.LOSInYear = (string)value; break;
                        case "LOSInMonth": this.str.LOSInMonth = (string)value; break;
                        case "LOSInDay": this.str.LOSInDay = (string)value; break;
                        case "DischargeOperatorID": this.str.DischargeOperatorID = (string)value; break;
                        case "AccountNo": this.str.AccountNo = (string)value; break;
                        case "TransactionAmount": this.str.TransactionAmount = (string)value; break;
                        case "AdministrationAmount": this.str.AdministrationAmount = (string)value; break;
                        case "RoundingAmount": this.str.RoundingAmount = (string)value; break;
                        case "RemainingAmount": this.str.RemainingAmount = (string)value; break;
                        case "IsTransferedToInpatient": this.str.IsTransferedToInpatient = (string)value; break;
                        case "IsNewPatient": this.str.IsNewPatient = (string)value; break;
                        case "IsNewBornInfant": this.str.IsNewBornInfant = (string)value; break;
                        case "IsParturition": this.str.IsParturition = (string)value; break;
                        case "IsHoldTransactionEntry": this.str.IsHoldTransactionEntry = (string)value; break;
                        case "IsHasCorrection": this.str.IsHasCorrection = (string)value; break;
                        case "IsEMRValid": this.str.IsEMRValid = (string)value; break;
                        case "IsBackDate": this.str.IsBackDate = (string)value; break;
                        case "ActualVisitDate": this.str.ActualVisitDate = (string)value; break;
                        case "IsVoid": this.str.IsVoid = (string)value; break;
                        case "SRVoidReason": this.str.SRVoidReason = (string)value; break;
                        case "VoidNotes": this.str.VoidNotes = (string)value; break;
                        case "VoidDate": this.str.VoidDate = (string)value; break;
                        case "VoidByUserID": this.str.VoidByUserID = (string)value; break;
                        case "IsClosed": this.str.IsClosed = (string)value; break;
                        case "IsEpisodeComplete": this.str.IsEpisodeComplete = (string)value; break;
                        case "IsClusterAssessment": this.str.IsClusterAssessment = (string)value; break;
                        case "IsConsul": this.str.IsConsul = (string)value; break;
                        case "IsFromDispensary": this.str.IsFromDispensary = (string)value; break;
                        case "IsNewVisit": this.str.IsNewVisit = (string)value; break;
                        case "Notes": this.str.Notes = (string)value; break;
                        case "LastCreateDateTime": this.str.LastCreateDateTime = (string)value; break;
                        case "LastCreateUserID": this.str.LastCreateUserID = (string)value; break;
                        case "LastUpdateDateTime": this.str.LastUpdateDateTime = (string)value; break;
                        case "LastUpdateByUserID": this.str.LastUpdateByUserID = (string)value; break;
                        case "IsDirectPrescriptionReturn": this.str.IsDirectPrescriptionReturn = (string)value; break;
                        case "VisiteRegistrationNo": this.str.VisiteRegistrationNo = (string)value; break;
                        case "RegistrationQue": this.str.RegistrationQue = (string)value; break;
                        case "ReferralIDTo": this.str.ReferralIDTo = (string)value; break;
                        case "SEPNo": this.str.SEPNo = (string)value; break;
                        case "JasindoNo": this.str.JasindoNo = (string)value; break;
                    }
                }
                else
                {
                    switch (name)
                    {
                        case "RegistrationDate":

                            if (value == null || value is System.DateTime)
                                this.RegistrationDate = (System.DateTime?)value;
                            break;

                        case "AgeInYear":

                            if (value == null || value is System.Byte)
                                this.AgeInYear = (System.Byte?)value;
                            break;

                        case "AgeInMonth":

                            if (value == null || value is System.Byte)
                                this.AgeInMonth = (System.Byte?)value;
                            break;

                        case "AgeInDay":

                            if (value == null || value is System.Byte)
                                this.AgeInDay = (System.Byte?)value;
                            break;

                        case "PlavonAmount":

                            if (value == null || value is System.Decimal)
                                this.PlavonAmount = (System.Decimal?)value;
                            break;

                        case "IsPrintingPatientCard":

                            if (value == null || value is System.Boolean)
                                this.IsPrintingPatientCard = (System.Boolean?)value;
                            break;

                        case "DischargeDate":

                            if (value == null || value is System.DateTime)
                                this.DischargeDate = (System.DateTime?)value;
                            break;

                        case "LOSInYear":

                            if (value == null || value is System.Byte)
                                this.LOSInYear = (System.Byte?)value;
                            break;

                        case "LOSInMonth":

                            if (value == null || value is System.Byte)
                                this.LOSInMonth = (System.Byte?)value;
                            break;

                        case "LOSInDay":

                            if (value == null || value is System.Byte)
                                this.LOSInDay = (System.Byte?)value;
                            break;

                        case "TransactionAmount":

                            if (value == null || value is System.Decimal)
                                this.TransactionAmount = (System.Decimal?)value;
                            break;

                        case "AdministrationAmount":

                            if (value == null || value is System.Decimal)
                                this.AdministrationAmount = (System.Decimal?)value;
                            break;

                        case "RoundingAmount":

                            if (value == null || value is System.Decimal)
                                this.RoundingAmount = (System.Decimal?)value;
                            break;

                        case "RemainingAmount":

                            if (value == null || value is System.Decimal)
                                this.RemainingAmount = (System.Decimal?)value;
                            break;

                        case "IsTransferedToInpatient":

                            if (value == null || value is System.Boolean)
                                this.IsTransferedToInpatient = (System.Boolean?)value;
                            break;

                        case "IsNewPatient":

                            if (value == null || value is System.Boolean)
                                this.IsNewPatient = (System.Boolean?)value;
                            break;

                        case "IsNewBornInfant":

                            if (value == null || value is System.Boolean)
                                this.IsNewBornInfant = (System.Boolean?)value;
                            break;

                        case "IsParturition":

                            if (value == null || value is System.Boolean)
                                this.IsParturition = (System.Boolean?)value;
                            break;

                        case "IsHoldTransactionEntry":

                            if (value == null || value is System.Boolean)
                                this.IsHoldTransactionEntry = (System.Boolean?)value;
                            break;

                        case "IsHasCorrection":

                            if (value == null || value is System.Boolean)
                                this.IsHasCorrection = (System.Boolean?)value;
                            break;

                        case "IsEMRValid":

                            if (value == null || value is System.Boolean)
                                this.IsEMRValid = (System.Boolean?)value;
                            break;

                        case "IsBackDate":

                            if (value == null || value is System.Boolean)
                                this.IsBackDate = (System.Boolean?)value;
                            break;

                        case "ActualVisitDate":

                            if (value == null || value is System.DateTime)
                                this.ActualVisitDate = (System.DateTime?)value;
                            break;

                        case "IsVoid":

                            if (value == null || value is System.Boolean)
                                this.IsVoid = (System.Boolean?)value;
                            break;

                        case "VoidDate":

                            if (value == null || value is System.DateTime)
                                this.VoidDate = (System.DateTime?)value;
                            break;

                        case "IsClosed":

                            if (value == null || value is System.Boolean)
                                this.IsClosed = (System.Boolean?)value;
                            break;

                        case "IsEpisodeComplete":

                            if (value == null || value is System.Boolean)
                                this.IsEpisodeComplete = (System.Boolean?)value;
                            break;

                        case "IsClusterAssessment":

                            if (value == null || value is System.Boolean)
                                this.IsClusterAssessment = (System.Boolean?)value;
                            break;

                        case "IsConsul":

                            if (value == null || value is System.Boolean)
                                this.IsConsul = (System.Boolean?)value;
                            break;

                        case "IsFromDispensary":

                            if (value == null || value is System.Boolean)
                                this.IsFromDispensary = (System.Boolean?)value;
                            break;

                        case "IsNewVisit":

                            if (value == null || value is System.Boolean)
                                this.IsNewVisit = (System.Boolean?)value;
                            break;

                        case "LastCreateDateTime":

                            if (value == null || value is System.DateTime)
                                this.LastCreateDateTime = (System.DateTime?)value;
                            break;

                        case "LastUpdateDateTime":

                            if (value == null || value is System.DateTime)
                                this.LastUpdateDateTime = (System.DateTime?)value;
                            break;

                        case "IsDirectPrescriptionReturn":

                            if (value == null || value is System.Boolean)
                                this.IsDirectPrescriptionReturn = (System.Boolean?)value;
                            break;

                        case "RegistrationQue":

                            if (value == null || value is System.Int32)
                                this.RegistrationQue = (System.Int32?)value;
                            break;


                        default:
                            break;
                    }
                }
            }
            else if (this.Row.Table.Columns.Contains(name))
            {
                this.Row[name] = value;
            }
            else
            {
                throw new Exception("SetProperty Error: '" + name + "' not found");
            }
        }


        /// <summary>
        /// Maps to Registration.RegistrationNo
        /// </summary>
        virtual public System.String RegistrationNo
        {
            get
            {
                return base.GetSystemString(RegistrationMetadata.ColumnNames.RegistrationNo);
            }

            set
            {
                base.SetSystemString(RegistrationMetadata.ColumnNames.RegistrationNo, value);
            }
        }

        /// <summary>
        /// Maps to Registration.SRRegistrationType
        /// </summary>
        virtual public System.String SRRegistrationType
        {
            get
            {
                return base.GetSystemString(RegistrationMetadata.ColumnNames.SRRegistrationType);
            }

            set
            {
                base.SetSystemString(RegistrationMetadata.ColumnNames.SRRegistrationType, value);
            }
        }

        /// <summary>
        /// Maps to Registration.ParamedicID
        /// </summary>
        virtual public System.String ParamedicID
        {
            get
            {
                return base.GetSystemString(RegistrationMetadata.ColumnNames.ParamedicID);
            }

            set
            {
                base.SetSystemString(RegistrationMetadata.ColumnNames.ParamedicID, value);
            }
        }

        /// <summary>
        /// Maps to Registration.GuarantorID
        /// </summary>
        virtual public System.String GuarantorID
        {
            get
            {
                return base.GetSystemString(RegistrationMetadata.ColumnNames.GuarantorID);
            }

            set
            {
                base.SetSystemString(RegistrationMetadata.ColumnNames.GuarantorID, value);
            }
        }

        /// <summary>
        /// Maps to Registration.PatientID
        /// </summary>
        virtual public System.String PatientID
        {
            get
            {
                return base.GetSystemString(RegistrationMetadata.ColumnNames.PatientID);
            }

            set
            {
                base.SetSystemString(RegistrationMetadata.ColumnNames.PatientID, value);
            }
        }

        /// <summary>
        /// Maps to Registration.ClassID
        /// </summary>
        virtual public System.String ClassID
        {
            get
            {
                return base.GetSystemString(RegistrationMetadata.ColumnNames.ClassID);
            }

            set
            {
                base.SetSystemString(RegistrationMetadata.ColumnNames.ClassID, value);
            }
        }

        /// <summary>
        /// Maps to Registration.RegistrationDate
        /// </summary>
        virtual public System.DateTime? RegistrationDate
        {
            get
            {
                return base.GetSystemDateTime(RegistrationMetadata.ColumnNames.RegistrationDate);
            }

            set
            {
                base.SetSystemDateTime(RegistrationMetadata.ColumnNames.RegistrationDate, value);
            }
        }

        /// <summary>
        /// Maps to Registration.RegistrationTime
        /// </summary>
        virtual public System.String RegistrationTime
        {
            get
            {
                return base.GetSystemString(RegistrationMetadata.ColumnNames.RegistrationTime);
            }

            set
            {
                base.SetSystemString(RegistrationMetadata.ColumnNames.RegistrationTime, value);
            }
        }

        /// <summary>
        /// Maps to Registration.AppointmentNo
        /// </summary>
        virtual public System.String AppointmentNo
        {
            get
            {
                return base.GetSystemString(RegistrationMetadata.ColumnNames.AppointmentNo);
            }

            set
            {
                base.SetSystemString(RegistrationMetadata.ColumnNames.AppointmentNo, value);
            }
        }

        /// <summary>
        /// Maps to Registration.AgeInYear
        /// </summary>
        virtual public System.Byte? AgeInYear
        {
            get
            {
                return base.GetSystemByte(RegistrationMetadata.ColumnNames.AgeInYear);
            }

            set
            {
                base.SetSystemByte(RegistrationMetadata.ColumnNames.AgeInYear, value);
            }
        }

        /// <summary>
        /// Maps to Registration.AgeInMonth
        /// </summary>
        virtual public System.Byte? AgeInMonth
        {
            get
            {
                return base.GetSystemByte(RegistrationMetadata.ColumnNames.AgeInMonth);
            }

            set
            {
                base.SetSystemByte(RegistrationMetadata.ColumnNames.AgeInMonth, value);
            }
        }

        /// <summary>
        /// Maps to Registration.AgeInDay
        /// </summary>
        virtual public System.Byte? AgeInDay
        {
            get
            {
                return base.GetSystemByte(RegistrationMetadata.ColumnNames.AgeInDay);
            }

            set
            {
                base.SetSystemByte(RegistrationMetadata.ColumnNames.AgeInDay, value);
            }
        }

        /// <summary>
        /// Maps to Registration.SRShift
        /// </summary>
        virtual public System.String SRShift
        {
            get
            {
                return base.GetSystemString(RegistrationMetadata.ColumnNames.SRShift);
            }

            set
            {
                base.SetSystemString(RegistrationMetadata.ColumnNames.SRShift, value);
            }
        }

        /// <summary>
        /// Maps to Registration.SRPatientInType
        /// </summary>
        virtual public System.String SRPatientInType
        {
            get
            {
                return base.GetSystemString(RegistrationMetadata.ColumnNames.SRPatientInType);
            }

            set
            {
                base.SetSystemString(RegistrationMetadata.ColumnNames.SRPatientInType, value);
            }
        }

        /// <summary>
        /// Maps to Registration.InsuranceID
        /// </summary>
        virtual public System.String InsuranceID
        {
            get
            {
                return base.GetSystemString(RegistrationMetadata.ColumnNames.InsuranceID);
            }

            set
            {
                base.SetSystemString(RegistrationMetadata.ColumnNames.InsuranceID, value);
            }
        }

        /// <summary>
        /// Maps to Registration.SRPatientCategory
        /// </summary>
        virtual public System.String SRPatientCategory
        {
            get
            {
                return base.GetSystemString(RegistrationMetadata.ColumnNames.SRPatientCategory);
            }

            set
            {
                base.SetSystemString(RegistrationMetadata.ColumnNames.SRPatientCategory, value);
            }
        }

        /// <summary>
        /// Maps to Registration.SRERCaseType
        /// </summary>
        virtual public System.String SRERCaseType
        {
            get
            {
                return base.GetSystemString(RegistrationMetadata.ColumnNames.SRERCaseType);
            }

            set
            {
                base.SetSystemString(RegistrationMetadata.ColumnNames.SRERCaseType, value);
            }
        }

        /// <summary>
        /// Maps to Registration.SRVisitReason
        /// </summary>
        virtual public System.String SRVisitReason
        {
            get
            {
                return base.GetSystemString(RegistrationMetadata.ColumnNames.SRVisitReason);
            }

            set
            {
                base.SetSystemString(RegistrationMetadata.ColumnNames.SRVisitReason, value);
            }
        }

        /// <summary>
        /// Maps to Registration.SRBussinesMethod
        /// </summary>
        virtual public System.String SRBussinesMethod
        {
            get
            {
                return base.GetSystemString(RegistrationMetadata.ColumnNames.SRBussinesMethod);
            }

            set
            {
                base.SetSystemString(RegistrationMetadata.ColumnNames.SRBussinesMethod, value);
            }
        }

        /// <summary>
        /// Maps to Registration.PlavonAmount
        /// </summary>
        virtual public System.Decimal? PlavonAmount
        {
            get
            {
                return base.GetSystemDecimal(RegistrationMetadata.ColumnNames.PlavonAmount);
            }

            set
            {
                base.SetSystemDecimal(RegistrationMetadata.ColumnNames.PlavonAmount, value);
            }
        }

        /// <summary>
        /// Maps to Registration.DepartmentID
        /// </summary>
        virtual public System.String DepartmentID
        {
            get
            {
                return base.GetSystemString(RegistrationMetadata.ColumnNames.DepartmentID);
            }

            set
            {
                base.SetSystemString(RegistrationMetadata.ColumnNames.DepartmentID, value);
            }
        }

        /// <summary>
        /// Maps to Registration.ServiceUnitID
        /// </summary>
        virtual public System.String ServiceUnitID
        {
            get
            {
                return base.GetSystemString(RegistrationMetadata.ColumnNames.ServiceUnitID);
            }

            set
            {
                base.SetSystemString(RegistrationMetadata.ColumnNames.ServiceUnitID, value);
            }
        }

        /// <summary>
        /// Maps to Registration.RoomID
        /// </summary>
        virtual public System.String RoomID
        {
            get
            {
                return base.GetSystemString(RegistrationMetadata.ColumnNames.RoomID);
            }

            set
            {
                base.SetSystemString(RegistrationMetadata.ColumnNames.RoomID, value);
            }
        }

        /// <summary>
        /// Maps to Registration.BedID
        /// </summary>
        virtual public System.String BedID
        {
            get
            {
                return base.GetSystemString(RegistrationMetadata.ColumnNames.BedID);
            }

            set
            {
                base.SetSystemString(RegistrationMetadata.ColumnNames.BedID, value);
            }
        }

        /// <summary>
        /// Maps to Registration.ChargeClassID
        /// </summary>
        virtual public System.String ChargeClassID
        {
            get
            {
                return base.GetSystemString(RegistrationMetadata.ColumnNames.ChargeClassID);
            }

            set
            {
                base.SetSystemString(RegistrationMetadata.ColumnNames.ChargeClassID, value);
            }
        }

        /// <summary>
        /// Maps to Registration.CoverageClassID
        /// </summary>
        virtual public System.String CoverageClassID
        {
            get
            {
                return base.GetSystemString(RegistrationMetadata.ColumnNames.CoverageClassID);
            }

            set
            {
                base.SetSystemString(RegistrationMetadata.ColumnNames.CoverageClassID, value);
            }
        }

        /// <summary>
        /// Maps to Registration.VisitTypeID
        /// </summary>
        virtual public System.String VisitTypeID
        {
            get
            {
                return base.GetSystemString(RegistrationMetadata.ColumnNames.VisitTypeID);
            }

            set
            {
                base.SetSystemString(RegistrationMetadata.ColumnNames.VisitTypeID, value);
            }
        }

        /// <summary>
        /// Maps to Registration.ReferralID
        /// </summary>
        virtual public System.String ReferralID
        {
            get
            {
                return base.GetSystemString(RegistrationMetadata.ColumnNames.ReferralID);
            }

            set
            {
                base.SetSystemString(RegistrationMetadata.ColumnNames.ReferralID, value);
            }
        }

        /// <summary>
        /// Maps to Registration.Anamnesis
        /// </summary>
        virtual public System.String Anamnesis
        {
            get
            {
                return base.GetSystemString(RegistrationMetadata.ColumnNames.Anamnesis);
            }

            set
            {
                base.SetSystemString(RegistrationMetadata.ColumnNames.Anamnesis, value);
            }
        }

        /// <summary>
        /// Maps to Registration.Complaint
        /// </summary>
        virtual public System.String Complaint
        {
            get
            {
                return base.GetSystemString(RegistrationMetadata.ColumnNames.Complaint);
            }

            set
            {
                base.SetSystemString(RegistrationMetadata.ColumnNames.Complaint, value);
            }
        }

        /// <summary>
        /// Maps to Registration.InitialDiagnose
        /// </summary>
        virtual public System.String InitialDiagnose
        {
            get
            {
                return base.GetSystemString(RegistrationMetadata.ColumnNames.InitialDiagnose);
            }

            set
            {
                base.SetSystemString(RegistrationMetadata.ColumnNames.InitialDiagnose, value);
            }
        }

        /// <summary>
        /// Maps to Registration.MedicationPlanning
        /// </summary>
        virtual public System.String MedicationPlanning
        {
            get
            {
                return base.GetSystemString(RegistrationMetadata.ColumnNames.MedicationPlanning);
            }

            set
            {
                base.SetSystemString(RegistrationMetadata.ColumnNames.MedicationPlanning, value);
            }
        }

        /// <summary>
        /// Maps to Registration.SRTriage
        /// </summary>
        virtual public System.String SRTriage
        {
            get
            {
                return base.GetSystemString(RegistrationMetadata.ColumnNames.SRTriage);
            }

            set
            {
                base.SetSystemString(RegistrationMetadata.ColumnNames.SRTriage, value);
            }
        }

        /// <summary>
        /// Maps to Registration.IsPrintingPatientCard
        /// </summary>
        virtual public System.Boolean? IsPrintingPatientCard
        {
            get
            {
                return base.GetSystemBoolean(RegistrationMetadata.ColumnNames.IsPrintingPatientCard);
            }

            set
            {
                base.SetSystemBoolean(RegistrationMetadata.ColumnNames.IsPrintingPatientCard, value);
            }
        }

        /// <summary>
        /// Maps to Registration.DischargeDate
        /// </summary>
        virtual public System.DateTime? DischargeDate
        {
            get
            {
                return base.GetSystemDateTime(RegistrationMetadata.ColumnNames.DischargeDate);
            }

            set
            {
                base.SetSystemDateTime(RegistrationMetadata.ColumnNames.DischargeDate, value);
            }
        }

        /// <summary>
        /// Maps to Registration.DischargeTime
        /// </summary>
        virtual public System.String DischargeTime
        {
            get
            {
                return base.GetSystemString(RegistrationMetadata.ColumnNames.DischargeTime);
            }

            set
            {
                base.SetSystemString(RegistrationMetadata.ColumnNames.DischargeTime, value);
            }
        }

        /// <summary>
        /// Maps to Registration.DischargeMedicalNotes
        /// </summary>
        virtual public System.String DischargeMedicalNotes
        {
            get
            {
                return base.GetSystemString(RegistrationMetadata.ColumnNames.DischargeMedicalNotes);
            }

            set
            {
                base.SetSystemString(RegistrationMetadata.ColumnNames.DischargeMedicalNotes, value);
            }
        }

        /// <summary>
        /// Maps to Registration.DischargeNotes
        /// </summary>
        virtual public System.String DischargeNotes
        {
            get
            {
                return base.GetSystemString(RegistrationMetadata.ColumnNames.DischargeNotes);
            }

            set
            {
                base.SetSystemString(RegistrationMetadata.ColumnNames.DischargeNotes, value);
            }
        }

        /// <summary>
        /// Maps to Registration.SRDischargeCondition
        /// </summary>
        virtual public System.String SRDischargeCondition
        {
            get
            {
                return base.GetSystemString(RegistrationMetadata.ColumnNames.SRDischargeCondition);
            }

            set
            {
                base.SetSystemString(RegistrationMetadata.ColumnNames.SRDischargeCondition, value);
            }
        }

        /// <summary>
        /// Maps to Registration.SRDischargeMethod
        /// </summary>
        virtual public System.String SRDischargeMethod
        {
            get
            {
                return base.GetSystemString(RegistrationMetadata.ColumnNames.SRDischargeMethod);
            }

            set
            {
                base.SetSystemString(RegistrationMetadata.ColumnNames.SRDischargeMethod, value);
            }
        }

        /// <summary>
        /// Maps to Registration.LOSInYear
        /// </summary>
        virtual public System.Byte? LOSInYear
        {
            get
            {
                return base.GetSystemByte(RegistrationMetadata.ColumnNames.LOSInYear);
            }

            set
            {
                base.SetSystemByte(RegistrationMetadata.ColumnNames.LOSInYear, value);
            }
        }

        /// <summary>
        /// Maps to Registration.LOSInMonth
        /// </summary>
        virtual public System.Byte? LOSInMonth
        {
            get
            {
                return base.GetSystemByte(RegistrationMetadata.ColumnNames.LOSInMonth);
            }

            set
            {
                base.SetSystemByte(RegistrationMetadata.ColumnNames.LOSInMonth, value);
            }
        }

        /// <summary>
        /// Maps to Registration.LOSInDay
        /// </summary>
        virtual public System.Byte? LOSInDay
        {
            get
            {
                return base.GetSystemByte(RegistrationMetadata.ColumnNames.LOSInDay);
            }

            set
            {
                base.SetSystemByte(RegistrationMetadata.ColumnNames.LOSInDay, value);
            }
        }

        /// <summary>
        /// Maps to Registration.DischargeOperatorID
        /// </summary>
        virtual public System.String DischargeOperatorID
        {
            get
            {
                return base.GetSystemString(RegistrationMetadata.ColumnNames.DischargeOperatorID);
            }

            set
            {
                base.SetSystemString(RegistrationMetadata.ColumnNames.DischargeOperatorID, value);
            }
        }

        /// <summary>
        /// Maps to Registration.AccountNo
        /// </summary>
        virtual public System.String AccountNo
        {
            get
            {
                return base.GetSystemString(RegistrationMetadata.ColumnNames.AccountNo);
            }

            set
            {
                base.SetSystemString(RegistrationMetadata.ColumnNames.AccountNo, value);
            }
        }

        /// <summary>
        /// Maps to Registration.TransactionAmount
        /// </summary>
        virtual public System.Decimal? TransactionAmount
        {
            get
            {
                return base.GetSystemDecimal(RegistrationMetadata.ColumnNames.TransactionAmount);
            }

            set
            {
                base.SetSystemDecimal(RegistrationMetadata.ColumnNames.TransactionAmount, value);
            }
        }

        /// <summary>
        /// Maps to Registration.AdministrationAmount
        /// </summary>
        virtual public System.Decimal? AdministrationAmount
        {
            get
            {
                return base.GetSystemDecimal(RegistrationMetadata.ColumnNames.AdministrationAmount);
            }

            set
            {
                base.SetSystemDecimal(RegistrationMetadata.ColumnNames.AdministrationAmount, value);
            }
        }

        /// <summary>
        /// Maps to Registration.RoundingAmount
        /// </summary>
        virtual public System.Decimal? RoundingAmount
        {
            get
            {
                return base.GetSystemDecimal(RegistrationMetadata.ColumnNames.RoundingAmount);
            }

            set
            {
                base.SetSystemDecimal(RegistrationMetadata.ColumnNames.RoundingAmount, value);
            }
        }

        /// <summary>
        /// Maps to Registration.RemainingAmount
        /// </summary>
        virtual public System.Decimal? RemainingAmount
        {
            get
            {
                return base.GetSystemDecimal(RegistrationMetadata.ColumnNames.RemainingAmount);
            }

            set
            {
                base.SetSystemDecimal(RegistrationMetadata.ColumnNames.RemainingAmount, value);
            }
        }

        /// <summary>
        /// Maps to Registration.IsTransferedToInpatient
        /// </summary>
        virtual public System.Boolean? IsTransferedToInpatient
        {
            get
            {
                return base.GetSystemBoolean(RegistrationMetadata.ColumnNames.IsTransferedToInpatient);
            }

            set
            {
                base.SetSystemBoolean(RegistrationMetadata.ColumnNames.IsTransferedToInpatient, value);
            }
        }

        /// <summary>
        /// Maps to Registration.IsNewPatient
        /// </summary>
        virtual public System.Boolean? IsNewPatient
        {
            get
            {
                return base.GetSystemBoolean(RegistrationMetadata.ColumnNames.IsNewPatient);
            }

            set
            {
                base.SetSystemBoolean(RegistrationMetadata.ColumnNames.IsNewPatient, value);
            }
        }

        /// <summary>
        /// Maps to Registration.IsNewBornInfant
        /// </summary>
        virtual public System.Boolean? IsNewBornInfant
        {
            get
            {
                return base.GetSystemBoolean(RegistrationMetadata.ColumnNames.IsNewBornInfant);
            }

            set
            {
                base.SetSystemBoolean(RegistrationMetadata.ColumnNames.IsNewBornInfant, value);
            }
        }

        /// <summary>
        /// Maps to Registration.IsParturition
        /// </summary>
        virtual public System.Boolean? IsParturition
        {
            get
            {
                return base.GetSystemBoolean(RegistrationMetadata.ColumnNames.IsParturition);
            }

            set
            {
                base.SetSystemBoolean(RegistrationMetadata.ColumnNames.IsParturition, value);
            }
        }

        /// <summary>
        /// Maps to Registration.IsHoldTransactionEntry
        /// </summary>
        virtual public System.Boolean? IsHoldTransactionEntry
        {
            get
            {
                return base.GetSystemBoolean(RegistrationMetadata.ColumnNames.IsHoldTransactionEntry);
            }

            set
            {
                base.SetSystemBoolean(RegistrationMetadata.ColumnNames.IsHoldTransactionEntry, value);
            }
        }

        /// <summary>
        /// Maps to Registration.IsHasCorrection
        /// </summary>
        virtual public System.Boolean? IsHasCorrection
        {
            get
            {
                return base.GetSystemBoolean(RegistrationMetadata.ColumnNames.IsHasCorrection);
            }

            set
            {
                base.SetSystemBoolean(RegistrationMetadata.ColumnNames.IsHasCorrection, value);
            }
        }

        /// <summary>
        /// Maps to Registration.IsEMRValid
        /// </summary>
        virtual public System.Boolean? IsEMRValid
        {
            get
            {
                return base.GetSystemBoolean(RegistrationMetadata.ColumnNames.IsEMRValid);
            }

            set
            {
                base.SetSystemBoolean(RegistrationMetadata.ColumnNames.IsEMRValid, value);
            }
        }

        /// <summary>
        /// Maps to Registration.IsBackDate
        /// </summary>
        virtual public System.Boolean? IsBackDate
        {
            get
            {
                return base.GetSystemBoolean(RegistrationMetadata.ColumnNames.IsBackDate);
            }

            set
            {
                base.SetSystemBoolean(RegistrationMetadata.ColumnNames.IsBackDate, value);
            }
        }

        /// <summary>
        /// Maps to Registration.ActualVisitDate
        /// </summary>
        virtual public System.DateTime? ActualVisitDate
        {
            get
            {
                return base.GetSystemDateTime(RegistrationMetadata.ColumnNames.ActualVisitDate);
            }

            set
            {
                base.SetSystemDateTime(RegistrationMetadata.ColumnNames.ActualVisitDate, value);
            }
        }

        /// <summary>
        /// Maps to Registration.IsVoid
        /// </summary>
        virtual public System.Boolean? IsVoid
        {
            get
            {
                return base.GetSystemBoolean(RegistrationMetadata.ColumnNames.IsVoid);
            }

            set
            {
                base.SetSystemBoolean(RegistrationMetadata.ColumnNames.IsVoid, value);
            }
        }

        /// <summary>
        /// Maps to Registration.SRVoidReason
        /// </summary>
        virtual public System.String SRVoidReason
        {
            get
            {
                return base.GetSystemString(RegistrationMetadata.ColumnNames.SRVoidReason);
            }

            set
            {
                base.SetSystemString(RegistrationMetadata.ColumnNames.SRVoidReason, value);
            }
        }

        /// <summary>
        /// Maps to Registration.VoidNotes
        /// </summary>
        virtual public System.String VoidNotes
        {
            get
            {
                return base.GetSystemString(RegistrationMetadata.ColumnNames.VoidNotes);
            }

            set
            {
                base.SetSystemString(RegistrationMetadata.ColumnNames.VoidNotes, value);
            }
        }

        /// <summary>
        /// Maps to Registration.VoidDate
        /// </summary>
        virtual public System.DateTime? VoidDate
        {
            get
            {
                return base.GetSystemDateTime(RegistrationMetadata.ColumnNames.VoidDate);
            }

            set
            {
                base.SetSystemDateTime(RegistrationMetadata.ColumnNames.VoidDate, value);
            }
        }

        /// <summary>
        /// Maps to Registration.VoidByUserID
        /// </summary>
        virtual public System.String VoidByUserID
        {
            get
            {
                return base.GetSystemString(RegistrationMetadata.ColumnNames.VoidByUserID);
            }

            set
            {
                base.SetSystemString(RegistrationMetadata.ColumnNames.VoidByUserID, value);
            }
        }

        /// <summary>
        /// Maps to Registration.IsClosed
        /// </summary>
        virtual public System.Boolean? IsClosed
        {
            get
            {
                return base.GetSystemBoolean(RegistrationMetadata.ColumnNames.IsClosed);
            }

            set
            {
                base.SetSystemBoolean(RegistrationMetadata.ColumnNames.IsClosed, value);
            }
        }

        /// <summary>
        /// Maps to Registration.IsEpisodeComplete
        /// </summary>
        virtual public System.Boolean? IsEpisodeComplete
        {
            get
            {
                return base.GetSystemBoolean(RegistrationMetadata.ColumnNames.IsEpisodeComplete);
            }

            set
            {
                base.SetSystemBoolean(RegistrationMetadata.ColumnNames.IsEpisodeComplete, value);
            }
        }

        /// <summary>
        /// Maps to Registration.IsClusterAssessment
        /// </summary>
        virtual public System.Boolean? IsClusterAssessment
        {
            get
            {
                return base.GetSystemBoolean(RegistrationMetadata.ColumnNames.IsClusterAssessment);
            }

            set
            {
                base.SetSystemBoolean(RegistrationMetadata.ColumnNames.IsClusterAssessment, value);
            }
        }

        /// <summary>
        /// Maps to Registration.IsConsul
        /// </summary>
        virtual public System.Boolean? IsConsul
        {
            get
            {
                return base.GetSystemBoolean(RegistrationMetadata.ColumnNames.IsConsul);
            }

            set
            {
                base.SetSystemBoolean(RegistrationMetadata.ColumnNames.IsConsul, value);
            }
        }

        /// <summary>
        /// Maps to Registration.IsFromDispensary
        /// </summary>
        virtual public System.Boolean? IsFromDispensary
        {
            get
            {
                return base.GetSystemBoolean(RegistrationMetadata.ColumnNames.IsFromDispensary);
            }

            set
            {
                base.SetSystemBoolean(RegistrationMetadata.ColumnNames.IsFromDispensary, value);
            }
        }

        /// <summary>
        /// Maps to Registration.IsNewVisit
        /// </summary>
        virtual public System.Boolean? IsNewVisit
        {
            get
            {
                return base.GetSystemBoolean(RegistrationMetadata.ColumnNames.IsNewVisit);
            }

            set
            {
                base.SetSystemBoolean(RegistrationMetadata.ColumnNames.IsNewVisit, value);
            }
        }

        /// <summary>
        /// Maps to Registration.Notes
        /// </summary>
        virtual public System.String Notes
        {
            get
            {
                return base.GetSystemString(RegistrationMetadata.ColumnNames.Notes);
            }

            set
            {
                base.SetSystemString(RegistrationMetadata.ColumnNames.Notes, value);
            }
        }

        /// <summary>
        /// Maps to Registration.LastCreateDateTime
        /// </summary>
        virtual public System.DateTime? LastCreateDateTime
        {
            get
            {
                return base.GetSystemDateTime(RegistrationMetadata.ColumnNames.LastCreateDateTime);
            }

            set
            {
                base.SetSystemDateTime(RegistrationMetadata.ColumnNames.LastCreateDateTime, value);
            }
        }

        /// <summary>
        /// Maps to Registration.LastCreateUserID
        /// </summary>
        virtual public System.String LastCreateUserID
        {
            get
            {
                return base.GetSystemString(RegistrationMetadata.ColumnNames.LastCreateUserID);
            }

            set
            {
                base.SetSystemString(RegistrationMetadata.ColumnNames.LastCreateUserID, value);
            }
        }

        /// <summary>
        /// Maps to Registration.LastUpdateDateTime
        /// </summary>
        virtual public System.DateTime? LastUpdateDateTime
        {
            get
            {
                return base.GetSystemDateTime(RegistrationMetadata.ColumnNames.LastUpdateDateTime);
            }

            set
            {
                base.SetSystemDateTime(RegistrationMetadata.ColumnNames.LastUpdateDateTime, value);
            }
        }

        /// <summary>
        /// Maps to Registration.LastUpdateByUserID
        /// </summary>
        virtual public System.String LastUpdateByUserID
        {
            get
            {
                return base.GetSystemString(RegistrationMetadata.ColumnNames.LastUpdateByUserID);
            }

            set
            {
                base.SetSystemString(RegistrationMetadata.ColumnNames.LastUpdateByUserID, value);
            }
        }

        /// <summary>
        /// Maps to Registration.isDirectPrescriptionReturn
        /// </summary>
        virtual public System.Boolean? IsDirectPrescriptionReturn
        {
            get
            {
                return base.GetSystemBoolean(RegistrationMetadata.ColumnNames.IsDirectPrescriptionReturn);
            }

            set
            {
                base.SetSystemBoolean(RegistrationMetadata.ColumnNames.IsDirectPrescriptionReturn, value);
            }
        }

        /// <summary>
        /// Maps to Registration.VisiteRegistrationNo
        /// </summary>
        virtual public System.String VisiteRegistrationNo
        {
            get
            {
                return base.GetSystemString(RegistrationMetadata.ColumnNames.VisiteRegistrationNo);
            }

            set
            {
                base.SetSystemString(RegistrationMetadata.ColumnNames.VisiteRegistrationNo, value);
            }
        }

        /// <summary>
        /// Maps to Registration.RegistrationQue
        /// </summary>
        virtual public System.Int32? RegistrationQue
        {
            get
            {
                return base.GetSystemInt32(RegistrationMetadata.ColumnNames.RegistrationQue);
            }

            set
            {
                base.SetSystemInt32(RegistrationMetadata.ColumnNames.RegistrationQue, value);
            }
        }

        /// <summary>
        /// Maps to Registration.ReferralIDTo
        /// </summary>
        virtual public System.String ReferralIDTo
        {
            get
            {
                return base.GetSystemString(RegistrationMetadata.ColumnNames.ReferralIDTo);
            }

            set
            {
                base.SetSystemString(RegistrationMetadata.ColumnNames.ReferralIDTo, value);
            }
        }

        /// <summary>
        /// Maps to Registration.SEPNo
        /// </summary>
        virtual public System.String SEPNo
        {
            get
            {
                return base.GetSystemString(RegistrationMetadata.ColumnNames.SEPNo);
            }

            set
            {
                base.SetSystemString(RegistrationMetadata.ColumnNames.SEPNo, value);
            }
        }

        /// <summary>
        /// Maps to Registration.JasindoNo
        /// </summary>
        virtual public System.String JasindoNo
        {
            get
            {
                return base.GetSystemString(RegistrationMetadata.ColumnNames.JasindoNo);
            }

            set
            {
                base.SetSystemString(RegistrationMetadata.ColumnNames.JasindoNo, value);
            }
        }

        #endregion

        #region String Properties


        [BrowsableAttribute(false)]
        public esStrings str
        {
            get
            {
                if (esstrings == null)
                {
                    esstrings = new esStrings(this);
                }
                return esstrings;
            }
        }


        [Serializable]
        sealed public class esStrings
        {
            public esStrings(esRegistration entity)
            {
                this.entity = entity;
            }


            public System.String RegistrationNo
            {
                get
                {
                    System.String data = entity.RegistrationNo;
                    return (data == null) ? String.Empty : Convert.ToString(data);
                }

                set
                {
                    if (value == null || value.Length == 0) entity.RegistrationNo = null;
                    else entity.RegistrationNo = Convert.ToString(value);
                }
            }

            public System.String SRRegistrationType
            {
                get
                {
                    System.String data = entity.SRRegistrationType;
                    return (data == null) ? String.Empty : Convert.ToString(data);
                }

                set
                {
                    if (value == null || value.Length == 0) entity.SRRegistrationType = null;
                    else entity.SRRegistrationType = Convert.ToString(value);
                }
            }

            public System.String ParamedicID
            {
                get
                {
                    System.String data = entity.ParamedicID;
                    return (data == null) ? String.Empty : Convert.ToString(data);
                }

                set
                {
                    if (value == null || value.Length == 0) entity.ParamedicID = null;
                    else entity.ParamedicID = Convert.ToString(value);
                }
            }

            public System.String GuarantorID
            {
                get
                {
                    System.String data = entity.GuarantorID;
                    return (data == null) ? String.Empty : Convert.ToString(data);
                }

                set
                {
                    if (value == null || value.Length == 0) entity.GuarantorID = null;
                    else entity.GuarantorID = Convert.ToString(value);
                }
            }

            public System.String PatientID
            {
                get
                {
                    System.String data = entity.PatientID;
                    return (data == null) ? String.Empty : Convert.ToString(data);
                }

                set
                {
                    if (value == null || value.Length == 0) entity.PatientID = null;
                    else entity.PatientID = Convert.ToString(value);
                }
            }

            public System.String ClassID
            {
                get
                {
                    System.String data = entity.ClassID;
                    return (data == null) ? String.Empty : Convert.ToString(data);
                }

                set
                {
                    if (value == null || value.Length == 0) entity.ClassID = null;
                    else entity.ClassID = Convert.ToString(value);
                }
            }

            public System.String RegistrationDate
            {
                get
                {
                    System.DateTime? data = entity.RegistrationDate;
                    return (data == null) ? String.Empty : Convert.ToString(data);
                }

                set
                {
                    if (value == null || value.Length == 0) entity.RegistrationDate = null;
                    else entity.RegistrationDate = Convert.ToDateTime(value);
                }
            }

            public System.String RegistrationTime
            {
                get
                {
                    System.String data = entity.RegistrationTime;
                    return (data == null) ? String.Empty : Convert.ToString(data);
                }

                set
                {
                    if (value == null || value.Length == 0) entity.RegistrationTime = null;
                    else entity.RegistrationTime = Convert.ToString(value);
                }
            }

            public System.String AppointmentNo
            {
                get
                {
                    System.String data = entity.AppointmentNo;
                    return (data == null) ? String.Empty : Convert.ToString(data);
                }

                set
                {
                    if (value == null || value.Length == 0) entity.AppointmentNo = null;
                    else entity.AppointmentNo = Convert.ToString(value);
                }
            }

            public System.String AgeInYear
            {
                get
                {
                    System.Byte? data = entity.AgeInYear;
                    return (data == null) ? String.Empty : Convert.ToString(data);
                }

                set
                {
                    if (value == null || value.Length == 0) entity.AgeInYear = null;
                    else entity.AgeInYear = Convert.ToByte(value);
                }
            }

            public System.String AgeInMonth
            {
                get
                {
                    System.Byte? data = entity.AgeInMonth;
                    return (data == null) ? String.Empty : Convert.ToString(data);
                }

                set
                {
                    if (value == null || value.Length == 0) entity.AgeInMonth = null;
                    else entity.AgeInMonth = Convert.ToByte(value);
                }
            }

            public System.String AgeInDay
            {
                get
                {
                    System.Byte? data = entity.AgeInDay;
                    return (data == null) ? String.Empty : Convert.ToString(data);
                }

                set
                {
                    if (value == null || value.Length == 0) entity.AgeInDay = null;
                    else entity.AgeInDay = Convert.ToByte(value);
                }
            }

            public System.String SRShift
            {
                get
                {
                    System.String data = entity.SRShift;
                    return (data == null) ? String.Empty : Convert.ToString(data);
                }

                set
                {
                    if (value == null || value.Length == 0) entity.SRShift = null;
                    else entity.SRShift = Convert.ToString(value);
                }
            }

            public System.String SRPatientInType
            {
                get
                {
                    System.String data = entity.SRPatientInType;
                    return (data == null) ? String.Empty : Convert.ToString(data);
                }

                set
                {
                    if (value == null || value.Length == 0) entity.SRPatientInType = null;
                    else entity.SRPatientInType = Convert.ToString(value);
                }
            }

            public System.String InsuranceID
            {
                get
                {
                    System.String data = entity.InsuranceID;
                    return (data == null) ? String.Empty : Convert.ToString(data);
                }

                set
                {
                    if (value == null || value.Length == 0) entity.InsuranceID = null;
                    else entity.InsuranceID = Convert.ToString(value);
                }
            }

            public System.String SRPatientCategory
            {
                get
                {
                    System.String data = entity.SRPatientCategory;
                    return (data == null) ? String.Empty : Convert.ToString(data);
                }

                set
                {
                    if (value == null || value.Length == 0) entity.SRPatientCategory = null;
                    else entity.SRPatientCategory = Convert.ToString(value);
                }
            }

            public System.String SRERCaseType
            {
                get
                {
                    System.String data = entity.SRERCaseType;
                    return (data == null) ? String.Empty : Convert.ToString(data);
                }

                set
                {
                    if (value == null || value.Length == 0) entity.SRERCaseType = null;
                    else entity.SRERCaseType = Convert.ToString(value);
                }
            }

            public System.String SRVisitReason
            {
                get
                {
                    System.String data = entity.SRVisitReason;
                    return (data == null) ? String.Empty : Convert.ToString(data);
                }

                set
                {
                    if (value == null || value.Length == 0) entity.SRVisitReason = null;
                    else entity.SRVisitReason = Convert.ToString(value);
                }
            }

            public System.String SRBussinesMethod
            {
                get
                {
                    System.String data = entity.SRBussinesMethod;
                    return (data == null) ? String.Empty : Convert.ToString(data);
                }

                set
                {
                    if (value == null || value.Length == 0) entity.SRBussinesMethod = null;
                    else entity.SRBussinesMethod = Convert.ToString(value);
                }
            }

            public System.String PlavonAmount
            {
                get
                {
                    System.Decimal? data = entity.PlavonAmount;
                    return (data == null) ? String.Empty : Convert.ToString(data);
                }

                set
                {
                    if (value == null || value.Length == 0) entity.PlavonAmount = null;
                    else entity.PlavonAmount = Convert.ToDecimal(value);
                }
            }

            public System.String DepartmentID
            {
                get
                {
                    System.String data = entity.DepartmentID;
                    return (data == null) ? String.Empty : Convert.ToString(data);
                }

                set
                {
                    if (value == null || value.Length == 0) entity.DepartmentID = null;
                    else entity.DepartmentID = Convert.ToString(value);
                }
            }

            public System.String ServiceUnitID
            {
                get
                {
                    System.String data = entity.ServiceUnitID;
                    return (data == null) ? String.Empty : Convert.ToString(data);
                }

                set
                {
                    if (value == null || value.Length == 0) entity.ServiceUnitID = null;
                    else entity.ServiceUnitID = Convert.ToString(value);
                }
            }

            public System.String RoomID
            {
                get
                {
                    System.String data = entity.RoomID;
                    return (data == null) ? String.Empty : Convert.ToString(data);
                }

                set
                {
                    if (value == null || value.Length == 0) entity.RoomID = null;
                    else entity.RoomID = Convert.ToString(value);
                }
            }

            public System.String BedID
            {
                get
                {
                    System.String data = entity.BedID;
                    return (data == null) ? String.Empty : Convert.ToString(data);
                }

                set
                {
                    if (value == null || value.Length == 0) entity.BedID = null;
                    else entity.BedID = Convert.ToString(value);
                }
            }

            public System.String ChargeClassID
            {
                get
                {
                    System.String data = entity.ChargeClassID;
                    return (data == null) ? String.Empty : Convert.ToString(data);
                }

                set
                {
                    if (value == null || value.Length == 0) entity.ChargeClassID = null;
                    else entity.ChargeClassID = Convert.ToString(value);
                }
            }

            public System.String CoverageClassID
            {
                get
                {
                    System.String data = entity.CoverageClassID;
                    return (data == null) ? String.Empty : Convert.ToString(data);
                }

                set
                {
                    if (value == null || value.Length == 0) entity.CoverageClassID = null;
                    else entity.CoverageClassID = Convert.ToString(value);
                }
            }

            public System.String VisitTypeID
            {
                get
                {
                    System.String data = entity.VisitTypeID;
                    return (data == null) ? String.Empty : Convert.ToString(data);
                }

                set
                {
                    if (value == null || value.Length == 0) entity.VisitTypeID = null;
                    else entity.VisitTypeID = Convert.ToString(value);
                }
            }

            public System.String ReferralID
            {
                get
                {
                    System.String data = entity.ReferralID;
                    return (data == null) ? String.Empty : Convert.ToString(data);
                }

                set
                {
                    if (value == null || value.Length == 0) entity.ReferralID = null;
                    else entity.ReferralID = Convert.ToString(value);
                }
            }

            public System.String Anamnesis
            {
                get
                {
                    System.String data = entity.Anamnesis;
                    return (data == null) ? String.Empty : Convert.ToString(data);
                }

                set
                {
                    if (value == null || value.Length == 0) entity.Anamnesis = null;
                    else entity.Anamnesis = Convert.ToString(value);
                }
            }

            public System.String Complaint
            {
                get
                {
                    System.String data = entity.Complaint;
                    return (data == null) ? String.Empty : Convert.ToString(data);
                }

                set
                {
                    if (value == null || value.Length == 0) entity.Complaint = null;
                    else entity.Complaint = Convert.ToString(value);
                }
            }

            public System.String InitialDiagnose
            {
                get
                {
                    System.String data = entity.InitialDiagnose;
                    return (data == null) ? String.Empty : Convert.ToString(data);
                }

                set
                {
                    if (value == null || value.Length == 0) entity.InitialDiagnose = null;
                    else entity.InitialDiagnose = Convert.ToString(value);
                }
            }

            public System.String MedicationPlanning
            {
                get
                {
                    System.String data = entity.MedicationPlanning;
                    return (data == null) ? String.Empty : Convert.ToString(data);
                }

                set
                {
                    if (value == null || value.Length == 0) entity.MedicationPlanning = null;
                    else entity.MedicationPlanning = Convert.ToString(value);
                }
            }

            public System.String SRTriage
            {
                get
                {
                    System.String data = entity.SRTriage;
                    return (data == null) ? String.Empty : Convert.ToString(data);
                }

                set
                {
                    if (value == null || value.Length == 0) entity.SRTriage = null;
                    else entity.SRTriage = Convert.ToString(value);
                }
            }

            public System.String IsPrintingPatientCard
            {
                get
                {
                    System.Boolean? data = entity.IsPrintingPatientCard;
                    return (data == null) ? String.Empty : Convert.ToString(data);
                }

                set
                {
                    if (value == null || value.Length == 0) entity.IsPrintingPatientCard = null;
                    else entity.IsPrintingPatientCard = Convert.ToBoolean(value);
                }
            }

            public System.String DischargeDate
            {
                get
                {
                    System.DateTime? data = entity.DischargeDate;
                    return (data == null) ? String.Empty : Convert.ToString(data);
                }

                set
                {
                    if (value == null || value.Length == 0) entity.DischargeDate = null;
                    else entity.DischargeDate = Convert.ToDateTime(value);
                }
            }

            public System.String DischargeTime
            {
                get
                {
                    System.String data = entity.DischargeTime;
                    return (data == null) ? String.Empty : Convert.ToString(data);
                }

                set
                {
                    if (value == null || value.Length == 0) entity.DischargeTime = null;
                    else entity.DischargeTime = Convert.ToString(value);
                }
            }

            public System.String DischargeMedicalNotes
            {
                get
                {
                    System.String data = entity.DischargeMedicalNotes;
                    return (data == null) ? String.Empty : Convert.ToString(data);
                }

                set
                {
                    if (value == null || value.Length == 0) entity.DischargeMedicalNotes = null;
                    else entity.DischargeMedicalNotes = Convert.ToString(value);
                }
            }

            public System.String DischargeNotes
            {
                get
                {
                    System.String data = entity.DischargeNotes;
                    return (data == null) ? String.Empty : Convert.ToString(data);
                }

                set
                {
                    if (value == null || value.Length == 0) entity.DischargeNotes = null;
                    else entity.DischargeNotes = Convert.ToString(value);
                }
            }

            public System.String SRDischargeCondition
            {
                get
                {
                    System.String data = entity.SRDischargeCondition;
                    return (data == null) ? String.Empty : Convert.ToString(data);
                }

                set
                {
                    if (value == null || value.Length == 0) entity.SRDischargeCondition = null;
                    else entity.SRDischargeCondition = Convert.ToString(value);
                }
            }

            public System.String SRDischargeMethod
            {
                get
                {
                    System.String data = entity.SRDischargeMethod;
                    return (data == null) ? String.Empty : Convert.ToString(data);
                }

                set
                {
                    if (value == null || value.Length == 0) entity.SRDischargeMethod = null;
                    else entity.SRDischargeMethod = Convert.ToString(value);
                }
            }

            public System.String LOSInYear
            {
                get
                {
                    System.Byte? data = entity.LOSInYear;
                    return (data == null) ? String.Empty : Convert.ToString(data);
                }

                set
                {
                    if (value == null || value.Length == 0) entity.LOSInYear = null;
                    else entity.LOSInYear = Convert.ToByte(value);
                }
            }

            public System.String LOSInMonth
            {
                get
                {
                    System.Byte? data = entity.LOSInMonth;
                    return (data == null) ? String.Empty : Convert.ToString(data);
                }

                set
                {
                    if (value == null || value.Length == 0) entity.LOSInMonth = null;
                    else entity.LOSInMonth = Convert.ToByte(value);
                }
            }

            public System.String LOSInDay
            {
                get
                {
                    System.Byte? data = entity.LOSInDay;
                    return (data == null) ? String.Empty : Convert.ToString(data);
                }

                set
                {
                    if (value == null || value.Length == 0) entity.LOSInDay = null;
                    else entity.LOSInDay = Convert.ToByte(value);
                }
            }

            public System.String DischargeOperatorID
            {
                get
                {
                    System.String data = entity.DischargeOperatorID;
                    return (data == null) ? String.Empty : Convert.ToString(data);
                }

                set
                {
                    if (value == null || value.Length == 0) entity.DischargeOperatorID = null;
                    else entity.DischargeOperatorID = Convert.ToString(value);
                }
            }

            public System.String AccountNo
            {
                get
                {
                    System.String data = entity.AccountNo;
                    return (data == null) ? String.Empty : Convert.ToString(data);
                }

                set
                {
                    if (value == null || value.Length == 0) entity.AccountNo = null;
                    else entity.AccountNo = Convert.ToString(value);
                }
            }

            public System.String TransactionAmount
            {
                get
                {
                    System.Decimal? data = entity.TransactionAmount;
                    return (data == null) ? String.Empty : Convert.ToString(data);
                }

                set
                {
                    if (value == null || value.Length == 0) entity.TransactionAmount = null;
                    else entity.TransactionAmount = Convert.ToDecimal(value);
                }
            }

            public System.String AdministrationAmount
            {
                get
                {
                    System.Decimal? data = entity.AdministrationAmount;
                    return (data == null) ? String.Empty : Convert.ToString(data);
                }

                set
                {
                    if (value == null || value.Length == 0) entity.AdministrationAmount = null;
                    else entity.AdministrationAmount = Convert.ToDecimal(value);
                }
            }

            public System.String RoundingAmount
            {
                get
                {
                    System.Decimal? data = entity.RoundingAmount;
                    return (data == null) ? String.Empty : Convert.ToString(data);
                }

                set
                {
                    if (value == null || value.Length == 0) entity.RoundingAmount = null;
                    else entity.RoundingAmount = Convert.ToDecimal(value);
                }
            }

            public System.String RemainingAmount
            {
                get
                {
                    System.Decimal? data = entity.RemainingAmount;
                    return (data == null) ? String.Empty : Convert.ToString(data);
                }

                set
                {
                    if (value == null || value.Length == 0) entity.RemainingAmount = null;
                    else entity.RemainingAmount = Convert.ToDecimal(value);
                }
            }

            public System.String IsTransferedToInpatient
            {
                get
                {
                    System.Boolean? data = entity.IsTransferedToInpatient;
                    return (data == null) ? String.Empty : Convert.ToString(data);
                }

                set
                {
                    if (value == null || value.Length == 0) entity.IsTransferedToInpatient = null;
                    else entity.IsTransferedToInpatient = Convert.ToBoolean(value);
                }
            }

            public System.String IsNewPatient
            {
                get
                {
                    System.Boolean? data = entity.IsNewPatient;
                    return (data == null) ? String.Empty : Convert.ToString(data);
                }

                set
                {
                    if (value == null || value.Length == 0) entity.IsNewPatient = null;
                    else entity.IsNewPatient = Convert.ToBoolean(value);
                }
            }

            public System.String IsNewBornInfant
            {
                get
                {
                    System.Boolean? data = entity.IsNewBornInfant;
                    return (data == null) ? String.Empty : Convert.ToString(data);
                }

                set
                {
                    if (value == null || value.Length == 0) entity.IsNewBornInfant = null;
                    else entity.IsNewBornInfant = Convert.ToBoolean(value);
                }
            }

            public System.String IsParturition
            {
                get
                {
                    System.Boolean? data = entity.IsParturition;
                    return (data == null) ? String.Empty : Convert.ToString(data);
                }

                set
                {
                    if (value == null || value.Length == 0) entity.IsParturition = null;
                    else entity.IsParturition = Convert.ToBoolean(value);
                }
            }

            public System.String IsHoldTransactionEntry
            {
                get
                {
                    System.Boolean? data = entity.IsHoldTransactionEntry;
                    return (data == null) ? String.Empty : Convert.ToString(data);
                }

                set
                {
                    if (value == null || value.Length == 0) entity.IsHoldTransactionEntry = null;
                    else entity.IsHoldTransactionEntry = Convert.ToBoolean(value);
                }
            }

            public System.String IsHasCorrection
            {
                get
                {
                    System.Boolean? data = entity.IsHasCorrection;
                    return (data == null) ? String.Empty : Convert.ToString(data);
                }

                set
                {
                    if (value == null || value.Length == 0) entity.IsHasCorrection = null;
                    else entity.IsHasCorrection = Convert.ToBoolean(value);
                }
            }

            public System.String IsEMRValid
            {
                get
                {
                    System.Boolean? data = entity.IsEMRValid;
                    return (data == null) ? String.Empty : Convert.ToString(data);
                }

                set
                {
                    if (value == null || value.Length == 0) entity.IsEMRValid = null;
                    else entity.IsEMRValid = Convert.ToBoolean(value);
                }
            }

            public System.String IsBackDate
            {
                get
                {
                    System.Boolean? data = entity.IsBackDate;
                    return (data == null) ? String.Empty : Convert.ToString(data);
                }

                set
                {
                    if (value == null || value.Length == 0) entity.IsBackDate = null;
                    else entity.IsBackDate = Convert.ToBoolean(value);
                }
            }

            public System.String ActualVisitDate
            {
                get
                {
                    System.DateTime? data = entity.ActualVisitDate;
                    return (data == null) ? String.Empty : Convert.ToString(data);
                }

                set
                {
                    if (value == null || value.Length == 0) entity.ActualVisitDate = null;
                    else entity.ActualVisitDate = Convert.ToDateTime(value);
                }
            }

            public System.String IsVoid
            {
                get
                {
                    System.Boolean? data = entity.IsVoid;
                    return (data == null) ? String.Empty : Convert.ToString(data);
                }

                set
                {
                    if (value == null || value.Length == 0) entity.IsVoid = null;
                    else entity.IsVoid = Convert.ToBoolean(value);
                }
            }

            public System.String SRVoidReason
            {
                get
                {
                    System.String data = entity.SRVoidReason;
                    return (data == null) ? String.Empty : Convert.ToString(data);
                }

                set
                {
                    if (value == null || value.Length == 0) entity.SRVoidReason = null;
                    else entity.SRVoidReason = Convert.ToString(value);
                }
            }

            public System.String VoidNotes
            {
                get
                {
                    System.String data = entity.VoidNotes;
                    return (data == null) ? String.Empty : Convert.ToString(data);
                }

                set
                {
                    if (value == null || value.Length == 0) entity.VoidNotes = null;
                    else entity.VoidNotes = Convert.ToString(value);
                }
            }

            public System.String VoidDate
            {
                get
                {
                    System.DateTime? data = entity.VoidDate;
                    return (data == null) ? String.Empty : Convert.ToString(data);
                }

                set
                {
                    if (value == null || value.Length == 0) entity.VoidDate = null;
                    else entity.VoidDate = Convert.ToDateTime(value);
                }
            }

            public System.String VoidByUserID
            {
                get
                {
                    System.String data = entity.VoidByUserID;
                    return (data == null) ? String.Empty : Convert.ToString(data);
                }

                set
                {
                    if (value == null || value.Length == 0) entity.VoidByUserID = null;
                    else entity.VoidByUserID = Convert.ToString(value);
                }
            }

            public System.String IsClosed
            {
                get
                {
                    System.Boolean? data = entity.IsClosed;
                    return (data == null) ? String.Empty : Convert.ToString(data);
                }

                set
                {
                    if (value == null || value.Length == 0) entity.IsClosed = null;
                    else entity.IsClosed = Convert.ToBoolean(value);
                }
            }

            public System.String IsEpisodeComplete
            {
                get
                {
                    System.Boolean? data = entity.IsEpisodeComplete;
                    return (data == null) ? String.Empty : Convert.ToString(data);
                }

                set
                {
                    if (value == null || value.Length == 0) entity.IsEpisodeComplete = null;
                    else entity.IsEpisodeComplete = Convert.ToBoolean(value);
                }
            }

            public System.String IsClusterAssessment
            {
                get
                {
                    System.Boolean? data = entity.IsClusterAssessment;
                    return (data == null) ? String.Empty : Convert.ToString(data);
                }

                set
                {
                    if (value == null || value.Length == 0) entity.IsClusterAssessment = null;
                    else entity.IsClusterAssessment = Convert.ToBoolean(value);
                }
            }

            public System.String IsConsul
            {
                get
                {
                    System.Boolean? data = entity.IsConsul;
                    return (data == null) ? String.Empty : Convert.ToString(data);
                }

                set
                {
                    if (value == null || value.Length == 0) entity.IsConsul = null;
                    else entity.IsConsul = Convert.ToBoolean(value);
                }
            }

            public System.String IsFromDispensary
            {
                get
                {
                    System.Boolean? data = entity.IsFromDispensary;
                    return (data == null) ? String.Empty : Convert.ToString(data);
                }

                set
                {
                    if (value == null || value.Length == 0) entity.IsFromDispensary = null;
                    else entity.IsFromDispensary = Convert.ToBoolean(value);
                }
            }

            public System.String IsNewVisit
            {
                get
                {
                    System.Boolean? data = entity.IsNewVisit;
                    return (data == null) ? String.Empty : Convert.ToString(data);
                }

                set
                {
                    if (value == null || value.Length == 0) entity.IsNewVisit = null;
                    else entity.IsNewVisit = Convert.ToBoolean(value);
                }
            }

            public System.String Notes
            {
                get
                {
                    System.String data = entity.Notes;
                    return (data == null) ? String.Empty : Convert.ToString(data);
                }

                set
                {
                    if (value == null || value.Length == 0) entity.Notes = null;
                    else entity.Notes = Convert.ToString(value);
                }
            }

            public System.String LastCreateDateTime
            {
                get
                {
                    System.DateTime? data = entity.LastCreateDateTime;
                    return (data == null) ? String.Empty : Convert.ToString(data);
                }

                set
                {
                    if (value == null || value.Length == 0) entity.LastCreateDateTime = null;
                    else entity.LastCreateDateTime = Convert.ToDateTime(value);
                }
            }

            public System.String LastCreateUserID
            {
                get
                {
                    System.String data = entity.LastCreateUserID;
                    return (data == null) ? String.Empty : Convert.ToString(data);
                }

                set
                {
                    if (value == null || value.Length == 0) entity.LastCreateUserID = null;
                    else entity.LastCreateUserID = Convert.ToString(value);
                }
            }

            public System.String LastUpdateDateTime
            {
                get
                {
                    System.DateTime? data = entity.LastUpdateDateTime;
                    return (data == null) ? String.Empty : Convert.ToString(data);
                }

                set
                {
                    if (value == null || value.Length == 0) entity.LastUpdateDateTime = null;
                    else entity.LastUpdateDateTime = Convert.ToDateTime(value);
                }
            }

            public System.String LastUpdateByUserID
            {
                get
                {
                    System.String data = entity.LastUpdateByUserID;
                    return (data == null) ? String.Empty : Convert.ToString(data);
                }

                set
                {
                    if (value == null || value.Length == 0) entity.LastUpdateByUserID = null;
                    else entity.LastUpdateByUserID = Convert.ToString(value);
                }
            }

            public System.String IsDirectPrescriptionReturn
            {
                get
                {
                    System.Boolean? data = entity.IsDirectPrescriptionReturn;
                    return (data == null) ? String.Empty : Convert.ToString(data);
                }

                set
                {
                    if (value == null || value.Length == 0) entity.IsDirectPrescriptionReturn = null;
                    else entity.IsDirectPrescriptionReturn = Convert.ToBoolean(value);
                }
            }

            public System.String VisiteRegistrationNo
            {
                get
                {
                    System.String data = entity.VisiteRegistrationNo;
                    return (data == null) ? String.Empty : Convert.ToString(data);
                }

                set
                {
                    if (value == null || value.Length == 0) entity.VisiteRegistrationNo = null;
                    else entity.VisiteRegistrationNo = Convert.ToString(value);
                }
            }

            public System.String RegistrationQue
            {
                get
                {
                    System.Int32? data = entity.RegistrationQue;
                    return (data == null) ? String.Empty : Convert.ToString(data);
                }

                set
                {
                    if (value == null || value.Length == 0) entity.RegistrationQue = null;
                    else entity.RegistrationQue = Convert.ToInt32(value);
                }
            }

            public System.String ReferralIDTo
            {
                get
                {
                    System.String data = entity.ReferralIDTo;
                    return (data == null) ? String.Empty : Convert.ToString(data);
                }

                set
                {
                    if (value == null || value.Length == 0) entity.ReferralIDTo = null;
                    else entity.ReferralIDTo = Convert.ToString(value);
                }
            }

            public System.String SEPNo
            {
                get
                {
                    System.String data = entity.SEPNo;
                    return (data == null) ? String.Empty : Convert.ToString(data);
                }

                set
                {
                    if (value == null || value.Length == 0) entity.SEPNo = null;
                    else entity.SEPNo = Convert.ToString(value);
                }
            }

            public System.String JasindoNo
            {
                get
                {
                    System.String data = entity.JasindoNo;
                    return (data == null) ? String.Empty : Convert.ToString(data);
                }

                set
                {
                    if (value == null || value.Length == 0) entity.JasindoNo = null;
                    else entity.JasindoNo = Convert.ToString(value);
                }
            }


            private esRegistration entity;
        }
        #endregion

        #region Query Logic
        protected void InitQuery(esRegistrationQuery query)
        {
            query.OnLoadDelegate = this.OnQueryLoaded;
            query.es2.Connection = ((IEntity)this).Connection;
        }

        [System.Diagnostics.DebuggerNonUserCode]
        protected bool OnQueryLoaded(DataTable table)
        {
            bool dataFound = this.PopulateEntity(table);

            if (this.RowCount > 1)
            {
                throw new Exception("esRegistration can only hold one record of data");
            }

            return dataFound;
        }
        #endregion

        [NonSerialized]
        private esStrings esstrings;
    }



    [Serializable]
    abstract public class esRegistrationQuery : esDynamicQuery
    {
        override protected IMetadata Meta
        {
            get
            {
                return RegistrationMetadata.Meta();
            }
        }


        public esQueryItem RegistrationNo
        {
            get
            {
                return new esQueryItem(this, RegistrationMetadata.ColumnNames.RegistrationNo, esSystemType.String);
            }
        }

        public esQueryItem SRRegistrationType
        {
            get
            {
                return new esQueryItem(this, RegistrationMetadata.ColumnNames.SRRegistrationType, esSystemType.String);
            }
        }

        public esQueryItem ParamedicID
        {
            get
            {
                return new esQueryItem(this, RegistrationMetadata.ColumnNames.ParamedicID, esSystemType.String);
            }
        }

        public esQueryItem GuarantorID
        {
            get
            {
                return new esQueryItem(this, RegistrationMetadata.ColumnNames.GuarantorID, esSystemType.String);
            }
        }

        public esQueryItem PatientID
        {
            get
            {
                return new esQueryItem(this, RegistrationMetadata.ColumnNames.PatientID, esSystemType.String);
            }
        }

        public esQueryItem ClassID
        {
            get
            {
                return new esQueryItem(this, RegistrationMetadata.ColumnNames.ClassID, esSystemType.String);
            }
        }

        public esQueryItem RegistrationDate
        {
            get
            {
                return new esQueryItem(this, RegistrationMetadata.ColumnNames.RegistrationDate, esSystemType.DateTime);
            }
        }

        public esQueryItem RegistrationTime
        {
            get
            {
                return new esQueryItem(this, RegistrationMetadata.ColumnNames.RegistrationTime, esSystemType.String);
            }
        }

        public esQueryItem AppointmentNo
        {
            get
            {
                return new esQueryItem(this, RegistrationMetadata.ColumnNames.AppointmentNo, esSystemType.String);
            }
        }

        public esQueryItem AgeInYear
        {
            get
            {
                return new esQueryItem(this, RegistrationMetadata.ColumnNames.AgeInYear, esSystemType.Byte);
            }
        }

        public esQueryItem AgeInMonth
        {
            get
            {
                return new esQueryItem(this, RegistrationMetadata.ColumnNames.AgeInMonth, esSystemType.Byte);
            }
        }

        public esQueryItem AgeInDay
        {
            get
            {
                return new esQueryItem(this, RegistrationMetadata.ColumnNames.AgeInDay, esSystemType.Byte);
            }
        }

        public esQueryItem SRShift
        {
            get
            {
                return new esQueryItem(this, RegistrationMetadata.ColumnNames.SRShift, esSystemType.String);
            }
        }

        public esQueryItem SRPatientInType
        {
            get
            {
                return new esQueryItem(this, RegistrationMetadata.ColumnNames.SRPatientInType, esSystemType.String);
            }
        }

        public esQueryItem InsuranceID
        {
            get
            {
                return new esQueryItem(this, RegistrationMetadata.ColumnNames.InsuranceID, esSystemType.String);
            }
        }

        public esQueryItem SRPatientCategory
        {
            get
            {
                return new esQueryItem(this, RegistrationMetadata.ColumnNames.SRPatientCategory, esSystemType.String);
            }
        }

        public esQueryItem SRERCaseType
        {
            get
            {
                return new esQueryItem(this, RegistrationMetadata.ColumnNames.SRERCaseType, esSystemType.String);
            }
        }

        public esQueryItem SRVisitReason
        {
            get
            {
                return new esQueryItem(this, RegistrationMetadata.ColumnNames.SRVisitReason, esSystemType.String);
            }
        }

        public esQueryItem SRBussinesMethod
        {
            get
            {
                return new esQueryItem(this, RegistrationMetadata.ColumnNames.SRBussinesMethod, esSystemType.String);
            }
        }

        public esQueryItem PlavonAmount
        {
            get
            {
                return new esQueryItem(this, RegistrationMetadata.ColumnNames.PlavonAmount, esSystemType.Decimal);
            }
        }

        public esQueryItem DepartmentID
        {
            get
            {
                return new esQueryItem(this, RegistrationMetadata.ColumnNames.DepartmentID, esSystemType.String);
            }
        }

        public esQueryItem ServiceUnitID
        {
            get
            {
                return new esQueryItem(this, RegistrationMetadata.ColumnNames.ServiceUnitID, esSystemType.String);
            }
        }

        public esQueryItem RoomID
        {
            get
            {
                return new esQueryItem(this, RegistrationMetadata.ColumnNames.RoomID, esSystemType.String);
            }
        }

        public esQueryItem BedID
        {
            get
            {
                return new esQueryItem(this, RegistrationMetadata.ColumnNames.BedID, esSystemType.String);
            }
        }

        public esQueryItem ChargeClassID
        {
            get
            {
                return new esQueryItem(this, RegistrationMetadata.ColumnNames.ChargeClassID, esSystemType.String);
            }
        }

        public esQueryItem CoverageClassID
        {
            get
            {
                return new esQueryItem(this, RegistrationMetadata.ColumnNames.CoverageClassID, esSystemType.String);
            }
        }

        public esQueryItem VisitTypeID
        {
            get
            {
                return new esQueryItem(this, RegistrationMetadata.ColumnNames.VisitTypeID, esSystemType.String);
            }
        }

        public esQueryItem ReferralID
        {
            get
            {
                return new esQueryItem(this, RegistrationMetadata.ColumnNames.ReferralID, esSystemType.String);
            }
        }

        public esQueryItem Anamnesis
        {
            get
            {
                return new esQueryItem(this, RegistrationMetadata.ColumnNames.Anamnesis, esSystemType.String);
            }
        }

        public esQueryItem Complaint
        {
            get
            {
                return new esQueryItem(this, RegistrationMetadata.ColumnNames.Complaint, esSystemType.String);
            }
        }

        public esQueryItem InitialDiagnose
        {
            get
            {
                return new esQueryItem(this, RegistrationMetadata.ColumnNames.InitialDiagnose, esSystemType.String);
            }
        }

        public esQueryItem MedicationPlanning
        {
            get
            {
                return new esQueryItem(this, RegistrationMetadata.ColumnNames.MedicationPlanning, esSystemType.String);
            }
        }

        public esQueryItem SRTriage
        {
            get
            {
                return new esQueryItem(this, RegistrationMetadata.ColumnNames.SRTriage, esSystemType.String);
            }
        }

        public esQueryItem IsPrintingPatientCard
        {
            get
            {
                return new esQueryItem(this, RegistrationMetadata.ColumnNames.IsPrintingPatientCard, esSystemType.Boolean);
            }
        }

        public esQueryItem DischargeDate
        {
            get
            {
                return new esQueryItem(this, RegistrationMetadata.ColumnNames.DischargeDate, esSystemType.DateTime);
            }
        }

        public esQueryItem DischargeTime
        {
            get
            {
                return new esQueryItem(this, RegistrationMetadata.ColumnNames.DischargeTime, esSystemType.String);
            }
        }

        public esQueryItem DischargeMedicalNotes
        {
            get
            {
                return new esQueryItem(this, RegistrationMetadata.ColumnNames.DischargeMedicalNotes, esSystemType.String);
            }
        }

        public esQueryItem DischargeNotes
        {
            get
            {
                return new esQueryItem(this, RegistrationMetadata.ColumnNames.DischargeNotes, esSystemType.String);
            }
        }

        public esQueryItem SRDischargeCondition
        {
            get
            {
                return new esQueryItem(this, RegistrationMetadata.ColumnNames.SRDischargeCondition, esSystemType.String);
            }
        }

        public esQueryItem SRDischargeMethod
        {
            get
            {
                return new esQueryItem(this, RegistrationMetadata.ColumnNames.SRDischargeMethod, esSystemType.String);
            }
        }

        public esQueryItem LOSInYear
        {
            get
            {
                return new esQueryItem(this, RegistrationMetadata.ColumnNames.LOSInYear, esSystemType.Byte);
            }
        }

        public esQueryItem LOSInMonth
        {
            get
            {
                return new esQueryItem(this, RegistrationMetadata.ColumnNames.LOSInMonth, esSystemType.Byte);
            }
        }

        public esQueryItem LOSInDay
        {
            get
            {
                return new esQueryItem(this, RegistrationMetadata.ColumnNames.LOSInDay, esSystemType.Byte);
            }
        }

        public esQueryItem DischargeOperatorID
        {
            get
            {
                return new esQueryItem(this, RegistrationMetadata.ColumnNames.DischargeOperatorID, esSystemType.String);
            }
        }

        public esQueryItem AccountNo
        {
            get
            {
                return new esQueryItem(this, RegistrationMetadata.ColumnNames.AccountNo, esSystemType.String);
            }
        }

        public esQueryItem TransactionAmount
        {
            get
            {
                return new esQueryItem(this, RegistrationMetadata.ColumnNames.TransactionAmount, esSystemType.Decimal);
            }
        }

        public esQueryItem AdministrationAmount
        {
            get
            {
                return new esQueryItem(this, RegistrationMetadata.ColumnNames.AdministrationAmount, esSystemType.Decimal);
            }
        }

        public esQueryItem RoundingAmount
        {
            get
            {
                return new esQueryItem(this, RegistrationMetadata.ColumnNames.RoundingAmount, esSystemType.Decimal);
            }
        }

        public esQueryItem RemainingAmount
        {
            get
            {
                return new esQueryItem(this, RegistrationMetadata.ColumnNames.RemainingAmount, esSystemType.Decimal);
            }
        }

        public esQueryItem IsTransferedToInpatient
        {
            get
            {
                return new esQueryItem(this, RegistrationMetadata.ColumnNames.IsTransferedToInpatient, esSystemType.Boolean);
            }
        }

        public esQueryItem IsNewPatient
        {
            get
            {
                return new esQueryItem(this, RegistrationMetadata.ColumnNames.IsNewPatient, esSystemType.Boolean);
            }
        }

        public esQueryItem IsNewBornInfant
        {
            get
            {
                return new esQueryItem(this, RegistrationMetadata.ColumnNames.IsNewBornInfant, esSystemType.Boolean);
            }
        }

        public esQueryItem IsParturition
        {
            get
            {
                return new esQueryItem(this, RegistrationMetadata.ColumnNames.IsParturition, esSystemType.Boolean);
            }
        }

        public esQueryItem IsHoldTransactionEntry
        {
            get
            {
                return new esQueryItem(this, RegistrationMetadata.ColumnNames.IsHoldTransactionEntry, esSystemType.Boolean);
            }
        }

        public esQueryItem IsHasCorrection
        {
            get
            {
                return new esQueryItem(this, RegistrationMetadata.ColumnNames.IsHasCorrection, esSystemType.Boolean);
            }
        }

        public esQueryItem IsEMRValid
        {
            get
            {
                return new esQueryItem(this, RegistrationMetadata.ColumnNames.IsEMRValid, esSystemType.Boolean);
            }
        }

        public esQueryItem IsBackDate
        {
            get
            {
                return new esQueryItem(this, RegistrationMetadata.ColumnNames.IsBackDate, esSystemType.Boolean);
            }
        }

        public esQueryItem ActualVisitDate
        {
            get
            {
                return new esQueryItem(this, RegistrationMetadata.ColumnNames.ActualVisitDate, esSystemType.DateTime);
            }
        }

        public esQueryItem IsVoid
        {
            get
            {
                return new esQueryItem(this, RegistrationMetadata.ColumnNames.IsVoid, esSystemType.Boolean);
            }
        }

        public esQueryItem SRVoidReason
        {
            get
            {
                return new esQueryItem(this, RegistrationMetadata.ColumnNames.SRVoidReason, esSystemType.String);
            }
        }

        public esQueryItem VoidNotes
        {
            get
            {
                return new esQueryItem(this, RegistrationMetadata.ColumnNames.VoidNotes, esSystemType.String);
            }
        }

        public esQueryItem VoidDate
        {
            get
            {
                return new esQueryItem(this, RegistrationMetadata.ColumnNames.VoidDate, esSystemType.DateTime);
            }
        }

        public esQueryItem VoidByUserID
        {
            get
            {
                return new esQueryItem(this, RegistrationMetadata.ColumnNames.VoidByUserID, esSystemType.String);
            }
        }

        public esQueryItem IsClosed
        {
            get
            {
                return new esQueryItem(this, RegistrationMetadata.ColumnNames.IsClosed, esSystemType.Boolean);
            }
        }

        public esQueryItem IsEpisodeComplete
        {
            get
            {
                return new esQueryItem(this, RegistrationMetadata.ColumnNames.IsEpisodeComplete, esSystemType.Boolean);
            }
        }

        public esQueryItem IsClusterAssessment
        {
            get
            {
                return new esQueryItem(this, RegistrationMetadata.ColumnNames.IsClusterAssessment, esSystemType.Boolean);
            }
        }

        public esQueryItem IsConsul
        {
            get
            {
                return new esQueryItem(this, RegistrationMetadata.ColumnNames.IsConsul, esSystemType.Boolean);
            }
        }

        public esQueryItem IsFromDispensary
        {
            get
            {
                return new esQueryItem(this, RegistrationMetadata.ColumnNames.IsFromDispensary, esSystemType.Boolean);
            }
        }

        public esQueryItem IsNewVisit
        {
            get
            {
                return new esQueryItem(this, RegistrationMetadata.ColumnNames.IsNewVisit, esSystemType.Boolean);
            }
        }

        public esQueryItem Notes
        {
            get
            {
                return new esQueryItem(this, RegistrationMetadata.ColumnNames.Notes, esSystemType.String);
            }
        }

        public esQueryItem LastCreateDateTime
        {
            get
            {
                return new esQueryItem(this, RegistrationMetadata.ColumnNames.LastCreateDateTime, esSystemType.DateTime);
            }
        }

        public esQueryItem LastCreateUserID
        {
            get
            {
                return new esQueryItem(this, RegistrationMetadata.ColumnNames.LastCreateUserID, esSystemType.String);
            }
        }

        public esQueryItem LastUpdateDateTime
        {
            get
            {
                return new esQueryItem(this, RegistrationMetadata.ColumnNames.LastUpdateDateTime, esSystemType.DateTime);
            }
        }

        public esQueryItem LastUpdateByUserID
        {
            get
            {
                return new esQueryItem(this, RegistrationMetadata.ColumnNames.LastUpdateByUserID, esSystemType.String);
            }
        }

        public esQueryItem IsDirectPrescriptionReturn
        {
            get
            {
                return new esQueryItem(this, RegistrationMetadata.ColumnNames.IsDirectPrescriptionReturn, esSystemType.Boolean);
            }
        }

        public esQueryItem VisiteRegistrationNo
        {
            get
            {
                return new esQueryItem(this, RegistrationMetadata.ColumnNames.VisiteRegistrationNo, esSystemType.String);
            }
        }

        public esQueryItem RegistrationQue
        {
            get
            {
                return new esQueryItem(this, RegistrationMetadata.ColumnNames.RegistrationQue, esSystemType.Int32);
            }
        }

        public esQueryItem ReferralIDTo
        {
            get
            {
                return new esQueryItem(this, RegistrationMetadata.ColumnNames.ReferralIDTo, esSystemType.String);
            }
        }

        public esQueryItem SEPNo
        {
            get
            {
                return new esQueryItem(this, RegistrationMetadata.ColumnNames.SEPNo, esSystemType.String);
            }
        }

        public esQueryItem JasindoNo
        {
            get
            {
                return new esQueryItem(this, RegistrationMetadata.ColumnNames.JasindoNo, esSystemType.String);
            }
        }

    }



    [System.Diagnostics.DebuggerDisplay("Count = {Count}")]
    [Serializable]
    [XmlType("RegistrationCollection")]
    public partial class RegistrationCollection : esRegistrationCollection, IEnumerable<Registration>
    {
        public RegistrationCollection()
        {

        }

        public static implicit operator List<Registration>(RegistrationCollection coll)
        {
            List<Registration> list = new List<Registration>();

            foreach (Registration emp in coll)
            {
                list.Add(emp);
            }

            return list;
        }

        #region Housekeeping methods
        override protected IMetadata Meta
        {
            get
            {
                return RegistrationMetadata.Meta();
            }
        }



        override protected esDynamicQuery GetDynamicQuery()
        {
            if (this.query == null)
            {
                this.query = new RegistrationQuery();
                this.InitQuery(query);
            }
            return this.query;
        }

        override protected esEntity CreateEntityForCollection(DataRow row)
        {
            return new Registration(row);
        }

        override protected esEntity CreateEntity()
        {
            return new Registration();
        }


        #endregion


        [BrowsableAttribute(false)]
        public RegistrationQuery Query
        {
            get
            {
                if (this.query == null)
                {
                    this.query = new RegistrationQuery();
                    base.InitQuery(this.query);
                }

                return this.query;
            }
        }

        public void QueryReset()
        {
            this.query = null;
        }

        public bool Load(RegistrationQuery query)
        {
            this.query = query;
            base.InitQuery(this.query);
            return this.Query.Load();
        }

        public Registration AddNew()
        {
            Registration entity = base.AddNewEntity() as Registration;

            return entity;
        }

        public Registration FindByPrimaryKey(System.String registrationNo)
        {
            return base.FindByPrimaryKey(registrationNo) as Registration;
        }


        #region IEnumerable<Registration> Members

        IEnumerator<Registration> IEnumerable<Registration>.GetEnumerator()
        {
            System.Collections.IEnumerable enumer = this as System.Collections.IEnumerable;
            System.Collections.IEnumerator iterator = enumer.GetEnumerator();

            while (iterator.MoveNext())
            {
                yield return iterator.Current as Registration;
            }
        }

        #endregion

        private RegistrationQuery query;
    }


    /// <summary>
    /// Encapsulates the 'Registration' table
    /// </summary>

    [System.Diagnostics.DebuggerDisplay("Registration ({RegistrationNo})")]
    [Serializable]
    public partial class Registration : esRegistration
    {
        public Registration()
        {

        }

        public Registration(DataRow row)
            : base(row)
        {

        }

        #region Housekeeping methods
        override protected IMetadata Meta
        {
            get
            {
                return RegistrationMetadata.Meta();
            }
        }



        override protected esRegistrationQuery GetDynamicQuery()
        {
            if (this.query == null)
            {
                this.query = new RegistrationQuery();
                this.InitQuery(query);
            }
            return this.query;
        }
        #endregion




        [BrowsableAttribute(false)]
        public RegistrationQuery Query
        {
            get
            {
                if (this.query == null)
                {
                    this.query = new RegistrationQuery();
                    base.InitQuery(this.query);
                }

                return this.query;
            }
        }

        public void QueryReset()
        {
            this.query = null;
        }


        public bool Load(RegistrationQuery query)
        {
            this.query = query;
            base.InitQuery(this.query);
            return this.Query.Load();
        }

        private RegistrationQuery query;
    }



    [System.Diagnostics.DebuggerDisplay("LastQuery = {es.LastQuery}")]
    [Serializable]

    public partial class RegistrationQuery : esRegistrationQuery
    {
        public RegistrationQuery()
        {

        }

        public RegistrationQuery(string joinAlias)
        {
            this.es.JoinAlias = joinAlias;
        }

        override protected string GetQueryName()
        {
            return "RegistrationQuery";
        }


    }


    [Serializable]
    public partial class RegistrationMetadata : esMetadata, IMetadata
    {
        #region Protected Constructor
        protected RegistrationMetadata()
        {
            _columns = new esColumnMetadataCollection();
            esColumnMetadata c;

            c = new esColumnMetadata(RegistrationMetadata.ColumnNames.RegistrationNo, 0, typeof(System.String), esSystemType.String);
            c.PropertyName = RegistrationMetadata.PropertyNames.RegistrationNo;
            c.IsInPrimaryKey = true;
            c.CharacterMaxLength = 20;
            c.HasDefault = true;
            c.Default = @"('')";
            _columns.Add(c);

            c = new esColumnMetadata(RegistrationMetadata.ColumnNames.SRRegistrationType, 1, typeof(System.String), esSystemType.String);
            c.PropertyName = RegistrationMetadata.PropertyNames.SRRegistrationType;
            c.CharacterMaxLength = 20;
            c.HasDefault = true;
            c.Default = @"('')";
            c.IsNullable = true;
            _columns.Add(c);

            c = new esColumnMetadata(RegistrationMetadata.ColumnNames.ParamedicID, 2, typeof(System.String), esSystemType.String);
            c.PropertyName = RegistrationMetadata.PropertyNames.ParamedicID;
            c.CharacterMaxLength = 10;
            c.HasDefault = true;
            c.Default = @"('')";
            c.IsNullable = true;
            _columns.Add(c);

            c = new esColumnMetadata(RegistrationMetadata.ColumnNames.GuarantorID, 3, typeof(System.String), esSystemType.String);
            c.PropertyName = RegistrationMetadata.PropertyNames.GuarantorID;
            c.CharacterMaxLength = 10;
            c.HasDefault = true;
            c.Default = @"('')";
            _columns.Add(c);

            c = new esColumnMetadata(RegistrationMetadata.ColumnNames.PatientID, 4, typeof(System.String), esSystemType.String);
            c.PropertyName = RegistrationMetadata.PropertyNames.PatientID;
            c.CharacterMaxLength = 15;
            c.HasDefault = true;
            c.Default = @"('')";
            _columns.Add(c);

            c = new esColumnMetadata(RegistrationMetadata.ColumnNames.ClassID, 5, typeof(System.String), esSystemType.String);
            c.PropertyName = RegistrationMetadata.PropertyNames.ClassID;
            c.CharacterMaxLength = 10;
            c.HasDefault = true;
            c.Default = @"('')";
            c.IsNullable = true;
            _columns.Add(c);

            c = new esColumnMetadata(RegistrationMetadata.ColumnNames.RegistrationDate, 6, typeof(System.DateTime), esSystemType.DateTime);
            c.PropertyName = RegistrationMetadata.PropertyNames.RegistrationDate;
            c.HasDefault = true;
            c.Default = @"(getdate())";
            _columns.Add(c);

            c = new esColumnMetadata(RegistrationMetadata.ColumnNames.RegistrationTime, 7, typeof(System.String), esSystemType.String);
            c.PropertyName = RegistrationMetadata.PropertyNames.RegistrationTime;
            c.CharacterMaxLength = 8;
            c.HasDefault = true;
            c.Default = @"('00:00')";
            _columns.Add(c);

            c = new esColumnMetadata(RegistrationMetadata.ColumnNames.AppointmentNo, 8, typeof(System.String), esSystemType.String);
            c.PropertyName = RegistrationMetadata.PropertyNames.AppointmentNo;
            c.CharacterMaxLength = 20;
            c.IsNullable = true;
            _columns.Add(c);

            c = new esColumnMetadata(RegistrationMetadata.ColumnNames.AgeInYear, 9, typeof(System.Byte), esSystemType.Byte);
            c.PropertyName = RegistrationMetadata.PropertyNames.AgeInYear;
            c.NumericPrecision = 3;
            c.HasDefault = true;
            c.Default = @"((0))";
            _columns.Add(c);

            c = new esColumnMetadata(RegistrationMetadata.ColumnNames.AgeInMonth, 10, typeof(System.Byte), esSystemType.Byte);
            c.PropertyName = RegistrationMetadata.PropertyNames.AgeInMonth;
            c.NumericPrecision = 3;
            c.HasDefault = true;
            c.Default = @"((0))";
            _columns.Add(c);

            c = new esColumnMetadata(RegistrationMetadata.ColumnNames.AgeInDay, 11, typeof(System.Byte), esSystemType.Byte);
            c.PropertyName = RegistrationMetadata.PropertyNames.AgeInDay;
            c.NumericPrecision = 3;
            c.HasDefault = true;
            c.Default = @"((0))";
            _columns.Add(c);

            c = new esColumnMetadata(RegistrationMetadata.ColumnNames.SRShift, 12, typeof(System.String), esSystemType.String);
            c.PropertyName = RegistrationMetadata.PropertyNames.SRShift;
            c.CharacterMaxLength = 20;
            c.HasDefault = true;
            c.Default = @"('')";
            c.IsNullable = true;
            _columns.Add(c);

            c = new esColumnMetadata(RegistrationMetadata.ColumnNames.SRPatientInType, 13, typeof(System.String), esSystemType.String);
            c.PropertyName = RegistrationMetadata.PropertyNames.SRPatientInType;
            c.CharacterMaxLength = 20;
            c.HasDefault = true;
            c.Default = @"('')";
            c.IsNullable = true;
            _columns.Add(c);

            c = new esColumnMetadata(RegistrationMetadata.ColumnNames.InsuranceID, 14, typeof(System.String), esSystemType.String);
            c.PropertyName = RegistrationMetadata.PropertyNames.InsuranceID;
            c.CharacterMaxLength = 20;
            c.HasDefault = true;
            c.Default = @"('')";
            c.IsNullable = true;
            _columns.Add(c);

            c = new esColumnMetadata(RegistrationMetadata.ColumnNames.SRPatientCategory, 15, typeof(System.String), esSystemType.String);
            c.PropertyName = RegistrationMetadata.PropertyNames.SRPatientCategory;
            c.CharacterMaxLength = 20;
            c.HasDefault = true;
            c.Default = @"('')";
            c.IsNullable = true;
            _columns.Add(c);

            c = new esColumnMetadata(RegistrationMetadata.ColumnNames.SRERCaseType, 16, typeof(System.String), esSystemType.String);
            c.PropertyName = RegistrationMetadata.PropertyNames.SRERCaseType;
            c.CharacterMaxLength = 20;
            c.HasDefault = true;
            c.Default = @"('')";
            c.IsNullable = true;
            _columns.Add(c);

            c = new esColumnMetadata(RegistrationMetadata.ColumnNames.SRVisitReason, 17, typeof(System.String), esSystemType.String);
            c.PropertyName = RegistrationMetadata.PropertyNames.SRVisitReason;
            c.CharacterMaxLength = 20;
            c.HasDefault = true;
            c.Default = @"('')";
            c.IsNullable = true;
            _columns.Add(c);

            c = new esColumnMetadata(RegistrationMetadata.ColumnNames.SRBussinesMethod, 18, typeof(System.String), esSystemType.String);
            c.PropertyName = RegistrationMetadata.PropertyNames.SRBussinesMethod;
            c.CharacterMaxLength = 20;
            c.HasDefault = true;
            c.Default = @"('')";
            c.IsNullable = true;
            _columns.Add(c);

            c = new esColumnMetadata(RegistrationMetadata.ColumnNames.PlavonAmount, 19, typeof(System.Decimal), esSystemType.Decimal);
            c.PropertyName = RegistrationMetadata.PropertyNames.PlavonAmount;
            c.NumericPrecision = 18;
            c.HasDefault = true;
            c.Default = @"((0))";
            c.IsNullable = true;
            _columns.Add(c);

            c = new esColumnMetadata(RegistrationMetadata.ColumnNames.DepartmentID, 20, typeof(System.String), esSystemType.String);
            c.PropertyName = RegistrationMetadata.PropertyNames.DepartmentID;
            c.CharacterMaxLength = 10;
            c.HasDefault = true;
            c.Default = @"('')";
            c.IsNullable = true;
            _columns.Add(c);

            c = new esColumnMetadata(RegistrationMetadata.ColumnNames.ServiceUnitID, 21, typeof(System.String), esSystemType.String);
            c.PropertyName = RegistrationMetadata.PropertyNames.ServiceUnitID;
            c.CharacterMaxLength = 10;
            c.HasDefault = true;
            c.Default = @"('')";
            c.IsNullable = true;
            _columns.Add(c);

            c = new esColumnMetadata(RegistrationMetadata.ColumnNames.RoomID, 22, typeof(System.String), esSystemType.String);
            c.PropertyName = RegistrationMetadata.PropertyNames.RoomID;
            c.CharacterMaxLength = 10;
            c.HasDefault = true;
            c.Default = @"('')";
            c.IsNullable = true;
            _columns.Add(c);

            c = new esColumnMetadata(RegistrationMetadata.ColumnNames.BedID, 23, typeof(System.String), esSystemType.String);
            c.PropertyName = RegistrationMetadata.PropertyNames.BedID;
            c.CharacterMaxLength = 10;
            c.HasDefault = true;
            c.Default = @"('')";
            c.IsNullable = true;
            _columns.Add(c);

            c = new esColumnMetadata(RegistrationMetadata.ColumnNames.ChargeClassID, 24, typeof(System.String), esSystemType.String);
            c.PropertyName = RegistrationMetadata.PropertyNames.ChargeClassID;
            c.CharacterMaxLength = 10;
            c.HasDefault = true;
            c.Default = @"('')";
            c.IsNullable = true;
            _columns.Add(c);

            c = new esColumnMetadata(RegistrationMetadata.ColumnNames.CoverageClassID, 25, typeof(System.String), esSystemType.String);
            c.PropertyName = RegistrationMetadata.PropertyNames.CoverageClassID;
            c.CharacterMaxLength = 10;
            c.HasDefault = true;
            c.Default = @"('')";
            c.IsNullable = true;
            _columns.Add(c);

            c = new esColumnMetadata(RegistrationMetadata.ColumnNames.VisitTypeID, 26, typeof(System.String), esSystemType.String);
            c.PropertyName = RegistrationMetadata.PropertyNames.VisitTypeID;
            c.CharacterMaxLength = 10;
            c.HasDefault = true;
            c.Default = @"('')";
            c.IsNullable = true;
            _columns.Add(c);

            c = new esColumnMetadata(RegistrationMetadata.ColumnNames.ReferralID, 27, typeof(System.String), esSystemType.String);
            c.PropertyName = RegistrationMetadata.PropertyNames.ReferralID;
            c.CharacterMaxLength = 10;
            c.HasDefault = true;
            c.Default = @"('')";
            c.IsNullable = true;
            _columns.Add(c);

            c = new esColumnMetadata(RegistrationMetadata.ColumnNames.Anamnesis, 28, typeof(System.String), esSystemType.String);
            c.PropertyName = RegistrationMetadata.PropertyNames.Anamnesis;
            c.CharacterMaxLength = 4000;
            c.HasDefault = true;
            c.Default = @"('')";
            c.IsNullable = true;
            _columns.Add(c);

            c = new esColumnMetadata(RegistrationMetadata.ColumnNames.Complaint, 29, typeof(System.String), esSystemType.String);
            c.PropertyName = RegistrationMetadata.PropertyNames.Complaint;
            c.CharacterMaxLength = 4000;
            c.HasDefault = true;
            c.Default = @"('')";
            c.IsNullable = true;
            _columns.Add(c);

            c = new esColumnMetadata(RegistrationMetadata.ColumnNames.InitialDiagnose, 30, typeof(System.String), esSystemType.String);
            c.PropertyName = RegistrationMetadata.PropertyNames.InitialDiagnose;
            c.CharacterMaxLength = 2147483647;
            c.HasDefault = true;
            c.Default = @"('')";
            c.IsNullable = true;
            _columns.Add(c);

            c = new esColumnMetadata(RegistrationMetadata.ColumnNames.MedicationPlanning, 31, typeof(System.String), esSystemType.String);
            c.PropertyName = RegistrationMetadata.PropertyNames.MedicationPlanning;
            c.CharacterMaxLength = 2147483647;
            c.HasDefault = true;
            c.Default = @"('')";
            c.IsNullable = true;
            _columns.Add(c);

            c = new esColumnMetadata(RegistrationMetadata.ColumnNames.SRTriage, 32, typeof(System.String), esSystemType.String);
            c.PropertyName = RegistrationMetadata.PropertyNames.SRTriage;
            c.CharacterMaxLength = 20;
            c.HasDefault = true;
            c.Default = @"('')";
            c.IsNullable = true;
            _columns.Add(c);

            c = new esColumnMetadata(RegistrationMetadata.ColumnNames.IsPrintingPatientCard, 33, typeof(System.Boolean), esSystemType.Boolean);
            c.PropertyName = RegistrationMetadata.PropertyNames.IsPrintingPatientCard;
            c.HasDefault = true;
            c.Default = @"((0))";
            _columns.Add(c);

            c = new esColumnMetadata(RegistrationMetadata.ColumnNames.DischargeDate, 34, typeof(System.DateTime), esSystemType.DateTime);
            c.PropertyName = RegistrationMetadata.PropertyNames.DischargeDate;
            c.IsNullable = true;
            _columns.Add(c);

            c = new esColumnMetadata(RegistrationMetadata.ColumnNames.DischargeTime, 35, typeof(System.String), esSystemType.String);
            c.PropertyName = RegistrationMetadata.PropertyNames.DischargeTime;
            c.CharacterMaxLength = 5;
            c.IsNullable = true;
            _columns.Add(c);

            c = new esColumnMetadata(RegistrationMetadata.ColumnNames.DischargeMedicalNotes, 36, typeof(System.String), esSystemType.String);
            c.PropertyName = RegistrationMetadata.PropertyNames.DischargeMedicalNotes;
            c.CharacterMaxLength = 4000;
            c.HasDefault = true;
            c.Default = @"('')";
            c.IsNullable = true;
            _columns.Add(c);

            c = new esColumnMetadata(RegistrationMetadata.ColumnNames.DischargeNotes, 37, typeof(System.String), esSystemType.String);
            c.PropertyName = RegistrationMetadata.PropertyNames.DischargeNotes;
            c.CharacterMaxLength = 4000;
            c.IsNullable = true;
            _columns.Add(c);

            c = new esColumnMetadata(RegistrationMetadata.ColumnNames.SRDischargeCondition, 38, typeof(System.String), esSystemType.String);
            c.PropertyName = RegistrationMetadata.PropertyNames.SRDischargeCondition;
            c.CharacterMaxLength = 20;
            c.HasDefault = true;
            c.Default = @"('')";
            c.IsNullable = true;
            _columns.Add(c);

            c = new esColumnMetadata(RegistrationMetadata.ColumnNames.SRDischargeMethod, 39, typeof(System.String), esSystemType.String);
            c.PropertyName = RegistrationMetadata.PropertyNames.SRDischargeMethod;
            c.CharacterMaxLength = 20;
            c.HasDefault = true;
            c.Default = @"('')";
            c.IsNullable = true;
            _columns.Add(c);

            c = new esColumnMetadata(RegistrationMetadata.ColumnNames.LOSInYear, 40, typeof(System.Byte), esSystemType.Byte);
            c.PropertyName = RegistrationMetadata.PropertyNames.LOSInYear;
            c.NumericPrecision = 3;
            c.HasDefault = true;
            c.Default = @"((0))";
            _columns.Add(c);

            c = new esColumnMetadata(RegistrationMetadata.ColumnNames.LOSInMonth, 41, typeof(System.Byte), esSystemType.Byte);
            c.PropertyName = RegistrationMetadata.PropertyNames.LOSInMonth;
            c.NumericPrecision = 3;
            c.HasDefault = true;
            c.Default = @"((0))";
            _columns.Add(c);

            c = new esColumnMetadata(RegistrationMetadata.ColumnNames.LOSInDay, 42, typeof(System.Byte), esSystemType.Byte);
            c.PropertyName = RegistrationMetadata.PropertyNames.LOSInDay;
            c.NumericPrecision = 3;
            c.HasDefault = true;
            c.Default = @"((0))";
            _columns.Add(c);

            c = new esColumnMetadata(RegistrationMetadata.ColumnNames.DischargeOperatorID, 43, typeof(System.String), esSystemType.String);
            c.PropertyName = RegistrationMetadata.PropertyNames.DischargeOperatorID;
            c.CharacterMaxLength = 10;
            c.HasDefault = true;
            c.Default = @"('')";
            c.IsNullable = true;
            _columns.Add(c);

            c = new esColumnMetadata(RegistrationMetadata.ColumnNames.AccountNo, 44, typeof(System.String), esSystemType.String);
            c.PropertyName = RegistrationMetadata.PropertyNames.AccountNo;
            c.CharacterMaxLength = 20;
            c.HasDefault = true;
            c.Default = @"('')";
            _columns.Add(c);

            c = new esColumnMetadata(RegistrationMetadata.ColumnNames.TransactionAmount, 45, typeof(System.Decimal), esSystemType.Decimal);
            c.PropertyName = RegistrationMetadata.PropertyNames.TransactionAmount;
            c.NumericPrecision = 18;
            c.NumericScale = 2;
            c.HasDefault = true;
            c.Default = @"((0))";
            _columns.Add(c);

            c = new esColumnMetadata(RegistrationMetadata.ColumnNames.AdministrationAmount, 46, typeof(System.Decimal), esSystemType.Decimal);
            c.PropertyName = RegistrationMetadata.PropertyNames.AdministrationAmount;
            c.NumericPrecision = 18;
            c.NumericScale = 2;
            c.HasDefault = true;
            c.Default = @"((0))";
            _columns.Add(c);

            c = new esColumnMetadata(RegistrationMetadata.ColumnNames.RoundingAmount, 47, typeof(System.Decimal), esSystemType.Decimal);
            c.PropertyName = RegistrationMetadata.PropertyNames.RoundingAmount;
            c.NumericPrecision = 18;
            c.NumericScale = 2;
            c.HasDefault = true;
            c.Default = @"((0))";
            _columns.Add(c);

            c = new esColumnMetadata(RegistrationMetadata.ColumnNames.RemainingAmount, 48, typeof(System.Decimal), esSystemType.Decimal);
            c.PropertyName = RegistrationMetadata.PropertyNames.RemainingAmount;
            c.NumericPrecision = 18;
            c.NumericScale = 2;
            c.HasDefault = true;
            c.Default = @"((0))";
            _columns.Add(c);

            c = new esColumnMetadata(RegistrationMetadata.ColumnNames.IsTransferedToInpatient, 49, typeof(System.Boolean), esSystemType.Boolean);
            c.PropertyName = RegistrationMetadata.PropertyNames.IsTransferedToInpatient;
            c.HasDefault = true;
            c.Default = @"((0))";
            _columns.Add(c);

            c = new esColumnMetadata(RegistrationMetadata.ColumnNames.IsNewPatient, 50, typeof(System.Boolean), esSystemType.Boolean);
            c.PropertyName = RegistrationMetadata.PropertyNames.IsNewPatient;
            c.HasDefault = true;
            c.Default = @"((0))";
            _columns.Add(c);

            c = new esColumnMetadata(RegistrationMetadata.ColumnNames.IsNewBornInfant, 51, typeof(System.Boolean), esSystemType.Boolean);
            c.PropertyName = RegistrationMetadata.PropertyNames.IsNewBornInfant;
            c.HasDefault = true;
            c.Default = @"((0))";
            _columns.Add(c);

            c = new esColumnMetadata(RegistrationMetadata.ColumnNames.IsParturition, 52, typeof(System.Boolean), esSystemType.Boolean);
            c.PropertyName = RegistrationMetadata.PropertyNames.IsParturition;
            c.HasDefault = true;
            c.Default = @"((0))";
            _columns.Add(c);

            c = new esColumnMetadata(RegistrationMetadata.ColumnNames.IsHoldTransactionEntry, 53, typeof(System.Boolean), esSystemType.Boolean);
            c.PropertyName = RegistrationMetadata.PropertyNames.IsHoldTransactionEntry;
            c.HasDefault = true;
            c.Default = @"((0))";
            _columns.Add(c);

            c = new esColumnMetadata(RegistrationMetadata.ColumnNames.IsHasCorrection, 54, typeof(System.Boolean), esSystemType.Boolean);
            c.PropertyName = RegistrationMetadata.PropertyNames.IsHasCorrection;
            c.HasDefault = true;
            c.Default = @"((0))";
            _columns.Add(c);

            c = new esColumnMetadata(RegistrationMetadata.ColumnNames.IsEMRValid, 55, typeof(System.Boolean), esSystemType.Boolean);
            c.PropertyName = RegistrationMetadata.PropertyNames.IsEMRValid;
            c.HasDefault = true;
            c.Default = @"((0))";
            c.IsNullable = true;
            _columns.Add(c);

            c = new esColumnMetadata(RegistrationMetadata.ColumnNames.IsBackDate, 56, typeof(System.Boolean), esSystemType.Boolean);
            c.PropertyName = RegistrationMetadata.PropertyNames.IsBackDate;
            c.HasDefault = true;
            c.Default = @"((0))";
            c.IsNullable = true;
            _columns.Add(c);

            c = new esColumnMetadata(RegistrationMetadata.ColumnNames.ActualVisitDate, 57, typeof(System.DateTime), esSystemType.DateTime);
            c.PropertyName = RegistrationMetadata.PropertyNames.ActualVisitDate;
            c.IsNullable = true;
            _columns.Add(c);

            c = new esColumnMetadata(RegistrationMetadata.ColumnNames.IsVoid, 58, typeof(System.Boolean), esSystemType.Boolean);
            c.PropertyName = RegistrationMetadata.PropertyNames.IsVoid;
            c.HasDefault = true;
            c.Default = @"((0))";
            c.IsNullable = true;
            _columns.Add(c);

            c = new esColumnMetadata(RegistrationMetadata.ColumnNames.SRVoidReason, 59, typeof(System.String), esSystemType.String);
            c.PropertyName = RegistrationMetadata.PropertyNames.SRVoidReason;
            c.CharacterMaxLength = 20;
            c.IsNullable = true;
            _columns.Add(c);

            c = new esColumnMetadata(RegistrationMetadata.ColumnNames.VoidNotes, 60, typeof(System.String), esSystemType.String);
            c.PropertyName = RegistrationMetadata.PropertyNames.VoidNotes;
            c.CharacterMaxLength = 2147483647;
            c.IsNullable = true;
            _columns.Add(c);

            c = new esColumnMetadata(RegistrationMetadata.ColumnNames.VoidDate, 61, typeof(System.DateTime), esSystemType.DateTime);
            c.PropertyName = RegistrationMetadata.PropertyNames.VoidDate;
            c.IsNullable = true;
            _columns.Add(c);

            c = new esColumnMetadata(RegistrationMetadata.ColumnNames.VoidByUserID, 62, typeof(System.String), esSystemType.String);
            c.PropertyName = RegistrationMetadata.PropertyNames.VoidByUserID;
            c.CharacterMaxLength = 15;
            c.IsNullable = true;
            _columns.Add(c);

            c = new esColumnMetadata(RegistrationMetadata.ColumnNames.IsClosed, 63, typeof(System.Boolean), esSystemType.Boolean);
            c.PropertyName = RegistrationMetadata.PropertyNames.IsClosed;
            c.HasDefault = true;
            c.Default = @"((0))";
            c.IsNullable = true;
            _columns.Add(c);

            c = new esColumnMetadata(RegistrationMetadata.ColumnNames.IsEpisodeComplete, 64, typeof(System.Boolean), esSystemType.Boolean);
            c.PropertyName = RegistrationMetadata.PropertyNames.IsEpisodeComplete;
            c.HasDefault = true;
            c.Default = @"((0))";
            c.IsNullable = true;
            _columns.Add(c);

            c = new esColumnMetadata(RegistrationMetadata.ColumnNames.IsClusterAssessment, 65, typeof(System.Boolean), esSystemType.Boolean);
            c.PropertyName = RegistrationMetadata.PropertyNames.IsClusterAssessment;
            c.HasDefault = true;
            c.Default = @"((0))";
            c.IsNullable = true;
            _columns.Add(c);

            c = new esColumnMetadata(RegistrationMetadata.ColumnNames.IsConsul, 66, typeof(System.Boolean), esSystemType.Boolean);
            c.PropertyName = RegistrationMetadata.PropertyNames.IsConsul;
            c.HasDefault = true;
            c.Default = @"((0))";
            c.IsNullable = true;
            _columns.Add(c);

            c = new esColumnMetadata(RegistrationMetadata.ColumnNames.IsFromDispensary, 67, typeof(System.Boolean), esSystemType.Boolean);
            c.PropertyName = RegistrationMetadata.PropertyNames.IsFromDispensary;
            c.IsNullable = true;
            _columns.Add(c);

            c = new esColumnMetadata(RegistrationMetadata.ColumnNames.IsNewVisit, 68, typeof(System.Boolean), esSystemType.Boolean);
            c.PropertyName = RegistrationMetadata.PropertyNames.IsNewVisit;
            c.IsNullable = true;
            _columns.Add(c);

            c = new esColumnMetadata(RegistrationMetadata.ColumnNames.Notes, 69, typeof(System.String), esSystemType.String);
            c.PropertyName = RegistrationMetadata.PropertyNames.Notes;
            c.CharacterMaxLength = 2147483647;
            c.HasDefault = true;
            c.Default = @"('')";
            _columns.Add(c);

            c = new esColumnMetadata(RegistrationMetadata.ColumnNames.LastCreateDateTime, 70, typeof(System.DateTime), esSystemType.DateTime);
            c.PropertyName = RegistrationMetadata.PropertyNames.LastCreateDateTime;
            c.IsNullable = true;
            _columns.Add(c);

            c = new esColumnMetadata(RegistrationMetadata.ColumnNames.LastCreateUserID, 71, typeof(System.String), esSystemType.String);
            c.PropertyName = RegistrationMetadata.PropertyNames.LastCreateUserID;
            c.CharacterMaxLength = 15;
            c.IsNullable = true;
            _columns.Add(c);

            c = new esColumnMetadata(RegistrationMetadata.ColumnNames.LastUpdateDateTime, 72, typeof(System.DateTime), esSystemType.DateTime);
            c.PropertyName = RegistrationMetadata.PropertyNames.LastUpdateDateTime;
            c.IsNullable = true;
            _columns.Add(c);

            c = new esColumnMetadata(RegistrationMetadata.ColumnNames.LastUpdateByUserID, 73, typeof(System.String), esSystemType.String);
            c.PropertyName = RegistrationMetadata.PropertyNames.LastUpdateByUserID;
            c.CharacterMaxLength = 15;
            c.IsNullable = true;
            _columns.Add(c);

            c = new esColumnMetadata(RegistrationMetadata.ColumnNames.IsDirectPrescriptionReturn, 74, typeof(System.Boolean), esSystemType.Boolean);
            c.PropertyName = RegistrationMetadata.PropertyNames.IsDirectPrescriptionReturn;
            c.HasDefault = true;
            c.Default = @"((0))";
            _columns.Add(c);

            c = new esColumnMetadata(RegistrationMetadata.ColumnNames.VisiteRegistrationNo, 75, typeof(System.String), esSystemType.String);
            c.PropertyName = RegistrationMetadata.PropertyNames.VisiteRegistrationNo;
            c.CharacterMaxLength = 20;
            c.IsNullable = true;
            _columns.Add(c);

            c = new esColumnMetadata(RegistrationMetadata.ColumnNames.RegistrationQue, 76, typeof(System.Int32), esSystemType.Int32);
            c.PropertyName = RegistrationMetadata.PropertyNames.RegistrationQue;
            c.NumericPrecision = 10;
            c.IsNullable = true;
            _columns.Add(c);

            c = new esColumnMetadata(RegistrationMetadata.ColumnNames.ReferralIDTo, 77, typeof(System.String), esSystemType.String);
            c.PropertyName = RegistrationMetadata.PropertyNames.ReferralIDTo;
            c.CharacterMaxLength = 10;
            c.IsNullable = true;
            _columns.Add(c);

            c = new esColumnMetadata(RegistrationMetadata.ColumnNames.SEPNo, 78, typeof(System.String), esSystemType.String);
            c.PropertyName = RegistrationMetadata.PropertyNames.SEPNo;
            c.CharacterMaxLength = 30;
            c.IsNullable = true;
            _columns.Add(c);

            c = new esColumnMetadata(RegistrationMetadata.ColumnNames.JasindoNo, 79, typeof(System.String), esSystemType.String);
            c.PropertyName = RegistrationMetadata.PropertyNames.JasindoNo;
            c.CharacterMaxLength = 30;
            c.IsNullable = true;
            _columns.Add(c);

        }
        #endregion

        static public RegistrationMetadata Meta()
        {
            return meta;
        }

        public Guid DataID
        {
            get { return base._dataID; }
        }

        public bool MultiProviderMode
        {
            get { return false; }
        }

        public esColumnMetadataCollection Columns
        {
            get { return base._columns; }
        }

        #region ColumnNames
        public class ColumnNames
        {
            public const string RegistrationNo = "RegistrationNo";
            public const string SRRegistrationType = "SRRegistrationType";
            public const string ParamedicID = "ParamedicID";
            public const string GuarantorID = "GuarantorID";
            public const string PatientID = "PatientID";
            public const string ClassID = "ClassID";
            public const string RegistrationDate = "RegistrationDate";
            public const string RegistrationTime = "RegistrationTime";
            public const string AppointmentNo = "AppointmentNo";
            public const string AgeInYear = "AgeInYear";
            public const string AgeInMonth = "AgeInMonth";
            public const string AgeInDay = "AgeInDay";
            public const string SRShift = "SRShift";
            public const string SRPatientInType = "SRPatientInType";
            public const string InsuranceID = "InsuranceID";
            public const string SRPatientCategory = "SRPatientCategory";
            public const string SRERCaseType = "SRERCaseType";
            public const string SRVisitReason = "SRVisitReason";
            public const string SRBussinesMethod = "SRBussinesMethod";
            public const string PlavonAmount = "PlavonAmount";
            public const string DepartmentID = "DepartmentID";
            public const string ServiceUnitID = "ServiceUnitID";
            public const string RoomID = "RoomID";
            public const string BedID = "BedID";
            public const string ChargeClassID = "ChargeClassID";
            public const string CoverageClassID = "CoverageClassID";
            public const string VisitTypeID = "VisitTypeID";
            public const string ReferralID = "ReferralID";
            public const string Anamnesis = "Anamnesis";
            public const string Complaint = "Complaint";
            public const string InitialDiagnose = "InitialDiagnose";
            public const string MedicationPlanning = "MedicationPlanning";
            public const string SRTriage = "SRTriage";
            public const string IsPrintingPatientCard = "IsPrintingPatientCard";
            public const string DischargeDate = "DischargeDate";
            public const string DischargeTime = "DischargeTime";
            public const string DischargeMedicalNotes = "DischargeMedicalNotes";
            public const string DischargeNotes = "DischargeNotes";
            public const string SRDischargeCondition = "SRDischargeCondition";
            public const string SRDischargeMethod = "SRDischargeMethod";
            public const string LOSInYear = "LOSInYear";
            public const string LOSInMonth = "LOSInMonth";
            public const string LOSInDay = "LOSInDay";
            public const string DischargeOperatorID = "DischargeOperatorID";
            public const string AccountNo = "AccountNo";
            public const string TransactionAmount = "TransactionAmount";
            public const string AdministrationAmount = "AdministrationAmount";
            public const string RoundingAmount = "RoundingAmount";
            public const string RemainingAmount = "RemainingAmount";
            public const string IsTransferedToInpatient = "IsTransferedToInpatient";
            public const string IsNewPatient = "IsNewPatient";
            public const string IsNewBornInfant = "IsNewBornInfant";
            public const string IsParturition = "IsParturition";
            public const string IsHoldTransactionEntry = "IsHoldTransactionEntry";
            public const string IsHasCorrection = "IsHasCorrection";
            public const string IsEMRValid = "IsEMRValid";
            public const string IsBackDate = "IsBackDate";
            public const string ActualVisitDate = "ActualVisitDate";
            public const string IsVoid = "IsVoid";
            public const string SRVoidReason = "SRVoidReason";
            public const string VoidNotes = "VoidNotes";
            public const string VoidDate = "VoidDate";
            public const string VoidByUserID = "VoidByUserID";
            public const string IsClosed = "IsClosed";
            public const string IsEpisodeComplete = "IsEpisodeComplete";
            public const string IsClusterAssessment = "IsClusterAssessment";
            public const string IsConsul = "IsConsul";
            public const string IsFromDispensary = "IsFromDispensary";
            public const string IsNewVisit = "IsNewVisit";
            public const string Notes = "Notes";
            public const string LastCreateDateTime = "LastCreateDateTime";
            public const string LastCreateUserID = "LastCreateUserID";
            public const string LastUpdateDateTime = "LastUpdateDateTime";
            public const string LastUpdateByUserID = "LastUpdateByUserID";
            public const string IsDirectPrescriptionReturn = "isDirectPrescriptionReturn";
            public const string VisiteRegistrationNo = "VisiteRegistrationNo";
            public const string RegistrationQue = "RegistrationQue";
            public const string ReferralIDTo = "ReferralIDTo";
            public const string SEPNo = "SEPNo";
            public const string JasindoNo = "JasindoNo";
        }
        #endregion

        #region PropertyNames
        public class PropertyNames
        {
            public const string RegistrationNo = "RegistrationNo";
            public const string SRRegistrationType = "SRRegistrationType";
            public const string ParamedicID = "ParamedicID";
            public const string GuarantorID = "GuarantorID";
            public const string PatientID = "PatientID";
            public const string ClassID = "ClassID";
            public const string RegistrationDate = "RegistrationDate";
            public const string RegistrationTime = "RegistrationTime";
            public const string AppointmentNo = "AppointmentNo";
            public const string AgeInYear = "AgeInYear";
            public const string AgeInMonth = "AgeInMonth";
            public const string AgeInDay = "AgeInDay";
            public const string SRShift = "SRShift";
            public const string SRPatientInType = "SRPatientInType";
            public const string InsuranceID = "InsuranceID";
            public const string SRPatientCategory = "SRPatientCategory";
            public const string SRERCaseType = "SRERCaseType";
            public const string SRVisitReason = "SRVisitReason";
            public const string SRBussinesMethod = "SRBussinesMethod";
            public const string PlavonAmount = "PlavonAmount";
            public const string DepartmentID = "DepartmentID";
            public const string ServiceUnitID = "ServiceUnitID";
            public const string RoomID = "RoomID";
            public const string BedID = "BedID";
            public const string ChargeClassID = "ChargeClassID";
            public const string CoverageClassID = "CoverageClassID";
            public const string VisitTypeID = "VisitTypeID";
            public const string ReferralID = "ReferralID";
            public const string Anamnesis = "Anamnesis";
            public const string Complaint = "Complaint";
            public const string InitialDiagnose = "InitialDiagnose";
            public const string MedicationPlanning = "MedicationPlanning";
            public const string SRTriage = "SRTriage";
            public const string IsPrintingPatientCard = "IsPrintingPatientCard";
            public const string DischargeDate = "DischargeDate";
            public const string DischargeTime = "DischargeTime";
            public const string DischargeMedicalNotes = "DischargeMedicalNotes";
            public const string DischargeNotes = "DischargeNotes";
            public const string SRDischargeCondition = "SRDischargeCondition";
            public const string SRDischargeMethod = "SRDischargeMethod";
            public const string LOSInYear = "LOSInYear";
            public const string LOSInMonth = "LOSInMonth";
            public const string LOSInDay = "LOSInDay";
            public const string DischargeOperatorID = "DischargeOperatorID";
            public const string AccountNo = "AccountNo";
            public const string TransactionAmount = "TransactionAmount";
            public const string AdministrationAmount = "AdministrationAmount";
            public const string RoundingAmount = "RoundingAmount";
            public const string RemainingAmount = "RemainingAmount";
            public const string IsTransferedToInpatient = "IsTransferedToInpatient";
            public const string IsNewPatient = "IsNewPatient";
            public const string IsNewBornInfant = "IsNewBornInfant";
            public const string IsParturition = "IsParturition";
            public const string IsHoldTransactionEntry = "IsHoldTransactionEntry";
            public const string IsHasCorrection = "IsHasCorrection";
            public const string IsEMRValid = "IsEMRValid";
            public const string IsBackDate = "IsBackDate";
            public const string ActualVisitDate = "ActualVisitDate";
            public const string IsVoid = "IsVoid";
            public const string SRVoidReason = "SRVoidReason";
            public const string VoidNotes = "VoidNotes";
            public const string VoidDate = "VoidDate";
            public const string VoidByUserID = "VoidByUserID";
            public const string IsClosed = "IsClosed";
            public const string IsEpisodeComplete = "IsEpisodeComplete";
            public const string IsClusterAssessment = "IsClusterAssessment";
            public const string IsConsul = "IsConsul";
            public const string IsFromDispensary = "IsFromDispensary";
            public const string IsNewVisit = "IsNewVisit";
            public const string Notes = "Notes";
            public const string LastCreateDateTime = "LastCreateDateTime";
            public const string LastCreateUserID = "LastCreateUserID";
            public const string LastUpdateDateTime = "LastUpdateDateTime";
            public const string LastUpdateByUserID = "LastUpdateByUserID";
            public const string IsDirectPrescriptionReturn = "IsDirectPrescriptionReturn";
            public const string VisiteRegistrationNo = "VisiteRegistrationNo";
            public const string RegistrationQue = "RegistrationQue";
            public const string ReferralIDTo = "ReferralIDTo";
            public const string SEPNo = "SEPNo";
            public const string JasindoNo = "JasindoNo";
        }
        #endregion

        public esProviderSpecificMetadata GetProviderMetadata(string mapName)
        {
            MapToMeta mapMethod = mapDelegates[mapName];

            if (mapMethod != null)
                return mapMethod(mapName);
            else
                return null;
        }

        #region MAP esDefault

        static private int RegisterDelegateesDefault()
        {
            // This is only executed once per the life of the application
            lock (typeof(RegistrationMetadata))
            {
                if (RegistrationMetadata.mapDelegates == null)
                {
                    RegistrationMetadata.mapDelegates = new Dictionary<string, MapToMeta>();
                }

                if (RegistrationMetadata.meta == null)
                {
                    RegistrationMetadata.meta = new RegistrationMetadata();
                }

                MapToMeta mapMethod = new MapToMeta(meta.esDefault);
                mapDelegates.Add("esDefault", mapMethod);
                mapMethod("esDefault");
            }
            return 0;
        }

        private esProviderSpecificMetadata esDefault(string mapName)
        {
            if (!_providerMetadataMaps.ContainsKey(mapName))
            {
                esProviderSpecificMetadata meta = new esProviderSpecificMetadata();


                meta.AddTypeMap("RegistrationNo", new esTypeMap("varchar", "System.String"));
                meta.AddTypeMap("SRRegistrationType", new esTypeMap("varchar", "System.String"));
                meta.AddTypeMap("ParamedicID", new esTypeMap("varchar", "System.String"));
                meta.AddTypeMap("GuarantorID", new esTypeMap("varchar", "System.String"));
                meta.AddTypeMap("PatientID", new esTypeMap("varchar", "System.String"));
                meta.AddTypeMap("ClassID", new esTypeMap("varchar", "System.String"));
                meta.AddTypeMap("RegistrationDate", new esTypeMap("smalldatetime", "System.DateTime"));
                meta.AddTypeMap("RegistrationTime", new esTypeMap("char", "System.String"));
                meta.AddTypeMap("AppointmentNo", new esTypeMap("varchar", "System.String"));
                meta.AddTypeMap("AgeInYear", new esTypeMap("tinyint", "System.Byte"));
                meta.AddTypeMap("AgeInMonth", new esTypeMap("tinyint", "System.Byte"));
                meta.AddTypeMap("AgeInDay", new esTypeMap("tinyint", "System.Byte"));
                meta.AddTypeMap("SRShift", new esTypeMap("varchar", "System.String"));
                meta.AddTypeMap("SRPatientInType", new esTypeMap("varchar", "System.String"));
                meta.AddTypeMap("InsuranceID", new esTypeMap("varchar", "System.String"));
                meta.AddTypeMap("SRPatientCategory", new esTypeMap("varchar", "System.String"));
                meta.AddTypeMap("SRERCaseType", new esTypeMap("varchar", "System.String"));
                meta.AddTypeMap("SRVisitReason", new esTypeMap("varchar", "System.String"));
                meta.AddTypeMap("SRBussinesMethod", new esTypeMap("varchar", "System.String"));
                meta.AddTypeMap("PlavonAmount", new esTypeMap("numeric", "System.Decimal"));
                meta.AddTypeMap("DepartmentID", new esTypeMap("varchar", "System.String"));
                meta.AddTypeMap("ServiceUnitID", new esTypeMap("varchar", "System.String"));
                meta.AddTypeMap("RoomID", new esTypeMap("varchar", "System.String"));
                meta.AddTypeMap("BedID", new esTypeMap("varchar", "System.String"));
                meta.AddTypeMap("ChargeClassID", new esTypeMap("varchar", "System.String"));
                meta.AddTypeMap("CoverageClassID", new esTypeMap("varchar", "System.String"));
                meta.AddTypeMap("VisitTypeID", new esTypeMap("varchar", "System.String"));
                meta.AddTypeMap("ReferralID", new esTypeMap("varchar", "System.String"));
                meta.AddTypeMap("Anamnesis", new esTypeMap("varchar", "System.String"));
                meta.AddTypeMap("Complaint", new esTypeMap("varchar", "System.String"));
                meta.AddTypeMap("InitialDiagnose", new esTypeMap("varchar", "System.String"));
                meta.AddTypeMap("MedicationPlanning", new esTypeMap("varchar", "System.String"));
                meta.AddTypeMap("SRTriage", new esTypeMap("varchar", "System.String"));
                meta.AddTypeMap("IsPrintingPatientCard", new esTypeMap("bit", "System.Boolean"));
                meta.AddTypeMap("DischargeDate", new esTypeMap("smalldatetime", "System.DateTime"));
                meta.AddTypeMap("DischargeTime", new esTypeMap("char", "System.String"));
                meta.AddTypeMap("DischargeMedicalNotes", new esTypeMap("varchar", "System.String"));
                meta.AddTypeMap("DischargeNotes", new esTypeMap("varchar", "System.String"));
                meta.AddTypeMap("SRDischargeCondition", new esTypeMap("varchar", "System.String"));
                meta.AddTypeMap("SRDischargeMethod", new esTypeMap("varchar", "System.String"));
                meta.AddTypeMap("LOSInYear", new esTypeMap("tinyint", "System.Byte"));
                meta.AddTypeMap("LOSInMonth", new esTypeMap("tinyint", "System.Byte"));
                meta.AddTypeMap("LOSInDay", new esTypeMap("tinyint", "System.Byte"));
                meta.AddTypeMap("DischargeOperatorID", new esTypeMap("varchar", "System.String"));
                meta.AddTypeMap("AccountNo", new esTypeMap("varchar", "System.String"));
                meta.AddTypeMap("TransactionAmount", new esTypeMap("numeric", "System.Decimal"));
                meta.AddTypeMap("AdministrationAmount", new esTypeMap("numeric", "System.Decimal"));
                meta.AddTypeMap("RoundingAmount", new esTypeMap("numeric", "System.Decimal"));
                meta.AddTypeMap("RemainingAmount", new esTypeMap("numeric", "System.Decimal"));
                meta.AddTypeMap("IsTransferedToInpatient", new esTypeMap("bit", "System.Boolean"));
                meta.AddTypeMap("IsNewPatient", new esTypeMap("bit", "System.Boolean"));
                meta.AddTypeMap("IsNewBornInfant", new esTypeMap("bit", "System.Boolean"));
                meta.AddTypeMap("IsParturition", new esTypeMap("bit", "System.Boolean"));
                meta.AddTypeMap("IsHoldTransactionEntry", new esTypeMap("bit", "System.Boolean"));
                meta.AddTypeMap("IsHasCorrection", new esTypeMap("bit", "System.Boolean"));
                meta.AddTypeMap("IsEMRValid", new esTypeMap("bit", "System.Boolean"));
                meta.AddTypeMap("IsBackDate", new esTypeMap("bit", "System.Boolean"));
                meta.AddTypeMap("ActualVisitDate", new esTypeMap("smalldatetime", "System.DateTime"));
                meta.AddTypeMap("IsVoid", new esTypeMap("bit", "System.Boolean"));
                meta.AddTypeMap("SRVoidReason", new esTypeMap("varchar", "System.String"));
                meta.AddTypeMap("VoidNotes", new esTypeMap("varchar", "System.String"));
                meta.AddTypeMap("VoidDate", new esTypeMap("datetime", "System.DateTime"));
                meta.AddTypeMap("VoidByUserID", new esTypeMap("varchar", "System.String"));
                meta.AddTypeMap("IsClosed", new esTypeMap("bit", "System.Boolean"));
                meta.AddTypeMap("IsEpisodeComplete", new esTypeMap("bit", "System.Boolean"));
                meta.AddTypeMap("IsClusterAssessment", new esTypeMap("bit", "System.Boolean"));
                meta.AddTypeMap("IsConsul", new esTypeMap("bit", "System.Boolean"));
                meta.AddTypeMap("IsFromDispensary", new esTypeMap("bit", "System.Boolean"));
                meta.AddTypeMap("IsNewVisit", new esTypeMap("bit", "System.Boolean"));
                meta.AddTypeMap("Notes", new esTypeMap("varchar", "System.String"));
                meta.AddTypeMap("LastCreateDateTime", new esTypeMap("datetime", "System.DateTime"));
                meta.AddTypeMap("LastCreateUserID", new esTypeMap("varchar", "System.String"));
                meta.AddTypeMap("LastUpdateDateTime", new esTypeMap("datetime", "System.DateTime"));
                meta.AddTypeMap("LastUpdateByUserID", new esTypeMap("varchar", "System.String"));
                meta.AddTypeMap("IsDirectPrescriptionReturn", new esTypeMap("bit", "System.Boolean"));
                meta.AddTypeMap("VisiteRegistrationNo", new esTypeMap("varchar", "System.String"));
                meta.AddTypeMap("RegistrationQue", new esTypeMap("int", "System.Int32"));
                meta.AddTypeMap("ReferralIDTo", new esTypeMap("varchar", "System.String"));
                meta.AddTypeMap("SEPNo", new esTypeMap("varchar", "System.String"));
                meta.AddTypeMap("JasindoNo", new esTypeMap("varchar", "System.String"));



                meta.Source = "Registration";
                meta.Destination = "Registration";

                meta.spInsert = "proc_RegistrationInsert";
                meta.spUpdate = "proc_RegistrationUpdate";
                meta.spDelete = "proc_RegistrationDelete";
                meta.spLoadAll = "proc_RegistrationLoadAll";
                meta.spLoadByPrimaryKey = "proc_RegistrationLoadByPrimaryKey";

                this._providerMetadataMaps["esDefault"] = meta;
            }

            return this._providerMetadataMaps["esDefault"];
        }

        #endregion

        static private RegistrationMetadata meta;
        static protected Dictionary<string, MapToMeta> mapDelegates;
        static private int _esDefault = RegisterDelegateesDefault();
    }
}
