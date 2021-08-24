using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;


namespace Do_Pham_Alexandre_Meyer_Adrien_Probleme
{
	class Program 
	{
		static void PresenceObjet(string image1, string objet)
		{
			Detection detectionObjet = new Detection(image1, objet);
			detectionObjet.Normal();
			Console.WriteLine(detectionObjet.Presence);
		}
		static string Message(bool intensite = false)
		{
			string sortieMessage = "message.bmp";
			Console.WriteLine("Quel est le message a cacher ?");
			string msg = Console.ReadLine();
			string[] tabMsg = msg.Split('*'); // on considere que '*' signifie un passage à la ligne
			Console.WriteLine("Quel couleur pour le message ? (Rouge/Bleu/Vert/noir)");
			string couleur = Console.ReadLine();
			Message messsage = new Message(tabMsg, sortieMessage,couleur,false,intensite);
			return sortieMessage;
		}
		static void MessageCode(string nom, string sortie)
		{			
			string sortieMessage = Message(true);
			Codage(nom, sortieMessage,sortie,false);
		}
		static void Jeu(string sortie)
		{
			Console.WriteLine("Nom de joueur ");
			string nom = Console.ReadLine();
			Jeu game = new Jeu(nom);
		}
		static void Fractale(string sortie)
		{
			int hauteur = 0;
			int largeur = 0;
			bool continuer = false;
			while (!continuer)
			{
				Console.WriteLine("Quelle hauteur ?");
				hauteur = Convert.ToInt32(Console.ReadLine());
				Console.WriteLine("Quelle largeur ?");
				largeur = Convert.ToInt32(Console.ReadLine());
				if (largeur > 0 &&
					hauteur > 0)
				{
					continuer = true;
				}
				else
				{
					Console.Clear();
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("Réponse incorrecte");
					Console.ResetColor();
				}
			}
			LectureEcriture A = new LectureEcriture("NouvelleImage.bmp",false);//"nouvelleImage " correspond à une petite image blanche, 
			//elle nous permet de ne pas à avoir à écrire le header en brut dans le code quand on crée une nouvelle image
			A.ImageClasse.Redimension(hauteur, largeur);
			A.ImageClasse.Fractale();
			A.FromImageToFile(sortie);
		}
		static void HistogrammeCouleur(string nom, string sortie,bool affi)
		{
			bool separe = false;
			LectureEcriture A = new LectureEcriture(nom, affi);
			bool continuer = false;
			while (!continuer)
			{
				Console.WriteLine("Histogrammes séparés ? (oui/non)");
				string reponse = Console.ReadLine();
				reponse = reponse.ToUpper();
				switch (reponse)
				{
					case "OUI":
						separe = true;
						continuer = true;
						break;

					case "NON":
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
			A.HistogrammeCouleur(separe);
			A.FromImageToFile(sortie);
		}
		static void Histogramme(string nom,string sortie, bool affi)
		{
			LectureEcriture A = new LectureEcriture(nom, affi);
			A.HistogrammeGris();
			A.FromImageToFile(sortie);
		}
		static void Decodage(string image, string sortie1, string sortie2,bool affi)
		{
			LectureEcriture A = new LectureEcriture(image,affi);
			Image B = A.ImageClasse.Decodage();
			A.FromImageToFile(sortie1);
			A.ImageClasse = B;
			A.FromImageToFile(sortie2);
		}
		static void Codage(string image1, string image2, string sortie, bool affi, bool redimension = true)
		{
			LectureEcriture A = new LectureEcriture(image1, affi);
			LectureEcriture B = new LectureEcriture(image2, affi);
			bool continuer = false;
			if (redimension)
			{
				while (!continuer)
				{
					Console.WriteLine("Redimensionner l'image à cacher ? (oui/non)");
					string reponse = Console.ReadLine();
					reponse = reponse.ToUpper();
					switch (reponse)
					{
						case "OUI":
							B.ImageClasse.Redimension(A.ImageClasse.MatPixel.GetLength(0), A.ImageClasse.MatPixel.GetLength(1));
							continuer = true;
							break;

						case "NON":
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
			}
			A.ImageClasse.Codage(B.ImageClasse);
			A.FromImageToFile(sortie);
		}
		static void Pixelisation(string nom,string sortie, bool affi)
		{
			LectureEcriture A = new LectureEcriture(nom, affi);
			int taille = 0;
			bool continuer = false;
			while (!continuer)
			{
				Console.WriteLine("Quelle taille de pixelisation ? (petite,moyenne,grande)");
				string reponse = Console.ReadLine();
				reponse = reponse.ToUpper();
				switch(reponse)
				{
					case "PETITE":
						taille = 5;
						continuer = true;
						break;

					case "MOYENNE":
						taille = 10;
						continuer = true;
						break;

					case "GRANDE":
						taille = 20;
						continuer = true;
						break;

					default:
						Console.Clear();
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine("Taille incorrecte");
						Console.ResetColor();
						break;
				}
			}
			A.ImageClasse.Pixelisation(taille);
			A.FromImageToFile(sortie);
		}
		static void Seuillage(string nom, string sortie, bool affi)
		{
			LectureEcriture A = new LectureEcriture(nom,affi);
			A.ImageClasse.Seuillage();
			A.FromImageToFile(sortie);
		}
		static void Negatif(string nom, string sortie, bool affi)
		{
			LectureEcriture A = new LectureEcriture(nom, affi);
			A.ImageClasse.Negatif();
			A.FromImageToFile(sortie);
		}
		static void Detection(string nom, string sortie,bool affi)
		{
			LectureEcriture A = new LectureEcriture(nom,affi);
			A.ImageClasse.DetectionBords();
			A.FromImageToFile(sortie);
		}
		static void Renforcement(string nom,string sortie, bool affi)
		{
			LectureEcriture A = new LectureEcriture(nom, affi);
			A.ImageClasse.RenforcementBords();
			A.FromImageToFile(sortie);
		}
		static void Repoussage(string nom, string sortie, bool affi)
		{
			LectureEcriture A = new LectureEcriture(nom, affi);
			A.ImageClasse.Repoussage();
			A.FromImageToFile(sortie);
		}
		static void VieillePhoto(string nom, string sortie, bool affi)
		{
			LectureEcriture A = new LectureEcriture(nom, affi);
			A.ImageClasse.Gris();
			A.ImageClasse.Veillissement();
			A.ImageClasse.FlouNormal();
			A.FromImageToFile(sortie);
		}
		static void FlouNormal(string nom, string sortie, bool affi)
		{
			LectureEcriture A = new LectureEcriture(nom, affi);
			A.ImageClasse.FlouNormal();
			A.FromImageToFile(sortie);
		}
		static void Redimension(string nom, string sortie, bool affi) 
		{
			LectureEcriture A = new LectureEcriture(nom, affi);
			bool continuer = false;
			int hauteur = 0;
			int largeur = 0;
			while (!continuer)
			{
				Console.WriteLine("Quel est la nouvelle hauteur ?");
				hauteur = Convert.ToInt32(Console.ReadLine());
				Console.WriteLine("Quel est la nouvelle largeur ?");
				largeur = Convert.ToInt32(Console.ReadLine());
				if ((largeur >0)&&
					(hauteur >0))
				{
					continuer = true;
				}
				else
				{
					Console.Clear();
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("Réponse incorrecte");
					Console.ResetColor();
				}
			}
			A.ImageClasse.Redimension(hauteur, largeur);
			A.FromImageToFile(sortie);
		}
		static void Rotation(string nom, string sortie,bool affi) 
		{
			int valeur = 0;
			bool continuer = false;
			LectureEcriture A = new LectureEcriture(nom, affi);
			while (!continuer)
			{
				Console.WriteLine("Quel angle pour la rotation ?");
				valeur = Convert.ToInt32(Console.ReadLine());
				int modulo = valeur % 90;
				if( (modulo == 0)&& 
					(valeur <= 270)&&
					(valeur >0))
				{
					continuer = true;
				}
				else
				{
					Console.Clear();
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("Réponse incorrecte");
					Console.ResetColor();
				}
			}
			A.ImageClasse.Rotation(valeur);
			A.FromImageToFile(sortie);
		}
		static void Vert(string nom, string sortie, bool affi)
		{
			LectureEcriture A = new LectureEcriture(nom, affi);
			A.ImageClasse.Vert();
			A.FromImageToFile(sortie);
		}
		static void Gris(string nom, string sortie, bool affi)
		{
			LectureEcriture A = new LectureEcriture(nom,affi);
			A.ImageClasse.Gris();
			A.FromImageToFile(sortie);
		}
		static void Mirroir(string nom, string sortie, bool affi)
		{
			LectureEcriture A = new LectureEcriture(nom, affi);
			A.ImageClasse.Mirroir();
			Console.WriteLine();
			A.FromImageToFile(sortie);
		}
		static string DemandeUtilisateur()
		{
			Console.WriteLine("Quel est le nom de l'image ?");
			string reponse = Console.ReadLine();
			bool continuer = false;
			string extension = null;
			while (!continuer)
			{
				Console.WriteLine("Quel est le format d'extension de l'image ? (bmp/csv)");
				extension = Console.ReadLine();
				if (extension != "bmp" &&
					extension != "csv")
				{
					Console.Clear();
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("Réponse incorrecte");
					Console.ResetColor();
				}
				else
				{
					continuer = true;
				}
			}
			reponse += "."
				+ extension;
			return reponse;
		}
		static bool Affichage()
		{
			bool affichage = false;
			bool continuer = false;
			while (!continuer)
			{
				Console.WriteLine("Voulez vous affichez les informations de la matrice ?  (Header + Matrice) (oui/non)");
				string reponse = Console.ReadLine();
				reponse = reponse.ToUpper();
				switch (reponse)
				{
					case "OUI":
						affichage = true;
						continuer = true;
						break;

					case "NON":
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
			return affichage;
		}
		static void Main(string[] args)
		{
			string image1 = "lena.bmp";
			string image2 = "coco.bmp";
			string sortie1 = "sortie1.bmp";
			string sortie2 = "sortie2.bmp";
			bool affi = false;
			bool continuer = false;
			while (!continuer)
			{				
				Console.Clear();
				Console.WriteLine(
					"1 - Effet mirroir"
					+ "\n"
					+ "2 - Rotation"
					+ "\n"
					+"3 - Gris"
					+ "\n"
					+ "4 - Vert"
					+ "\n"
					+"5 - Redimension"
					+ "\n"
					+"6 - Flou normal"
					+ "\n"
					+"7 - Vieille photo"
					+ "\n"
					+"8 - Detection des contours"
					+ "\n"
					+"9 - Renforcement des bords"
					+"\n"
					+ "10 - Repoussage"
					+ "\n"
					+ "11 - Negatif"
					+ "\n"
					+ "12 - Seuillage"
					+ "\n"
					+ "13 - Pixelisation"
					+ "\n"
					+ "14 - Codage d'une image"
					+ "\n"
					+ "15 - Décodage d'une image"
					+ "\n"
					+ "16 - Histogramme"
					+ "\n"
					+ "17 - Histogramme en fonction de BVR"
					+ "\n"
					+ "18 - Fratacle"
					+ "\n"
					+ "19 - Jeu"
					+ "\n"
					+ "20 - Message codé"
					+ "\n"
					+ "21 - Message"
					+ "\n"
					+ "22 - Présence objet"
					+ "\n");
				Console.WriteLine("Selectionner ce que vous voulez faire");
				int input = Convert.ToInt32(Console.ReadLine());
				switch (input)
				{
					case 1:
						Console.Clear();
						image1 = DemandeUtilisateur();
						affi = Affichage();
						Mirroir(image1,sortie1,affi);
						continuer = true;
						System.Diagnostics.Process.Start(sortie1);
						break;

					case 2:
						Console.Clear();
						image1 = DemandeUtilisateur();
						affi = Affichage();
						Rotation(image1, sortie1, affi);
						continuer = true;
						System.Diagnostics.Process.Start(sortie1);
						break;

					case 3:
						Console.Clear();
						image1 = DemandeUtilisateur();
						affi = Affichage();
						Gris(image1, sortie1, affi);
						continuer = true;
						System.Diagnostics.Process.Start(sortie1);
						break;

					case 4:
						Console.Clear();
						image1 = DemandeUtilisateur();
						affi = Affichage();
						Vert(image1, sortie1, affi);
						continuer = true;
						System.Diagnostics.Process.Start(sortie1);
						break;

					case 5:
						Console.Clear();
						image1 = DemandeUtilisateur();
						affi = Affichage();
						Redimension(image1, sortie1, affi);
						continuer = true;
						System.Diagnostics.Process.Start(sortie1);
						break;

					case 6:
						Console.Clear();
						image1 = DemandeUtilisateur();
						affi = Affichage();
						FlouNormal(image1, sortie1, affi);
						continuer = true;
						System.Diagnostics.Process.Start(sortie1);
						break;

					case 7:
						Console.Clear();
						image1 = DemandeUtilisateur();
						affi = Affichage();
						VieillePhoto(image1, sortie1, affi);
						continuer = true;
						System.Diagnostics.Process.Start(sortie1);
						break;

					case 8:
						Console.Clear();
						image1 = DemandeUtilisateur();
						affi = Affichage();
						Detection(image1, sortie1, affi);
						continuer = true;
						System.Diagnostics.Process.Start(sortie1);
						break;

					case 9:
						Console.Clear();
						image1 = DemandeUtilisateur();
						affi = Affichage();
						Renforcement(image1, sortie1, affi);
						continuer = true;
						System.Diagnostics.Process.Start(sortie1);
						break;

					case 10:
						Console.Clear();
						image1 = DemandeUtilisateur();
						affi = Affichage();
						Repoussage(image1, sortie1, affi);
						continuer = true;
						System.Diagnostics.Process.Start(sortie1);
						break;

					case 11:
						Console.Clear();
						image1 = DemandeUtilisateur();
						affi = Affichage();
						Negatif(image1, sortie1, affi);
						continuer = true;
						System.Diagnostics.Process.Start(sortie1);
						break;

					case 12:
						Console.Clear();
						image1 = DemandeUtilisateur();
						affi = Affichage();
						Seuillage(image1, sortie1, affi);
						continuer = true;
						System.Diagnostics.Process.Start(sortie1);
						break;

					case 13:
						Console.Clear();
						image1 = DemandeUtilisateur();
						affi = Affichage();
						Pixelisation(image1, sortie1, affi);
						continuer = true;
						System.Diagnostics.Process.Start(sortie1);
						break;

					case 14:
						Console.Clear();
						image1 = DemandeUtilisateur();
						affi = Affichage();
						Console.WriteLine("2 ème image");
						image2 = DemandeUtilisateur();
						Codage(image1, image2, sortie1, affi);
						continuer = true;
						System.Diagnostics.Process.Start(sortie1);
						break;

					case 15:
						Console.Clear();
						image1 = DemandeUtilisateur();
						affi = Affichage();
						Decodage(image1, sortie1, sortie2, affi);
						continuer = true;
						System.Diagnostics.Process.Start(sortie1);
						System.Diagnostics.Process.Start(sortie2);
						break;

					case 16:
						Console.Clear();
						image1 = DemandeUtilisateur();
						affi = Affichage();
						Histogramme(image1, sortie1, affi);
						continuer = true;
						System.Diagnostics.Process.Start(sortie1);
						break;

					case 17:
						Console.Clear();
						image1 = DemandeUtilisateur();
						affi = Affichage();
						HistogrammeCouleur(image1, sortie1, affi);
						continuer = true;
						System.Diagnostics.Process.Start(sortie1);
						break;

					case 18:
						Console.Clear();
						Fractale(sortie1);
						continuer = true;
						System.Diagnostics.Process.Start(sortie1);
						break;

					case 19:
						Console.Clear();
						Jeu(sortie1);
						continuer = true;
						break;

					case 20:
						Console.Clear();
						image1 = DemandeUtilisateur();
						MessageCode(image1, sortie1);
						continuer = true;
						System.Diagnostics.Process.Start(sortie1);
						break;

					case 21:
						Console.Clear();
						Message();
						continuer = true;
						break;

					case 22:
						Console.Clear();
						image1 = DemandeUtilisateur();
						image2 = DemandeUtilisateur();
						PresenceObjet(image1, image2);
						continuer = true;
						break;

					default:
						Console.Clear();
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine("Valeur incorrecte");
						Console.ResetColor();
						break;
				}
			}
			Console.WriteLine("Fini ! ");
			Console.ReadKey();
		}
	}
}
