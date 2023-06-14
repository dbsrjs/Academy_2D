import java.util.Scanner;

public class Calc {

	public static void main(String[] args) {
		Scanner sc = new Scanner(System.in);
		int num1;
		int num2;
		
		System.out.println("num1");
		num1 = sc.nextInt();
		
		System.out.println("num2");
		num2 = sc.nextInt();
		
		System.out.println("+(1) -(2) *(3) /(4)");
		int op = sc.nextInt();
		
		switch (op) {
		case 1:
			System.out.println((num1 + " + " + num2) + " = " + (num1 + num2));
			break;
		case 2:
			System.out.println((num1 + " - " + num2) + " = " + (num1 - num2));
			break;
		case 3:
			System.out.println((num1 + " * " + num2) + " = " + (num1 * num2));
			break;
		case 4:
			System.out.println((num1 + " / " + num2) + " = " + (num1 / num2));
			break;
		}
	}

}
