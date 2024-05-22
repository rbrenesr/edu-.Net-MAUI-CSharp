using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigationDemo.Utilities
{
    public static class NavUtilities
    {
        public static void Examine(INavigation navigation) { 
        StringBuilder sb = new StringBuilder();

            foreach (var page in navigation.NavigationStack)
            {
                sb.AppendLine(page.GetType().Name);
            }

            sb.AppendLine("-------------");
            Debug.WriteLine(sb.ToString());

        }
    }
}
