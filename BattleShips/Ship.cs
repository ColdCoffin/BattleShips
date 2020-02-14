using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;

namespace BattleShips
{
	abstract class Ship
	{
		public readonly string ShipName;

		protected readonly PictureBox Hgraphics;
		protected readonly PictureBox Vgraphics;
		protected int Health;
		protected Point Location;
		protected Point[] Positions;
		protected int ShipLength;


		Ship(PictureBox Hgraphics, PictureBox Vgraphics) 
		{
			this.Hgraphics = Hgraphics;
			this.Vgraphics = Vgraphics;

			this.Hgraphics.Location = new Point(0, 0);
			this.Vgraphics.Location = new Point(0, 0);
			Location = new Point(0, 0);

			Hgraphics.Visible = false;
			Vgraphics.Visible = false;

			CalculatePositions();
		}

		//Every inherited class MUST implement this!
		public abstract void CalculatePositions();

		virtual public bool SpawnShip(Point pos, string orientation)
		{

			if (orientation == "Vertical" && pos.Y + (30 * ShipLength) > 240)
				return false;
			if (orientation == "Horizontal" && pos.X + (30 * ShipLength) > 270)
				return false;

			Location = pos;
			CalculatePositions();

			if (orientation == "Vertical") 
				{
				Vgraphics.Location = Location;
				Vgraphics.Visible = true;
				}
			if (orientation == "Horizontal")
			{
				Hgraphics.Location = Location;
				Hgraphics.Visible = true;
			}

			return true;

		}

		virtual public bool isHit(Point pos)
		{
			foreach (Point location in Positions)
			{
				if (pos == location)
					return true;
			}

			return false;
		}

		virtual public void Hit(Point pos)
		{
			PictureBox debris = new PictureBox();
			debris.Image = Image.FromFile("E:\\Programming\\c# vsite projects\\" +
				"BatleShips game\\BattleShips\\BattleShips\\Art\\Destroyed_ship.png");

			debris.Location = pos;
			debris.BringToFront();
			Health -= 1;
		}

		virtual public bool isDestroyed()
		{
			if (Health == 0)
				return true;
			else
				return false;
		}

	}
}
