﻿using Microsoft.Win32;
using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PorraGironaCSharp.Capes.View
{
    /// <summary>
    /// Lógica de interacción para AltaEquip.xaml
    /// </summary>
    public partial class AltaEquip : UserControl
    {
        public AltaEquip()
        {
            InitializeComponent();
        }

        private void ButtonAfegirImatge_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = "c:\\"
            };
            openFileDialog.ShowDialog();
            TextBoxImatge.Text = openFileDialog.FileName;
        }
    }
}
