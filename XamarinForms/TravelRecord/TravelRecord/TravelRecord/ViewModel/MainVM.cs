using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using TravelRecord.Model;
using TravelRecord.ViewModel.Commands;

namespace TravelRecord.ViewModel
{
    public class MainVM : INotifyPropertyChanged
    {
        public User User { get => user;
            set
            {
                user = value;
                OnPropertyChanged("User");
            }
        }

        public LoginCommand LoginCommand { set; get; }

        public RegisterCommand RegisterCommand { set; get; }

        public MainVM()
        {
            User = new User();
            LoginCommand = new LoginCommand(this);
            RegisterCommand = new RegisterCommand(this);
        }


        private string email;

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                User = new User
                {
                    Email = this.Email,
                    Password = this.Password
                };
                OnPropertyChanged("Email");
            }
        }

        private string password;
        private User user;

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                User = new User()
                {
                    Email = this.Email,
                    Password = this.Password
                };
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }



        public async void Login()
        {
            bool canLogin = await User.Login(User.Email, User.Password);
            if (canLogin)
                await App.Current.MainPage.Navigation.PushAsync(new HomePage());
            else
                await App.Current.MainPage.DisplayAlert("Error ", "Try again ", "OK");
        }

        public async void Register()
        {
            await App.Current.MainPage.Navigation.PushAsync(new RegisterPage());
        }

    }
}
