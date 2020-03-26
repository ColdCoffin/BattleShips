using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;
using BattleShips.Properties;

namespace BattleShips
{
	public partial class SetShip : UserControl
	{

		private List<Image> menuAnim;
		ResourceManager RS;

		PictureBox[] miniMap;

		public SetShip()
		{
			InitializeComponent();
			RS = new ResourceManager("BattleShips.Properties.Resources", typeof(Resources).Assembly);
			menuAnim = new List<Image>();

			loadAnimation();

			miniMap = new PictureBox[100];

			setMinimap();
		}

		private void loadAnimation()
		{
			for (int i = 132; i <= 301; i++)
			{
				menuAnim.Add((Image)RS.GetObject("MenuBoatScreen" + i));
			}
		}

		int animIndex = 0;
		private void timer1_Tick(object sender, EventArgs e)
		{
			if (animIndex == 169)
				animIndex = 0;

			pictureBox1.Image = menuAnim[animIndex++];
		}

		private void ActionButton_Click(object sender, EventArgs e)
		{
			GameScreen.GameScreenInstance.SetShips(choseShip_combobox.Text, ChooseXPos_texbox.Text,
				ChooseYPos_texbox.Text, ChooseName_texbox.Text, VericalOri_radiobutton.Checked);

			ChooseXPos_texbox.Text = "";
			ChooseYPos_texbox.Text = "";
			choseShip_combobox.Text = "";
			ChooseName_texbox.Text = "";

			this.Visible = false;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			ChooseXPos_texbox.Text = "";
			ChooseYPos_texbox.Text = "";
			choseShip_combobox.Text = "";
			ChooseName_texbox.Text = "";

			GameScreen.GameScreenInstance.CancelMenu();

			Visible = false;
		}

		private void SetShip_VisibleChanged(object sender, EventArgs e)
		{
			if (Visible == true)
			{
				timer1.Start();

				refreshMinimap();
			}

			if (Visible == false)
			{
				timer1.Stop();
			}
		}
		private void setMinimap()
		{
			for (int i = 0; i < 100; i += 10)
			{
				for (int j = 0; j < 10; j++)
				{
					double temp = i * 1.5;

					miniMap[i + j] = new PictureBox();
					miniMap[i + j].Parent = panel1;
					miniMap[i + j].Location = new Point(j * 15, (int)temp);
				}
			}
		}

		private void refreshMinimap()
		{
			for (int i = 0; i < 100; i += 10)
			{
				for (int j = 0; j < 10; j++)
				{
					miniMap[i + j].BringToFront();

					if (PlayerField.isShipTarget(new Point(j * 30, i * 3)) == true)
						miniMap[i + j].Image = Resources.Menu_redButton;
					else
						miniMap[i + j].Image = Resources.Menu_greenButton;
				}
			}
		}
	}
}
