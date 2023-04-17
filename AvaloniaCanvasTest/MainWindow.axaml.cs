using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Markup.Xaml.Styling;
using Avalonia.Media;
using Avalonia.Styling;

using System;

namespace AvaloniaCanvasTest
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            mChangeBackgroundButton.Click += ChangeBackgroundButton_Click;
            mCanvas.Children.Add(new RectangleShape());
        }

        private void ChangeBackgroundButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (Application.Current == null)
                return;

            Application.Current.Styles[1] = LoadColors("DarkColors.xaml")!;
        }

        private IStyle? LoadColors(string fileName)
        {
            string baseUri = "avares://AvaloniaCanvasTest/";

            StyleInclude include = new StyleInclude(new Uri(baseUri))
            {
                Source = new Uri(fileName, UriKind.Relative)
            };

            return include;
        }
    }
}