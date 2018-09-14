using System;
using MySql.Data.MySqlClient;
using System.Data;

namespace CMySql
{
    class MainClass
    {
		private static string[] getFieldNames(IDataReader dataReader){
			int aux = dataReader.FieldCount;
			for (int i = 0; i < aux; i++)
            {
				dataReader.GetName(int i);
				string cadena += ;
            }
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
			dbCommand.CommandText = "select * from categoria order by id";
			IDataReader dataReader = dbCommand.ExecuteReader();
			dataReader.get
			while(dataReader.Read()){
				Console.WriteLine("id={0} nombre={1}", dataReader["id"], dataReader["nombre"]);
			}
			dataReader.Close();

			dbConnection.Close();
        }
    }
}
