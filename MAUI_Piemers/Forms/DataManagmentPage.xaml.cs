using Microsoft.Maui.Controls.Shapes;
using Geometry;

namespace MAUI_Piemers.Forms;



public partial class DataManagmentPage : ContentPage
{
	public DataManagmentPage()
	{
		InitializeComponent();
        dm = MyStaticItems.myDm;
	}

    private IDataManager dm;

    private void btnTestData_Clicked(object sender, EventArgs e)
    {
        dm.CreateTestData();
        lblData.Text = dm.Print();
    }

    private void btnReset_Clicked(object sender, EventArgs e)
    {
        dm.Reset();
        lblData.Text = dm.Print();
    }

    private void btnSave_Clicked(object sender, EventArgs e)
    {
        dm.Save();
    }

    private void btnLoad_Clicked(object sender, EventArgs e)
    {
        dm.Load();
        lblData.Text = dm.Print();
    }

    private void btnPrint_Clicked(object sender, EventArgs e)
    {
        lblData.Text = dm.Print();
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        lblData.Text = dm.Print();
    }
}