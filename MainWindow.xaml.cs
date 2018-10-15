﻿using Rolodex.Infra;
using Rolodex.ViewModel;
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

namespace Rolodex
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            (this.DataContext as PersonCollectionViewModel).ShowMessageBox += delegate (object sender, EventArgs args)
            {
                MessageBox.Show(((MessageEventArgs)args).Message);
            };
        }

        public static class DataGridTextSearch
        {
            // Using a DependencyProperty as the backing store for SearchValue.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty SearchValueProperty =
                DependencyProperty.RegisterAttached("SearchValue", typeof(string), typeof(DataGridTextSearch),
                    new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.Inherits));

            public static string GetSearchValue(DependencyObject obj)
            {
                return (string)obj.GetValue(SearchValueProperty);
            }

            public static void SetSearchValue(DependencyObject obj, string value)
            {
                obj.SetValue(SearchValueProperty, value);
            }

            // Using a DependencyProperty as the backing store for IsTextMatch.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty IsTextMatchProperty =
                DependencyProperty.RegisterAttached("IsTextMatch", typeof(bool), typeof(DataGridTextSearch), new UIPropertyMetadata(false));

            public static bool GetIsTextMatch(DependencyObject obj)
            {
                return (bool)obj.GetValue(IsTextMatchProperty);
            }

            public static void SetIsTextMatch(DependencyObject obj, bool value)
            {
                obj.SetValue(IsTextMatchProperty, value);
            }
        }

        public class SearchValueConverter : IMultiValueConverter
        {
            public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                string cellText = values[0] == null ? string.Empty : values[0].ToString();
                string searchText = values[1] as string;

                if (!string.IsNullOrEmpty(searchText) && !string.IsNullOrEmpty(cellText))
                {
                    return cellText.ToLower().StartsWith(searchText.ToLower());
                }
                return false;
            }

            public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
            {
                return null;
            }
        }
    }
}
