package serpis.ad;

import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class CategoriaMain {
	public static void main(String[] args) throws SQLException {
		
		String connectionSql = "jdbc:mysql://localhost/dbprueba?user=root&password=sistemas";
		
		App.getInstance().setConnection(DriverManager.getConnection(connectionSql));

			Menu.create("Menu principal")
			.exitWhen("0 . Salir")
			.add("1 - Nuevo", CategoriaMain::nuevo)
			.add("2 - Editar", CategoriaMain::editar)
			.add("3 - Eliminar", CategoriaMain::eliminar)
			.loop();

		
	}
	private static String insertSql = "insert into categoria (nombre) values (?)";
	public static void nuevo() {
		try {
			String nombre = "categoria";
			String nombreSql = ScannerHelper.getString();
			Categoria categoria = new Categoria();
			categoria.setNombre(nombreSql);
			PreparedStatement preparedStatement = App.getInstance().getConnection().prepareStatement(insertSql);
			preparedStatement.setString(1, categoria.getNombre());
			preparedStatement.execute();
		} catch (SQLException e) {
			System.out.println("Error al añadir la nueva categoria");
			e.printStackTrace();
		}
		
	}
	private static String selectAllSql = "select * from categoria";
	
	private static String selectSql = "select id from categoria where id=?";
	public static long mostrar() {
		long id = 0;
		try {
			System.out.println("Introduzca el id: ");
			id = ScannerHelper.getLong();
			PreparedStatement preparedStatement = App.getInstance().getConnection().prepareStatement(selectSql);
			preparedStatement.setLong(1, id);
			ResultSet rs = preparedStatement.executeQuery();
			while(rs.next()) {
				id = rs.getLong("id");
			}
		} catch (SQLException e) {
			System.out.println("Error al seleccionar una categoria");
			e.printStackTrace();
		}
		return id;
	}
	private static String updateSql = "update categoria set nombre=? where id=?";
	public static void editar() {
		try {
			Categoria categoria = new Categoria();
			PreparedStatement preparedStatement = App.getInstance().getConnection().prepareStatement(selectSql);
			categoria.setId(mostrar());
			System.out.println("Introduzca el nuevo nombre de la categoria");
			categoria.setNombre(ScannerHelper.getString());
			
			preparedStatement = App.getInstance().getConnection().prepareStatement(updateSql);
			preparedStatement.setString(1, categoria.getNombre() );
			preparedStatement.setLong(2, categoria.getId());
			preparedStatement.execute();
			
		}catch(SQLException e) {
			System.out.println("Error al editar una categoria");
		}
	}
	private static String deleteSql = "delete from categoria where id=?";
	public static void eliminar() {
		try {
			Categoria categoria = new Categoria();
			categoria.setId(mostrar());
			PreparedStatement preparedStatement = App.getInstance().getConnection().prepareStatement(deleteSql);
			preparedStatement.setLong(1, categoria.getId());
			preparedStatement.execute();
		} catch (SQLException e) {
			System.out.println("Error al eliminar una categoria");
			e.printStackTrace();
		}
	}
}
