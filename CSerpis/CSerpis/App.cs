using System;
using System.Data;

namespace Serpis.Ad
{
    public class App
    {
        private App() {
        }

		private static App instance = new App(); //solo se crea una instancia del objeto = singleton

		public static App Instance { //Inicialización perezosa
			get {
				if (instance == null){
					instance = new App();
				}
                return instance; }
		}

		private IDbConnection dbConnection;

		public IDbConnection DbConnection {
			get { return dbConnection; }
			set { dbConnection = value; }
		}
    }
}
