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

namespace Сalculator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public double operation1;
        public double operation2;
        public string operation;
        public bool start;
        public bool operandos;
        public MainWindow()
        {
            InitializeComponent();
            start = true;
            operandos = false;
        }

        private void Window_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnEvents(object sender, RoutedEventArgs e)
        {
            if (!start)
            {
                box1.Text = (sender as Button).Content.ToString();
                start = true;
            }
            else
            {
                if ((sender as Button).Content.ToString() != ".")
                {
                    if (box1.Text == "0") box1.Text = "";
                }
                if ((sender as Button).Content.ToString() == "." && box1.Text.Contains("."))
                {
                    box1.Text = box1.Text;
                }
                else
                {
                    string start = box1.Text;
                    box1.Text += (sender as Button).Content.ToString();
                    if (box1.Text.Length >= 15)
                    {
                        box1.Text = start;
                    }
                }
            }
            
            
              
                           
           
        }

        private void btnRemove(object sender, RoutedEventArgs e)

        {
            if(box1.Text != "0")
            {
                box1.Text = box1.Text.Remove(box1.Text.Length - 1);
                if (box1.Text=="")box1.Text= "0";
            } 
            
        }

        private void btnClear(object sender, RoutedEventArgs e)
        {
            box1.Text= "0";
            operation1 = 0;
            operation2 = 0;
            operation = "";
        }

        private void btnОperand(object sender, RoutedEventArgs e)
        {
            operation =(sender as Button).Content.ToString();
            operation1=double.Parse(box1.Text.Trim());
            box1.Text = "0";
        }

        private void btnCalculation(object sender, RoutedEventArgs e)
        {
            operation2=double.Parse(box1.Text.Trim());
            switch (operation)
            {
                case "+":
                    if (!operandos)
                    {
                        box1.Text = (operation1 + operation2).ToString();
                        operation = "";
                        operation1 = 0;
                        operation2 = 0;
                    }
                    else
                    {
                        box1.Text=(operation1 + operation2*0.01*operation1).ToString();
                        operation = "";
                        operation1 = 0;
                        operation2 = 0;
                        operandos = false;
                    }
                    
                    break;
                case "-":
                    

                    if (!operandos)
                    {
                        box1.Text = (operation1 - operation2).ToString();
                        operation = "";
                        operation1 = 0;
                        operation2 = 0;
                    }
                    else
                    {
                        box1.Text = (operation1 - operation2 * 0.01 * operation1).ToString();
                        operation = "";
                        operation1 = 0;
                        operation2 = 0;
                        operandos = false;
                    }
                    break;
                case "*":
                    
                    if (!operandos)
                    {
                        box1.Text = (operation1 * operation2).ToString();
                        operation = "";
                        operation1 = 0;
                        operation2 = 0;
                    }
                    else
                    {
                        box1.Text = (operation1 * operation2 * 0.01 * operation1).ToString();
                        operation = "";
                        operation1 = 0;
                        operation2 = 0;
                        operandos = false;
                    }
                    break;
                case "/":
                    if(operation2 == 0) box1.Text = "error";
                    if (!operandos)
                    {
                        box1.Text = (operation1 / operation2).ToString();
                        if(box1.Text.Length>=15)box1.Text= box1.Text.Substring(0,14);
                        operation = "";
                        operation1 = 0;
                        operation2 = 0;
                    }
                    else
                    {
                        box1.Text = (operation1 / (operation2 * 0.01 * operation1)).ToString();
                        operation = "";
                        operation1 = 0;
                        operation2 = 0;
                        operandos = false;
                    }
                    break;
                    
            }
            start = false;
        }

        private void btnОperandos(object sender, RoutedEventArgs e)
        {
            operandos = true;
        }
    }
}
