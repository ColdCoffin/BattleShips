﻿using System;
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
		protected string orientation;
		protected bool isEnemy;


		public Ship(PictureBox Hgraphics = null, PictureBox Vgraphics = null) 
		{
			isSpawned = false;

			if (Hgraphics != null || Vgraphics != null)
			{
				this.Hgraphics = Hgraphics;
				this.Vgraphics = Vgraphics;

				this.Hgraphics.Location = new Point(0, 0);
				this.Vgraphics.Location = new Point(0, 0);

				Hgraphics.Visible = false;
				Vgraphics.Visible = false;
			}
			

			InitializePositions();
			SetHealth();
			SetLength();
		}

		//Every inherited class MUST implement this!
		protected abstract void InitializePositions();
		protected abstract void SetHealth();
		protected abstract void SetLength();


		protected virtual void CalculatePositions()
		{

			int index = (Location.point.X / 30) + ((Location.point.Y / 30) * 10);
			int indexAdd = 0;

			for (int i = 0; i < ShipLength; i++)
			{

				if (orientation == "Horizontal")
				{
					if (isEnemy == false)
					{
						if (prepareToSpawn == true)
							PlayerField.AllFields[index + i].isSpawnReady = true;
						else
							PlayerField.AllFields[index + i].isTaken = true;
						
						ShipParts[i].field = PlayerField.AllFields[index + i];
						ShipParts[i].isDestroyed = false;
					}
					else
					{
						ShipParts[i].field = EnemyField.AllFields[index + i];
						EnemyField.AllFields[index + i].isTaken = true;
						ShipParts[i].isDestroyed = false;
					}
					}

				if (orientation == "Vertical")
				{
					if (isEnemy == false)
					{
						if (prepareToSpawn == true)
							PlayerField.AllFields[index + indexAdd].isSpawnReady = true;
						else
							PlayerField.AllFields[index + indexAdd].isTaken = true;

						ShipParts[i].field = PlayerField.AllFields[index + indexAdd];
						ShipParts[i].isDestroyed = false;
					}
					else
					{
						ShipParts[i].field = EnemyField.AllFields[index + indexAdd];
						EnemyField.AllFields[index + indexAdd].isTaken = true;
						ShipParts[i].isDestroyed = false;

					}
				}

				indexAdd += 10;
			}
		}

		virtual protected bool checkCollision(Field pos)
		{
			int index = (pos.point.X / 30) + ((pos.point.Y / 30) * 10);
			int indexAdd = 0;

			for (int i = 0; i < ShipLength; i++)
			{

				if (orientation == "Horizontal")
				{
					if (isEnemy == false)
					{
						if (PlayerField.AllFields[index + i].isTaken == true)
							return false;
					}
					else
					{
						if (EnemyField.AllFields[index + i].isTaken == true)
							return false;
					}
				}


				if (orientation == "Vertical")
				{
					if (isEnemy == false)
					{
						if (PlayerField.AllFields[index + indexAdd].isTaken == true)
							return false;
					}
					else
					{
						if (EnemyField.AllFields[index + indexAdd].isTaken == true)
							return false;
					}
				}

				indexAdd += 10;
				
			}
			return true;
		}

		virtual public void DespawnShip()
		{
			if (isSpawned == false)
				return;

			int index = (Location.point.X / 30) + ((Location.point.Y / 30) * 10);
			int indexAdd = 0;

			for (int i = 0; i < ShipLength; i++)
			{

				if (orientation == "Horizontal")
				{
					if (isEnemy == false)
					{
						PlayerField.AllFields[index + i].isTaken = false;
						PlayerField.AllFields[index + i].isSpawnReady = false;
					}
					else
						EnemyField.AllFields[index + i].isTaken = false;
				}
				if (orientation == "Vertical")
				{
					if (isEnemy == false)
					{
						PlayerField.AllFields[index + indexAdd].isTaken = false;
						PlayerField.AllFields[index + indexAdd].isSpawnReady = false;
					}
					else
						EnemyField.AllFields[index + indexAdd].isTaken = false;
				}
				indexAdd += 10;
			}

			if (Vgraphics != null || Hgraphics != null)
			{
				Vgraphics.Visible = false;
				Hgraphics.Visible = false;
			}
			
			isSpawned = false;
		}

		virtual protected bool checkBorders(Field pos)
		{
			if (orientation == "Horizontal")
				if (pos.point.X + ((ShipLength - 1) * 30) > 270)
					return false;

			if (orientation == "Vertical")
				if (pos.point.Y + ((ShipLength - 1) * 30) > 270)
					return false;

			return true;


		}
		bool prepareToSpawn;
		virtual public bool PrepareToSpawnShip(Field pos, string orientation, string shipType)
		{
			if (isSpawned == true)
				DespawnShip();

			ShipName = shipType;

			prepareToSpawn = true;

			SetHealth();

			this.orientation = orientation;

			if (checkBorders(pos) == false)
				return false;

			if (checkCollision(pos) == false)
				return false;

			Location.point = pos.point;
			CalculatePositions();

			isSpawned = true;
			return true;

		}

		virtual public bool SpawnShip(Field pos, string orientation, bool isEnemy,
			string name)
		{
			if (isSpawned == true)
				DespawnShip();

			Vgraphics.Visible = false;
			Hgraphics.Visible = false;

			SetHealth();

			if (name != "")
				ShipName = name;

			this.isEnemy = isEnemy;

			this.orientation = orientation;

			if (checkBorders(pos) == false)
				return false;

			if (checkCollision(pos) == false)
				return false;

			Location.point = pos.point;
			CalculatePositions();

			Vgraphics.Location = Location.point;
			Vgraphics.BringToFront();
			Hgraphics.Location = Location.point;
			Hgraphics.BringToFront();

			if (isEnemy == false)
				ShowBoat();

			isSpawned = true;
			return true;

		}

		public virtual void ShowBoat()
		{
			if (orientation == "Vertical")
			{
				Vgraphics.Visible = true;
			}
			if (orientation == "Horizontal")
			{
				Hgraphics.Visible = true;
			}

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
				{
					ShipParts[i].isDestroyed = true;
					if (isEnemy == true)
						EnemyField.Hit(pos);
					else
						PlayerField.Hit(pos);
				}

			}
			Health -= 10;

			
		}

		virtual public int getHealth()
		{
			return Health;
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
