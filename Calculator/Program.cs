using Calculator;
using System;
using System.Linq;
using System.Reflection.Metadata;

internal class Program
{
    private static void Main(string[] args)
    {

        using var db = new CalcDbContext();

        float number1 = 0;
        float number2 = 0;

        while (true)
        {
            try
            {

                Console.Write("Nombre 1 : ");
                number1 = Convert.ToInt32(Console.ReadLine());

                break;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Veuillez entre un chiffre!");
            }
        }


        Console.Write("Operateur (+ , - , * , /): ");
        string calc = Console.ReadLine();

        while (true)
        {
            try
            {

                Console.Write("Nombre 2 : ");
                number2 = Convert.ToInt32(Console.ReadLine());

                break;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Veuillez entre un chiffre!");
            }
        }

        IOperation operation = null;
        switch (calc)
        {
            case "+":
                operation = new Add(number1, number2);
                break;
            case "-":
                operation = new Sub(number1, number2);
                break; ;
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

        try
        {
            Console.WriteLine("Le résultat de {0} {1} {2} est : {3}", number1, calc, number2, operation.calc());
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine($"Database path: {db.DbPath}.");

        Console.WriteLine("Inserting a new blog");
        db.Add(new Calculus(number1, calc, number2));
        db.SaveChanges();

    }
}