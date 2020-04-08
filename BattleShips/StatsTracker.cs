using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShips
{
	class StatsTracker
	{

		public int shipsDestroyed { get; set; }
		public int shipsHit { get; set; }
		public int shipsMissed { get; set; }
		public float accuracy { get { calculateAccuracy(); return accuracy; } set { accuracy = value; } }


		public StatsTracker()
		{

			shipsDestroyed = 0;
			shipsHit = 0;
			shipsMissed = 0;
			accuracy = 0;

		}

		private void calculateAccuracy()
		{
			accuracy = (  shipsHit / (shipsHit + shipsMissed)) * 100f;
		}

		public void ResetStats()
		{
			shipsDestroyed = 0;
			shipsHit = 0;
			shipsMissed = 0;
			accuracy = 0;

		}

	}

	
}
