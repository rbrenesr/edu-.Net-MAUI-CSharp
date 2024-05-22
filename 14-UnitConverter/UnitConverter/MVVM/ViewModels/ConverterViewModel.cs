using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UnitsNet;

namespace UnitConverter.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class ConverterViewModel
    {
        public string QuantityName { get; set; }

        public ObservableCollection<string> FromMeasures { get; set; }
        public ObservableCollection<string> ToMeasures { get; set; }

        public string CurrentFromMeasure { get; set; }
        public string CurrentToMeasure { get; set; }

        public double FromValue { get; set; } = 1;
        public double ToValue { get; set; }

        public ICommand ReturnCommand => new Command(() => { Convert(); });

        public ConverterViewModel(string quantityName)
        {
            //QuantityName = "Length";
            QuantityName = quantityName;
            FromMeasures = LoadMeasures();
            ToMeasures = LoadMeasures();
            
            /*CurrentFromMeasure = "Meter";
            CurrentToMeasure = "Centimeter";*/

            CurrentFromMeasure = FromMeasures.FirstOrDefault();
            CurrentToMeasure = ToMeasures.Skip(1).FirstOrDefault();

            Convert();
        }

        public void Convert()
        {
            var result =
                UnitsNet.UnitConverter.ConvertByName(
                    FromValue,
                    QuantityName,
                    CurrentFromMeasure,
                    CurrentToMeasure);
            ToValue = result;
        }

        public ObservableCollection<string> LoadMeasures()
        {
            var types =
                Quantity.Infos
                .FirstOrDefault(q => q.Name == QuantityName)
                .UnitInfos
                .Select(u => u.Name)
                .ToList();

            return new ObservableCollection<string>(types);
        }

    }
}
