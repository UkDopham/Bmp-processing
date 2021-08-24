using Do_Pham_Alexandre_Meyer_Adrien_Probleme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traitement_image_Wpf.ViewModels
{
	class PositionViewModel
	{
		private int _ligne;
		private int _colonne;
		private int _taille;
		private int _ligneActu;  //colonne dans la matrice de pixel
		private int _colonneActu; //colonne dans la matrice de pixel
		private int _ligneVrai; //la taille de ligne
		private int _colonneVrai; //la taille de colonne
		private ColorViewModels _colorVM;

		public ColorViewModels ColorVM
		{
			get { return this._colorVM; }
			set { this._colorVM = value; }
		}
		
		public int LigneActu
		{
			set { this._ligneActu = value; }
		}

		public int ColonneActu
		{
			set { this._colonneActu = value; }
		}

		public int LigneVrai
		{
			set { this._ligneVrai = value; }
		}

		public int ColonneVrai
		{
			set { this._colonneVrai = value; }
		}
		public PositionViewModel()
		{
			this._taille = 1;
			this._colorVM = new ColorViewModels();
		}
		public int Ligne
		{
			get { return this._ligne; }
			set { this._ligne = ProduitCroix(value, this._ligneVrai, this._ligneActu); }
		}

		public int Colonne
		{
			get { return this._colonne; }
			set { this._colonne = ProduitCroix(value, this._colonneVrai, this._colonneActu); }
		}

		public int Taille
		{
			get { return this._taille; }
			set { this._taille = value; }
		}		

		private int ProduitCroix(int valeurBaseA, int valeurMaxBaseA, int valeurMaxBaseB)
		{
			int valeurBaseB = 0;
			int passage = valeurBaseA * valeurMaxBaseB;
			valeurBaseB = Convert.ToInt32((double)passage / (double)valeurMaxBaseA);
			return valeurBaseB;
		}			
	}
}
