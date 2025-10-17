using Avalonia.Controls;
using System;

namespace Calculator;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private decimal getNumberFromTextBox(TextBox textBox)
    {
        if (decimal.TryParse(textBox.Text, out var value))
        {
            return value;
        }
        else
        {
            throw new Exception("Invalid number format");
        }
    }

    private void OnAdd(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {

    }
    



    private void Calculate(Func<decimal, decimal, decimal> operation)
    {
       
    }
}