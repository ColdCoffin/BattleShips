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


		public AIEnemy(Ship f, Ship s, Ship g, Ship b, Ship p) 
		{
			enemyFishingBoat = (FishingBoat) f;
			enemySloop = (Sloop) s;
			enemyGalleon = (Galleon) g;
			enemyBrigantine = (Brigantine) b;
			enemyPiratesShip = (PiratesShip) p;
		}

	}
}
