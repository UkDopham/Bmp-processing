using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Traitement_image_Wpf.ViewModels
{
    public class Login : ObservableObject
	{
		private string _identifiant;
		private bool _rappelIdentifiant;

		public Login()
		{
			Lecture();
		}

		public string Identifiant
		{
			get
			{
				if (string.IsNullOrEmpty(this._identifiant))
				{
					return "invité";
				}
				return this._identifiant;
			}
			set
			{
				this._identifiant = value;
				OnPropertyChanged("Identifiant");
				Ecriture();
			}
		}

		public bool RappelIdentifiant
		{
			get { return this._rappelIdentifiant; }
			set { this._rappelIdentifiant = value;
				Ecriture();
			}
		}

		/// <summary>
		/// Ecriture de l'identifiant dans un .txt pour avoir une sauvegarde
		/// </summary>
		private void Ecriture()
		{
			string[] sauvegarde = new string[2];

			if (this._rappelIdentifiant)
			{
				sauvegarde[0] = this._identifiant;
				sauvegarde[1] = "oui";
			}
			File.WriteAllLines("sauvegarde.txt", sauvegarde);
		}

		/// <summary>
		/// Lecture des données issu du fichier "sauvegarde.txt"
		/// avec le dernier identifiant
		/// </summary>
		private void Lecture()
		{
			string[] sauvegarde = File.ReadAllLines("sauvegarde.txt");
			this._identifiant = sauvegarde[0];
			if (sauvegarde[1] =="oui")
			{
				this._rappelIdentifiant = true;
			}
			else
			{
				this._rappelIdentifiant = false;
			}
		}
    }
}
