using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Do_Pham_Alexandre_Meyer_Adrien_Probleme
{
	class LectureEcriture
	{
		private int _typeFichier;
		private int _taille;
		private int _offset; //index de debut de la matrice dans le fichier
		private int _hauteur;
		private int _largeur;
		private int _nbCouleur;
		private Image _image;
		private int _padding;
		private byte[] _fichier;

		public Image ImageClasse
		{
			get { return this._image; }
			set { this._image = value; }
		}

		public LectureEcriture(string file,bool affichageConsole = false)
		{
			Lecture(file);
			if (affichageConsole)
			{
				Affichage();
			}
			CalculPadding();
			this._image = new Image(this._largeur, this._hauteur, this._fichier, this._padding);
			if (affichageConsole)
			{
				this._image.AffichageMat();
			}
		}
		/// <summary>
		/// Tout d'abord on actualise la matrice de l'instance de la classe image
		/// dans le cas ou l'on a modifié cette derniere puis on écrit le fichier en brut
		/// </summary>
		/// <param name="nomFichier"></param>
		public void FromImageToFile(string nomFichier)
		{
			Actualisation();
			File.WriteAllBytes(nomFichier,this._fichier);
		}
		/// <summary>
		/// Acualisation des nouvelles dimensions en fonction de la matrice de Pixel de l'image
		/// </summary>
		private void CalculDimension()
		{
			this._largeur = this._image.Largeur;
			this._hauteur = this._image.Hauteur;
			byte[] hauteur = ConvertirIntToLittleEndian(this._hauteur);
			byte[] largeur = ConvertirIntToLittleEndian(this._largeur);
			for (int i = 0;
				i < 4;
				i++)
			{
				this._fichier[i + 18] = largeur[i];
				this._fichier[i + 22] = hauteur[i];
			}
		}
		/// <summary>
		/// Création d'un histogramme de nuance de gris
		/// </summary>
		public void HistogrammeGris()
		{
			int[] histogramme = this._image.CalculHistogrammeGris();
			// Recherche de la valeur Max du tableau de valeur pour pouvoir creer la matrice
			int max = ValeurMaxTab(histogramme);
			// Valeur pour avoir des intervalles de valeur pour éviter une image trop grande en hauteur
			int ligne = (int)(Math.Sqrt(max))+1;
			/// 256 valeurs differents 
			Pixel[,] mat = new Pixel[ligne, 256];
			// Remplissage en blanc pour ne pas avoir de valeur null
			RemplissageBlanc(mat);
			// Couleur noir
			Pixel pix = new Pixel(0);
			// Remplissage de la matrice 
			RemplissageHistogrammeMonoCouleur(mat,histogramme,max,pix);
			Image histo = new Image(mat);
			this._image = histo;
			// Rotation car l'image est à l'envers
			this._image.Rotation(180);
		}
		/// <summary>
		/// Retourne la valeur max d'une matrice
		/// </summary>
		/// <param name="mat"></param>
		/// <returns></returns>
		private int ValeurMaxMatr(int[,] mat)
		{
			int max = 0;
			for (int ligne = 0;
				ligne < mat.GetLength(0);
				ligne++)
			{
				for (int colonne = 0;
					colonne < mat.GetLength(1);
					colonne++)
				{
					if (mat[ligne,colonne] > max)
					{
						max = mat[ligne, colonne];
					}
				}
			}
			return max;
		}
		/// <summary>
		/// Création d'un histogramme des 3 couleurs
		/// </summary>
		/// <param name="separe">True si on veut qu'il est trois histogramme séparés; false si on les veut superposés</param>
		public void HistogrammeCouleur(bool separe)
		{
			// Remplissage des valeurs
			int[,] histogramme = this._image.CalculHistogrammeCouleur();
			// Recherche de la valeur max pour avoir la taile de l'image
			int max = ValeurMaxMatr(histogramme);
			// Valeur pour la séparation en intervalle
			int ligne = (int)(Math.Sqrt(max)) + 1;
			Pixel[,] mat;
			if (separe)
			{
				// Comme l'on aura 3 images en une la hauteur est multiplié par 3
				mat = new Pixel[ligne * 3, 256];
			}
			else
			{
				 mat = new Pixel[ligne, 256];
			}
			// pour évité les pixels null
			RemplissageBlanc(mat);
			for (int i = 0;
				i < 3;
				i++)
			{
				if (separe)
				{
					// pour avoir la bonne ligne en fonction de la couleur
					int ligneActuelle = i * ligne;
					RemplissageHistogrammeCouleur(mat, histogramme, max, i, ligneActuelle);
				}
				else
				{
					RemplissageHistogrammeCouleur(mat, histogramme, max, i);
				}
			}
			Image histo = new Image(mat);
			this._image = histo;
			// rotation car l'image est à l'envers
			this._image.Rotation(180);
		}
		/// <summary>
		/// Remplisage de l'histogramme couleur
		/// </summary>
		/// <param name="mat">Matrice de couleur BVR</param>
		/// <param name="histo">Matrice qui le nombre de valeur pour chaque valeur differente de couleur
		/// Ligne 0 : Bleu
		/// Ligne 1 : Vert
		/// Ligne 2 : Rouge</param>
		/// <param name="max">Valeur max de l'histogramme (nombre de fois qu'il y a une couleur )</param>
		/// <param name="index">La ligne de couleur (Bleu / Vert / Rouge)</param>
		/// <param name="debut">ligne de debut du remplissage (pour quand l'histogramme est séparé)</param>
		private void RemplissageHistogrammeCouleur(Pixel[,] mat, int[,] histo, int max, int index, int debut = 0)
		{
			// Pour avoir des couleurs plus jolie
			byte intensiteMajeur = 255;
			byte intensiteMineur = 128;
			Pixel pix = new Pixel(0, 0, 0);
			// Création d'un tableau de passage pour stocker les valeurs d'une ligne de la matrice histogramme
			int[] tab = CopyMatToTab(histo, index);
			switch(index)
			{
				case 0:
					/// Bleu
					pix = new Pixel(intensiteMajeur, intensiteMineur, intensiteMineur);
					break;

				case 1:
					// Vert
					pix = new Pixel(intensiteMineur, intensiteMajeur, intensiteMineur);
					break;

				case 2:
					// Rouge
					pix = new Pixel(intensiteMineur, intensiteMineur, intensiteMajeur);
					break;
			}
			RemplissageHistogrammeMonoCouleur(mat, tab, max, pix,debut);
		}
		/// <summary>
		/// Copy les valeurs d'une ligne d'une matrice dans un tableau et retourne 
		/// ce dernier
		/// </summary>
		/// <param name="mat"></param>
		/// <param name="index"></param>
		/// <returns></returns>
		private int[] CopyMatToTab(int[,] mat, int index)
		{
			int[] tab = new int[mat.GetLength(1)];
			for (int i = 0;
				i < tab.Length;
				i++)
			{
				tab[i] = mat[index, i];
			}
			return tab;
		}
		/// <summary>
		/// Remplissage la matrice de pixel 
		/// </summary>
		/// <param name="mat">Matrice de pixel</param>
		/// <param name="histo">tableau avec le nombre de fois d'apparition de chaque valeur de couleur</param>
		/// <param name="max">nombre de fois max d'appartion d'une valeur de couleur dans l'image</param>
		/// <param name="pix">Couleur que l'on veut attribuer dans l'image </param>
		/// <param name="debut"> ligne de debut d'écriture dans l'image</param>
		private void RemplissageHistogrammeMonoCouleur(Pixel[,] mat, int[] histo, int max, Pixel pix, int debut = 0)
		{
			for (int i = 0;
				i < histo.Length;
				i++)
			{
				int ligne = ProduitCroix(max,histo[i]);
				// remplissage des colonnes
				for (int j = debut;
					j < ligne+debut;
					j++)
				{
					mat[j, i] = pix;
				}
			}
		}
		/// <summary>
		/// Met tous les pixels en blanc 
		/// </summary>
		/// <param name="mat"></param>
		private void RemplissageBlanc(Pixel[,] mat)
		{
			for (int ligne = 0;
				ligne < mat.GetLength(0);
				ligne++)
			{
				for (int colonne = 0;
					colonne < mat.GetLength(1);
					colonne++)
				{
					mat[ligne, colonne] = new Pixel(255); //tout en blanc
				}
			}
		}
		/// <summary>
		/// Produit en croix pour les intervalles de valeurs
		/// </summary>
		/// <param name="max"></param>
		/// <param name="valeur"></param>
		/// <returns></returns>
		private int ProduitCroix(int max, int valeur)
		{
			int valeurModif = (int)(valeur*(int)(Math.Sqrt(max)));
			valeurModif /= max;
			return valeurModif;
		}
		/// <summary>
		///  Retourne la valeur max d'un tableau
		/// </summary>
		/// <param name="tab"></param>
		/// <returns></returns>
		private int ValeurMaxTab(int[] tab)
		{
			int max = 0;
			for (int i = 0;
				i < tab.Length;
				i++)
			{
				if (max < tab[i])
				{
					max = tab[i];
				}
			}
			return max;
		}
		/// <summary>
		/// On identifie l'entension du fichier pour pouvoir exécuter le bon code
		/// </summary>
		/// <param name="nomFichier"></param>
		private void Lecture(string nomFichier)
		{
			string[] decoupe = nomFichier.Split('.');
			string entension = decoupe[1];
			switch(entension)
			{
				case "csv":
					Lecturecsv(nomFichier);
					break;

				case "bmp":
					Lecturebmp(nomFichier);
					break;

				default:
					Console.WriteLine("Entension de fichier non supportée ");
					break;
			}
			this._typeFichier = ConvertirLittleEndianToInt(0, 2);
			this._taille = ConvertirLittleEndianToInt(2, 4);
			this._offset = ConvertirLittleEndianToInt(10, 4);
			this._largeur = ConvertirLittleEndianToInt(18, 4);
			this._hauteur = ConvertirLittleEndianToInt(22, 4);
			this._nbCouleur = ConvertirLittleEndianToInt(28, 2);
		}
		/// <summary>
		/// Lecture d'un fichier csv, on lit d'abord les 2 premières lignes pour avoir les informations sur la
		/// hauteur et la largeur de l'image pour pouvoir créer le tableau de bytes
		/// </summary>
		/// <param name="nomFichier"></param>
		private void Lecturecsv(string nomFichier)
		{
			try
			{
				string[] passage = File.ReadAllLines(nomFichier);
				string[] headerInfo = passage[1].Split(';');
				byte[] tabPassage = RemplissageBoucleByte(4, headerInfo);
				int largeur = LittleEndian(tabPassage);
				this._largeur = largeur;
				CalculPadding();
				tabPassage = RemplissageBoucleByte(8, headerInfo);
				int hauteur = LittleEndian(tabPassage);
				int taille = (hauteur * largeur * 3) + 54; //54 = offset
				taille += this._padding * hauteur;
				this._fichier = new byte[taille];
				RemplissageFichier(passage);
			}
			catch (FileNotFoundException erreur)
			{
				Console.WriteLine("Le fichier n'existe pas " + erreur.Message);
			}
		}
		/// <summary>
		/// cette méthode permet d'écrire les données du tableau issu d'un fichier csv
		/// dans le tableau de bytes du champ
		/// </summary>
		/// <param name="passage"></param>
		private void RemplissageFichier(string[] passage)
		{
			int compteur = 0;
			for (int ligne = 0;
				ligne < passage.Length;
				ligne++)
			{
				string[] valeur = passage[ligne].Split(';');
				for (int i = 0;
					i < valeur.Length;
					i++)
				{
					if (!String.IsNullOrEmpty(valeur[i]))
					{
						this._fichier[compteur] = Convert.ToByte(valeur[i]);
						compteur++;
					}
				}
			}
		}
		/// <summary>
		/// méthode utilisé dans la lecture d'un fichier csv
		/// elle permet de créer un tableau de byte pour pouvoir ensuite lire les données
		/// </summary>
		/// <param name="depart"></param>
		/// <param name="tab"></param>
		/// <returns></returns>
		private byte[] RemplissageBoucleByte(int depart, string[] tab)
		{
			byte[] tabPassage = new byte[4];
			for (int i = 0;
				i <4;
				i++)
			{
				tabPassage[i] = Convert.ToByte(tab[i + depart]);
			}
			return tabPassage;
		}
		/// <summary>
		/// Lecture d'un fichier d'extension BMP
		/// </summary>
		/// <param name="nomFichier"></param>
		private void Lecturebmp(string nomFichier) 
		{
			try
			{
				this._fichier = File.ReadAllBytes(nomFichier); // de 0 à 255 
			}
			catch (FileNotFoundException erreur)
			{
				Console.WriteLine("Le fichier n'existe pas " + erreur.Message);
			}
		}
		// Octets - little endian (Dans le sens inverse de lecture cad 123456 donne 56 34 12 en little endian)
		// Valeurs test de l'image "ImageTest.bmp"
		// [2] Type de fichier (66 77) = 77 66 
		// [4] Taille du BMP (134 0 0 0) = 134 
		// [2] Réservé (0 0)
		// [2] Réservé (0 0)
		// [4] l'offset  (54 0 0 0) = 54 

		// [4] Taille du Header (40 0 0 0) = 40
		// [4] Largeur en pixel (5 0 0 0) = 5
		// [4] Hauteur en pixel (5 0 0 0) = 5
		// [2] Nombre de plan de couleur (1 0) = 1
		// [2] Nombre d'octets par couleur (24 0) = 24
		// [4] Methode de Compression  (0 0 0 0)
		// [4] Taille "raw" de l'image bitmap (80 0 0 0) = 80
		// [4] Taille horizontal (0 0 0 0)
		// [4] Taille vertical (0 0 0 0)
		// [4] Nombre de couleur (0 0 0 0)
		// [4] Nombre de couleur utilisé (0 0 0 0)
		private void Affichage()
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("Header");
			Console.ResetColor();
			for (int i = 0;
				i < 54;
				i++)
			{
				if (i == 14)
				{
					Console.WriteLine();
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("Header information");
					Console.ResetColor();
				}
				Console.Write(this._fichier[i]);
				Console.Write(" ");
			}
			Console.WriteLine();
		}
		/// <summary>
		/// Va dans le tab de byte de l'image (Header) 
		/// selection les bytes qui nous interressent, les met dans un tableau 
		/// puis les passage de litle Endian à Int
		/// Retourne ce dernier
		/// </summary>
		/// <param name="index">l'index de debut des valeurs dans la tableau de byte contenant les valeurs</param>
		/// <param name="taille">nombre de valeur</param>
		/// <returns></returns>
		private int ConvertirLittleEndianToInt(int index, int taille)
		{
			byte[] tabPassage = new byte[4]; //si la taille est plus petite que 4, ça met des 0 dans les places manquantes
			int compteur = 0;
			for (int i = index;
				i < index + taille;
				i++)
			{
				tabPassage[compteur] = this._fichier[i];
				compteur++;
			}
			int valeur = LittleEndian(tabPassage);
			byte[] tab = ConvertirIntToLittleEndian(valeur); // à virer
			return valeur;
		}
		/// <summary>
		/// Passage en binaire tout d'abord, on décale vers la gauche pour inverser les valeurs, 
		/// ensuite on fait une "somme" avec | des valeurs en binaires
		/// </summary>
		/// <param name="tab"> tableau bytes</param>
		/// <returns>l'entier traduit de little Endian</returns>
		static int LittleEndian(byte[] tab)
		{
			//Passage en binaire tout d'abord ensuite on fait une "somme" avec | des valeurs en binaires
			// | permet de renvoyer 1 si il y a un 1 sinon 0

			int valeurLittleEndian = (tab[3] << 24) // on décale de 24 bits vers la gauche le dernier byte pour qu'il devient le premier dans la somme
				 | (tab[2] << 16) // on décale de 16 bits vers la gauche le dernier byte pour qu'il devient le deuxième dans la somme
				 | (tab[1] << 8) // on décale de 8 bits vers la gauche le dernier byte pour qu'il devient le troisième dans la somme
				 | tab[0];
			return valeurLittleEndian;
		}
		private byte[] ConvertirIntToLittleEndian(int valeur)
		{
			byte[] tab = BitConverter.GetBytes(valeur);
			return tab;
		}
		/// <summary>
		/// Cette méthode permet de calculer le padding d'une image en fonctino de sa largeur
		/// </summary>
		private void CalculPadding()
		{
			int modulo = (this._largeur*3)%4;
			switch(modulo)
			{
				case 1:
					this._padding = 3;
					break;

				case 2: 
					this._padding = 2;
					break;

				case 3:
					this._padding = 1;
					break;

				default:
					this._padding = 0;
					break;
			}
		}
		/// <summary>
		/// cette méthode ecrit les valeurs de la matrice de l'instance image dans le tableau de bytes
		/// </summary>
		private void Actualisation()
		{
			CalculDimension();
			CalculPadding();
			Creationtableau();
			int compteur = this._offset;
			for (int ligne = this._image.MatPixel.GetLength(0) - 1;
				ligne > -1;
				ligne--)
			{ 
				for (int colonne = 0;
					colonne < this._image.MatPixel.GetLength(1);
					colonne++)
				{
					this._fichier[compteur]= this._image.MatPixel[ligne, colonne].Bleu;
					this._fichier[compteur+1] = this._image.MatPixel[ligne, colonne].Vert;
					this._fichier[compteur+2] = this._image.MatPixel[ligne, colonne].Rouge;
					compteur +=3;
				}
				compteur += this._padding;
			}
		}
		/// <summary>
		/// Création d'un nouveau tab byte de valeur en fonction des nouvelles dimensions,
		/// copy de l'ancien Header dans ce dernier
		/// </summary>
		private void Creationtableau()
		{
			int nombreCase = this._offset + (this._largeur * this._hauteur)*3;
			nombreCase += this._padding * this._hauteur;
			byte[] tabPassage = new byte[nombreCase];
			for (int i = 0;
				i < this._offset;
				i++)
			{
				tabPassage[i] = this._fichier[i];
			}
			this._fichier = tabPassage;
		}
	}
}
