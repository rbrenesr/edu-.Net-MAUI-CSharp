using NavigationDemo.MVVM.Pages;
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
        public static void Examine(INavigation navigation)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var page in navigation.NavigationStack)
            {
                sb.AppendLine(page.GetType().Name);
            }

            sb.AppendLine("-------------");
            Debug.WriteLine(sb.ToString());

        }

        public static void InsertPage(INavigation navigation)
        {
            var secondPage = navigation.NavigationStack.ElementAtOrDefault(1);

            if (secondPage != null)
            {
                navigation.InsertPageBefore(new CoolPage(), secondPage);
            }
        }

        public static void RemovePage(INavigation navigation, string pageName)
        {
            var pagetoDelete = navigation.NavigationStack.FirstOrDefault(p => p.GetType().Name == pageName);

            if (pagetoDelete != null)
            {
                navigation.RemovePage(pagetoDelete);
            }
        }
    }
}
