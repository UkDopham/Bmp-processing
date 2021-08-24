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

		public Message(string[] tabPhrase, string sortie, Pixel couleur, bool record, bool cacher,string path,int taillePixel)
		{
			Pixel couleurBlanc = new Pixel(255, 255, 255);
			string mot = "Tableau des records du jeu !";
			byte intensite = 200; // baisse de l'intensité pour rendre l'image moins visible
			this._taillePixel = taillePixel;
			int debut = 10;
			this._couleurPixel = couleur;
			LectureEcriture photo = new LectureEcriture(path);
			/*
			if (record)
			{
				colonneTaille = MaxTailleLigne(tabPhrase,mot.Length) * 10 + 30;
				ligneTaille = 10 * this._taillePixel + 20; // 10*10 taille de lettre = 10 pixels et on a 10 joueurs dans le classement
											//+ 20 pour un espace avant la fin et au début +10 pour la ligne avec écrit mot
			}
			*/
			this._message = photo.ImageClasse;
			/*
			if (record)
			{
				CouleurLettre("ROUGE");
				EcriturePhrase(mot, debut);
				this._message.ColorisationImageNoir(this._couleurPixel);
				debut += this._taillePixel;
			}
			*/			
			for (int i = 0;
				i < tabPhrase.Length;
				i++)
			{
				int indexDebut = debut + i * this._taillePixel;
				EcriturePhrase(tabPhrase[i], indexDebut);
			}
			this._message.ColorisationImageNoir(this._couleurPixel);
			// quand on crée une nouvelle image
			if (cacher)
			{
				this._message.Intensité(intensite);
			}
			photo.ImageClasse = this._message;
			photo.FromImageToFile(sortie);
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
			lectureLettre.ImageClasse.Redimension(this._taillePixel, this._taillePixel);
			this._message.CopyDonne(lectureLettre.ImageClasse.MatPixel, ligne, colonne,true);
		}
	}
}
