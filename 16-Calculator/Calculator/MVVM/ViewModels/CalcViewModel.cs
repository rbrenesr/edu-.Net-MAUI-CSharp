using Dangl.Calculator;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Calculator.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class CalcViewModel
    {
        public string Formula { get; set; } = "";
        public string Result { get; set; } = "0";

        public ICommand OperationCommand => new Command((number) => { Formula += number; });
        public ICommand ResetCommand => new Command(() => { Formula = ""; Result = "0"; });
        public ICommand BackSpaceCommand => new Command(() => { 
        
            if (Formula.Length > 0)
            {
                Formula = Formula.Substring(0, Formula.Length - 1);
            }

        });
        public ICommand CalculateCommand => new Command(() => {
            try
            {
                if (Formula.Length == 0)
                {
                    return; 
                }

                var calculation = Dangl.Calculator.Calculator.Calculate(Formula);
                Result = calculation.Result.ToString();

            }
            catch (Exception)
            {
                Result = "Error";
            }
        });
    }
}
