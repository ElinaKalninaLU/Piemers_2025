using Geometry;

namespace TestLekcija6_7.Forms;

public partial class AddRectangle : ContentPage
{
	public IAddFigure dm;
	public AddRectangle()
	{
		InitializeComponent();
        cboKrasa.ItemsSource = Enum.GetNames(typeof(ColorEnum));
        dm = MyStaticItems.myDm;
	}

    private Rectangle _rec;
    public AddRectangle(Rectangle rec):this()
    {
        _rec= rec;
        txtX.Text = _rec.Width.ToString() ?? "0";
        txtY.Text = _rec.Height.ToString() ?? "0";
        cboKrasa.SelectedItem = _rec.MyColor.ToString() ?? "Blue";
        txtNosaukums.Text = _rec.Name?.ToString() ?? "";
        btnAdd.Text = "Labot";
    }

    private async void btnAdd_Clicked(object sender, EventArgs e)
    {
		int? x = int.Parse(txtX.Text);
        int? y = int.Parse(txtY.Text);
        if (x != null && x > 0 && y != null && y > 0)
		{
            if (_rec is null)
            {
                Rectangle rec = new Rectangle();
                rec.Height = x ?? 0;
                rec.Width = y ?? 0;
                if (txtNosaukums.Text.Length > 0) { rec.Name = txtNosaukums.Text; }
                if (cboKrasa.SelectedIndex != -1) { rec.MyColor = (ColorEnum)cboKrasa.SelectedIndex; }
                dm.Add(rec);
                await Shell.Current.GoToAsync("//FigureList");
            }
            else {
                _rec.Width = x ?? 0;
                _rec.Height = y ?? 0;
                if (txtNosaukums.Text.Length > 0) { _rec.Name = txtNosaukums.Text; }
                if (cboKrasa.SelectedIndex != -1)
                {
                    _rec.MyColor = (ColorEnum)cboKrasa.SelectedIndex;
                }
                Navigation.PopAsync();
            }
		}
		
    }
}