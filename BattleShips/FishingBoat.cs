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

		protected override void InitializePositions() => ShipParts = new ShipPart[2];
		protected override void SetHealth() => Health = 20;

		protected override void SetLength()=> ShipLength = 2;

	}
}
