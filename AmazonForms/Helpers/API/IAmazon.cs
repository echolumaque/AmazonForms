using System.Collections.ObjectModel;
using System.Threading.Tasks;
using AmazonForms.Models;
using Refit;

namespace AmazonForms.Helpers.API
{
    public interface IAmazon
    {
        [Post("/users/register")]
        Task<string> RegisterUser(string name, string password, string emailOrPhone);

        [Post("/users/login")]
        Task<UserModel> UserLogin(string emailOrPhone, string password);

        [Post("/users/edituser")]
        void EditUser(int id, string name, string address);

        [Get("/userscarts/GetCurrentUserCart?id={id}")]
        Task<ObservableCollection<UsersCarts>> GetCurrentUserCart(int id);

        [Get("/userscarts/ShowProductDetails?productId={productId}")]
        Task<ProductDetails> GetProductDetails(int productId);

        [Get("/Products/AllProducts")]
        Task<AllProducts> GetAllProducts();
    }
}