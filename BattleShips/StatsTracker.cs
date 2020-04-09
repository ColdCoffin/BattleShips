using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShips
{
	public class StatsTracker
	{

		public int shipsDestroyed { get; set; }
		public int shipsHit { get; set; }
		public int shipsMissed { get; set; }
		float accuracy;
		public float Accuracy { get { calculateAccuracy(); return accuracy; } set { accuracy = value; } }


		public StatsTracker()
		{

			shipsDestroyed = 0;
			shipsHit = 0;
			shipsMissed = 0;
			accuracy = 0;

		}

		private void calculateAccuracy()
		{
			if (shipsHit == 0)
				accuracy = 0;
			else
				accuracy = (shipsHit / (shipsHit + shipsMissed)) * 100f;
			
		}

		public void ResetStats()
		{
			shipsDestroyed = 0;
			shipsHit = 0;
			shipsMissed = 0;
			Accuracy = 0;

		}

	}

	
}
