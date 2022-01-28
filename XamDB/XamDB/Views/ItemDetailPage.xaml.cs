using System.ComponentModel;
using Xamarin.Forms;
using XamDB.ViewModels;

namespace XamDB.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}