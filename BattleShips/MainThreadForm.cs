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
	public partial class MainThreadForm : Form
	{
		private static MainThreadForm instance;

		public static MainThreadForm mainThread { get { return instance; } }


		public MainThreadForm()
		{
			InitializeComponent();

			instance = this;

			Hide();
			new MenuScreen().ShowDialog();
		}

		public void CloseOpenForm(Form formToClose, Form formToOpen)
		{
		
			formToClose.Dispose();
			formToClose.Close();

			GC.Collect();
			GC.WaitForPendingFinalizers();

			formToOpen.ShowDialog();

		}
	}
}
