using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traitement_image_Wpf.ViewModels;

namespace Traitement_image_Wpf.Models
{
	public class Joueur : ObservableObject
	{
		private string _nom;
		private int _point;
		private int _temps;


		#region Propriétées 
		public string Nom
		{
			get { return this._nom; }
		}

		public int Point
		{
			get { return this._point; }
			set { this._point = value;
				OnPropertyChanged("Point");
			}
		}

		public int Temps
		{
			get { return this._temps; }
		}
		#endregion

		public Joueur(string nom)
		{
			this._nom = nom;
			this._point = 0;
			this._temps = 0;
		}
		
		/// <summary>
		/// Augmente le temps de jeu d'un joueur
		/// </summary>
		/// <param name="temps"></param>
		public void GagnerTemps(int temps)
		{
			this._temps += temps;
		}

		/// <summary>
		/// Augmente le nombre de point d'une instance d'un joueur
		/// </summary>
		/// <param name="point"></param>
		public void GagnerPoint(int point)
		{
			this._point += point;
		}
	}
}
