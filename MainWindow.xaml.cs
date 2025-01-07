﻿// https://github.com/benchadl/PrevExamPaper.git

using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PrevExamPaper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Account> accounts = new List<Account>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Create 4 accounts
            CurrentAccount ca1 = new CurrentAccount("Joe", "Doe", 1000, DateTime.Now.AddYears(-2), "12345678");
            CurrentAccount ca2 = new CurrentAccount("Jane", "Doe", 2000, DateTime.Now.AddYears(-3), "15345678");

            SavingsAccount sa1 = new SavingsAccount("John", "Smith", 3000, DateTime.Now.AddYears(-4), "64345678");
            SavingsAccount sa2 = new SavingsAccount("Jane", "Smith", 4000, DateTime.Now.AddYears(-5), "12376478");
            // aDD to account List
            accounts.Add(ca1);
            accounts.Add(ca2);
            accounts.Add(sa1);
            accounts.Add(sa2);
            // Display
            lbxAccounts.ItemsSource = accounts;
        }
    }
}