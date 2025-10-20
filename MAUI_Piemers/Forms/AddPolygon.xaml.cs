using Geometry;

namespace MAUI_Piemers.Forms;

public partial class AddPolygon : ContentPage
{
    private List<Geometry.Point> points = new List<Geometry.Point>();
    public IAddFigure dm;
    public AddPolygon()
    {
        InitializeComponent();
        resetPointList();
        dm = MyStaticItems.myDm.fc;
    }
    private Polygon _poly;
    public AddPolygon(Polygon poly) : this()
    {
        _poly = poly;
        points = poly.Points;
        resetPointList();
        btnAddPolygon.Text = "Labot";

    }
    private void btnAddPoint_Clicked(object sender, EventArgs e)
    {
        int x = int.Parse(txtX.Text);
        int y = int.Parse(txtY.Text);
        if (x > 0 && y > 0)
        {
            points.Add(new Geometry.Point(x, y));
            resetPointList();
        }
    }
    private void resetPointList()
    {
        lwPointList.ItemsSource = null;
        lwPointList.ItemsSource = points;
    }

    private void btnRemovePoint_Clicked(object sender, EventArgs e)
    {
        if (lwPointList.SelectedItem != null)
        {
            points.Remove((Geometry.Point)lwPointList.SelectedItem);
            resetPointList();
        }
    }

    private async void btnAddPolygon_Clicked(object sender, EventArgs e)
    {
        if (_poly != null)
        {
            if (points.Count > 0)
            {
                _poly.Points = points;
            }
            Navigation.PopAsync();
        }
        else
        {

            if (points.Count > 0)
            {
                var poly = new Polygon();
                poly.Points = points;
                dm.Add(poly);
                await Shell.Current.GoToAsync("//FigureList");

            }
        }
    }
}