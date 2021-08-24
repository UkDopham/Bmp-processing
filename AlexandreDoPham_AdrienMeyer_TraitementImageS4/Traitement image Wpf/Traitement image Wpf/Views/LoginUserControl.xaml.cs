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
	/// Logique d'interaction pour LoginUserControl.xaml
	/// </summary>
	public partial class LoginUserControl : UserControl
	{
		private Login _login;
		
		public LoginUserControl()
		{
			this._login = new Login();
			InitializeComponent();
			DataContext = this._login;
		}

		#region Boutons
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			Window fenetre = Window.GetWindow(this);
			fenetre.DataContext = new MenuUserControl(this._login.Identifiant);
		}

		private void FermerButtonClick(object sender, RoutedEventArgs e)
		{
			Window fenetre = Window.GetWindow(this);
			fenetre.Close();
		}

		private void inviteButton(object sender, RoutedEventArgs e)
		{
			this._login.Identifiant = "invité";
			Button_Click(sender, e);
		}
		#endregion

		#region Clique Gauche
		private void BorderMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			Window fenetre = Window.GetWindow(this);
			fenetre.DragMove();
		}
		#endregion
	}
}
