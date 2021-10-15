using System;
using System.Drawing;
using System.IO;
using System.Media;
using System.Windows.Forms;

namespace StartMenu
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }
        Button settings = new Button();
        Button start = new Button();

        public static string[] phrases = new string[5];
        public static bool[] started;
        public static Point[,] GamevsOther = new Point[5, 16];
        DateTime[] TimevsOther = new DateTime[5];
        public static int[,] TurnvsOther = new int[5, 2];
        public static string[] Passwords;
        Button b3 = new Button();
        Button b4 = new Button();
        ComboBox c = new ComboBox();
        string[,] Verify = new string[5, 2];
        public static string[] PhrasesArranged;

        public static string[] phrasesCPU = new string[5];
        public static bool[] startedCPU;
        public static Point[,] GamevsCPU = new Point[5, 16];
        DateTime[] TimevsCPU = new DateTime[5];
        public static int[,] TurnvsCPU = new int[5, 2];
        public static string[] PasswordsCPU;
        Button b5 = new Button();
        Button b6 = new Button();
        ComboBox cCPU = new ComboBox();
        string[,] VerifyCPU = new string[5, 2];
        public static string[] PhrasesArrangedCPU;

        public static bool PlayAgainstCPU;
        Button back = new Button();
        Button enter = new Button();
        TextBox te = new TextBox();
        Panel panel = new Panel();
        Label le = new Label();

        public static Label gems = new Label();
        public static int amount_of_gems=50;
        public static Label gems_image = new Label();

        Button exitgame = new Button();
        public static bool[] Turns = new bool[4];
        public static int[,] whostarted = new int[2, 5];

        Label[] Equiped = new Label[2];
        bool[] ColorAlreadyEquiped = new bool[4];
        private void Out(object sender, EventArgs e)
        {
            //Application.Exit();
            //this.Close();
            Environment.Exit(0);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Controls.Remove(label1);
            this.Controls.Remove(label2);
            this.Controls.Remove(label3);
            this.Controls.Remove(label4);
            this.Controls.Remove(label5);
            this.Controls.Remove(label6);
            this.Controls.Remove(label7);
            this.Controls.Remove(pictureBox1);
            this.BackgroundImage = global::StartMenu.Properties.Resources.Background;

            this.BackgroundImageLayout = ImageLayout.Stretch;

            this.FormBorderStyle = FormBorderStyle.None;
           
            PlayAgainstCPU = false;

            
            gems.Size = new Size(100, 20);
            gems.Text = amount_of_gems.ToString();
            gems.Location = new Point(this.Width - 160, 10);
            gems.BackColor = Color.Transparent;
            gems.ForeColor = Color.BurlyWood;
            gems.Font = new Font("calibri", 15, FontStyle.Regular);
            this.Controls.Add(gems);

           
            gems_image.Size = new Size(20,20);
            gems_image.Location = new Point(gems.Location.X - gems_image.Width, gems.Location.Y);
            gems_image.BackgroundImage = global::StartMenu.Properties.Resources.gems;
            gems_image.BackgroundImageLayout = ImageLayout.Stretch;
            this.Controls.Add(gems_image);
            
            

            exitgame.Location = new Point(gems.Location.X+gems.Width+20, gems.Location.Y);
            exitgame.Size = new Size(25, 25);
            exitgame.BackColor = Color.Transparent;
            exitgame.FlatStyle = FlatStyle.Flat;
            exitgame.FlatAppearance.BorderSize = 0;
            exitgame.BackgroundImage = global::StartMenu.Properties.Resources.close;
            exitgame.BackgroundImageLayout = ImageLayout.Stretch;
            exitgame.Click += new EventHandler(Out);
      
            this.Controls.Add(exitgame);

            panel.Size = new Size(500, 250);
            panel.BackColor = Color.White;
            panel.BackColor = Color.FromArgb(100, 0, 0, 0);

            enter.Size = new Size(100, 50);
            enter.BackColor = Color.White;
            enter.BackColor = Color.FromArgb(100, 0, 0, 0);
            enter.ForeColor = Color.BurlyWood;
            enter.Text = "ENTER";
            enter.Font = new Font("Monotype Corsiva", 15, FontStyle.Regular);
            enter.BringToFront();
            enter.FlatStyle = FlatStyle.Popup;
            enter.Click += new EventHandler(EnterPassword);

            le.Size = new Size(panel.Width-30, 50);
            le.BackColor = Color.White;
            le.BackColor = Color.FromArgb(100, 0, 0, 0);
            le.Text = "In order to continue, please enter the password of the chosen game:";
            le.Font = new Font("Monotype Corsiva", 15F, (FontStyle.Italic | FontStyle.Bold), GraphicsUnit.Point);
            le.ForeColor = Color.BurlyWood;

            back.Size = new Size(100, 50);
            back.BackColor = Color.White;
            back.BackColor = Color.FromArgb(100, 0, 0, 0);
            back.ForeColor = Color.BurlyWood;
            back.Text = "BACK";
            back.Font = new Font("Monotype Corsiva", 15, FontStyle.Regular);
            back.BringToFront();
            back.Click += new EventHandler(BackToComboBox);
            back.FlatStyle = FlatStyle.Popup;

            te.Size = new Size(200, 75);
            te.Font = new Font("calibri", 12, FontStyle.Regular);
            te.UseSystemPasswordChar = true;


            Label l = new Label();
            l.Location = new Point(400, 0);
            l.Size = new Size(800, 250);
            l.TextAlign = ContentAlignment.MiddleCenter;
            l.BackColor = Color.Transparent;
            l.Text = "QUARTO";
            l.Font = new Font("Monotype Corsiva", 120F, FontStyle.Italic);
            l.FlatStyle = FlatStyle.Popup;
            l.ForeColor = Color.BurlyWood;
            this.Controls.Add(l);

            settings.Location = new Point(50, 50);
            settings.BackColor = Color.Transparent; ;
            settings.Size = new Size(100, 50);
            settings.Text = "SETTINGS";
            settings.Font = new Font("Monotype Corsiva", 14); ;
            settings.FlatStyle = FlatStyle.Popup;
            settings.ForeColor = Color.BurlyWood;
            settings.FlatAppearance.BorderSize = 5;
            settings.FlatAppearance.BorderColor = Color.BurlyWood;
            settings.Click += new EventHandler(SettingsClick);
            this.Controls.Add(settings);


            start.Location = new Point(550, 250);
            start.BackColor = Color.Transparent;
            start.Size = new Size(500, 150);
            start.Text = "START";
            start.FlatStyle = FlatStyle.Flat;
            start.FlatAppearance.BorderSize = 5;
            start.FlatAppearance.BorderColor = Color.BurlyWood;
            start.Font = new Font("Monotype Corsiva", 80);
            start.ForeColor = Color.BurlyWood;
            start.Click += new EventHandler(StartClick);
            this.Controls.Add(start);

            help.Location = new Point(settings.Location.X + settings.Width / 10, settings.Location.Y + settings.Height); help.BackColor = Color.Transparent;
            help.Size = new Size(settings.Width - 2 * settings.Width / 10, settings.Height);
            help.Text = "HELP";
            help.Font = new Font("Monotype Corsiva", 12, FontStyle.Regular);
            help.FlatStyle = FlatStyle.Flat;
            help.BackColor = Color.Transparent;
            help.ForeColor = Color.BurlyWood;
            help.FlatAppearance.BorderSize = 0;
            help.Click += new EventHandler(HelpClick);

            volume.Location = new Point(help.Location.X, help.Location.Y + settings.Height);
            volume.Size = new Size(help.Width, help.Height);
            volume.Text = "VOLUME";
            volume.Font = new Font("Monotype Corsiva", 12, FontStyle.Regular);
            volume.FlatStyle = FlatStyle.Flat;
            volume.BackColor = Color.Transparent;
            volume.ForeColor = Color.BurlyWood;
            volume.FlatAppearance.BorderSize = 0;
            volume.Click += new EventHandler(VolumeClick);

            ColorsButton.Location = new Point(help.Location.X, help.Location.Y + 2 * settings.Height);
            ColorsButton.Size = new Size(help.Width, help.Height);
            ColorsButton.Text = "COLORS";
            ColorsButton.Font = new Font("Monotype Corsiva", 12, FontStyle.Regular);
            ColorsButton.FlatStyle = FlatStyle.Popup;
            ColorsButton.BackColor = Color.Transparent;
            ColorsButton.ForeColor = Color.BurlyWood;
            ColorsButton.FlatAppearance.BorderSize = 0;
            ColorsButton.Click += new EventHandler(ColorClick);


        /*    reset.Location = new Point(help.Location.X, help.Location.Y + 3 * settings.Height);
            reset.Size = new Size(help.Width, help.Height);
            reset.Text = "Reset";
            reset.Font = new Font("Monotype Corsiva", 12, FontStyle.Regular);
            reset.FlatStyle = FlatStyle.Popup;
            reset.BackColor = Color.Transparent;
            reset.ForeColor = Color.BurlyWood;
            reset.FlatAppearance.BorderSize = 0;
            this.Controls.Add(reset);
            reset.Click += new EventHandler(ResetClick);*/
            

            on.Location = new Point(volume.Location.X + volume.Width, volume.Location.Y);
            on.BackColor = Color.Transparent;
            on.ForeColor = Color.BurlyWood;
            on.Size = new Size(volume.Height, volume.Height);
            on.Text = "ON";
            on.Font = new Font("calibri", 12, FontStyle.Regular);
            on.FlatStyle = FlatStyle.Flat;
            on.FlatAppearance.BorderSize = 0;
            on.Click += new EventHandler(PlaySound);

            off.Location = new Point(volume.Location.X + volume.Width + on.Width, volume.Location.Y);
            off.BackColor = Color.Transparent;
            off.ForeColor = Color.BurlyWood;
            off.Size = new Size(volume.Height, volume.Height);
            off.Text = "OFF";
            off.Font = new Font("calibri", 12, FontStyle.Regular);
            off.FlatStyle = FlatStyle.Flat;
            off.FlatAppearance.BorderSize = 0;
            off.Click += new EventHandler(StopSound);

            t.Width = 500;
            t.Height = 500;
            t.BackColor = Color.White;
            t.ForeColor = Color.BurlyWood;
            t.Location = new Point(ColorsButton.Location.X - 20, ColorsButton.Location.Y + ColorsButton.Height);
            t.Font = new Font("Calibri", 14F, FontStyle.Bold, GraphicsUnit.Point);
            t.Text = "Quarto is a board game recently invented by Blaise Muller (blaise.muller@9online.fr) and published by Gigamic.\n\nThis is a game for two players. The board has 16 squares(4x4), and the 16 different pieces that can be constructed combinating the following four characteristics:\nSize(big / small)\nColour(red / blue)\nShape(circle / square)\nHole(piece with hole / piece without hole)\n\nThe aim of the game is to complete a line with four pieces that are similar at least about one of the four described characteristics(four big pieces, four little, four red, four blue, four circle, four square, four with hole or four without hole).The line may be vertical, horizontal or diagonal.The winner is the player who places the fourth piece of the line.\n\nPlayers move alternatively, placing one piece on the board; once inserted, pieces cannot be moved.\n\nOne of the more special characteristics of this game is that the choice of the piece to be placed on the board is not made by the same player who places it; it is the opponent who, after doing his move, decides which will be the next piece to place.\n\nSo, each turn consists of two actions:\n1.Place on the board the piece given by the opponent.\n2.Give to the opponent the piece to be placed in the next move.\nIn the first turn of the game, the player who starts has only to choose one piece for the opponent.";
            t.ReadOnly = true;

            Gold.Location = new Point(ColorsButton.Location.X, ColorsButton.Location.Y + ColorsButton.Height);
            Gold.BackColor = Color.Goldenrod;
            Gold.Size = new Size(ColorsButton.Width, ColorsButton.Height);
            //Red.Text = "ON";
            //Red.Font = new Font("calibri", 12, FontStyle.Regular);
            Gold.FlatStyle = FlatStyle.Flat;
            Gold.FlatAppearance.BorderSize = 0;
            Gold.Click += new EventHandler(Gold_Click);

            Silver.Location = new Point(ColorsButton.Location.X, ColorsButton.Location.Y + 2 * ColorsButton.Height);
            Silver.BackColor = Color.Silver;
            Silver.Size = new Size(ColorsButton.Width, ColorsButton.Height);
            //Blue.Text = "OFF";
            //Blue.Font = new Font("calibri", 12, FontStyle.Regular);
            Silver.FlatStyle = FlatStyle.Flat;
            Silver.FlatAppearance.BorderSize = 0;
            Silver.Click += new EventHandler(Silver_Click);

            Green.Location = new Point(ColorsButton.Location.X, ColorsButton.Location.Y + 3 * ColorsButton.Height);
            Green.BackColor = Color.ForestGreen;
            Green.Size = new Size(ColorsButton.Width, ColorsButton.Height);
            //Green.Text = "OFF";
            //Green.Font = new Font("calibri", 12, FontStyle.Regular);
            Green.FlatStyle = FlatStyle.Flat;
            Green.FlatAppearance.BorderSize = 0;
            Green.Text = "50 gems";
            Green.Font = new Font("Monotype Corsiva", 12, (FontStyle.Italic | FontStyle.Bold), GraphicsUnit.Point);
            Green.ForeColor = Color.White;
            Green.Click += new EventHandler(Green_Click);

            BlueViolet.Location = new Point(ColorsButton.Location.X, ColorsButton.Location.Y + 4 * ColorsButton.Height);
            BlueViolet.BackColor = Color.BlueViolet;
            BlueViolet.Size = new Size(ColorsButton.Width, ColorsButton.Height);
            //Blue.Text = "OFF";
            //Blue.Font = new Font("calibri", 12, FontStyle.Regular);
            BlueViolet.FlatStyle = FlatStyle.Flat;
            BlueViolet.FlatAppearance.BorderSize = 0;
            BlueViolet.Text = "100 gems";
            BlueViolet.Font = new Font("Monotype Corsiva", 12, (FontStyle.Italic | FontStyle.Bold), GraphicsUnit.Point);
            BlueViolet.ForeColor = Color.White;
            BlueViolet.Click += new EventHandler(Violet_Click);

            for (int e1 = 0; e1 < 2; e1++)
            {
                Equiped[e1] = new Label();
                Equiped[e1].Width = ColorsButton.Width;
                Equiped[e1].Height = ColorsButton.Height;
                Equiped[e1].ForeColor = Color.BurlyWood;
                Equiped[e1].Font = new Font("Monotype Corsiva", 11, (FontStyle.Italic | FontStyle.Bold), GraphicsUnit.Point);
                Equiped[e1].BackColor = Color.Transparent;
                Equiped[e1].TextAlign = ContentAlignment.MiddleCenter;
                Equiped[e1].Text = "Equiped";

            }

            FileStream fs;
            BinaryReader br;

            fs = new FileStream("Colors.data", FileMode.Open);
            br = new BinaryReader(fs);
            if(fs.Length!=0)
            {
                amount_of_gems = br.ReadInt32();
                gems.Text = amount_of_gems.ToString();
                if(br.PeekChar()!=-1)
                {
                    for (int i = 0; i < 4; i++)
                        ColorsUnlocked[i] = br.ReadBoolean();
                    for (int i = 0; i < 2; i++)
                        ColorsChosen[i] = br.ReadInt32();
                }
                else
                {
                    ColorsUnlocked[0] = true;
                    ColorsUnlocked[1] = true;
                    ColorsUnlocked[2] = false;
                    ColorsUnlocked[3] = false;
                    ColorsChosen[0] = 0;
                    ColorsChosen[1] = 1;
                }
            }
            else
            {
                ColorsUnlocked[0] = true;
                ColorsUnlocked[1] = true;
                ColorsUnlocked[2] = false;
                ColorsUnlocked[3] = false;
                ColorsChosen[0] = 0;
                ColorsChosen[1] = 1;
            }
            for (int i = 0; i < 4; i++)
                ColorAlreadyEquiped[i] = false;
            ColorAlreadyEquiped[ColorsChosen[1]] = true;
            ColorAlreadyEquiped[ColorsChosen[0]] = true;
            br.Close();
            fs.Close();

            if (ColorsChosen[0] == 0)
            {
                GamePlay.player1_color = Brushes.Goldenrod;
                GamePlay.player1_dark_color = Brushes.DarkGoldenrod;
                Equiped[0].Location = new Point(Gold.Location.X + Gold.Width, Gold.Location.Y);
            }
            else if (ColorsChosen[0] == 1)
            {
                GamePlay.player1_color = Brushes.Silver;
                GamePlay.player1_dark_color = Brushes.DarkGray;
                Equiped[0].Location = new Point(Silver.Location.X + Silver.Width, Silver.Location.Y);
            }
            else if (ColorsChosen[0] == 2)
            {
                GamePlay.player1_color = Brushes.ForestGreen;
                GamePlay.player1_dark_color = Brushes.DarkGreen;
                Equiped[0].Location = new Point(Green.Location.X + Green.Width, Green.Location.Y);
            }
            else if (ColorsChosen[0] == 3)
            {
                GamePlay.player1_color = Brushes.BlueViolet;
                GamePlay.player1_dark_color = Brushes.DarkBlue;
                Equiped[0].Location = new Point(BlueViolet.Location.X + BlueViolet.Width, BlueViolet.Location.Y);
            }
            if (ColorsChosen[1] == 0)
            {
                GamePlay.player2_color = Brushes.Goldenrod;
                GamePlay.player2_Dark_color = Brushes.DarkGoldenrod;
                Equiped[1].Location = new Point(Gold.Location.X + Gold.Width, Gold.Location.Y);
            }
            else if (ColorsChosen[1] == 1)
            {
                GamePlay.player2_color = Brushes.Silver;
                GamePlay.player2_Dark_color = Brushes.DarkGray;
                Equiped[1].Location = new Point(Silver.Location.X + Silver.Width, Silver.Location.Y);
            }
            else if (ColorsChosen[1] == 2)
            {
                GamePlay.player2_color = Brushes.ForestGreen;
                GamePlay.player2_Dark_color = Brushes.DarkGreen;
                Equiped[1].Location = new Point(Green.Location.X + Green.Width, Green.Location.Y);
            }
            else if (ColorsChosen[1] == 3)
            {
                GamePlay.player2_color = Brushes.BlueViolet;
                GamePlay.player2_Dark_color = Brushes.DarkBlue;
                Equiped[1].Location = new Point(BlueViolet.Location.X + BlueViolet.Width, BlueViolet.Location.Y);
            }

            started = new bool[5];
            for (int i = 0; i < 5; i++)
                started[i] = true;

            string Name1, Name2;
            Passwords = new string[5];
            for (int i1 = 0; i1 < 5; i1++)
            {
                fs = new FileStream("Game" + (i1 + 1).ToString() + ".data", FileMode.Open);
                br = new BinaryReader(fs);
                if (fs.Length != 0)
                {
                    for (int i2 = 0; i2 < 16; i2++)
                    {
                        GamevsOther[i1, i2].X = br.ReadInt32();
                        GamevsOther[i1, i2].Y = br.ReadInt32();
                    }
                    Name1 = br.ReadString();
                    Name2 = br.ReadString();
                    Verify[i1, 0] = Name1;
                    Verify[i1, 1] = Name2;
                    TimevsOther[i1] = new DateTime(br.ReadInt32(), br.ReadInt32(), br.ReadInt32(), br.ReadInt32(), br.ReadInt32(), br.ReadInt32());
                    phrases[i1] = Name1 + " vs " + Name2 + "   " + TimevsOther[i1].Day + "/" + TimevsOther[i1].Month + "/" + TimevsOther[i1].Year + " ";
                    if (TimevsOther[i1].Hour < 10)
                        phrases[i1] += "0" + TimevsOther[i1].Hour + ":";
                    else
                        phrases[i1] += TimevsOther[i1].Hour + ":";
                    if (TimevsOther[i1].Minute < 10)
                        phrases[i1] += "0" + TimevsOther[i1].Minute + ":";
                    else
                        phrases[i1] += TimevsOther[i1].Minute + ":";
                    if (TimevsOther[i1].Second < 10)
                        phrases[i1] += "0" + TimevsOther[i1].Second;
                    else
                        phrases[i1] += TimevsOther[i1].Second;
                    whostarted[1, i1] = br.ReadInt32();
                    TurnvsOther[i1, 0] = br.ReadInt32();
                    if (TurnvsOther[i1, 0] % 2 == 1)
                        TurnvsOther[i1, 1] = br.ReadInt32();
                    if (br.PeekChar() != -1)
                    {
                        Passwords[i1] = br.ReadString();
                        phrases[i1] += "   (LOCKED)";
                    }
                    else
                        Passwords[i1] = "";
                }
                br.Close();
                fs.Close();
            }

            for (int i = 0; i < Verify.GetLength(0); i++)
                for (int j = 0; j < Verify.GetLength(1); j++)
                    if (Verify[i, j] == null)
                        Verify[i, j] = "";

            PhrasesArranged = new string[5];
            PhrasesArranged[0] = phrases[0];
            PhrasesArranged[1] = phrases[1];
            PhrasesArranged[2] = phrases[2];
            PhrasesArranged[3] = phrases[3];
            PhrasesArranged[4] = phrases[4];
            bool b = true;
            DateTime aux;
            string auxstring;
            while (b)
            {
                b = false;
                for (int i = 0; i < 4; i++)
                    if (TimevsOther[i] > TimevsOther[i + 1])
                    {
                        aux = TimevsOther[i];
                        TimevsOther[i] = TimevsOther[i + 1];
                        TimevsOther[i + 1] = aux;

                        auxstring = PhrasesArranged[i];
                        PhrasesArranged[i] = PhrasesArranged[i + 1];
                        PhrasesArranged[i + 1] = auxstring;

                        b = true;
                    }
            }
            for (int i = 0; i < 5; i++)
                if (TimevsOther[i] != new DateTime())
                    c.Items.Add(PhrasesArranged[i]);

            GamePlay.NumberOfSavedGames = c.Items.Count;



            startedCPU = new bool[5];
            for (int i = 0; i < 5; i++)
                startedCPU[i] = true;
            PasswordsCPU = new string[5];
            for (int i1 = 0; i1 < 5; i1++)
            {
                fs = new FileStream("Game" + (i1 + 1).ToString() + "vsCPU.data", FileMode.Open);
                br = new BinaryReader(fs);
                if (fs.Length != 0)
                {
                    for (int i2 = 0; i2 < 16; i2++)
                    {
                        GamevsCPU[i1, i2].X = br.ReadInt32();
                        GamevsCPU[i1, i2].Y = br.ReadInt32();
                    }
                    Name1 = br.ReadString();
                    Name2 = br.ReadString();
                    VerifyCPU[i1, 0] = Name1;
                    VerifyCPU[i1, 1] = Name2;
                    TimevsCPU[i1] = new DateTime(br.ReadInt32(), br.ReadInt32(), br.ReadInt32(), br.ReadInt32(), br.ReadInt32(), br.ReadInt32());
                    phrasesCPU[i1] = Name1 + "   " + TimevsCPU[i1].Day + "/" + TimevsCPU[i1].Month + "/" + TimevsCPU[i1].Year + " ";
                    //Name1 +"   " + time2CPU.Day + "/" + time2CPU.Month + "/" + time2CPU.Year + " " 
                    if (TimevsCPU[i1].Hour < 10)
                        phrasesCPU[i1] += "0" + TimevsCPU[i1].Hour + ":";
                    else
                        phrasesCPU[i1] += TimevsCPU[i1].Hour + ":";
                    if (TimevsCPU[i1].Minute < 10)
                        phrasesCPU[i1] += "0" + TimevsCPU[i1].Minute + ":";
                    else
                        phrasesCPU[i1] += TimevsCPU[i1].Minute + ":";
                    if (TimevsCPU[i1].Second < 10)
                        phrasesCPU[i1] += "0" + TimevsCPU[i1].Second;
                    else
                        phrasesCPU[i1] += TimevsCPU[i1].Second;
                    whostarted[0, i1] = br.ReadInt32();
                    TurnvsCPU[i1, 0] = br.ReadInt32();
                    if (TurnvsCPU[i1, 0] % 2 == 1)
                        TurnvsCPU[i1, 1] = br.ReadInt32();
                    if (br.PeekChar() != -1)
                    {
                        PasswordsCPU[i1] = br.ReadString();
                        phrasesCPU[i1] += "   (LOCKED)";
                    }
                    else
                        PasswordsCPU[i1] = "";
                }
                br.Close();
                fs.Close();
            }

            for (int i = 0; i < VerifyCPU.GetLength(0); i++)
                for (int j = 0; j < VerifyCPU.GetLength(1); j++)
                    if (VerifyCPU[i, j] == null)
                        VerifyCPU[i, j] = "";

            PhrasesArrangedCPU = new string[5];
            PhrasesArrangedCPU[0] = phrasesCPU[0];
            PhrasesArrangedCPU[1] = phrasesCPU[1];
            PhrasesArrangedCPU[2] = phrasesCPU[2];
            PhrasesArrangedCPU[3] = phrasesCPU[3];
            PhrasesArrangedCPU[4] = phrasesCPU[4];
            b = true;
            while (b)
            {
                b = false;
                for (int i = 0; i < 4; i++)
                    if (TimevsCPU[i] > TimevsCPU[i + 1])
                    {
                        aux = TimevsCPU[i];
                        TimevsCPU[i] = TimevsCPU[i + 1];
                        TimevsCPU[i + 1] = aux;

                        auxstring = PhrasesArrangedCPU[i];
                        PhrasesArrangedCPU[i] = PhrasesArrangedCPU[i + 1];
                        PhrasesArrangedCPU[i + 1] = auxstring;

                        b = true;
                    }
            }
            for (int i = 0; i < 5; i++)
                if (TimevsCPU[i] != new DateTime())
                    cCPU.Items.Add(PhrasesArrangedCPU[i]);

            GamePlay.NumberOfSavedGamesCPU = cCPU.Items.Count;
        }
        

        bool Sett = false;
        bool Help = false;
        bool Vol = false;
        bool Colors = false;
        Button help = new Button();
        Button volume = new Button();
        Button ColorsButton = new Button();
        Button reset = new Button();
        Button off = new Button();
        Button on = new Button();
        RichTextBox t = new RichTextBox();
        private void SettingsClick(object sender, EventArgs e)
        {
            Sett = !Sett;

            if (Sett)
            {
                exitgame.Enabled = false;
                start.Enabled = false;

                this.Controls.Add(help);


                this.Controls.Add(volume);


                this.Controls.Add(ColorsButton);
            }
            else
            {
               
                start.Enabled = true;
                exitgame.Enabled = true;
                this.Controls.Remove(volume);
                this.Controls.Remove(help);
                this.Controls.Remove(ColorsButton);
              
            }
        }
        private void VolumeClick(object sender, EventArgs e)
        {
            Vol = !Vol;

            if (Vol)
            {
                help.Enabled = false;
                settings.Enabled = false;
                ColorsButton.Enabled = false;
               

                this.Controls.Add(on);



                this.Controls.Add(off);
            }
            else
            {
                this.Controls.Remove(on);
                this.Controls.Remove(off);
                help.Enabled = true;
                settings.Enabled = true;
                ColorsButton.Enabled = true;
            }

        }


        public static SoundPlayer sp = new SoundPlayer("BackgroundMusic2.wav");
        private void PlaySound(object sender, EventArgs e)
        {
            sp.PlayLooping();
        }
        private void StopSound(object sender, EventArgs e)
        {
            sp.Stop();
        }

        private void HelpClick(object sender, EventArgs e)
        {
            Help = !Help;
            if (Help)
            {
                volume.Enabled = false;
                settings.Enabled = false;
                ColorsButton.Enabled = false;
                
                this.Controls.Add(t);
            }
            else
            {
                this.Controls.Remove(t);
                volume.Enabled = true;
                settings.Enabled = true;
                ColorsButton.Enabled = true;
            }
        }
        Button Gold = new Button();
        Button Silver = new Button();
        Button Green = new Button();
        Button BlueViolet = new Button();
        bool FirstColor = true;
        //Button[] unlock_colors = new Button[6];
        bool[] ColorsUnlocked = new bool[4];
        int[] ColorsChosen = new int[2];
     
        private void ColorClick(object sender, EventArgs e)
        {
            Colors = !Colors;
            if (Colors)
            {
                help.Enabled = false;
                settings.Enabled = false;
                volume.Enabled = false;
                //Help = true;
                //HelpClick(sender, e);

                this.Controls.Add(Gold);



                this.Controls.Add(Silver);

                if (ColorsUnlocked[2])
                    Green.Text = "";
                this.Controls.Add(Green);
                if (ColorsUnlocked[3])
                    BlueViolet.Text = "";

                this.Controls.Add(BlueViolet);
                this.Controls.Add(Equiped[0]);
                this.Controls.Add(Equiped[1]);

               
            }
            else
            {
                this.Controls.Remove(Gold);
                this.Controls.Remove(Silver);
                this.Controls.Remove(Green);
                this.Controls.Remove(BlueViolet);
                this.Controls.Remove(Equiped[0]);
                this.Controls.Remove(Equiped[1]);
                

                help.Enabled = true;
                settings.Enabled = true;
                volume.Enabled = true;

                FileStream fs = new FileStream("Colors.data", FileMode.Create);
                BinaryWriter bw = new BinaryWriter(fs);
                bw.Write(amount_of_gems);
                for (int i = 0; i < 4; i++)
                    bw.Write(ColorsUnlocked[i]);
                for (int i = 0; i < 2; i++)
                    bw.Write(ColorsChosen[i]);
                
                bw.Close();
                fs.Close();


                    
            }

        }

        void Gold_Click(object sender, EventArgs e)
        {
            if(!ColorAlreadyEquiped[0])
            {
                if (FirstColor)
                {
                    GamePlay.player1_color = Brushes.Goldenrod;
                    GamePlay.player1_dark_color = Brushes.DarkGoldenrod;
                    FirstColor = !FirstColor;
                    ColorsChosen[0] = 0;
                    Equiped[0].Location = new Point(Gold.Location.X + Gold.Width, Gold.Location.Y);
                }
                else
                {
                    GamePlay.player2_color = Brushes.Goldenrod;
                    GamePlay.player2_Dark_color = Brushes.DarkGoldenrod;
                    FirstColor = !FirstColor;
                    ColorsChosen[1] = 0;
                    Equiped[1].Location = new Point(Gold.Location.X + Gold.Width, Gold.Location.Y);
                }
                for (int c = 0; c < 4; c++)
                    ColorAlreadyEquiped[c] = false;
                ColorAlreadyEquiped[ColorsChosen[0]] = true;
                ColorAlreadyEquiped[ColorsChosen[1]] = true;
            }

        }
        void Silver_Click(object sender, EventArgs e)
        {
            if(!ColorAlreadyEquiped[1])
            {
                if (FirstColor)
                {
                    GamePlay.player1_color = Brushes.Silver;
                    GamePlay.player1_dark_color = Brushes.DarkGray;
                    FirstColor = !FirstColor;
                    ColorsChosen[0] = 1;
                    Equiped[0].Location = new Point(Silver.Location.X + Silver.Width, Silver.Location.Y);
                }
                else
                {
                    GamePlay.player2_color = Brushes.Silver;
                    GamePlay.player2_Dark_color = Brushes.DarkGray;
                    FirstColor = !FirstColor;
                    ColorsChosen[1] = 1;
                    Equiped[1].Location = new Point(Silver.Location.X + Silver.Width, Silver.Location.Y);
                }
                for (int c = 0; c < 4; c++)
                    ColorAlreadyEquiped[c] = false;
                ColorAlreadyEquiped[ColorsChosen[0]] = true;
                ColorAlreadyEquiped[ColorsChosen[1]] = true;
            }

        }
        void Green_Click(object sender, EventArgs e)
        {
            if (Green.Text == "")
            {
                if(!ColorAlreadyEquiped[2])
                {
                    if (FirstColor)
                    {
                        GamePlay.player1_color = Brushes.ForestGreen;
                        GamePlay.player1_dark_color = Brushes.DarkGreen;
                        FirstColor = !FirstColor;
                        ColorsChosen[0] = 2;
                        Equiped[0].Location = new Point(Green.Location.X + Green.Width, Green.Location.Y);
                    }
                    else
                    {
                        GamePlay.player2_color = Brushes.ForestGreen;
                        GamePlay.player2_Dark_color = Brushes.DarkGreen;
                        FirstColor = !FirstColor;
                        ColorsChosen[1] = 2;
                        Equiped[1].Location = new Point(Green.Location.X + Green.Width, Green.Location.Y);
                    }
                    for (int c = 0; c < 4; c++)
                        ColorAlreadyEquiped[c] = false;
                    ColorAlreadyEquiped[ColorsChosen[0]] = true;
                    ColorAlreadyEquiped[ColorsChosen[1]] = true;
                }
            }
            else
            {
                if (amount_of_gems < 50)
                    MessageBox.Show("Sorry, you do not have the enough amount of gems to purchase this color", "Color not purchased", MessageBoxButtons.OK);
                else
                {
                    Green.Text = "";
                    amount_of_gems -= 50;
                    gems.Text = amount_of_gems.ToString();
                    if (FirstColor)
                    {
                        GamePlay.player1_color = Brushes.ForestGreen;
                        GamePlay.player1_dark_color = Brushes.DarkGreen;
                        FirstColor = !FirstColor;
                        ColorsChosen[0] = 2;
                        Equiped[0].Location = new Point(Green.Location.X + Green.Width, Green.Location.Y);
                    }
                    else
                    {
                        GamePlay.player2_color = Brushes.ForestGreen;
                        GamePlay.player2_Dark_color = Brushes.DarkGreen;
                        FirstColor = !FirstColor;
                        ColorsChosen[1] = 2;
                        Equiped[1].Location = new Point(Green.Location.X + Green.Width, Green.Location.Y);
                    }
                    ColorsUnlocked[2] = true;
                    for (int c = 0; c < 4; c++)
                        ColorAlreadyEquiped[c] = false;
                    ColorAlreadyEquiped[ColorsChosen[0]] = true;
                    ColorAlreadyEquiped[ColorsChosen[1]] = true;
                }
            }
        }
        void Violet_Click(object sender, EventArgs e)
        {
            if(BlueViolet.Text=="")
            {
                if(!ColorAlreadyEquiped[3])
                {
                    if (FirstColor)
                    {
                        GamePlay.player1_color = Brushes.BlueViolet;
                        GamePlay.player1_dark_color = Brushes.DarkBlue;
                        FirstColor = !FirstColor;
                        ColorsChosen[0] = 3;
                        Equiped[0].Location = new Point(BlueViolet.Location.X + BlueViolet.Width, BlueViolet.Location.Y);
                    }
                    else
                    {
                        GamePlay.player2_color = Brushes.BlueViolet;
                        GamePlay.player2_Dark_color = Brushes.DarkBlue;
                        FirstColor = !FirstColor;
                        ColorsChosen[1] = 3;
                        Equiped[1].Location = new Point(BlueViolet.Location.X + BlueViolet.Width, BlueViolet.Location.Y);
                    }
                    for (int c = 0; c < 4; c++)
                        ColorAlreadyEquiped[c] = false;
                    ColorAlreadyEquiped[ColorsChosen[0]] = true;
                    ColorAlreadyEquiped[ColorsChosen[1]] = true;
                }

            }
            else
            {
                if (amount_of_gems < 100)
                    MessageBox.Show("Sorry, you do not have the enough amount of gems to purchase this color", "Color not purchased", MessageBoxButtons.OK);
                else
                {
                    BlueViolet.Text = "";
                    amount_of_gems -= 100;
                    gems.Text = amount_of_gems.ToString();
                    if (FirstColor)
                    {
                        GamePlay.player1_color = Brushes.BlueViolet;
                        GamePlay.player1_dark_color = Brushes.DarkBlue;
                        FirstColor = !FirstColor;
                        ColorsChosen[0] = 3;
                        Equiped[0].Location = new Point(BlueViolet.Location.X + BlueViolet.Width, BlueViolet.Location.Y);
                    }
                    else
                    {
                        GamePlay.player2_color = Brushes.BlueViolet;
                        GamePlay.player2_Dark_color = Brushes.DarkBlue;
                        FirstColor = !FirstColor;
                        ColorsChosen[1] = 3;
                        Equiped[1].Location = new Point(BlueViolet.Location.X + BlueViolet.Width, BlueViolet.Location.Y);
                    }
                    ColorsUnlocked[3] = true;
                    for (int c = 0; c < 4; c++)
                        ColorAlreadyEquiped[c] = false;
                    ColorAlreadyEquiped[ColorsChosen[0]] = true;
                    ColorAlreadyEquiped[ColorsChosen[1]] = true;
                }
            }

        }


        bool Start = false;
        bool CPU = false;
        bool Other = false;
        Button vsCPU = new Button();
        Button vsOther = new Button();
        Button NewGamevsCPU = new Button();
        Button load_saved_vsCpu = new Button();
        Button NewGamevsOther = new Button();
        Button load_saved_vsOther = new Button();
        Point p1_position, p2_position;
        private void StartClick(object sender, EventArgs e)
        {
            Start = !Start;

            if (Start)
            {
                settings.Enabled = false;
                exitgame.Enabled = false;
                vsCPU.Location = new Point(start.Location.X - start.Width / 2, start.Location.Y + start.Height);
                vsCPU.BackColor = Color.Transparent;
                vsCPU.ForeColor = Color.BurlyWood;
                vsCPU.Size = new Size(start.Width, start.Height / 2);
                vsCPU.Text = "1 PLAYER";
                vsCPU.FlatStyle = FlatStyle.Flat;
                vsCPU.FlatAppearance.BorderSize = 3;
                vsCPU.FlatAppearance.BorderColor = Color.BurlyWood;
                vsCPU.Font = new Font("Monotype Corsiva", 40, (FontStyle.Italic | FontStyle.Bold), GraphicsUnit.Point);
                vsCPU.Click += new EventHandler(vsCPUClick);
                this.Controls.Add(vsCPU);

                vsOther.Location = new Point(vsCPU.Location.X + vsCPU.Width, vsCPU.Location.Y);

                vsOther.Size = new Size(vsCPU.Width, vsCPU.Height);
                vsOther.Text = "2 PLAYERS";
                vsOther.FlatStyle = FlatStyle.Flat;
                vsOther.FlatAppearance.BorderSize = 3;
                vsOther.FlatAppearance.BorderColor = Color.BurlyWood;
                vsOther.Font = new Font("Monotype Corsiva", 40, (FontStyle.Italic | FontStyle.Bold), GraphicsUnit.Point);
                vsOther.BackColor = Color.Transparent;
                vsOther.ForeColor = Color.BurlyWood;
                vsOther.Click += new EventHandler(vsOtherClick);

                this.Controls.Add(vsOther);

                p1_position = new Point(vsOther.Location.X, vsOther.Location.Y + vsOther.Height + 10);
                l1.Size = new Size(470, 100);
               
                l1.BackColor = Color.White;
                l1.BackColor = Color.FromArgb(100, 0, 0, 0);
                l1.Location = new Point(p1_position.X+30, p1_position.Y + 30);
                l1.Font = new Font("Monotype Corsiva", 15F, (FontStyle.Italic | FontStyle.Bold), GraphicsUnit.Point);
                l1.ForeColor = Color.BurlyWood;

               

                

                t1.Size = new Size(200, 75);
                
                t1.Location = new Point(l1.Location.X, l1.Location.Y + 100);
                t1.Font = new Font("calibri", 12, FontStyle.Regular);

                t1.BackColor = Color.White;
                t1.BringToFront();
                

               
                b1.Size = new Size(100, 50);
                b1.Location = new Point(l1.Location.X + l1.Width - b1.Width-50, l1.Location.Y + 150);
                b1.FlatStyle = FlatStyle.Popup;
                
                b1.BackColor = Color.White;
                b1.BackColor = Color.FromArgb(100, 0, 0, 0);
                b1.ForeColor = Color.BurlyWood;
                b1.Font = new Font("Monotype Corsiva", 15, FontStyle.Regular);
                
                b1.Text = "START";


                p1.Size = new Size(500,250);
                p1.Location = p1_position;
                p1.BackColor = Color.White;
                p1.BackColor = Color.FromArgb(100, 0, 0, 0);


                p2_position = new Point(vsCPU.Location.X, vsCPU.Location.Y + vsCPU.Height + 10);

                l2.Size = new Size(470, 100);
               
                l2.BackColor = Color.White;
                l2.BackColor = Color.FromArgb(100, 0, 0, 0);
                l2.Location = new Point(p2_position.X + 30, p2_position.Y + 30);
                l2.Font = new Font("Monotype Corsiva", 15F, (FontStyle.Italic | FontStyle.Bold), GraphicsUnit.Point);
                l2.ForeColor = Color.BurlyWood;


                t2.Size = new Size(200, 75);
                t2.Location = new Point(l2.Location.X, l2.Location.Y + 100);
                t2.Font = new Font("calibri", 12, FontStyle.Regular);
                t2.BackColor = Color.White;
                t2.BringToFront();

                b2.Size = new Size(100, 50);
                b2.Location = new Point(l2.Location.X + l2.Width - b2.Width-50, l2.Location.Y + 150);
                b2.FlatStyle = FlatStyle.Popup;
                b2.Font = new Font("Monotype Corsiva", 15, FontStyle.Regular);
                b2.BackColor = Color.White;
                b2.BackColor = Color.FromArgb(100, 0, 0, 0);
                //b2.BackColor = Color.White;
                //b2.BackColor = Color.FromArgb(100, 0, 0, 0);
                b2.ForeColor = Color.BurlyWood;


                p2.Size = new Size(500, 250);
                p2.Location = p2_position;
                p2.BackColor = Color.White;
                p2.BackColor = Color.FromArgb(100, 0, 0, 0);
            }
            else
            {
                //CPU = false;
                //Other = false;
                vsCPU.Click -= new EventHandler(vsCPUClick);
                vsOther.Click -= new EventHandler(vsOtherClick);
                this.Controls.Remove(vsOther);
                this.Controls.Remove(vsCPU);
                settings.Enabled = true;
                exitgame.Enabled = true;
            }
        }

        private void vsCPUClick(object sender, EventArgs e)
        {
            CPU = !CPU;

            if (CPU)
            {
                vsOther.Enabled = false;
                start.Enabled = false;

                NewGamevsCPU.Size = new Size(500 / 2, 250 / 2);
                NewGamevsCPU.Location = new Point(vsCPU.Location.X + vsCPU.Width / 2 - NewGamevsCPU.Width / 2, vsCPU.Location.Y + vsCPU.Height);
                NewGamevsCPU.Text = "NEW GAME";
                NewGamevsCPU.FlatStyle = FlatStyle.Flat;
                NewGamevsCPU.FlatAppearance.BorderSize = 3;
                NewGamevsCPU.FlatAppearance.BorderColor = Color.BurlyWood;
                NewGamevsCPU.Font = new Font("Monotype Corsiva", 25F);
                NewGamevsCPU.Click += new EventHandler(NewGamevsCPUClick);
                NewGamevsCPU.BackColor = Color.Transparent;
                NewGamevsCPU.ForeColor = Color.BurlyWood;
                NewGamevsCPU.Enabled = true;
                this.Controls.Add(NewGamevsCPU);


                // load_saved_vsCpu.Location = new Point(start.Location.X - 500 / 2 + 250 / 2, start.Location.Y + 250 + 250 / 2 + 250 / 2);

                load_saved_vsCpu.Size = new Size(500 / 2, 250 / 2);
                load_saved_vsCpu.Location = new Point(NewGamevsCPU.Location.X, NewGamevsCPU.Location.Y + NewGamevsCPU.Height);
                load_saved_vsCpu.Text = "LOAD PREVIOUS";
                load_saved_vsCpu.FlatStyle = FlatStyle.Flat;
                load_saved_vsCpu.FlatAppearance.BorderSize = 3;
                load_saved_vsCpu.FlatAppearance.BorderColor = Color.BurlyWood;
                load_saved_vsCpu.Font = new Font("Monotype Corsiva", 25F);
                load_saved_vsCpu.Click += new EventHandler(SavedGamesvsCPU);
                load_saved_vsCpu.BackColor = Color.Transparent;
                load_saved_vsCpu.ForeColor = Color.BurlyWood;
                load_saved_vsCpu.Enabled = true;
                this.Controls.Add(load_saved_vsCpu);
            }
            else
            {
                NewGamevsCPU.Click -= new EventHandler(NewGamevsCPUClick);
                load_saved_vsCpu.Click -= new EventHandler(SavedGamesvsCPU);
                this.Controls.Remove(NewGamevsCPU);
                this.Controls.Remove(load_saved_vsCpu);
                vsOther.Enabled = true;
                start.Enabled = true;
            }

        }

        private void vsOtherClick(object sender, EventArgs e)
        {
            Other = !Other;
            if (Other)
            {
                vsCPU.Enabled = false;
                start.Enabled = false;
                NewGamevsOther.BackColor = Color.Transparent;
                NewGamevsOther.ForeColor = Color.BurlyWood;
                NewGamevsOther.Size = new Size(500 / 2, 250 / 2);
                NewGamevsOther.Location = new Point(vsOther.Location.X + vsOther.Width / 2 - NewGamevsOther.Width / 2, vsOther.Location.Y + vsOther.Height);
                NewGamevsOther.Text = "NEW GAME";
                NewGamevsOther.FlatStyle = FlatStyle.Flat;
                NewGamevsOther.FlatAppearance.BorderSize = 3;
                NewGamevsOther.FlatAppearance.BorderColor = Color.BurlyWood;
                NewGamevsOther.Font = new Font("Monotype Corsiva", 25F);
                NewGamevsOther.Click += new EventHandler(NewGamevsOtherClick);
                NewGamevsOther.Enabled = true;
                this.Controls.Add(NewGamevsOther);

                load_saved_vsOther.BackColor = Color.Transparent;
                load_saved_vsOther.ForeColor = Color.BurlyWood;
                load_saved_vsOther.Size = new Size(500 / 2, 250 / 2);
                load_saved_vsOther.Location = new Point(NewGamevsOther.Location.X, NewGamevsOther.Location.Y + NewGamevsOther.Height);
                load_saved_vsOther.Text = "LOAD PREVIOUS";
                load_saved_vsOther.FlatStyle = FlatStyle.Flat;
                load_saved_vsOther.FlatAppearance.BorderSize = 3;
                load_saved_vsOther.FlatAppearance.BorderColor = Color.BurlyWood;
                load_saved_vsOther.Font = new Font("Monotype Corsiva", 25F);
                load_saved_vsOther.Click += new EventHandler(SavedGamesvsOther);
                load_saved_vsOther.Enabled = true;
                this.Controls.Add(load_saved_vsOther);

            }
            else
            {
                this.Controls.Remove(NewGamevsOther);
                this.Controls.Remove(load_saved_vsOther);
                NewGamevsOther.Click -= new EventHandler(NewGamevsOtherClick);
                load_saved_vsOther.Click -= new EventHandler(SavedGamesvsOther);
                vsCPU.Enabled = true;
                start.Enabled = true;
            }

        }
        Label l1 = new Label();
        TextBox t1 = new TextBox();
        Button b1 = new Button();
        Panel p1 = new Panel();
        public static string[] Names = new string[2];
        bool NGvsCPU = false;

        private void NewGamevsCPUClick(object sender, EventArgs e)
        {
            b1.Enabled = true;
            NGvsCPU = !NGvsCPU;

            if (NGvsCPU)
            {
                vsCPU.Enabled = false;
                load_saved_vsCpu.Enabled = false;
                //l1.Text = "PLEASE ENTER YOUR USERNAME(3 CHARACTERS MINIMUM, 8 CHARACTERS MAXIMUM, NO SPACES ALLOWED AND CONTAINS AT LEAST ONE ALPHABETICAL LETTER)";
                l1.Text = "Please enter the username of player 1 (this non-empty username should contain at least one alphabetical letter, should not contain any spaces and it's length should be between 3 and 8 characters!)";
                l1.Size = new Size(470, 100);
                l1.Font = new Font("Monotype Corsiva", 15F, (FontStyle.Italic | FontStyle.Bold), GraphicsUnit.Point);
                this.Controls.Add(l1);
                this.Controls.Add(t1);
                b1.Click += new EventHandler(StartGamevsCPUClick);
                b1.Text = "START";
                this.Controls.Add(b1);
                this.Controls.Add(p1);
            }
            else
            {
                this.Controls.Remove(l1);
                this.Controls.Remove(t1);
                this.Controls.Remove(b1);
                this.Controls.Remove(p1);
                t1.Clear();
                for (int i = 0; i < 3; i++)
                    this.Controls.Remove(rock_paper_scissor[i]);

                vsCPU.Enabled = true;
                load_saved_vsCpu.Enabled = true;
                game_ready_to_start = false;
                b1.Click -= new EventHandler(StartGamevsCPUClick);
            }
        }

        bool ContainsLetters(string s)
        {

            int i = 0;
            string s1 = s.ToLower();
            bool contain_letters = false;
            int ascii_of_a = (int)'a';
            int ascii_of_z = (int)'z';

            while (i < s1.Length && !contain_letters)
            {
                if ((int)s1[i] >= ascii_of_a && (int)s1[i] <= ascii_of_z)
                    contain_letters = true;
                i++;
            }
            return contain_letters;
        }

        private void StartGamevsCPUClick(object sender, EventArgs e)
        {

            bool NotAllowedCPU = false;
            if (t1.Text.Length == 0)
                MessageBox.Show("Please enter a non-empty username", "Username not entered", MessageBoxButtons.OK);
            else if (!ContainsLetters(t1.Text))
            {
                t1.Clear();
                MessageBox.Show("Please enter a username with at least one alphabetical letter", "Username not accepted", MessageBoxButtons.OK);
            }
            else if (t1.Text.Contains(" "))
            {
                t1.Clear();
                MessageBox.Show("Please enter a username without spaces", "Username not accepted", MessageBoxButtons.OK);
            }
            else if (t1.Text.Length > 8)
            {
                t1.Clear();
                MessageBox.Show("The entered username is too long, please enter a shorter username", "Username not accepted", MessageBoxButtons.OK);
            }
            else if (t1.Text.Length<3)
            {
                t1.Clear();
                MessageBox.Show("The entered username is too short, please enter a longer username", "Username not accepted", MessageBoxButtons.OK);
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    if (VerifyCPU[i, 0].ToLower() == t1.Text.ToLower())
                    {
                        t1.Clear();
                        MessageBox.Show("There is a previously saved game with this username, you have to finish the previously saved game or delete it in order to use this username", "Game already exists", MessageBoxButtons.OK);
                        NotAllowedCPU = true;
                        break;
                    }
                }
            }
            if (t1.Text.Length != 0 && t1.Text.Length <= 8 && t1.Text.Length >= 3 && !NotAllowedCPU && !t1.Text.Contains(" ") && ContainsLetters(t1.Text))
            {
                Names[0] = t1.Text;
                Names[1] = "CPU";
                PlayAgainstCPU = true;
                if (!game_ready_to_start)
                    Choosing_turn_by_RockPaperScissor();

            }
            if (game_ready_to_start)
            {
                this.Hide();
                GamePlay f2 = new GamePlay();
                f2.ShowDialog();
                this.Close();
            }

        }
        Button[] rock_paper_scissor = new Button[3];

        void Choosing_turn_by_RockPaperScissor()
        {
            for (int i = 0; i < 3; i++)//ha kermel ezaa 3emlit restart eno tie abl chilon le already exist
                this.Controls.Remove(rock_paper_scissor[i]);

            this.Controls.Remove(t1);
            //this.Controls.Remove(b2);
            b1.Enabled = false;

            for (int i = 0; i < 3; i++)
            {
                rock_paper_scissor[i] = new Button();
                rock_paper_scissor[i].Size = new Size(50, 50);
                // rock_paper_scissor[i].Location = new Point(p2.Location.X + i * (p1.Width / 3 )+10, p2.Location.Y + 130);
                
                
                //rock_paper_scissor[i].BackColor = Color.Transparent;
                rock_paper_scissor[i].FlatStyle = FlatStyle.Popup;
                rock_paper_scissor[i].BackColor = Color.White;
                rock_paper_scissor[i].BackColor = Color.FromArgb(100, 0, 0, 0);
                rock_paper_scissor[i].FlatAppearance.BorderSize = 0;
                rock_paper_scissor[i].BringToFront();
                this.Controls.Add(rock_paper_scissor[i]);
            }

            rock_paper_scissor[0].Location = new Point(p1.Location.X + 10, p1.Location.Y + 110);
            rock_paper_scissor[1].Location = new Point(p1.Location.X + p1.Width / 2 - rock_paper_scissor[1].Width / 2, p1.Location.Y + 110);
            rock_paper_scissor[2].Location = new Point(p1.Location.X + p1.Width - rock_paper_scissor[1].Width - 10, p1.Location.Y + 110);

            this.Controls.Add(p1);
            l1.Font = new Font("Monotype Corsiva", 18F, ((FontStyle)((FontStyle.Bold | FontStyle.Italic))), GraphicsUnit.Point, ((byte)(0)));
            l1.BackColor = p1.BackColor;
            l1.Text = Names[0] + ", please choose:";
            l1.Size = new Size(470, 50);


            rock_paper_scissor[0].BackgroundImage = global::StartMenu.Properties.Resources.rock3;
            rock_paper_scissor[1].BackgroundImage = global::StartMenu.Properties.Resources.paper3;
            rock_paper_scissor[2].BackgroundImage = global::StartMenu.Properties.Resources.scissor3;


            rock_paper_scissor[0].BackgroundImageLayout = ImageLayout.Stretch;
            rock_paper_scissor[1].BackgroundImageLayout = ImageLayout.Stretch;
            rock_paper_scissor[2].BackgroundImageLayout = ImageLayout.Stretch;

            rock_paper_scissor[0].Click += new EventHandler(Rock_click);
            rock_paper_scissor[1].Click += new EventHandler(Paper_click);
            rock_paper_scissor[2].Click += new EventHandler(Scissor_click);

        }

        Random gen_for_RPS = new Random();
        bool game_ready_to_start = false;

        void Rock_click(object sender, EventArgs e)
        {
           


            int n = gen_for_RPS.Next(3);



            if (n == 0)//CPU picked Rock
            {

                this.Controls.Remove(rock_paper_scissor[1]);



                rock_paper_scissor[2].BackgroundImage = global::StartMenu.Properties.Resources.rock3; ;
                l1.Text = "It's a TIE, Restart";
                b1.Text = "RESTART";
                b1.Enabled = true;
               


            }
            else if (n == 1)//CPU chosse paper
            {
                for (int i = 0; i < 4; i++)
                    Turns[i] = false;

                Turns[1] = true;

                this.Controls.Remove(rock_paper_scissor[2]);
                l1.Text = "CPU will start the game";
                b1.Text = "START";
                game_ready_to_start = true;
            }
            else//CPU chosse scissor
            {
                for (int i = 0; i < 4; i++)
                    Turns[i] = false;
                Turns[0] = true;
                this.Controls.Remove(rock_paper_scissor[1]);
                l1.Text = Names[0] + " will start the game";
                b1.Text = "START";
                game_ready_to_start = true;
               
            }
            // DateTime d = new DateTime();


            for (double i = 0; i < p1.Width / 2 - rock_paper_scissor[1].Width; i += 10)
            {
                rock_paper_scissor[0].Location = new Point(p1.Location.X + (int)i, p1.Location.Y + 130);

                if (n != 0)//eza tel3it 0 ya3ne rock w faw2a 3am 7arek rock fa bs we7de 7a tet7arak
                    rock_paper_scissor[n].Location = new Point(p1.Location.X + p1.Width - rock_paper_scissor[n].Width - (int)i, p1.Location.Y + 130);
                else
                    rock_paper_scissor[2].Location = new Point(p1.Location.X + p1.Width - rock_paper_scissor[n].Width - (int)i, p1.Location.Y + 130);
            }
            for (int i = 0; i < 3; i++)
                rock_paper_scissor[i].Enabled = false;
           
            b1.Enabled = true;
            NewGamevsCPU.Enabled = false;

        }
        void Paper_click(object sender, EventArgs e)
        {
            /* for (int j=1;j<3;j++)
                 this.Controls.Remove(rock_paper_scissor[j]);*/


            int n = gen_for_RPS.Next(3);



            if (n == 0)//CPU picked Rock
            {
                for (int i = 0; i < 4; i++)
                    Turns[i] = false;

                Turns[0] = true;

                this.Controls.Remove(rock_paper_scissor[2]);
                l1.Text = Names[0] + " will start the game";
                b1.Text = "START";
                game_ready_to_start = true;
                /*this.Hide();
                Form2 f2 = new Form2();
                f2.ShowDialog();
                this.Close();*/
                //turns[2]

            }
            else if (n == 1)//CPU chosse paper
            {

                this.Controls.Remove(rock_paper_scissor[2]);

                /* this.Controls.Remove(rock_paper_scissor[0]);
                 this.Controls.Remove(rock_paper_scissor[1]);*/
                rock_paper_scissor[0].BackgroundImage = global::StartMenu.Properties.Resources.paper3;
                l1.Text = "It's a TIE ,Restart";
                b1.Text = "RESTART";
                b1.Enabled = true;
            }
            else//CPU chosse scissor
            {
                for (int i = 0; i < 4; i++)
                    Turns[i] = false;
                Turns[1] = true;

                this.Controls.Remove(rock_paper_scissor[0]);
                l1.Text = "CPU will start the game";
                b1.Text = "START";
                game_ready_to_start = true;
                /* this.Hide();
                 Form2 f2 = new Form2();
                 f2.ShowDialog();
                 this.Close();*/
                //turns[2]
            }
            // DateTime d = new DateTime();


            for (double i = 0; i < p1.Width / 2 - rock_paper_scissor[1].Width; i += 10)
            {
                rock_paper_scissor[1].Location = new Point(p1.Location.X + (int)i, p1.Location.Y + 130);

                if (n != 1)//eza tel3it =1 ya3ne paper w faw2a 3am 7arek paper fa bs we7de 7a tet7arak
                    rock_paper_scissor[n].Location = new Point(p1.Location.X + p1.Width - rock_paper_scissor[n].Width - (int)i, p1.Location.Y + 130);
                else
                    rock_paper_scissor[0].Location = new Point(p1.Location.X + p1.Width - rock_paper_scissor[n].Width - (int)i, p1.Location.Y + 130);
            }
            for (int i = 0; i < 3; i++)
                rock_paper_scissor[i].Enabled = false;
            /*  tik.Interval = 500;
              tik.Start();
              tik.Tick += new EventHandler(tik_Tick);*/
            b1.Enabled = true;
            NewGamevsCPU.Enabled = false;
        }
        void Scissor_click(object sender, EventArgs e)
        {
            /* for (int j=1;j<3;j++)
                 this.Controls.Remove(rock_paper_scissor[j]);*/


            int n = gen_for_RPS.Next(3);



            if (n == 0)//CPU picked Rock
            {
                for (int i = 0; i < 4; i++)
                    Turns[i] = false;
                Turns[1] = true;

                this.Controls.Remove(rock_paper_scissor[1]);
                l1.Text = "CPU will start the game";
                b1.Text = "START";
                game_ready_to_start = true;


            }
            else if (n == 1)//CPU chosse paper
            {

                for (int i = 0; i < 4; i++)
                    Turns[i] = false;
                Turns[0] = true;

                this.Controls.Remove(rock_paper_scissor[0]);
                l1.Text = Names[0] + " will start the game";
                b1.Text = "START";
                game_ready_to_start = true;
                /*this.Hide();
                Form2 f2 = new Form2();
                f2.ShowDialog();
                this.Close();*/
                //turns[2]
            }
            else//CPU chosse scissor
            {

                this.Controls.Remove(rock_paper_scissor[1]);

                /* this.Controls.Remove(rock_paper_scissor[0]);
                 this.Controls.Remove(rock_paper_scissor[2]);*/
                rock_paper_scissor[0].BackgroundImage = global::StartMenu.Properties.Resources.scissor3;
                l1.Text = "It's a TIE ,Restart";
                b1.Text = "RESTART";
                b1.Enabled = true;


            }
            // DateTime d = new DateTime();


            for (double i = 0; i < p1.Width / 2 - rock_paper_scissor[1].Width; i += 10)
            {
                rock_paper_scissor[2].Location = new Point(p1.Location.X + (int)i, p1.Location.Y + 130);

                if (n != 2)//eza tel3it =2 scisor w faw2a 3am 7arek scisor fa bs we7de 7a tet7arak
                    rock_paper_scissor[n].Location = new Point(p1.Location.X + p1.Width - rock_paper_scissor[n].Width - (int)i, p1.Location.Y + 130);
                else
                    rock_paper_scissor[0].Location = new Point(p1.Location.X + p1.Width - rock_paper_scissor[n].Width - (int)i, p1.Location.Y + 130);
            }
            for (int i = 0; i < 3; i++)
                rock_paper_scissor[i].Enabled = false;
            /* tik.Interval = 500;
             tik.Start();
             tik.Tick += new EventHandler(tik_Tick);*/
            b1.Enabled = true;
            NewGamevsCPU.Enabled = false;
        }


        bool PGvsCPU = false;
        private void SavedGamesvsCPU(object sender, EventArgs e)
        {
            PGvsCPU = !PGvsCPU;
            panel.Location = new Point(vsOther.Location.X, vsOther.Location.Y + vsOther.Height + 10);
            le.Location = new Point(panel.Location.X + 30, panel.Location.Y + 30);
            enter.Location = new Point(panel.Location.X + panel.Width - enter.Width - 50, panel.Location.Y + panel.Height-enter.Height-50);            
            te.Location = new Point(le.Location.X, le.Location.Y + 75);
            back.Location = new Point(panel.Location.X+ 50, panel.Location.Y + panel.Height - back.Height - 50);
            if (PGvsCPU)
            {
                NewGamevsCPU.Enabled = false;
                vsCPU.Enabled = false;

                cCPU.Location = new Point(p1.Location.X + 25, p1.Location.Y + 10);
                cCPU.Font = new Font("calibri", 12F, FontStyle.Regular);
                cCPU.Width = p1.Width-50;
                cCPU.ItemHeight = 100;
                cCPU.DropDownStyle = ComboBoxStyle.DropDownList;
                this.Controls.Add(cCPU);

                b5.Size = new Size(100, 50);
                b5.Location = new Point(p1.Location.X + p1.Width - b5.Width-50, p1.Location.Y + p1.Height - b5.Height-50);
                //b5.BackColor = Color.Transparent;
                b5.BackColor = Color.White;
                b5.BackColor = Color.FromArgb(100, 0, 0, 0);
                b5.ForeColor = Color.BurlyWood;
                b5.FlatAppearance.BorderSize = 0;
                b5.FlatStyle = FlatStyle.Popup;
                b5.Text = "CHOOSE";
                b5.Font = b1.Font;
                b5.BringToFront();
                b5.Click += new EventHandler(LoadSavedvsCPU);
                this.Controls.Add(b5);

                b6.Size = new Size(100, 50);
                b6.Location = new Point(p1.Location.X + 50, p1.Location.Y + p1.Height - b6.Height-50);
                //b6.BackColor = Color.Transparent;
                b6.BackColor = Color.White;
                b6.BackColor = Color.FromArgb(100, 0, 0, 0);
                b6.ForeColor = Color.BurlyWood;
                b6.FlatAppearance.BorderSize = 0;
                b6.FlatStyle = FlatStyle.Popup;
                b6.Text = "DELETE";
                b6.Font = b1.Font;
                b6.BringToFront();
                b6.Click += new EventHandler(DeleteGameCPU);
                this.Controls.Add(b6);
                this.Controls.Add(p1);
            }
            else
            {
                cCPU.SelectedIndex = -1;
                vsCPU.Enabled = true;
                NewGamevsCPU.Enabled = true;
                this.Controls.Remove(cCPU);
                this.Controls.Remove(b5);
                b5.Click -= new EventHandler(LoadSavedvsCPU);
                b6.Click -= new EventHandler(DeleteGameCPU);
                this.Controls.Remove(b6);
                this.Controls.Remove(p1);
            }
        }


        private void LoadSavedvsCPU(object sender, EventArgs e)
        {
            if (cCPU.SelectedItem != null)
            {
                string s = (string)cCPU.SelectedItem;
                string[] arr = s.Split(' ');
                Names[0] = arr[0];
                Names[1] = arr[2];
                PlayAgainstCPU = true;
                int i = 0;
                while (i < 5 && !cCPU.SelectedItem.ToString().Equals(phrasesCPU[i]))
                    i++;

                if (PasswordsCPU[i].Equals(""))
                {
                    startedCPU[i] = false;
                    cCPU.Text = "";
                    cCPU.Items.Clear();

                    this.Hide();
                    GamePlay f2 = new GamePlay();
                    f2.ShowDialog();
                    this.Close();
                }
                else
                {
                    whichpassword = i;
                    load_saved_vsCpu.Enabled = false;
                    this.Controls.Remove(cCPU);
                    this.Controls.Remove(p1);
                    this.Controls.Remove(b5);
                    this.Controls.Remove(b6);
                    this.Controls.Add(back);
                    this.Controls.Add(te);
                    this.Controls.Add(enter);
                    this.Controls.Add(le);
                    this.Controls.Add(panel);
                }


            }
            else
            {
                MessageBox.Show("Please select item from combobox", "Item not selected", MessageBoxButtons.OK);
            }

        }
        bool deleting = false;
        private void DeleteGameCPU(object sender, EventArgs e)
        {
            if (cCPU.SelectedItem != null)
            {
                FileStream fs;
                int i = 0;
                while (i < 5 && !cCPU.SelectedItem.ToString().Equals(phrasesCPU[i]))
                    i++;
                if (PasswordsCPU[i] != "")
                {
                    deleting = true;
                    whichpassword = i;
                    load_saved_vsCpu.Enabled = false;
                    this.Controls.Remove(cCPU);
                    this.Controls.Remove(p1);
                    this.Controls.Remove(b5);
                    this.Controls.Remove(b6);
                    this.Controls.Add(back);
                    this.Controls.Add(te);
                    this.Controls.Add(enter);
                    this.Controls.Add(le);
                    this.Controls.Add(panel);
                }
                else
                {
                    fs = new FileStream("Game" + (i + 1).ToString() + "vsCPU.data", FileMode.Create);
                    fs.Close();
                    VerifyCPU[i, 0] = "";
                    VerifyCPU[i, 1] = "";
                    cCPU.Items.Remove(cCPU.SelectedItem);
                    GamePlay.NumberOfSavedGamesCPU--;
                }
            }
            else
                MessageBox.Show("Please select item from combobox", "Item not selected", MessageBoxButtons.OK);
        }

        Label l2 = new Label();
        TextBox t2 = new TextBox();
        Button b2 = new Button();
        Panel p2 = new Panel();
        bool NGvsOther = false;

        private void NewGamevsOtherClick(object sender, EventArgs e)
        {
            CPU = false;
            NGvsOther = !NGvsOther;


            if (NGvsOther)
            {
                vsOther.Enabled = false;
                load_saved_vsOther.Enabled = false;


                //l2.Text = "PLEASE ENTER PLAYER 1 USERNAME(3 CHARCTERS MINIMUM, 8 CHARACTERS MAXIMUM, NO SPACES ALLOWED AND CONTAINS AT LEAST ONE ALPHABETICAL LETTER)";
                l2.Text = "Please enter the username of player 1 (this non-empty username should contain at least one alphabetical letter, should not contain any spaces and it's length should be between 3 and 8 characters!)";
                l2.Size = new Size(470, 100);
                l2.Font = new Font("Monotype Corsiva", 15F, (FontStyle.Italic | FontStyle.Bold), GraphicsUnit.Point);
                this.Controls.Add(l2);
                this.Controls.Add(t2);
                b2.Text = "ENTER";
                this.Controls.Add(b2);
                b2.Click += new EventHandler(OtherNameClick);
                p2.Size = new Size(500, 250);
                this.Controls.Add(p2);
            }
            else
            {

                t2.Clear();
                this.Controls.Remove(t2);
                this.Controls.Remove(l2);
                this.Controls.Remove(b2);
                this.Controls.Remove(p2);
                vsOther.Enabled = true;
                load_saved_vsOther.Enabled = true;
                this.Controls.Remove(french_arabic[0]);
                this.Controls.Remove(french_arabic[1]);
                b2.Click -= new EventHandler(StartGamevsOtherClick);
                b2.Click -= new EventHandler(OtherNameClick);
                p2.Size = new Size(500, 250);
                
            }
        }

        private void OtherNameClick(object sender, EventArgs e)
        {
            if (t2.Text.Length == 0)
                MessageBox.Show("Please enter a non-empty username", "Userame not entered", MessageBoxButtons.OK);
            else if (!ContainsLetters(t2.Text))
            {
                t2.Clear();
                MessageBox.Show("Please enter a username with at least one alphabetical letter", "Username not accepted", MessageBoxButtons.OK);
            }
            else if (t2.Text.Contains(" "))
            {
                t2.Clear();
                MessageBox.Show("Please enter a username without spaces", "Userame not accepted", MessageBoxButtons.OK);
            }
            else if (t2.Text.Length > 8)
            {
                t2.Clear();
                MessageBox.Show("The entered username is too long, please enter a shorter username", "Username not accepted", MessageBoxButtons.OK);
            }
            else if (t2.Text.Length < 3)
            {
                t2.Clear();
                MessageBox.Show("The entered username is too short, please enter a longer username", "Username not accepted", MessageBoxButtons.OK);
            }
            else
            {
                Names[0] = t2.Text;
                //l2.Text = "PLEASE ENTER PLAYER 2 USERNAME(3 CHARACTERS MINIMUM, 8 CHARACTERS MAXIMUM, NO SPACES ALLOWED AND CONTAINS AT LEAST ONE ALPHABETICAL LETTER)";
                l2.Text = "Please enter the username of player 2 (this non-empty username should contain at least one alphabetical letter, should not contain any spaces and it's length should be between 3 and 8 characters!)";
                b2.Text = "START";
                b2.Click -= new EventHandler(OtherNameClick);
                b2.Click += new EventHandler(StartGamevsOtherClick);
                t2.Clear();
            }
        }

        private void StartGamevsOtherClick(object sender, EventArgs e)
        {
            if (t2.Text.Length == 0)
                MessageBox.Show("Please enter a non-empty username", "Userame not entered", MessageBoxButtons.OK);
            else if (!ContainsLetters(t2.Text))
            {
                t2.Clear();
                MessageBox.Show("Please enter a username with at least one alphabetical letter", "Username not accepted", MessageBoxButtons.OK);
            }
            else if (t2.Text.Contains(" "))
            {
                t2.Clear();
                MessageBox.Show("Please enter a username without spaces", "Userame not accepted", MessageBoxButtons.OK);
            }
            else if (t2.Text.Length > 8)
            {
                t2.Clear();
                MessageBox.Show("The entered username is too long, please enter a shorter username", "Username not accepted", MessageBoxButtons.OK);
            }
            else if (t2.Text.Length < 3)
            {
                t2.Clear();
                MessageBox.Show("The entered username is too short, please enter a longer username", "Username not accepted", MessageBoxButtons.OK);
            }
            else if (t2.Text.ToLower() == Names[0].ToLower())
            {
                t2.Clear();
                MessageBox.Show("Please enter another username", "Username already entered", MessageBoxButtons.OK);
            }
            bool NotAllowed = false;
            for (int i = 0; i < 5; i++)
            {
                if (Verify[i, 0].ToLower() == Names[0].ToLower())
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if (Verify[i, j].ToLower() == t2.Text.ToLower())
                        {
                            t2.Clear();
                            MessageBox.Show("There is a previously saved game with these two usernames, you have to finish the previously saved game or delete it in order to use these two usernames", "Game already exists", MessageBoxButtons.OK);
                            NotAllowed = true;
                            break;
                        }
                    }
                }
                if (Verify[i, 0].ToLower() == t2.Text.ToLower())
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if (Verify[i, j].ToLower() == Names[0].ToLower())
                        {
                            t2.Clear();
                            MessageBox.Show("There is a previously saved game with these two usernames, you have to finish the previously saved game or delete it in order to use these two usernames", "Game already exists", MessageBoxButtons.OK);
                            NotAllowed = true;
                            break;
                        }
                    }
                }
                if (NotAllowed)
                    break;
            }
            if (t2.Text != Names[0] && t2.Text.Length != 0 && t2.Text.Length <= 8 && t2.Text.Length>=3 && !NotAllowed && !t2.Text.Contains(" ") && ContainsLetters(t2.Text))
            {
                Names[1] = t2.Text;
                //c.Items.Clear();
                this.Controls.Remove(t2);
                this.Controls.Remove(p2);
                this.Controls.Remove(b2);
                Choosing_turn_by_coin();
            }
        }
        Button[] french_arabic = new Button[2];//indx 0 for french ;index 1 for arabic

        void Choosing_turn_by_coin()
        {

            p2.Size = new Size(380, 250);
            NewGamevsCPU.Enabled = false;

            french_arabic[0] = new Button();
            french_arabic[1] = new Button();
            l2.Font = new Font("Monotype Corsiva", 18F, ((FontStyle)((FontStyle.Bold | FontStyle.Italic))), GraphicsUnit.Point, ((byte)(0)));
            l2.BackColor = p2.BackColor;
            l2.Text = Names[0] + ", please choose the side:";
            l2.Size = new Size(350, 70);

            french_arabic[0].Size = new Size(50, 50);
            french_arabic[1].Size = french_arabic[0].Size;
            french_arabic[0].Location = new Point(p2.Location.X + 50, p2.Location.Y + 130);
            french_arabic[1].Location = new Point(p2.Location.X + p2.Width -french_arabic[1].Width - 50, p2.Location.Y + 130);
            


            french_arabic[0].BackgroundImage = global::StartMenu.Properties.Resources.FrenchCoin;
            french_arabic[1].BackgroundImage = global::StartMenu.Properties.Resources.arabicCoin;
            french_arabic[0].BackgroundImageLayout = ImageLayout.Stretch;
            french_arabic[1].BackgroundImageLayout = ImageLayout.Stretch;

            for (int i = 0; i < 2; i++)
            {
                french_arabic[i].BackColor = p2.BackColor;
                french_arabic[i].FlatStyle = FlatStyle.Flat;
                french_arabic[i].FlatAppearance.BorderSize = 0;
            }


            french_arabic[0].BringToFront();
            french_arabic[1].BringToFront();



            this.Controls.Add(french_arabic[0]);
            this.Controls.Add(french_arabic[1]);
            this.Controls.Add(p2);

            french_arabic[0].Click += new EventHandler(Click_french_coin);
            french_arabic[1].Click += new EventHandler(Click_Arabic_coin);




        }
        bool switching_between_coin = true;
        int number_of_switch = 0;
        int coin_toss_result;
        bool player1_won_the_coin_toss;
       
        Timer tik = new Timer();
        bool choose_french;
        void Click_french_coin(object sender, EventArgs e)
        {
            choose_french = true;
            NewGamevsOther.Enabled = false;
            Random gen = new Random();
            coin_toss_result = gen.Next(2);


            french_arabic[0].Enabled = false;
            french_arabic[1].Enabled = false;

            tik.Interval = 200;
            tik.Start();
            tik.Tick += new EventHandler(throwing_the_coin);


        }
        void Click_Arabic_coin(object sender, EventArgs e)
        {
            choose_french = false;
            NewGamevsOther.Enabled = false;
            Random gen = new Random();
            coin_toss_result = gen.Next(2);


            french_arabic[0].Enabled = false;
            french_arabic[1].Enabled = false;

            tik.Interval = 200;
            tik.Start();
            tik.Tick += new EventHandler(throwing_the_coin);
           
        }

        void throwing_the_coin(object sender, EventArgs e)
        {
            Timer t = (Timer)sender;
            if (number_of_switch != 10)
            {
                if (switching_between_coin)
                {
                    french_arabic[0].FlatAppearance.BorderSize = 1;
                    french_arabic[0].FlatAppearance.BorderColor = Color.BurlyWood;

                    french_arabic[1].FlatAppearance.BorderSize = 0;
                    //  french_arabic[1].FlatAppearance.BorderColor = p2.BackColor;
                    switching_between_coin = false;
                    number_of_switch++;
                }
                else
                {
                    french_arabic[1].FlatAppearance.BorderSize = 1;
                    french_arabic[1].FlatAppearance.BorderColor = Color.BurlyWood;

                    french_arabic[0].FlatAppearance.BorderSize = 0;
                    //french_arabic[0].FlatAppearance.BorderColor = p2.BackColor;
                    switching_between_coin = true;
                }

            }
            else//(number_of_switch==10)
            {
                NewGamevsOther.Enabled = false;

                for (int i = 0; i < 2; i++)
                {
                    french_arabic[i].FlatAppearance.BorderSize = 0;
                    //  french_arabic[i].FlatAppearance.BorderColor = p2.BackColor;
                }

                if (coin_toss_result == 0)
                {
                    if (choose_french)
                        player1_won_the_coin_toss = true;
                    else
                        player1_won_the_coin_toss = false;
                    // turns[0] = true;

                    //this.Controls.Add(french_arabic[0]);i < p2.Width / 2 - french_arabic[0].Width
                  

                    this.Controls.Remove(french_arabic[1]);
                    if (coin_bigger)
                    {
                        coin_bigger = false;
                        french_arabic[0].Size = new Size(french_arabic[0].Width + 50, french_arabic[0].Height + 50);
                        french_arabic[0].BackgroundImageLayout = ImageLayout.Stretch;
                        french_arabic[0].Location = new Point(vsCPU.Location.X + vsCPU.Width / 2 - french_arabic[0].Width, french_arabic[0].Location.Y);

                    }

                    /* for (int i = french_arabic[0].Location.X; i < french_arabic[0].Location.X + p2.Width / 2; i+=10)
                     {
                         french_arabic[0].BringToFront();
                         french_arabic[0].Location = new Point(i, french_arabic[0].Location.Y);
                     }*/



                }
                else
                {
                    if (choose_french)
                        player1_won_the_coin_toss = false;
                    else
                        player1_won_the_coin_toss = true;

                    

                    // this.Controls.Add(french_arabic[1]);
                    this.Controls.Remove(french_arabic[0]);
                    if(coin_bigger)
                    {
                        coin_bigger = false;
                        french_arabic[1].Size = new Size(french_arabic[1].Width + 50, french_arabic[1].Height + 50);
                        french_arabic[1].BackgroundImageLayout = ImageLayout.Stretch;
                        french_arabic[1].Location = new Point(vsCPU.Location.X + vsCPU.Width / 2 - french_arabic[1].Width, french_arabic[1].Location.Y);
                    }
                    


                   /* for (int i = french_arabic[1].Location.X; i < french_arabic[0].Location.X + p2.Width / 2; i--)
                        french_arabic[1].Location = new Point(i, french_arabic[1].Location.Y);*/

                   
                    // turns[2] = true;

                }
                t.Stop();

                tik.Interval = 1000;
                tik.Start();
                tik.Tick += new EventHandler(tik_Tick);


            }



        }

        int time_up = 12;
        bool coin_bigger = true;
        private void tik_Tick(object sender, EventArgs e)
        {
           
            Timer t = (Timer)sender;
            if (time_up == 0)
            {
                t.Stop();
                this.Hide();
                GamePlay f2 = new GamePlay();
                f2.ShowDialog();
                this.Close();
            }      
            else
            {
                time_up-=1;

                if (player1_won_the_coin_toss)
                {
                    

                    
                    for (int i = 1; i < 4; i++)
                        Turns[i] = false;
                    Turns[0] = true;

                    l2.Text = Names[0] + " will start in " + (time_up/2).ToString();

                }
                else
                {
                  

                    for (int i = 0; i < 4; i++)
                        Turns[i] = false;

                    Turns[2] = true;
                    l2.Text = Names[1] + " will start in " + (time_up/2).ToString();
                }

            }


        }
        bool PGvsOther = false;
        private void SavedGamesvsOther(object sender, EventArgs e)
        {
            PGvsOther = !PGvsOther;
            panel.Location = new Point(vsCPU.Location.X, vsCPU.Location.Y + vsCPU.Height + 10);
            le.Location = new Point(panel.Location.X + 30, panel.Location.Y + 30);
            enter.Location = new Point(panel.Location.X + panel.Width - enter.Width - 50, panel.Location.Y + panel.Height - enter.Height - 50);
            te.Location = new Point(le.Location.X, le.Location.Y + 75);
            back.Location = new Point(panel.Location.X + 50, panel.Location.Y + panel.Height - back.Height - 50);
            //panel.Location = new Point(vsCPU.Location.X, vsCPU.Location.Y + vsCPU.Height + 10);
            //le.Location = new Point(panel.Location.X + 30, panel.Location.Y + 30);
            //enter.Location = new Point(le.Location.X + le.Width - enter.Width - 50, le.Location.Y + 150);
            //enter.BackColor = Color.Transparent;
            //te.Location = new Point(le.Location.X, le.Location.Y + 100);
            //back.Location = new Point(le.Location.X, le.Location.Y + 150);
            //back.BackColor = Color.Transparent;
            if (PGvsOther)
            {
                NewGamevsOther.Enabled = false;
                vsOther.Enabled = false;

                b3.Size = new Size(100, 50);
                b3.Location = new Point(p2.Location.X + p2.Width - b3.Width - 50, p2.Location.Y + p2.Height - b3.Height - 50);
                //b3.BackColor = Color.Transparent;
                b3.BackColor = Color.White;
                b3.BackColor = Color.FromArgb(100, 0, 0, 0);
                b3.FlatAppearance.BorderSize = 0;
                b3.FlatStyle = FlatStyle.Popup;
                b3.ForeColor = Color.BurlyWood;
                b3.Text = "CHOOSE";
                b3.Font = b2.Font;
                b3.BringToFront();
                b3.Click += new EventHandler(LoadSavedvsOther);
                this.Controls.Add(b3);

                b4.Size = new Size(100, 50);
                b4.Location = new Point(p2.Location.X + 50, p2.Location.Y + p2.Height - b4.Height - 50);
                b4.BackColor = Color.White;
                b4.BackColor = Color.FromArgb(100, 0, 0, 0);
                b4.ForeColor = Color.BurlyWood;
                b4.FlatAppearance.BorderSize = 0;
                b4.FlatStyle = FlatStyle.Popup;
                b4.Text = "DELETE";
                b4.Font = b2.Font;
                b4.BringToFront();
                b4.Click += new EventHandler(DeleteGame);
                this.Controls.Add(b4);

                c.Location = new Point(p2.Location.X+25, p2.Location.Y +10);
                c.Font = new Font("calibri", 12F, FontStyle.Regular);
                c.Width = p2.Width-50;
                c.ItemHeight = 100;
                c.DropDownStyle = ComboBoxStyle.DropDownList;
                this.Controls.Add(c);

                
                this.Controls.Add(p2);
            }
            else
            {
                c.SelectedIndex = -1;
                vsOther.Enabled = true;
                NewGamevsOther.Enabled = true;
                this.Controls.Remove(c);
                this.Controls.Remove(b3);
                b3.Click -= new EventHandler(LoadSavedvsOther);
                b4.Click -= new EventHandler(DeleteGame);
                this.Controls.Remove(b4);
                this.Controls.Remove(p2);
            }
        }

        int whichpassword;
        private void LoadSavedvsOther(object sender, EventArgs e)
        {
            
            if (c.SelectedItem != null)
            {
                string s = (string)c.SelectedItem;
                string[] arr = s.Split(' ');
                Names[0] = arr[0];
                Names[1] = arr[2];

                int i = 0;
                while (i < 5 && !c.SelectedItem.ToString().Equals(phrases[i]))
                    i++;
                if (Passwords[i].Equals(""))
                {
                    started[i] = false;
                    c.Text = "";
                    c.Items.Clear();

                    this.Hide();
                    GamePlay f2 = new GamePlay();
                    f2.ShowDialog();
                    this.Close();
                }
                else
                {
                    whichpassword = i;
                    load_saved_vsOther.Enabled = false;
                    this.Controls.Remove(c);
                    this.Controls.Remove(p2);
                    this.Controls.Remove(b3);
                    this.Controls.Remove(b4);
                    this.Controls.Add(back);
                    this.Controls.Add(te);
                    this.Controls.Add(enter);
                    this.Controls.Add(le);
                    this.Controls.Add(panel);
                }
            }
            else
            {
                MessageBox.Show("Please select item from combobox", "Item not selected", MessageBoxButtons.OK);
            }

        }
        private void EnterPassword(object sender, EventArgs e)
        {
            if (te.Text.Equals(""))
                MessageBox.Show("Please enter a non-empty password", "Password not entered", MessageBoxButtons.OK);
            else if (te.Text != Passwords[whichpassword] && !CPU)
            {
                te.Clear();
                MessageBox.Show("The password you entered is wrong, please enter another one", "Wrong Password", MessageBoxButtons.OK);
            }
            else if (te.Text != PasswordsCPU[whichpassword] && CPU)
            {
                te.Clear();
                MessageBox.Show("The password you entered is wrong, please enter another one", "Wrong Password", MessageBoxButtons.OK);
            }
            else if (!deleting)
            {
                if (CPU)
                {
                    startedCPU[whichpassword] = false;
                    cCPU.Text = "";
                    cCPU.Items.Clear();
                }
                else
                {
                    started[whichpassword] = false;
                    c.Text = "";
                    c.Items.Clear();
                }

                this.Hide();
                GamePlay f2 = new GamePlay();
                f2.ShowDialog();
                this.Close();
            }
            else
            {
                FileStream fs;
                if (CPU)
                {
                    fs = new FileStream("Game" + (whichpassword + 1).ToString() + "vsCPU.data", FileMode.Create);
                    fs.Close();
                    VerifyCPU[whichpassword, 0] = "";
                    VerifyCPU[whichpassword, 1] = "";
                    PasswordsCPU[whichpassword] = "";
                    cCPU.Items.Remove(cCPU.SelectedItem);
                    GamePlay.NumberOfSavedGamesCPU--;
                }
                else
                {
                    fs = new FileStream("Game" + (whichpassword + 1).ToString() + ".data", FileMode.Create);
                    fs.Close();
                    Verify[whichpassword, 0] = "";
                    Verify[whichpassword, 1] = "";
                    Passwords[whichpassword] = "";
                    c.Items.Remove(c.SelectedItem);
                    GamePlay.NumberOfSavedGames--;
                }
                BackToComboBox(sender, e);
            }
        }
        private void BackToComboBox(object sender, EventArgs e)
        {
            if (CPU)
            {
                cCPU.SelectedIndex = -1;
                this.Controls.Add(cCPU);
                this.Controls.Add(b5);
                this.Controls.Add(b6);
                this.Controls.Add(p1);
                b5.BringToFront();
                b6.BringToFront();
                load_saved_vsCpu.Enabled = true;
            }
            else
            {
                c.SelectedIndex = -1;
                this.Controls.Add(c);
                this.Controls.Add(p2);
                this.Controls.Add(b3);
                b3.BringToFront();
                this.Controls.Add(b4);
                b4.BringToFront();
                load_saved_vsOther.Enabled = true;
            }
            PlayAgainstCPU = false;
            te.Clear();
            this.Controls.Remove(back);
            this.Controls.Remove(te);
            this.Controls.Remove(enter);
            this.Controls.Remove(le);
            this.Controls.Remove(panel);


        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void DeleteGame(object sender, EventArgs e)
        {
            if (c.SelectedItem != null)
            {
                FileStream fs;
                int i = 0;
                while (i < 5 && !c.SelectedItem.ToString().Equals(phrases[i]))
                    i++;
                if (Passwords[i] != "")
                {
                    deleting = true;
                    whichpassword = i;
                    load_saved_vsOther.Enabled = false;
                    this.Controls.Remove(c);
                    this.Controls.Remove(p2);
                    this.Controls.Remove(b3);
                    this.Controls.Remove(b4);
                    this.Controls.Add(back);
                    this.Controls.Add(te);
                    this.Controls.Add(enter);
                    this.Controls.Add(le);
                    this.Controls.Add(panel);
                }
                else
                {
                    fs = new FileStream("Game" + (i + 1).ToString() + ".data", FileMode.Create);
                    fs.Close();
                    Verify[i, 0] = "";
                    Verify[i, 1] = "";
                    c.Items.Remove(c.SelectedItem);
                    GamePlay.NumberOfSavedGames--;
                }
            }
            else
                MessageBox.Show("Please select item from combobox", "Item not selected", MessageBoxButtons.OK);
        }
    }
}
