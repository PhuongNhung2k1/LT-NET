using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Shapes;

namespace Code_mau_kt2
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();

        }

        private void w2Name_Initialized(object sender, EventArgs e)
        {

        }

        private void w2Name_Loaded(object sender, RoutedEventArgs e)
        {

            /*if (numberOfWorkingDays <= 20)
            {
                txtSalary.Text = (numberOfWorkingDays * 100000).ToString();
            }
            else
            {
                txtSalary.Text = (2000000 + (numberOfWorkingDays - 20) * 200000).ToString();
            }*/
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var data = Tag.ToString().Split("-");
                var languages = data[2].Split(",");

                txtname.Text = data[0];
                txtWorkingDay.Text = data[4];

                dtTime.SelectedDate = DateTime.ParseExact(data[3].Trim().ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);


                foreach (ComboBoxItem cbitem in cboDepartment.Items)
                {
                    if (cbitem.Content.ToString().Equals(data[1].Trim()))
                    {
                        cbitem.IsSelected = true;
                    }
                }

                foreach (CheckBox cb in cbLanguages.Children)
                {
                    foreach (string language in languages)
                    {
                        if (cb.Content.ToString().Equals(language.Trim()))
                        {
                            cb.IsChecked = true;
                        }
                    }

                }

                int numberOfWorkingDays = Int32.Parse(data[4]);

                txtSalary.Text = data[5];
            }
            catch (Exception err)
            {
                MessageBox.Show("Có lỗi xảy ra");
            }


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}