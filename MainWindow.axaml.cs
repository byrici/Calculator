using Avalonia.Controls;
using System;

namespace Calculator;

public partial class MainWindow : Window
{
    private decimal? _firstNumber = null;
    private string? _Operator = null;
    private bool _isNewEntry = false;
    public MainWindow()
    {
        InitializeComponent();
    }

    private void OnNumberClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (sender is Button button)
        {
            string value = button.Content.ToString() ?? "";

            if (_isNewEntry)
            {
                Display.Text = value;
                _isNewEntry = false;
            }
            else
            {
                Display.Text += value;
            }
        }
    }

    private void OnOperatorClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (sender is Button button)
        {

            string op = button.Content.ToString();

            if (string.IsNullOrWhiteSpace(Display.Text) && op == "-")
            {
                Display.Text = "-";
                _isNewEntry = false;
                _Operator = null;
                return;
            }

            try
            {
                _firstNumber = Convert.ToDecimal(Display.Text);
                _Operator = button.Content.ToString();
                _isNewEntry = true;
            }
            catch
            {
                Display.Text = "Fehler";
                _firstNumber = null;
                _Operator = null;
            }
        }
    }

    private void OnEqualClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (_firstNumber.HasValue && !string.IsNullOrEmpty(_Operator))
        {
            try
            {
                decimal secondNumber = Convert.ToDecimal(Display.Text);
                decimal result = _Operator switch
                {
                    "+" => _firstNumber.Value + secondNumber,
                    "-" => _firstNumber.Value - secondNumber,
                    "×" => _firstNumber.Value * secondNumber,
                    "÷" => secondNumber == 0 ? throw new DivideByZeroException() : _firstNumber.Value / secondNumber,
                    _ => 0
                };

                Display.Text = Math.Round(result, 7).ToString();
                _firstNumber = result;
                _Operator = null;
                _isNewEntry = true;
            }
            catch
            {
                Display.Text = "Error";
                _firstNumber = null;
                _Operator = null;
            }
        }
    }

    private void OnPlusMinusClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (sender is Button button)
        {
            string value = Display.Text;
            decimal currentNumber = Convert.ToDecimal(value);

            if (currentNumber == 0)
                return;
            
            currentNumber = -currentNumber;
            Display.Text = currentNumber.ToString();
        }
    }

    private void OnCleanClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Display.Text = "";
        _firstNumber = null;
        _Operator = null;
    }
}