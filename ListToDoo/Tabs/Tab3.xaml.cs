using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListToDoo.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XLabs;
using XLabs.Forms.Controls;
using Xamarin.Essentials;

namespace ListToDoo.Tabs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Tab3 : ContentPage
    {
        private IEnumerable<ToDo> _collection;
        public Tab3()
        {
            InitializeComponent();
            var db = DependencyService.Get<ISQLite>().GetConnection();
            db.CreateTable<ToDo>();
            _collection = db.Table<ToDo>().Where(r => r.Body != null).ToList();
            lv_todo.ItemsSource = _collection;
        }

        private void Ch_event_CheckedChanged(object sender, EventArgs<bool> e)
        {

            var db = DependencyService.Get<ISQLite>().GetConnection();
            var item = (CheckBox) sender;
            string uText = item.UncheckedText;
            if (e.Value)
            {
                ToDo a = db.Table<ToDo>().Where(r => r.Body == uText).First();
                a.IsDone = true;
                db.Update(a);
                //profildeki oranı yenile
               
            }
            else
            {
                ToDo a = db.Table<ToDo>().Where(r => r.Body == uText).First();
                a.IsDone = false;
                db.Update(a);
            }


        }

        private async void Btn_add_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddToDo());
        }

        public void OnDelete(object sender, EventArgs e)
        {
            var db = DependencyService.Get<ISQLite>().GetConnection();
            var mi = ((MenuItem)sender);
            ToDo item = (ToDo) mi.CommandParameter;
            db.Table<ToDo>().Delete(r => r.Body == item.Body);
            funct();
        }
        //item source unu belirtip OnDelete den sonra listeyi refreshliyoruz
        public void funct()
        {
            var db = DependencyService.Get<ISQLite>().GetConnection();
            db.CreateTable<ToDo>();
            _collection = db.Table<ToDo>().Where(r => r.Body != null).ToList();
            lv_todo.ItemsSource = _collection;
        }

        private async void ClipBoard(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            ToDo item = (ToDo)mi.CommandParameter;
            await Clipboard.SetTextAsync(item.Body);
        }
    }
}