package serpis.ad;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;

public class App {
	
	private static App instance = new App();
	
	public static App getInstance() {
		return instance;
	}
	private Connection connection;
	
	public void setConnection(Connection connection) {
		this.connection = connection;
	}
	public Connection getConnection() {
		return connection;
	}
}
		

