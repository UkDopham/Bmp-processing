using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traitement_image_Wpf.ViewModels
{
	public class BoutonJeuViewModel : ObservableObject
	{
		private string _nom;
		private string _path;

		#region Propriétées

		public string Nom
		{
			get { return this._nom; }
			set { this._nom = value; }
		}

		public string Path
		{
			get { return this._path; }
			set { this._path = value;
				OnPropertyChanged("Path");
			}
		}
		#endregion

		/// <summary>
		/// Attribution du chemin de l'image dans le dossier de ressources en fonction du nom de l'animal
		/// </summary>
		public void AttributionPath()
		{
			string path = null;

			switch (this._nom)
			{
				case "camel":
					path = "pack://siteoforigin:,,,/Resources/camel.png";
					break;

				case "cat":
					path = "pack://siteoforigin:,,,/Resources/cat.png";
					break;

				case "chicken":
					path = "pack://siteoforigin:,,,/Resources/chicken.png";
					break;

				case "dog":
					path = "pack://siteoforigin:,,,/Resources/dog.png";
					break;

				case "duck":
					path = "pack://siteoforigin:,,,/Resources/duck.png";
					break;

				case "giraffe":
					path = "pack://siteoforigin:,,,/Resources/giraffe.png";
					break;

				case "lion":
					path = "pack://siteoforigin:,,,/Resources/lion.png";
					break;

				case "mole":
					path = "pack://siteoforigin:,,,/Resources/mole.png";
					break;

				case "snake":
					path = "pack://siteoforigin:,,,/Resources/snake.png";
					break;

			}
			Path = path;
		}
	}
}
