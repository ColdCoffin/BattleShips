using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace BattleShips
{
	public class AIEnemy
	{
		private FishingBoat enemyFishingBoat;
		private Sloop enemySloop;
		private Galleon enemyGalleon;
		private Brigantine enemyBrigantine;
		private PiratesShip enemyPiratesShip;

		private bool normalMode;

		private List<Ship> enemyShips;
		private Random rand;



		Field fieldHit;

		public bool IsHit
		{
			set
			{
				if (value == true && searchmodeActivated == false)
				{
					searchmodeActivated = true;
					startSearchPoint = fieldHit;
				}
			}
		}
		

		private string[] Orientation = { "Vertical", "Horizontal" };
		private List<string> Direction;

		Field startSearchPoint;

		private bool searchmodeActivated;
		private bool checkedUp;
		static int offsetUp;
		private bool checkedDown;
		static int offsetDown;
		private bool checkedRight;
		static int offsetRight;
		private bool checkedLeft;
		static int offsetLeft;

		private bool DirisSet;
		string dir;


		public AIEnemy(Ship f, Ship s, Ship g, Ship b, Ship p, bool isNormal)
		{
			enemyFishingBoat = (FishingBoat)f;
			enemySloop = (Sloop)s;
			enemyGalleon = (Galleon)g;
			enemyBrigantine = (Brigantine)b;
			enemyPiratesShip = (PiratesShip)p;

			normalMode = isNormal;

			rand = new Random();

			resetOffset();

			enemyShips = new List<Ship>
			{
				enemyFishingBoat,
				enemyGalleon,
				enemySloop,
				enemyPiratesShip,
				enemyBrigantine
			};

		Direction = new List<string>
		{ "Up", "Down", "Left", "Right" };

		DirisSet = false;

			checkedDown = false;
			checkedUp = false;
			checkedLeft = false;
			checkedRight = false;

		}
		public void SpawnShips()
		{
			bool spawned;

			foreach (Ship ship in enemyShips)
			{
				do
				{
					if (ship.isSpawned == true)
						break;

					spawned = ship.SpawnShip(EnemyField.AllFields[rand.Next(0, 100)],
						Orientation[rand.Next(0, 2)], true, "");

				} while (spawned == false);
			}

		}

		private bool GetFirePoint(string dir, int offset)
		{

			if (dir == "Up" || dir == "Down")
				{
					Field temp = new Field();
					temp.point.Y = startSearchPoint.point.Y + offset;
					temp.point.X = startSearchPoint.point.X;
					fieldHit = temp;

				if (dir == "Up")
					offsetUp += -30;
				else
					offsetDown += 30;
				}


			if (dir == "Left" || dir == "Right")
				{
					Field temp = new Field();
					temp.point.X = startSearchPoint.point.X + offset;
					temp.point.Y = startSearchPoint.point.Y;

					fieldHit = temp;

					if (dir == "Left")
						offsetLeft += -30;
					else
						offsetRight += 30;


				}


			if (PlayerField.isShipTarget(fieldHit) == true && PlayerField.isAlreadyHit(fieldHit) == false)
				return true;
			else
				return false;

		}

		private Field chooseRandomFreeField()
			{
			do
			{
				fieldHit = PlayerField.AllFields[rand.Next(0, 100)];
			} while (PlayerField.isAlreadyHit(fieldHit) == true);

			return fieldHit;

		}

		private void searchModeOff()
		{
			searchmodeActivated = false;
			DirisSet = false;
			resetOffset();
			resetDir();
		}

		private void resetDir()
		{
			Direction.Add("Up");
			Direction.Add("Down");
			Direction.Add("Left");
			Direction.Add("Right");
		}

		private void resetOffset()
		{
		 offsetUp = -30;
		 offsetDown = 30;
		 offsetRight = 30;
		 offsetLeft = -30;
	}
		public Field FireAtPosition()
		{

			if (normalMode == true)
			{
				

				if (searchmodeActivated == true)
				{

					if (Direction.Count == 0)
					{
						searchModeOff();
						chooseRandomFreeField();
						return fieldHit;
					}

					if (DirisSet == false)
					{
						int index = rand.Next(0, Direction.Count);
						dir = Direction[index];
						DirisSet = true;
					}

					
					{
						switch (dir)
						{
							case "Up":
								if (GetFirePoint(dir, offsetUp) == false)
								{

									Direction.Remove("Up");
									checkedUp = true;
									DirisSet = false;


									if (checkedDown == false)
									{
										dir = "Down";
										DirisSet = true;
									}

									
								}
								else
								{
									dir = "Up";
									DirisSet = true;
									Direction.Remove("Left");
									Direction.Remove("Right");
								}
								if (PlayerField.isOutOfBounds(fieldHit) == true)
								{
									if (checkedDown == true)
									{
										searchModeOff();
										chooseRandomFreeField();
										return fieldHit;
									}
									goto case "Down";
								}
									
								else
									return fieldHit;

							case "Down":
								if (GetFirePoint(dir, offsetDown) == false)
								{
									Direction.Remove("Down");
									checkedDown = true;
									DirisSet = false;

									if (checkedUp == false)
									{
										dir = "Up";
										DirisSet = true;
									}

									
								}
								else
								{
									dir = "Down";
									DirisSet = true;
									Direction.Remove("Left");
									Direction.Remove("Right");

								}
								if (PlayerField.isOutOfBounds(fieldHit) == true)
								{
									if (checkedUp == true)
									{
										searchModeOff();
										chooseRandomFreeField();
										return fieldHit;
									}
									goto case "Left";
								}
								else
									return fieldHit;

							case "Left":
								if (GetFirePoint(dir, offsetLeft) == false)
								{

									Direction.Remove("Left");
									checkedLeft = true;
									DirisSet = false;

									if (checkedRight == false)
									{
										dir = "Right";
										DirisSet = true;
									}

									
								}
								else
								{
									dir = "Left";
									DirisSet = true;
									Direction.Remove("Up");
									Direction.Remove("Down");
								}
								if (PlayerField.isOutOfBounds(fieldHit) == true)
									{
										if (checkedRight == true)
										{
										searchModeOff();
											chooseRandomFreeField();
											return fieldHit;
										}
										goto case "Right";
									}
									else
										return fieldHit;

							case "Right":
								if (GetFirePoint(dir, offsetRight) == false)
								{


									Direction.Remove("Right");
									checkedRight = true;
									DirisSet = false;

									if (checkedLeft == false)
									{
										dir = "Left";
										DirisSet = true;
									}

								}
								else
								{
									dir = "Right";
									DirisSet = true;
									Direction.Remove("Up");
									Direction.Remove("Down");

								}
								if (PlayerField.isOutOfBounds(fieldHit) == true)
								{
									if (checkedLeft == true)
									{
										searchModeOff();
										chooseRandomFreeField();
										return fieldHit;
									}
									goto case "Up";
								}
								else
									return fieldHit;
							default:
								searchModeOff();
								chooseRandomFreeField();
								return fieldHit;
						}
					}

				}
				

			}

			chooseRandomFreeField();
			return fieldHit;


	}



	}
}
