using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
        public AddInfo2()
        {
            this.InitializeComponent();
        }
        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void submit_Click(object sender, RoutedEventArgs e)
        {
            User user = new User(name.Text,Int32.Parse(ID.Text),111,Int32.Parse(Whistband.Text));
            user.save();

        }
    }
}
