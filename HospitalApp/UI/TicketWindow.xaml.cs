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
using System.Windows.Shapes;

namespace HospitalApp.UI
{
    /// <summary>
    /// Логика взаимодействия для TicketWindow.xaml
    /// </summary>
    public partial class TicketWindow : Window
    {
        public TicketWindow(Entities.Appointment appointment)
        {
            InitializeComponent();
            txtBlockDoctor.Text = "Врач: " + appointment.DoctorSchedule.Doctor.FullName;
            txtBlockDate.Text = "Дата: " + appointment.DoctorSchedule.Date.ToString("dd-MM-yyyy") + " " + appointment.StartTime.ToString(@"hh\:mm") + "-" + appointment.EndTime.ToString(@"hh\:mm");
            txtBlockCabinet.Text = "Кабинет: " + appointment.DoctorSchedule.Doctor.CabinetNumber.ToString();
        }

        private void BtnPring_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                IDocumentPaginatorSource idpSource = ticketDocument;
                printDialog.PrintDocument(idpSource.DocumentPaginator, $"Report_AllData_From_{DateTime.Now.ToShortDateString()}");
            }
        }
    }
}
