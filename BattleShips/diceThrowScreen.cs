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

		private void confirm_button_Click(object sender, EventArgs e)
		{
			enemySign = new Sign();
			enemyFinalSign_pictureBox.Image = enemySign.image;
			PlayerFinalSign_pictureBox.Image = playerSign.image;

			enemyFinalSign_pictureBox.Visible = true;
			PlayerFinalSign_pictureBox.Visible = true;
		}
	}
}
