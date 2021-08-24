using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traitement_image_Wpf.ViewModels
{
	public class DemandeUtilisateurViewModel : ObservableObject
	{
		private string _question;
		private string _titre;
		private string _reponse;
		private bool _fait = false;
		
		public bool Fait
		{
			get { return this._fait; }
			set { this._fait = value;}
		}

		public string Question
		{
			get { return this._question; } // jamais null 
			set { this._question = value;
				OnPropertyChanged("Question");
			}
		}

		public string Titre
		{
			get { return this._titre; }
			set { this._titre = value;
				OnPropertyChanged("Titre");
			}
		}

		public string Reponse
		{
			get { return this._reponse; }
			set { this._reponse = value; }
		}

		/// <summary>
		/// Methode de config des questions et titres
		/// </summary>
		/// <param name="nomBouton"></param>
		public void ConfigDefault(string nomBouton)
		{
			switch(nomBouton)
			{
				case "seuillageBouton":
					Question = "Quelle valeur de seuillage ?";
					Titre = "Seuillage";
					break;
			}
		}
	}
}
