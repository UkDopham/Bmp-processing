using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_Pham_Alexandre_Meyer_Adrien_Probleme
{
	public class Pixel
	{
		private byte _rouge;
		private byte _vert;
		private byte _bleu;
		private byte _alpha;

		public Pixel(byte bleu, byte vert , byte rouge)
		{
			this._bleu = bleu;
			this._vert = vert;
			this._rouge = rouge;
		}
		public Pixel(Pixel autrePixel)
		{
			this._bleu = autrePixel.Bleu;
			this._vert = autrePixel.Vert;
			this._rouge = autrePixel.Rouge;
		}
		public Pixel(byte bleu, byte vert, byte rouge, byte alpha)
		{
			this._bleu = bleu;
			this._vert = vert;
			this._rouge = rouge;
			this._alpha = alpha;
		} // pas utilisé yet
		public Pixel(byte valeur) //gris
		{
			this._bleu = valeur;
			this._vert = valeur;
			this._rouge = valeur;
		}
		public byte Rouge
		{
			get { return this._rouge; }
			set { this._rouge = value; }
		}
		public byte Vert
		{
			get { return this._vert; }
			set { this._vert = value; }
		}
		public byte Bleu
		{
			get { return this._bleu; }
			set { this._bleu = value; }
		}
		/// <summary>
		/// Retourne un string contenant les valeurs BVR
		/// </summary>
		/// <returns></returns>
		public string Description()
		{
			string desc = null;
			desc +=
				this._bleu
				+ Espace(this._bleu)
				+ this._vert
				+ Espace(this._vert)
				+ this._rouge
				+ Espace(this._rouge);
			return desc;
		}
		/// <summary>
		/// Retourne true si le pixel est le meme que celui en parametre
		/// </summary>
		/// <param name="autrePixel"></param>
		/// <returns></returns>
		public bool Pareil(Pixel autrePixel)
		{
			bool same = true;
			if (this._rouge != autrePixel.Rouge)
			{
				same = false;
			}
			else
			{
				if (this._vert != autrePixel.Vert)
				{
					same = false;
				}
				else
				{
					if(this._bleu != autrePixel.Bleu)
					{
						same = false;
					}
				}
			}
			return same;
		}

		/// <summary>
		/// Copy les valeurs d'un pixel
		/// </summary>
		/// <param name="Acopy"></param>
		public void Copy(Pixel Acopy)
		{
			this._bleu = Acopy.Bleu;
			this._vert = Acopy.Vert;
			this._rouge = Acopy.Rouge;
		}

		/// <summary>
		/// Met la valeur de rouge et bleu à 0
		/// </summary>
		public void Vertation()
		{
			this._rouge = 0;
			this._bleu = 0;
		}

		/// <summary>
		/// Met la valeur de vert et bleu à 0
		/// </summary>
		public void Rougation()
		{
			this._vert = 0;
			this._bleu = 0;
		}
		/// <summary>
		/// Fais la moyenne des valeurs BVR pour avoir la valeur en gris
		/// </summary>
		public void Moyenne()
		{
			int somme = this._rouge + this._vert + this._bleu;
			byte moyenne = (byte)(somme / 3);
			this._rouge = moyenne;
			this._vert = moyenne;
			this._bleu = moyenne;
		}
		/// <summary>
		/// Retourne la valeur moyenne BVR
		/// </summary>
		/// <returns></returns>
		public int ValeurMoyenne()
		{
			int valeur = 0;
			valeur += this._bleu
				+ this._rouge
				+ this._vert;
			valeur /= 3;
			return valeur;
		}
		/// <summary>
		/// Retourne un string contant un nombre d'espace en fonction de la valeur
		/// </summary>
		/// <param name="valeur"></param>
		/// <returns></returns>
		private string Espace(int valeur)
		{
			string espace = " ";
			if (valeur < 100)
			{
				espace += " ";
				if (valeur < 10)
				{
					espace += " ";
				}
			}
			return espace;
		}
	}
}
