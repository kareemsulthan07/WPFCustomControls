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

namespace CalendarWpfApp
{
    /// <summary>
    /// Interaction logic for CalendarUserControl.xaml
    /// </summary>
    public partial class CalendarUserControl : UserControl
    {
        private int waitTime = 250;
        private YearsUserControl yearsUserControl;
        private MonthsUserControl monthsUserControl;
        private DaysUserControl daysUserControl;

        public CalendarUserControl()
        {
            InitializeComponent();

            yearsUserControl = new YearsUserControl()
            {
            };
            yearsUserControl.YearSelected += YearsUserControl_YearSelected;

            monthsUserControl = new MonthsUserControl()
            {
                Year = DateTime.Now.Year
            };
            monthsUserControl.GoBackToYears += MonthsUserControl_GoBackToYears;
            monthsUserControl.MonthSelected += MonthsUserControl_MonthSelected;

            daysUserControl = new DaysUserControl
            {
                Month = DateTime.Now.Month,
                Year = DateTime.Now.Year
            };
            daysUserControl.GoBackToMonths += DaysUserControl_GoBackToMonths;
            daysUserControl.UpdateCalendar();

            Content = daysUserControl;
        }

        private void YearsUserControl_YearSelected(object? sender, int year)
        {
            try
            {
                monthsUserControl.ClearBorders();

                Thread.Sleep(waitTime);

                monthsUserControl.Year = year;
                Content = monthsUserControl;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void MonthsUserControl_GoBackToYears(object? sender, EventArgs e)
        {
            try
            {
                Thread.Sleep(waitTime);

                Content = yearsUserControl;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void MonthsUserControl_MonthSelected(object? sender, int month)
        {
            try
            {
                daysUserControl.Year = monthsUserControl.Year;
                daysUserControl.Month = month;
                daysUserControl.UpdateCalendar();

                Thread.Sleep(waitTime);

                Content = daysUserControl;

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void DaysUserControl_GoBackToMonths(object? sender, EventArgs e)
        {
            try
            {
                monthsUserControl.ClearBorders();
                monthsUserControl.Month = daysUserControl.Month;
                monthsUserControl.Refresh();

                Thread.Sleep(waitTime);

                Content = monthsUserControl;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
