using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using TravelRecord.Model;

namespace TravelRecord.ViewModel
{
    public class HistoryVM
    {
        public ObservableCollection<Post> Posts { set; get; }

        private bool isRefreshing;

        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set { isRefreshing = value; }
        }

        public HistoryVM()
        {
            Posts = new ObservableCollection<Post>();
        }

        public async Task<bool> UpdatePosts()
        {
            IsRefreshing = true;

            var posts = await Post.Read();
            if (posts != null)
            {
                Posts.Clear();
                foreach (var p in posts)
                    Posts.Add(p);
            }
            IsRefreshing = false;

            return true;
        }

        public async Task<bool> DeletePost(Post post)
        {
            if(await Post.DeletePost(post))
                Posts.Remove(post);

            return true;
        }
    }
}
