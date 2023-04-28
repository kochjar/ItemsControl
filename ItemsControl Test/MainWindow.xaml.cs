using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xaml.Permissions;
using HuseByg.model;

namespace ItemsControl_Test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        public ObservableCollection<Hus> huse { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            List<Lejer> lejere = new List<Lejer>() { 
                new Lejer("Hans", "10203040", "hans@gmail.com")
            };
            Lejemål lejemål1 = new Lejemål(new DateTime(2010, 1, 1), new DateTime(2015, 1, 1), 20000, lejere, 0, 1);
            Hus hus1 = new Hus("Søndergade 1, 8000 Aarhus", HusType.Stor, 70, 3);
            hus1.TilføjLejemål(lejemål1);
            hus1.LejemålFindes = true;
            DataContext = this;
            huse = new ObservableCollection<Hus>()
            {
                hus1,
                new Hus("Søndergade 2, 8000 Aarhus", HusType.Stor, 70, 3),
                new Hus("Søndergade 3, 8000 Aarhus", HusType.Lille, 50, 2),   
            };

        }



        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var hus = ((FrameworkElement)sender).DataContext as Hus;
            if (hus != null)
            {
                // Open a dialog box
                Debug.WriteLine($"Der blev fundet et hus. {hus.HusId},{hus.Adresse},{hus.Kvm} kvm");
                hus.Lejemål = null;
            } else
            {
                Debug.WriteLine("Der blev IKKE fundet et hus.");
            }
        }


    }
}
