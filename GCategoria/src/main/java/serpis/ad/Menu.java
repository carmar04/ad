package serpis.ad;

import java.util.ArrayList;
import java.util.List;

import serpis.ad.CategoriaMain.Action;

public class Menu {
	
	public interface Action{
		void execute();
	}
	
	private static boolean exit = false;
	
	public static void create() {
		
	}
	
	public static void main(String[] args) {
		Menu.create("Menu principal")
		.exitWhen("0 . Salir")
		.add("1 - Nuevo", CategoriaMain::nuevo)
		.add("2 - Editar", CategoriaMain::editar)
		.loop();
	}
	
}
