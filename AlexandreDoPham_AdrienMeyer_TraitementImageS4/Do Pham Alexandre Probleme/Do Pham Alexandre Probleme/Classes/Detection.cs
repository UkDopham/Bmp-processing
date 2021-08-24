using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_Pham_Alexandre_Meyer_Adrien_Probleme
{
	class Detection
	{
		private LectureEcriture _image;
		private LectureEcriture _objet;
		private bool _presence;

		public bool Presence
		{
			get { return this._presence; }
		}

		public Detection(string nomImage, string nomObjet)
		{
			this._image = new LectureEcriture(nomImage);
			this._objet = new LectureEcriture(nomObjet);
			this._presence = false;
		}
		/// <summary>
		/// Detection simple, l'objet a trouvé est pareil dans l'image 
		/// </summary>
		public void Normal()
		{
			this._presence = this._image.ImageClasse.Presence(this._objet.ImageClasse);
		}
	}
}
