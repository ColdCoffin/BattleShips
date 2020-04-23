using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;
using BattleShips.Properties;

namespace BattleShips
{
	public partial class SetShip : UserControl
	{
		int animIndex = 0;

		PictureBox[] miniMap;

		readonly SetShip setShip;

		public SetShip SetShipInstance
		{
			get
			{
				return setShip;
			}
		}


		FishingBoat fishingBoat = new FishingBoat();
		Sloop sloop = new Sloop();
		Brigantine brigantine = new Brigantine();
		Galleon galleon = new Galleon();
		PiratesShip piratesShip = new PiratesShip();

		List<Ship> ships; 



		public SetShip()
		{
			InitializeComponent();

			miniMap = new PictureBox[100];
			setShip = this;
			ships = new List<Ship> { fishingBoat, sloop, brigantine, galleon, piratesShip };

			setMinimap();

			refreshMinimap();
			timer1.Start();
		}


		private void setMinimap()
		{
			char letter = 'A';
			MouseEventHandler Event = new MouseEventHandler(SelectAFieldClickEvnt);

			for (int i = 0; i < 100; i += 10, ++letter)
			{
				for (int j = 0; j < 10; j++)
				{
					double temp = i * 1.5;

					miniMap[i + j] = new PictureBox();
					Controls.Add(miniMap[i + j]);
					miniMap[i + j].Name = letter + (j + 1).ToString();
					miniMap[i + j].Parent = panel1;
					miniMap[i + j].Location = new Point(j * 15, (int)temp);
					miniMap[i + j].MouseClick += Event;
				}
			}
		}


		private void SettingShipText(string shipName)
		{

			int index = choseShip_combobox.Items.IndexOf(shipName);
			if (index == -1)
				return;

			choseShip_combobox.Items.RemoveAt(index);
			choseShip_combobox.Items.Insert(index, shipName + "(SETTING)");
			choseShip_combobox.Text = shipName + "(SETTING)";

		}

		private void SetShipText(string shipName)
		{

			int index = choseShip_combobox.Items.IndexOf(shipName + "(SETTING)");
			choseShip_combobox.Items.RemoveAt(index);
			choseShip_combobox.Items.Insert(index, shipName + "(SET)");

		}

		private void ClearSettingText(string shipName)
		{

			string shipCurrently = choseShip_combobox.Text;
			int index = choseShip_combobox.Items.IndexOf(shipName + "(SETTING)");
			choseShip_combobox.Items.RemoveAt(index);
			choseShip_combobox.Items.Insert(index, shipName);
			choseShip_combobox.Text = shipCurrently;


		}

		public void ClearSetText(string shipName)
		{
			int index = choseShip_combobox.Items.IndexOf(shipName + "(SET)");
			choseShip_combobox.Items.RemoveAt(index);
			choseShip_combobox.Items.Insert(index, shipName);
			choseShip_combobox.Text = shipName;
		}

		public void ClearAllSetText()
		{
			for (int i = 0; i < choseShip_combobox.Items.Count; i++)
			{
			choseShip_combobox.Items.RemoveAt(i);
			choseShip_combobox.Items.Insert(i, ships[i].ShipName);
			}	
		}


		private void timer1_Tick(object sender, EventArgs e)
		{
			if (animIndex == SetFireMenuAnim.menuAnim.Count())
				animIndex = 0;

			pictureBox1.Image = SetFireMenuAnim.menuAnim[animIndex++];
		}
		private void ActionButton_Click_1(object sender, EventArgs e)
		{
			bool ori;
			if (VericalOri_radiobutton.Checked == true)
				ori = true;
			else
				ori = false;

			foreach (Ship s in ships)
			{
				if (s.isSpawned == true)
				{

					string shipType;
					if (s.ShipName.EndsWith("(SET)") == true)
						shipType = s.ShipName.Substring(0, s.ShipName.Length - 5);
					else if (s.ShipName.EndsWith("(SETTING)") == true)
						shipType = s.ShipName.Substring(0, s.ShipName.Length - 9);
					else
						shipType = s.ShipName;

					
					SetShipText(shipType);
					s.DespawnShip();
	

					GameScreen.GameScreenInstance.SetShips(shipType, ChooseXPos_texbox.Text,
						ChooseYPos_texbox.Text, ChooseName_texbox.Text, ori);

					break;
				}
			}


			ChooseXPos_texbox.Text = "";
			ChooseYPos_texbox.Text = "";
			choseShip_combobox.Text = "";
			ChooseName_texbox.Text = "";

			refreshMinimap();

			ErrorLabel.Visible = false;

		}

		private void refreshMinimap()
		{
			for (int i = 0; i < 100; i += 10)
			{
				for (int j = 0; j < 10; j++)
				{
					miniMap[i + j].BringToFront();

					if (PlayerField.isShipTarget(new Point(j * 30, i * 3)) == true)
						miniMap[i + j].Image = Resources.Menu_redButton;
					else if (PlayerField.isSpawnReadyTarget(new Point(j * 30, i * 3)) == true)
						miniMap[i + j].Image = Resources.Menu_whiteButton;
					else
						miniMap[i + j].Image = Resources.Menu_greenButton;
				}
			}
		}

		private void SetShip_VisibleChanged_1(object sender, EventArgs e)
		{
			if (Visible == true)
			{
				timer1.Start();

				refreshMinimap();
			}

			if (Visible == false)
			{
				timer1.Stop();
			}
		}

		private void SelectAFieldClickEvnt(object sender, MouseEventArgs e)
		{
			ErrorLabel.Visible = false;

			choseShip_combobox.DropDownStyle = ComboBoxStyle.DropDown;

			foreach (Ship s in ships)
			{
				if (s.isSpawned == true)
					ClearSettingText(s.ShipName);
			}

			fishingBoat.DespawnShip();
			sloop.DespawnShip();
			brigantine.DespawnShip();
			galleon.DespawnShip();
			piratesShip.DespawnShip();

			refreshMinimap();

			PictureBox p = null;

			if (sender.GetType() == typeof(PictureBox))
				p = (PictureBox)sender;

			if (p == null)
				return;

			ChooseXPos_texbox.Text = p.Name.Substring(0, 1);
			ChooseYPos_texbox.Text = p.Name.Substring(1, p.Name.Length - 1);

			char hpos = ChooseXPos_texbox.Text[0];
			int vpos = int.Parse(ChooseYPos_texbox.Text);
			int index = ((hpos - 65) * 10) + vpos - 1;
			string ori;

			if (VericalOri_radiobutton.Checked == true)
				ori = "Vertical";
			else
				ori = "Horizontal";

			string shipType;

			if (choseShip_combobox.Text.EndsWith("(SETTING)") == true)
				shipType = choseShip_combobox.Text.Substring(0, choseShip_combobox.Text.Length - 9);
			else if (choseShip_combobox.Text.EndsWith("(SET)") == true)
				shipType = "Ship Spawned Already";
			else
				shipType = choseShip_combobox.Text;

			switch (shipType)
			{
				case "Fishing Boat":
					fishingBoat.PrepareToSpawnShip(PlayerField.AllFields[index], ori, "Fishing Boat");
					SettingShipText("Fishing Boat");
					break;
				case "Brigantine":
					brigantine.PrepareToSpawnShip(PlayerField.AllFields[index], ori, "Brigantine");
					SettingShipText("Brigantine");
					break;
				case "Sloop":
					sloop.PrepareToSpawnShip(PlayerField.AllFields[index], ori, "Sloop");
					SettingShipText("Sloop");
					break;
				case "Galleon":
					galleon.PrepareToSpawnShip(PlayerField.AllFields[index], ori, "Galleon");
					SettingShipText("Galleon");
					break;
				case "Pirate's ship":
					piratesShip.PrepareToSpawnShip(PlayerField.AllFields[index], ori, "Pirate's ship");
					SettingShipText("Pirate's ship");
					break;

				case "Ship Spawned Already":
					ErrorLabel.Visible = true;
					ErrorLabel.Text = "Remove spawned ship first!";
					break;
				default:
					ErrorLabel.Visible = true;
					ErrorLabel.Text = "No ship chosen!";
					break;
			}


			choseShip_combobox.DropDownStyle = ComboBoxStyle.DropDownList;

			refreshMinimap();


		}

		private void mainMenu_button_Click(object sender, EventArgs e)
		{
			if (choseShip_combobox.Text.EndsWith("(SETTING)") == false)
			{
				ErrorLabel.Visible = true;
				ErrorLabel.Text = "Chose ship that hasn't been spawned!";
				return;
			}

			ClearSettingText(choseShip_combobox.Text.Substring(0, choseShip_combobox.Text.Length - 9));

			fishingBoat.DespawnShip();
			sloop.DespawnShip();
			brigantine.DespawnShip();
			galleon.DespawnShip();
			piratesShip.DespawnShip();
			refreshMinimap();

			ErrorLabel.Visible = false;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.Visible = false;
			ErrorLabel.Visible = false;
			GameScreen.GameScreenInstance.CancelMenu();
		}

		private void button2_Click(object sender, EventArgs e)
		{

			foreach (Ship s in ships)
			{
				if (s.ShipName + "(SET)" == choseShip_combobox.Text )
				{
					GameScreen.GameScreenInstance.DespawnPlayerShip(s);
					ErrorLabel.Visible = false;
					break;
				}
				
				ErrorLabel.Visible = true;
				ErrorLabel.Text = "Chose ship that hasn't been set!";
			}

			refreshMinimap();
		}
	}
}
