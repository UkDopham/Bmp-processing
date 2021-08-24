using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Do_Pham_Alexandre_Meyer_Adrien_Probleme
{
	class Jeu
	{
		private string _nomJoueur;
		private int _score;
		private LectureEcriture _image;
		private string _difficulte;

		public Jeu(string nomJoueur)
		{
			Random aleatoire = new Random();
			string musique = "musique.mp3";
			int pointParImage = 5;
			int tempsPartie = 30; // en seconde
			System.Diagnostics.Process.Start(musique);
			string sortie = "reponse.bmp";
			bool gagne = false;
			this._nomJoueur = nomJoueur;
			this._score = 0;
			int nombre = ChoixDifficulite();
			Temps timer = new Temps();
			int TempsRestant = tempsPartie;
			while (TempsRestant > 0)
			{
				Temps tempsChargement = new Temps();
				bool juste = false;
				gagne = false;
				timer.Calcul();
				string reponseUtilisateur = null;
				int compteur = 0;				
				string fichier = SelectionImage(aleatoire);
				EffetAleatoire(nombre);
				this._image.FromImageToFile(sortie);
				System.Diagnostics.Process.Start(sortie);
				string[] tab = fichier.Split('.');
				string reponse = tab[0];
				reponse = reponse.ToUpper();
				tempsChargement.Calcul();
				int tempsChargementTotal = 0;
				while (!gagne)
				{
					timer.Calcul();
					juste = false;
					Console.ForegroundColor = ConsoleColor.Red;
					if (compteur == 0)
					{
						tempsChargementTotal += tempsChargement.TempsPasse;
					}
					TempsRestant = (tempsPartie + tempsChargementTotal - timer.TempsPasse);
					if (TempsRestant > 0)
					{
						Console.WriteLine("il reste " + TempsRestant + " secondes");
						Console.ResetColor();
						Console.WriteLine("Quel est l'animal sur la photo ?");
						reponseUtilisateur = Console.ReadLine();
						reponseUtilisateur = reponseUtilisateur.ToUpper();
						if (reponseUtilisateur == reponse)
						{
							juste = true;
							gagne = true;
						}
						else
						{
							Console.Clear();
							Console.ForegroundColor = ConsoleColor.Red;
							Console.WriteLine("Réponse incorrecte");
							Console.ResetColor();
							timer.Calcul();
							compteur++;
						}
					}
					else
					{
						gagne = true;
					}
				}
				if (juste)
				{
					int pointGagne = (compteur >= pointParImage) ? 0 : (pointParImage - compteur);
					this._score += pointGagne; ;
					Console.WriteLine("Trouvé !");
					Console.WriteLine("Vous avez gagné " + pointGagne + " points");
					timer.Calcul();
				}
				timer.Calcul();
				TempsRestant = (tempsPartie + tempsChargementTotal - timer.TempsPasse);
			}
			Console.WriteLine("Partie terminée vous avez " + this._score +" points, bien joué !");
			Sauvegarde();
		}
		private int ChoixDifficulite()
		{			
			int valeur = 0;
			bool continuer = false;
			while (!continuer)
			{
				Console.WriteLine("Quel niveau de difficulte ? (easy/normal/hard)");
				string reponse = Console.ReadLine();
				reponse = reponse.ToUpper();
				switch (reponse)
				{
					case "EASY":
						valeur = 3;
						this._difficulte = "EASY";
						continuer = true;
						break;

					case "NORMAL":
						valeur = 6;
						this._difficulte = "NORMAL";
						continuer = true;
						break;

					case "HARD":
						valeur = 12;
						this._difficulte = "HARD";
						continuer = true;
						break;

					default:
						Console.Clear();
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine("Réponse incorrecte");
						Console.ResetColor();
						break;
				}
			}
			return valeur;
		}
		private void EffetAleatoire(int nombre)
		{
			Random aleatoire = new Random();
			for (int i = 0;
				i < nombre;
				i++)
			{
				System.Threading.Thread.Sleep(10);
				int valeur = aleatoire.Next(0, 8);
				TypeEffet(valeur);
			}
		}
		/// <summary>
		/// Selection de l'effet à appliquer à l'image de manière aléatoire
		/// </summary>
		/// <param name="valeur"></param>
		private void TypeEffet(int valeur)
		{
			int taillePixelisation = 10;
			int rotation = 90;
			switch(valeur)
			{
				case 0:
					this._image.ImageClasse.FlouNormal();
					break;

				case 1:
					this._image.ImageClasse.Negatif();
					break;

				case 2:
					this._image.ImageClasse.Gris();
					break;

				case 3:
					this._image.ImageClasse.Mirroir();
					break;

				case 4:
					this._image.ImageClasse.Repoussage();
					break;

				case 5:
					this._image.ImageClasse.Vert();
					break;

				case 6:
					this._image.ImageClasse.Rotation(rotation);
					break;

				case 7:
					this._image.ImageClasse.Pixelisation(taillePixelisation);
					break;

			}
		}
		/// <summary>
		/// Sauvegarde le score dans un tableau
		/// Triage du tableau du meilleur score au plus mauvaise de haut en bas
		/// Ecriture du tableau des record dans une image
		/// </summary>
		private void Sauvegarde()
		{
			string couleur = "NOIR";
			string sortie = "record.bmp";
			string[] tableauRecord = File.ReadAllLines("Record.txt");
			string[][] passage = new string[tableauRecord.Length+1][];
			for (int i = 0;
				i < tableauRecord.Length;
				i++)
			{
				passage[i] = tableauRecord[i].Split(';');
			}
			passage[passage.Length - 1] = new string[3];
			passage[passage.Length - 1][0] = this._nomJoueur;
			passage[passage.Length - 1][1] = this._difficulte;
			passage[passage.Length - 1][2] = Convert.ToString(this._score);
			Tri(passage);
			string[] final = Reecriture(passage);
			File.WriteAllLines("Record.txt", final);
			Message msg = new Message(final, sortie, couleur, true, false);
		}
		/// <summary>
		/// Passage d'un tableau double de string à un tableau simple de string
		/// </summary>
		/// <param name="tab"></param>
		/// <returns></returns>
		private string[] Reecriture(string[][] tab)
		{
			int taille = 10; //on veut un top 10 
			// les derniers valeurs ne sont donc pas prise en compte
			string[] tab1D = new string[taille];
			for (int i = 0;
				i < tab1D.Length;
				i++)
			{
				string passage = null;
				for (int j = 0;
					j < tab[i].Length;
					j++)
				{
					passage += tab[i][j];
					if (j < tab[i].Length -1)
					{
						passage += ";";
					}
				}
				tab1D[i] = passage;
			}
			return tab1D;
		}
		/// <summary>
		/// Triage du tableau des records
		/// </summary>
		/// <param name="tab"></param>
		private void Tri(string[][] tab)
		{
			for (int i = 0;
				i < tab.Length-1;
				i++)
			{
				for (int j = 0;
					j < tab.Length-1;
					j++)
				{
					int valeurA = Convert.ToInt32(tab[j][2]);
					int valeurB = Convert.ToInt32(tab[j+1][2]);
					if (valeurA < valeurB)
					{
						string[] passage = tab[j];
						tab[j] = tab[j + 1];
						tab[j + 1] = passage;
					}
				}
			}
		}
		/// <summary>
		/// Selection de l'image de maniere aléatoire
		/// </summary>
		/// <param name="aleatoire"></param>
		/// <returns></returns>
		private string SelectionImage(Random aleatoire)
		{
			string nom = null;
			aleatoire = new Random();
			int valeur = aleatoire.Next(0, 14);
			switch (valeur)
			{
				case 0:
					nom  = "chat.bmp";
					break;

				case 1:
					nom = "chien.bmp";
					break;

				case 2:
					nom = "poisson.bmp";
					break;

				case 3:
					nom = "crocodile.bmp";
					break;

				case 4:
					nom = "hamster.bmp";
					break;

				case 5:
					nom = "biche.bmp";
					break;

				case 6:
					nom = "lion.bmp";
					break;

				case 7:
					nom = "chameau.bmp";
					break;

				case 8:
					nom = "coq.bmp";
					break;

				case 9:
					nom = "giraffe.bmp";
					break;

				case 10:
					nom = "herisson.bmp";
					break;

				case 11:
					nom = "koala.bmp";
					break;

				case 12:
					nom = "limace.bmp";
					break;

				case 13:
					nom = "serpent.bmp";
					break;
			}
			this._image = new LectureEcriture(nom);
			return nom;
		}
	}
}
