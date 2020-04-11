using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kalkulator
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Stack<double> num = new Stack<double>();
        private char operacje = ' ';
        private StringBuilder wyswietlacz;
        bool bool1, bool2;
        public MainWindow()
        {
            InitializeComponent();
            Wyswietlanie();
        }
        private void Wyswietlanie()
        {
            wyswietlacz = new StringBuilder("0");
            wyswietlacz_tb.Text = wyswietlacz.ToString();
            
        }
        
        private void Liczenie()
        {
            if (num.Count == 2)
            {
                double wynik = 0.0;
                double num2 = num.Pop();
                double num1 = num.Pop();
                num.Clear();
                switch (operacje)
                {
                    case '+':
                        wynik = num1 + num2;
                        break;
                    case '-':
                        wynik = num1 - num2;
                        break;
                    case '*':
                        wynik = num1 * num2;
                        break;
                    case '/':
                        if (num2 == 0)
                        {
                            wyswietlacz_tb.Text = "Nie dziel przez zero!";
                            return;
                        }
                        else
                            wynik = num1 / num2;
                        break;
                    default:
                        break;
                }
                num.Push(wynik);
                wyswietlacz.Clear();
                wyswietlacz.Append(wynik.ToString());
                wyswietlacz_tb.Text = wyswietlacz.ToString();
                wyswietlacz.Clear();
                bool1 = false;
            }

        }
        private void Operacje(char o)
        {
            if (!bool1)
            {
                if (Double.TryParse(wyswietlacz.ToString(), out double wynik))
                {
                    bool1 = true;
                    num.Push(wynik);
                    Liczenie();
                }
            }
            operacje = o;
            bool2 = false;
        }
        private void Zeruj()
        {
            wyswietlacz.Clear();
            wyswietlacz.Append("0");
        }
        private void ZmianaWartosci(string liczba)
        {
            if (bool1)
            {
                Zeruj();
                bool1 = false;
            }
            if (bool2)
            {
                num.Clear();
                bool1 = false;
                bool2 = false;
            }
            if (wyswietlacz.Length < 20)
            {
                if (wyswietlacz.ToString() == "0")
                {
                    wyswietlacz.Clear();
                    wyswietlacz.Append(liczba);

                }
                else
                {
                    wyswietlacz.Append(liczba);
                }
                bool2 = false;
                wyswietlacz_tb.Text = wyswietlacz.ToString();
            }
        }

        private void dzielenie_clk(object sender, RoutedEventArgs e)
        {
            Operacje('/');
        }

        private void mnozenie_clk(object sender, RoutedEventArgs e)
        {
            Operacje('*');
        }
        private void odejmowanie_clk(object sender, RoutedEventArgs e)
        {
            Operacje('-');
        }
        private void dodawanie_clk(object sender, RoutedEventArgs e)
        {
            Operacje('+');
        }
        private void wynik_clk(object sender, RoutedEventArgs e)
        {
            Operacje(' ');
            bool2 = true;
            bool1 = true;
        }

        private void p0_clk(object sender, RoutedEventArgs e)
        {
            ZmianaWartosci("0");
        }

        private void p1_clk(object sender, RoutedEventArgs e)
        {
            ZmianaWartosci("1");
        }
        private void p2_clk(object sender, RoutedEventArgs e)
        {
            ZmianaWartosci("2");
        }
        private void p3_clk(object sender, RoutedEventArgs e)
        {
            ZmianaWartosci("3");
        }
        private void p4_clk(object sender, RoutedEventArgs e)
        {
            ZmianaWartosci("4");
        }
        private void p5_clk(object sender, RoutedEventArgs e)
        {
            ZmianaWartosci("5");
        }
        private void p6_clk(object sender, RoutedEventArgs e)
        {
            ZmianaWartosci("6");
        }
        private void p7_clk(object sender, RoutedEventArgs e)
        {
            ZmianaWartosci("7");
        }
        private void p8_clk(object sender, RoutedEventArgs e)
        {
            ZmianaWartosci("8");
        }
        private void p9_clk(object sender, RoutedEventArgs e)
        {
            ZmianaWartosci("9");
        }

        private void back_clk(object sender, RoutedEventArgs e)
        {
            if (wyswietlacz.ToString() == "") wyswietlacz.Append("0");

            if (wyswietlacz[0] == '-')
            {
                if (wyswietlacz.Length == 2)
                {
                    Zeruj();
                }
                else
                {
                    wyswietlacz.Remove(wyswietlacz.Length - 1, 1);
                }
            }
            else
            {
                if (wyswietlacz.Length > 1)
                {
                    wyswietlacz.Remove(wyswietlacz.Length - 1, 1);
                }
                else
                {
                    Zeruj();
                }
            }wyswietlacz_tb.Text = wyswietlacz.ToString();
        }
       
        private void C_clk(object sender, RoutedEventArgs e)
        {
            Zeruj();
            wyswietlacz_tb.Text = wyswietlacz.ToString();
            num.Clear();
        }

        private void CE_clk(object sender, RoutedEventArgs e)
        {
            Zeruj();
            wyswietlacz_tb.Text = wyswietlacz.ToString();
        }

        private void znak_clk(object sender, RoutedEventArgs e)
        {
            if (wyswietlacz.ToString() == "0") { }
            else if (!wyswietlacz.ToString().Contains('-'))
            {
                wyswietlacz.Insert(0, '-');
            }
            else if (wyswietlacz.ToString().Contains('-'))
            {
                wyswietlacz.Remove(0, 1);
            }

            wyswietlacz_tb.Text = wyswietlacz.ToString();
        }

        private void przecinek_clk(object sender, RoutedEventArgs e)
        {
            if (!wyswietlacz.ToString().Contains(","))
            {
                wyswietlacz.Append(",");
            }
            wyswietlacz_tb.Text = wyswietlacz.ToString();
        }


        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.D0 || e.Key == Key.NumPad0) 
                ZmianaWartosci("0");
            else if (e.Key == Key.D1 || e.Key == Key.NumPad1)
                ZmianaWartosci("1");
            else if (e.Key == Key.D2 || e.Key == Key.NumPad2)
                ZmianaWartosci("2");
            else if (e.Key == Key.D3 || e.Key == Key.NumPad3)
                ZmianaWartosci("3");
            else if (e.Key == Key.D4 || e.Key == Key.NumPad4)
                ZmianaWartosci("4");
            else if (e.Key == Key.D5 || e.Key == Key.NumPad5)
                ZmianaWartosci("5");
            else if (e.Key == Key.D6 || e.Key == Key.NumPad6)
                ZmianaWartosci("6");
            else if (e.Key == Key.D7 || e.Key == Key.NumPad7)
                ZmianaWartosci("7");
            else if (e.Key == Key.D8 || e.Key == Key.NumPad8)
                ZmianaWartosci("8");
            else if (e.Key == Key.D9 || e.Key == Key.NumPad9)
                ZmianaWartosci("9");
            else if (e.Key == Key.Decimal)
                ZmianaWartosci(",");

            if (e.Key == Key.Add)
                Operacje('+');
            else if (e.Key == Key.Subtract|| e.Key==Key.OemMinus)
                Operacje('-');
            else if (e.Key == Key.Multiply)
                Operacje('*');
            else if (e.Key == Key.Divide || e.Key==Key.OemQuestion)
                Operacje('/');

            if (e.Key == Key.Enter)
            {
                Operacje(' ');
                bool1 = true;
                bool2 = true;
            }
        }
    }
}
