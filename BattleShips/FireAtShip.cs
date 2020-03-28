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
	public partial class FireAtShip : UserControl
	{
		int animIndex = 0;

		PictureBox[] miniMap;
		public FireAtShip()
		{
			InitializeComponent();

			miniMap = new PictureBox[100];

			setMinimap();
			refreshMinimap();
			timer1.Start();
		}

		~FireAtShip()
		{
			foreach (PictureBox picture in miniMap)
			{
				picture.Dispose();
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

					if (EnemyField.isAlreadyHit(new Point(j * 30, i * 3)) == true)
					{

						if (EnemyField.isShipTarget(new Point(j * 30, i * 3)) == true)
							miniMap[i + j].Image = Resources.Menu_redButton;
						else
							miniMap[i + j].Image = Resources.Menu_grayButton;

					}
					else
						miniMap[i + j].Image = Resources.Menu_greenButton;
				}
			}
		}

		private void timer1_Tick_1(object sender, EventArgs e)
		{
			if (animIndex == SetFireMenuAnim.menuAnim.Count())
				animIndex = 0;

			pictureBox1.Image = SetFireMenuAnim.menuAnim[animIndex++];
		}

		private void FireAtShip_VisibleChanged(object sender, EventArgs e)
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

		private void ActionButton_Click(object sender, EventArgs e)
		{
			GameScreen.GameScreenInstance.Fire(ChooseXPos_texbox.Text, ChooseYPos_texbox.Text);

			ChooseXPos_texbox.Text = "";
			ChooseYPos_texbox.Text = "";

			this.Visible = false;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			ChooseXPos_texbox.Text = "";
			ChooseYPos_texbox.Text = "";

			GameScreen.GameScreenInstance.CancelMenu();

			Visible = false;
		}
	}

}
