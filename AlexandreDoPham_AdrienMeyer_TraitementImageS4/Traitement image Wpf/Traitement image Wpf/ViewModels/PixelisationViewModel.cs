using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traitement_image_Wpf.ViewModels
{
	public class PixelisationViewModel
	{
		private int _taillePixelisation;
		private bool _fait;

		public bool Fait
		{
			get { return this._fait; }
			set { this._fait = value; }
		}

		public int TaillePixelisation
		{
			get { return this._taillePixelisation; }
			set { this._taillePixelisation = value; }
		}
	}
}
