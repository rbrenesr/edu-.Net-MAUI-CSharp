using CollectionViewDemo.MVVM.Models;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CollectionViewDemo.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class DataViewModel
    {
        private Product selectedProduct;        



        public ObservableCollection<Product> Products { get; set; } = new ObservableCollection<Product>();
        public bool IsRefreshing { get; set; }
        public Product SelectedProduct
        {
            get => selectedProduct; set
            {
                selectedProduct = value;
            }
        }
        public List<Object> SelectectProducts { get; set; } = new List<object>();




        public ICommand RefreshCommand => new Command(async () =>
        {
            IsRefreshing = true;
            await Task.Delay(1000);
            RefreshItems();
            IsRefreshing = false;
        });
        public ICommand ThresholdReachedCommand => new Command(async () =>
        {
            RefreshItems(Products.Count);
        });
        public ICommand DeleteCommand => new Command((p) =>
        {
            Products.Remove((Product)p);
        });
        public ICommand ProductChangedCommand => new Command(() =>
        {
            var selectedProduct = SelectedProduct;
        });
        public ICommand ProductsChangedCommand => new Command(() =>
        {
            var selectedProduct = SelectectProducts;
        });
     
        public ICommand ClearCommand => new Command(() =>
        {
            SelectedProduct = null;
            SelectectProducts = null;
        });

        public DataViewModel()
        {
            RefreshItems();
            SelectectProducts.Add(Products.Skip(3).FirstOrDefault());
            SelectectProducts.Add(Products.Skip(7).FirstOrDefault());

            selectedProduct = Products.Skip(2).FirstOrDefault();
        }



        private void RefreshItems(int lastIndex = 0)
        {
            int numberOfItemsPerPage = 10;

            var items = new ObservableCollection<Product>
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

            var pageItems =
                items.Skip(lastIndex).Take(numberOfItemsPerPage);

            foreach (var item in pageItems)
            {
                Products.Add(item);
            }

        }
    }
}
