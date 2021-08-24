using Microsoft.VisualStudio.TestTools.UnitTesting;
using Do_Pham_Alexandre_Meyer_Adrien_Probleme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traitement_image_Wpf.Models;

namespace Do_Pham_Alexandre_Meyer_Adrien_Probleme.Tests
{
	[TestClass()]
	public class UnitaireTests
	{
		[TestMethod()]
		public void Pareil()
		{
			Pixel test = new Pixel(100, 200, 0);
			Pixel test2 = new Pixel(100, 0, 200);
			Assert.AreEqual(false, test.Pareil(test2));
		}

		[TestMethod()]
		public void Vert()
		{
			Pixel test = new Pixel(100, 200, 0);
			test.Vertation();
			Assert.AreEqual(0, test.Rouge);
		}

		[TestMethod()]
		public void Moyenne()
		{
			Pixel test = new Pixel(100, 200, 0);
			int valeur = test.ValeurMoyenne();
			Assert.AreEqual(100,valeur);
		}

		[TestMethod()]
		public void Rouge()
		{
			Pixel test = new Pixel(100, 200, 10);
			test.Rougation();
			Assert.AreEqual(10, test.Rouge);
		}
		
	}
}