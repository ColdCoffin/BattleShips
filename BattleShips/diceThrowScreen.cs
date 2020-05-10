using System;
using System.Drawing;
using System.Windows.Forms;
using BattleShips.Properties;

namespace BattleShips
{
	public partial class diceThrowScreen : UserControl
	{
		class Sign
		{
			public signs selected;
			public Image image;
			Random rand;
			public Sign() 
			{
				rand = new Random();
				selected = (signs)rand.Next(Enum.GetNames(typeof(signs)).Length);
				selectImage();
			}

			private Image selectImage()
			{
				if (selected == signs.PAPER)
					image = Resources.Hand_paper_selected;
				else if (selected == signs.ROCK)
					image = Resources.Hand_stone_selected;
				else
					image = Resources.Hand_scissors_selected;

				return image;
			}

			public Image SetSign(signs s)
			{
				selected = s;
				return selectImage();
			}

			public static bool operator <(Sign left, Sign right)
			{
				if (left.selected == signs.SCISSORS && right.selected == signs.ROCK)
					return true;
				if (left.selected == signs.ROCK && right.selected == signs.PAPER)
					return true;
				if (left.selected == signs.PAPER && right.selected == signs.SCISSORS)
					return true;

				return false;
			}

			public static bool operator >(Sign left, Sign right)
			{

				if (left.selected == signs.PAPER && right.selected == signs.ROCK)
					return true;
				if (left.selected == signs.ROCK && right.selected == signs.SCISSORS)
					return true;
				if (left.selected == signs.SCISSORS && right.selected == signs.PAPER)
					return true;

				return false;
			}

			public static bool operator ==(Sign left, Sign right)
			{

				return (left.selected == right.selected);

			}

			public static bool operator !=(Sign left, Sign right)
			{

				return !(left.selected == right.selected);

			}
		};
		enum signs
		{
			ROCK,
			PAPER,
			SCISSORS
		}

		Sign playerSign, enemySign;
		public diceThrowScreen()
		{
			InitializeComponent();
			playerSign = new Sign();
		}

		private void refreshSignsSelect()
		{
			rock.Image = Resources.Hand_stone;
			scissors.Image = Resources.Hand_scissors;
			paper.Image = Resources.Hand_paper;
		}
		private void rock_Click(object sender, EventArgs e)
		{
			
			refreshSignsSelect();
			rock.Image = playerSign.SetSign(signs.ROCK);
		}

		private void paper_Click(object sender, EventArgs e)
		{
			refreshSignsSelect();
			paper.Image = playerSign.SetSign(signs.PAPER);
		}

		private void scissors_Click(object sender, EventArgs e)
		{
			refreshSignsSelect();
			scissors.Image = playerSign.SetSign(signs.SCISSORS);
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			this.Dispose();
		}

		private void confirm_button_Click(object sender, EventArgs e)
		{
			enemySign = new Sign();
			enemyFinalSign_pictureBox.Image = enemySign.image;
			PlayerFinalSign_pictureBox.Image = playerSign.image;

			enemyFinalSign_pictureBox.Visible = true;
			PlayerFinalSign_pictureBox.Visible = true;

			if (playerSign > enemySign == true)
			{
				won_label.Visible = true;
				won_label.BringToFront();
				GameScreen.GameScreenInstance.playerGoesFirst = true;
				timer1.Start();
				confirm_button.Enabled = false;
			}

			else if (enemySign > playerSign == true)
			{
				lost_label.Visible = true;
				lost_label.BringToFront();
				GameScreen.GameScreenInstance.playerGoesFirst = false;
				timer1.Start();
				confirm_button.Enabled = false;
			}

			else
				tryAgain_label.Visible = true;

		}
	}
}
