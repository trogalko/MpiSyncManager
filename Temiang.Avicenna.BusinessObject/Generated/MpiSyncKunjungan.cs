/*
===============================================================================
                    EntitySpaces 2009 by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2009.2.1214.0
EntitySpaces Driver  : SQL
Date Generated       : 6/4/2015 9:40:44 AM
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
	abstract public class esMpiSyncKunjunganCollection : esEntityCollection
	{
		public esMpiSyncKunjunganCollection()
		{

		}

		protected override string GetCollectionName()
		{
			return "MpiSyncKunjunganCollection";
		}

		#region Query Logic
		protected void InitQuery(esMpiSyncKunjunganQuery query)
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
			this.InitQuery(query as esMpiSyncKunjunganQuery);
		}
		#endregion
		
		virtual public MpiSyncKunjungan DetachEntity(MpiSyncKunjungan entity)
		{
			return base.DetachEntity(entity) as MpiSyncKunjungan;
		}
		
		virtual public MpiSyncKunjungan AttachEntity(MpiSyncKunjungan entity)
		{
			return base.AttachEntity(entity) as MpiSyncKunjungan;
		}
		
		virtual public void Combine(MpiSyncKunjunganCollection collection)
		{
			base.Combine(collection);
		}
		
		new public MpiSyncKunjungan this[int index]
		{
			get
			{
				return base[index] as MpiSyncKunjungan;
			}
		}

		public override Type GetEntityType()
		{
			return typeof(MpiSyncKunjungan);
		}
	}



	[Serializable]
	abstract public class esMpiSyncKunjungan : esEntity
	{
		/// <summary>
		/// Used internally by the entity's DynamicQuery mechanism.
		/// </summary>
		virtual protected esMpiSyncKunjunganQuery GetDynamicQuery()
		{
			return null;
		}

		public esMpiSyncKunjungan()
		{

		}

		public esMpiSyncKunjungan(DataRow row)
			: base(row)
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.String registrationNo, System.String patientID)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(registrationNo, patientID);
			else
				return LoadByPrimaryKeyStoredProcedure(registrationNo, patientID);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.String registrationNo, System.String patientID)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(registrationNo, patientID);
			else
				return LoadByPrimaryKeyStoredProcedure(registrationNo, patientID);
		}

		private bool LoadByPrimaryKeyDynamic(System.String registrationNo, System.String patientID)
		{
			esMpiSyncKunjunganQuery query = this.GetDynamicQuery();
			query.Where(query.RegistrationNo == registrationNo, query.PatientID == patientID);
			return query.Load();
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.String registrationNo, System.String patientID)
		{
			esParameters parms = new esParameters();
			parms.Add("RegistrationNo",registrationNo);			parms.Add("PatientID",patientID);
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
						case "RegistrationNo": this.str.RegistrationNo = (string)value; break;							
						case "PatientID": this.str.PatientID = (string)value; break;							
						case "MedicalNo": this.str.MedicalNo = (string)value; break;							
						case "AdmissionID": this.str.AdmissionID = (string)value; break;							
						case "MpiPatientID": this.str.MpiPatientID = (string)value; break;							
						case "IsNewKunjungan": this.str.IsNewKunjungan = (string)value; break;							
						case "IsEditedKunjungan": this.str.IsEditedKunjungan = (string)value; break;							
						case "IsDischarged": this.str.IsDischarged = (string)value; break;							
						case "IsClosed": this.str.IsClosed = (string)value; break;							
						case "IsSkipped": this.str.IsSkipped = (string)value; break;							
						case "CreatedByUser": this.str.CreatedByUser = (string)value; break;							
						case "CreatedDateTime": this.str.CreatedDateTime = (string)value; break;							
						case "LastUpdatedByUser": this.str.LastUpdatedByUser = (string)value; break;							
						case "LastUpdatedDateTime": this.str.LastUpdatedDateTime = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "IsNewKunjungan":
						
							if (value == null || value is System.Boolean)
								this.IsNewKunjungan = (System.Boolean?)value;
							break;
						
						case "IsEditedKunjungan":
						
							if (value == null || value is System.Boolean)
								this.IsEditedKunjungan = (System.Boolean?)value;
							break;
						
						case "IsDischarged":
						
							if (value == null || value is System.Boolean)
								this.IsDischarged = (System.Boolean?)value;
							break;
						
						case "IsClosed":
						
							if (value == null || value is System.Boolean)
								this.IsClosed = (System.Boolean?)value;
							break;
						
						case "IsSkipped":
						
							if (value == null || value is System.Boolean)
								this.IsSkipped = (System.Boolean?)value;
							break;
						
						case "CreatedDateTime":
						
							if (value == null || value is System.DateTime)
								this.CreatedDateTime = (System.DateTime?)value;
							break;
						
						case "LastUpdatedDateTime":
						
							if (value == null || value is System.DateTime)
								this.LastUpdatedDateTime = (System.DateTime?)value;
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
		/// Maps to MpiSyncKunjungan.RegistrationNo
		/// </summary>
		virtual public System.String RegistrationNo
		{
			get
			{
				return base.GetSystemString(MpiSyncKunjunganMetadata.ColumnNames.RegistrationNo);
			}
			
			set
			{
				base.SetSystemString(MpiSyncKunjunganMetadata.ColumnNames.RegistrationNo, value);
			}
		}
		
		/// <summary>
		/// Maps to MpiSyncKunjungan.PatientID
		/// </summary>
		virtual public System.String PatientID
		{
			get
			{
				return base.GetSystemString(MpiSyncKunjunganMetadata.ColumnNames.PatientID);
			}
			
			set
			{
				base.SetSystemString(MpiSyncKunjunganMetadata.ColumnNames.PatientID, value);
			}
		}
		
		/// <summary>
		/// Maps to MpiSyncKunjungan.MedicalNo
		/// </summary>
		virtual public System.String MedicalNo
		{
			get
			{
				return base.GetSystemString(MpiSyncKunjunganMetadata.ColumnNames.MedicalNo);
			}
			
			set
			{
				base.SetSystemString(MpiSyncKunjunganMetadata.ColumnNames.MedicalNo, value);
			}
		}
		
		/// <summary>
		/// Maps to MpiSyncKunjungan.AdmissionID
		/// </summary>
		virtual public System.String AdmissionID
		{
			get
			{
				return base.GetSystemString(MpiSyncKunjunganMetadata.ColumnNames.AdmissionID);
			}
			
			set
			{
				base.SetSystemString(MpiSyncKunjunganMetadata.ColumnNames.AdmissionID, value);
			}
		}
		
		/// <summary>
		/// Maps to MpiSyncKunjungan.MpiPatientID
		/// </summary>
		virtual public System.String MpiPatientID
		{
			get
			{
				return base.GetSystemString(MpiSyncKunjunganMetadata.ColumnNames.MpiPatientID);
			}
			
			set
			{
				base.SetSystemString(MpiSyncKunjunganMetadata.ColumnNames.MpiPatientID, value);
			}
		}
		
		/// <summary>
		/// Maps to MpiSyncKunjungan.IsNewKunjungan
		/// </summary>
		virtual public System.Boolean? IsNewKunjungan
		{
			get
			{
				return base.GetSystemBoolean(MpiSyncKunjunganMetadata.ColumnNames.IsNewKunjungan);
			}
			
			set
			{
				base.SetSystemBoolean(MpiSyncKunjunganMetadata.ColumnNames.IsNewKunjungan, value);
			}
		}
		
		/// <summary>
		/// Maps to MpiSyncKunjungan.IsEditedKunjungan
		/// </summary>
		virtual public System.Boolean? IsEditedKunjungan
		{
			get
			{
				return base.GetSystemBoolean(MpiSyncKunjunganMetadata.ColumnNames.IsEditedKunjungan);
			}
			
			set
			{
				base.SetSystemBoolean(MpiSyncKunjunganMetadata.ColumnNames.IsEditedKunjungan, value);
			}
		}
		
		/// <summary>
		/// Maps to MpiSyncKunjungan.IsDischarged
		/// </summary>
		virtual public System.Boolean? IsDischarged
		{
			get
			{
				return base.GetSystemBoolean(MpiSyncKunjunganMetadata.ColumnNames.IsDischarged);
			}
			
			set
			{
				base.SetSystemBoolean(MpiSyncKunjunganMetadata.ColumnNames.IsDischarged, value);
			}
		}
		
		/// <summary>
		/// Maps to MpiSyncKunjungan.IsClosed
		/// </summary>
		virtual public System.Boolean? IsClosed
		{
			get
			{
				return base.GetSystemBoolean(MpiSyncKunjunganMetadata.ColumnNames.IsClosed);
			}
			
			set
			{
				base.SetSystemBoolean(MpiSyncKunjunganMetadata.ColumnNames.IsClosed, value);
			}
		}
		
		/// <summary>
		/// Maps to MpiSyncKunjungan.IsSkipped
		/// </summary>
		virtual public System.Boolean? IsSkipped
		{
			get
			{
				return base.GetSystemBoolean(MpiSyncKunjunganMetadata.ColumnNames.IsSkipped);
			}
			
			set
			{
				base.SetSystemBoolean(MpiSyncKunjunganMetadata.ColumnNames.IsSkipped, value);
			}
		}
		
		/// <summary>
		/// Maps to MpiSyncKunjungan.CreatedByUser
		/// </summary>
		virtual public System.String CreatedByUser
		{
			get
			{
				return base.GetSystemString(MpiSyncKunjunganMetadata.ColumnNames.CreatedByUser);
			}
			
			set
			{
				base.SetSystemString(MpiSyncKunjunganMetadata.ColumnNames.CreatedByUser, value);
			}
		}
		
		/// <summary>
		/// Maps to MpiSyncKunjungan.CreatedDateTime
		/// </summary>
		virtual public System.DateTime? CreatedDateTime
		{
			get
			{
				return base.GetSystemDateTime(MpiSyncKunjunganMetadata.ColumnNames.CreatedDateTime);
			}
			
			set
			{
				base.SetSystemDateTime(MpiSyncKunjunganMetadata.ColumnNames.CreatedDateTime, value);
			}
		}
		
		/// <summary>
		/// Maps to MpiSyncKunjungan.LastUpdatedByUser
		/// </summary>
		virtual public System.String LastUpdatedByUser
		{
			get
			{
				return base.GetSystemString(MpiSyncKunjunganMetadata.ColumnNames.LastUpdatedByUser);
			}
			
			set
			{
				base.SetSystemString(MpiSyncKunjunganMetadata.ColumnNames.LastUpdatedByUser, value);
			}
		}
		
		/// <summary>
		/// Maps to MpiSyncKunjungan.LastUpdatedDateTime
		/// </summary>
		virtual public System.DateTime? LastUpdatedDateTime
		{
			get
			{
				return base.GetSystemDateTime(MpiSyncKunjunganMetadata.ColumnNames.LastUpdatedDateTime);
			}
			
			set
			{
				base.SetSystemDateTime(MpiSyncKunjunganMetadata.ColumnNames.LastUpdatedDateTime, value);
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
			public esStrings(esMpiSyncKunjungan entity)
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
				
			public System.String MedicalNo
			{
				get
				{
					System.String data = entity.MedicalNo;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.MedicalNo = null;
					else entity.MedicalNo = Convert.ToString(value);
				}
			}
				
			public System.String AdmissionID
			{
				get
				{
					System.String data = entity.AdmissionID;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.AdmissionID = null;
					else entity.AdmissionID = Convert.ToString(value);
				}
			}
				
			public System.String MpiPatientID
			{
				get
				{
					System.String data = entity.MpiPatientID;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.MpiPatientID = null;
					else entity.MpiPatientID = Convert.ToString(value);
				}
			}
				
			public System.String IsNewKunjungan
			{
				get
				{
					System.Boolean? data = entity.IsNewKunjungan;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.IsNewKunjungan = null;
					else entity.IsNewKunjungan = Convert.ToBoolean(value);
				}
			}
				
			public System.String IsEditedKunjungan
			{
				get
				{
					System.Boolean? data = entity.IsEditedKunjungan;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.IsEditedKunjungan = null;
					else entity.IsEditedKunjungan = Convert.ToBoolean(value);
				}
			}
				
			public System.String IsDischarged
			{
				get
				{
					System.Boolean? data = entity.IsDischarged;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.IsDischarged = null;
					else entity.IsDischarged = Convert.ToBoolean(value);
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
				
			public System.String IsSkipped
			{
				get
				{
					System.Boolean? data = entity.IsSkipped;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.IsSkipped = null;
					else entity.IsSkipped = Convert.ToBoolean(value);
				}
			}
				
			public System.String CreatedByUser
			{
				get
				{
					System.String data = entity.CreatedByUser;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.CreatedByUser = null;
					else entity.CreatedByUser = Convert.ToString(value);
				}
			}
				
			public System.String CreatedDateTime
			{
				get
				{
					System.DateTime? data = entity.CreatedDateTime;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.CreatedDateTime = null;
					else entity.CreatedDateTime = Convert.ToDateTime(value);
				}
			}
				
			public System.String LastUpdatedByUser
			{
				get
				{
					System.String data = entity.LastUpdatedByUser;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.LastUpdatedByUser = null;
					else entity.LastUpdatedByUser = Convert.ToString(value);
				}
			}
				
			public System.String LastUpdatedDateTime
			{
				get
				{
					System.DateTime? data = entity.LastUpdatedDateTime;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.LastUpdatedDateTime = null;
					else entity.LastUpdatedDateTime = Convert.ToDateTime(value);
				}
			}
			

			private esMpiSyncKunjungan entity;
		}
		#endregion

		#region Query Logic
		protected void InitQuery(esMpiSyncKunjunganQuery query)
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
				throw new Exception("esMpiSyncKunjungan can only hold one record of data");
			}

			return dataFound;
		}
		#endregion
		
		[NonSerialized]
		private esStrings esstrings;
	}


	
	public partial class MpiSyncKunjungan : esMpiSyncKunjungan
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
	abstract public class esMpiSyncKunjunganQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return MpiSyncKunjunganMetadata.Meta();
			}
		}	
		

		public esQueryItem RegistrationNo
		{
			get
			{
				return new esQueryItem(this, MpiSyncKunjunganMetadata.ColumnNames.RegistrationNo, esSystemType.String);
			}
		} 
		
		public esQueryItem PatientID
		{
			get
			{
				return new esQueryItem(this, MpiSyncKunjunganMetadata.ColumnNames.PatientID, esSystemType.String);
			}
		} 
		
		public esQueryItem MedicalNo
		{
			get
			{
				return new esQueryItem(this, MpiSyncKunjunganMetadata.ColumnNames.MedicalNo, esSystemType.String);
			}
		} 
		
		public esQueryItem AdmissionID
		{
			get
			{
				return new esQueryItem(this, MpiSyncKunjunganMetadata.ColumnNames.AdmissionID, esSystemType.String);
			}
		} 
		
		public esQueryItem MpiPatientID
		{
			get
			{
				return new esQueryItem(this, MpiSyncKunjunganMetadata.ColumnNames.MpiPatientID, esSystemType.String);
			}
		} 
		
		public esQueryItem IsNewKunjungan
		{
			get
			{
				return new esQueryItem(this, MpiSyncKunjunganMetadata.ColumnNames.IsNewKunjungan, esSystemType.Boolean);
			}
		} 
		
		public esQueryItem IsEditedKunjungan
		{
			get
			{
				return new esQueryItem(this, MpiSyncKunjunganMetadata.ColumnNames.IsEditedKunjungan, esSystemType.Boolean);
			}
		} 
		
		public esQueryItem IsDischarged
		{
			get
			{
				return new esQueryItem(this, MpiSyncKunjunganMetadata.ColumnNames.IsDischarged, esSystemType.Boolean);
			}
		} 
		
		public esQueryItem IsClosed
		{
			get
			{
				return new esQueryItem(this, MpiSyncKunjunganMetadata.ColumnNames.IsClosed, esSystemType.Boolean);
			}
		} 
		
		public esQueryItem IsSkipped
		{
			get
			{
				return new esQueryItem(this, MpiSyncKunjunganMetadata.ColumnNames.IsSkipped, esSystemType.Boolean);
			}
		} 
		
		public esQueryItem CreatedByUser
		{
			get
			{
				return new esQueryItem(this, MpiSyncKunjunganMetadata.ColumnNames.CreatedByUser, esSystemType.String);
			}
		} 
		
		public esQueryItem CreatedDateTime
		{
			get
			{
				return new esQueryItem(this, MpiSyncKunjunganMetadata.ColumnNames.CreatedDateTime, esSystemType.DateTime);
			}
		} 
		
		public esQueryItem LastUpdatedByUser
		{
			get
			{
				return new esQueryItem(this, MpiSyncKunjunganMetadata.ColumnNames.LastUpdatedByUser, esSystemType.String);
			}
		} 
		
		public esQueryItem LastUpdatedDateTime
		{
			get
			{
				return new esQueryItem(this, MpiSyncKunjunganMetadata.ColumnNames.LastUpdatedDateTime, esSystemType.DateTime);
			}
		} 
		
	}



    [System.Diagnostics.DebuggerDisplay("Count = {Count}")]
	[Serializable]
	[XmlType("MpiSyncKunjunganCollection")]
	public partial class MpiSyncKunjunganCollection : esMpiSyncKunjunganCollection, IEnumerable<MpiSyncKunjungan>
	{
		public MpiSyncKunjunganCollection()
		{

		}
		
		public static implicit operator List<MpiSyncKunjungan>(MpiSyncKunjunganCollection coll)
		{
			List<MpiSyncKunjungan> list = new List<MpiSyncKunjungan>();
			
			foreach (MpiSyncKunjungan emp in coll)
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
				return  MpiSyncKunjunganMetadata.Meta();
			}
		}
		
		
		
		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new MpiSyncKunjunganQuery();
				this.InitQuery(query);
			}
			return this.query;
		}
		
		override protected esEntity CreateEntityForCollection(DataRow row)
		{
			return new MpiSyncKunjungan(row);
		}

		override protected esEntity CreateEntity()
		{
			return new MpiSyncKunjungan();
		}
		
		
		#endregion


		[BrowsableAttribute( false )]
		public MpiSyncKunjunganQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new MpiSyncKunjunganQuery();
					base.InitQuery(this.query);
				}

				return this.query;
			}
		}

		public void QueryReset()
		{
			this.query = null;
		}

		public bool Load(MpiSyncKunjunganQuery query)
		{
			this.query = query;
			base.InitQuery(this.query);
			return this.Query.Load();
		}
		
		public MpiSyncKunjungan AddNew()
		{
			MpiSyncKunjungan entity = base.AddNewEntity() as MpiSyncKunjungan;
			
			return entity;
		}

		public MpiSyncKunjungan FindByPrimaryKey(System.String registrationNo, System.String patientID)
		{
			return base.FindByPrimaryKey(registrationNo, patientID) as MpiSyncKunjungan;
		}


		#region IEnumerable<MpiSyncKunjungan> Members

		IEnumerator<MpiSyncKunjungan> IEnumerable<MpiSyncKunjungan>.GetEnumerator()
		{
			System.Collections.IEnumerable enumer = this as System.Collections.IEnumerable;
			System.Collections.IEnumerator iterator = enumer.GetEnumerator();

			while(iterator.MoveNext())
			{
				yield return iterator.Current as MpiSyncKunjungan;
			}
		}

		#endregion
		
		private MpiSyncKunjunganQuery query;
	}


	/// <summary>
	/// Encapsulates the 'MpiSyncKunjungan' table
	/// </summary>

    [System.Diagnostics.DebuggerDisplay("MpiSyncKunjungan ({RegistrationNo},{PatientID})")]
	[Serializable]
	public partial class MpiSyncKunjungan : esMpiSyncKunjungan
	{
		public MpiSyncKunjungan()
		{

		}
	
		public MpiSyncKunjungan(DataRow row)
			: base(row)
		{

		}
		
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return MpiSyncKunjunganMetadata.Meta();
			}
		}
		
		
		
		override protected esMpiSyncKunjunganQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new MpiSyncKunjunganQuery();
				this.InitQuery(query);
			}
			return this.query;
		}
		#endregion
		



		[BrowsableAttribute( false )]
		public MpiSyncKunjunganQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new MpiSyncKunjunganQuery();
					base.InitQuery(this.query);
				}

				return this.query;
			}
		}

		public void QueryReset()
		{
			this.query = null;
		}
		

		public bool Load(MpiSyncKunjunganQuery query)
		{
			this.query = query;
			base.InitQuery(this.query);
			return this.Query.Load();
		}
		
		private MpiSyncKunjunganQuery query;
	}



    [System.Diagnostics.DebuggerDisplay("LastQuery = {es.LastQuery}")]
	[Serializable]
		
	public partial class MpiSyncKunjunganQuery : esMpiSyncKunjunganQuery
	{
		public MpiSyncKunjunganQuery()
		{

		}		
		
		public MpiSyncKunjunganQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

        override protected string GetQueryName()
        {
            return "MpiSyncKunjunganQuery";
        }
		
			
	}


	[Serializable]
	public partial class MpiSyncKunjunganMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected MpiSyncKunjunganMetadata()
		{
			_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(MpiSyncKunjunganMetadata.ColumnNames.RegistrationNo, 0, typeof(System.String), esSystemType.String);
			c.PropertyName = MpiSyncKunjunganMetadata.PropertyNames.RegistrationNo;
			c.IsInPrimaryKey = true;
			c.CharacterMaxLength = 20;
			_columns.Add(c);
				
			c = new esColumnMetadata(MpiSyncKunjunganMetadata.ColumnNames.PatientID, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = MpiSyncKunjunganMetadata.PropertyNames.PatientID;
			c.IsInPrimaryKey = true;
			c.CharacterMaxLength = 15;
			_columns.Add(c);
				
			c = new esColumnMetadata(MpiSyncKunjunganMetadata.ColumnNames.MedicalNo, 2, typeof(System.String), esSystemType.String);
			c.PropertyName = MpiSyncKunjunganMetadata.PropertyNames.MedicalNo;
			c.CharacterMaxLength = 15;
			_columns.Add(c);
				
			c = new esColumnMetadata(MpiSyncKunjunganMetadata.ColumnNames.AdmissionID, 3, typeof(System.String), esSystemType.String);
			c.PropertyName = MpiSyncKunjunganMetadata.PropertyNames.AdmissionID;
			c.CharacterMaxLength = 3;
			c.IsNullable = true;
			_columns.Add(c);
				
			c = new esColumnMetadata(MpiSyncKunjunganMetadata.ColumnNames.MpiPatientID, 4, typeof(System.String), esSystemType.String);
			c.PropertyName = MpiSyncKunjunganMetadata.PropertyNames.MpiPatientID;
			c.CharacterMaxLength = 15;
			c.IsNullable = true;
			_columns.Add(c);
				
			c = new esColumnMetadata(MpiSyncKunjunganMetadata.ColumnNames.IsNewKunjungan, 5, typeof(System.Boolean), esSystemType.Boolean);
			c.PropertyName = MpiSyncKunjunganMetadata.PropertyNames.IsNewKunjungan;
			c.HasDefault = true;
			c.Default = @"((0))";
			_columns.Add(c);
				
			c = new esColumnMetadata(MpiSyncKunjunganMetadata.ColumnNames.IsEditedKunjungan, 6, typeof(System.Boolean), esSystemType.Boolean);
			c.PropertyName = MpiSyncKunjunganMetadata.PropertyNames.IsEditedKunjungan;
			c.HasDefault = true;
			c.Default = @"((0))";
			_columns.Add(c);
				
			c = new esColumnMetadata(MpiSyncKunjunganMetadata.ColumnNames.IsDischarged, 7, typeof(System.Boolean), esSystemType.Boolean);
			c.PropertyName = MpiSyncKunjunganMetadata.PropertyNames.IsDischarged;
			c.HasDefault = true;
			c.Default = @"((0))";
			_columns.Add(c);
				
			c = new esColumnMetadata(MpiSyncKunjunganMetadata.ColumnNames.IsClosed, 8, typeof(System.Boolean), esSystemType.Boolean);
			c.PropertyName = MpiSyncKunjunganMetadata.PropertyNames.IsClosed;
			c.HasDefault = true;
			c.Default = @"((0))";
			_columns.Add(c);
				
			c = new esColumnMetadata(MpiSyncKunjunganMetadata.ColumnNames.IsSkipped, 9, typeof(System.Boolean), esSystemType.Boolean);
			c.PropertyName = MpiSyncKunjunganMetadata.PropertyNames.IsSkipped;
			c.HasDefault = true;
			c.Default = @"((0))";
			_columns.Add(c);
				
			c = new esColumnMetadata(MpiSyncKunjunganMetadata.ColumnNames.CreatedByUser, 10, typeof(System.String), esSystemType.String);
			c.PropertyName = MpiSyncKunjunganMetadata.PropertyNames.CreatedByUser;
			c.CharacterMaxLength = 40;
			c.IsNullable = true;
			_columns.Add(c);
				
			c = new esColumnMetadata(MpiSyncKunjunganMetadata.ColumnNames.CreatedDateTime, 11, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = MpiSyncKunjunganMetadata.PropertyNames.CreatedDateTime;
			c.IsNullable = true;
			_columns.Add(c);
				
			c = new esColumnMetadata(MpiSyncKunjunganMetadata.ColumnNames.LastUpdatedByUser, 12, typeof(System.String), esSystemType.String);
			c.PropertyName = MpiSyncKunjunganMetadata.PropertyNames.LastUpdatedByUser;
			c.CharacterMaxLength = 40;
			c.IsNullable = true;
			_columns.Add(c);
				
			c = new esColumnMetadata(MpiSyncKunjunganMetadata.ColumnNames.LastUpdatedDateTime, 13, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = MpiSyncKunjunganMetadata.PropertyNames.LastUpdatedDateTime;
			c.IsNullable = true;
			_columns.Add(c);
				
		}
		#endregion	
	
		static public MpiSyncKunjunganMetadata Meta()
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
			 public const string RegistrationNo = "RegistrationNo";
			 public const string PatientID = "PatientID";
			 public const string MedicalNo = "MedicalNo";
			 public const string AdmissionID = "AdmissionID";
			 public const string MpiPatientID = "MpiPatientID";
			 public const string IsNewKunjungan = "IsNewKunjungan";
			 public const string IsEditedKunjungan = "IsEditedKunjungan";
			 public const string IsDischarged = "IsDischarged";
			 public const string IsClosed = "IsClosed";
			 public const string IsSkipped = "IsSkipped";
			 public const string CreatedByUser = "CreatedByUser";
			 public const string CreatedDateTime = "CreatedDateTime";
			 public const string LastUpdatedByUser = "LastUpdatedByUser";
			 public const string LastUpdatedDateTime = "LastUpdatedDateTime";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string RegistrationNo = "RegistrationNo";
			 public const string PatientID = "PatientID";
			 public const string MedicalNo = "MedicalNo";
			 public const string AdmissionID = "AdmissionID";
			 public const string MpiPatientID = "MpiPatientID";
			 public const string IsNewKunjungan = "IsNewKunjungan";
			 public const string IsEditedKunjungan = "IsEditedKunjungan";
			 public const string IsDischarged = "IsDischarged";
			 public const string IsClosed = "IsClosed";
			 public const string IsSkipped = "IsSkipped";
			 public const string CreatedByUser = "CreatedByUser";
			 public const string CreatedDateTime = "CreatedDateTime";
			 public const string LastUpdatedByUser = "LastUpdatedByUser";
			 public const string LastUpdatedDateTime = "LastUpdatedDateTime";
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
			lock (typeof(MpiSyncKunjunganMetadata))
			{
				if(MpiSyncKunjunganMetadata.mapDelegates == null)
				{
					MpiSyncKunjunganMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (MpiSyncKunjunganMetadata.meta == null)
				{
					MpiSyncKunjunganMetadata.meta = new MpiSyncKunjunganMetadata();
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
				

				meta.AddTypeMap("RegistrationNo", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("PatientID", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("MedicalNo", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("AdmissionID", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("MpiPatientID", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("IsNewKunjungan", new esTypeMap("bit", "System.Boolean"));
				meta.AddTypeMap("IsEditedKunjungan", new esTypeMap("bit", "System.Boolean"));
				meta.AddTypeMap("IsDischarged", new esTypeMap("bit", "System.Boolean"));
				meta.AddTypeMap("IsClosed", new esTypeMap("bit", "System.Boolean"));
				meta.AddTypeMap("IsSkipped", new esTypeMap("bit", "System.Boolean"));
				meta.AddTypeMap("CreatedByUser", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("CreatedDateTime", new esTypeMap("datetime", "System.DateTime"));
				meta.AddTypeMap("LastUpdatedByUser", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("LastUpdatedDateTime", new esTypeMap("datetime", "System.DateTime"));			
				
				
				
				meta.Source = "MpiSyncKunjungan";
				meta.Destination = "MpiSyncKunjungan";
				
				meta.spInsert = "proc_MpiSyncKunjunganInsert";				
				meta.spUpdate = "proc_MpiSyncKunjunganUpdate";		
				meta.spDelete = "proc_MpiSyncKunjunganDelete";
				meta.spLoadAll = "proc_MpiSyncKunjunganLoadAll";
				meta.spLoadByPrimaryKey = "proc_MpiSyncKunjunganLoadByPrimaryKey";
				
				this._providerMetadataMaps["esDefault"] = meta;
			}
			
			return this._providerMetadataMaps["esDefault"];
		}

		#endregion

		static private MpiSyncKunjunganMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
