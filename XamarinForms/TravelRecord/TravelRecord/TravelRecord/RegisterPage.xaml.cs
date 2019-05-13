﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecord.Model;
using TravelRecord.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecord
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        
        private RegisterVM RegisterVM;

        public RegisterPage()
        {
            InitializeComponent();

            RegisterVM = new RegisterVM();

            BindingContext = RegisterVM;
        }
    }
}