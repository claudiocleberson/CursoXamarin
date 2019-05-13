using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TravelRecord.Model;

namespace TravelRecord.ViewModel.Commands
{
    public class PostCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private NewTravelVM travelVM;

        public PostCommand( NewTravelVM vm)
        {
            travelVM = vm;
        }

        public bool CanExecute(object parameter)
        {
            var post = parameter as Post;

            if(post != null)
            {
                if (string.IsNullOrEmpty(post.Experience))
                    return false;

                if (post.Venue != null)
                    return true;

                return false;
            }
            return false;
        }

        public void Execute(object parameter)
        {
            var post = parameter as Post;

            if (post != null)
                travelVM.PublishPost(post);
        }
    }
}
