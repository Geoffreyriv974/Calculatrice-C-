public class Calculus
{
    public Calculus()
    {
    }

    public Calculus(float number1, string operation, float number2)
    {
        this.Value1 = number1;
        this.Operateur = operation;
        this.Value2 = number2;

    }

    public int Id { get; set; }

    public float Value1 { get; set; }
    public string Operateur { get; set;}
    public float Value2 { get; set; }
}