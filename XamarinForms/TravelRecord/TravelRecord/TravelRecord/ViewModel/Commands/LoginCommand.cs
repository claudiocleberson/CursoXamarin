using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TravelRecord.Model;

namespace TravelRecord.ViewModel.Commands
{
    public class LoginCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private MainVM MainVM { set; get; }
        public LoginCommand(MainVM mainVM)
        {
            MainVM = mainVM;
        }

        public bool CanExecute(object parameter)
        {
            var user = (User)parameter;

            if (user == null)
                return false;

            if (string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password))
                return false;
            else
                return true;
        }

        public void Execute(object parameter)
        {
            MainVM.Login();
        }
    }
}
