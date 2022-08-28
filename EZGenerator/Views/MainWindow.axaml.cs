using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using System;
using System.Text.RegularExpressions;

namespace EZGenerator.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        Regex regex = new Regex("[^0-9.-]+");
        Random random = new Random();
        public void ClickRandomize(object sender, RoutedEventArgs e)
        {
            string min = Min.Text;
            string max = Max.Text;
            
            if (min == null || regex.IsMatch(min))
                min = "0";
            if (max == null || regex.IsMatch(max))
                max = "0";

            long minInt = long.Parse(min);
            long maxInt = long.Parse(max);
            
            if (minInt >= maxInt)
                minInt = maxInt - 1;

            Min.Text = minInt.ToString();
            Max.Text = maxInt.ToString();

            long result = random.NextInt64(minInt, maxInt + 1);
            Result.Text = $"Ваше случайное число: {result}";
        }
        public void ClickCoinFlip(object sender, RoutedEventArgs e)
        {
            int chance = random.Next(1, 3);
            switch (chance)
            {
                case 1:
                    CoinResult.Text = "ОРЁЛ";
                    break;
                case 2:
                    CoinResult.Text = "РЕШКА";
                    break;
            }
        }
    }
}