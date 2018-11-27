package serpis.ad;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.time.LocalDateTime;


public class Prueba {

	public static void main(String[] args) throws SQLException {
		
		String connectionSql = "jdbc:mysql://localhost/dbprueba?user=root&password=sistemas";
		
		App.getInstance().setConnection(DriverManager.getConnection(connectionSql));
						
 		App.getInstance().getConnection();
		
		Statement statement = App.getInstance().getConnection().createStatement();
		insert();
		ResultSet resultSet = statement.executeQuery("select * from categoria");
		
		while(resultSet.next()) {
			System.out.printf("%s %s\n", resultSet.getObject(1), resultSet.getObject(2));
		}
		statement.close();
		App.getInstance().getConnection().close();
		
	}
	private static void insert() throws SQLException {
		String insertSql = "insert into categoria (nombre) values (?)";
		PreparedStatement preparedStatement = App.getInstance().getConnection().prepareStatement(insertSql);
		preparedStatement.setObject(1, "categoria " + LocalDateTime.now());
		preparedStatement.executeUpdate();
		preparedStatement.close();
	}
	private static void update() throws SQLException {
		String updateSql = "update categoria set (nombre) where id=?";
		PreparedStatement preparedStatement = App.getInstance().getConnection().prepareStatement(updateSql);
		preparedStatement.setObject(1, "categoria");
	}
}
