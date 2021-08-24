using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Traitement_image_Wpf.ViewModels
{
	public class ImageUIViewModel : ObservableObject
	{
		private string _path;
		private ImageSource _bmpSource;
		private BitmapImage _image;

		#region Propriétés
		public BitmapImage Image
		{
			set { this._image = value; }
		}
		public string Path
		{
			get { return this._path; }
			set { this._path = value;
				Load();
			}
		}

		public ImageSource BmpSource
		{
			get { return this._bmpSource; }
			set { this._bmpSource = value;
				OnPropertyChanged("BmpSource");
			}
		}
		#endregion
		
		/// <summary>
		/// Load une image dans l'UI à partir du tableau de byte
		/// </summary>
		/// <returns></returns>
		public void LoadImage(byte[] tab)
		{
			this._image = new BitmapImage();
			MemoryStream passage = new MemoryStream(tab);
			passage.Position = 0;
			this._image.BeginInit();
			this._image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
			this._image.CacheOption = BitmapCacheOption.OnLoad;
			this._image.UriSource = null;
			this._image.StreamSource = passage;
			this._image.EndInit();
			this._image.Freeze();
			BmpSource = this._image;
		}

		/// <summary>
		/// Load l'image issu du chemin
		/// </summary>
		private void Load()
		{
			this._image = new BitmapImage();
			this._image.BeginInit();
			this._image.CacheOption = BitmapCacheOption.OnLoad;
			this._image.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
			this._image.UriSource = new Uri(this._path, UriKind.RelativeOrAbsolute);
			this._image.EndInit();
			this._image.Freeze();
			BmpSource = this._image;
		}

	}
}
