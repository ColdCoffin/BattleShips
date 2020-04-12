using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShips
{
	public class PlayerActionText
	{

		List<string> hitText = new List<string>()
		{
			"Yo-ho-ho, a good hit!",
			"Look at them seadogs drowning, hahah!",
			"What a hit, now take their booty!",
			"Aye'll bludgeon yee skirvey scallywags!",
			"Aye'll make yee walk thee plank!",
			"Aye'll be a shark bait when we sink you!",

			"Shiver me timbers, what a hit!",
			"Give no quarter Matey's!",
			"Aaaarrrrgggghhhh, keep it up!",
			"Splice the Mainbrac, good job!",
		};

		List<string> destroyedShipText = new List<string>()
		{
			"Ship destroyed! Get their treasure!",
			"Ya-ho-ho, they are sinking!",

		};

		Random rand;

		public PlayerActionText()
		{
			rand = new Random();
		}


		public string HitText()
		{

			return hitText[rand.Next(0, hitText.Count())];

		}

		public string DestroyedShipText()
		{

			return destroyedShipText[rand.Next(0, destroyedShipText.Count())];

		}
	}
}
