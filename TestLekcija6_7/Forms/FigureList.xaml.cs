using Geometry;

namespace TestLekcija6_7.Forms;

public partial class FigureList : ContentPage
{
	private JSONDataManager dm;
    public FigureList()
	{
		InitializeComponent();
		dm = MyStaticItems.myDm;
		cVList.ItemsSource = dm.fc.GfList;
    }

    

    private async void EditClicked(object sender, EventArgs e)
    {
        var b = sender as Button;
        if (b != null)
        {
            if (b.BindingContext is Square)
            {
                var sq = (Square)b.BindingContext;
                var sqPage = new AddSquare(sq);
                await Navigation.PushAsync(sqPage);
            }
            if (b.BindingContext is Rectangle)
            {
                var rc = (Rectangle)b.BindingContext;
                var sqPage = new AddRectangle(rc);
                await Navigation.PushAsync(sqPage);
            }
            if (b.BindingContext is Polygon)
            {
                var po = (Polygon)b.BindingContext;
                var sqPage = new AddPolygon(po);
                await Navigation.PushAsync(sqPage);
            }
        }
    }

    private async void DeleteClicked(object sender, EventArgs e)
    {
        if (sender is Button)
        {
            Button btn = (Button) sender;
            if (btn.BindingContext is GeometryFigure)
            {
                GeometryFigure f = (GeometryFigure)btn.BindingContext;
                bool answer = await DisplayAlert("Question?", "Vai gribat dz?st? " + f.ToString(), "yes", "no");
                if (answer)
                {
                   
                    dm.fc.GfList.Remove(f);
                    cVList.ItemsSource = null;
                    cVList.ItemsSource = dm.fc.GfList;
                }
            }
        }
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        cVList.ItemsSource = null;
        cVList.ItemsSource = dm.fc.GfList;
    }
}