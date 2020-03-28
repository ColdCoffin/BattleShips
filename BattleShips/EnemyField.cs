using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace BattleShips
{
	public static class EnemyField
	{

		public static Field[] AllFields;
		private static List<Field> hitFields;

		static EnemyField()
		{
			AllFields = new Field[100];
			hitFields = new List<Field>();
		}


		static public void LoadFields()
		{
			for (int i = 0; i < 100; i += 10)
			{
				for (int j = 0; j < 10; j++)
				{
					AllFields[i + j] = new Field(new Point(j * 30, i * 3));
				}
			}
		}

		static public void ResetFields()
		{
			for (int i = 0; i < 100; i++)
			{
				AllFields[i].isHit = false;
				AllFields[i].isTaken = false;
				
			}

			hitFields.Clear();
		}

		static public void Hit(Field pos)
		{
			for (int i = 0; i < 100; i++)
			{
				if (AllFields[i].point == pos.point)
				{
					AllFields[i].isHit = true;
					hitFields.Add(pos);
				}

			}

		}

		static public bool isShipTarget(Point pos)
		{
			for (int i = 0; i < 100; i++)
			{
				if (AllFields[i].point == pos)
				{
					if (AllFields[i].isTaken == true)
						return true;
				}
			}

			return false;
		}

		static public bool isAlreadyHit(Point pos)
		{


			foreach (Field f in hitFields)
			{
				if (f.point == pos)
					return true;
			}
			return false;
		}
	}

}

