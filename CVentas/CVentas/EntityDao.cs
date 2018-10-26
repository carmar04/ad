﻿using System.Collections.Generic;
using System.Collections;
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
                        entityType.GetProperty(propertyName).SetValue(model, value);
                    }
                    list.Add(model);
                }
                dataReader.Close();
                return list;
            }

        }

    }

}
