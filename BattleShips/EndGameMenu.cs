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

		public EndGameMenu()
		{
			InitializeComponent();

			timer1.Start();
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			if (animIndex == SetFireMenuAnim.menuAnim.Count())
				animIndex = 0;

			pictureBox1.Image = SetFireMenuAnim.menuAnim[animIndex++];
		}

		private void ActionButton_Click(object sender, EventArgs e)
		{
			MainThreadForm.mainThread.CloseOpenForm(GameScreen.GameScreenInstance, new MenuScreen());
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}
	}
}
