using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.MVVM.Models
{


    public class WeatherData
    {
        public float latitude { get; set; }
        public float longitude { get; set; }
        public float generationtime_ms { get; set; }
        public int utc_offset_seconds { get; set; }
          public float elevation { get; set; }
          public Current_Weather current_weather { get; set; }
          public Daily_Units daily_units { get; set; }
          public Daily daily { get; set; }
          public ObservableCollection<Daily2> daily2 { get; set; } =
               new ObservableCollection<Daily2>();
    }

     public class Current_Weather
     {
          public float temperature { get; set; }
          public float windspeed { get; set; }
          public float winddirection { get; set; }
          public float weathercode { get; set; }
          public string time { get; set; }
     }

     public class Daily_Units
     {
          public string time { get; set; }
          public string weathercode { get; set; }
          public string temperature_2m_max { get; set; }
          public string temperature_2m_min { get; set; }
     }

     public class Daily
     {
          public string[] time { get; set; }
          public float[] weathercode { get; set; }
          public float[] temperature_2m_max { get; set; }
          public float[] temperature_2m_min { get; set; }
     }

     public class Daily2
     {
          public string time { get; set; }
          public float weathercode { get; set; }
          public float temperature_2m_max { get; set; }
          public float temperature_2m_min { get; set; }
     }

}
