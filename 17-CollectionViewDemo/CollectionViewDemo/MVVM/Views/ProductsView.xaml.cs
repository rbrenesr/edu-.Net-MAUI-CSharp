using CollectionViewDemo.MVVM.ViewModels;
using System.Diagnostics;

namespace CollectionViewDemo.MVVM.Views;

public partial class ProductsView : ContentPage
{
    public ProductsView()
    {
        InitializeComponent();
        BindingContext = new ProductsViewModel();
    }

    private void CollectionView_Scrolled(object sender, ItemsViewScrolledEventArgs e)
    {
        Debug.WriteLine("-------------------------------------");
        Debug.WriteLine($"HorizontalDelta: {e.HorizontalDelta}, VerticalDelta: {e.VerticalDelta}");
        Debug.WriteLine($"HorizontalOffset: {e.HorizontalOffset}, VerticalOffset: {e.VerticalOffset}");
        Debug.WriteLine($"FirstVisibleItemIndex: {e.FirstVisibleItemIndex}, CenterItemIndex: {e.CenterItemIndex}, LastVisibleItemIndex: {e.LastVisibleItemIndex}");
        Debug.WriteLine("-------------------------------------");

    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        //CollectionView.ScrollTo(10);
        //CollectionView.ScrollTo(10, groupIndex:3);

        var vm =
               BindingContext as ProductsViewModel;

        vm.Products.Add(new Models.ProductsGroup("New Group",
             new List<Models.Product>
             {
                    new Models.Product
                    {
                         Id = 100,
                         Name = "Bitcoint",
                         Price = 999999
                    }
             }));

        var product =
             vm.Products
             .SelectMany(p => p)
             .FirstOrDefault(x => x.Id == 10);

        //CollectionView.ScrollTo(product, animate: false, position: ScrollToPosition.Center);

    }
}