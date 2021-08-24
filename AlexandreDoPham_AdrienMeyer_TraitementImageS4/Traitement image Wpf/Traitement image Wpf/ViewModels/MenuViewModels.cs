using Do_Pham_Alexandre_Meyer_Adrien_Probleme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Media.Imaging;

namespace Traitement_image_Wpf.ViewModels
{
    class MenuViewModels : ObservableObject
    {   private string _operation;
		private MessageViewModel _messageViewModel;
		private PixelisationViewModel _pixelisationVM;
		private RedimensionViewModel _redimensionVM;
		private MatriceConvolutionViewModel _matriceConvolutionVM;
		private string _pathDeuxImage;
		private PositionViewModel _pos;
		private LectureEcriture _lectureImage;
		private ImageUIViewModel _imageVM;
		private int _hauteur;
		private int _largeur;
		private bool _premier;
		private string _nomFichier;
		private bool _enregistrer;
		private bool _fait;
		private string _nom;
		private List<Image> _sauvegarde;
		private List<string> _historique;

		#region Propriété
		
		public List<string> Historique
		{
			get { return this._historique; }
			set { this._historique = value; }
		}

		public List<Image> Sauvegarde
		{
			get { return this._sauvegarde; }
			set { this._sauvegarde = value; }
		}

		public string Nom
		{
			get
			{
				if (String.IsNullOrEmpty(this._nom))
				{
					return "anonyme :)";
				}
				return this._nom;
			}

			set
			{
				this._nom = value;
				OnPropertyChanged("Nom");
			}
		}

		public string NomFichier
		{
			get { if (String.IsNullOrEmpty(this._nomFichier))
				{
					return "pas d'image pour l'instant :)";
				}
					return this._nomFichier; }

			set { this._nomFichier = value;
				OnPropertyChanged("NomFichier");
			}
		}

		public bool Premier
		{
			set { this._premier = value; }
		}

		public int Hauteur
		{
			get { return this._hauteur; }
			set { this._hauteur = value;
				OnPropertyChanged("Hauteur");
			}
		}

		public int Largeur
		{
			get { return this._largeur; }
			set { this._largeur = value;
				OnPropertyChanged("Largeur");
			}
		}

		public ImageUIViewModel ImageVM
		{
			get { return this._imageVM; }
			set { this._imageVM = value;}
		}

		public Image Image
		{
			get { return this._lectureImage.ImageClasse; }
		}

		public PositionViewModel Pos
		{
			get { return this._pos; }
			set { this._pos = value; }
		}

		public string PathDeuxImage
		{
			get { return this._pathDeuxImage; }
			set { this._pathDeuxImage = value; }
		}

		public MatriceConvolutionViewModel MatriceConvolutionVM
		{
			set { this._matriceConvolutionVM = value; }
		}
		
		public RedimensionViewModel RedimensionVM
		{
			set { this._redimensionVM = value; }
		}

		public PixelisationViewModel PixelisationVM
		{
			set { this._pixelisationVM = value; }
		}

		public MessageViewModel MessageViewModelGetSet
		{
			get { return this._messageViewModel; }
			set { this._messageViewModel = value; }
		}			
		
		public string Operation
		{
			get { return this._operation; }
			set { this._operation = value; }
		}

		#endregion
		public MenuViewModels()
		{
			this._imageVM = new ImageUIViewModel();
		}
		
		/// <summary>
		/// inialisation de l'image
		/// </summary>
		public void Initialisation()
		{
			this._lectureImage = new LectureEcriture(this._imageVM.Path);
			Hauteur = this._lectureImage.ImageClasse.Hauteur;
			Largeur = this._lectureImage.ImageClasse.Largeur;
			this._pos = new PositionViewModel();
			NomFichier = NotationNomFichier(this._imageVM.Path);
			this._sauvegarde = new List<Image>();
			this._historique = new List<string>();
			this._enregistrer = false;
			this._fait = false;
		}

		/// <summary>
		/// Retour en arriere 
		/// </summary>
		public void BackUp()
		{			
			string sortie = this._imageVM.Path;
			if (this._sauvegarde.Count > 0)
			{
				this._lectureImage.ImageClasse = this._sauvegarde[this._sauvegarde.Count - 1];
				this._sauvegarde.RemoveAt(this._sauvegarde.Count - 1);
				this._lectureImage.FromImageToFile(sortie);
				this._imageVM.Path = sortie;
			}
		}

		/// <summary>
		/// Cette méthode excute un traitement d'image en fonction 
		/// du bouton qui a cliqué 
		/// </summary>
		public void TraitementOperation()
		{
			bool coloriage = false;
			int valeurRot = 90;
			string[] tabMsg = null;
			string sortie = this._imageVM.Path;
			if (this._messageViewModel != null)
			{
				tabMsg = this._messageViewModel.MessageCode.Split('*');
			}
			Pixel[,] matPassage = this._lectureImage.ImageClasse.CopyTotal();
			Image ImPassage = new Image(matPassage);
			string phrase = null;
			if (this._operation != "Coloriage")
			{
				this._sauvegarde.Add(ImPassage);
			}
			switch (this._operation)
			{
				case "histogrammeBouton":
					phrase = "Histogramme";
					this._lectureImage.HistogrammeCouleur(true);
					//this._lectureImage.FromImageToFile(sortie);
					break;

				case "rotationBouton":
					phrase = "Rotation";
					this._lectureImage.ImageClasse.Rotation(valeurRot);
					//this._image.FromImageToFile(sortie);
					break;

				case "vertationBouton":
					phrase = "Vertation";
					this._lectureImage.ImageClasse.Vert();
					//this._lectureImage.FromImageToFile(sortie);
					break;

				case "messageBouton":
					phrase = "Message";
					Message msg = new Message(tabMsg, sortie, this._messageViewModel.Couleur , false,false, this._imageVM.Path, this._messageViewModel.Taille);
					break;

				case "mirroirBouton":
					phrase = "Mirroir";
					this._lectureImage.ImageClasse.Mirroir();
					//this._lectureImage.FromImageToFile(sortie);
					break;

				case "vieilleBouton":
					phrase = "Vieillissement";
					this._lectureImage.ImageClasse.Veillissement();
					this._lectureImage.ImageClasse.Gris();
					//this._lectureImage.FromImageToFile(sortie);
					break;

				case "grisBouton":
					phrase = "Noir & blanc";
					this._lectureImage.ImageClasse.Gris();
					//this._lectureImage.FromImageToFile(sortie);
					break;

				case "pixelBouton":
					phrase = "Pixel";
					this._lectureImage.ImageClasse.Pixelisation(this._pixelisationVM.TaillePixelisation);
					//this._lectureImage.FromImageToFile(sortie);
					break;

				case "redimensionBouton":
					phrase = "Redimension";
					this._lectureImage.ImageClasse.Redimension(this._redimensionVM.Hauteur, this._redimensionVM.Largeur);
					//this._lectureImage.FromImageToFile(sortie);
					break;

				case "fractaleBouton":
					phrase = "Fractale";
					this._lectureImage.ImageClasse.Redimension(this._redimensionVM.Hauteur, this._redimensionVM.Largeur);
					this._lectureImage.ImageClasse.Fractale();
					//this._lectureImage.FromImageToFile(sortie);
					break;

				case "seuillageBouton":
					phrase = "Seuillage";
					this._lectureImage.ImageClasse.Seuillage();
					//this._lectureImage.FromImageToFile(sortie);
					break;

				case "convolutionBouton":
					phrase = "Convolution";
					this._lectureImage.ImageClasse.Convolution(this._matriceConvolutionVM.Mat, this._matriceConvolutionVM.Flou);
					//this._lectureImage.FromImageToFile(sortie);
					break;

				case "imageCacheBouton":
					phrase = "Codage d'une image";
					LectureEcriture deuxImage = new LectureEcriture(this._pathDeuxImage);
					this._lectureImage.ImageClasse.Codage(deuxImage.ImageClasse);
					this._lectureImage.FromImageToFile(sortie);
					break;

				case "decodageBouton":
					phrase = "Decodage d'une image";
					this._lectureImage.ImageClasse = this._lectureImage.ImageClasse.Decodage();
					//this._lectureImage.FromImageToFile(sortie);
					break;

				case "coloriage":
					phrase = "Coloriage";
					this._lectureImage.ModifDirectTab(this._pos.Ligne, this._pos.Colonne, this._pos.ColorVM.Couleur, this._pos.Taille);
					coloriage = true;
					//this._lectureImage.ImageClasse.ColoriagePixelSolo(this._pos.Ligne, this._pos.Colonne, this._pos.ColorVM.Couleur, this._pos.Taille); //très lourd car on doit actualisation le tab à chaque fois 
					// faire modif sans passer par la classe image
					//this._lectureImage.FromImageToFile(sortie);
					break;
			}
			if (!coloriage)
			{
				this._lectureImage.Actualisation();
			}
			this._historique.Add(phrase);
			this._fait = true;
			this._premier = false;
			/*
			this._imageVM.Path = sortie;
			NomFichier = NotationNomFichier(this._imageVM.Path);
			*/
			this._imageVM.LoadImage(this._lectureImage.Fichier); //binding 
			Hauteur = this._lectureImage.ImageClasse.Hauteur;
			Largeur = this._lectureImage.ImageClasse.Largeur;
		}
		
		/// <summary>
		/// Sauvegarde brute de l'image
		/// </summary>
		/// <param name="path"></param>
		public void Enregistrer(string path)
		{
			this._lectureImage.FromImageToFile(path);
			this._imageVM.Path = path;
			NomFichier = NotationNomFichier(path);
			this._enregistrer = true;
		}

		/// <summary>
		/// Returne le nom du fichier
		/// </summary>
		/// <returns></returns>
		private string NotationNomFichier(string path)
		{
			string nom = null;
			string[] passage = path.Split('\\');
			nom = passage[passage.Length - 1];
			return nom;
		}
	}
}
