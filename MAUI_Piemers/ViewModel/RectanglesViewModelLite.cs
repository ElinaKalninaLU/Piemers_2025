using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Geometry;
using SQLiteClasses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI_Piemers.ViewModel
{
    //Lai var izmantot Mvvm anotācijas tālāk
    [ObservableObject]
    public partial class RectanglesViewModelLite : IRectangleViewModel
    {
        //SQLite DB
        private DBClass _dBManager { get; set; }

        public RectanglesViewModelLite() {
            _dBManager = new DBClass();
            refresh();
        }

        //Izveido Height publisku property ar change notification. 
        //Binding izmantojam Height
        [ObservableProperty]
        private int height = 0;

        [ObservableProperty]
        private int width = 0;

        [ObservableProperty]
        private string? name = "";

        //parādīs paziņojumu, kāda darbība paveikta
        [ObservableProperty]
        private string info = "";

        //poga Add vai Update
        [ObservableProperty]
        private string submitButtonText = "Add Rectangle";

        //saraksts ar taisnstūriem DB
        [ObservableProperty]
        private ObservableCollection<IRectangle> rectangleList = new ObservableCollection<IRectangle>() { new RectangleLite() { Height = 1, Width = 1 } };

        //izvēlētais taisnstūris, ko rediģēt
        [ObservableProperty]
        private IRectangle selectedRectangle;

        [ObservableProperty]
        private bool isDeleteVisible = false;

        [ObservableProperty]
        private string[] colorValues = Enum.GetNames(typeof(Geometry.ColorEnum));

        [ObservableProperty]
        private string selectedColor = ColorEnum.Black.ToString();

        private RectangleLite UpdateRectangle = null;


        //izveido IRelayCommand addRectangleCommand { get; }
        //komandai pieliek delegātu uz šo metodi
        [RelayCommand]
        private void addRectangle()
        {
            if (UpdateRectangle is null)
            {
                //izvēlēto krāsu no string pārvērš par Enum
                var sc = Enum.Parse<ColorEnum>(SelectedColor);
                _dBManager.AddRectangle(height, width, name, sc);
                Info = "Rectangle Added";
            }
            else
            {
                UpdateRectangle.Height = Height;
                UpdateRectangle.Width = Width;
                UpdateRectangle.Name = Name;
                UpdateRectangle.MyColor = Enum.Parse<Geometry.ColorEnum>(selectedColor);
                //atšķirība no koda
                _dBManager.UpdateRectangle(UpdateRectangle);
                Info = "Rectangle updated!";
                endEdit();
            }
            refresh();
        }

        //dabū no DB aktuālo elementu sarakstu
        [RelayCommand]
        private void refresh()
        {
            rectangleList.Clear();
            foreach (var r in _dBManager.GetRectangles())
            {
                rectangleList.Add(r);
            }
        }

        //izdzēšam izvēlēto un pārejam uz pievienošanas režīmu
        [RelayCommand]
        private void delete()
        {
            if (UpdateRectangle != null)
            {

                _dBManager.RemoveRectangle(UpdateRectangle);
                Info = "Rectangle deleted!";
                endEdit();
                refresh();
            }
        }

        //pārslēdzamies no Edit modes uz Add modi
        private void endEdit()
        {
            UpdateRectangle = null;
            SelectedRectangle = null;
            SubmitButtonText = "Add Rectangle";
            IsDeleteVisible = false;
        }

        //pārslēdzamies no Add modes uz Edit modi
        private void startEdit()
        {
            SubmitButtonText = "Update Rectangle";
            IsDeleteVisible = true;
        }

        //izvēlēts taisnstūris un sākam viņa labošanu
        [RelayCommand]
        private void itemSelected()
        {
            if (SelectedRectangle != null)
            {
                Width = SelectedRectangle.Width;
                Height = SelectedRectangle.Height;
                Name = SelectedRectangle.Name;
                SelectedColor = SelectedRectangle.MyColor.ToString();
                if (SelectedRectangle is RectangleLite)
                {
                    UpdateRectangle = (RectangleLite)SelectedRectangle;
                    
                }
                startEdit();
            }
        }

        //izvēlēts taisnstūris un sākam viņa labošanu
        [RelayCommand]
        private void itemSelectedParam(IRectangle r)
        {
            SelectedRectangle = r;
            itemSelected();
        }

    }
}
