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
using System.Xml.Linq;
using System.IO;
using System.Diagnostics;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PeopleManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        Staff mainStaff;
        public MainWindow()
        {
            InitializeComponent();
            mainStaff = new Staff("teszt");
            mainStaff.XMLOpen();
        }

        private void peopleButton_Click(object sender, RoutedEventArgs e)
        {
            peopleGridLoader(mainStaff);
            OnPropChanged();
        }

        private void settingsButton_Click(object sender, RoutedEventArgs e)
        {
            settingsGridLoader();
            OnPropChanged();
        }

        private void tablesButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void runButton_Click(object sender, RoutedEventArgs e)
        {

        }

        public void peopleGridLoader(Staff staff)
        {
            ListBox coContainer = new ListBox();
            containerGrid.Children.Add(coContainer);
            coContainer.ItemsSource = staff.StaffMembers;
        }

        public void settingsGridLoader()
        {
            ListBox coContainer = new ListBox();
            containerGrid.Children.Add(coContainer);
        }

        public void tabelsGridLoader()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropChanged([CallerMemberName] string n = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(n));
        }
    }
}
