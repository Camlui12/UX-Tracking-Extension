using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Reflection;
using System.IO;

namespace Lades.WebTracer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static string ExeDir { get; private set; }
        public static string CurrentTrace { get; set; }

        public static List<string> CurrentTraceList = new List<string>();
        public static string CurrentTraceFolder { get; set; }
        public static bool Compilation { get; set; } = false;

        public static int maxClicks = 0;
        public static int sizeFactor = 8;

        public static List<int> scrolls = new List<int>();

        public static ViewerFull vieweFull;

        public static Stats stats;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Splash splash = new Splash();
            splash.Show();
        }

        public static List<HeatPoint> ordenador(List<HeatPoint> source)
        {
            HeatPoint major = new HeatPoint();
            int pos = -1;
            for (int y = source.Count - 1; y > -1; y--)
            {
                major.Z = -3;
                for (int x = 0; x <= y; x++)
                {
                    if (major.Z < source[x].Z)
                    {
                        major.X = source[x].X;
                        major.Y = source[x].Y;
                        major.Z = source[x].Z;
                        pos = x;
                    }
                }
                HeatPoint heat = new HeatPoint();
                heat.X = source[y].X;
                heat.Y = source[y].Y;
                heat.Z = source[y].Z;
                source[y].X = major.X;
                source[y].Y = major.Y;
                source[y].Z = major.Z;
                source[pos].X = heat.X;
                source[pos].Y = heat.Y;
                source[pos].Z = heat.Z;
            }
            //foreach (HeatPoint point in source) result.Insert(0, point);
            return source;
        }

        public static int Find(string source, string pattern)
        {
            bool b = source.Contains(pattern);
            if (b)
            {
                int index = source.IndexOf(pattern);
                if (index >= 0)
                    return index;
            }
            return -1;
        }
    }
}
