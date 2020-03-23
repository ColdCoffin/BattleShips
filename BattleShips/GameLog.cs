using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleShips
{
	public class GameLog
	{
		Label label;
		List<string> allText;

		int textStartIndex, textLastIndex;
		public GameLog(Label label)
		{

			this.label = label;
			allText = new List<string>();
			textStartIndex = 0;
			textLastIndex = -1;
		}

		public void Write(string txt)
		{

			allText.Add(txt);
			textLastIndex++;

			if (textStartIndex + textLastIndex >= 8)
			{
				textStartIndex++;

				label.Text = "";

				for (int i = textStartIndex; i <= textLastIndex; i++)
				{
					label.Text += '\n' + allText[i] + '\n';
				}
			}
			else 
				label.Text += '\n' + txt + '\n';

		}

		public void Reset()
		{

			allText.Clear();
			label.Text = "";

		}


	}
}
