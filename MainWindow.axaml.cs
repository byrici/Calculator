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
}