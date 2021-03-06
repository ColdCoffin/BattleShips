﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using BattleShips.Properties;
using System.IO;
using System.Resources;

namespace BattleShips
{
	public partial class GameScreen : Form
	{

		private static GameScreen gameScreenInstance;
		public static GameScreen GameScreenInstance
		{
			get
			{
				return gameScreenInstance;
			}
		}

		public bool playerGoesFirst { get; set; }

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

		StatsTracker playerStats;
		StatsTracker enemyStats;

		int destroyedPlayerShips;
		int destroyedEnemyShips;
		bool isEnemyTurn;
		bool isGameOver = false;

		int playerDialogClock = 0;
		int enemyDialogClock = 0;

		AIEnemy AI;

		ResourceManager RS;
		InGameOptionsMenu inGameOptionsMenu;

		GameLog gl;
		List<PictureBox> hitAreas;
		SetShip setShipMenu;
		FireAtShip fireAtShipMenu;
		PlayerActionText playerText;
		diceThrowScreen dicethrowScreen;

		Point cannonballEndPos, cannonballCurrentPos, cannonballEnemyStartPos, cannonballPlayerStartPos;

		List<Image> explosion;

		public GameScreen()
		{
			InitializeComponent();
		
			gameScreenInstance = this;

			PlayerField.LoadFields();
			EnemyField.LoadFields();

			gl = new GameLog(DialogLabel);
			playerStats = new StatsTracker();
			playerText = new PlayerActionText();

			gameTime.Start();

			explosion = new List<Image>();

			cannonballEnemyStartPos = new Point(192, 575);
			cannonballPlayerStartPos = new Point(1001, 161);

			RS = new ResourceManager("BattleShips.Properties.Resources", typeof(Resources).Assembly);

			Stream str = Resources.soundscrate_last_one_standing_sc1;
			MainThreadForm.mainThread.SetSoundStream(str);

			loadExplosion();

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
			HideShowLog_button.Visible = false;
			options_button.Enabled = false;
			ActionButton.Enabled = false;
			ActionButton.Text = "SET SHIPS";
			ActionButton.BackColor = Color.LightYellow;

			RemovePiratesShip_button.Visible = false;
			RemoveSloop_button.Visible = false;
			RemoveGalleon_button.Visible = false;
			RemoveFishingBoat_button.Visible = false;
			RemoveBrigantine_button.Visible = false;


			PlayerShips = new List<Ship>
			{
				playerFishingBoat,
				playerSloop,
				playerBrigantine,
				playerGalleon,	
				playerPiratesShip
				
			};

			EnemyShips = new List<Ship>
			{
				enemyFishingBoat,
				enemyGalleon,
				enemySloop,
				enemyPiratesShip,
				enemyBrigantine
			};

			hitAreas = new List<PictureBox>();

			setShipMenu = new SetShip();
			setShipMenu.Location = new Point(340, 160);
			setShipMenu.Parent = this;

			fireAtShipMenu = new FireAtShip();
			fireAtShipMenu.Location = new Point(340, 160);
			fireAtShipMenu.Parent = this;

			inGameOptionsMenu = new InGameOptionsMenu();
			inGameOptionsMenu.Location = new Point(340, 160);
			inGameOptionsMenu.Parent = this;

			dicethrowScreen = new diceThrowScreen();
			dicethrowScreen.Location = new Point(340, 260);
			dicethrowScreen.Parent = this;
			dicethrowScreen.Visible = true;
			dicethrowScreen.BringToFront();


		}
		public readonly bool isHard;
		public GameScreen(AIEnemy ai, bool isHard) : this()
		{
			this.isHard = isHard;
			AI = new AIEnemy(enemyFishingBoat, enemySloop,
									enemyGalleon, enemyBrigantine, enemyPiratesShip, isHard);
			AI.SpawnShips();
			enemyStats = new StatsTracker();

		}


		public void gameReset()
		{
			AITimer.Stop();
			cannonballTimer.Stop();
			explosionTimer.Stop();
			showEnemyDialogTimer.Stop();
			enemyDialogClock = 0;
			EnemyActionText.Visible = false;
			enemyDialogBox.Visible = false;
			showPlayerDialogTimer.Stop();
			playerDialogClock = 0;
			PlayerActionText.Visible = false;
			playerDialogBox.Visible = false;
			HideShowLog_button.Visible = false;


			cannonball.Visible = false;

			setShipMenu.SetShipInstance.ClearAllSetText();
			AI.DespawnShips();
			EnemyField.ResetFields();
			PlayerField.ResetFields();
			AI.SpawnShips();
			playerStats.ResetStats();
			enemyStats.ResetStats();
			SetHealth();

			gl.Reset();
			removeAllShipsFromDock();

			LogFrame.Visible = false;
			DialogLabel.Visible = false;


			foreach (PictureBox pictureBox in hitAreas)
			{
				pictureBox.Image = Resources.pixil_frame_0;
			}

			foreach (Ship ship in PlayerShips)
			{
				ship.DespawnShip();
			}

			destroyedPlayerShips = 0;
			destroyedEnemyShips = 0;


			FireButton.Enabled = false;
			SetShipsButton.Enabled = true;
			SetShipsButton.Visible = true;
			HideShowLog_button.Visible = false;

			RemovePiratesShip_button.Visible = false;
			RemoveSloop_button.Visible = false;
			RemoveGalleon_button.Visible = false;
			RemoveFishingBoat_button.Visible = false;
			RemoveBrigantine_button.Visible = false;


			dicethrowScreen = new diceThrowScreen();
			dicethrowScreen.Location = new Point(340, 260);
			dicethrowScreen.Parent = this;
			dicethrowScreen.Visible = true;
			dicethrowScreen.BringToFront();
			ActionButton.Text = "SET SHIPS";
			ActionButton.BackColor = Color.LightYellow;

		}
		bool enemyWasHit;
		bool enemyShipDestroyed;
		PictureBox hitPic;

		public void Fire(string letter, string number)
		{
			options_button.Enabled = true;

			isEnemyTurn = false;


			String s = "EnemyField_" + letter + number;

			hitPic = Controls.Find(s, true).FirstOrDefault() as PictureBox;

			if (hitPic == null)
			{
				playerDialogClock = 0;
				showPlayerDialogTimer.Start();
				PlayerActionText.Text = "Bad coordinaates mate!";
				return;
			}

			Point fireAt = hitPic.Location;


			if (EnemyField.isAlreadyHit(fireAt) == true)
			{
				playerDialogClock = 0;
				showPlayerDialogTimer.Start();
				PlayerActionText.Text = "Already fired there!";
				return;
			}



			explosion_image.Location = new Point(977, 150);
			explosionTimer.Start();

			EnemyField.Hit(new Field(fireAt));
			enemyWasHit = false;

			string shipHit = " (No ships were hit)";
			playerWasHit = false;
			enemyWasHit = false;
			playerShipDestroyed = false;
			enemyShipDestroyed = false;
			Ship temp = null;

			foreach (Ship enemyShip in EnemyShips)
			{
				if (enemyShip.isHit(new Field(fireAt)) == true)
				{
					enemyWasHit = true;
					shipHit = " (Ship was hit)";
					enemyShip.Hit(new Field(fireAt));

					if (enemyShip.getHealth() == 0)
					{
						enemyShipDestroyed = true;
						temp = enemyShip;
						playerStats.shipsDestroyed++;
					}

					break;
				}
			}

			if (enemyWasHit == true)
				playerStats.shipsHit++;
			else
				playerStats.shipsMissed++;

			cannonball.Location = cannonballPlayerStartPos;
			cannonballCurrentPos = cannonball.Location;
			cannonballEndPos = new Point(EnemyField_label.Location.X + (fireAt.X + 15),
				EnemyField_label.Location.Y + (fireAt.Y + 15));

			FireButton.Enabled = false;

			cannonballTimer.Start();

			playerDialogClock = 0;
			string msg = "" + (char)((fireAt.Y / 30) + 'A') + ((fireAt.X / 30) + 1);
			PlayerActionText.Text = "Firing at " + msg;
			showPlayerDialogTimer.Start();
			gl.Write("You fired at " + msg + shipHit);

			if (enemyShipDestroyed == true)
				gl.Write("You destroyed enemy " + temp.ShipName);


			if (isGameOver == false)
			{
				AIPreparing.Start();
				ActionButton.Text = "ENEMY TURN";
				ActionButton.BackColor = Color.Red;
			}


		}
		private void FireButton_Click(object sender, EventArgs e)
		{
			fireAtShipMenu.Visible = true;
			fireAtShipMenu.BringToFront();
			options_button.Enabled = false;

		}

		public bool SetShips(string ShipType, string SetHorizontalPosText, string SetVerticalPosText, string ShipName,
			bool VerticalOption)
		{

			RemoveBrigantine_button.Enabled = true;
			RemoveFishingBoat_button.Enabled = true; 
			RemoveSloop_button.Enabled = true;
			RemoveGalleon_button.Enabled = true;
			RemovePiratesShip_button.Enabled = true;

			if (SetHorizontalPosText.Length == 0 || SetHorizontalPosText[0] < 'A'
				|| SetHorizontalPosText[0] > 'J' || SetVerticalPosText.Length == 0)
			{
				PlayerActionText.Text = "Bad coordinates";
				showPlayerDialogTimer.Start();
				return false;
			}

			char hpos = SetHorizontalPosText[0];
			int vpos = int.Parse(SetVerticalPosText) - 1;

			if (vpos < 0 || vpos > 9)
			{
				PlayerActionText.Text = "Bad coordinates";
				showPlayerDialogTimer.Start();
				return false;
			}
			string sname = ShipName;

			int index = ((hpos - 65) * 10) + vpos;

			string ship = ShipType;
			string orientation;

			if (VerticalOption == true)
				orientation = "Vertical";
			else
				orientation = "Horizontal";

			switch (ship)
			{
				case "Fishing Boat":
					if (
					playerFishingBoat.SpawnShip(PlayerField.AllFields[index], orientation, false, sname) == false)
						goto case "Error";

					FishingBoat_icon.Visible = true;
					FishingBoat_nameText.Text = playerFishingBoat.ShipName;
					FishingBoat_nameText.Visible = true;
					FishingBoat_progressBar.Visible = true;
					RemoveFishingBoat_button.Visible = true;
					break;
				case "Brigantine":
					if (
					playerBrigantine.SpawnShip(PlayerField.AllFields[index], orientation, false, sname) == false)
						goto case "Error";

					Brigantine_icon.Visible = true;
					Brigantine_nameText.Text = playerBrigantine.ShipName;
					Brigantine_nameText.Visible = true;
					Brigantine_progressBar.Visible = true;
					RemoveBrigantine_button.Visible = true;
					break;
				case "Sloop":
					if (
					playerSloop.SpawnShip(PlayerField.AllFields[index], orientation, false, sname) == false)
						goto case "Error";

					Sloop_icon.Visible = true;
					Sloop_nameText.Text = playerSloop.ShipName;
					Sloop_nameText.Visible = true;
					Sloop_progressBar.Visible = true;
					RemoveSloop_button.Visible = true;
					break;
				case "Galleon":
					if (
					playerGalleon.SpawnShip(PlayerField.AllFields[index], orientation, false, sname) == false)
						goto case "Error";

					Galleon_icon.Visible = true;
					Galleon_nameText.Text = playerGalleon.ShipName;
					Galleon_nameText.Visible = true;
					Galleon_progressBar.Visible = true;
					RemoveGalleon_button.Visible = true;
					break;
				case "Pirate's ship":
					if (
					playerPiratesShip.SpawnShip(PlayerField.AllFields[index], orientation, false, sname) == false)
						goto case "Error";

					PiratesShip_icon.Visible = true;
					PiratesShip_nameText.Text = playerPiratesShip.ShipName;
					PiratesShip_nameText.Visible = true;
					PiratesShip_progressBar.Visible = true;
					RemovePiratesShip_button.Visible = true;
					break;

				case "Error":
					PlayerActionText.Text = "Can't place your boat there";
					showPlayerDialogTimer.Start();
					return false;

				default:
					PlayerActionText.Text = "No such ship exists";
					showPlayerDialogTimer.Start();
					return false;
			}

			foreach (Ship s in PlayerShips)
			{
				if (s.isSpawned == true)
				{
					ActionButton.Enabled = true;
					ActionButton.Text = "START GAME";
					ActionButton.BackColor = Color.Black;
				}
				else
				{
					ActionButton.Enabled = false;
					ActionButton.Text = "SET SHIPS";
					ActionButton.BackColor = Color.LightYellow;
					break;
				}
			}

			return true;
		}

		public void DespawnPlayerShip(Ship ship)
		{

			if (ship.GetType() == typeof(FishingBoat))
				RemoveFishingBoat_button_Click(null,null);
			if (ship.GetType() == typeof(Brigantine))
				RemoveBrigantine_button_Click(null, null);
			if (ship.GetType() == typeof(Sloop))
				RemoveSloop_button_Click(null, null);
			if (ship.GetType() == typeof(Galleon))
				RemoveGalleon_button_Click(null, null);
			if (ship.GetType() == typeof(PiratesShip))
				button1_Click(null, null);

		}

		public void CancelMenu()
		{
			options_button.Enabled = true;

			RemoveBrigantine_button.Enabled = true;
			RemoveFishingBoat_button.Enabled = true;
			RemoveSloop_button.Enabled = true;
			RemoveGalleon_button.Enabled = true;
			RemovePiratesShip_button.Enabled = true;
		}

		private void SetShipsButton_Click(object sender, EventArgs e)
		{
			setShipMenu.BringToFront();
			setShipMenu.Visible = true;
			options_button.Enabled = false;

			RemoveBrigantine_button.Enabled = false;
			RemoveFishingBoat_button.Enabled = false;
			RemoveSloop_button.Enabled = false;
			RemoveGalleon_button.Enabled = false;
			RemovePiratesShip_button.Enabled = false;
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

		private void GameOverScreen(bool playerWon)
		{
			if (playerWon == true)
			{
				EndGameMenu temp = new EndGameMenu(playerStats, enemyStats, true);
				temp.Location = new Point(340, 160);
				temp.Parent = this;
				temp.Visible = true;
				temp.BringToFront();
			}
			else
			{
				EndGameMenu temp = new EndGameMenu(playerStats, enemyStats, false);
				temp.Location = new Point(340, 160);
				temp.Parent = this;
				temp.Visible = true;
				temp.BringToFront();
			}

			options_button.Enabled = false;

		}

		private void ActionButton_Click(object sender, EventArgs e)
		{
			SetShipsButton.Enabled = false;
			FireButton.Enabled = false;
			RemovePiratesShip_button.Visible = false;
			RemoveBrigantine_button.Visible = false;
			RemoveFishingBoat_button.Visible = false;
			RemoveGalleon_button.Visible = false;
			RemoveSloop_button.Visible = false;
			HideShowLog_button.Visible = true;
			ActionButton.Enabled = false;

			if (playerGoesFirst == true)
			{
				ActionButton.Text = "YOUR TURN";
				ActionButton.BackColor = Color.Green;
				FireButton.Enabled = true;
			}
			else
			{
				ActionButton.Text = "ENEMY TURN";
				ActionButton.BackColor = Color.Red;
				enemyDialogClock = 0;
				showEnemyDialogTimer.Start();

				EnemyActionText.Text = "Ready the cannons!";

				AITimer.Start();
			}		

		}

		private void button1_Click(object sender, EventArgs e)
		{

			playerPiratesShip.DespawnShip();
			PiratesShip_icon.Visible = false;
			PiratesShip_nameText.Visible = false;
			PiratesShip_progressBar.Visible = false;
			RemovePiratesShip_button.Visible = false;
			ActionButton.Enabled = false;
			ActionButton.Text = "SET SHIPS";
			ActionButton.BackColor = Color.LightYellow;

			setShipMenu.SetShipInstance.ClearSetText("Pirate's ship");

		}

		bool playerWasHit;
		bool playerShipDestroyed;
		private void AITimer_Tick(object sender, EventArgs e)
		{

			explosion_image.Location = new Point(193,566);
			explosionTimer.Start();

			playerWasHit = false;
			enemyWasHit = false;
			playerShipDestroyed = false;
			enemyShipDestroyed = false;
			

			isEnemyTurn = true;

			Field fieldHit = AI.FireAtPosition();

			PlayerField.Hit(fieldHit);

			string shipHit = " (No ships were hit)";
			playerShipDestroyed = false;
			Ship temp = null;

			foreach (Ship playerShip in PlayerShips)
			{
				if (playerShip.isHit(fieldHit) == true)
				{

					playerWasHit = true;
					playerShip.Hit(fieldHit);
					AI.IsHit = true;

					shipHit = " (Enemy hit your " + playerShip.ShipName + ")";

					if (playerShip.getHealth() == 0)
					{
						playerShipDestroyed = true;
						temp = playerShip;
						enemyStats.shipsDestroyed++;
						AI.ShipDestroyed();
					}
					break;
				}
			}

			if (playerWasHit == true)
				enemyStats.shipsHit++;
			else
				enemyStats.shipsMissed++;

			int letter = ((fieldHit.point.Y / 30 + 'A'));
			int number = ((fieldHit.point.X / 30) + 1);
			String s = "PlayerField_" + (char)letter +  number;

			hitPic = Controls.Find(s, true).FirstOrDefault() as PictureBox;

			enemyDialogClock = 0;
			showEnemyDialogTimer.Start();
			string msg = "" + (char)letter + "" + number;
			EnemyActionText.Text = "Fire at " + msg + "!";
			gl.Write("Enemy fired at " + msg + shipHit);

			if (playerShipDestroyed == true)
			{
				gl.Write("Your " + temp.ShipName + " was destroyed");

			}

			cannonball.Location = cannonballEnemyStartPos;
			cannonballCurrentPos = cannonball.Location;
			cannonballEndPos = new Point(PlayerField_label.Location.X + (fieldHit.point.X + 15),
				PlayerField_label.Location.Y + (fieldHit.point.Y + 15));

			if (isGameOver == false)
			{
				ActionButton.Text = "YOUR TURN";
				ActionButton.BackColor = Color.Green;
				FireButton.Enabled = true;
			}

			

			cannonballTimer.Start();
			AITimer.Stop();

		}

		public void Cheat()
		{
			foreach (Ship ship in EnemyShips)
			{
				ship.ShowBoat();
			}
		}

		private void removeAllShipsFromDock()
		{
			Galleon_icon.Visible = false;
			Galleon_nameText.Visible = false;
			Galleon_progressBar.Visible = false;

			Sloop_icon.Visible = false;
			Sloop_nameText.Visible = false;
			Sloop_progressBar.Visible = false;

			Brigantine_icon.Visible = false;
			Brigantine_nameText.Visible = false;
			Brigantine_progressBar.Visible = false;

			FishingBoat_icon.Visible = false;
			FishingBoat_nameText.Visible = false;
			FishingBoat_progressBar.Visible = false;

			PiratesShip_icon.Visible = false;
			PiratesShip_nameText.Visible = false;
			PiratesShip_progressBar.Visible = false;
		}
		
		private void RemoveGalleon_button_Click(object sender, EventArgs e)
		{
			playerGalleon.DespawnShip();
			Galleon_icon.Visible = false;
			Galleon_nameText.Visible = false;
			Galleon_progressBar.Visible = false;
			RemoveGalleon_button.Visible = false;
			ActionButton.Enabled = false;
			ActionButton.Text = "SET SHIPS";
			ActionButton.BackColor = Color.LightYellow;

			setShipMenu.SetShipInstance.ClearSetText("Galleon");
		}

		private void RemoveSloop_button_Click(object sender, EventArgs e)
		{
			playerSloop.DespawnShip();
			Sloop_icon.Visible = false;
			Sloop_nameText.Visible = false;
			Sloop_progressBar.Visible = false;
			RemoveSloop_button.Visible = false;
			ActionButton.Enabled = false;
			ActionButton.Text = "SET SHIPS";
			ActionButton.BackColor = Color.LightYellow;

			setShipMenu.SetShipInstance.ClearSetText("Sloop");
		}

		private void RemoveBrigantine_button_Click(object sender, EventArgs e)
		{
			playerBrigantine.DespawnShip();
			Brigantine_icon.Visible = false;
			Brigantine_nameText.Visible = false;
			Brigantine_progressBar.Visible = false;
			RemoveBrigantine_button.Visible = false;
			ActionButton.Enabled = false;
			ActionButton.Text = "SET SHIPS";
			ActionButton.BackColor = Color.LightYellow;

			setShipMenu.SetShipInstance.ClearSetText("Brigantine");
		}

		private void RemoveFishingBoat_button_Click(object sender, EventArgs e)
		{
			playerFishingBoat.DespawnShip();
			FishingBoat_icon.Visible = false;
			FishingBoat_nameText.Visible = false;
			FishingBoat_progressBar.Visible = false;
			RemoveFishingBoat_button.Visible = false;
			ActionButton.Enabled = false;
			ActionButton.Text = "SET SHIPS";
			ActionButton.BackColor = Color.LightYellow;

			setShipMenu.SetShipInstance.ClearSetText("Fishing Boat");
		}

		private void exit_button_Click(object sender, EventArgs e)
		{
			inGameOptionsMenu.Visible = true;
			inGameOptionsMenu.BringToFront();
		}

		private void loadExplosion()
		{
			for (int i = 1; i <= 49; i++)
			{
				explosion.Add((Image)RS.GetObject("explosion_miss_" + i ));
			}
		}

		int explosionIndex = 1;
		private void showPlayerDialogTimer_Tick(object sender, EventArgs e)
		{
			if (playerDialogClock == 35)
			{
				playerDialogClock = 0;
				PlayerActionText.Visible = false;
				playerDialogBox.Visible = false;
				showPlayerDialogTimer.Stop();
			}
			else
			{
				PlayerActionText.Visible = true;
				playerDialogBox.Visible = true;
				playerDialogClock++;
			}
		}


		private void showEnemyDialogTimer_Tick(object sender, EventArgs e)
		{
			if (enemyDialogClock == 35)
			{
				enemyDialogClock = 0;
				EnemyActionText.Visible = false;
				enemyDialogBox.Visible = false;
				showEnemyDialogTimer.Stop();
			}
			else
			{
				EnemyActionText.Visible = true;
				enemyDialogBox.Visible = true;
				enemyDialogClock++;
			}
		}

		private void explosionTimer_Tick(object sender, EventArgs e)
		{
			if (explosionIndex >= 20)
			{
				explosionIndex = 1;
				explosion_image.Visible = false;
				explosionTimer.Stop();
			}
			else
			{
				explosion_image.Visible = true;
				explosion_image.BringToFront();
				explosion_image.BackgroundImage = explosion[explosionIndex];
				explosionIndex++;
			}
		}

		private void HideShowLog_button_Click(object sender, EventArgs e)
		{
			if (HideShowLog_button.Text == "Hide Log")
			{
				HideShowLog_button.Text = "Show Log";
				LogFrame.Visible = false;
				DialogLabel.Visible = false;
			}
			else
			{
				HideShowLog_button.Text = "Hide Log";
				LogFrame.Visible = true;
				DialogLabel.Visible = true;
			}
		}

		private int minutesPassed = 0;
		public int MinutesPassed { get { return minutesPassed; } }
		private void gameTime_Tick(object sender, EventArgs e)
		{
			++minutesPassed;
		}

		private void AIPreparing_Tick(object sender, EventArgs e)
		{
			enemyDialogClock = 0;
			showEnemyDialogTimer.Start();

			EnemyActionText.Text = "Ready the cannons!";

			AITimer.Start();
			AIPreparing.Stop();
		}

		int endDistance;
		private void cannonballTimer_Tick(object sender, EventArgs e)
		{

			endDistance = Math.Abs(cannonballEndPos.X - cannonballCurrentPos.X);
			endDistance += Math.Abs(cannonballEndPos.Y - cannonballCurrentPos.Y);

			cannonball.Visible = true;

			if (endDistance <= 7)
			{
				cannonballTimer.Stop();

				explosion_image.Location = new Point(cannonballEndPos.X - 15, cannonballEndPos.Y - 15);
				explosionTimer.Start();

				if (enemyWasHit == true || playerWasHit == true)
					hitPic.Image = Resources.Destroyed_ship;
				else
					hitPic.Image = Resources.HitArea;


				hitPic.BringToFront();

				hitAreas.Add(hitPic);
				
				SetHealth();
				SetNumOfDestroyedShips();


				cannonball.Visible = false;

				playerDialogClock = 0;
				enemyDialogClock = 0;

				if (enemyShipDestroyed == true)
				{
					PlayerActionText.Text = playerText.DestroyedShipText();
					showPlayerDialogTimer.Start();
				}
				else if (enemyWasHit == true)
				{
					PlayerActionText.Text = playerText.HitText();
					showPlayerDialogTimer.Start();
				}



				if (playerShipDestroyed == true)
				{
					EnemyActionText.Text = playerText.DestroyedShipText();
					showEnemyDialogTimer.Start();
				}
				else if (playerWasHit == true)
				{
					EnemyActionText.Text = playerText.HitText();
					showEnemyDialogTimer.Start();
				}
			}

			if (cannonball.Location.X > cannonballEndPos.X)
				cannonball.Location = new Point(cannonball.Location.X - 6,
					calculateLinearFunction());
			if (cannonball.Location.X < cannonballEndPos.X)
				cannonball.Location = new Point(cannonball.Location.X + 6,
					calculateLinearFunction());


			if (destroyedEnemyShips == 5)
			{
				isGameOver = true;
				GameOverScreen(true);
			}
			else if (destroyedPlayerShips == 5)
			{
				isGameOver = true;
				GameOverScreen(false);
			}

			cannonballCurrentPos = cannonball.Location;

		}

		private int calculateLinearFunction()
		{
			int y;
			float m;
			if ( isEnemyTurn == true)
				m = (float)(cannonballEnemyStartPos.Y - cannonballEndPos.Y)
					/ (cannonballEnemyStartPos.X - cannonballEndPos.X);
			else
				m = (float)(cannonballPlayerStartPos.Y - cannonballEndPos.Y)
					/ (cannonballPlayerStartPos.X - cannonballEndPos.X);

			y = (int)(m * (cannonballCurrentPos.X - cannonballEndPos.X));

			if (cannonballCurrentPos.Y > 0)
				y += cannonballEndPos.Y;
			else
				y -= cannonballEndPos.Y;

			return y;
		}
	}
}
