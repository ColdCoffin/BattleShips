using BattleShips.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace BattleShips
{
	public static class SetFireMenuAnim
	{

		public static List<Image> menuAnim;
		static ResourceManager RS;
		static SetFireMenuAnim()
		{
			RS = new ResourceManager("BattleShips.Properties.Resources", typeof(Resources).Assembly);
			menuAnim = new List<Image>();

			for (int i = 132; i <= 301; i++)
			{
				menuAnim.Add((Image)RS.GetObject("MenuBoatScreen" + i));
			}
		}

	}
}
