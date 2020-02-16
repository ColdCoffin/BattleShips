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
	public class PlayingField
	{

		private Field[] AllFields;

		public PlayingField()
		{
			AllFields = new Field[100];
		}

		public void LoadFields()
		{
			for (int i = 0; i < 10; i++)
			{
				for (int j = 0; j < 10; j++)
				{
					AllFields[i + j] = new Field(new Point(i * 30, j * 30));
				}
			}
		}

		public void MarkAsTaken(Point pos)
		{
			for (int i = 0; i < 100; i++)
			{
				if (AllFields[i].point == pos)
					AllFields[i].isTaken = true;
			}
		}

		public void MarkAsFree(Point pos)
		{
			for (int i = 0; i < 100; i++)
			{
				if (AllFields[i].point == pos)
					AllFields[i].isTaken = false;
				
			}
		}

		public void Hit(Point pos)
		{
			for (int i = 0; i < 100; i++)
			{
				if (AllFields[i].point == pos)
					AllFields[i].isHit = true;
				
			}

		}

		public Field[] ListHitFields()
		{
			Field[] hitfields = new Field[100];

			for (int i = 0; i < 100; i++)
			{
				if (AllFields[i].isHit == true)
					hitfields[i] = AllFields[i];
			}
			return hitfields;
		}
	}
}
