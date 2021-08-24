using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_Pham_Alexandre_Meyer_Adrien_Probleme
{
	class Image 
	{
		private int _largeur;
		private int _hauteur;
		private byte[] _valeur;
		private Pixel[,] _matPixel;
		private int _padding;

		public int Largeur
		{
			get { return this._largeur; }
		}
		public int Hauteur
		{
			get { return this._hauteur; }
		}
		public Pixel[,] MatPixel
		{
			get { return this._matPixel; }
			set { this._matPixel = value; }
		}

		public Image(int largeur, int hauteur, byte[] valeur,int padding)
		{
			this._largeur = largeur;
			this._hauteur = hauteur;
			this._valeur = valeur;
			this._padding = padding; // dans le cas ou les lignes ne sont pas un multiple de 4
			CreationMatrice();
		}
		public Image(Pixel[,] mat)
		{
			this._largeur = mat.GetLength(1);
			this._hauteur = mat.GetLength(0);
			this._matPixel = mat;
		}
		/// <summary>
		/// copy les valeurs de la matrice en parametre à partir des coordonnées en parametre(ligneDepart, colonneDepart)
		/// </summary>
		/// <param name="mat"></param>
		/// <param name="ligneDepart"></param>
		/// <param name="colonneDepart"></param>
		public void CopyDonne(Pixel[,] mat, int ligneDepart, int colonneDepart)
		{
			for (int ligne = ligneDepart;
				ligne < ligneDepart + mat.GetLength(0);
				ligne++)
			{
				for (int colonne  = colonneDepart;
					colonne < colonneDepart + mat.GetLength(1);
					colonne++)
				{
					this._matPixel[ligne, colonne] = mat[ligne - ligneDepart, colonne - colonneDepart];
				}
			}
		}
		/// <summary>
		/// Cette méthode permet de colorirer les pixels noirs en la couleur du pixel en parametre
		/// </summary>
		/// <param name="couleur"></param>
		public void ColorisationImageNoir(Pixel couleur)
		{
			for (int ligne = 0;
				ligne < this._matPixel.GetLength(0);
				ligne++)
			{
				for (int colonne = 0;
					colonne < this._matPixel.GetLength(1);
					colonne++)
				{
					int valeur = this._matPixel[ligne, colonne].ValeurMoyenne();
					if (valeur == 0 ) // couleur noir
					{
						this._matPixel[ligne, colonne] = couleur;
					}
				}
			}
		}		
		/// <summary>
		/// Methode qui permet de baisser la valeur RVB de chaque pixel de la valeur passé en parametre
		/// </summary>
		/// <param name="valeur"></param>
		public void Intensité(byte valeur)
		{
			for (int ligne = 0;
				ligne < this._matPixel.GetLength(0);
				ligne++)
			{
				for (int colonne = 0;
					colonne < this._matPixel.GetLength(1);
					colonne++)
				{
					if ((this._matPixel[ligne, colonne].Bleu - valeur) >= 0)
					{
						this._matPixel[ligne, colonne].Bleu += valeur;
					}
					if ((this._matPixel[ligne, colonne].Vert - valeur) >= 0)
					{
						this._matPixel[ligne, colonne].Vert += valeur;
					}
					if ((this._matPixel[ligne, colonne].Rouge - valeur) >= 0)
					{
						this._matPixel[ligne, colonne].Rouge += valeur;
					}
				}
			}
		} //pas utilisé yet
		/// <summary>
		/// Cette méthode permet de créer un histogramme des valeurs de gris
		/// </summary>
		/// <returns></returns>
		public int[] CalculHistogrammeGris()
		{
			int[] histogramme = new int[256];
			RecensementGris(histogramme);
			return histogramme;
		}
		/// <summary>
		/// Cette méthode permet de créer un histogramme des valeurs de 
		/// </summary>
		/// <returns></returns>
		public int[,] CalculHistogrammeCouleur()
		{
			int[,] histogramme = new int[3, 256];
			RecensementCouleur(histogramme);
			return histogramme;
		}
		/// <summary>
		/// Cette méthode compte le nombre de fois qu'une valeur de byte apparait dans l'image pour chaque couleur BVR
		/// Ordre des valeurs dans la matrice :
		/// mat[0,] Bleu
		/// mat[1,] Vert
		/// mat[2,] Rouge
		/// </summary>
		/// <param name="mat"></param>
		private void RecensementCouleur(int[,] mat) //changement en byte
		{
			for (int ligne = 0;
				ligne < this._matPixel.GetLength(0);
				ligne++)
			{
				for (int colonne = 0;
					colonne < this._matPixel.GetLength(1);
					colonne++)
				{
					int bleu = this._matPixel[ligne, colonne].Bleu;
					mat[0, bleu]++;
					int vert = this._matPixel[ligne, colonne].Vert;
					mat[1, vert]++;
					int rouge = this._matPixel[ligne, colonne].Rouge;
					mat[2, rouge]++;
				}
			}
		}
		/// <summary>
		/// Cette méthode compte le nombre de fois qu'une valeur de byte apparait dans l'image en gris
		/// </summary>
		/// <param name="mat"></param>
		private void RecensementGris(int[] mat) //changement en byte
		{
			for (int ligne = 0;
				ligne < this._matPixel.GetLength(0);
				ligne++)
			{
				for (int colonne = 0;
					colonne < this._matPixel.GetLength(1);
					colonne++)
				{
					int valeur = this._matPixel[ligne, colonne].ValeurMoyenne();
					mat[valeur]++;
				}
			}
		}
		/// <summary>
		/// Codage d'une image dans une autre image
		/// </summary>
		/// <param name="autreImage"></param>
		public void Codage(Image autreImage)
		{			
			for (int ligne = 0;
				ligne < this._matPixel.GetLength(0);
				ligne++)
			{
				for (int colonne = 0;
					colonne < this._matPixel.GetLength(1);
					colonne++)
				{
					bool possible = autreImage.Bordure(ligne, colonne);
					if (possible)
					{
						this._matPixel[ligne, colonne].Bleu = CodageByte(this._matPixel[ligne, colonne].Bleu, autreImage.MatPixel[ligne, colonne].Bleu);
						this._matPixel[ligne, colonne].Vert = CodageByte(this._matPixel[ligne, colonne].Vert, autreImage.MatPixel[ligne, colonne].Vert);
						this._matPixel[ligne, colonne].Rouge = CodageByte(this._matPixel[ligne, colonne].Rouge, autreImage.MatPixel[ligne, colonne].Rouge);
					}
				}
			}
		}
		/// <summary>
		/// Décodage d'une image caché dans une autre
		/// </summary>
		/// <returns></returns>
		public Image Decodage()
		{
			Pixel[,] mat = new Pixel[this._matPixel.GetLength(0), this._matPixel.GetLength(1)];
			for (int ligne = 0;
				ligne < this._matPixel.GetLength(0);
				ligne++)
			{
				for (int colonne = 0;
					colonne < this._matPixel.GetLength(1);
					colonne++)
				{
					mat[ligne, colonne] = DecodageByte(ligne, colonne);
				}
			}
			Image im = new Image(mat);
			return im;
		}
		/// <summary>
		/// décodage d'un pixel caché dans un autre pixel
		/// </summary>
		/// <param name="ligne"></param>
		/// <param name="colonne"></param>
		/// <returns></returns>
		private Pixel DecodageByte(int ligne, int colonne)
		{
			byte bitDebut = 240; // 1111 0000 en bits
			byte bitFin = 15; // 0000 1111 en bits
			byte rouge = (byte)(this._matPixel[ligne, colonne].Rouge & bitFin); //recuperation des bits de poid faible ( les valeurs cachées de l'image fort ses bits de poid fort donc)
			rouge =(byte)(rouge << 4); //décalage vers la gauche pour devenir des bits de poid fort
			byte bleu = (byte)(this._matPixel[ligne, colonne].Bleu & bitFin);
			bleu = (byte)(bleu << 4);
			byte vert = (byte)(this._matPixel[ligne, colonne].Vert & bitFin);
			vert = (byte)(vert << 4);
			this._matPixel[ligne, colonne].Rouge = (byte)(this._matPixel[ligne, colonne].Rouge & bitDebut); //on garde seulement les bits de poid fort pour l'image de façade
			this._matPixel[ligne, colonne].Bleu = (byte)(this._matPixel[ligne, colonne].Bleu & bitDebut);
			this._matPixel[ligne, colonne].Vert = (byte)(this._matPixel[ligne, colonne].Vert & bitDebut);
			Pixel pix = new Pixel(bleu, vert, rouge); // pixel de l'image cachée
			return pix;
		}
		/// <summary>
		/// Codage d'un pixel dans un autre pixel
		/// </summary>
		/// <param name="debut"></param>
		/// <param name="fin"></param>
		/// <returns></returns>
		private byte CodageByte(byte debut, byte fin)
		{
			byte bitDebut = 240; // 1111 0000 en bits
			byte sortie = (byte)(fin & bitDebut); //on garde seulement les bits de poid fort de l'image à caché
			sortie = (byte)(sortie >> 4); //transformation en bits de poid faible
			byte passage = (byte)(debut & bitDebut); //on garche les bits de poids forts de l'image de façade
			sortie = (byte)(sortie | passage);
			return sortie;
		}
		/// <summary>
		/// Redimension de l'image en image de taille en parametre
		/// </summary>
		/// <param name="hauteur"></param>
		/// <param name="largeur"></param>
		public void Redimension(int hauteur, int largeur)
		{
			Pixel[,] newMat = new Pixel[hauteur, largeur];
			double quotienLigne = (double)this._matPixel.GetLength(0) / (double)newMat.GetLength(0);
			double quotienColonne = (double)this._matPixel.GetLength(1) / (double)newMat.GetLength(1);
			for (int ligne = 0;
				ligne < newMat.GetLength(0);
				ligne++)
			{
				for (int colonne = 0;
					colonne < newMat.GetLength(1);
					colonne++)
				{
						newMat[ligne, colonne] = this._matPixel[(int)(quotienLigne * ligne), (int)(quotienColonne * colonne)];
				}
			}
			this._hauteur = hauteur;
			this._largeur = largeur;
			this._matPixel = newMat;
		}
		/// <summary>
		/// Methode verifiant si une matrice de pixel est pareil qu'une autre
		/// </summary>
		/// <param name="autreImage"></param>
		/// <returns></returns>
		public bool Pareil(Image autreImage)
		{
			bool same = true;
			for (int ligne = 0;
				ligne < this._matPixel.GetLength(0);
				ligne++)
			{
				for (int colonne = 0;
					colonne < this._matPixel.GetLength(1);
					colonne++)
				{
					if (this._matPixel[ligne,colonne].Pareil(autreImage.MatPixel[ligne,colonne]))
					{
						same = false;
					}
				}
			}
			return same;
		}
		/// <summary>
		/// création d'une matrice de pixel à partir du tableau de donnée de l'image bmp
		/// </summary>
		private void CreationMatrice()
		{
			int compteur = 54; 
			this._matPixel = new Pixel[this._hauteur, this._largeur];
			for (int ligne = this._matPixel.GetLength(0)-1;
				ligne > -1;
				ligne--)
			{
				for (int colonne = 0;
					colonne < this._matPixel.GetLength(1);
					colonne++)
				{
					this._matPixel[ligne, colonne] = new Pixel (this._valeur[compteur],this._valeur[compteur+1], this._valeur[compteur+2]);
					compteur+=3;
				}
				compteur += this._padding;
			}
		}
		/// <summary>
		/// création d'une fractale
		/// </summary>
		public void Fractale()
		{
			int limite = 100;
			for (int ligne = 0;
				ligne < this._matPixel.GetLength(0);
				ligne++)
			{
				for (int colonne = 0;
					colonne < this._matPixel.GetLength(1);
					colonne++)
				{
					double reel = (double)(ligne - (this._matPixel.GetLength(0) / 2)) /(double)(this._matPixel.GetLength(0) / 4);
					double imaginaire = (double)(colonne - (this._matPixel.GetLength(1) / 2)) /(double)(this._matPixel.GetLength(1) / 4);
					Complexe complexC = new Complexe(reel, imaginaire);
					Complexe ComplexZ = new Complexe(0, 0);
					bool continuer = false;
					int index = 0;
					while (!continuer)
					{
						ComplexZ.Carre();
						ComplexZ.Addition(complexC);
						index++;
						double module = ComplexZ.Module();
						if (index > limite ||
							module >= 2)
						{
							continuer = true;
						}
						this._matPixel[ligne, colonne] = new Pixel(index < limite ? (byte)255 : (byte)0);
					}
				}
			}
		}
		/// <summary>
		/// Méthode qui fait un nombre de rotation de l'image definie par la valeur
		/// saisie en parametre 
		/// </summary>
		/// <param name="valeur"></param>
		public void Rotation(int valeur)
		{
			int quotient = valeur / 90;
			for (int i = 0;
				i <  quotient;
				i++)
			{
				RotationUneFois();
			}
		}
		/// <summary>
		/// Rotation de 90 dégré de l'image
		/// </summary>
		private void RotationUneFois()
		{
			int passage = this._largeur;
			this._largeur = this._hauteur;
			this._hauteur = passage;
			Pixel[,] mat = new Pixel[this._hauteur, this._largeur];
			for (int ligne = 0;
				ligne < mat.GetLength(1);
				ligne++)
			{
				int i = 0;
				for ( int colonne = mat.GetLength(0)-1;
					colonne > -1;
					colonne--)
				{
					mat[colonne, ligne] = this._matPixel[ligne, i];
					i++;
				}
			}
			this._matPixel = mat;
		}
		/// <summary>
		/// Copy des valeurs de la matrice de pixel dans une nouvelle matrice
		/// et retourne cette derniere
		/// </summary>
		/// <returns></returns>
		private Pixel[,] Copy()
		{
			Pixel[,] mat = new Pixel[this._matPixel.GetLength(0), this._matPixel.GetLength(1)];
			for (int ligne = 0;
				ligne <mat.GetLength(0);
				ligne++)
			{
				for (int colonne = 0;
					colonne < mat.GetLength(1);
					colonne++)
				{
					mat[ligne, colonne] = this._matPixel[ligne, colonne];
				}
			}
			return mat;
		}
		/// <summary>
		/// Application d'une matrice de convolution sur une matrice de pixel
		/// </summary>
		/// <param name="matConvo"></param>
		/// <param name="flue"></param>
		private void Convolution(int[,] matConvo,bool flue = false)
		{
			Pixel[,] nouveauMat = Copy(); 
			for (int ligne = 0;
				 ligne < this._matPixel.GetLength(0);
				 ligne++)
			{
				for (int colonne = 0;
					colonne < this._matPixel.GetLength(1);
					colonne++)
				{
					nouveauMat[ligne,colonne] = CalculConvolution(matConvo, ligne, colonne,flue);
				}
			}
			this._matPixel = nouveauMat;
		}
		/// <summary>
		/// Application de la matrice de convolution sur le pixel saisie en parametre (ligneCentre, colonneCentre)
		/// </summary>
		/// <param name="matConvo"></param>
		/// <param name="ligneCentre"></param>
		/// <param name="colonneCentre"></param>
		/// <param name="flou"></param>
		/// <returns></returns>
		private Pixel CalculConvolution(int[,] matConvo, int ligneCentre, int colonneCentre, bool flou = false)
		{
			int somme = SommeMatConvolution(matConvo);
			int rouge = 0;
			int bleu = 0;
			int vert = 0;
			for (int ligne = 0;
				ligne < matConvo.GetLength(0);
				ligne++)
			{
				for (int colonne = 0;
					colonne < matConvo.GetLength(1);
					colonne++)
				{
					int ligneMatPixel = ligneCentre - 1 + ligne;
					int colonneMatPixel = colonneCentre - 1 + colonne;
					bool possible = Bordure(ligneMatPixel, colonneMatPixel);
					if (possible)
					{
						rouge += (this._matPixel[ligneMatPixel, colonneMatPixel].Rouge * matConvo[ligne, colonne]);
						bleu += (this._matPixel[ligneMatPixel, colonneMatPixel].Bleu * matConvo[ligne, colonne]);
						vert += (this._matPixel[ligneMatPixel, colonneMatPixel].Vert * matConvo[ligne, colonne]);
					}
					else
					{
						somme -= matConvo[ligne, colonne];
					}
				}
			}

			if (flou)
			{
				rouge /= somme;
				bleu /= somme;
				vert /= somme;
			}
			if (bleu < 0)
			{
				bleu = 0;
			}
			if (rouge < 0)
			{
				rouge = 0;
			}
			if (vert < 0)
			{
				vert = 0;
			}
			if (bleu > 255)
			{
				bleu = 255;
			}
			if (rouge > 255)
			{
				rouge = 255;
			}
			if (vert > 255)
			{
				vert = 255;
			}
			Pixel nouveauPixel = new Pixel((byte)bleu, (byte)vert, (byte)rouge);
			return nouveauPixel;
		}
		/// <summary>
		/// Seuillage d'une matrice de pixel
		/// </summary>
		public void Seuillage()
		{
			Gris();
			byte seuil = 150;
			for (int ligne = 0;
				ligne < this._matPixel.GetLength(0);
				ligne++)
			{
				for (int colonne = 0;
					colonne < this._matPixel.GetLength(1);
					colonne++)
				{
					byte valeur = this._matPixel[ligne, colonne].Rouge;
					if (valeur < seuil)
					{
						this._matPixel[ligne, colonne] = new Pixel(255);
					}
					else
					{
						this._matPixel[ligne, colonne] = new Pixel(0);
					}
				}
			}
		}
		/// <summary>
		/// Negatif d'une matrice de pixel
		/// </summary>
		public void Negatif()
		{
			for (int ligne = 0;
				ligne < this._matPixel.GetLength(0);
				ligne++)
			{
				for (int colonne = 0;
					colonne < this._matPixel.GetLength(1);
					colonne++)
				{
					this._matPixel[ligne, colonne].Rouge = (byte)(255 - this._matPixel[ligne, colonne].Rouge);
					this._matPixel[ligne, colonne].Vert = (byte)(255 - this._matPixel[ligne, colonne].Vert);
					this._matPixel[ligne, colonne].Bleu = (byte)(255 - this._matPixel[ligne, colonne].Bleu);
				}
			}
		}
		/// <summary>
		/// Cette méthode regarde si les positions mis en parametre ne sont pas en dehors de la matrice
		/// renvoie true si la position est en l'interieur sinon false
		/// </summary>
		/// <param name="ligne"></param>
		/// <param name="colonne"></param>
		/// <returns></returns>
		public bool Bordure(int ligne, int colonne)
		{
			bool possible = true;
			if((ligne < 0)
				||(colonne <0)
				||(ligne > this._matPixel.GetLength(0)-1)
				||(colonne > this._matPixel.GetLength(1)-1))
			{
				possible = false;
			}
			return possible;
		}
		/// <summary>
		/// fais la somme des valeurs d'une matrice de convolution
		/// fonction appliqué uniquement dans le cas d'un flou
		/// </summary>
		/// <param name="matConvo"></param>
		/// <returns></returns>
		private int SommeMatConvolution(int[,] matConvo)
		{
			int somme = 0;
			for (int ligne = 0;
				ligne < matConvo.GetLength(0);
				ligne++)
			{
				for (int colonne = 0;
					colonne < matConvo.GetLength(1);
					colonne++)
				{
					somme += matConvo[ligne, colonne];
				}
			}
			return somme;
		}
		/// <summary>
		/// Pixelisation d'une matrice de Pixel
		/// </summary>
		/// <param name="taille"></param>
		public void Pixelisation(int taille)
		{
			for (int ligne = 0;
				ligne < this._matPixel.GetLength(0);
				ligne+= taille)
			{
				for (int colonne = 0;
					colonne < this._matPixel.GetLength(1);
					colonne+= taille)
				{
					ZonageMoyenne(ligne, colonne, taille); //on fait la moyenne d'une zone de taille "taille" et on applique cette valeur à tous les pixels de cette zone
				}
			}
		}
		/// <summary>
		/// Moyenne des valeurs bytes d'une zone de taille "taille",
		/// la valeur moyenne est ensuite attribué à toutes les valeurs 
		/// présente dans la zone dont on a fait la moyenne
		/// </summary>
		/// <param name="ligneDepart"></param>
		/// <param name="colonneDepart"></param>
		/// <param name="taille"></param>
		private void ZonageMoyenne(int ligneDepart,int colonneDepart, int taille)
		{
			int sommeRouge = 0;
			int sommeBleu = 0;
			int sommeVert = 0;
			int moyenneRouge = 0;
			int moyenneBleu = 0;
			int moyenneVert = 0;
			int caseImpossible = 0;
			for (int ligne = ligneDepart;
				ligne < ligneDepart+taille;
				ligne++)
			{
				for (int colonne = colonneDepart;
					colonne < colonneDepart+taille;
					colonne++)
				{
					bool possible = Bordure(ligne, colonne);
					if (possible)
					{
						sommeRouge += this._matPixel[ligne, colonne].Rouge;
						sommeVert += this._matPixel[ligne, colonne].Vert;
						sommeBleu += this._matPixel[ligne, colonne].Bleu;
					}
					else
					{
						caseImpossible++;
					}
				}
			}
			moyenneRouge = sommeRouge / (taille * taille - caseImpossible);
			moyenneBleu = sommeBleu / (taille * taille - caseImpossible);
			moyenneVert = sommeVert / (taille * taille - caseImpossible);
			for (int ligne = ligneDepart;
				ligne < ligneDepart + taille;
				ligne++)
			{
				for (int colonne = colonneDepart;
					colonne < colonneDepart + taille;
					colonne++)
				{
					bool possible = Bordure(ligne, colonne);
					if (possible)
					{
						this._matPixel[ligne, colonne].Rouge = (byte)moyenneRouge;
						this._matPixel[ligne, colonne].Vert = (byte)moyenneVert;
						this._matPixel[ligne, colonne].Bleu = (byte)moyenneBleu;
					}
				}
			}
		}
		/// <summary>
		/// Veillissement d'une image = gris + quelque pixel blanc pour simuler l'usure
		/// </summary>
		public void Veillissement()
		{
			Random aleatoire = new Random();
			for (int ligne = 0;
				ligne < this._matPixel.GetLength(0);
				ligne++)
			{
				for (int colonne = 0;
					colonne < this._matPixel.GetLength(1);
					colonne++)
				{
					int valeur = aleatoire.Next(0, 10000);
					if (valeur < 5)
					{
						this._matPixel[ligne, colonne] = new Pixel(255, 255, 255);
					}
				}
			}
		}
		/// <summary>
		/// Matrice convolution
		/// </summary>
		public void FlouNormal()
		{
			int[,] matConvolution = new int[,]{ { 1, 1, 1}, { 1, 1, 1}, { 1, 1, 1} };
			Convolution(matConvolution,true);
		}
		/// <summary>
		/// Matrice convolution
		/// </summary>
		public void FlouGaussian()
		{
			int[,] matConvolution = new int[,] { { 1, 2, 1 }, { 2, 4, 2 }, { 1, 2, 1 } };
			Convolution(matConvolution, true);
		}
		/// <summary>
		/// Cette methode pareil la matrice pour chercher la matrice en parametre dans l'image
		/// </summary>
		/// <param name="imageATrouver"></param>
		/// <returns></returns>
		public bool Presence(Image imageATrouver)
		{
			bool passage = false;
			bool presence = false;
			for (int ligne = 0;
				ligne < this.MatPixel.GetLength(0);
				ligne ++)
			{
				for (int colonne = 0;
					colonne < this.MatPixel.GetLength(1);
					colonne++)
				{
					bool pareil = this._matPixel[ligne, colonne].Pareil(imageATrouver.MatPixel[0, 0]);
					if (pareil)
					{
						passage = PresenceCible(imageATrouver, ligne, colonne);
						if (passage)
						{
							presence = true;
						}
					}
				}
			}
			return presence;
		}
		/// <summary>
		/// cette methode parcourt la matrice "aTrouver" et regarder si la matrice de meme taille partant de la 
		/// position [ligneDepart,colonneDepart] est la meme
		/// </summary>
		/// <param name="aTrouver"></param>
		/// <param name="ligneDepart"></param>
		/// <param name="colonneDepart"></param>
		/// <returns></returns>
		private bool PresenceCible(Image aTrouver,int ligneDepart, int colonneDepart)
		{
			bool presence = true;
			for (int ligne = 0;
				ligne < aTrouver.MatPixel.GetLength(0);
				ligne++)
			{
				for (int colonne = 0;
					colonne < aTrouver.MatPixel.GetLength(1);
					colonne++)
				{
					int ligneActu = ligneDepart + ligne;
					int colonneActu = colonneDepart + colonne;
					bool possible = Bordure(ligneActu, colonneActu);
					if (possible)
					{
						bool pareil = this.MatPixel[ligneActu, colonneActu].Pareil(aTrouver.MatPixel[ligne, colonne]);
						if(!pareil)
						{
							presence = false;
						}
					}
					else
					{
						presence = false;
					}
				}
			}
			return presence;
		}
		/// <summary>
		/// Matrice convolution
		/// </summary>
		public void DetectionBords()
		{
			int[,] matConvolution = new int[,] { { 0, 1, 0 }, { 1, -4, 1 }, { 0, 1, 0 } };
			Convolution(matConvolution);
		}
		/// <summary>
		/// Matrice convolution
		/// </summary>
		public void RenforcementBords()
		{
			int[,] matConvolution = new int[,] { { 0, 0, 0 }, { -1, 1, 0 }, { 0, 0, 0 } };
			Convolution(matConvolution);
		}
		/// <summary>
		/// Matrice convolution
		/// </summary>
		public void Repoussage()
		{
			int[,] matConvolution = new int[,] { { -2, -1, 0 }, { -1, 1, 1 }, { 0, 1, 2 } };
			Convolution(matConvolution);
		}
		/// <summary>
		/// effet mirroir d'une matrice de pixel
		/// </summary>
		public void Mirroir()
		{
			for (int ligne = 0;
				ligne < this._matPixel.GetLength(0);
				ligne++)
			{
				for (int colonne = 0;
					colonne < (this._matPixel.GetLength(1)/2);
					colonne++)
				{
					Pixel passage = this._matPixel[ligne, colonne];
					this._matPixel[ligne, colonne] = this._matPixel[ligne, this._matPixel.GetLength(1) - 1 - colonne];
					this._matPixel[ligne, this._matPixel.GetLength(1) - 1 - colonne] = passage;
				}
			}
		}
		/// <summary>
		/// Remplis la matrice de la couleur saisie en parametre
		/// </summary>
		/// <param name="couleur"></param>
		public void Remplissage(Pixel couleur)
		{
			for (int ligne = 0;
				ligne < this._matPixel.GetLength(0);
				ligne++)
			{
				for (int colonne = 0;
					colonne < this._matPixel.GetLength(1);
					colonne++)
				{
					this._matPixel[ligne, colonne] = new Pixel(couleur);
				}
			}
		}
		/// <summary>
		/// Colorisation en vert d'une image
		/// </summary>
		public void Vert()
		{
			for (int ligne = 0;
							ligne < this.MatPixel.GetLength(0);
							ligne++)
			{
				for (int colonne = 0;
					colonne < this.MatPixel.GetLength(1);
					colonne++)
				{
					this.MatPixel[ligne, colonne].Vertation();
				}
			}
		}
		/// <summary>
		/// Colorisation en gris d'une image
		/// </summary>
		public void Gris()
		{
			for (int ligne = 0;
				ligne < this.MatPixel.GetLength(0);
				ligne++)
			{
				for (int colonne = 0;
					colonne < this.MatPixel.GetLength(1);
					colonne++)
				{
					this.MatPixel[ligne, colonne].Moyenne();
				}
			}
		}
		/// <summary>
		/// Affichage de la matrice de pixel
		/// </summary>
		public void AffichageMat()
		{
			int compteur = 0;
			for (int ligne = 0;
				ligne < this._matPixel.GetLength(0);
				ligne++)
			{
				for (int colonne = 0;
					colonne < this._matPixel.GetLength(1);
					colonne++)
				{
					int modulo = compteur % 2;
					if(modulo == 0)
					{
						Console.ForegroundColor = ConsoleColor.Blue;
					}
					else
					{
						Console.ResetColor();
					}
					Console.Write(this._matPixel[ligne,colonne].Description());
					compteur++;
				}
				Console.WriteLine();
			}
			Console.ResetColor();
		}
	}
}
