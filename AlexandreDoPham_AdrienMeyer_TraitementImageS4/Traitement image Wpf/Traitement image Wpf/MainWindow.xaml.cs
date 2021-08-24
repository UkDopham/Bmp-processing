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
using Traitement_image_Wpf.Views;

namespace Traitement_image_Wpf
{
	/// <summary>
	/// Logique d'interaction pour MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public LoginUserControl _loginUC;

		public MainWindow()
		{
			this._loginUC = new LoginUserControl();
			InitializeComponent();
			DataContext = this._loginUC;
		}
		
	}
}
