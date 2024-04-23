
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
        }

        public Calcul calc
        {
            get; set;
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

        private void Result(object sender, RoutedEventArgs e)
        {

            if (Label.Content != null)
            {
                IOperation operation = null;
                string content = Label.Content.ToString();
                float Number1 = 0;
                float Number2 = 0;

                if (content.Contains("+"))
                {
                    string[] parts = content.Split('+');

                    if (parts.Length == 2 && float.TryParse(parts[0], out Number1) && float.TryParse(parts[1], out Number2))
                    {
                        operation = new Add(Number1, Number2);
                        Label.Content = operation.calc();
                    }

                }
                else if (content.Contains("-"))
                {
                    string[] parts = content.Split('-');

                    if (parts.Length == 2 && float.TryParse(parts[0], out Number1) && float.TryParse(parts[1], out Number2))
                    {
                        operation = new Sub(Number1, Number2);
                        Label.Content = operation.calc();
                    }

                }
                else if (content.Contains("*"))
                {
                    string[] parts = content.Split('*');

                    if (parts.Length == 2 && float.TryParse(parts[0], out Number1) && float.TryParse(parts[1], out Number2))
                    {
                        operation = new Mult(Number1, Number2);
                        Label.Content = operation.calc();
                    }
                }
                else if (content.Contains("/"))
                {
                    string[] parts = content.Split('/');

                    if (parts.Length == 2 && float.TryParse(parts[0], out Number1) && float.TryParse(parts[1], out Number2))
                    {
                        operation = new Div(Number1, Number2);
                        Label.Content = operation.calc();
                    }
                }
                else if (content.Contains("x^x"))
                {
                    string[] parts = content.Split('^');

                    if (parts.Length == 2 && float.TryParse(parts[0], out Number1) && float.TryParse(parts[1], out Number2))
                    {
                        operation = new Puissance(Number1, Number2);
                        Label.Content = operation.calc();
                    }
                }
            } 
            else
            {
                this.Label.Content = "ERROR!";
            }
        }
    }
}
