using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using AmazonForms.Helpers.API;
using AmazonForms.Models;
using Prism.Mvvm;
using Prism.Navigation;
using Refit;

namespace AmazonForms.ViewModels
{
    public class ViewModelBase : BindableBase, IInitialize, INavigationAware, IDestructible, IAmazon
    {
        protected INavigationService NavigationService { get; private set; }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        public virtual void Initialize(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {

        }

        public virtual void Destroy()
        {

        }

        private readonly IAmazon amazon = RestService.For<IAmazon>("https://amazonrest.azurewebsites.net/");

        public async Task<string> RegisterUser(string name, string password, string emailOrPhone) => await amazon.RegisterUser(name, password, emailOrPhone);

        public async Task<UserModel> UserLogin(string emailOrPhone, string password) => await amazon.UserLogin(emailOrPhone, password);

        //public void EditUser(int id, string name, string address) => amazon.EditUser(id, name, address);

        public async Task<ObservableCollection<UsersCarts>> GetCurrentUserCart(int id) => await amazon.GetCurrentUserCart(id);

        public Task<ProductDetails> GetProductDetails(int? productId) => amazon.GetProductDetails(productId);

        public Task<IEnumerable<ProductDetails>> GetAllProducts() => amazon.GetAllProducts();
    }
}