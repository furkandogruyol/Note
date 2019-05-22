using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListToDoo.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListToDoo.Tabs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddToDo : ContentPage
    {
        public AddToDo()
        {
            InitializeComponent();
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            var db = DependencyService.Get<ISQLite>().GetConnection();
            db.CreateTable<ToDo>();
            ToDo toDo = new ToDo()
            {
                Title = tb_baslik.Text,
                Body = tb_not.Text,
                IsDone = false
            };
            db.Insert(toDo);

            await Navigation.PushAsync(new MainPage());
        }
    }
}