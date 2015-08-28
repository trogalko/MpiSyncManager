/*
===============================================================================
                    EntitySpaces 2009 by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2009.2.1214.0
EntitySpaces Driver  : SQL
Date Generated       : 7/7/2014 10:00:05 AM
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
	abstract public class esMpiPayplanMappingCollection : esEntityCollection
	{
		public esMpiPayplanMappingCollection()
		{

		}

		protected override string GetCollectionName()
		{
			return "MpiPayplanMappingCollection";
		}

		#region Query Logic
		protected void InitQuery(esMpiPayplanMappingQuery query)
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
			this.InitQuery(query as esMpiPayplanMappingQuery);
		}
		#endregion
		
		virtual public MpiPayplanMapping DetachEntity(MpiPayplanMapping entity)
		{
			return base.DetachEntity(entity) as MpiPayplanMapping;
		}
		
		virtual public MpiPayplanMapping AttachEntity(MpiPayplanMapping entity)
		{
			return base.AttachEntity(entity) as MpiPayplanMapping;
		}
		
		virtual public void Combine(MpiPayplanMappingCollection collection)
		{
			base.Combine(collection);
		}
		
		new public MpiPayplanMapping this[int index]
		{
			get
			{
				return base[index] as MpiPayplanMapping;
			}
		}

		public override Type GetEntityType()
		{
			return typeof(MpiPayplanMapping);
		}
	}



	[Serializable]
	abstract public class esMpiPayplanMapping : esEntity
	{
		/// <summary>
		/// Used internally by the entity's DynamicQuery mechanism.
		/// </summary>
		virtual protected esMpiPayplanMappingQuery GetDynamicQuery()
		{
			return null;
		}

		public esMpiPayplanMapping()
		{

		}

		public esMpiPayplanMapping(DataRow row)
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
			esMpiPayplanMappingQuery query = this.GetDynamicQuery();
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
						case "PayplanId": this.str.PayplanId = (string)value; break;							
						case "PayplanNm": this.str.PayplanNm = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{

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
		/// Maps to MpiPayplanMapping.GuarantorID
		/// </summary>
		virtual public System.String GuarantorID
		{
			get
			{
				return base.GetSystemString(MpiPayplanMappingMetadata.ColumnNames.GuarantorID);
			}
			
			set
			{
				base.SetSystemString(MpiPayplanMappingMetadata.ColumnNames.GuarantorID, value);
			}
		}
		
		/// <summary>
		/// Maps to MpiPayplanMapping.GuarantorName
		/// </summary>
		virtual public System.String GuarantorName
		{
			get
			{
				return base.GetSystemString(MpiPayplanMappingMetadata.ColumnNames.GuarantorName);
			}
			
			set
			{
				base.SetSystemString(MpiPayplanMappingMetadata.ColumnNames.GuarantorName, value);
			}
		}
		
		/// <summary>
		/// Maps to MpiPayplanMapping.payplan_id
		/// </summary>
		virtual public System.String PayplanId
		{
			get
			{
				return base.GetSystemString(MpiPayplanMappingMetadata.ColumnNames.PayplanId);
			}
			
			set
			{
				base.SetSystemString(MpiPayplanMappingMetadata.ColumnNames.PayplanId, value);
			}
		}
		
		/// <summary>
		/// Maps to MpiPayplanMapping.payplan_nm
		/// </summary>
		virtual public System.String PayplanNm
		{
			get
			{
				return base.GetSystemString(MpiPayplanMappingMetadata.ColumnNames.PayplanNm);
			}
			
			set
			{
				base.SetSystemString(MpiPayplanMappingMetadata.ColumnNames.PayplanNm, value);
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
			public esStrings(esMpiPayplanMapping entity)
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
				
			public System.String PayplanId
			{
				get
				{
					System.String data = entity.PayplanId;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.PayplanId = null;
					else entity.PayplanId = Convert.ToString(value);
				}
			}
				
			public System.String PayplanNm
			{
				get
				{
					System.String data = entity.PayplanNm;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.PayplanNm = null;
					else entity.PayplanNm = Convert.ToString(value);
				}
			}
			

			private esMpiPayplanMapping entity;
		}
		#endregion

		#region Query Logic
		protected void InitQuery(esMpiPayplanMappingQuery query)
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
				throw new Exception("esMpiPayplanMapping can only hold one record of data");
			}

			return dataFound;
		}
		#endregion
		
		[NonSerialized]
		private esStrings esstrings;
	}


	
	public partial class MpiPayplanMapping : esMpiPayplanMapping
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
	abstract public class esMpiPayplanMappingQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return MpiPayplanMappingMetadata.Meta();
			}
		}	
		

		public esQueryItem GuarantorID
		{
			get
			{
				return new esQueryItem(this, MpiPayplanMappingMetadata.ColumnNames.GuarantorID, esSystemType.String);
			}
		} 
		
		public esQueryItem GuarantorName
		{
			get
			{
				return new esQueryItem(this, MpiPayplanMappingMetadata.ColumnNames.GuarantorName, esSystemType.String);
			}
		} 
		
		public esQueryItem PayplanId
		{
			get
			{
				return new esQueryItem(this, MpiPayplanMappingMetadata.ColumnNames.PayplanId, esSystemType.String);
			}
		} 
		
		public esQueryItem PayplanNm
		{
			get
			{
				return new esQueryItem(this, MpiPayplanMappingMetadata.ColumnNames.PayplanNm, esSystemType.String);
			}
		} 
		
	}



    [System.Diagnostics.DebuggerDisplay("Count = {Count}")]
	[Serializable]
	[XmlType("MpiPayplanMappingCollection")]
	public partial class MpiPayplanMappingCollection : esMpiPayplanMappingCollection, IEnumerable<MpiPayplanMapping>
	{
		public MpiPayplanMappingCollection()
		{

		}
		
		public static implicit operator List<MpiPayplanMapping>(MpiPayplanMappingCollection coll)
		{
			List<MpiPayplanMapping> list = new List<MpiPayplanMapping>();
			
			foreach (MpiPayplanMapping emp in coll)
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
				return  MpiPayplanMappingMetadata.Meta();
			}
		}
		
		
		
		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new MpiPayplanMappingQuery();
				this.InitQuery(query);
			}
			return this.query;
		}
		
		override protected esEntity CreateEntityForCollection(DataRow row)
		{
			return new MpiPayplanMapping(row);
		}

		override protected esEntity CreateEntity()
		{
			return new MpiPayplanMapping();
		}
		
		
		#endregion


		[BrowsableAttribute( false )]
		public MpiPayplanMappingQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new MpiPayplanMappingQuery();
					base.InitQuery(this.query);
				}

				return this.query;
			}
		}

		public void QueryReset()
		{
			this.query = null;
		}

		public bool Load(MpiPayplanMappingQuery query)
		{
			this.query = query;
			base.InitQuery(this.query);
			return this.Query.Load();
		}
		
		public MpiPayplanMapping AddNew()
		{
			MpiPayplanMapping entity = base.AddNewEntity() as MpiPayplanMapping;
			
			return entity;
		}

		public MpiPayplanMapping FindByPrimaryKey(System.String guarantorID)
		{
			return base.FindByPrimaryKey(guarantorID) as MpiPayplanMapping;
		}


		#region IEnumerable<MpiPayplanMapping> Members

		IEnumerator<MpiPayplanMapping> IEnumerable<MpiPayplanMapping>.GetEnumerator()
		{
			System.Collections.IEnumerable enumer = this as System.Collections.IEnumerable;
			System.Collections.IEnumerator iterator = enumer.GetEnumerator();

			while(iterator.MoveNext())
			{
				yield return iterator.Current as MpiPayplanMapping;
			}
		}

		#endregion
		
		private MpiPayplanMappingQuery query;
	}


	/// <summary>
	/// Encapsulates the 'MpiPayplanMapping' table
	/// </summary>

    [System.Diagnostics.DebuggerDisplay("MpiPayplanMapping ({GuarantorID})")]
	[Serializable]
	public partial class MpiPayplanMapping : esMpiPayplanMapping
	{
		public MpiPayplanMapping()
		{

		}
	
		public MpiPayplanMapping(DataRow row)
			: base(row)
		{

		}
		
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return MpiPayplanMappingMetadata.Meta();
			}
		}
		
		
		
		override protected esMpiPayplanMappingQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new MpiPayplanMappingQuery();
				this.InitQuery(query);
			}
			return this.query;
		}
		#endregion
		



		[BrowsableAttribute( false )]
		public MpiPayplanMappingQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new MpiPayplanMappingQuery();
					base.InitQuery(this.query);
				}

				return this.query;
			}
		}

		public void QueryReset()
		{
			this.query = null;
		}
		

		public bool Load(MpiPayplanMappingQuery query)
		{
			this.query = query;
			base.InitQuery(this.query);
			return this.Query.Load();
		}
		
		private MpiPayplanMappingQuery query;
	}



    [System.Diagnostics.DebuggerDisplay("LastQuery = {es.LastQuery}")]
	[Serializable]
		
	public partial class MpiPayplanMappingQuery : esMpiPayplanMappingQuery
	{
		public MpiPayplanMappingQuery()
		{

		}		
		
		public MpiPayplanMappingQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

        override protected string GetQueryName()
        {
            return "MpiPayplanMappingQuery";
        }
		
			
	}


	[Serializable]
	public partial class MpiPayplanMappingMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected MpiPayplanMappingMetadata()
		{
			_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(MpiPayplanMappingMetadata.ColumnNames.GuarantorID, 0, typeof(System.String), esSystemType.String);
			c.PropertyName = MpiPayplanMappingMetadata.PropertyNames.GuarantorID;
			c.IsInPrimaryKey = true;
			c.CharacterMaxLength = 10;
			_columns.Add(c);
				
			c = new esColumnMetadata(MpiPayplanMappingMetadata.ColumnNames.GuarantorName, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = MpiPayplanMappingMetadata.PropertyNames.GuarantorName;
			c.CharacterMaxLength = 100;
			_columns.Add(c);
				
			c = new esColumnMetadata(MpiPayplanMappingMetadata.ColumnNames.PayplanId, 2, typeof(System.String), esSystemType.String);
			c.PropertyName = MpiPayplanMappingMetadata.PropertyNames.PayplanId;
			c.CharacterMaxLength = 10;
			_columns.Add(c);
				
			c = new esColumnMetadata(MpiPayplanMappingMetadata.ColumnNames.PayplanNm, 3, typeof(System.String), esSystemType.String);
			c.PropertyName = MpiPayplanMappingMetadata.PropertyNames.PayplanNm;
			c.CharacterMaxLength = 255;
			_columns.Add(c);
				
		}
		#endregion	
	
		static public MpiPayplanMappingMetadata Meta()
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
			 public const string PayplanId = "payplan_id";
			 public const string PayplanNm = "payplan_nm";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string GuarantorID = "GuarantorID";
			 public const string GuarantorName = "GuarantorName";
			 public const string PayplanId = "PayplanId";
			 public const string PayplanNm = "PayplanNm";
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
			lock (typeof(MpiPayplanMappingMetadata))
			{
				if(MpiPayplanMappingMetadata.mapDelegates == null)
				{
					MpiPayplanMappingMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (MpiPayplanMappingMetadata.meta == null)
				{
					MpiPayplanMappingMetadata.meta = new MpiPayplanMappingMetadata();
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
				

				meta.AddTypeMap("GuarantorID", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("GuarantorName", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("PayplanId", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("PayplanNm", new esTypeMap("nvarchar", "System.String"));			
				
				
				
				meta.Source = "MpiPayplanMapping";
				meta.Destination = "MpiPayplanMapping";
				
				meta.spInsert = "proc_MpiPayplanMappingInsert";				
				meta.spUpdate = "proc_MpiPayplanMappingUpdate";		
				meta.spDelete = "proc_MpiPayplanMappingDelete";
				meta.spLoadAll = "proc_MpiPayplanMappingLoadAll";
				meta.spLoadByPrimaryKey = "proc_MpiPayplanMappingLoadByPrimaryKey";
				
				this._providerMetadataMaps["esDefault"] = meta;
			}
			
			return this._providerMetadataMaps["esDefault"];
		}

		#endregion

		static private MpiPayplanMappingMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
