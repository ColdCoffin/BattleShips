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
		public Field field;
		public bool isDestroyed;
	}
	public abstract class Ship
	{
		public string ShipName;
		public bool isSpawned;

		protected readonly PictureBox Hgraphics;
		protected readonly PictureBox Vgraphics;
		protected int Health;
		protected Field Location;
		protected ShipPart[] ShipParts;
		protected int ShipLength;
		



		public Ship(PictureBox Hgraphics, PictureBox Vgraphics) 
		{
			isSpawned = false;
			this.Hgraphics = Hgraphics;
			this.Vgraphics = Vgraphics;

			this.Hgraphics.Location = new Point(0, 0);
			this.Vgraphics.Location = new Point(0, 0);

			Hgraphics.Visible = false;
			Vgraphics.Visible = false;

			InitializePositions();
			SetHealth();
			SetLength();
		}

		//Every inherited class MUST implement this!
		protected abstract void InitializePositions();
		protected abstract void SetHealth();
		protected abstract void SetLength();


		protected virtual void CalculatePositions(string orientation)
		{


			ShipParts[0].field = Location;
			int index = 0;
			for (int i = 1; i < ShipLength; i++)
			{

				if (orientation == "Horizontal")
				{
					ShipParts[i].field = PlayerField.AllFields[((Location.point.Y + index) / 30)
						 + (Location.point.X / 30) * 10];
					ShipParts[i].field.isTaken = true;
					ShipParts[i].isDestroyed = false;
				}

				if (orientation == "Vertical")
				{
					ShipParts[i].field = PlayerField.AllFields[((Location.point.Y / 30) * 10)
						 + ((Location.point.X + index) / 30)];
					ShipParts[i].field.isTaken = true;
					ShipParts[i].isDestroyed = false;
				}

					index += 30;
			}
		}

		virtual protected bool checkCollision(ref Field pos,string orientation)
		{
			if (orientation == "Vertical")
			{
				for (int i = pos.point.Y/30; i < ShipLength * 10; i += 10)
				{
					if (PlayerField.AllFields[i + pos.point.X / 30].isTaken == true)
						return false;
				}
			}

			if (orientation == "Horizontal")
			{
				for (int i = pos.point.X / 30; i < ShipLength * 10; i += 10)
				{
					if (PlayerField.AllFields[i + pos.point.Y / 30].isTaken == true)
						return false;
				}
			}

			return true;

		}

		virtual protected void FreePreviousPos()
		{

			for (int i = 0; i < ShipLength; i++)
			{
				ShipParts[i].field.isTaken = false;
			}

		}

		virtual public bool SpawnShip(ref Field pos, string orientation, 
			string name)
		{
			if (name != "")
				ShipName = name;

			if (checkCollision(ref pos,orientation) == false)
				return false;

			FreePreviousPos();

			Location.point = pos.point;
			CalculatePositions(orientation);

			if (orientation == "Vertical") 
				{
				Vgraphics.Location = Location.point;
				Vgraphics.Visible = true;
				}
			if (orientation == "Horizontal")
			{
				Hgraphics.Location = Location.point;
				Hgraphics.Visible = true;
			}

			isSpawned = true;
			return true;

		}

		virtual public bool isHit(Field pos)
		{
			for (int i = 0; i < ShipLength; i++)
			{
				if (ShipParts[i].field.point == pos.point && ShipParts[i].isDestroyed == false)
					return true;
			}

			return false;
		}

		virtual public void Hit(Field pos)
		{
			for (int i = 0; i < ShipLength; i++)
			{
				if (ShipParts[i].field.point == pos.point)
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
