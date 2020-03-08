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
	public partial class MenuScreen : Form
	{
		public MenuScreen()
		{
			InitializeComponent();
		}

		private void startGame_button_Click(object sender, EventArgs e)
		{
			Hide();
			new GameScreen(this).ShowDialog();
			
		}

		private void exit_button_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}
	}
}
