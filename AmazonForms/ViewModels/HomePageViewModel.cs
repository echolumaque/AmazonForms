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
    public class HomePageViewModel : ViewModelBase
    {
        private INavigationService navigationService;
        public HomePageViewModel(INavigationService navigationService) : base(navigationService)
        {
            this.navigationService = navigationService;
        }

        public override async void Initialize(INavigationParameters parameters)
        {
            var response = await GetAllProducts();

            for (int i = 0; i < response.Count(); i++)
            {
                response.ElementAt(i).GotoProductDetailPage = new DelegateCommand<int?>(async (productId) => await ProductDetailPage(productId));
                //response[i].GotoProductDetailPage = new DelegateCommand<object>(async (productId) => await ProductDetailPage(productId));
            }

            RecommendedProducts = response.Take(3);
            RelatedProducts = response.Skip(3).Take(3);
            ViewedProducts = response.Skip(6).Take(3);
        }

        #region Properties

        private IEnumerable<ProductDetails> recommendedProducts;
        public IEnumerable<ProductDetails> RecommendedProducts
        {
            get { return recommendedProducts; }
            set { SetProperty(ref recommendedProducts, value); }
        }

        private IEnumerable<ProductDetails> relatedProducts;
        public IEnumerable<ProductDetails> RelatedProducts
        {
            get { return relatedProducts; }
            set { SetProperty(ref relatedProducts, value); }
        }

        private IEnumerable<ProductDetails> viewedProducts;
        public IEnumerable<ProductDetails> ViewedProducts
        {
            get { return viewedProducts; }
            set { SetProperty(ref viewedProducts, value); }
        }
        #endregion

        #region Methods

        private async Task ProductDetailPage(int? productId)
        {
            var product = await GetProductDetails(productId);

            var parameters = new NavigationParameters
            {
                {
                    "product",
                    new ProductDetails
                    {
                        Brand = product.Brand,
                        Description = product.Description,
                        Features = product.Features,
                        Item_Dimen = product.Item_Dimen,
                        ModelNumber = product.ModelNumber,
                        Price = product.Price,
                        Product_Dimen = product.Product_Dimen,
                        Prod_Name = product.Prod_Name,
                        Rating = product.Rating,
                        Series = product.Series,
                        Shipping_Fee = product.Shipping_Fee,
                        Stocks = product.Stocks,
                        Thumbanil = product.Thumbanil,
                        Weight = product.Weight
                    }
                }
            };

            await navigationService.NavigateAsync("ProductDetailPage", parameters);
        }


        #endregion
    }
}
