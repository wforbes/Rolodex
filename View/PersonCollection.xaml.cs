using Rolodex.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Rolodex.View
{
    /// <summary>
    /// Interaction logic for PersonCollection.xaml
    /// </summary>
    public partial class PersonCollection : Page
    {
        public PersonCollection()
        {
            InitializeComponent();
        }

        private void findByLastNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBoxName = (TextBox)sender;
            string filterText = textBoxName.Text;
            ICollectionView cv = CollectionViewSource.GetDefaultView(dataGrid.ItemsSource);

            if (!string.IsNullOrEmpty(filterText))
            {
                cv.Filter = o =>
                {
                    Person p = o as Person;
                    return (p.lastName.ToUpper().StartsWith(filterText.ToUpper()));
                    
                };
            }
            else
            {
                cv.Filter = null;
            }
        }
    }
}
