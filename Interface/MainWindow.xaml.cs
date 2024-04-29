
using Calculator;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Data.SqlClient;
using System.Numerics;

namespace Interface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.calc = new Calcul();

            Refresh();

        }

        public Calcul calc
        {
            get; set;
        }

        private void Refresh()
        {
            using (var db = new CalcDbContext())
            {
                var calcs = db.Calculus.ToList();
                Trace.WriteLine("--------");
                Trace.WriteLine(calcs.Last().Id);
                Trace.WriteLine("--------");
            }
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null || button.Content == null) return;

            if (button.Content.ToString() == "x^x")
            {
                this.Label.Content += "^";
            }else
            {
                this.Label.Content += button.Content as string;
            }

        }

        private void ClearLabel(object sender, RoutedEventArgs e)
        {
            this.Label.Content = "";
        }

        private void Remove(object sender, RoutedEventArgs e)
        {
            if (this.Label.Content != null && !string.IsNullOrEmpty(this.Label.Content.ToString()))
            {
                string currentContent = this.Label.Content.ToString();
                this.Label.Content = currentContent.Substring(0, currentContent.Length - 1);
            }
        }

        private bool IsOperator(string op)
        {
            if (op == "+" || op == "-" || op == "*" || op == "/" || op == "^" || op == "√")
            {
                return true;
            }
            return false;

        }

        private void Result(object sender, RoutedEventArgs e)
        {

            var db = new CalcDbContext();

            if (Label.Content != null)
            {
                IOperation operation = null;
                string content = Label.Content.ToString();

                List <string> listOperator = new List<string>();

                string currentNumber = "";

                foreach (char c in content)
                {
                    if (c == '+' || c == '-' || c == '*' || c == '/' || c == '^' || c == '√')
                    {
                        if (!string.IsNullOrEmpty(currentNumber))
                        {
                            listOperator.Add(currentNumber);
                            currentNumber = "";
                        }
                        listOperator.Add(c.ToString());
                    }
                    else
                    {
                        currentNumber += c;
                    }
                }
                if (!string.IsNullOrEmpty(currentNumber))
                {
                    listOperator.Add(currentNumber);
                }

                for (int i = 0; i < listOperator.Count; i++)
                {

                    string currentItem = listOperator[i];

                    if (IsOperator(currentItem))
                    {

                        float Number1 = i == 0 ? 0 : float.Parse(listOperator[i - 1]);
                        float Number2 = float.Parse(listOperator[i + 1]);

                        switch (currentItem)
                        {
                            case "^":

                                operation = new Puissance(Number1, Number2);

                                break;
                            case "√":
                                operation = new Racine(Number2);

                                break;
                            case "*":

                                operation = new Mult(Number1, Number2);

                                break;
                            case "/":

                                if (Number2 != 0)
                                {
                                    operation = new Div(Number1, Number2);
                                }
                                else
                                {
                                    this.Label.Content = "ERROR!";
                                }

                                break;
                            case "+":

                                operation = new Add(Number1, Number2);

                                break;
                            case "-":

                                operation = new Sub(Number1, Number2);

                                break;
                            default:
                                break;
                        }

                        if (operation != null)
                        {
                            listOperator.RemoveRange(i - 1, 3);
                            listOperator.Insert(i - 1, operation.calc().ToString());
                            i -= 2;
                        }

                        db.Add(new Calculus
                        {
                            Operateur = currentItem,
                            Value1 = Number1,
                            Value2 = Number2
                        });

                        db.SaveChanges();

                    }

                    string result = listOperator[0];
                    Label.Content = result;

                }
            } 
            else
            {
                this.Label.Content = "ERROR!";
            }

            this.Label_bdd.Content = Label.Content;


            
        }
    }
}
