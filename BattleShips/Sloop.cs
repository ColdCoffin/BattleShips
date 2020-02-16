using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace BattleShips
{
	class Sloop : Ship
	{
		public Sloop(PictureBox Hgraphics, PictureBox Vgraphics)
			: base(Hgraphics, Vgraphics) { ShipName = "Sloop"; }

		protected override void InitializePositions() => ShipParts = new ShipPart[3];
		protected override void SetHealth() => Health = 30;

		protected override void SetLength() => ShipLength = 3;	

	}
}
