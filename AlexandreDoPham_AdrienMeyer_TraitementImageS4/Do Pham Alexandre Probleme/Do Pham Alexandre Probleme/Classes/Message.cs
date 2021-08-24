using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_Pham_Alexandre_Meyer_Adrien_Probleme
{
	class Message
	{
		private Image _message;
		private Pixel _couleurPixel;
		private int _taillePixel;

		public Message(string[] tabPhrase, string sortie, string couleur, bool record, bool cacher)
		{
			Pixel couleurBlanc = new Pixel(255, 255, 255);
			string mot = "Tableau des records du jeu !";
			byte intensite = 200; // baisse de l'intensité pour rendre l'image moins visible
			this._taillePixel = 10;
			int debut = 10;
			int colonneTaille = MaxTailleLigne(tabPhrase,0) * this._taillePixel + 20;
			int ligneTaille = tabPhrase.Length * this._taillePixel + 20;

			if (record)
			{
				colonneTaille = MaxTailleLigne(tabPhrase,mot.Length) * 10 + 30;
				ligneTaille = 10 * this._taillePixel + 20; // 10*10 taille de lettre = 10 pixels et on a 10 joueurs dans le classement
											//+ 20 pour un espace avant la fin et au début +10 pour la ligne avec écrit mot
			}
			Pixel[,] mat = new Pixel[ligneTaille, colonneTaille];
			this._message = new Image(mat);
			this._message.Remplissage(couleurBlanc);
			if (record)
			{
				CouleurLettre("ROUGE");
				EcriturePhrase(mot, debut);
				this._message.ColorisationImageNoir(this._couleurPixel);
				debut += this._taillePixel;
			}
			CouleurLettre(couleur);
			for (int i = 0;
				i < tabPhrase.Length;
				i++)
			{
				int indexDebut = debut + i * this._taillePixel;
				EcriturePhrase(tabPhrase[i], indexDebut);
			}
			this._message.ColorisationImageNoir(this._couleurPixel);
			LectureEcriture photo = new LectureEcriture("NouvelleImage.bmp");//image null, elle permet de ne pas à avoir à écrire le header en brut dans le code
			// quand on crée une nouvelle image
			if (cacher)
			{
				this._message.Intensité(intensite);
			}
			photo.ImageClasse = this._message;
			photo.FromImageToFile(sortie);
			System.Diagnostics.Process.Start(sortie);
		}
		/// <summary>
		/// Retourne la taille max des string du tableau
		/// </summary>
		/// <param name="tab"></param>
		/// <param name="valeurMini"></param>
		/// <returns></returns>
		private int MaxTailleLigne(string[] tab,int valeurMini)
		{
			int max = valeurMini;
			for (int i = 0;
				i < tab.Length;
				i++)
			{
				if (tab[i].Length > max)
				{
					max = tab[i].Length;
				}
			}
			return max;
		}
		/// <summary>
		/// On parcourt la phrase et on ecriture dans l'image lettre par lettre
		/// </summary>
		private void EcriturePhrase(string phrase,int debutLigne)
		{
			for (int i = 0;
				i < phrase.Length;
				i++)
			{
				phrase = phrase.ToUpper();
				char lettre = phrase[i];
				EcritureLettre(lettre, debutLigne, 10 + i * this._taillePixel); // incrementation = 10 , taille pix = 10
			}
		}
		/// <summary>
		/// On attribue une valeur de couleur en fonction de la couleur demandé par l'utilisateur
		/// </summary>
		/// <param name="couleur"></param>
		private void CouleurLettre(string couleur)
		{
			Pixel pix = new Pixel(0);
			couleur = couleur.ToUpper();
			switch(couleur) // si la reponse utilisateur est noir pas besoin de modifier
			{
				case "ROUGE":
					pix.Rouge = 255;
					break;

				case "BLEU":
					pix.Bleu = 255;
					break;

				case "VERT":
					pix.Vert = 255;
					break;
			}
			this._couleurPixel = pix;
		}
		/// <summary>
		/// Ecriture lettre par lettre dans l'image
		/// </summary>
		/// <param name="lettre"></param>
		/// <param name="ligne"> Ligne ou l'on doit écrire la lettre</param>
		/// <param name="colonne"> Colonne ou l'on doit écrire la lettre</param>
		private void EcritureLettre(char lettre,int ligne,int colonne)
		{
			string character = null;
			switch(lettre)
			{
				default:
					character = lettre.ToString();
					break;

				case ' ':
					character = "SPACE";
					break;

				case '!':
					character = "EXCLAMATION";
					break;

				case '?':
					character = "INTERROGATION";
					break;

				case '.':
					character = "POINT";
					break;

				case ',':
					character = "VIRGULE";
					break;

				case ';':
					character = "SPACE";
					break;
			}
			string nom = character + ".bmp";
			LectureEcriture lectureLettre = new LectureEcriture(nom);
			this._message.CopyDonne(lectureLettre.ImageClasse.MatPixel, ligne, colonne);
		}
	}
}
