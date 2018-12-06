package serpis.ad;

import java.math.BigDecimal;
import java.util.Scanner;

public class ScannerHelper {
	private static Scanner scanner = new Scanner(System.in);

	public static int getInt(String label) {
		while (true) {
			System.out.print(label);
			String intString = scanner.nextLine();
			try {
				return Integer.parseInt(intString);
			} catch (NumberFormatException ex) {
				System.out.println("Formato inválido. Vuelve a introducir.");
			}
		}
	}
	
	public static BigDecimal getBigDecimal(String label) {
		while (true) {
			System.out.print(label);
			String bigDecimalString = scanner.nextLine();
			try {
				return new BigDecimal(bigDecimalString);
			} catch (NumberFormatException ex) {
				System.out.println("Formato inválido. Vuelve a introducir.");
			}
		}
	}
	public static String getString() {
		while(true) {
			String labelString = scanner.nextLine();
			try {
				return new String(labelString);
			}catch(NumberFormatException ex) {
				System.out.println("Formato inválido. Vuelve a introducir.");
			}
		}
	}
	public static Long getLong() {
		while(true) {
			String labelLong = scanner.nextLine();
			try {
				return new Long(labelLong);
			}catch(NumberFormatException ex) {
				System.out.println("Formato inválido. Vuelve a introducir.");
			}
			
		}
	}
}
