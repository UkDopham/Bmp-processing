using Do_Pham_Alexandre_Meyer_Adrien_Probleme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traitement_image_Wpf.Models;

namespace Traitement_image_Wpf.ViewModels
{
	public class JeuViewModel : ObservableObject
	{
		private Joueur _player;
		private Animal _imageDevine;
		private BoutonJeuViewModel _image1;
		private BoutonJeuViewModel _image2;
		private BoutonJeuViewModel _image3;
		private BoutonJeuViewModel _image4;
		private int _question;
		private int _maxQuestion;
		private Random _aleatoireImage;
		private int _nbAnimaux;
		private int _taillePixelisation;
		private int _valeurRotation;
		private int _repetitionEffet;
		private int _nbEffet;
		private int _point;
		private string _couleur;
		private string[] _tabNom;

		#region Propriété

		public string Couleur
		{
			get { return this._couleur; }
			set { this._couleur = value;
				OnPropertyChanged("Couleur");
			}
		}

		public int MaxQuestion
		{
			get { return this._maxQuestion; }
			set { this._maxQuestion = value; }
		}

		public Animal ImageDevine
		{
			get { return this._imageDevine; }
			set { this._imageDevine = value;
				OnPropertyChanged("ImageDevine");
			}
		}

		public BoutonJeuViewModel Image1
		{
			get { return this._image1; }
			set { this._image1 = value; }
		}

		public BoutonJeuViewModel Image2
		{
			get { return this._image2; }
			set { this._image2 = value; }
		}

		public BoutonJeuViewModel Image3
		{
			get { return this._image3; }
			set { this._image3 = value; }
		}

		public BoutonJeuViewModel Image4
		{
			get { return this._image4; }
			set { this._image4 = value; }
		}

		public int Question
		{
			get { return this._question; }
			set { this._question = value;
				OnPropertyChanged("Question");
			}
		}

		public Joueur Player
		{
			get { return this._player; }
			set { this._player = value; }
		}
		#endregion

		public JeuViewModel(string nom)
		{
			this._player = new Joueur(nom);
			Question = 1;
			this._maxQuestion = 10;
			this._aleatoireImage = new Random();
			this._nbAnimaux = 9;
			this._taillePixelisation = 10;
			this._valeurRotation = 90;
			this._repetitionEffet = 10;
			this._nbEffet = 9;
			this._point = 5;

			this._image1 = new BoutonJeuViewModel();
			this._image2 = new BoutonJeuViewModel();
			this._image3 = new BoutonJeuViewModel();
			this._image4 = new BoutonJeuViewModel();
			TourQuestion();
		}

		public bool RepoonseBouton(string nomBouton)
		{
			bool termine = false;
			if (this._question >= this._maxQuestion)
			{
				termine = true;
			}
			else
			{
				string reponse = null;
				switch (nomBouton)
				{
					case "Image1":
						reponse = this._image1.Nom;
						break;

					case "Image2":
						reponse = this._image2.Nom;
						break;

					case "Image3":
						reponse = this._image3.Nom;
						break;

					case "Image4":
						reponse = this._image4.Nom;
						break;
				}
				Question += 1;
				if (reponse == this.ImageDevine.NomAnimal)
				{
					this.Player.Point += this._point;
				}
				TourQuestion();
			}
			return termine;
		}

		/// <summary>
		/// Operations pour chaque nouvelle image
		/// </summary>
		private void TourQuestion()
		{
			OuvertureFichier();
			ApplicationEffet();
			this._tabNom = new string[4];
			
			int valeur = this._aleatoireImage.Next(1, this._nbAnimaux + 1);
			this._image1.Nom = ImageAleatoire(valeur);
			this._image1.AttributionPath();
			this._tabNom[0] = this._image1.Nom;

			BoucleNom(this._image2);
			this._image2.AttributionPath();
			this._tabNom[1] = this._image2.Nom;

			BoucleNom(this._image3);
			this._image3.AttributionPath();
			this._tabNom[2] = this._image3.Nom;

			BoucleNom(this._image4);
			this._image4.AttributionPath();
			this._tabNom[3] = this._image4.Nom;

			//mettre la réponse
			bool reponseDejaPresente = Existance(this.ImageDevine.NomAnimal);

			if (!reponseDejaPresente)
			{
				int imageReponse = this._aleatoireImage.Next(1, 5);

				switch (imageReponse)
				{
					case 1:
						this._image1.Nom = this._imageDevine.NomAnimal;
						this._image1.AttributionPath();
						break;

					case 2:
						this._image2.Nom = this._imageDevine.NomAnimal;
						this._image2.AttributionPath();
						break;

					case 3:
						this._image3.Nom = this._imageDevine.NomAnimal;
						this._image3.AttributionPath();
						break;

					case 4:
						this._image4.Nom = this._imageDevine.NomAnimal;
						this._image4.AttributionPath();
						break;
				}
			}
		}

		private void BoucleNom(BoutonJeuViewModel bouton)
		{
			bool presence = true;
			while (presence)
			{				
				int valeur = this._aleatoireImage.Next(1, this._nbAnimaux + 1);
				string nom = ImageAleatoire(valeur);
				presence = Existance(nom);
				bouton.Nom = ImageAleatoire(valeur);
			}
		}

		/// <summary>
		/// Regarde si le string mis en parametre existe deja dans le tableau
		/// </summary>
		/// <param name="nom"></param>
		/// <returns></returns>
		private bool Existance(string nom)
		{
			bool presence = false;
			for (int i = 0;
				i < this._tabNom.Length;
				i++)
			{
				if (nom == this._tabNom[i])
				{
					presence = true;
				}
			}
			return presence;
		}
		/// <summary>
		/// Initialisation des images
		/// </summary>
		/// <param name="animal"></param>
		private void OuvertureFichier()
		{
			this.ImageDevine = new Animal("null");
			int valeur = this._aleatoireImage.Next(1, this._nbAnimaux + 1);
			string nomAnimal = ImageAleatoire(valeur);
			this.ImageDevine = new Animal(nomAnimal);
			this.ImageDevine.AttributionPath();
		}

		private void ApplicationEffet()
		{
			int valeur = 0;
			for (int i = 0;
				i < this._repetitionEffet;
				i++)
			{
				valeur = this._aleatoireImage.Next(1, this._nbEffet+ 1);
				EffetAleatoire(valeur);
			}
		}

		/// <summary>
		/// Liste des images d'animaux présents dans le jeu	
		/// </summary>
		/// <param name="valeur"></param>
		/// <returns></returns>
		private string ImageAleatoire(int valeur)
		{
			string nomAnimal = null;
			switch(valeur)
			{
				case 1:
					nomAnimal = "camel";
					break;

				case 2:
					nomAnimal = "cat";
					break;

				case 3:
					nomAnimal = "chicken";
					break;

				case 4:
					nomAnimal = "dog";
					break;

				case 5:
					nomAnimal = "duck";
					break;

				case 6:
					nomAnimal = "giraffe";
					break;

				case 7:
					nomAnimal = "lion";
					break;

				case 8:
					nomAnimal = "mole";
					break;

				case 9:
					nomAnimal = "snake";
					break;

			}
			return nomAnimal;
		}

		/// <summary>
		/// Liste effetss
		/// </summary>
		/// <param name="valeur"></param>
		/// <param name="animal"></param>
		/// <param name="nomAnimal"></param>
		private void EffetAleatoire(int valeur)
		{
			this.ImageDevine.TabByte = new LectureEcriture(this.ImageDevine.ImageUI.Path);
			switch (valeur)
			{
				case 1: //Mirroir
					this.ImageDevine.TabByte.ImageClasse.Mirroir();
					break;

				case 2: //Negatif
					this.ImageDevine.TabByte.ImageClasse.Negatif();
					break;

				case 3: //Pixelisation
					this.ImageDevine.TabByte.ImageClasse.Pixelisation(this._taillePixelisation);
					break;

				case 4: //Renforcement des bords
					this.ImageDevine.TabByte.ImageClasse.RenforcementBords();
					break;

				case 5: //Repoussage
					this.ImageDevine.TabByte.ImageClasse.Repoussage();
					break;

				case 6: //Rouge
					this.ImageDevine.TabByte.ImageClasse.Rouge();
					break;

				case 7: //Rotation
					this.ImageDevine.TabByte.ImageClasse.Rotation(this._valeurRotation);
					break;

				case 8: //Flou
					this.ImageDevine.TabByte.ImageClasse.FlouNormal();
					break;

				case 9: //Gris
					this.ImageDevine.TabByte.ImageClasse.Gris();
					break;
					
			}
			this.ImageDevine.TabByte.Actualisation();
			this.ImageDevine.ImageUI.LoadImage(this.ImageDevine.TabByte.Fichier);
		}
	}
}
