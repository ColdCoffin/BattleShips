using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace BattleShips
{
	class PiratesShip : Ship
	{
		public PiratesShip(PictureBox Hgraphics, PictureBox Vgraphics)
			: base(Hgraphics, Vgraphics) { ShipName = "Pirate's Ship"; OriginalShipName = "PiratesShip"; }


		protected override void InitializePositions() => ShipParts = new ShipPart[5];
		protected override void SetHealth() => Health = 50;

		protected override void SetLength() => ShipLength = 5;

	}
}
