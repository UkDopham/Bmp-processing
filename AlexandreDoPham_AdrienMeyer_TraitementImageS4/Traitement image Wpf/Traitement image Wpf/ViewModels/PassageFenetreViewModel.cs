using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traitement_image_Wpf.Views;

namespace Traitement_image_Wpf.ViewModels
{
   public  class PassageFenetreViewModel : MainWindow
    {
		private LoginUserControl _loginUC;
		private MenuUserControl _menuUC;

		public LoginUserControl LoginUC
		{
			get { return this._loginUC; }
			set { this._loginUC = value; }
		}

		public MenuUserControl MenuUC
		{
			get { return this._menuUC; }
			set { this._menuUC = value; }
		}
		public void Load()
		{
			
		}
    }
}
