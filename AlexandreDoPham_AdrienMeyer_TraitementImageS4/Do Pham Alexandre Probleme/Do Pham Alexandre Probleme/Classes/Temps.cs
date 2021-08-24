using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_Pham_Alexandre_Meyer_Adrien_Probleme
{
	class Temps
	{
		private int _tempsPasse;
		private DateTime debut;
		private DateTime fin;

		public Temps()
		{
			this._tempsPasse = 0;
			Start();
		}

		public int TempsPasse
		{
			get { return this._tempsPasse; }
			set { this._tempsPasse = value; }
		}
		/// <summary>
		/// Lancement du chronomètre
		/// </summary>
		private void Start()
		{
			this.debut = DateTime.Now;
		}
		/// <summary>
		/// On calcul le temps passé en le debut et maintenant, pas de reset, on lance ensuite la fonction TempsPasse() pour avoir le temps écoulé
		/// </summary>
		public void Calcul()
		{
			this.fin = DateTime.Now;
			TempsPasseCalcul();
		}
		/// <summary>
		/// Calcul le temsp en seconde depuis le début
		/// </summary>
		private void TempsPasseCalcul()
		{
			TimeSpan tempsPasse = this.fin - this.debut;
			this._tempsPasse = (int)tempsPasse.TotalSeconds;
		}
	}
}
