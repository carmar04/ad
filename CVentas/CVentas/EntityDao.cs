using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
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

        public TEntity load(object id)
        {
            return default(TEntity);
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
		protected static string deleteSql  ="delete from {0} where {1} = @id"
        public void Delete(Object id)
        {
			string tableName = entityType.Name.ToLower();
			IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand();
			dbCommand.CommandText = string.Format(deleteSql, tableName, idPropertyName.ToLower());
			DbCommandHelper.AddParameter(dbCommand, "id", id);
			dbCommand.ExecuteNonQuery();

            
            
        }
        protected void Insert(TEntity entity)
        {

        }
        protected void Update(TEntity entity)
        {

        }
    }

}
