package serpis.ad;

import java.util.List;

public class CategoriaConsole {
	public static long getId() {
		System.out.println("Introduzca el id: ");
		return ScannerHelper.getLong();
	}
	public static void newCategoria(Categoria categoria) {
		System.out.println("Introduzca el nombre de la categoria: ");
		categoria.setNombre(ScannerHelper.getString());
	}
	public static void editCategoria(Categoria categoria) {
		System.out.println("Introduzca el nombre de la categoria: ");
		categoria.setNombre(ScannerHelper.getString());
	}
	public static void idNotExists() {
		System.out.println("La categoria no puede ser eliminada");
	}
	public static boolean deleteConfirm() {
		System.out.println("Esta seguro que desea eliminar esta categoria?");
		if(ScannerHelper.getString().equalsIgnoreCase("si")) {
			return true;
		}
		return false;
	}
	public static void show(Categoria categoria) {
		System.out.println("Id: " + categoria.getId() + " Nombre: " + categoria.getNombre());
	}
	public static void showList(List<Categoria> categorias ) {
		for (Categoria categoria : categorias) {
			System.out.println("Id: " + categoria.getId() + " Nombre: " +  categoria.getNombre());
		}
	}
}
