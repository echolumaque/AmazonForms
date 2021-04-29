using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using AmazonForms.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace AmazonForms.ViewModels
{
    public class ProductDetailPageViewModel : ViewModelBase
    {
        private INavigationService navigationService;
        public ProductDetailPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            this.navigationService = navigationService;
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            var passedProduct = parameters["product"] as ProductDetails;
            var xd = passedProduct.Prod_Name;
        }
    }
}
