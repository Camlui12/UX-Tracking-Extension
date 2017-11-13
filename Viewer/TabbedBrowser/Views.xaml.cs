﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;

namespace EO.TabbedBrowser
{
    /// <summary>
    /// Interaction logic for Views.xaml
    /// </summary>
    public partial class Views : Window
    {
        public Views()
        {
            InitializeComponent();
        }
        string[] directories;
        private void Window_ContentRendered(object sender, EventArgs e)
        {
            directories = Directory.GetDirectories(App.CurrentTraceFolder);
            Ltb_traces.Items.Clear();
            foreach (string rastro in directories)
            {
                Ltb_traces.Items.Add(System.IO.Path.GetFileNameWithoutExtension(rastro).Replace("_",":").Replace("-","/"));
            }
        }

        private void Ltb_traces_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int index = Ltb_traces.SelectedIndex;
            App.CurrentTrace = directories[index];
            Viewer viewer = new Viewer();
            viewer.ShowDialog();
        }
    }
}
