using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traitement_image_Wpf.ViewModels
{
	public class MatriceConvolutionViewModel
	{
		private int[,] _mat;
		private bool _fait;
		private bool _flou;

		public bool Flou
		{
			get { return this._flou; }
			set { this._flou = value; }
		}

		public bool Fait
		{
			get { return this._fait; }
			set { this._fait = value; }
		}

		public int[,] Mat
		{
			get { return this._mat; }
			set { this._mat = value; }
		}
	}
}
