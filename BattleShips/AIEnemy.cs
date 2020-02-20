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

		public AIEnemy(Ship f, Ship s, Ship g, Ship b, Ship p, bool isNormal)
		{
			enemyFishingBoat = (FishingBoat)f;
			enemySloop = (Sloop)s;
			enemyGalleon = (Galleon)g;
			enemyBrigantine = (Brigantine)b;
			enemyPiratesShip = (PiratesShip)p;

			normalMode = isNormal;

			rand = new Random();

			enemyShips = new List<Ship>
			{
				enemyFishingBoat,
				enemyGalleon,
				enemySloop,
				enemyPiratesShip,
				enemyBrigantine
			};

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

					string[] ori = { "Vertical", "Horizontal" };
					string orientation = ori[rand.Next(0, 2)];
					spawned = ship.SpawnShip(EnemyField.AllFields[rand.Next(0, 100)], orientation, true, "");

				} while (spawned == false);
			}

		}

		public Field FireAtPosition()
		{
	
			List<Field> freeFields = PlayerField.ListNotHitFields();
			Field fieldHit = freeFields[rand.Next(0, freeFields.Count)];
			return fieldHit;
					
		
		//TODO: Add better AI 



	}



	}
}
