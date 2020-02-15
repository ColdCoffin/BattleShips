using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace BattleShips
{
	class FishingBoat:Ship
	{

		public FishingBoat( PictureBox Hgraphics, PictureBox Vgraphics,
			string name = "Fishing Boat")
			: base(Hgraphics,Vgraphics,name) { }

		protected override void InitializePositions() => Positions = new Point[2];
		protected override void SetHealth() => Health = 20;

		protected override void SetLength()=> ShipLength = 2;


		protected override void CalculatePositions(string orientation)
		{
			Positions[0] = new Point(Location.X, Location.Y);

			for (int i = 1; i < ShipLength; i++)
			{
				if (orientation == "Horizontal")
					Positions[i] = new Point(Location.X + (i * 30), Location.Y);

				if (orientation == "Vertical")
					Positions[i] = new Point(Location.X, Location.Y + (i * 30));

			}
		}
	}
}
