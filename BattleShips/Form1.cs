using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleShips
{
	public partial class GameScreen : Form
	{

		int numberOfHits = 0;
		public GameScreen()
		{
			InitializeComponent();
		}

		private void DestroyShip(PictureBox picture)
		{
			PictureBox destroyed = new PictureBox();
			destroyed.Image = Image.FromFile("E:\\Programming\\c# vsite projects\\BatleShips game\\BattleShips\\BattleShips\\Art\\Destroyed_ship.png");
			picture.Image = destroyed.Image;
			picture.BringToFront();
		}

		private void FireButton_Click(object sender, EventArgs e)
		{

			String letter = LetterboxText.Text;
			String number = NumberboxText.Text;
			String s = "EnemyField_" + letter + number;

			PictureBox pic = Controls.Find(s, true).FirstOrDefault() as PictureBox;
			Point p = pic.Location;

			if (pic == null)
				ActionText.Text = "Bad coordinaates mate!";
			else
			{
				ActionText.Text = "Firing at " +
					pic.Name.Substring(pic.Name.IndexOf('_') + 1, 2);
				DestroyShip(pic);
			}
		}
	}
}
