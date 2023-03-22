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

namespace ISP22_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<int> ints = new List<int>(); 
        private List<double> doubles = new List<double>();  
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string str = txtMassiv.Text;
                string[] strings = str.Split(',');
                string result = "";
                foreach (string s in strings)
                {
                    ints.Add(int.Parse(s));
                    result += s + " ";
                }
                txbMassiv.Text = result;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtMassiv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 ||
                e.Key == Key.OemComma || e.Key == Key.Back) return;
            e.Handled = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int P = 1;
            foreach (int item in ints)
            {
                if(item>=2&&item<8) P*=item;
            }
            txbResult.Text = "Произведение элементов от [2,8) равно:"+P;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            for (int i = 0; i < int.Parse(txtSize.Text); i++)
            {
                double n = random.NextDouble() * 100-50;
                doubles.Add(n);
                txbGenMassiv.Text += n.ToString("F2") + " ";
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            int count = 0;
            foreach (double item in doubles)
            {
                if (item > -15 && item < 4) count++;
            }
            txbDoubleResult.Text = count.ToString();
        }
    }
}