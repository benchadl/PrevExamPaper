// https://github.com/benchadl/PrevExamPaper.git

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
        List<Account> filteredAccounts = new List<Account>();
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

        private void lbxAccounts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // determine what account is selected
            Account selected = lbxAccounts .SelectedItem as Account;
            // check for null
            if (selected != null)
            {
                //update display
                UpdateDisplay(selected);
            }


        }

        private void UpdateDisplay(Account selected)
        {
            tblkFirstName.Text = selected.FirstName;
            tblkLastName.Text = selected.LastName;
            tblkBalance.Text = selected.Balance.ToString("c");
            tblkAccountType.Text = selected.GetType().Name;
            tblkIntrestDate.Text = selected.InterestDate.ToString("d");
        }

        private void checkBox_Click(object sender, RoutedEventArgs e)
        {
            // reset the listbox display
            lbxAccounts.ItemsSource = null;
            // clear the filter
            filteredAccounts.Clear();
            // determine what checkbox was selected 
            bool savings = false, current = false;

            if (cbCurrentAccounts.IsChecked.Value) 
                current = true;

            if (cbSavingsAccounts.IsChecked.Value)
                savings = true;
            // update display 

            if (current && savings )
            {
                lbxAccounts .ItemsSource = accounts;
            }
            // search for current accounts
            else if (current)
            {
                foreach (Account account in accounts)
                {
                    if (account is CurrentAccount)
                        filteredAccounts.Add(account);
                }

                lbxAccounts.ItemsSource = filteredAccounts;
            }
            // search for savings account
            else if (savings)
            {
                foreach(Account account in accounts)
                {
                    if (account is Account)
                        filteredAccounts.Add(account);
                }
                lbxAccounts.ItemsSource = filteredAccounts;
            }
        }

        private void cbSavingsAccounts_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDeposit_Click(object sender, RoutedEventArgs e)
        {
            // read amount to add
            decimal amount = 0;
            if (Decimal.TryParse(tbxTransactionAmout.Text, out amount))
            {
                // determine selected amount
                Account selected = lbxAccounts.SelectedItem as Account;

                if (selected != null)
                {
                    // Add Amount
                    selected.Deposit(amount);
                    UpdateDisplay(selected);
                }

            }

        }

        private void tbxTransactionAmout_GotFocus(object sender, RoutedEventArgs e)
        {
            tbxTransactionAmout.Clear();
        }
    }
}