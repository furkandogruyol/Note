using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListToDoo.Models;
using Plugin.LocalNotifications;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListToDoo.Tabs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddEvent : ContentPage
    {
        private static int count = 0;
        public AddEvent()
        {
            InitializeComponent();
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            var db = DependencyService.Get<ISQLite>().GetConnection();
            db.CreateTable<Reminder>();
            Reminder reminder = new Reminder()
            {
                Title = tb_baslik.Text,
                Date = tb_gun.Date,
                Body = tb_not.Text,
                Time =  tb_time.Time
            };

            db.Insert(reminder);
            //metod buraya
            
            CrossLocalNotifications.Current.Show("ListToDoo",reminder.Body,count,reminder.Date.AddHours(reminder.Time.Hours).AddMinutes(reminder.Time.Minutes));
            count++;
            await Navigation.PushAsync(new MainPage());

        }

        private void DatePicker_OnDateSelected(object sender, DateChangedEventArgs e)
        {

        }


    }
}