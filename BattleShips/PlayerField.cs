using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace BattleShips
{
	public struct Field
	{
		public Field(Point p) { point = p; isTaken = false; isHit = false; }

		public Point point;
		public bool isTaken;
		public bool isHit;
	}

	public static class PlayerField
	{

		public static Field[] AllFields;
		private static List<Field> hitfields;

		static PlayerField()
			{ 
			AllFields  = new Field[100];
			hitfields = new List<Field>();
			}

		static public void LoadFields()
		{
			for (int i = 0; i < 100; i+=10)
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
		}


		static public void Hit(Field pos)
		{
			for (int i = 0; i < 100; i++)
			{
				if (AllFields[i].point == pos.point)
				{
					AllFields[i].isHit = true;
					hitfields.Add(pos);
				}
			}

		}

		static public bool isShipTarget(Field pos)
		{
			for (int i = 0; i < 100; i++)
			{
				if (AllFields[i].point == pos.point)
				{
					if (AllFields[i].isTaken == true)
						return true;
				}
			}

			return false;
		}

		static public bool isAlreadyHit(Field pos)
		{


			foreach (Field f in hitfields)
			{
				if (f.point == pos.point)
					return true;
			}
			return false;
		}

		static public bool isOutOfBounds(Field pos)
		{

			foreach (Field f in AllFields)
			{
				if (f.point == pos.point)
					return false;
			}

			return true;
		}
	}

}

