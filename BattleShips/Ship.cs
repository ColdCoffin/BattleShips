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

	public struct ShipPart
	{
		public Point point;
		public bool isDestroyed;
	}
	public abstract class Ship
	{
		public readonly string ShipName;

		protected readonly PictureBox Hgraphics;
		protected readonly PictureBox Vgraphics;
		protected int Health;
		protected Point Location;
		protected ShipPart[] ShipParts;
		protected int ShipLength;



		public Ship(PictureBox Hgraphics, PictureBox Vgraphics, string name) 
		{
			ShipName = name;

			isSpawned = false;
			this.Hgraphics = Hgraphics;
			this.Vgraphics = Vgraphics;

			this.Hgraphics.Location = new Point(0, 0);
			this.Vgraphics.Location = new Point(0, 0);
			Location = new Point(0, 0);

			Hgraphics.Visible = false;
			Vgraphics.Visible = false;

			InitializePositions();
			SetHealth();
			SetLength();
			CalculatePositions("Vertical");
		}

		//Every inherited class MUST implement this!
		protected abstract void InitializePositions();
		protected abstract void SetHealth();
		protected abstract void SetLength();


		protected virtual void CalculatePositions(string orientation)
		{
			ShipParts[0].point = new Point(Location.X, Location.Y);

			for (int i = 1; i < ShipLength; i++)
			{
				if (orientation == "Horizontal")
					ShipParts[i].point = new Point(Location.X + (i * 30), Location.Y);

				if (orientation == "Vertical")
					ShipParts[i].point = new Point(Location.X, Location.Y + (i * 30));

			}
		}

		virtual public bool SpawnShip(Point pos, string orientation)
		{

			if (orientation == "Vertical" && pos.Y + (30 * ShipLength) > 240)
				return false;
			if (orientation == "Horizontal" && pos.X + (30 * ShipLength) > 270)
				return false;

			Location = pos;
			CalculatePositions(orientation);

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
			for (int i = 0; i < ShipLength; i++)
			{
				if (ShipParts[i].point == pos && ShipParts[i].isDestroyed == true)
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
