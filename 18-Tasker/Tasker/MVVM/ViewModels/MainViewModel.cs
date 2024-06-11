using PropertyChanged;
using System.Collections.ObjectModel;
using System.Net.Http.Headers;
using Tasker.MVVM.Models;

namespace Tasker.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class MainViewModel
    {

        public ObservableCollection<Category> Categories{ get; set; }
        public ObservableCollection<MyTask> Tasks{ get; set; }

        public MainViewModel()
        {
            FillData();            
        }

        private void FillData()
        {
Categories = new ObservableCollection<Category>
               {
                    new Category
                    {
                         Id = 1,
                         CategoryName = ".NET MAUI Course",
                         Color = "#CF14DF"
                    },
                    new Category
                    {
                         Id = 2,
                         CategoryName = "Tutorials",
                         Color = "#df6f14"
                    },
                    new Category
                    {
                         Id = 3,
                         CategoryName = "Shopping",
                         Color = "#14df80"
                    }
               };

               Tasks = new ObservableCollection<MyTask>
               {
                    new MyTask
                    {
                         TaskName = "Upload exercise files",
                         Completed = false,
                         CategoryId = 1
                    },
                    new MyTask
                    {
                         TaskName = "Plan next course",
                         Completed = false,
                         CategoryId = 1
                    },
                    new MyTask
                    {
                         TaskName = "Upload new ASP.NET video on YouTube",
                         Completed = false,
                         CategoryId = 2
                    },
                    new MyTask
                    {
                         TaskName = "Fix Settings.cs class of the project",
                         Completed = false,
                         CategoryId = 2
                    },
                    new MyTask
                    {
                         TaskName = "Update github repository",
                         Completed = true,
                         CategoryId = 2
                    },
                    new MyTask
                    {
                         TaskName = "Buy eggs",
                         Completed = false,
                         CategoryId = 3
                    },
                    new MyTask
                    {
                         TaskName = "Go for the pepperoni pizza",
                         Completed = false,
                         CategoryId = 3
                    },
               };

               UpdateData();
          }

          public void UpdateData()
          {
               foreach (var c in Categories)
               {
                    var tasks = from t in Tasks
                                where t.CategoryId == c.Id
                                select t;

                    var completed = from t in tasks
                                    where t.Completed == true
                                    select t;

                    var notCompleted = from t in tasks
                                       where t.Completed == false
                                       select t;



                    c.PendingTasks = notCompleted.Count();
                    c.Percentage = (float)completed.Count() / (float)tasks.Count();
               }
               foreach (var t in Tasks)
               {
                    var catColor =
                         (from c in Categories
                          where c.Id == t.CategoryId
                          select c.Color).FirstOrDefault();
                    t.TaskColor = catColor;
               }
          }

     }
}
