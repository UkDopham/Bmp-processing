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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Traitement_image_Wpf.ViewModels;

namespace Traitement_image_Wpf.Views
{
    /// <summary>
    /// Logique d'interaction pour JeuUserControl.xaml
    /// </summary>
    public partial class JeuUserControl : UserControl
    {
		private JeuViewModel _jeuViewModel;

		public JeuUserControl(string nom)
        {
            InitializeComponent();
			this._jeuViewModel = new JeuViewModel(nom);
			this.DataContext = this._jeuViewModel;
			this.MusiquePlayer.Play();
		}

		#region Clique gauche
		private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			Window fenetre = Window.GetWindow(this);
			fenetre.DragMove();
		}
		#endregion

		#region Boutons
		private void FermerButtonClick(object sender, RoutedEventArgs e)
		{
			Window fenetre = Window.GetWindow(this);
			fenetre.Close();
		}

		private void ReponseButtonClick(object sender, RoutedEventArgs e)
		{
			bool termine = this._jeuViewModel.RepoonseBouton(((Button)sender).Name);
			if (termine)
			{
				Terminer();
			}
		}
		#endregion

		private void Terminer()
		{
			Window fenetre = Window.GetWindow(this);
			fenetre.DataContext = new MenuUserControl(this._jeuViewModel.Player.Nom);
		}
	}
}
