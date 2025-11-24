using MAUI_Piemers.ViewModel;

namespace MAUI_Piemers.Views;

public partial class RectangleView : ContentPage
{
    private IRectangleViewModel _vm;
    public RectangleView(IRectangleViewModel vm)
    {
        _vm = vm;
        this.BindingContext = _vm;
        InitializeComponent();
    }

}