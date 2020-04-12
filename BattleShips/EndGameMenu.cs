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
	public partial class EndGameMenu : UserControl
	{
		int animIndex = 0;

		StatsTracker playerStats;
		StatsTracker enemyStats;

		public EndGameMenu(StatsTracker player, StatsTracker enemy, bool playerWon)
		{
			InitializeComponent();

			playerStats = player;
			enemyStats = enemy;

			timer1.Start();

			playerShipsDestroyed_label.Text += playerStats.shipsDestroyed;
			playerShipHits_label.Text += playerStats.shipsHit;
			playerShipMisses_label.Text += playerStats.shipsMissed;
			playerAccuracy_label.Text += playerStats.CalculateAccuracy() + "%";

			enemyShipsDestroyed_label.Text += enemyStats.shipsDestroyed;
			EnemyShipHits_label.Text += enemyStats.shipsHit;
			enemyShipMisses_label.Text += enemyStats.shipsMissed;
			enemyAccuracy_label.Text += enemyStats.CalculateAccuracy() + "%";

			if (playerWon == true)
				winOrLose_label.Text = "YOU WON!";
			else
				winOrLose_label.Text = "YOU LOST!";

		}

		private void ActionButton_Click(object sender, EventArgs e)
		{
			MainThreadForm.mainThread.CloseOpenForm(GameScreen.GameScreenInstance, new MenuScreen());
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void timer1_Tick_1(object sender, EventArgs e)
		{
			if (animIndex == SetFireMenuAnim.menuAnim.Count())
				animIndex = 0;

			pictureBox1.Image = SetFireMenuAnim.menuAnim[animIndex++];
		}
	}
}
