using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traitement_image_Wpf.ViewModels
{
	public class RedimensionViewModel
	{
		private int _hauteur;
		private int _largeur;
		private bool _fait;

		public bool Fait
		{
			get { return this._fait; }
			set { this._fait = value; }
		}
		public int Hauteur
		{
			get { return this._hauteur; }
			set { this._hauteur = value; }
		}

		public int Largeur
		{
			get { return this._largeur; }
			set { this._largeur = value; }
		}
	}
}
