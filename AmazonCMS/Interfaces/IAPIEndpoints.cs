using System.Threading.Tasks;
using AmazonCMS.Model;
using Refit;

namespace AmazonCMS.Interfaces
{
    public interface IAPIEndpoints
    {
        [Post("/Products/AddProduct")]
        Task AddProduct(ProductModel product);
    }
}
