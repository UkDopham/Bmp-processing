using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_Pham_Alexandre_Meyer_Adrien_Probleme
{
	class Complexe
	{
		private double _reel;
		private double _imaginaire;

		public double Reel
		{
			get { return this._reel; }
		}
		public double Imaginaire
		{
			get { return this._imaginaire; }
		}

		public Complexe(double reel, double imaginaire)
		{
			this._reel = reel;
			this._imaginaire = imaginaire;
		}
		/// <summary>
		/// Cette methode calcul le carré d'un nombre complexe
		/// </summary>
		public void Carre()
		{
			double passage = this._reel * this._reel - this._imaginaire * this._imaginaire;
			this._imaginaire = 2 * this._reel * this._imaginaire;
			this._reel = passage;
		}
		/// <summary>
		/// Cette methode calcul le module d'un nombre complexe
		/// </summary>
		/// <returns></returns>
		public double Module()
		{
			double module = Math.Sqrt(this._reel * this._reel + this._imaginaire * this._imaginaire);
			return module;
		}
		/// <summary>
		/// Cette méthode fait l'addition de 2 nombres complexes
		/// </summary>
		/// <param name="valeur"></param>
		public void Addition(Complexe valeur)
		{
			this._reel += valeur.Reel;
			this._imaginaire += valeur.Imaginaire;
		}
	}
}
