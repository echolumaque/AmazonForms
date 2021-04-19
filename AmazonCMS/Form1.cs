using System;
using System.Windows.Forms;
using AmazonCMS.Interfaces;
using AmazonCMS.Model;
using Refit;

namespace AmazonCMS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var product = new ProductModel
            {
                brand = brand.Text,
                description = description.Text,
                features = features.Text,
                item_dimen = dimension.Text,
                model_number = brand.Text + " " + series.Text + " " + modelnumber.Text,
                price = Math.Round(decimal.Parse(price.Text) * (decimal)48.39, 2),
                product_dimen = dimension.Text,
                prod_name = prodname.Text,
                rating = int.Parse(rating.Text),
                series = series.Text,
                shipping_fee = Math.Round(decimal.Parse(shipping.Text) * (decimal)48.39, 2),
                stocks = int.Parse(stocks.Text),
                thumbanil = thumbnail.Text,
                weight = weight.Text
            };
            await RestService.For<IAPIEndpoints>("https://localhost:44364/").AddProduct(product);

            brand.Text = "";
            description.Text = "";
            features.Text = "";
            dimension.Text = "";
            modelnumber.Text = "";
            price.Text = "";
            dimension.Text = "";
            prodname.Text = "";
            rating.Text = "";
            series.Text = "";
            shipping.Text = "";
            stocks.Text = "";
            thumbnail.Text = "";
            weight.Text = "";
        }
    }
}
