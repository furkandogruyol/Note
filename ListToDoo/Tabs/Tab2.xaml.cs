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
    public partial class Tab2 : ContentPage
    {

        public Tab2()
        {
            InitializeComponent();
            get_progress();
            //mail.Text = Application.Current.Properties["user"].ToString();
            //e_name.Text = Application.Current.Properties["username"].ToString();
            //e_age.Text = Application.Current.Properties["age"].ToString();
            //e_def.Text = Application.Current.Properties["def"].ToString();
            
           

        }

        public void get_progress()
        {
            var db = DependencyService.Get<ISQLite>().GetConnection();
            double donet = db.Table<ToDo>().Count(t => t.IsDone == true);
            double donef = db.Table<ToDo>().Count(t => t.IsDone == false);

            double ratio = donet / (donef + donet);
            progress.Progress = ratio;

            lb_progress.Text = "Notlarınızın Tamamlanma Oranı: %" + ratio*100;
        }

        private void Btn_kaydet_OnClicked(object sender, EventArgs e)
        {
            var db = DependencyService.Get<ISQLite>().GetConnection();
            db.CreateTable<User>();
            User user = new User()
            {
                fullName = e_name.Text,
                DateOfBirth = e_age.Text,
                Definition = e_def.Text
            };
            db.Insert(user);
            e_name.BindingContext = e_name.Text;
            e_age.BindingContext = e_age.Text;
            e_def.BindingContext = e_def.Text;
            //Application.Current.Properties["username"] = e_name.Text;
            //Application.Current.Properties["age"] = e_age.Text;
            //Application.Current.Properties["def"] = e_def.Text;
            //Application.Current.SavePropertiesAsync();
        }
    }
}