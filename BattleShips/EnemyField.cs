﻿using System;
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

		static EnemyField() { AllFields = new Field[100]; }

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

		static public void Hit(Field pos)
		{
			for (int i = 0; i < 100; i++)
			{
				if (AllFields[i].point == pos.point)
				{
					AllFields[i].isHit = true;
				}

			}

		}

		static public List<Field> ListHitFields()
		{
			List<Field> Hitfields = new List<Field>();

			for (int i = 0; i < 100; i++)
			{
				if (AllFields[i].isHit == true)
					Hitfields.Add(AllFields[i]);
			}
			return Hitfields;
		}
	}

}

