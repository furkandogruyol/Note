using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListToDoo.Models;
using SQLite;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListToDoo.Tabs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Tab1 : ContentPage
    {
        private IEnumerable<Reminder> _collection;
        public Tab1()
        {
            InitializeComponent();
            funct();
        }

        public void funct()
        {
            var db = DependencyService.Get<ISQLite>().GetConnection();
            db.CreateTable<Reminder>();
            _collection = db.Table<Reminder>().Where(r => r.Body != null).ToList();
            lv_todo.ItemsSource = _collection;
        }
        private void Ch_event_CheckedChanged(object sender, XLabs.EventArgs<bool> e)
        {


        }

        private string ConvertToStrikethrough(string stringToChange)
        {
            var newString = "";
            foreach (var character in stringToChange)
            {
                newString += $"{character}\u0336";
            }

            return newString;
        }



        private async void Btn_add_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddEvent());
        }


        private void OnDelete(object sender, EventArgs e)
        {
            var db = DependencyService.Get<ISQLite>().GetConnection();
            var mi = ((MenuItem)sender);
            Reminder item = (Reminder)mi.CommandParameter;
            //Reminder re = (Reminder)item;
            db.Table<Reminder>().Delete(r=>r.Body == item.Body);
            funct();

        }
        
        private async void ClipBoard(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            Reminder item = (Reminder)mi.CommandParameter;
            await Clipboard.SetTextAsync(item.Body);
        }
    }
}