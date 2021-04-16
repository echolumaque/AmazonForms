using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmazonCMS.Model;
using Refit;

namespace AmazonCMS.Interfaces
{
    public interface IAPIEndpoints
    {
        [Post("/Products/Create")]
        Task AddNewProduct(ProductsModel product);
        [Get("/Products/LastID")]
        Task<int> GetAllProducts();
    }
}
