using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleShips
{
	public partial class InGameOptionsMenu : UserControl
	{
		int animIndex = 0;
		public InGameOptionsMenu()
		{
			InitializeComponent();

			timer1.Start();
		}

		private void ActionButton_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void timer1_Tick(object sender, EventArgs e)
		{

			if (animIndex == SetFireMenuAnim.menuAnim.Count())
				animIndex = 0;

			pictureBox1.Image = SetFireMenuAnim.menuAnim[animIndex++];

			timePlayed_label.Text = "Time played: " + GameScreen.GameScreenInstance.MinutesPassed / 60 + " min";

			if (MainThreadForm.mainThread.SoundOn == true)
				sound_button.Text = "Sound Off";
			else
				sound_button.Text = "Sound On";
		}

		private void back_button_Click(object sender, EventArgs e)
		{
			Visible = false;
			cheat_label.Visible = false;
		}

		private void restart_button_Click(object sender, EventArgs e)
		{
			GameScreen.GameScreenInstance.gameReset();
			Visible = false;
			cheat_label.Visible = false;
		}

		private void mainMenu_button_Click(object sender, EventArgs e)
		{
			MainThreadForm.mainThread.CloseOpenForm(GameScreen.GameScreenInstance, new MenuScreen());
		}

		private void cheat_button_Click(object sender, EventArgs e)
		{
			if (GameScreen.GameScreenInstance.isHard == true)
			{
				cheat_label.Visible = true;
				return;
			}

			GameScreen.GameScreenInstance.Cheat();
			Visible = false;
		}

		private void sound_button_Click(object sender, EventArgs e)
		{
			if (sound_button.Text == "Sound On")
				MainThreadForm.mainThread.SoundOn = true;
			else
				MainThreadForm.mainThread.SoundOn = false;
		}
	}
}
