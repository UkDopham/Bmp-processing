using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Traitement_image_Wpf.Views
{
    /// <summary>
    /// Logique d'interaction pour HistoriqueWindow.xaml
    /// </summary>
    public partial class HistoriqueWindow : Window
    {
        public HistoriqueWindow(List<string> historique)
        {
            InitializeComponent();
			this.HistoriqueListBox.ItemsSource = historique;
        }

		#region Clique gauche
		private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			this.DragMove();
		}
		#endregion

		#region Boutons
		private void FermerButtonClick(object sender, RoutedEventArgs e)
		{
			Close();
		}
		#endregion
	}
}
