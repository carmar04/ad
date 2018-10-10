﻿using System;
using System.Data;
using System.Collections.Generic;
using Serpis.Ad;
namespace CCategoria
{
    public class CategoriaDao
    {
		private static string selectAll = "select id, nombre from categoria order by id";
		public static IList<Categoria> Categorias {
			get {
				List<Categoria> categorias = new List<Categoria>();
				IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand();
				dbCommand.CommandText = selectAll;

				IDataReader dataReader = dbCommand.ExecuteReader();
				while(dataReader.Read()){
					categorias.Add(new Categoria((ulong)dataReader["id"], (string)dataReader["nombre"]));
				}
				dataReader.Close();
				return categorias;
			}
		}
		private static string selectSql = "select id, nombre from categoria where id = @id";
		public static Categoria Load(object id){
			IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand();
			dbCommand.CommandText = selectSql;
			DbCommandHelper.AddParameter(dbCommand, "id", id);
			IDataReader dataReader = dbCommand.ExecuteReader();
			dataReader.Read();
            Categoria categoria = new Categoria((ulong)id, (string)dataReader["nombre"]);
			dataReader.Close();
			return categoria;

		}
		private static string insertSql = "insert into categoria (nombre) values (@nombre)";
		public static void Save(Categoria categoria){
			insert(categoria);
		}
		private static void insert(Categoria categoria){
			IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand();
			dbCommand.CommandText = insertSql;
			DbCommandHelper.AddParameter(dbCommand, "nombre", categoria.Nombre);
			dbCommand.ExecuteNonQuery();
		}
    }
}