using PropertyChanged;

namespace MVVMToolkitSample.MVVM.Models
{
     [AddINotifyPropertyChangedInterface]
     public class FakePerson
     {

          public string FirstName { get; set; }
          public string LastName { get; set; }
          public string FullName
          {
               get
               {
                    return $"{FirstName} {LastName}";
               }
          }
     }
}