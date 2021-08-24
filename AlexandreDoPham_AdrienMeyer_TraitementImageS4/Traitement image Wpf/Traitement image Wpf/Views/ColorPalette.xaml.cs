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
	/// Logique d'interaction pour ColorPalette.xaml
	/// </summary>
	public partial class ColorPalette : Window
	{
		private ColorViewModels _colorViewModels = new ColorViewModels();

		public ColorViewModels ColorViewModelsGetSet
		{
			get { return this._colorViewModels; }
		}

		public ColorPalette()
		{
			InitializeComponent();
		}

		#region Boutons
		private void ButtonClick(object sender, RoutedEventArgs e)
		{
			string couleurHexa = ((Button)sender).Background.ToString();
			_colorViewModels.HexaToByte(couleurHexa);
			_colorViewModels.Fait = true;
			this.Close();
		}
		#endregion
	}
}
