/*
===============================================================================
                 Persistence Layer and Business Objects
===============================================================================
Version         : 2009.2.1214.0
Driver          : SQL
Date Generated  : 6/14/2011 2:21:38 PM
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
	abstract public class esGuarantorCollection : esEntityCollection
	{
		public esGuarantorCollection()
		{

		}

		protected override string GetCollectionName()
		{
			return "GuarantorCollection";
		}

		#region Query Logic
		protected void InitQuery(esGuarantorQuery query)
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
			this.InitQuery(query as esGuarantorQuery);
		}
		#endregion
		
		virtual public Guarantor DetachEntity(Guarantor entity)
		{
			return base.DetachEntity(entity) as Guarantor;
		}
		
		virtual public Guarantor AttachEntity(Guarantor entity)
		{
			return base.AttachEntity(entity) as Guarantor;
		}
		
		virtual public void Combine(GuarantorCollection collection)
		{
			base.Combine(collection);
		}
		
		new public Guarantor this[int index]
		{
			get
			{
				return base[index] as Guarantor;
			}
		}

		public override Type GetEntityType()
		{
			return typeof(Guarantor);
		}
	}



	[Serializable]
	abstract public class esGuarantor : esEntity
	{
		/// <summary>
		/// Used internally by the entity's DynamicQuery mechanism.
		/// </summary>
		virtual protected esGuarantorQuery GetDynamicQuery()
		{
			return null;
		}

		public esGuarantor()
		{

		}

		public esGuarantor(DataRow row)
			: base(row)
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.String guarantorID)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(guarantorID);
			else
				return LoadByPrimaryKeyStoredProcedure(guarantorID);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.String guarantorID)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(guarantorID);
			else
				return LoadByPrimaryKeyStoredProcedure(guarantorID);
		}

		private bool LoadByPrimaryKeyDynamic(System.String guarantorID)
		{
			esGuarantorQuery query = this.GetDynamicQuery();
			query.Where(query.GuarantorID == guarantorID);
			return query.Load();
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.String guarantorID)
		{
			esParameters parms = new esParameters();
			parms.Add("GuarantorID",guarantorID);
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
			if(this.Row == null) this.AddNew();
			
			esColumnMetadata col = this.Meta.Columns.FindByPropertyName(name);
			if (col != null)
			{
				if(value == null || value is System.String)
				{				
					// Use the strongly typed property
					switch (name)
					{							
						case "GuarantorID": this.str.GuarantorID = (string)value; break;							
						case "GuarantorName": this.str.GuarantorName = (string)value; break;							
						case "ShortName": this.str.ShortName = (string)value; break;							
						case "SRGuarantorType": this.str.SRGuarantorType = (string)value; break;							
						case "ContractNumber": this.str.ContractNumber = (string)value; break;							
						case "ContractStart": this.str.ContractStart = (string)value; break;							
						case "ContractEnd": this.str.ContractEnd = (string)value; break;							
						case "ContractSummary": this.str.ContractSummary = (string)value; break;							
						case "ContactPerson": this.str.ContactPerson = (string)value; break;							
						case "IsActive": this.str.IsActive = (string)value; break;							
						case "SRBusinessMethod": this.str.SRBusinessMethod = (string)value; break;							
						case "SRTariffType": this.str.SRTariffType = (string)value; break;							
						case "IsManageItem": this.str.IsManageItem = (string)value; break;							
						case "SRGuarantorRuleType": this.str.SRGuarantorRuleType = (string)value; break;							
						case "IsValueInPercent": this.str.IsValueInPercent = (string)value; break;							
						case "AmountValue": this.str.AmountValue = (string)value; break;							
						case "AdminPercentage": this.str.AdminPercentage = (string)value; break;							
						case "AdminAmountLimit": this.str.AdminAmountLimit = (string)value; break;							
						case "StreetName": this.str.StreetName = (string)value; break;							
						case "District": this.str.District = (string)value; break;							
						case "City": this.str.City = (string)value; break;							
						case "County": this.str.County = (string)value; break;							
						case "State": this.str.State = (string)value; break;							
						case "ZipCode": this.str.ZipCode = (string)value; break;							
						case "PhoneNo": this.str.PhoneNo = (string)value; break;							
						case "FaxNo": this.str.FaxNo = (string)value; break;							
						case "Email": this.str.Email = (string)value; break;							
						case "MobilePhoneNo": this.str.MobilePhoneNo = (string)value; break;							
						case "ChartOfAccountId": this.str.ChartOfAccountId = (string)value; break;							
						case "SubLedgerId": this.str.SubLedgerId = (string)value; break;							
						case "LastUpdateDateTime": this.str.LastUpdateDateTime = (string)value; break;							
						case "LastUpdateByUserID": this.str.LastUpdateByUserID = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "ContractStart":
						
							if (value == null || value is System.DateTime)
								this.ContractStart = (System.DateTime?)value;
							break;
						
						case "ContractEnd":
						
							if (value == null || value is System.DateTime)
								this.ContractEnd = (System.DateTime?)value;
							break;
						
						case "IsActive":
						
							if (value == null || value is System.Boolean)
								this.IsActive = (System.Boolean?)value;
							break;
						
						case "IsManageItem":
						
							if (value == null || value is System.Boolean)
								this.IsManageItem = (System.Boolean?)value;
							break;
						
						case "IsValueInPercent":
						
							if (value == null || value is System.Boolean)
								this.IsValueInPercent = (System.Boolean?)value;
							break;
						
						case "AmountValue":
						
							if (value == null || value is System.Decimal)
								this.AmountValue = (System.Decimal?)value;
							break;
						
						case "AdminPercentage":
						
							if (value == null || value is System.Decimal)
								this.AdminPercentage = (System.Decimal?)value;
							break;
						
						case "AdminAmountLimit":
						
							if (value == null || value is System.Decimal)
								this.AdminAmountLimit = (System.Decimal?)value;
							break;
						
						case "ChartOfAccountId":
						
							if (value == null || value is System.Int32)
								this.ChartOfAccountId = (System.Int32?)value;
							break;
						
						case "SubLedgerId":
						
							if (value == null || value is System.Int32)
								this.SubLedgerId = (System.Int32?)value;
							break;
						
						case "LastUpdateDateTime":
						
							if (value == null || value is System.DateTime)
								this.LastUpdateDateTime = (System.DateTime?)value;
							break;
					

						default:
							break;
					}
				}
			}
			else if(this.Row.Table.Columns.Contains(name))
			{
				this.Row[name] = value;
			}
			else
			{
				throw new Exception("SetProperty Error: '" + name + "' not found");
			}
		}
		
		
		/// <summary>
		/// Maps to Guarantor.GuarantorID
		/// </summary>
		virtual public System.String GuarantorID
		{
			get
			{
				return base.GetSystemString(GuarantorMetadata.ColumnNames.GuarantorID);
			}
			
			set
			{
				base.SetSystemString(GuarantorMetadata.ColumnNames.GuarantorID, value);
			}
		}
		
		/// <summary>
		/// Maps to Guarantor.GuarantorName
		/// </summary>
		virtual public System.String GuarantorName
		{
			get
			{
				return base.GetSystemString(GuarantorMetadata.ColumnNames.GuarantorName);
			}
			
			set
			{
				base.SetSystemString(GuarantorMetadata.ColumnNames.GuarantorName, value);
			}
		}
		
		/// <summary>
		/// Maps to Guarantor.ShortName
		/// </summary>
		virtual public System.String ShortName
		{
			get
			{
				return base.GetSystemString(GuarantorMetadata.ColumnNames.ShortName);
			}
			
			set
			{
				base.SetSystemString(GuarantorMetadata.ColumnNames.ShortName, value);
			}
		}
		
		/// <summary>
		/// Maps to Guarantor.SRGuarantorType
		/// </summary>
		virtual public System.String SRGuarantorType
		{
			get
			{
				return base.GetSystemString(GuarantorMetadata.ColumnNames.SRGuarantorType);
			}
			
			set
			{
				base.SetSystemString(GuarantorMetadata.ColumnNames.SRGuarantorType, value);
			}
		}
		
		/// <summary>
		/// Maps to Guarantor.ContractNumber
		/// </summary>
		virtual public System.String ContractNumber
		{
			get
			{
				return base.GetSystemString(GuarantorMetadata.ColumnNames.ContractNumber);
			}
			
			set
			{
				base.SetSystemString(GuarantorMetadata.ColumnNames.ContractNumber, value);
			}
		}
		
		/// <summary>
		/// Maps to Guarantor.ContractStart
		/// </summary>
		virtual public System.DateTime? ContractStart
		{
			get
			{
				return base.GetSystemDateTime(GuarantorMetadata.ColumnNames.ContractStart);
			}
			
			set
			{
				base.SetSystemDateTime(GuarantorMetadata.ColumnNames.ContractStart, value);
			}
		}
		
		/// <summary>
		/// Maps to Guarantor.ContractEnd
		/// </summary>
		virtual public System.DateTime? ContractEnd
		{
			get
			{
				return base.GetSystemDateTime(GuarantorMetadata.ColumnNames.ContractEnd);
			}
			
			set
			{
				base.SetSystemDateTime(GuarantorMetadata.ColumnNames.ContractEnd, value);
			}
		}
		
		/// <summary>
		/// Maps to Guarantor.ContractSummary
		/// </summary>
		virtual public System.String ContractSummary
		{
			get
			{
				return base.GetSystemString(GuarantorMetadata.ColumnNames.ContractSummary);
			}
			
			set
			{
				base.SetSystemString(GuarantorMetadata.ColumnNames.ContractSummary, value);
			}
		}
		
		/// <summary>
		/// Maps to Guarantor.ContactPerson
		/// </summary>
		virtual public System.String ContactPerson
		{
			get
			{
				return base.GetSystemString(GuarantorMetadata.ColumnNames.ContactPerson);
			}
			
			set
			{
				base.SetSystemString(GuarantorMetadata.ColumnNames.ContactPerson, value);
			}
		}
		
		/// <summary>
		/// Maps to Guarantor.IsActive
		/// </summary>
		virtual public System.Boolean? IsActive
		{
			get
			{
				return base.GetSystemBoolean(GuarantorMetadata.ColumnNames.IsActive);
			}
			
			set
			{
				base.SetSystemBoolean(GuarantorMetadata.ColumnNames.IsActive, value);
			}
		}
		
		/// <summary>
		/// Maps to Guarantor.SRBusinessMethod
		/// </summary>
		virtual public System.String SRBusinessMethod
		{
			get
			{
				return base.GetSystemString(GuarantorMetadata.ColumnNames.SRBusinessMethod);
			}
			
			set
			{
				base.SetSystemString(GuarantorMetadata.ColumnNames.SRBusinessMethod, value);
			}
		}
		
		/// <summary>
		/// Maps to Guarantor.SRTariffType
		/// </summary>
		virtual public System.String SRTariffType
		{
			get
			{
				return base.GetSystemString(GuarantorMetadata.ColumnNames.SRTariffType);
			}
			
			set
			{
				base.SetSystemString(GuarantorMetadata.ColumnNames.SRTariffType, value);
			}
		}
		
		/// <summary>
		/// Maps to Guarantor.IsManageItem
		/// </summary>
		virtual public System.Boolean? IsManageItem
		{
			get
			{
				return base.GetSystemBoolean(GuarantorMetadata.ColumnNames.IsManageItem);
			}
			
			set
			{
				base.SetSystemBoolean(GuarantorMetadata.ColumnNames.IsManageItem, value);
			}
		}
		
		/// <summary>
		/// Maps to Guarantor.SRGuarantorRuleType
		/// </summary>
		virtual public System.String SRGuarantorRuleType
		{
			get
			{
				return base.GetSystemString(GuarantorMetadata.ColumnNames.SRGuarantorRuleType);
			}
			
			set
			{
				base.SetSystemString(GuarantorMetadata.ColumnNames.SRGuarantorRuleType, value);
			}
		}
		
		/// <summary>
		/// Maps to Guarantor.IsValueInPercent
		/// </summary>
		virtual public System.Boolean? IsValueInPercent
		{
			get
			{
				return base.GetSystemBoolean(GuarantorMetadata.ColumnNames.IsValueInPercent);
			}
			
			set
			{
				base.SetSystemBoolean(GuarantorMetadata.ColumnNames.IsValueInPercent, value);
			}
		}
		
		/// <summary>
		/// Maps to Guarantor.AmountValue
		/// </summary>
		virtual public System.Decimal? AmountValue
		{
			get
			{
				return base.GetSystemDecimal(GuarantorMetadata.ColumnNames.AmountValue);
			}
			
			set
			{
				base.SetSystemDecimal(GuarantorMetadata.ColumnNames.AmountValue, value);
			}
		}
		
		/// <summary>
		/// Maps to Guarantor.AdminPercentage
		/// </summary>
		virtual public System.Decimal? AdminPercentage
		{
			get
			{
				return base.GetSystemDecimal(GuarantorMetadata.ColumnNames.AdminPercentage);
			}
			
			set
			{
				base.SetSystemDecimal(GuarantorMetadata.ColumnNames.AdminPercentage, value);
			}
		}
		
		/// <summary>
		/// Maps to Guarantor.AdminAmountLimit
		/// </summary>
		virtual public System.Decimal? AdminAmountLimit
		{
			get
			{
				return base.GetSystemDecimal(GuarantorMetadata.ColumnNames.AdminAmountLimit);
			}
			
			set
			{
				base.SetSystemDecimal(GuarantorMetadata.ColumnNames.AdminAmountLimit, value);
			}
		}
		
		/// <summary>
		/// Maps to Guarantor.StreetName
		/// </summary>
		virtual public System.String StreetName
		{
			get
			{
				return base.GetSystemString(GuarantorMetadata.ColumnNames.StreetName);
			}
			
			set
			{
				base.SetSystemString(GuarantorMetadata.ColumnNames.StreetName, value);
			}
		}
		
		/// <summary>
		/// Maps to Guarantor.District
		/// </summary>
		virtual public System.String District
		{
			get
			{
				return base.GetSystemString(GuarantorMetadata.ColumnNames.District);
			}
			
			set
			{
				base.SetSystemString(GuarantorMetadata.ColumnNames.District, value);
			}
		}
		
		/// <summary>
		/// Maps to Guarantor.City
		/// </summary>
		virtual public System.String City
		{
			get
			{
				return base.GetSystemString(GuarantorMetadata.ColumnNames.City);
			}
			
			set
			{
				base.SetSystemString(GuarantorMetadata.ColumnNames.City, value);
			}
		}
		
		/// <summary>
		/// Maps to Guarantor.County
		/// </summary>
		virtual public System.String County
		{
			get
			{
				return base.GetSystemString(GuarantorMetadata.ColumnNames.County);
			}
			
			set
			{
				base.SetSystemString(GuarantorMetadata.ColumnNames.County, value);
			}
		}
		
		/// <summary>
		/// Maps to Guarantor.State
		/// </summary>
		virtual public System.String State
		{
			get
			{
				return base.GetSystemString(GuarantorMetadata.ColumnNames.State);
			}
			
			set
			{
				base.SetSystemString(GuarantorMetadata.ColumnNames.State, value);
			}
		}
		
		/// <summary>
		/// Maps to Guarantor.ZipCode
		/// </summary>
		virtual public System.String ZipCode
		{
			get
			{
				return base.GetSystemString(GuarantorMetadata.ColumnNames.ZipCode);
			}
			
			set
			{
				base.SetSystemString(GuarantorMetadata.ColumnNames.ZipCode, value);
			}
		}
		
		/// <summary>
		/// Maps to Guarantor.PhoneNo
		/// </summary>
		virtual public System.String PhoneNo
		{
			get
			{
				return base.GetSystemString(GuarantorMetadata.ColumnNames.PhoneNo);
			}
			
			set
			{
				base.SetSystemString(GuarantorMetadata.ColumnNames.PhoneNo, value);
			}
		}
		
		/// <summary>
		/// Maps to Guarantor.FaxNo
		/// </summary>
		virtual public System.String FaxNo
		{
			get
			{
				return base.GetSystemString(GuarantorMetadata.ColumnNames.FaxNo);
			}
			
			set
			{
				base.SetSystemString(GuarantorMetadata.ColumnNames.FaxNo, value);
			}
		}
		
		/// <summary>
		/// Maps to Guarantor.Email
		/// </summary>
		virtual public System.String Email
		{
			get
			{
				return base.GetSystemString(GuarantorMetadata.ColumnNames.Email);
			}
			
			set
			{
				base.SetSystemString(GuarantorMetadata.ColumnNames.Email, value);
			}
		}
		
		/// <summary>
		/// Maps to Guarantor.MobilePhoneNo
		/// </summary>
		virtual public System.String MobilePhoneNo
		{
			get
			{
				return base.GetSystemString(GuarantorMetadata.ColumnNames.MobilePhoneNo);
			}
			
			set
			{
				base.SetSystemString(GuarantorMetadata.ColumnNames.MobilePhoneNo, value);
			}
		}
		
		/// <summary>
		/// Maps to Guarantor.ChartOfAccountId
		/// </summary>
		virtual public System.Int32? ChartOfAccountId
		{
			get
			{
				return base.GetSystemInt32(GuarantorMetadata.ColumnNames.ChartOfAccountId);
			}
			
			set
			{
				base.SetSystemInt32(GuarantorMetadata.ColumnNames.ChartOfAccountId, value);
			}
		}
		
		/// <summary>
		/// Maps to Guarantor.SubLedgerId
		/// </summary>
		virtual public System.Int32? SubLedgerId
		{
			get
			{
				return base.GetSystemInt32(GuarantorMetadata.ColumnNames.SubLedgerId);
			}
			
			set
			{
				base.SetSystemInt32(GuarantorMetadata.ColumnNames.SubLedgerId, value);
			}
		}
		
		/// <summary>
		/// Maps to Guarantor.LastUpdateDateTime
		/// </summary>
		virtual public System.DateTime? LastUpdateDateTime
		{
			get
			{
				return base.GetSystemDateTime(GuarantorMetadata.ColumnNames.LastUpdateDateTime);
			}
			
			set
			{
				base.SetSystemDateTime(GuarantorMetadata.ColumnNames.LastUpdateDateTime, value);
			}
		}
		
		/// <summary>
		/// Maps to Guarantor.LastUpdateByUserID
		/// </summary>
		virtual public System.String LastUpdateByUserID
		{
			get
			{
				return base.GetSystemString(GuarantorMetadata.ColumnNames.LastUpdateByUserID);
			}
			
			set
			{
				base.SetSystemString(GuarantorMetadata.ColumnNames.LastUpdateByUserID, value);
			}
		}
		
		#endregion	

		#region String Properties


		[BrowsableAttribute( false )]
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
			public esStrings(esGuarantor entity)
			{
				this.entity = entity;
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
				
			public System.String GuarantorName
			{
				get
				{
					System.String data = entity.GuarantorName;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.GuarantorName = null;
					else entity.GuarantorName = Convert.ToString(value);
				}
			}
				
			public System.String ShortName
			{
				get
				{
					System.String data = entity.ShortName;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.ShortName = null;
					else entity.ShortName = Convert.ToString(value);
				}
			}
				
			public System.String SRGuarantorType
			{
				get
				{
					System.String data = entity.SRGuarantorType;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.SRGuarantorType = null;
					else entity.SRGuarantorType = Convert.ToString(value);
				}
			}
				
			public System.String ContractNumber
			{
				get
				{
					System.String data = entity.ContractNumber;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.ContractNumber = null;
					else entity.ContractNumber = Convert.ToString(value);
				}
			}
				
			public System.String ContractStart
			{
				get
				{
					System.DateTime? data = entity.ContractStart;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.ContractStart = null;
					else entity.ContractStart = Convert.ToDateTime(value);
				}
			}
				
			public System.String ContractEnd
			{
				get
				{
					System.DateTime? data = entity.ContractEnd;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.ContractEnd = null;
					else entity.ContractEnd = Convert.ToDateTime(value);
				}
			}
				
			public System.String ContractSummary
			{
				get
				{
					System.String data = entity.ContractSummary;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.ContractSummary = null;
					else entity.ContractSummary = Convert.ToString(value);
				}
			}
				
			public System.String ContactPerson
			{
				get
				{
					System.String data = entity.ContactPerson;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.ContactPerson = null;
					else entity.ContactPerson = Convert.ToString(value);
				}
			}
				
			public System.String IsActive
			{
				get
				{
					System.Boolean? data = entity.IsActive;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.IsActive = null;
					else entity.IsActive = Convert.ToBoolean(value);
				}
			}
				
			public System.String SRBusinessMethod
			{
				get
				{
					System.String data = entity.SRBusinessMethod;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.SRBusinessMethod = null;
					else entity.SRBusinessMethod = Convert.ToString(value);
				}
			}
				
			public System.String SRTariffType
			{
				get
				{
					System.String data = entity.SRTariffType;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.SRTariffType = null;
					else entity.SRTariffType = Convert.ToString(value);
				}
			}
				
			public System.String IsManageItem
			{
				get
				{
					System.Boolean? data = entity.IsManageItem;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.IsManageItem = null;
					else entity.IsManageItem = Convert.ToBoolean(value);
				}
			}
				
			public System.String SRGuarantorRuleType
			{
				get
				{
					System.String data = entity.SRGuarantorRuleType;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.SRGuarantorRuleType = null;
					else entity.SRGuarantorRuleType = Convert.ToString(value);
				}
			}
				
			public System.String IsValueInPercent
			{
				get
				{
					System.Boolean? data = entity.IsValueInPercent;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.IsValueInPercent = null;
					else entity.IsValueInPercent = Convert.ToBoolean(value);
				}
			}
				
			public System.String AmountValue
			{
				get
				{
					System.Decimal? data = entity.AmountValue;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.AmountValue = null;
					else entity.AmountValue = Convert.ToDecimal(value);
				}
			}
				
			public System.String AdminPercentage
			{
				get
				{
					System.Decimal? data = entity.AdminPercentage;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.AdminPercentage = null;
					else entity.AdminPercentage = Convert.ToDecimal(value);
				}
			}
				
			public System.String AdminAmountLimit
			{
				get
				{
					System.Decimal? data = entity.AdminAmountLimit;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.AdminAmountLimit = null;
					else entity.AdminAmountLimit = Convert.ToDecimal(value);
				}
			}
				
			public System.String StreetName
			{
				get
				{
					System.String data = entity.StreetName;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.StreetName = null;
					else entity.StreetName = Convert.ToString(value);
				}
			}
				
			public System.String District
			{
				get
				{
					System.String data = entity.District;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.District = null;
					else entity.District = Convert.ToString(value);
				}
			}
				
			public System.String City
			{
				get
				{
					System.String data = entity.City;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.City = null;
					else entity.City = Convert.ToString(value);
				}
			}
				
			public System.String County
			{
				get
				{
					System.String data = entity.County;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.County = null;
					else entity.County = Convert.ToString(value);
				}
			}
				
			public System.String State
			{
				get
				{
					System.String data = entity.State;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.State = null;
					else entity.State = Convert.ToString(value);
				}
			}
				
			public System.String ZipCode
			{
				get
				{
					System.String data = entity.ZipCode;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.ZipCode = null;
					else entity.ZipCode = Convert.ToString(value);
				}
			}
				
			public System.String PhoneNo
			{
				get
				{
					System.String data = entity.PhoneNo;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.PhoneNo = null;
					else entity.PhoneNo = Convert.ToString(value);
				}
			}
				
			public System.String FaxNo
			{
				get
				{
					System.String data = entity.FaxNo;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.FaxNo = null;
					else entity.FaxNo = Convert.ToString(value);
				}
			}
				
			public System.String Email
			{
				get
				{
					System.String data = entity.Email;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Email = null;
					else entity.Email = Convert.ToString(value);
				}
			}
				
			public System.String MobilePhoneNo
			{
				get
				{
					System.String data = entity.MobilePhoneNo;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.MobilePhoneNo = null;
					else entity.MobilePhoneNo = Convert.ToString(value);
				}
			}
				
			public System.String ChartOfAccountId
			{
				get
				{
					System.Int32? data = entity.ChartOfAccountId;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.ChartOfAccountId = null;
					else entity.ChartOfAccountId = Convert.ToInt32(value);
				}
			}
				
			public System.String SubLedgerId
			{
				get
				{
					System.Int32? data = entity.SubLedgerId;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.SubLedgerId = null;
					else entity.SubLedgerId = Convert.ToInt32(value);
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
			

			private esGuarantor entity;
		}
		#endregion

		#region Query Logic
		protected void InitQuery(esGuarantorQuery query)
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
				throw new Exception("esGuarantor can only hold one record of data");
			}

			return dataFound;
		}
		#endregion
		
		[NonSerialized]
		private esStrings esstrings;
	}


	
	public partial class Guarantor : esGuarantor
	{

		
		/// <summary>
		/// Used internally by the entity's hierarchical properties.
		/// </summary>
		protected override List<esPropertyDescriptor> GetHierarchicalProperties()
		{
			List<esPropertyDescriptor> props = new List<esPropertyDescriptor>();
			
		
			return props;
		}	
		
		/// <summary>
		/// Used internally for retrieving AutoIncrementing keys
		/// during hierarchical PreSave.
		/// </summary>
		protected override void ApplyPreSaveKeys()
		{
		}
		
		/// <summary>
		/// Used internally for retrieving AutoIncrementing keys
		/// during hierarchical PostSave.
		/// </summary>
		protected override void ApplyPostSaveKeys()
		{
		}
		
		/// <summary>
		/// Used internally for retrieving AutoIncrementing keys
		/// during hierarchical PostOneToOneSave.
		/// </summary>
		protected override void ApplyPostOneSaveKeys()
		{
		}
		
	}



	[Serializable]
	abstract public class esGuarantorQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return GuarantorMetadata.Meta();
			}
		}	
		

		public esQueryItem GuarantorID
		{
			get
			{
				return new esQueryItem(this, GuarantorMetadata.ColumnNames.GuarantorID, esSystemType.String);
			}
		} 
		
		public esQueryItem GuarantorName
		{
			get
			{
				return new esQueryItem(this, GuarantorMetadata.ColumnNames.GuarantorName, esSystemType.String);
			}
		} 
		
		public esQueryItem ShortName
		{
			get
			{
				return new esQueryItem(this, GuarantorMetadata.ColumnNames.ShortName, esSystemType.String);
			}
		} 
		
		public esQueryItem SRGuarantorType
		{
			get
			{
				return new esQueryItem(this, GuarantorMetadata.ColumnNames.SRGuarantorType, esSystemType.String);
			}
		} 
		
		public esQueryItem ContractNumber
		{
			get
			{
				return new esQueryItem(this, GuarantorMetadata.ColumnNames.ContractNumber, esSystemType.String);
			}
		} 
		
		public esQueryItem ContractStart
		{
			get
			{
				return new esQueryItem(this, GuarantorMetadata.ColumnNames.ContractStart, esSystemType.DateTime);
			}
		} 
		
		public esQueryItem ContractEnd
		{
			get
			{
				return new esQueryItem(this, GuarantorMetadata.ColumnNames.ContractEnd, esSystemType.DateTime);
			}
		} 
		
		public esQueryItem ContractSummary
		{
			get
			{
				return new esQueryItem(this, GuarantorMetadata.ColumnNames.ContractSummary, esSystemType.String);
			}
		} 
		
		public esQueryItem ContactPerson
		{
			get
			{
				return new esQueryItem(this, GuarantorMetadata.ColumnNames.ContactPerson, esSystemType.String);
			}
		} 
		
		public esQueryItem IsActive
		{
			get
			{
				return new esQueryItem(this, GuarantorMetadata.ColumnNames.IsActive, esSystemType.Boolean);
			}
		} 
		
		public esQueryItem SRBusinessMethod
		{
			get
			{
				return new esQueryItem(this, GuarantorMetadata.ColumnNames.SRBusinessMethod, esSystemType.String);
			}
		} 
		
		public esQueryItem SRTariffType
		{
			get
			{
				return new esQueryItem(this, GuarantorMetadata.ColumnNames.SRTariffType, esSystemType.String);
			}
		} 
		
		public esQueryItem IsManageItem
		{
			get
			{
				return new esQueryItem(this, GuarantorMetadata.ColumnNames.IsManageItem, esSystemType.Boolean);
			}
		} 
		
		public esQueryItem SRGuarantorRuleType
		{
			get
			{
				return new esQueryItem(this, GuarantorMetadata.ColumnNames.SRGuarantorRuleType, esSystemType.String);
			}
		} 
		
		public esQueryItem IsValueInPercent
		{
			get
			{
				return new esQueryItem(this, GuarantorMetadata.ColumnNames.IsValueInPercent, esSystemType.Boolean);
			}
		} 
		
		public esQueryItem AmountValue
		{
			get
			{
				return new esQueryItem(this, GuarantorMetadata.ColumnNames.AmountValue, esSystemType.Decimal);
			}
		} 
		
		public esQueryItem AdminPercentage
		{
			get
			{
				return new esQueryItem(this, GuarantorMetadata.ColumnNames.AdminPercentage, esSystemType.Decimal);
			}
		} 
		
		public esQueryItem AdminAmountLimit
		{
			get
			{
				return new esQueryItem(this, GuarantorMetadata.ColumnNames.AdminAmountLimit, esSystemType.Decimal);
			}
		} 
		
		public esQueryItem StreetName
		{
			get
			{
				return new esQueryItem(this, GuarantorMetadata.ColumnNames.StreetName, esSystemType.String);
			}
		} 
		
		public esQueryItem District
		{
			get
			{
				return new esQueryItem(this, GuarantorMetadata.ColumnNames.District, esSystemType.String);
			}
		} 
		
		public esQueryItem City
		{
			get
			{
				return new esQueryItem(this, GuarantorMetadata.ColumnNames.City, esSystemType.String);
			}
		} 
		
		public esQueryItem County
		{
			get
			{
				return new esQueryItem(this, GuarantorMetadata.ColumnNames.County, esSystemType.String);
			}
		} 
		
		public esQueryItem State
		{
			get
			{
				return new esQueryItem(this, GuarantorMetadata.ColumnNames.State, esSystemType.String);
			}
		} 
		
		public esQueryItem ZipCode
		{
			get
			{
				return new esQueryItem(this, GuarantorMetadata.ColumnNames.ZipCode, esSystemType.String);
			}
		} 
		
		public esQueryItem PhoneNo
		{
			get
			{
				return new esQueryItem(this, GuarantorMetadata.ColumnNames.PhoneNo, esSystemType.String);
			}
		} 
		
		public esQueryItem FaxNo
		{
			get
			{
				return new esQueryItem(this, GuarantorMetadata.ColumnNames.FaxNo, esSystemType.String);
			}
		} 
		
		public esQueryItem Email
		{
			get
			{
				return new esQueryItem(this, GuarantorMetadata.ColumnNames.Email, esSystemType.String);
			}
		} 
		
		public esQueryItem MobilePhoneNo
		{
			get
			{
				return new esQueryItem(this, GuarantorMetadata.ColumnNames.MobilePhoneNo, esSystemType.String);
			}
		} 
		
		public esQueryItem ChartOfAccountId
		{
			get
			{
				return new esQueryItem(this, GuarantorMetadata.ColumnNames.ChartOfAccountId, esSystemType.Int32);
			}
		} 
		
		public esQueryItem SubLedgerId
		{
			get
			{
				return new esQueryItem(this, GuarantorMetadata.ColumnNames.SubLedgerId, esSystemType.Int32);
			}
		} 
		
		public esQueryItem LastUpdateDateTime
		{
			get
			{
				return new esQueryItem(this, GuarantorMetadata.ColumnNames.LastUpdateDateTime, esSystemType.DateTime);
			}
		} 
		
		public esQueryItem LastUpdateByUserID
		{
			get
			{
				return new esQueryItem(this, GuarantorMetadata.ColumnNames.LastUpdateByUserID, esSystemType.String);
			}
		} 
		
	}



    [System.Diagnostics.DebuggerDisplay("Count = {Count}")]
	[Serializable]
	[XmlType("GuarantorCollection")]
	public partial class GuarantorCollection : esGuarantorCollection, IEnumerable<Guarantor>
	{
		public GuarantorCollection()
		{

		}
		
		public static implicit operator List<Guarantor>(GuarantorCollection coll)
		{
			List<Guarantor> list = new List<Guarantor>();
			
			foreach (Guarantor emp in coll)
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
				return  GuarantorMetadata.Meta();
			}
		}
		
		
		
		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new GuarantorQuery();
				this.InitQuery(query);
			}
			return this.query;
		}
		
		override protected esEntity CreateEntityForCollection(DataRow row)
		{
			return new Guarantor(row);
		}

		override protected esEntity CreateEntity()
		{
			return new Guarantor();
		}
		
		
		#endregion


		[BrowsableAttribute( false )]
		public GuarantorQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new GuarantorQuery();
					base.InitQuery(this.query);
				}

				return this.query;
			}
		}

		public void QueryReset()
		{
			this.query = null;
		}

		public bool Load(GuarantorQuery query)
		{
			this.query = query;
			base.InitQuery(this.query);
			return this.Query.Load();
		}
		
		public Guarantor AddNew()
		{
			Guarantor entity = base.AddNewEntity() as Guarantor;
			
			return entity;
		}

		public Guarantor FindByPrimaryKey(System.String guarantorID)
		{
			return base.FindByPrimaryKey(guarantorID) as Guarantor;
		}


		#region IEnumerable<Guarantor> Members

		IEnumerator<Guarantor> IEnumerable<Guarantor>.GetEnumerator()
		{
			System.Collections.IEnumerable enumer = this as System.Collections.IEnumerable;
			System.Collections.IEnumerator iterator = enumer.GetEnumerator();

			while(iterator.MoveNext())
			{
				yield return iterator.Current as Guarantor;
			}
		}

		#endregion
		
		private GuarantorQuery query;
	}


	/// <summary>
	/// Encapsulates the 'Guarantor' table
	/// </summary>

    [System.Diagnostics.DebuggerDisplay("Guarantor ({GuarantorID})")]
	[Serializable]
	public partial class Guarantor : esGuarantor
	{
		public Guarantor()
		{

		}
	
		public Guarantor(DataRow row)
			: base(row)
		{

		}
		
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return GuarantorMetadata.Meta();
			}
		}
		
		
		
		override protected esGuarantorQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new GuarantorQuery();
				this.InitQuery(query);
			}
			return this.query;
		}
		#endregion
		



		[BrowsableAttribute( false )]
		public GuarantorQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new GuarantorQuery();
					base.InitQuery(this.query);
				}

				return this.query;
			}
		}

		public void QueryReset()
		{
			this.query = null;
		}
		

		public bool Load(GuarantorQuery query)
		{
			this.query = query;
			base.InitQuery(this.query);
			return this.Query.Load();
		}
		
		private GuarantorQuery query;
	}



    [System.Diagnostics.DebuggerDisplay("LastQuery = {es.LastQuery}")]
	[Serializable]
		
	public partial class GuarantorQuery : esGuarantorQuery
	{
		public GuarantorQuery()
		{

		}		
		
		public GuarantorQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

        override protected string GetQueryName()
        {
            return "GuarantorQuery";
        }
		
			
	}


	[Serializable]
	public partial class GuarantorMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected GuarantorMetadata()
		{
			_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(GuarantorMetadata.ColumnNames.GuarantorID, 0, typeof(System.String), esSystemType.String);
			c.PropertyName = GuarantorMetadata.PropertyNames.GuarantorID;
			c.IsInPrimaryKey = true;
			c.CharacterMaxLength = 10;
			c.HasDefault = true;
			c.Default = @"('')";
			_columns.Add(c);
				
			c = new esColumnMetadata(GuarantorMetadata.ColumnNames.GuarantorName, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = GuarantorMetadata.PropertyNames.GuarantorName;
			c.CharacterMaxLength = 100;
			c.HasDefault = true;
			c.Default = @"('')";
			_columns.Add(c);
				
			c = new esColumnMetadata(GuarantorMetadata.ColumnNames.ShortName, 2, typeof(System.String), esSystemType.String);
			c.PropertyName = GuarantorMetadata.PropertyNames.ShortName;
			c.CharacterMaxLength = 35;
			c.HasDefault = true;
			c.Default = @"('')";
			_columns.Add(c);
				
			c = new esColumnMetadata(GuarantorMetadata.ColumnNames.SRGuarantorType, 3, typeof(System.String), esSystemType.String);
			c.PropertyName = GuarantorMetadata.PropertyNames.SRGuarantorType;
			c.CharacterMaxLength = 20;
			c.HasDefault = true;
			c.Default = @"('')";
			_columns.Add(c);
				
			c = new esColumnMetadata(GuarantorMetadata.ColumnNames.ContractNumber, 4, typeof(System.String), esSystemType.String);
			c.PropertyName = GuarantorMetadata.PropertyNames.ContractNumber;
			c.CharacterMaxLength = 50;
			c.HasDefault = true;
			c.Default = @"('')";
			_columns.Add(c);
				
			c = new esColumnMetadata(GuarantorMetadata.ColumnNames.ContractStart, 5, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = GuarantorMetadata.PropertyNames.ContractStart;
			c.HasDefault = true;
			c.Default = @"(CONVERT([smalldatetime],'19000101',(105)))";
			c.IsNullable = true;
			_columns.Add(c);
				
			c = new esColumnMetadata(GuarantorMetadata.ColumnNames.ContractEnd, 6, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = GuarantorMetadata.PropertyNames.ContractEnd;
			c.HasDefault = true;
			c.Default = @"(CONVERT([smalldatetime],'19000101',(105)))";
			c.IsNullable = true;
			_columns.Add(c);
				
			c = new esColumnMetadata(GuarantorMetadata.ColumnNames.ContractSummary, 7, typeof(System.String), esSystemType.String);
			c.PropertyName = GuarantorMetadata.PropertyNames.ContractSummary;
			c.CharacterMaxLength = 2147483647;
			c.HasDefault = true;
			c.Default = @"('')";
			_columns.Add(c);
				
			c = new esColumnMetadata(GuarantorMetadata.ColumnNames.ContactPerson, 8, typeof(System.String), esSystemType.String);
			c.PropertyName = GuarantorMetadata.PropertyNames.ContactPerson;
			c.CharacterMaxLength = 100;
			c.HasDefault = true;
			c.Default = @"('')";
			_columns.Add(c);
				
			c = new esColumnMetadata(GuarantorMetadata.ColumnNames.IsActive, 9, typeof(System.Boolean), esSystemType.Boolean);
			c.PropertyName = GuarantorMetadata.PropertyNames.IsActive;
			c.HasDefault = true;
			c.Default = @"((1))";
			_columns.Add(c);
				
			c = new esColumnMetadata(GuarantorMetadata.ColumnNames.SRBusinessMethod, 10, typeof(System.String), esSystemType.String);
			c.PropertyName = GuarantorMetadata.PropertyNames.SRBusinessMethod;
			c.CharacterMaxLength = 20;
			c.HasDefault = true;
			c.Default = @"('')";
			_columns.Add(c);
				
			c = new esColumnMetadata(GuarantorMetadata.ColumnNames.SRTariffType, 11, typeof(System.String), esSystemType.String);
			c.PropertyName = GuarantorMetadata.PropertyNames.SRTariffType;
			c.CharacterMaxLength = 20;
			c.HasDefault = true;
			c.Default = @"('')";
			_columns.Add(c);
				
			c = new esColumnMetadata(GuarantorMetadata.ColumnNames.IsManageItem, 12, typeof(System.Boolean), esSystemType.Boolean);
			c.PropertyName = GuarantorMetadata.PropertyNames.IsManageItem;
			c.IsNullable = true;
			_columns.Add(c);
				
			c = new esColumnMetadata(GuarantorMetadata.ColumnNames.SRGuarantorRuleType, 13, typeof(System.String), esSystemType.String);
			c.PropertyName = GuarantorMetadata.PropertyNames.SRGuarantorRuleType;
			c.CharacterMaxLength = 20;
			c.IsNullable = true;
			_columns.Add(c);
				
			c = new esColumnMetadata(GuarantorMetadata.ColumnNames.IsValueInPercent, 14, typeof(System.Boolean), esSystemType.Boolean);
			c.PropertyName = GuarantorMetadata.PropertyNames.IsValueInPercent;
			c.HasDefault = true;
			c.Default = @"((0))";
			_columns.Add(c);
				
			c = new esColumnMetadata(GuarantorMetadata.ColumnNames.AmountValue, 15, typeof(System.Decimal), esSystemType.Decimal);
			c.PropertyName = GuarantorMetadata.PropertyNames.AmountValue;
			c.NumericPrecision = 18;
			c.NumericScale = 2;
			c.HasDefault = true;
			c.Default = @"((0))";
			_columns.Add(c);
				
			c = new esColumnMetadata(GuarantorMetadata.ColumnNames.AdminPercentage, 16, typeof(System.Decimal), esSystemType.Decimal);
			c.PropertyName = GuarantorMetadata.PropertyNames.AdminPercentage;
			c.NumericPrecision = 5;
			c.NumericScale = 2;
			c.HasDefault = true;
			c.Default = @"((0))";
			_columns.Add(c);
				
			c = new esColumnMetadata(GuarantorMetadata.ColumnNames.AdminAmountLimit, 17, typeof(System.Decimal), esSystemType.Decimal);
			c.PropertyName = GuarantorMetadata.PropertyNames.AdminAmountLimit;
			c.NumericPrecision = 18;
			c.NumericScale = 2;
			c.HasDefault = true;
			c.Default = @"((0))";
			_columns.Add(c);
				
			c = new esColumnMetadata(GuarantorMetadata.ColumnNames.StreetName, 18, typeof(System.String), esSystemType.String);
			c.PropertyName = GuarantorMetadata.PropertyNames.StreetName;
			c.CharacterMaxLength = 250;
			c.HasDefault = true;
			c.Default = @"('')";
			_columns.Add(c);
				
			c = new esColumnMetadata(GuarantorMetadata.ColumnNames.District, 19, typeof(System.String), esSystemType.String);
			c.PropertyName = GuarantorMetadata.PropertyNames.District;
			c.CharacterMaxLength = 20;
			c.HasDefault = true;
			c.Default = @"('')";
			_columns.Add(c);
				
			c = new esColumnMetadata(GuarantorMetadata.ColumnNames.City, 20, typeof(System.String), esSystemType.String);
			c.PropertyName = GuarantorMetadata.PropertyNames.City;
			c.CharacterMaxLength = 50;
			c.HasDefault = true;
			c.Default = @"('')";
			_columns.Add(c);
				
			c = new esColumnMetadata(GuarantorMetadata.ColumnNames.County, 21, typeof(System.String), esSystemType.String);
			c.PropertyName = GuarantorMetadata.PropertyNames.County;
			c.CharacterMaxLength = 50;
			c.HasDefault = true;
			c.Default = @"('')";
			_columns.Add(c);
				
			c = new esColumnMetadata(GuarantorMetadata.ColumnNames.State, 22, typeof(System.String), esSystemType.String);
			c.PropertyName = GuarantorMetadata.PropertyNames.State;
			c.CharacterMaxLength = 50;
			c.HasDefault = true;
			c.Default = @"('')";
			_columns.Add(c);
				
			c = new esColumnMetadata(GuarantorMetadata.ColumnNames.ZipCode, 23, typeof(System.String), esSystemType.String);
			c.PropertyName = GuarantorMetadata.PropertyNames.ZipCode;
			c.CharacterMaxLength = 15;
			c.IsNullable = true;
			_columns.Add(c);
				
			c = new esColumnMetadata(GuarantorMetadata.ColumnNames.PhoneNo, 24, typeof(System.String), esSystemType.String);
			c.PropertyName = GuarantorMetadata.PropertyNames.PhoneNo;
			c.CharacterMaxLength = 50;
			c.HasDefault = true;
			c.Default = @"('')";
			_columns.Add(c);
				
			c = new esColumnMetadata(GuarantorMetadata.ColumnNames.FaxNo, 25, typeof(System.String), esSystemType.String);
			c.PropertyName = GuarantorMetadata.PropertyNames.FaxNo;
			c.CharacterMaxLength = 50;
			c.HasDefault = true;
			c.Default = @"('')";
			_columns.Add(c);
				
			c = new esColumnMetadata(GuarantorMetadata.ColumnNames.Email, 26, typeof(System.String), esSystemType.String);
			c.PropertyName = GuarantorMetadata.PropertyNames.Email;
			c.CharacterMaxLength = 50;
			c.HasDefault = true;
			c.Default = @"('')";
			_columns.Add(c);
				
			c = new esColumnMetadata(GuarantorMetadata.ColumnNames.MobilePhoneNo, 27, typeof(System.String), esSystemType.String);
			c.PropertyName = GuarantorMetadata.PropertyNames.MobilePhoneNo;
			c.CharacterMaxLength = 20;
			c.HasDefault = true;
			c.Default = @"('')";
			_columns.Add(c);
				
			c = new esColumnMetadata(GuarantorMetadata.ColumnNames.ChartOfAccountId, 28, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = GuarantorMetadata.PropertyNames.ChartOfAccountId;
			c.NumericPrecision = 10;
			c.IsNullable = true;
			_columns.Add(c);
				
			c = new esColumnMetadata(GuarantorMetadata.ColumnNames.SubLedgerId, 29, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = GuarantorMetadata.PropertyNames.SubLedgerId;
			c.NumericPrecision = 10;
			c.IsNullable = true;
			_columns.Add(c);
				
			c = new esColumnMetadata(GuarantorMetadata.ColumnNames.LastUpdateDateTime, 30, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = GuarantorMetadata.PropertyNames.LastUpdateDateTime;
			c.IsNullable = true;
			_columns.Add(c);
				
			c = new esColumnMetadata(GuarantorMetadata.ColumnNames.LastUpdateByUserID, 31, typeof(System.String), esSystemType.String);
			c.PropertyName = GuarantorMetadata.PropertyNames.LastUpdateByUserID;
			c.CharacterMaxLength = 40;
			c.IsNullable = true;
			_columns.Add(c);
				
		}
		#endregion	
	
		static public GuarantorMetadata Meta()
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
			get	{ return base._columns; }
		}
		
		#region ColumnNames
		public class ColumnNames
		{ 
			 public const string GuarantorID = "GuarantorID";
			 public const string GuarantorName = "GuarantorName";
			 public const string ShortName = "ShortName";
			 public const string SRGuarantorType = "SRGuarantorType";
			 public const string ContractNumber = "ContractNumber";
			 public const string ContractStart = "ContractStart";
			 public const string ContractEnd = "ContractEnd";
			 public const string ContractSummary = "ContractSummary";
			 public const string ContactPerson = "ContactPerson";
			 public const string IsActive = "IsActive";
			 public const string SRBusinessMethod = "SRBusinessMethod";
			 public const string SRTariffType = "SRTariffType";
			 public const string IsManageItem = "IsManageItem";
			 public const string SRGuarantorRuleType = "SRGuarantorRuleType";
			 public const string IsValueInPercent = "IsValueInPercent";
			 public const string AmountValue = "AmountValue";
			 public const string AdminPercentage = "AdminPercentage";
			 public const string AdminAmountLimit = "AdminAmountLimit";
			 public const string StreetName = "StreetName";
			 public const string District = "District";
			 public const string City = "City";
			 public const string County = "County";
			 public const string State = "State";
			 public const string ZipCode = "ZipCode";
			 public const string PhoneNo = "PhoneNo";
			 public const string FaxNo = "FaxNo";
			 public const string Email = "Email";
			 public const string MobilePhoneNo = "MobilePhoneNo";
			 public const string ChartOfAccountId = "ChartOfAccountId";
			 public const string SubLedgerId = "SubLedgerId";
			 public const string LastUpdateDateTime = "LastUpdateDateTime";
			 public const string LastUpdateByUserID = "LastUpdateByUserID";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string GuarantorID = "GuarantorID";
			 public const string GuarantorName = "GuarantorName";
			 public const string ShortName = "ShortName";
			 public const string SRGuarantorType = "SRGuarantorType";
			 public const string ContractNumber = "ContractNumber";
			 public const string ContractStart = "ContractStart";
			 public const string ContractEnd = "ContractEnd";
			 public const string ContractSummary = "ContractSummary";
			 public const string ContactPerson = "ContactPerson";
			 public const string IsActive = "IsActive";
			 public const string SRBusinessMethod = "SRBusinessMethod";
			 public const string SRTariffType = "SRTariffType";
			 public const string IsManageItem = "IsManageItem";
			 public const string SRGuarantorRuleType = "SRGuarantorRuleType";
			 public const string IsValueInPercent = "IsValueInPercent";
			 public const string AmountValue = "AmountValue";
			 public const string AdminPercentage = "AdminPercentage";
			 public const string AdminAmountLimit = "AdminAmountLimit";
			 public const string StreetName = "StreetName";
			 public const string District = "District";
			 public const string City = "City";
			 public const string County = "County";
			 public const string State = "State";
			 public const string ZipCode = "ZipCode";
			 public const string PhoneNo = "PhoneNo";
			 public const string FaxNo = "FaxNo";
			 public const string Email = "Email";
			 public const string MobilePhoneNo = "MobilePhoneNo";
			 public const string ChartOfAccountId = "ChartOfAccountId";
			 public const string SubLedgerId = "SubLedgerId";
			 public const string LastUpdateDateTime = "LastUpdateDateTime";
			 public const string LastUpdateByUserID = "LastUpdateByUserID";
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
			lock (typeof(GuarantorMetadata))
			{
				if(GuarantorMetadata.mapDelegates == null)
				{
					GuarantorMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (GuarantorMetadata.meta == null)
				{
					GuarantorMetadata.meta = new GuarantorMetadata();
				}
				
				MapToMeta mapMethod = new MapToMeta(meta.esDefault);
				mapDelegates.Add("esDefault", mapMethod);
				mapMethod("esDefault");
			}
			return 0;
		}			

		private esProviderSpecificMetadata esDefault(string mapName)
		{
			if(!_providerMetadataMaps.ContainsKey(mapName))
			{
				esProviderSpecificMetadata meta = new esProviderSpecificMetadata();
				

				meta.AddTypeMap("GuarantorID", new esTypeMap("varchar", "System.String"));
				meta.AddTypeMap("GuarantorName", new esTypeMap("varchar", "System.String"));
				meta.AddTypeMap("ShortName", new esTypeMap("varchar", "System.String"));
				meta.AddTypeMap("SRGuarantorType", new esTypeMap("varchar", "System.String"));
				meta.AddTypeMap("ContractNumber", new esTypeMap("varchar", "System.String"));
				meta.AddTypeMap("ContractStart", new esTypeMap("smalldatetime", "System.DateTime"));
				meta.AddTypeMap("ContractEnd", new esTypeMap("smalldatetime", "System.DateTime"));
				meta.AddTypeMap("ContractSummary", new esTypeMap("text", "System.String"));
				meta.AddTypeMap("ContactPerson", new esTypeMap("varchar", "System.String"));
				meta.AddTypeMap("IsActive", new esTypeMap("bit", "System.Boolean"));
				meta.AddTypeMap("SRBusinessMethod", new esTypeMap("varchar", "System.String"));
				meta.AddTypeMap("SRTariffType", new esTypeMap("varchar", "System.String"));
				meta.AddTypeMap("IsManageItem", new esTypeMap("bit", "System.Boolean"));
				meta.AddTypeMap("SRGuarantorRuleType", new esTypeMap("varchar", "System.String"));
				meta.AddTypeMap("IsValueInPercent", new esTypeMap("bit", "System.Boolean"));
				meta.AddTypeMap("AmountValue", new esTypeMap("numeric", "System.Decimal"));
				meta.AddTypeMap("AdminPercentage", new esTypeMap("numeric", "System.Decimal"));
				meta.AddTypeMap("AdminAmountLimit", new esTypeMap("numeric", "System.Decimal"));
				meta.AddTypeMap("StreetName", new esTypeMap("varchar", "System.String"));
				meta.AddTypeMap("District", new esTypeMap("varchar", "System.String"));
				meta.AddTypeMap("City", new esTypeMap("varchar", "System.String"));
				meta.AddTypeMap("County", new esTypeMap("varchar", "System.String"));
				meta.AddTypeMap("State", new esTypeMap("varchar", "System.String"));
				meta.AddTypeMap("ZipCode", new esTypeMap("varchar", "System.String"));
				meta.AddTypeMap("PhoneNo", new esTypeMap("varchar", "System.String"));
				meta.AddTypeMap("FaxNo", new esTypeMap("varchar", "System.String"));
				meta.AddTypeMap("Email", new esTypeMap("varchar", "System.String"));
				meta.AddTypeMap("MobilePhoneNo", new esTypeMap("varchar", "System.String"));
				meta.AddTypeMap("ChartOfAccountId", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("SubLedgerId", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("LastUpdateDateTime", new esTypeMap("datetime", "System.DateTime"));
				meta.AddTypeMap("LastUpdateByUserID", new esTypeMap("varchar", "System.String"));			
				
				
				
				meta.Source = "Guarantor";
				meta.Destination = "Guarantor";
				
				meta.spInsert = "proc_GuarantorInsert";				
				meta.spUpdate = "proc_GuarantorUpdate";		
				meta.spDelete = "proc_GuarantorDelete";
				meta.spLoadAll = "proc_GuarantorLoadAll";
				meta.spLoadByPrimaryKey = "proc_GuarantorLoadByPrimaryKey";
				
				this._providerMetadataMaps["esDefault"] = meta;
			}
			
			return this._providerMetadataMaps["esDefault"];
		}

		#endregion

		static private GuarantorMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
