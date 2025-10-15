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
        try
        {
            var num1 = getNumberFromTextBox(Num1);
            var num2 = getNumberFromTextBox(Num2);
            var result = operation(num1, num2);
            Result.Text = result.ToString();
        }
        catch (Exception ex)
        {
            Result.Text = $"Error: {ex.Message}";
        }
    }
}