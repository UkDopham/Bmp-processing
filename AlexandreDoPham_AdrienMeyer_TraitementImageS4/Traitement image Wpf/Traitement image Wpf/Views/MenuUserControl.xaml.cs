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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Traitement_image_Wpf.ViewModels;

namespace Traitement_image_Wpf.Views
{
	/// <summary>
	/// Logique d'interaction pour MenuUserControl.xaml
	/// </summary>
	public partial class MenuUserControl : System.Windows.Controls.UserControl
	{
		private MenuViewModels _menu;
		private bool _click;
		
		public MenuUserControl(string identifiant)
		{
			InitializeComponent();
			this._menu = new MenuViewModels();
			this._menu.Nom = identifiant;
			this.DataContext = this._menu;
		}
		#region Boutons
		private void folderButtonClick(object sender, RoutedEventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "BMP files (*.bmp)|";
			openFileDialog.ShowDialog();
			this._menu.ImageVM.Image = new BitmapImage();
			string[] passage = openFileDialog.FileName.Split('.');

			if (!string.IsNullOrEmpty(openFileDialog.FileName)
				&& passage[1] == "bmp")//l'extension
			{
				this._menu.ImageVM.Path = openFileDialog.FileName;
				this._menu.Premier = true;
				this._menu.Initialisation();
			}
			else
			{
				if (!string.IsNullOrEmpty(openFileDialog.FileName))
				{
					MessageErreurBmp();
				}
			}
		}

		private void ButtonClick(object sender, RoutedEventArgs e)
		{
			if (!String.IsNullOrEmpty(this._menu.ImageVM.Path))
			{
				this._menu.Operation = ((System.Windows.Controls.Button)sender).Name; //unboxing
				this._menu.TraitementOperation();
			}
			else
			{
				MessageErreurBmp();
			}
		}

		private void messageBoutonClick(object sender, RoutedEventArgs e)
		{
			MessageWindow _message = new MessageWindow();
			if (!String.IsNullOrEmpty(this._menu.ImageVM.Path))
			{
				_message.ShowDialog();
			}
			else
			{
				MessageErreurBmp();
			}
			if (_message.MessageProp.Fait)
			{
				this._menu.MessageViewModelGetSet = _message.MessageProp;
				ButtonClick(sender, e);
			}
		}

		private void pixelBoutonClick(object sender, RoutedEventArgs e)
		{
			PixelisationWindow _pixelisationWindow = new PixelisationWindow();
			if (String.IsNullOrEmpty(this._menu.ImageVM.Path))
			{
				MessageErreurBmp();
			}
			else
			{
				_pixelisationWindow.ShowDialog();
			}
			if (_pixelisationWindow.PixelisationVM.Fait)
			{
				this._menu.PixelisationVM = _pixelisationWindow.PixelisationVM;
				ButtonClick(sender, e);
			}
		}

		private void redimensionBoutonClick(object sender, RoutedEventArgs e)
		{
			RedimensionWindow _redimensionWindow = new RedimensionWindow();
			if (String.IsNullOrEmpty(this._menu.ImageVM.Path))
			{
				MessageErreurBmp();
			}
			else
			{
				_redimensionWindow.ShowDialog();
			}
			if (_redimensionWindow.RedimensionVM.Fait)
			{
				this._menu.RedimensionVM = _redimensionWindow.RedimensionVM;
				ButtonClick(sender, e);
			}
		}

		private void fractaleBoutonClick(object sender, RoutedEventArgs e)
		{
			RedimensionWindow _redimensionWindow = new RedimensionWindow();
			_redimensionWindow.ShowDialog();
			if (_redimensionWindow.RedimensionVM.Fait)
			{
				this._menu.RedimensionVM = _redimensionWindow.RedimensionVM;
				string path = AppDomain.CurrentDomain.BaseDirectory;
				path += "Sans titre.bmp";
				this._menu.ImageVM.Path = path;
				this._menu.Initialisation();
				ButtonClick(sender, e);
			}
		}

		private void PersoBoutonClick(object sender, RoutedEventArgs e)
		{
			DemandeUtilisateurWindow _demandeUtilisateurWindow = new DemandeUtilisateurWindow();
			if (String.IsNullOrEmpty(this._menu.ImageVM.Path))
			{
				MessageErreurBmp();
			}
			else
			{
				string nomBouton = ((System.Windows.Controls.Button)sender).Name.ToString(); //unboxing
				_demandeUtilisateurWindow.DemandeUtilisateurVM.ConfigDefault(nomBouton);
				_demandeUtilisateurWindow.ShowDialog();
			}
			if (_demandeUtilisateurWindow.DemandeUtilisateurVM.Fait)
			{
				ButtonClick(sender, e);
			}

		}

		private void convolutionBoutonClick(object sender, RoutedEventArgs e)
		{
			MatriceConvolutionWindow _matriceConvolutionWindow = new MatriceConvolutionWindow();
			if (String.IsNullOrEmpty(this._menu.ImageVM.Path))
			{
				MessageErreurBmp();
			}
			else
			{
				_matriceConvolutionWindow.ShowDialog();
			}
			if (_matriceConvolutionWindow.MatriceConvolutionVM.Fait)
			{
				this._menu.MatriceConvolutionVM = _matriceConvolutionWindow.MatriceConvolutionVM;
				ButtonClick(sender, e);
			}
		}

		private void imageCacheBoutonClick(object sender, RoutedEventArgs e)
		{
			if (String.IsNullOrEmpty(this._menu.ImageVM.Path))
			{
				MessageErreurBmp();
			}
			else
			{
				OpenFileDialog openFileDialog = new OpenFileDialog();
				openFileDialog.ShowDialog();
				this._menu.PathDeuxImage = openFileDialog.FileName;
			}
			if (this._menu.PathDeuxImage != null)
			{
				ButtonClick(sender, e);
			}
		}		

		private void CouleurButtonClick(object sender, RoutedEventArgs e)
		{
			if (!String.IsNullOrEmpty(this._menu.ImageVM.Path))
			{
				string couleurHexa = ((System.Windows.Controls.Button)sender).Background.ToString();
				this._menu.Pos.ColorVM.HexaToByte(couleurHexa);
			}
			else
			{
				MessageErreurBmp();
			}
		}

		private void EnregistrerButtonClick(object sender, RoutedEventArgs e)
		{
			if (!String.IsNullOrEmpty(this._menu.ImageVM.Path))
			{
				SaveFileDialog _saveFileDialog = new SaveFileDialog();
				_saveFileDialog.Filter = "BMP files (*.bmp)|";
				_saveFileDialog.ShowDialog();
				if (!String.IsNullOrEmpty(_saveFileDialog.FileName))
				{
					string nom = _saveFileDialog.FileName;
					string[] passage = _saveFileDialog.FileName.Split('.');
					if (passage[passage.Length-1] !="bmp")
					{
						nom +=".bmp";
					}
					this._menu.Enregistrer(nom);
				}
			}
			else
			{
				MessageErreurBmp();
			}
		}

		private void FermerButtonClick(object sender, RoutedEventArgs e)
		{
			Window fenetre = Window.GetWindow(this);
			fenetre.Close();
		}

		private void NewButtonClick(object sender, RoutedEventArgs e)
		{
			this._menu.ImageVM.Path = "Sans titre.bmp";
			this._menu.Premier = true;
			this._menu.Initialisation();
		}

		private void RetourButtonClick(object sender, RoutedEventArgs e)
		{
			if (!String.IsNullOrEmpty(this._menu.ImageVM.Path))
			{
				this._menu.BackUp();
			}
			else
			{
				MessageErreurBmp();
			}
		}

		private void HistoriqueButtonClick(object sender, RoutedEventArgs e)
		{
			HistoriqueWindow _historiqueWindow = new HistoriqueWindow(this._menu.Historique);
			_historiqueWindow.ShowDialog();
		}


		private void jeuBouton_Click(object sender, RoutedEventArgs e)
		{
			Window fenetre = Window.GetWindow(this);
			fenetre.DataContext = new JeuUserControl(this.loginTextBlock.Text);
		}
		#endregion

		#region Clique gauche

		private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			Window fenetre = Window.GetWindow(this);
			fenetre.DragMove();
		}


		private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			this._click = true;
		}

		private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			this._click = false;
		}

		#endregion

		private void Image_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
		{
			if (this._click)
			{
				Point clickPoint = e.GetPosition(this.bmpImage);
				string passage = this.FontSizeComboBox.SelectedValue.ToString();
				string[] tabPass = passage.Split(':');

				this._menu.Pos.Taille = Convert.ToInt32(tabPass[1]);
				this._menu.Pos.LigneVrai = Convert.ToInt32(this.bmpImage.ActualHeight); //taille de pix affichage dans l'UI
				this._menu.Pos.ColonneVrai = Convert.ToInt32(this.bmpImage.ActualWidth);
				this._menu.Pos.LigneActu = this._menu.Image.MatPixel.GetLength(0); //taille en pixel
				this._menu.Pos.ColonneActu = this._menu.Image.MatPixel.GetLength(1);
				this._menu.Pos.Colonne = Convert.ToInt32(clickPoint.X);
				this._menu.Pos.Ligne = Convert.ToInt32(clickPoint.Y);
				this._menu.Operation = "coloriage";
				this._menu.TraitementOperation();
			}
		}

		private void MessageErreurBmp()
		{
			System.Windows.MessageBox.Show("Impossible, il faut selectionner un fichier .bmp d'abord",
					"Erreur",
					MessageBoxButton.OK,
					MessageBoxImage.Error); ;
		}

	}
}
