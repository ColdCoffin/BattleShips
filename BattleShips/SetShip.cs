using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;
using BattleShips.Properties;

namespace BattleShips
{
	public partial class SetShip : UserControl
	{
		private static SetShip setShipInstance;
		public static SetShip SetShipInstance
		{
			get
			{
				if (setShipInstance == null)
					setShipInstance = new SetShip();
				return setShipInstance;
			}			
		}

		private List<Image> menuAnim;
		ResourceManager RS;

		public SetShip()
		{
			InitializeComponent();
			RS = new ResourceManager("BattleShips.Properties.Resources", typeof(Resources).Assembly);
			menuAnim = new List<Image>();

			loadAnimation();
		}


		private void loadAnimation()
		{
			for (int i = 132; i <= 301; i++)
			{
				menuAnim.Add((Image)RS.GetObject("MenuBoatScreen" + i));
			}
		}

	}
}
