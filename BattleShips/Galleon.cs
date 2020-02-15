using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace BattleShips
{
	class Galleon : Ship
	{
		public Galleon(PictureBox Hgraphics, PictureBox Vgraphics,
			string name = "Galleon")
			: base(Hgraphics, Vgraphics, name) { }

		protected override void InitializePositions() => Positions = new Point[4];
		protected override void SetHealth() => Health = 40;

		protected override void SetLength() => ShipLength = 4;

	}
}
