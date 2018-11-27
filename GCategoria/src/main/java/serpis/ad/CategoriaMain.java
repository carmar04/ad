package serpis.ad;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class CategoriaMain {
	
	@FunctionalInterface
	public interface Action{
		void execute();
	}
	public static class Menu {
		Scanner tcl = new Scanner(System.in);
		List<String> labels = new ArrayList<>();
		List<Action> actions = new ArrayList<>();
		List<String> options = new ArrayList<>();
		private boolean exit = false;
		private String labelMenu;
		
		public static Menu create(String labelMenu) {
			return new Menu(labelMenu);
		}
		public Menu add(String label, Action action) {
			String option = label.trim().substring(0, 1).toUpperCase();
			options.add(option);
			labels.add(label);
			actions.add(action);
			return this;
		}
		public Menu exitWhen(String label) {
			return add(label,  () -> exit = true);
		}
		public void loop() {
			while(!exit) {
				String mensaje = showLabels();
				System.out.println(mensaje);
				System.out.println("Introduzca la opción: ");
				int option = Integer.parseInt(tcl.nextLine());
				actions.get(option).execute();
			}
		}
		private String showLabels() {
			String mensaje = "";
			for (String label : labels) {
				mensaje += label+"\n";
			}
			return mensaje;
		}
		
		private Menu(String labelMenu) {
			this.labelMenu = labelMenu;
		}
	}
	private static boolean exit = false;
	public static void main(String[] args) {
		Menu.create("Menu principal")
		.exitWhen("0 . Salir")
		.add("1 - Nuevo", CategoriaMain::nuevo)
		.add("2 - Editar", CategoriaMain::editar)
		.loop();
		
		Scanner tcl = new Scanner(System.in);
		List<Action> actions = new ArrayList<>();

		actions.add( () -> exit = true);
		actions.add( CategoriaMain::nuevo);
		actions.add( CategoriaMain::editar);
		
		while(!exit) {
			System.out.println(" 0.- Salir \n 1.- Nuevo \n 2.- Editar");
			int option = Integer.parseInt(tcl.nextLine());
			actions.get(option).execute();
		}
		for (Action action : actions) {
			action.execute();
		}
		
	}

	public static void nuevo() {
		System.out.println("Metodo nuevo");
	}
	public static void editar() {
		System.out.println("Metodo editar");
	}
}
