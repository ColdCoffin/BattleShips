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
using BattleShips.Properties;
using System.IO;
using System.Resources;


namespace BattleShips
{
	public partial class MenuScreen : Form
	{
		ResourceManager RM;

		private List<Image> backround;
		static int indexUpdateLoop;

		public bool isHard { get; set; }


		SoundPlayer snd;
		public MenuScreen()
		{
			InitializeComponent();
			backround = new List<Image>();

			RM = new ResourceManager("BattleShips.Properties.Resources", typeof(Resources).Assembly);

			Stream str = Resources.soundscrate_on_a_quest_sc1;
			snd = new SoundPlayer(str);
			snd.PlayLooping();

			indexUpdateLoop = 0;
		}

		private void loadBackround()
		{
			


			backroundLoad_progressbar.Visible = true;

			for (int i = 360; i <= 522; i++)
			{
				backround.Add((Image)RM.GetObject("Backround" + i));
				backroundLoad_progressbar.Value++;
			}

			backroundLoad_progressbar.Visible = false;
			backroundUpdate.Start();

		}

		private void releaseBackround()
		{
			foreach (Image item in backround)
			{
				item.Dispose();
			}

			backround.Clear();
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

			new GameScreen(this).ShowDialog();
			

		}

		public void closeMenu()
		{
			backroundUpdate.Stop();
			releaseBackround();
			Hide();
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

		private void startStopAnimation_button_Click(object sender, EventArgs e)
		{
			if (startStopAnimation_button.Text == "Stop Animation")
			{
				backroundUpdate.Stop();
				startStopAnimation_button.Text = "Start Animation";
			}
			else
			{
				if (backround.Count < 1)
				{
					loadBackround();
				}

				backroundUpdate.Start();
				startStopAnimation_button.Text = "Stop Animation";

			}
		}
	}
}
