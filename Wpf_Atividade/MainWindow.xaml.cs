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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wpf_Estudos.Forms;

namespace Wpf_Estudos
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btCadastrar_Click(object sender, RoutedEventArgs e)
        {
            CadastrarContato form = new CadastrarContato();
            form.ShowDialog();
        }

        private void btListar_Click(object sender, RoutedEventArgs e)
        {
            ListarContatos form = new ListarContatos();
            form.ShowDialog();
        }
    }
}
