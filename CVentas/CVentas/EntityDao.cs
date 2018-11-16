using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using MySql.Data.MySqlClient;

namespace Serpis.Ad
{

	public class EntityDao<TEntity>
	{
		protected string idPropertyName = "Id";
		protected Type entityType = typeof(TEntity);
		protected List<string> entityPropertyNames = new List<string>();


		public EntityDao()
		{
			foreach (PropertyInfo propertyInfo in entityType.GetProperties())
				if (propertyInfo.Name == idPropertyName)
					entityPropertyNames.Insert(0, idPropertyName);
				else
					entityPropertyNames.Add(propertyInfo.Name);
		}

		public IEnumerable Enumerable
        {
            get
            {
                ArrayList list = new ArrayList();
				IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand();
                string tableName = entityType.Name.ToLower();
                string fieldNameCsv = string.Join(",", entityPropertyNames).ToLower();
                string selectSql = string.Format("select {0} from {1} order by {2}", fieldNameCsv, tableName, idPropertyName.ToLower());
                entityType.GetProperties();
                dbCommand.CommandText = selectSql;
                IDataReader dataReader = dbCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    object model = Activator.CreateInstance<TEntity>();
                    foreach (string propertyName in entityPropertyNames)
                    {
                        object value = dataReader[propertyName.ToLower()];
                        if (value == DBNull.Value)
                            value = null;
                        entityType.GetProperty(propertyName).SetValue(model, value);
                    }
                    list.Add(model);
                }
                dataReader.Close();
                return list;
            }

        }
		private static string selectSql = "select * from {0} where {1} = @id";
			
		public TEntity Load(object id)
        {
            IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand();
            string tableName = entityType.Name.ToLower();
            dbCommand.CommandText = string.Format(selectSql, tableName, idPropertyName.ToLower());
            DbCommandHelper.AddParameter(dbCommand, "id", id);
            IDataReader dataReader = dbCommand.ExecuteReader();
            dataReader.Read();
            TEntity entity = Activator.CreateInstance<TEntity>();
            foreach (string propertyName in entityPropertyNames)
            {
                object value = dataReader[propertyName.ToLower()];
                if (value == DBNull.Value)
                    value = null;
                entityType.GetProperty(propertyName).SetValue(entity, value);
            }
            dataReader.Close();
            return entity;
        }

        public void Save(TEntity entity)
        {
            object id = entityType.GetProperty(idPropertyName).GetValue(entity);
            object defaultId = Activator.CreateInstance(entityType.GetProperty(idPropertyName).PropertyType);
            if (id.Equals(defaultId))
                Insert(entity);
            else
                Update(entity);
        }
		protected static string deleteSql = "delete from {0} where {1} = @id";
        public void Delete(Object id)
        {
			string tableName = entityType.Name.ToLower();
			IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand();
			dbCommand.CommandText = string.Format(deleteSql, tableName, idPropertyName.ToLower());
			DbCommandHelper.AddParameter(dbCommand, "id", id);
			dbCommand.ExecuteNonQuery();
        }
		protected static string insertSql = "insert into {0} ({1}) values ({2})";
        protected void Insert(TEntity entity)
        {
			IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand();
			List<string> insertFieldNames = new List<string>();
			List<string> parameterNames = new List<string>();

			insertFieldNames.ForEach(item => parameterNames.Add("@" + item));
			string tableName = entityType.Name.ToLower();
			string insertFieldNameCsv = string.Join(",", insertFieldNames).ToLower();
			string parameterNamesCsv = string.Join(", ", parameterNames).ToLower();
			dbCommand.CommandText = string.Format(insertSql, tableName, insertFieldNameCsv, parameterNamesCsv);

			foreach(string fieldName in insertFieldNames){
				object value = entityType.GetProperty(fieldName).GetValue(entity);
				DbCommandHelper.AddParameter(dbCommand, fieldName, value);
			}         
        }
        protected void Update(TEntity entity)
        {

        }
    }

}
