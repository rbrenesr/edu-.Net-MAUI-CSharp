using CollectionViewDemo.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionViewDemo.MVVM.ViewModels
{
    public class ProductsViewModel
    {
        public ObservableCollection<ProductsGroup> Products { get; set; } = new ObservableCollection<ProductsGroup>();

        public ProductsViewModel()
        {
            var products = LoadItems();

            //var grouped =
            //    products.GroupBy(p => p.Name[0].ToString())
            //    .Select(g => new ProductsGroup(g.Key, g.ToList()))
            //    .ToList();

            var grouped =
                from p in products
                orderby p.Name
                group p by p.Name[0].ToString() into g
                select new ProductsGroup(g.Key, g.ToList());

            int id = 0;

            foreach (var group in grouped)
            {
               foreach (var product in group)
                {
                    product.Id = id;
                    id++;
                }
            }

            Products = new ObservableCollection<ProductsGroup>(grouped.ToList());

        }

        private List<Product> LoadItems()
        {
            return new List<Product>
            {
               new Product
                {
                    Name = "Laptop",
                    Price = 500,
                    Image = "alcohol.png",
                    Stock = 10,
                    HasOffer = true,
                    OfferPrice = 450
                },
                new Product
                {
                    Name = "Mouse",
                    Price = 20,
                    Image = "apple.png",
                    Stock = 50,
                    HasOffer = false,
                    OfferPrice = 0
                },
                new Product
                {
                    Name = "Keyboard",
                    Price = 50,
                    Image = "banana.png",
                    Stock = 30,
                    HasOffer = true,
                    OfferPrice = 40
                },
                new Product
                {
                    Name = "Monitor",
                    Price = 300,
                    Image = "bread.png",
                    Stock = 5,
                    HasOffer = false,
                    OfferPrice = 0
                },
                new Product
                {
                    Name = "Headset",
                    Price = 100,
                    Image = "candy.png",
                    Stock = 20,
                    HasOffer = true,
                    OfferPrice = 80
                },
                new Product
                {
                    Name = "Laptop",
                    Price = 500,
                    Image = "alcohol.png",
                    Stock = 10,
                    HasOffer = true,
                    OfferPrice = 450
                },
                new Product
                {
                    Name = "Mouse",
                    Price = 20,
                    Image = "apple.png",
                    Stock = 50,
                    HasOffer = false,
                    OfferPrice = 0
                },
                new Product
                {
                    Name = "Keyboard",
                    Price = 50,
                    Image = "banana.png",
                    Stock = 30,
                    HasOffer = true,
                    OfferPrice = 40
                },
                new Product
                {
                    Name = "Monitor",
                    Price = 300,
                    Image = "bread.png",
                    Stock = 5,
                    HasOffer = false,
                    OfferPrice = 0
                },
                new Product
                {
                    Name = "Headset",
                    Price = 100,
                    Image = "candy.png",
                    Stock = 20,
                    HasOffer = true,
                    OfferPrice = 80
                },
                new Product
                {
                    Name = "Laptop",
                    Price = 500,
                    Image = "alcohol.png",
                    Stock = 10,
                    HasOffer = true,
                    OfferPrice = 450
                },
                new Product
                {
                    Name = "Mouse",
                    Price = 20,
                    Image = "apple.png",
                    Stock = 50,
                    HasOffer = false,
                    OfferPrice = 0
                },
                new Product
                {
                    Name = "Keyboard",
                    Price = 50,
                    Image = "banana.png",
                    Stock = 30,
                    HasOffer = true,
                    OfferPrice = 40
                },
                new Product
                {
                    Name = "Monitor",
                    Price = 300,
                    Image = "bread.png",
                    Stock = 5,
                    HasOffer = false,
                    OfferPrice = 0
                },
                new Product
                {
                    Name = "Headset",
                    Price = 100,
                    Image = "candy.png",
                    Stock = 20,
                    HasOffer = true,
                    OfferPrice = 80
                },
                new Product
                {
                    Name = "Laptop",
                    Price = 500,
                    Image = "alcohol.png",
                    Stock = 10,
                    HasOffer = true,
                    OfferPrice = 450
                },
                new Product
                {
                    Name = "Mouse",
                    Price = 20,
                    Image = "apple.png",
                    Stock = 50,
                    HasOffer = false,
                    OfferPrice = 0
                },
                new Product
                {
                    Name = "Keyboard",
                    Price = 50,
                    Image = "banana.png",
                    Stock = 30,
                    HasOffer = true,
                    OfferPrice = 40
                },
                new Product
                {
                    Name = "Monitor",
                    Price = 300,
                    Image = "bread.png",
                    Stock = 5,
                    HasOffer = false,
                    OfferPrice = 0
                },
                new Product
                {
                    Name = "Headset",
                    Price = 100,
                    Image = "candy.png",
                    Stock = 20,
                    HasOffer = true,
                    OfferPrice = 80
                },
                new Product
                {
                    Name = "Laptop",
                    Price = 500,
                    Image = "alcohol.png",
                    Stock = 10,
                    HasOffer = true,
                    OfferPrice = 450
                },
                new Product
                {
                    Name = "Mouse",
                    Price = 20,
                    Image = "apple.png",
                    Stock = 50,
                    HasOffer = false,
                    OfferPrice = 0
                },
                new Product
                {
                    Name = "Keyboard",
                    Price = 50,
                    Image = "banana.png",
                    Stock = 30,
                    HasOffer = true,
                    OfferPrice = 40
                },
                new Product
                {
                    Name = "Monitor",
                    Price = 300,
                    Image = "bread.png",
                    Stock = 5,
                    HasOffer = false,
                    OfferPrice = 0
                },
                new Product
                {
                    Name = "Headset",
                    Price = 100,
                    Image = "candy.png",
                    Stock = 20,
                    HasOffer = true,
                    OfferPrice = 80
                },
                new Product
                {
                    Name = "Laptop",
                    Price = 500,
                    Image = "alcohol.png",
                    Stock = 10,
                    HasOffer = true,
                    OfferPrice = 450
                },
                new Product
                {
                    Name = "Mouse",
                    Price = 20,
                    Image = "apple.png",
                    Stock = 50,
                    HasOffer = false,
                    OfferPrice = 0
                },
                new Product
                {
                    Name = "Keyboard",
                    Price = 50,
                    Image = "banana.png",
                    Stock = 30,
                    HasOffer = true,
                    OfferPrice = 40
                },
                new Product
                {
                    Name = "Monitor",
                    Price = 300,
                    Image = "bread.png",
                    Stock = 5,
                    HasOffer = false,
                    OfferPrice = 0
                },
                new Product
                {
                    Name = "Headset",
                    Price = 100,
                    Image = "candy.png",
                    Stock = 20,
                    HasOffer = true,
                    OfferPrice = 80
                }
            };
        }
    }
}
