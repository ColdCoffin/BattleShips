using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace BattleShips
{
	public partial class MenuScreen : Form
	{
		private List<Image> backround;
		static int indexUpdateLoop;

		public bool isHard { get; set; }

		SoundPlayer sound;

		public MenuScreen()
		{
			InitializeComponent();
			loadBackround();

			sound = new SoundPlayer();
			sound.SoundLocation = "E:\\Programming\\c# vsite projects\\" +
					"BatleShips game\\BattleShips\\BattleShips\\Art\\soundscrate-on-a-quest-sc1.wav";
			sound.PlayLooping();

			indexUpdateLoop = 0;
			backroundUpdate.Start();
		}

		private void loadBackround()
		{
			backround = new List<Image>();

			for (int i = 360; i <= 622; i++)
			{
				backround.Add(Image.FromFile("E:\\Programming\\c# vsite projects\\" +
					"BatleShips game\\BattleShips\\BattleShips\\Art\\MenuBackround\\Backround"
					+ i +".jpg"));
			}

		}

		private void startGame_button_Click(object sender, EventArgs e)
		{
			startGame_button.Visible = false;
			options_button.Visible = false;
			multiplayerGame_button.Visible = false;
			exit_button.Visible = false;

			easyOption_button.Visible = true;
			hardOption_button.Visible = true;
			back_button.Visible = true;

		}

		private void exit_button_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void backroundUpdate_Tick(object sender, EventArgs e)
		{
			if (indexUpdateLoop >= 162)
				indexUpdateLoop = 0;

			backround_box.Image = backround[indexUpdateLoop++];
		}

		private void easyOption_button_Click(object sender, EventArgs e)
		{
			isHard = false;

			gameStart();
		}

		private void hardOption_button_Click(object sender, EventArgs e)
		{
			isHard = true;

			gameStart();
		}

		private void gameStart()
		{
			Hide();
			backroundUpdate.Stop();
			backround.Clear();
			new GameScreen(this).ShowDialog();
			Close();
		}

		private void back_button_Click(object sender, EventArgs e)
		{
			startGame_button.Visible = true;
			options_button.Visible = true;
			multiplayerGame_button.Visible = true;
			exit_button.Visible = true;

			easyOption_button.Visible = false;
			hardOption_button.Visible = false;
			back_button.Visible = false;
		}
	}
}
