using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleShips
{
	public partial class MainThreadForm : Form
	{
		private static MainThreadForm instance;

		public static MainThreadForm mainThread { get { return instance; } }

		private bool soundOn;
		public bool SoundOn
		{
			get { return soundOn; }

			set
			{
				if (value == false)
				{
					sound.Stop();
					soundOn = false;
				}
				else
				{
					sound.PlayLooping();
					soundOn = true;
				}
			}

		}
		SoundPlayer sound;
		Stream buffer;
		public MainThreadForm()
		{
			InitializeComponent();

			instance = this;
			sound = new SoundPlayer();
			soundOn = true;

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

		public void SetSoundStream(Stream stream)
		{

			buffer = stream;
			sound.Stream = buffer;

			if (soundOn == true)
				sound.PlayLooping();

		}

	}
}
