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

namespace Code_mau_kt2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        
            private string lastEmployee = "";

            public MainWindow()
            {
                InitializeComponent();
            }


            private void Button_Click(object sender, RoutedEventArgs e)
            {
                Window2 win2 = new Window2();
                win2.Tag = lastEmployee;
                win2.Show();
            }

            private void Button_Click_1(object sender, RoutedEventArgs e)
            {
                try
                {
                    string name = txtname.Text.ToString();

                    if (name.Length == 0)
                    {
                        MessageBox.Show("Tên không được trống");
                        return;
                    }

                    ComboBoxItem item = (ComboBoxItem)cboDepartment.SelectedItem;
                    string department = item.Content.ToString();

                    List<string> languages = new List<string>();

                    foreach (CheckBox cb in cbLanguages.Children)
                    {
                        if (cb.IsChecked == true)
                        {
                            languages.Add(cb.Content.ToString());
                        }
                    }

                    DateTime dateOfBirth = new DateTime();
                    if (dtTime.SelectedDate == null)
                    {
                        MessageBox.Show("Ngày sinh không được trống");
                        return;
                    }
                    else if (2021 - dtTime.SelectedDate.Value.Year < 18)
                    {
                        MessageBox.Show("Tuổi phải lớn hơn 18");
                        return;
                    }
                    else
                    {
                        dateOfBirth = dtTime.SelectedDate.Value;
                    }

                    int numberOfWorkingDays = 0;
                    int a;

                    if (txtWorkingDay.Text.ToString().Length == 0)
                    {
                        MessageBox.Show("Số ngày làm việc không được trống");
                        return;
                    }
                    else if (!Int32.TryParse(txtWorkingDay.Text.ToString(), out a))
                    {
                        MessageBox.Show("Số ngày làm việc phải là số");
                        return;
                    }
                    else if (Int32.Parse(txtWorkingDay.Text.ToString()) < 0)
                    {
                        MessageBox.Show("Số ngày làm việc phải lớn hơn 0");
                        return;
                    }
                    else
                    {
                        numberOfWorkingDays = Int32.Parse(txtWorkingDay.Text.ToString());
                    }

                    int salary = 0;
                    if (numberOfWorkingDays <= 20)
                    {
                        salary = (numberOfWorkingDays * 100000);
                    }
                    else
                    {
                        salary = (2000000 + (numberOfWorkingDays - 20) * 200000);
                    }

                    ListBoxItem lbItem = new ListBoxItem();
                    lastEmployee = $"{name} - {department} - {languages.Aggregate((a, b) => a + "," + b)} - {dateOfBirth.ToString("dd/MM/yyyy")} - {numberOfWorkingDays} - {salary.ToString()}";
                    lbItem.Content = lastEmployee;
                    lbResult.Items.Add(lbItem);
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }

            }

            private void Button_Click_2(object sender, RoutedEventArgs e)
            {
                txtname.Text = "";
                txtWorkingDay.Text = "";
                dtTime.SelectedDate = DateTime.Now;

                foreach (CheckBox cb in cbLanguages.Children)
                {

                    cb.IsChecked = false;
                }

                cboDepartment.SelectedIndex = -1;
                txtname.Focus();
            }

        }
    
}
