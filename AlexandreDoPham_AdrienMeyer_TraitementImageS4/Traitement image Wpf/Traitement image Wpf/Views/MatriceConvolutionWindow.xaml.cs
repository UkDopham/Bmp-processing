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
	/// Logique d'interaction pour MatriceConvolutionWindow.xaml
	/// </summary>
	public partial class MatriceConvolutionWindow : Window
	{
		private MatriceConvolutionViewModel _matriceConvolutionVM;

		public MatriceConvolutionViewModel MatriceConvolutionVM
		{
			get { return this._matriceConvolutionVM; }
			set { this._matriceConvolutionVM = value; }
		}
		public MatriceConvolutionWindow()
		{
			InitializeComponent();
			this._matriceConvolutionVM = new MatriceConvolutionViewModel();
		}

		#region Boutons
		private void ButtonClick(object sender, RoutedEventArgs e)
		{
			this._matriceConvolutionVM.Mat = new int[5, 5];
			this._matriceConvolutionVM.Mat[0, 0] = Convert.ToInt32(this.textBox1.Text);
			this._matriceConvolutionVM.Mat[0, 1] = Convert.ToInt32(this.textBox2.Text);
			this._matriceConvolutionVM.Mat[0, 2] = Convert.ToInt32(this.textBox3.Text);
			this._matriceConvolutionVM.Mat[0, 3] = Convert.ToInt32(this.textBox4.Text);
			this._matriceConvolutionVM.Mat[0, 4] = Convert.ToInt32(this.textBox5.Text);

			this._matriceConvolutionVM.Mat[1, 0] = Convert.ToInt32(this.textBox6.Text);
			this._matriceConvolutionVM.Mat[1, 1] = Convert.ToInt32(this.textBox7.Text);
			this._matriceConvolutionVM.Mat[1, 2] = Convert.ToInt32(this.textBox8.Text);
			this._matriceConvolutionVM.Mat[1, 3] = Convert.ToInt32(this.textBox9.Text);
			this._matriceConvolutionVM.Mat[1, 4] = Convert.ToInt32(this.textBox10.Text);

			this._matriceConvolutionVM.Mat[2, 0] = Convert.ToInt32(this.textBox11.Text);
			this._matriceConvolutionVM.Mat[2, 1] = Convert.ToInt32(this.textBox12.Text);
			this._matriceConvolutionVM.Mat[2, 2] = Convert.ToInt32(this.textBox13.Text);
			this._matriceConvolutionVM.Mat[2, 3] = Convert.ToInt32(this.textBox14.Text);
			this._matriceConvolutionVM.Mat[2, 4] = Convert.ToInt32(this.textBox15.Text);

			this._matriceConvolutionVM.Mat[3, 0] = Convert.ToInt32(this.textBox16.Text);
			this._matriceConvolutionVM.Mat[3, 1] = Convert.ToInt32(this.textBox17.Text);
			this._matriceConvolutionVM.Mat[3, 2] = Convert.ToInt32(this.textBox18.Text);
			this._matriceConvolutionVM.Mat[3, 3] = Convert.ToInt32(this.textBox19.Text);
			this._matriceConvolutionVM.Mat[3, 4] = Convert.ToInt32(this.textBox20.Text);

			this._matriceConvolutionVM.Mat[4, 0] = Convert.ToInt32(this.textBox21.Text);
			this._matriceConvolutionVM.Mat[4, 1] = Convert.ToInt32(this.textBox22.Text);
			this._matriceConvolutionVM.Mat[4, 2] = Convert.ToInt32(this.textBox23.Text);
			this._matriceConvolutionVM.Mat[4, 3] = Convert.ToInt32(this.textBox24.Text);
			this._matriceConvolutionVM.Mat[4, 4] = Convert.ToInt32(this.textBox25.Text);

			this._matriceConvolutionVM.Fait = true;
			this._matriceConvolutionVM.Flou = (bool)this.flouCheckBox.IsChecked;
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

