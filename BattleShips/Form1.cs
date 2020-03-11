using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace BattleShips
{
	public partial class GameScreen : Form
	{
		FishingBoat playerFishingBoat;
		FishingBoat enemyFishingBoat;

		Sloop playerSloop;
		Sloop enemySloop;

		Galleon playerGalleon;
		Galleon enemyGalleon;

		Brigantine playerBrigantine;
		Brigantine enemyBrigantine;

		PiratesShip playerPiratesShip;
		PiratesShip enemyPiratesShip;

		List<Ship> PlayerShips;
		List<Ship> EnemyShips;

		int destroyedPlayerShips;
		int destroyedEnemyShips;
		Random rand;

		AIEnemy AI;
		SoundPlayer sound;

		string[] tileIndex;

		MenuScreen menuScreen;


		public GameScreen(MenuScreen menuScreen)
		{
			InitializeComponent();

			this.menuScreen = menuScreen;

			EnemyField_label_A.Parent = pictureBox1;
			EnemyField_label_A.Location = pictureBox1.Location;
			EnemyField_label_A.BringToFront();

			tileIndex = new string[3];
			tileIndex[0] = "woodtile_clean.png";
			tileIndex[1] = "woodtile_halfdirty.png";
			tileIndex[2] = "woodtile_dirty.png";

			rand = new Random();

			loadBackround();

			PlayerField.LoadFields();
			EnemyField.LoadFields();

			sound = new SoundPlayer();
			sound.SoundLocation = "E:\\Programming\\c# vsite projects\\" +
					"BatleShips game\\BattleShips\\BattleShips\\Art\\soundscrate-last-one-standing-sc1.wav";
			sound.PlayLooping();

			playerFishingBoat = new FishingBoat(FishingBoat_horizontal_player,
				FishingBoat_vertical_player);
			enemyFishingBoat = new FishingBoat(FishingBoat_horizontal_enemy,
				FishingBoat_vertical_enemy);

			playerSloop = new Sloop(Sloop_horizontal_player,
				Sloop_vertical_player);
			enemySloop = new Sloop(Sloop_horizontal_enemy,
				Sloop_vertical_enemy);

			playerGalleon = new Galleon(Galleon_horizontal_player,
				Galleon_vertical_player);
			enemyGalleon = new Galleon(Galleon_horizontal_enemy,
				Galleon_vertical_enemy);

			playerBrigantine = new Brigantine(Brigantine_horizontal_player,
				Brigantine_vertical_player);
			enemyBrigantine = new Brigantine(Brigantine_horizontal_enemy,
				Brigantine_vertical_enemy);

			playerPiratesShip = new PiratesShip(PiratesShip_horizontal_player,
				 PiratesShip_vertical_player);
			enemyPiratesShip = new PiratesShip(PiratesShip_horizontal_enemy,
				PiratesShip_vertical_enemy);

			destroyedPlayerShips = 0;
			destroyedEnemyShips = 0;


			FireButton.Enabled = false;
			LetterboxText.Enabled = false;
			NumberboxText.Enabled = false;
			ActionButton.Enabled = false;

			RemovePiratesShip_button.Visible = false;
			RemoveSloop_button.Visible = false;
			RemoveGalleon_button.Visible = false;
			RemoveFishingBoat_button.Visible = false;
			RemoveBrigantine_button.Visible = false;

			PlayerShips = new List<Ship>
			{
				playerFishingBoat,
				playerGalleon,
				playerSloop,
				playerPiratesShip,
				playerBrigantine
			};

			EnemyShips = new List<Ship>
			{
				enemyFishingBoat,
				enemyGalleon,
				enemySloop,
				enemyPiratesShip,
				enemyBrigantine
			};

			AI = new AIEnemy(enemyFishingBoat, enemySloop,
									enemyGalleon, enemyBrigantine, enemyPiratesShip, menuScreen.isHard);
			AI.SpawnShips();

		
		}
		
		private void loadBackround()
		{

			for (int i = 0; i < 23; i++)
			{
				for (int j = 0; j < 40; j++)
				{
					string tile = tileIndex[rand.Next(0,2)];
					PictureBox p = new PictureBox();
					p.Size = new Size(new Point(32, 32));
					p.Location = new Point(32*j,32*i);
					p.Image = Image.FromFile("E:\\Programming\\c# vsite projects\\" +
					"BatleShips game\\BattleShips\\BattleShips\\Art\\"+ tile);
					Controls.Add(p);
				}
			}

		}

		private void FireButton_Click(object sender, EventArgs e)
		{

			String letter = LetterboxText.Text;
			String number = NumberboxText.Text;
			String s = "EnemyField_" + letter + number;

			PictureBox pic = Controls.Find(s, true).FirstOrDefault() as PictureBox;

			if (pic == null)
			{
				ActionText.Text = "Bad coordinaates mate!";
				return;
			}

			Point fireAt =  pic.Location;


			if (EnemyField.isAlreadyHit(new Field(fireAt)) == true)
			{
					ActionText.Text = "Already fired there!";
					return;
			}

			

			EnemyField.Hit(new Field(fireAt));
			bool wasHit = false;

			foreach (Ship enemyShip in EnemyShips)
			{
				if (enemyShip.isHit(new Field(fireAt)) == true)
				{
					wasHit = true;
					enemyShip.Hit(new Field(fireAt));
					break;
				}
			}
			if (wasHit == true)
				pic.Image = Image.FromFile("E:\\Programming\\c# vsite projects\\" +
					"BatleShips game\\BattleShips\\BattleShips\\Art\\Destroyed_ship.png");
			else
				pic.Image = Image.FromFile("E:\\Programming\\c# vsite projects\\" +
					"BatleShips game\\BattleShips\\BattleShips\\Art\\HitArea.png");

			pic.BringToFront();

			ActionText.Text = "Firing at " + (char) ((fireAt.Y / 30 ) + 'A')+ ((fireAt.X / 30) + 1);



			SetHealth();
			SetNumOfDestroyedShips();
			GameOver();

			LetterboxText.Enabled = false;
			NumberboxText.Enabled = false;
			FireButton.Enabled = false;

			ActionButton.Enabled = true;
		}

		

		private void SetShipsButton_Click(object sender, EventArgs e)
		{

			if (SetHorizontalPosText.TextLength == 0 || SetHorizontalPosText.Text[0] < 'A' 
				|| SetHorizontalPosText.Text[0] > 'J' || SetVerticalPosText.TextLength == 0)
			{
				ErrorDialogLabel.Text = "Bad coordinates";
				return;
			}

			char hpos = SetHorizontalPosText.Text[0];
			SetHorizontalPosText.Text = string.Empty;

			

			int vpos = int.Parse(SetVerticalPosText.Text) - 1;
			SetVerticalPosText.Text = string.Empty;

			if (vpos < 0 || vpos > 9)
			{
				ErrorDialogLabel.Text = "Bad coordinates";
				return;
			}

			string sname = ShipName_texbox.Text;
			ShipName_texbox.Text = string.Empty;

			int index = ((hpos - 65) * 10) + vpos;

			string ship = ChooseShipComboBox.Text;
			string orientation;

			if (VerticalOption.Checked == true)
				orientation = "Vertical";
			else
				orientation = "Horizontal";

			switch (ship)
			{
				case "Fishing Boat":
					if (
					playerFishingBoat.SpawnShip(PlayerField.AllFields[index], orientation,false, sname) == false)
					{
						ErrorDialogLabel.Text = "Can't place your boat there";
						break;
					}
					FishingBoat_icon.Visible = true;
					FishingBoat_nameText.Text = playerFishingBoat.ShipName;
					FishingBoat_nameText.Visible = true;
					FishingBoat_progressBar.Visible = true;
					RemoveFishingBoat_button.Visible = true;
					break;
				case "Brigantine":
					if (
					playerBrigantine.SpawnShip(PlayerField.AllFields[index], orientation,false, sname) == false)
					{
						ErrorDialogLabel.Text = "Can't place your boat there";
						break;
					}
					Brigantine_icon.Visible = true;
					Brigantine_nameText.Text = playerBrigantine.ShipName;
					Brigantine_nameText.Visible = true;
					Brigantine_progressBar.Visible = true;
					RemoveBrigantine_button.Visible = true;
					break;
				case "Sloop":
					if (
					playerSloop.SpawnShip(PlayerField.AllFields[index], orientation,false, sname) == false)
					{
						ErrorDialogLabel.Text = "Can't place your boat there";
						break;
					}
					Sloop_icon.Visible = true;
					Sloop_nameText.Text = playerSloop.ShipName;
					Sloop_nameText.Visible = true;
					Sloop_progressBar.Visible = true;
					RemoveSloop_button.Visible = true;
					break;
				case "Galleon":
					if (
					playerGalleon.SpawnShip(PlayerField.AllFields[index], orientation,false, sname) == false)
					{
						ErrorDialogLabel.Text = "Can't place your boat there";
						break;
					}
					Galleon_icon.Visible = true;
					Galleon_nameText.Text = playerGalleon.ShipName;
					Galleon_nameText.Visible = true;
					Galleon_progressBar.Visible = true;
					RemoveGalleon_button.Visible = true;
					break;
				case "Pirate's ship":
					if (
					playerPiratesShip.SpawnShip(PlayerField.AllFields[index], orientation,false, sname) == false)
					{
						ErrorDialogLabel.Text = "Can't place your boat there";
						break;
					}
					PiratesShip_icon.Visible = true;
					PiratesShip_nameText.Text = playerPiratesShip.ShipName;
					PiratesShip_nameText.Visible = true;
					PiratesShip_progressBar.Visible = true;
					RemovePiratesShip_button.Visible = true;
					break;

				default:
					ErrorDialogLabel.Text = "No such ship exists!";
					break;
			}

			foreach (Ship s in PlayerShips)
			{
				if (s.isSpawned == true)
					ActionButton.Enabled = true;
				else
				{
					ActionButton.Enabled = false;
					break;
				}
			}

		}

		private void SetHealth()
		{
			FishingBoat_progressBar.Value = playerFishingBoat.getHealth();
			Brigantine_progressBar.Value = playerBrigantine.getHealth();
			Sloop_progressBar.Value = playerSloop.getHealth();
			Galleon_progressBar.Value = playerGalleon.getHealth();
			PiratesShip_progressBar.Value = playerPiratesShip.getHealth();
		}

		private void SetNumOfDestroyedShips()
		{
			destroyedPlayerShips = 0;
			destroyedEnemyShips = 0;

			foreach (Ship playership in PlayerShips)
			{
				if (playership.isDestroyed() == true)
					destroyedPlayerShips++;
			}

			foreach (Ship enemyship in EnemyShips)
			{
				if (enemyship.isDestroyed() == true)
					destroyedEnemyShips++;
			}
		}

		private void GameOver()
		{
			if (destroyedPlayerShips == 5)
				MessageBox.Show("Game over, you lost!");

			if ( destroyedEnemyShips == 5)
				MessageBox.Show("Game over, you won!");
		}

		private void ActionButton_Click(object sender, EventArgs e)
		{
			ActionButton.Enabled = false;
			SetShipsButton.Enabled = false;
			FireButton.Enabled = false;
			RemovePiratesShip_button.Visible = false;
			RemoveBrigantine_button.Visible = false;
			RemoveFishingBoat_button.Visible = false;
			RemoveGalleon_button.Visible = false;
			RemoveSloop_button.Visible = false;

			ActionText.Text = "Enemy is preparing to fire!";

			AITimer.Start();

		}

		private void SetHorizontalPosText_TextChanged(object sender, EventArgs e)
		{
			ErrorDialogLabel.Text = string.Empty;
		}

		private void button1_Click(object sender, EventArgs e)
		{

			playerPiratesShip.DespawnShip();
			PiratesShip_icon.Visible = false;
			PiratesShip_nameText.Visible = false;
			PiratesShip_progressBar.Visible = false;
			RemovePiratesShip_button.Visible = false;
			ActionButton.Enabled = false;


		}

		private void AITimer_Tick(object sender, EventArgs e)
		{
			bool wasHit = false;

			Field fieldHit = AI.FireAtPosition();

			PlayerField.Hit(fieldHit);

			foreach (Ship playerShip in PlayerShips)
			{
				if (playerShip.isHit(fieldHit) == true)
				{
					AI.IsHit = true;
					wasHit = true;
					playerShip.Hit(fieldHit);
					break;
				}
			}

			int letter = ((fieldHit.point.Y / 30 + 'A'));
			int number = ((fieldHit.point.X / 30) + 1);
			String s = "PlayerField_" + (char)letter +  number;

			PictureBox pic = Controls.Find(s, true).FirstOrDefault() as PictureBox;

			if (wasHit == true)
				pic.Image = Image.FromFile("E:\\Programming\\c# vsite projects\\" +
					"BatleShips game\\BattleShips\\BattleShips\\Art\\Destroyed_ship.png");
			else
				pic.Image = Image.FromFile("E:\\Programming\\c# vsite projects\\" +
					"BatleShips game\\BattleShips\\BattleShips\\Art\\HitArea.png");

			pic.BringToFront();
			ActionText.Text = "Enemy fired at " + (char)letter + "" + number;

			FireButton.Enabled = true;
			LetterboxText.Enabled = true;
			NumberboxText.Enabled = true;

			SetHealth();
			SetNumOfDestroyedShips();
			GameOver();

			AITimer.Stop();
		}

		private void cheat_button_Click(object sender, EventArgs e)
		{
			foreach (Ship ship in EnemyShips)
			{
				ship.ShowBoat();
			}
		}

		private void RemoveGalleon_button_Click(object sender, EventArgs e)
		{
			playerGalleon.DespawnShip();
			Galleon_icon.Visible = false;
			Galleon_nameText.Visible = false;
			Galleon_progressBar.Visible = false;
			RemoveGalleon_button.Visible = false;
			ActionButton.Enabled = false;
		}

		private void RemoveSloop_button_Click(object sender, EventArgs e)
		{
			playerSloop.DespawnShip();
			Sloop_icon.Visible = false;
			Sloop_nameText.Visible = false;
			Sloop_progressBar.Visible = false;
			RemoveSloop_button.Visible = false;
			ActionButton.Enabled = false;
		}

		private void RemoveBrigantine_button_Click(object sender, EventArgs e)
		{
			playerBrigantine.DespawnShip();
			Brigantine_icon.Visible = false;
			Brigantine_nameText.Visible = false;
			Brigantine_progressBar.Visible = false;
			RemoveBrigantine_button.Visible = false;
			ActionButton.Enabled = false;
		}

		private void RemoveFishingBoat_button_Click(object sender, EventArgs e)
		{
			playerFishingBoat.DespawnShip();
			FishingBoat_icon.Visible = false;
			FishingBoat_nameText.Visible = false;
			FishingBoat_progressBar.Visible = false;
			RemoveFishingBoat_button.Visible = false;
			ActionButton.Enabled = false;
		}

		private void exit_button_Click(object sender, EventArgs e)
		{
			Application.Exit(); 
		}

		private void GameScreen_Load(object sender, EventArgs e)
		{
			menuScreen.closeMenu();
		}
	}
}
