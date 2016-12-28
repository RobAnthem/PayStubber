using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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

namespace PayStubs
{
    /// <summary>
    /// Interaction logic for StubsWindow.xaml
    /// </summary>
    public partial class StubsWindow : Window
    {
        public string companyName;
        public string companyAddress;
        public string employeeName;
        public float payScale;
        public float hours;
        public DateTime startDate;
        public DateTime endingDate;
        public string ssID;
        public int empID;
        public int checkID;
        public StubsWindow()
        {
            InitializeComponent();
        }

        public void Init()
        {
            name_L.Content = employeeName;
            company_L.Content = companyName;
            address_L.Content = companyAddress;
            hourly_RateL.Content = String.Format("{0:##.#0}", payScale);
            hoursL.Content = hours;
            total_L.Content = payScale * hours;
            totalpayL.Content = payScale * hours;
            netPay_L.Content = payScale * hours;
            checkn_L.Content = checkID;
            ssid_L.Content = "xxx-xx-" + ssID;
            empId_L.Content = empID;
            DateTime endDate = startDate.Date;
            endDate = endDate.AddDays(7);
            payPeriod_L.Content = startDate.ToLongDateString() + " - " + endDate.ToLongDateString();
            this.UpdateLayout();

        }
        public void loopStub()
        {
            int x = 100;
            DateTime endDate = startDate.Date;
            Random random = new Random();
            float ytdGross = 0;
            int checkNumber = random.Next(2000, 3000);
            for (int i = 0; i < x; i++)
            {
                if (endDate > endingDate)
                {
                    x = 0;
                }
                checkNumber += random.Next(10, 50);
                checkn_L.Content = checkNumber;
                int randomNumber = random.Next(30, 45);
                hoursL.Content = randomNumber;
                ytdGross += payScale * randomNumber;
                string ytD = String.Format("{0:#,##.#0}", ytdGross);
                total_L.Content = String.Format("{0:#,##.#0}", payScale * randomNumber);
                totalpayL.Content = String.Format("{0:#,##.#0}", payScale * randomNumber);
                netPay_L.Content = String.Format("{0:#,##.#0}", payScale * randomNumber);
                ytd_NetL.Content = ytD;
                ytd_GrossL.Content = ytD;
                startDate = endDate;
                endDate = endDate.AddDays(6);
                payPeriod_L.Content = startDate.ToShortDateString() + " - " + endDate.ToShortDateString();
                this.UpdateLayout();
                Print(endDate);
                endDate = endDate.AddDays(1);

            }
        }
        public void Print(DateTime endDate)
        {
            RenderTargetBitmap bmp = new RenderTargetBitmap((int)mainGrid.RenderSize.Width, (int)mainGrid.RenderSize.Height, 96, 96, PixelFormats.Pbgra32);
            bmp.Render(this);
            BmpBitmapEncoder encoder = new BmpBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bmp));
            FileStream fs = File.Open("PayStub" + endDate.Month.ToString() + "-" + endDate.Day.ToString() + ".png", FileMode.Create);
            encoder.Save(fs);
            fs.Close();
        }
    }
}
