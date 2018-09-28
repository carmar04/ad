using System;
using System.Data;

namespace Serpis.Ad
{
    public class App
    {
        private App() {
        }

		private static App instance = new App(); //solo se crea una instancia del objeto = singleton

		public static App Instance { //con mayusculas debido a que es public "Instance"
			get { return instance; }
		}

		private IDbConnection dbConnection;

		public IDbConnection DbConnection {
			get { return dbConnection; }
			set { dbConnection = value; }
		}
    }
}
