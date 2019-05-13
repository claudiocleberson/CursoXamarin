using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TravelRecord.Model;

namespace TravelRecord.ViewModel.Commands
{
    public class ConfirmRegisterCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private RegisterVM RegisterVM;

        public ConfirmRegisterCommand(RegisterVM vm)
        {
            RegisterVM = vm;
        }

        public bool CanExecute(object parameter)
        {
            var user = parameter as User;

            if (user == null)
                return false;

            if (user.Password != user.ConfirmPassword || string.IsNullOrEmpty(user.Email))
                return false;
            else
                return true;
        }

        public void Execute(object parameter)
        {
            var user = parameter as User;
            if(user !=null)
                RegisterVM.Register(user);
        }
    }
}
