using Calculator;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.Write("Nombre 1 : ");
        int number1 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Operateur (+ , - , * , /): ");
        string calc = Console.ReadLine();

        Console.Write("Nombre 2 : ");
        int number2 = Convert.ToInt32(Console.ReadLine());

        IOperation operation = null;
        switch (calc)
        {
            case "+":
                operation = new Add(number1, number2);
                break;
            case "-":
                operation = new Sub(number1, number2);
                break;
            case "*":
                operation = new Mult(number1, number2);
                break;
            case "/":
                operation = new Div(number1, number2);
                break;
            default:
                Console.WriteLine("Error!");
                break;
        }
        Console.WriteLine("Le résultat de {0} {1} {2} est : {3}", number1, calc, number2, operation.calc());


    }
}