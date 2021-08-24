using Do_Pham_Alexandre_Meyer_Adrien_Probleme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traitement_image_Wpf.ViewModels
{
	public class MessageViewModel : ObservableObject
	{
		private string _message;
		private bool _termine;
		private Pixel _couleur;
		private int _taille;
		private bool _fait;

		public bool Fait
		{
			get { return this._fait; }
			set { this._fait = value; }
		}


		public int Taille
		{
			get { return this._taille; }
			set { this._taille = value; }
		}

		public bool Termine
		{
			get { return this._termine; }
			set { this._termine = value; }
		}

		public Pixel Couleur
		{
			get { return this._couleur; }
			set { this._couleur = value; }
		}
		
		public string MessageCode
		{
			get { if (string.IsNullOrEmpty(this._message))
				{
					return "";
				}
				return this._message;
			}
			set {
				this._message = value;
				OnPropertyChanged("MessageCode");
			}
		}
	}
}
