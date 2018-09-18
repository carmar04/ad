using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;

namespace CMySql
{
    class MainClass
    {
		private static string[] getFieldNames(IDataReader dataReader){
			//int fieldCount = dataReader.FieldCount;
			//string [] fieldNames = new string[fieldCount];
			//for (int index = 0; index < fieldCount; index++)
			//{
			//fieldNames.SetValue(dataReader.GetName(index), index);
			//}
			//return fieldNames;
			List<string> fieldNamelist = new List<string>();
			int fieldCount = dataReader.FieldCount;
			for (int index = 0; index < dataReader.FieldCount;index++){
				fieldNamelist.Add(dataReader.GetName(index));
			}
			return fieldNamelist.ToArray();
		}
        public static void Main(string[] args)
        {
			IDbConnection dbConnection = new MySqlConnection(
				"server=localhost;" +
				"database=dbprueba;" +
				"user=root;" +
				"password=sistemas;" +
				"ssl-mode=none;"
			);
			dbConnection.Open();
			IDbCommand dbCommand = dbConnection.CreateCommand();
			dbCommand.CommandText = "select id, nombre from categoria order by id";
			IDataReader dataReader = dbCommand.ExecuteReader();
			Console.WriteLine("Numero de columnas= "+dataReader.FieldCount);

			for (int index = 0; index < dataReader.FieldCount;index++){
//				Console.WriteLine("Columna {0} = {1}", index, dataReader.GetName(index));
				Console.Write("Columna:"+getFieldNames(dataReader)[index]+" ");
			}
			Console.WriteLine();
			while(dataReader.Read()){
				Console.WriteLine("id={0} nombre={1}", dataReader["id"], dataReader["nombre"]);
			}
			dataReader.Close();

			dbConnection.Close();
        }
    }
}
