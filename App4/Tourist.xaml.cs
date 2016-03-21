using App4.Model;
using System.Collections.ObjectModel;
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
    public sealed partial class Tourist : Page
    {

         private ObservableCollection<User> usersItems;
         public Tourist() 
         {
             this.InitializeComponent();
             usersItems = new ObservableCollection<User>();
             User.add("Tourist", usersItems);
         }
        /*private ObservableCollection<Book> booksItems;

        public Tourist()
        {
            this.InitializeComponent();
            booksItems = new ObservableCollection<Book>();
            BooksManager.GetBooks("Tourist", booksItems);
        }*/

    }
}