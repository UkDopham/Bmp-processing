using Do_Pham_Alexandre_Meyer_Adrien_Probleme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traitement_image_Wpf.ViewModels
{
	public class ColorViewModels
	{
		private Pixel _couleur = new Pixel(0,0,0);
		private bool _fait;

		public bool Fait
		{
			get { return this._fait; }
			set { this._fait = value; }
		}

		public Pixel Couleur
		{
			get { return this._couleur; }
			set { this._couleur = value; }
		}

		public ColorViewModels()
		{
			this._couleur = new Pixel(0,0,0);
		}
		/// <summary>
		/// Convertis un hex en byte
		/// </summary>
		/// <param name="hexa"></param>
		public void HexaToByte(string hexa) //RGB
		{
			string[] tabPassage = hexa.Split('#');
			string[] tabHexa = SeparateurHexa(tabPassage[1]);
			this._couleur.Rouge = Convert.ToByte(tabHexa[0], 16);
			this._couleur.Vert = Convert.ToByte(tabHexa[1], 16);
			this._couleur.Bleu = Convert.ToByte(tabHexa[2], 16);
		}

		/// <summary>
		/// Separe un hexa en 3 composantes
		/// R
		/// G
		/// B
		/// </summary>
		/// <param name="hexa"></param>
		/// <returns></returns>
		private string[] SeparateurHexa(string hexa)
		{
			string[] tabHexa = new string[3];
			int index = 0;
			for (int i = 2;
				i < hexa.Length;
				i+=2)
			{
				tabHexa[index] = hexa[i].ToString(); // +2 car il y a FF au debut de l'ecriture en hexa
				tabHexa[index] += hexa[i + 1].ToString();
				index++;
			}
			return tabHexa;
		}
	}
}
