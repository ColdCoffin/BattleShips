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

		private List<Ship> enemyShips;
		private Random rand;

		public AIEnemy(Ship f, Ship s, Ship g, Ship b, Ship p) 
		{
			enemyFishingBoat = (FishingBoat) f;
			enemySloop = (Sloop) s;
			enemyGalleon = (Galleon) g;
			enemyBrigantine = (Brigantine) b;
			enemyPiratesShip = (PiratesShip) p;

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
					string[] ori = { "Vertical","Horizontal"};
					string orientation = ori[rand.Next(0, 2)];
					spawned = ship.SpawnShip(EnemyField.AllFields[rand.Next(0,101)], orientation, true,"");
				} while (spawned==false);
			}

		}

	}
}
