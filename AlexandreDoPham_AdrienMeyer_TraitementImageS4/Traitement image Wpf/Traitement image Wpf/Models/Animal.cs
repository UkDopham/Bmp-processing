using Do_Pham_Alexandre_Meyer_Adrien_Probleme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traitement_image_Wpf.ViewModels;

namespace Traitement_image_Wpf.Models
{
	public class Animal : ObservableObject 
	{
		private string _nomAnimal;
		private LectureEcriture _tabByte;
		private ImageUIViewModel _imageUI;

		#region propriétés
		public ImageUIViewModel ImageUI
		{
			get { return this._imageUI; }
			set { this._imageUI = value; }
		}

		public LectureEcriture TabByte
		{
			get { return this._tabByte; }
			set { this._tabByte = value;}
		}
		
		public string NomAnimal
		{
			get { return this._nomAnimal; }
			set { this._nomAnimal = value;}
		}
		#endregion

		public Animal(string animal)
		{
			this._nomAnimal = animal;
			this._imageUI = new ImageUIViewModel();
		}

		/// <summary>
		/// Attribution du chemin de l'image dans le dossier de ressources en fonction du nom de l'animal
		/// </summary>
		public void AttributionPath()
		{
			string path = null;

			switch(this._nomAnimal)
			{
				case "camel":
					path = "Devinette/camel.bmp";
					break;

				case "cat":
					path = "Devinette/cat.bmp";
					break;

				case "chicken":
					path = "Devinette/chicken.bmp";
					break;

				case "dog":
					path = "Devinette/dog.bmp";
					break;

				case "duck":
					path = "Devinette/duck.bmp";
					break;

				case "giraffe":
					path = "Devinette/giraffe.bmp";
					break;

				case "lion":
					path = "Devinette/lion.bmp";
					break;

				case "mole":
					path = "Devinette/mole.bmp";
					break;

				case "snake":
					path = "Devinette/snake.bmp";
					break;

			}
			this._imageUI.Path = path;
		}
	}
}
