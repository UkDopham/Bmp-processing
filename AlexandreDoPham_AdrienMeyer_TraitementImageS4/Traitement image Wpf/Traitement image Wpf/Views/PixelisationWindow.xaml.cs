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
using Traitement_image_Wpf.ViewModels;

namespace Traitement_image_Wpf.Views
{
	/// <summary>
	/// Logique d'interaction pour PixelisationWindow.xaml
	/// </summary>
	public partial class PixelisationWindow : Window
	{
		private PixelisationViewModel _pixelisationVM = new PixelisationViewModel();

		public PixelisationViewModel PixelisationVM
		{
			get { return this._pixelisationVM; }
		}

		public PixelisationWindow()
		{
			InitializeComponent();
		}

		#region Boutons
		private void ButtonClick(object sender, RoutedEventArgs e)
		{
			this._pixelisationVM.TaillePixelisation = Convert.ToInt32(this.pixelTextBlock.Text);
			this._pixelisationVM.Fait = true;
			this.Close();
		}

		private void FermerButtonClick(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
		#endregion

		#region Clique gauche
		private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			this.DragMove();
		}
		#endregion
	}
}
