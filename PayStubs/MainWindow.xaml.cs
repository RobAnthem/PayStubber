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

namespace PayStubs
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            StubsWindow x = new StubsWindow();
            x.Show();
            x.companyName = field_cName.Text;
            x.companyAddress = field_cAdd.Text;
            x.employeeName = field_eName.Text;
            x.payScale = (float)Convert.ToDouble(field_rate.Text);
            x.hours = (float)Convert.ToInt32(field_hours.Text);
            x.startDate = field_date.DisplayDate;
            x.ssID = field_eSSN.Text;
            x.empID = Convert.ToInt32(field_eID.Text);
            Random r = new Random(11333);
            x.endingDate = field_dateEnd.DisplayDate;
            x.checkID = r.Next();
            x.Init();
            x.loopStub();
        }
    }
}
