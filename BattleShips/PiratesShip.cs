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
		public PiratesShip(PictureBox Hgraphics, PictureBox Vgraphics,
			string name = "Sloop")
			: base(Hgraphics, Vgraphics, name) { }

		protected override void InitializePositions() => Positions = new Point[5];
		protected override void SetHealth() => Health = 50;

		protected override void SetLength() => ShipLength = 5;

	}
}
