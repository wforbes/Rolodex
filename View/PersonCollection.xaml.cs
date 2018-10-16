using Rolodex.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        
        private void insertButton_Click(object sender, RoutedEventArgs e)
        {
            Person person = new Person();
            person.id = 0;
            person.firstName = firstNameTextBox.Text;
            person.middleName = middleNameTextBox.Text;
            person.lastName = lastNameTextBox.Text;
            person.jobTitle = jobTitleTextBox.Text;
            person.address = addressTextBox.Text;
            person.city = cityTextBox.Text;
            person.state = stateTextBox.Text;
            person.zipCode = zipTextBox.Text;
            person.phone = phoneTextBox.Text;
            Business business = new Business();
            business.Update(person);
            dataGrid.ItemsSource = null;
            dataGrid.ItemsSource = new ObservableCollection<Person>(business.Get());
        }
    }
}
