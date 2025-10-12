using Geometry;

namespace TestLekcija6_7.Forms;

public partial class AddSquare : ContentPage
{
	public IAddFigure dm;
	public AddSquare()
	{
		InitializeComponent();
        cboKrasa.ItemsSource = Enum.GetNames(typeof(ColorEnum));
        dm = MyStaticItems.myDm;
	}

	private Square _sq =  null;
	//EditSquare
    public AddSquare(Square sq):this()
    {
        _sq=sq;
		txtMala.Text = sq.Edge.ToString() ?? "0";
		cboKrasa.SelectedItem = sq.MyColor.ToString() ?? "Blue" ;
        txtNosaukums.Text = sq.Name?.ToString() ?? "";
		btnAdd.Text = "Labot";
	}

    private async void btnAdd_Clicked(object sender, EventArgs e)
    {
		int? i = int.Parse(txtMala.Text);
		if (i != null && i > 0)
		{
			
				
            if (_sq is null)
            {
                Square sq = new Square();
                sq.Edge = i ?? 0;
                if (txtNosaukums.Text.Length > 0) { sq.Name = txtNosaukums.Text; }
                if (cboKrasa.SelectedIndex != -1)
                {
                    sq.MyColor = (ColorEnum)cboKrasa.SelectedIndex;
                }
                dm.Add(sq);
                await Shell.Current.GoToAsync("//FigureList");

            }
            else
			{
               _sq.Edge = i ?? 0;
                if (txtNosaukums.Text.Length > 0) { _sq.Name = txtNosaukums.Text; }
                if (cboKrasa.SelectedIndex != -1)
                {
                    _sq.MyColor = (ColorEnum)cboKrasa.SelectedIndex;
                }
                Navigation.PopAsync();
            }
		}
		
    }
}