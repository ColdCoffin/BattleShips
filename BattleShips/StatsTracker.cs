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


		public StatsTracker()
		{

			shipsDestroyed = 0;
			shipsHit = 0;
			shipsMissed = 0;

		}

		public float CalculateAccuracy()
		{
			if (shipsHit == 0)
				return 0;
			else
				return (shipsHit / (shipsHit + shipsMissed)) * 100f;
			
		}

		public void ResetStats()
		{
			shipsDestroyed = 0;
			shipsHit = 0;
			shipsMissed = 0;

		}

	}

	
}
