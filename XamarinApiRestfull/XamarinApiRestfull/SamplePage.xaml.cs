using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinApiRestfull.Service;

namespace XamarinApiRestfull
{
    public partial class SamplePage : ContentPage
    {
        public SamplePage()
        {
            InitializeComponent();

            btnLogin.Clicked += BtnLogin_Clicked;
        }

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            try
            {

                //Here how to use a post
                ApiService service = new ApiService();
                var result = await service.Login(txtUserName.Text, txtPassword.Text);

            }
            catch (Exception ex)
            {
                this.DisplayAlert("Ops", ex.Message, "Ok");
            }
        }
    }
}
