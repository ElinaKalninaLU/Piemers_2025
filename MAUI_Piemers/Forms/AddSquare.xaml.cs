using Geometry;

namespace MAUI_Piemers.Forms;

public partial class AddSquare : ContentPage
{
	private IAddFigure fc;
	public AddSquare()
	{
		InitializeComponent();
        cboKrasa.ItemsSource = Enum.GetNames(typeof(ColorEnum));
        fc = MyStaticItems.myDm.fc;
    }

    private Square sq;
    public AddSquare(Square _sq):this()
    {
        sq=_sq;
        txtMala.Text = sq.Edge.ToString() ?? "0";
        cboKrasa.SelectedItem = sq.MyColor.ToString() ?? "Blue";
        txtNosaukums.Text = sq.Name?.ToString() ?? "";
        btnAdd.Text = "Labot";
    }

    private async void btnAdd_Clicked(object sender, EventArgs e)
    {
        int? i = int.Parse(txtMala.Text);
        if (i != null && i > 0)
        {
            if (sq is null)
            {
                Square sq = new Square();
                sq.Edge = i ?? 0;
                if (txtNosaukums.Text.Length > 0) { sq.Name = txtNosaukums.Text; }
                if (cboKrasa.SelectedIndex != -1)
                {
                    sq.MyColor = (ColorEnum)cboKrasa.SelectedIndex;
                }
                fc.Add(sq);
                await Shell.Current.GoToAsync("//DataManagmentPage");
            }
            else {
                sq.Edge = i ?? 0;
                if (txtNosaukums.Text.Length > 0) { sq.Name = txtNosaukums.Text; }
                if (cboKrasa.SelectedIndex != -1)
                {
                    sq.MyColor = (ColorEnum)cboKrasa.SelectedIndex;
                }
                Navigation.PopAsync();
            }
        }
    }
}