using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListToDoo.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListToDoo.Auth
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        private async void Btn_login_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tb_mail.Text) || !string.IsNullOrWhiteSpace(tb_password.Text)) {
                var db = DependencyService.Get<ISQLite>().GetConnection();
                db.CreateTable<User>();

            if (db.Table<User>().Any(c => c.Mail == tb_mail.Text))
            {
                if (db.Table<User>().First(c => c.Mail == tb_mail.Text).Password != tb_password.Text)
                {
                    await DisplayAlert("Hata", "Şifre yanlış", "Geri");
                    tb_password.Text = "";
                }
                else
                {
                    Application.Current.Properties["user"] = tb_mail.Text;
                    Application.Current.SavePropertiesAsync();
                    await Navigation.PushAsync(new MainPage());
                    tb_mail.Text = "";
                    tb_password.Text = "";
                }

            }
            else
            {
                User user = new User()
                {
                    Mail = tb_mail.Text,
                    Password = tb_password.Text
                };
                Application.Current.Properties["user"] = tb_mail.Text;
                db.Insert(user);
                var action = await DisplayAlert("Giriş", "Kayıt Yapıldı", "Giriş Yap", "Geri");
                if (action)
                {
                    await Navigation.PushAsync(new MainPage());
                    tb_mail.Text = "";
                    tb_password.Text = "";
                }
                else
                {
                    await Navigation.PopAsync();
                }
            }
            }
            else
            {
                DisplayAlert("Hata", "Alanları doldurunuz", "Geri");
            }
        }
    }
}