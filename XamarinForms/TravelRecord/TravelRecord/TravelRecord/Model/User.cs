using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelRecord.Model
{
    public class User : INotifyPropertyChanged
    {
        private string id;
        private string email;
        private string password;
        private string confirmPassword;

        public event PropertyChangedEventHandler PropertyChanged;


        private void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Id
        {
            get => id;
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }
        public string Email
        {
            get => email;
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }
        public string Password { get => password;
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }

        public string ConfirmPassword
        {
            get => confirmPassword;
            set
            {
                confirmPassword = value;
                OnPropertyChanged("ConfirmPassword");
            }
        }

        public static async void RegisterUser(User user)
        {
            await App.MobileService.GetTable<User>().InsertAsync(user);
        }

        public static async Task<bool> Login(string userEmail, string userPass)
        {
            bool isEmailEmpty = string.IsNullOrEmpty(userEmail);
            bool isPasswordEmpty = string.IsNullOrEmpty(userPass);

            if (isEmailEmpty || isPasswordEmpty)
            {
                return false;
            }
            else
            {
                //Check if the user exists
                var user = (await App.MobileService.GetTable<User>().Where(w => w.Email == userEmail).ToListAsync()).FirstOrDefault(); ;

                if (user != null)
                {
                    if (user.Password == userPass)
                    {
                        App.CurrentUser = user;

                        return true;
                        //Navigation.PushAsync(new HomePage());
                    }
                    else
                        return false; //await DisplayAlert("Error", "Email or password are incorrect", "OK");
                }
                else
                {
                    return false; //await DisplayAlert("Error", "There was an error logging you in", "OK");
                }
            }
        }
    }
}
