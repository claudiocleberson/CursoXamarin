using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecord.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecord
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : TabbedPage
    {
        HomeVM homeViewModel;
        public HomePage()
        {
            InitializeComponent();

            homeViewModel = new HomeVM();

            BindingContext = homeViewModel;
        }
    }
}