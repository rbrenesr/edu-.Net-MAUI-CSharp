using Tasker.MVVM.Models;
using Tasker.MVVM.ViewModels;

namespace Tasker.MVVM.Views;

public partial class NewTaskView : ContentPage
{
    public NewTaskView()
    {
        InitializeComponent();
    }

    private async void btnAddTask_Clicked(object sender, EventArgs e)
    {
        var vm = BindingContext as NewTaskViewModel;
        var selectedCategory = vm.Categories.Where(c => c.IsSelected == true).FirstOrDefault();


        if (String.IsNullOrEmpty(vm.Task))
        {
            await DisplayAlert("Error", "Please enter a valid Task name", "OK");
            return;
        }
        if (selectedCategory == null)
        {
            await DisplayAlert("Error", "Please select a category", "OK");
            return;            
        }


        var task = new MyTask
        {
            TaskName = vm.Task,
            CategoryId = selectedCategory.Id
        };

        vm.Tasks.Add(task);
        await Navigation.PopAsync();
    }

    private async void btnAddCategory_Clicked(object sender, EventArgs e)
    {
        var vm = BindingContext as NewTaskViewModel;
        string category =
            await DisplayPromptAsync("New Category", "Enter the name of the new category", maxLength: 15, keyboard: Keyboard.Text);

        var r = new Random();

        if (!string.IsNullOrEmpty(category))
        {
            vm.Categories.Add(new Category
            {
                Id = vm.Categories.Max(c => c.Id) + 1,
                Color = Color.FromRgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255)).ToHex(),
                CategoryName = category
            });
        }
    }
}