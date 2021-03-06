﻿using App4.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace App4
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddInfo2 : Page
    {
        private string profile_pic = "";
        public AddInfo2()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            profile_pic = (string)e.Parameter;
        }

        public void clearForm()
        {
            name.Text = "";
            ID.Text = "";
            Whistband.Text = "";
        }
        public void clearIDForm()
        {
            ID.Text = "";
            Whistband.Text = "";
        }

        private async void save_Click(object sender, RoutedEventArgs e)
        {
            if (name.Text == "" || Whistband.Text == "" || ID.Text == "")
            {
                MessageDialog ms = new MessageDialog("Please fill the box below.");
                await ms.ShowAsync();
                
            }
            else
            {
                if (IsAllDigits(ID.Text) && IsAllDigits(Whistband.Text))
                {
                    User user = new User(name.Text, Double.Parse(ID.Text), profile_pic, Int32.Parse(Whistband.Text));
                    user.registerUser();
                    clearIDForm();
                }
                else
                {
                    var messageDialog = new MessageDialog("Please fill number in ID and WristbandID");
                    await messageDialog.ShowAsync();
                }
            }
        }
        private bool IsAllDigits(string s)
        {
            foreach (char c in s)
            {
                if (!char.IsDigit(c))
                    return false;
            }
            return true;
        }
    }
}
