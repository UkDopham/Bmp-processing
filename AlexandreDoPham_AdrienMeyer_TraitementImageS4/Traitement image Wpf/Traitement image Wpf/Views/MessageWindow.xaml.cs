using Do_Pham_Alexandre_Meyer_Adrien_Probleme;
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
	/// Logique d'interaction pour MessageWindow.xaml
	/// </summary>
	public partial class MessageWindow : Window
	{
		private MessageViewModel _message = new MessageViewModel();

		public MessageViewModel MessageProp
		{
			get { return this._message; }
		}

		public bool ViewModel { get; internal set; }

		public MessageWindow()
		{
			InitializeComponent();
			this._message.Couleur = new Pixel(0, 0, 0); // de base couleur noir
			this.DataContext = _message;
		}

		#region Boutons
		private void ButtonClick(object sender, RoutedEventArgs e)
		{
			this.Close();
			//.message.Taille = this.tailleComboBox.SelectedValue.ToString;
			string passage = this.tailleComboBox.SelectedValue.ToString();
			string[] tabPass = passage.Split(':');
			this._message.Fait = true;
			this._message.Taille = Convert.ToInt32(tabPass[1]);
		}

		private void ColorButtonClick(object sender, RoutedEventArgs e)
		{
			ColorPalette colorPalette = new ColorPalette();
			colorPalette.ShowDialog();
			if (colorPalette.ColorViewModelsGetSet.Fait)
			{
				_message.Couleur = colorPalette.ColorViewModelsGetSet.Couleur;
			}
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
