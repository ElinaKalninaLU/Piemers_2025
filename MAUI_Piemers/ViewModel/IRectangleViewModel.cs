using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SQLiteClasses;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MAUI_Piemers.ViewModel
{
    public interface IRectangleViewModel
    {
        int Width { get; set; }
        int Height { get; set; }
        string Info { get; set; }
        string? Name { get; set; }
        string SubmitButtonText { get; set; }
        string[] ColorValues { get; set; }
        string SelectedColor { get; set; }
        ObservableCollection<IRectangle> RectangleList { get; set; }
        IRectangle SelectedRectangle { get; set; }
        bool IsDeleteVisible {  get; set; }

        IRelayCommand addRectangleCommand { get; }

        IRelayCommand deleteCommand { get; }

        IRelayCommand itemSelectedCommand { get; }

    }
}
