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

		virtual protected bool checkCollision(Field[] f, string orientation)
		{
			if (orientation == "Vertical")
			{
				for (int i = Location.Y/30; i < 100; i += 10)
				{
					if (f[i + Location.X / 30].isTaken == true)
						return false;
				}
			}

			if (orientation == "Horizontal")
			{
				for (int i = Location.X / 30; i < 100; i += 10)
				{
					if (f[i + Location.Y / 30].isTaken == true)
						return false;
				}
			}

			return true;

		}

		virtual public bool SpawnShip(Field[] allFields,Field pos, string orientation)
		{

			if (checkCollision(allFields, orientation) == false)
				return false;

			Location = pos.point;
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

		virtual public bool isHit(Field pos)
		{
			for (int i = 0; i < ShipLength; i++)
			{
				if (ShipParts[i].point == pos.point)
					return true;
			}

			return false;
		}

		virtual public void Hit(Field pos)
		{
			for (int i = 0; i < ShipLength; i++)
			{
				if (ShipParts[i].point == pos.point)
					ShipParts[i].isDestroyed = true;
			}

			PictureBox debris = new PictureBox();
			debris.Image = Image.FromFile("E:\\Programming\\c# vsite projects\\" +
				"BatleShips game\\BattleShips\\BattleShips\\Art\\Destroyed_ship.png");

			debris.Location = pos.point;
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
