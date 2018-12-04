package serpis.ad;

import java.sql.DriverManager;
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
		.loop();
		
	}

	public static void nuevo() {
		
	}
	public static void editar() {
		System.out.println("Metodo editar");
	}
}
