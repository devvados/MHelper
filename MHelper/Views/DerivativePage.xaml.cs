using System;
using System.Collections.Generic;
using MHelper.ViewModels;
using Xamarin.Forms;

namespace MHelper.Views
{
    public partial class DerivativePage : ContentPage
    {
        private BaseViewModel derivativeViewModel;

        public DerivativePage()
        {
            InitializeComponent();
        }

        public DerivativePage(BaseViewModel derivativeViewModel)
        {
            InitializeComponent();

            BindingContext = this.derivativeViewModel = derivativeViewModel;
        }
    }
}
