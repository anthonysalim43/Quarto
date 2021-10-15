using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Media;

namespace StartMenu
{
    public partial class GamePlay : Form
    {
        public GamePlay()
        {
            InitializeComponent();
        }

        bool[] Turns=new bool[4];//bimaslo l jemal ye3ne l index 0 w 1 bimaslo player1 select shape(0) w position(1) w 2 w 3 bimaslo l player2
        Label t = new Label();

        public Point AA;
        int side;

        Color circle_color = Color.DarkGoldenrod;
        Button b;
        Button quarto = new Button();
        Shape s = new Shape();
        Position p = new Position();



        public static Brush player1_color;
        public static Brush player1_dark_color;

        public static  Brush player2_color;
        public static  Brush player2_Dark_color;

        Button Save = new Button();
        Button Quit = new Button();

        string[] Phrases, PhrasesCPU;

        bool cpu_turn = true;
        int index_shape_cpu_choose;

        Button Back = new Button();
        Label l = new Label();
        Button Replace = new Button();
        Panel panel = new Panel();
        ComboBox c = new ComboBox();
        Button Yes = new Button();
        Button No = new Button();

        int index;
        TextBox tp = new TextBox();
        Label lp = new Label();
        string[,] VerifyPass;
        Label lw = new Label();

        public static int NumberOfSavedGames, NumberOfSavedGamesCPU;
        int whostarted;
       // int velocity = 20;
        private void Form2_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = global::StartMenu.Properties.Resources.Background;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Refresh();

            try
            {

                this.Controls.Add(MainMenu.gems);
                this.Controls.Add(MainMenu.gems_image);
            }
            catch (ObjectDisposedException)
            {
                
            }

            AA = new Point(500, 200);
            side = 400;
            Point centre_rectangle = new Point(AA.X + 200, AA.Y + 200);
            int distance_between_2circle = 5;

            /* enter.Size = new Size(100, 50);
            enter.BackColor = Color.White;
            enter.BackColor = Color.FromArgb(100, 0, 0, 0);
            enter.ForeColor = Color.BurlyWood;
            enter.Text = "ENTER";
            enter.Font = new Font("Monotype Corsiva", 15, FontStyle.Regular);
            enter.BringToFront();
            enter.FlatStyle = FlatStyle.Popup;
            enter.Click += new EventHandler(EnterPassword);

            le.Size = new Size(470, 50);
            le.BackColor = Color.White;
            le.BackColor = Color.FromArgb(100, 0, 0, 0);
            le.Text = "In order to continue, please enter the password of the chosen game:";
            le.Font = new Font("Monotype Corsiva", 15F, (FontStyle.Italic | FontStyle.Bold), GraphicsUnit.Point);
            le.ForeColor = Color.BurlyWood;

             panel.Location = new Point(vsOther.Location.X, vsOther.Location.Y + vsOther.Height + 10);
            le.Location = new Point(panel.Location.X + 30, panel.Location.Y + 30);
            enter.Location = new Point(panel.Location.X + panel.Width - enter.Width - 50, panel.Location.Y + panel.Height-enter.Height-50);            
            te.Location = new Point(le.Location.X, le.Location.Y + 75);
            back.Location = new Point(panel.Location.X+ 50, panel.Location.Y + panel.Height - enter.Height - 50);*/
            
            panel.Size = new Size(500, 250);
            panel.Location = new Point(50, 500);
            panel.BackColor = Color.White;
            panel.BackColor = Color.FromArgb(100, 0, 0, 0);

            l.Location = new Point(panel.Location.X + 30, panel.Location.Y + 30);
            l.Size = new Size(panel.Width - 30, 100);
            //l.Text = "YOU ARE ONLY ALLOWED TO SAVE 5 GAMES, PLEASE CHOOSE IF YOU WANT TO REPLACE ONE OF THE PREVIOUS SAVED GAMES OR NOT"
            l.Text = "You are only allowed to save five games, please choose if you want to replace one of the previously saved games";
            l.Font = new Font("Monotype Corsiva", 15F, (FontStyle.Italic | FontStyle.Bold), GraphicsUnit.Point);
            l.BackColor = Color.White;
            l.BackColor = Color.FromArgb(100, 0, 0, 0);
            l.ForeColor = Color.BurlyWood;

            c.Location = new Point(panel.Location.X + 25, panel.Location.Y + l.Height + 10);
            c.Font = new Font("calibri", 12F, FontStyle.Regular);
            c.Width = panel.Width - 50;
            c.ItemHeight = 100;
            c.DropDownStyle = ComboBoxStyle.DropDownList;

            Replace.Size = new Size(100, 50);
            Replace.Location = new Point(panel.Location.X + panel.Width - Replace.Width - 50, panel.Location.Y + panel.Height - Replace.Height - 50);
            Replace.BackColor = Color.White;
            Replace.BackColor = Color.FromArgb(100, 0, 0, 0);
            Replace.FlatStyle = FlatStyle.Popup;
            Replace.Text = "REPLACE";
            Replace.Font = new Font("Monotype Corsiva", 15, FontStyle.Regular);
            Replace.BringToFront();
            Replace.ForeColor = Color.BurlyWood;
            Replace.Click += new EventHandler(ReplaceGame);

            Back.Size = new Size(100, 50);
            Back.Location = new Point(panel.Location.X + 50, panel.Location.Y + panel.Height - Back.Height - 50);         
            Back.BackColor = Color.White;
            Back.BackColor = Color.FromArgb(100, 0, 0, 0);
            Back.FlatStyle = FlatStyle.Popup;
            Back.Text = "BACK";
            Back.Font = new Font("Monotype Corsiva", 15, FontStyle.Regular);
            Back.ForeColor = Color.BurlyWood;
            Back.BringToFront();
            Back.Click += new EventHandler(BACK);

            
            lp.Size = new Size(panel.Width-30, 100);
            lp.BackColor = Color.White;
            lp.BackColor = Color.FromArgb(100, 0, 0, 0);
            lp.Text = "Do you want to add a password to protect your saved game?";
            lp.Location = new Point(panel.Location.X + 30, panel.Location.Y + 30);
            lp.Font = new Font("Monotype Corsiva", 15F, (FontStyle.Italic | FontStyle.Bold), GraphicsUnit.Point);
            lp.ForeColor = Color.BurlyWood;
            //lp.BringToFront();

            No.Size = new Size(100, 50);
            No.Location = new Point(panel.Location.X + 50, lp.Location.Y+150);
            No.BackColor = Color.White;
            No.BackColor = Color.FromArgb(100, 0, 0, 0);
            No.FlatStyle = FlatStyle.Popup;
            No.Text = "NO";
            No.ForeColor = Color.BurlyWood;
            No.Font = new Font("Monotype Corsiva", 15, FontStyle.Regular);
            No.BringToFront();
            No.Click += new EventHandler(YesNoEnterClick);

            Yes.Size = new Size(100, 50);
            Yes.Location = new Point(panel.Location.X + panel.Width - Yes.Width - 50, lp.Location.Y+150);
            Yes.BackColor = Color.White;
            Yes.BackColor = Color.FromArgb(100, 0, 0, 0);
            Yes.FlatStyle = FlatStyle.Popup;
            Yes.Text = "YES";
            Yes.Font = new Font("Monotype Corsiva", 15, FontStyle.Regular);
            Yes.BringToFront();
            Yes.ForeColor = Color.BurlyWood;
            Yes.Click += new EventHandler(YesNoEnterClick);

            tp.Size = new Size(200, 75);
            tp.Location = new Point(lp.Location.X, lp.Location.Y + 100);
            tp.Font = new Font("calibri", 12, FontStyle.Regular);
            tp.UseSystemPasswordChar = true;
            tp.BackColor = Color.White;
            tp.BringToFront();

            lw.Size = new Size(400, 100);
            lw.BackColor = Color.Transparent;
            lw.Location = new Point(AA.X, AA.Y + side + 20);
            lw.ForeColor = Color.BurlyWood;
            lw.Font = new Font("Monotype Corsiva",30F, FontStyle.Bold);
            lw.TextAlign = ContentAlignment.MiddleCenter;

            for (int i = 0; i < 4; i++)
            {
                Turns[i] = MainMenu.Turns[i];
                if (Turns[i])
                    whostarted = i;
            }
            VerifyPass = new string[2, 5];
            for (int i = 0; i < 5; i++)
            {
                VerifyPass[1, i] = MainMenu.Passwords[i];
                VerifyPass[0, i] = MainMenu.PasswordsCPU[i];
            }

            int k = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    b = new Button();
                    b.Size = new Size(50, 50);
                    Point top_button_position = new Point(centre_rectangle.X - b.Width / 2,
                                                centre_rectangle.Y - side / 2 + distance_between_2circle);


                    b.Location = new Point(top_button_position.X - j * (distance_between_2circle + b.Width) + i * (distance_between_2circle + b.Width)
                        , top_button_position.Y + j * (distance_between_2circle + b.Width) + i * (distance_between_2circle + b.Width));
                    b.BackColor = Color.MidnightBlue;
                    b.FlatStyle = FlatStyle.Flat;
                    b.FlatAppearance.BorderSize = 0;
                    b.Paint += new PaintEventHandler(draw_a_circle);
                    p.Positionn[k] = b;

                    k++;
                    this.Controls.Add(b);//To display the button you created dynamicaly
                }
            }

            k = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    b = new Button();
                    b.Size = new Size(50, 50);
                    b.Location = new Point(AA.X + side + 100 + j * (distance_between_2circle + b.Size.Width), AA.Y + i * (distance_between_2circle + b.Size.Height + 10) + 30);

                    b.FlatStyle = FlatStyle.Flat;
                    b.FlatAppearance.BorderSize = 0;
                    b.BackColor = Color.Transparent;
                    s.Shapes[k] = b;
                    k++;
                    this.Controls.Add(b);
                }
            }

            //player1_color = Brushes.ForestGreen;
            //player1_dark_color = Brushes.DarkGreen;

            for (int j = 0; j < 8; j++)
            {
                s.Color[0, j] = player1_color;
                s.Color[1, j] = player1_dark_color;
            }
           // player2_color = Brushes.Silver;
            //player2_Dark_color = Brushes.DarkGray;

            // player2_color = Brushes.BlueViolet;
             //player2_Dark_color = Brushes.DarkBlue;
            
             // player2_color = Brushes.DarkOrange;
           // player2_Dark_color = Brushes.Brown;
            


            for (int j = 8; j < 16; j++)
            {
                s.Color[0, j] = player2_color;
                s.Color[1, j] = player2_Dark_color;
            }

            quarto.Font = new Font("Monotype Corsiva", 20, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            quarto.Size = new Size(125, 92);
            quarto.Location = new Point(AA.X + side / 2 - quarto.Width / 2, AA.Y - 100);
            quarto.BackColor =Color.Transparent;
            quarto.FlatStyle = FlatStyle.Flat;
            quarto.FlatAppearance.BorderSize = 0;
            quarto.Text = "Quarto";
            quarto.ForeColor = Color.BurlyWood;       
            quarto.Enabled = false;
            this.Controls.Add(quarto);
            quarto.Click += new EventHandler(quarto_click);


            s.Shapes[0].Paint += new PaintEventHandler(b1_draw);
            s.Red[0] = true;
            s.Big[0] = true;
            s.Circle[0] = false;
            s.CircleInMiddle[0] = false;


            s.Shapes[1].Paint += new PaintEventHandler(b2_draw);
            s.Red[1] = true;
            s.Big[1] = true;
            s.Circle[1] = false;
            s.CircleInMiddle[1] = true;

            s.Shapes[2].Paint += new PaintEventHandler(b3_draw);
            s.Red[2] = true;
            s.Big[2] = false;
            s.Circle[2] = false;
            s.CircleInMiddle[2] = false;

            s.Shapes[3].Paint += new PaintEventHandler(b4_draw);
            s.Red[3] = true;
            s.Big[3] = false;
            s.Circle[3] = false;
            s.CircleInMiddle[3] = true;

            s.Shapes[4].Paint += new PaintEventHandler(b5_draw);
            s.Red[4] = true;
            s.Big[4] = true;
            s.Circle[4] = true;
            s.CircleInMiddle[4] = false;

            s.Shapes[5].Paint += new PaintEventHandler(b6_draw);
            s.Red[5] = true;
            s.Big[5] = true;
            s.Circle[5] = true;
            s.CircleInMiddle[5] = true;

            s.Shapes[6].Paint += new PaintEventHandler(b7_draw);
            s.Red[6] = true;
            s.Big[6] = false;
            s.Circle[6] = true;
            s.CircleInMiddle[6] = false;

            s.Shapes[7].Paint += new PaintEventHandler(b8_draw);
            s.Red[7] = true;
            s.Big[7] = false;
            s.Circle[7] = true;
            s.CircleInMiddle[7] = true;

            s.Shapes[8].Paint += new PaintEventHandler(b9_draw);
            s.Red[8] = false;
            s.Big[8] = true;
            s.Circle[8] = false;
            s.CircleInMiddle[8] = false;

            s.Shapes[9].Paint += new PaintEventHandler(b10_draw);
            s.Red[9] = false;
            s.Big[9] = true;
            s.Circle[9] = false;
            s.CircleInMiddle[9] = true;

            s.Shapes[10].Paint += new PaintEventHandler(b11_draw);
            s.Red[10] = false;
            s.Big[10] = false;
            s.Circle[10] = false;
            s.CircleInMiddle[10] = false;

            s.Shapes[11].Paint += new PaintEventHandler(b12_draw);
            s.Red[11] = false;
            s.Big[11] = false;
            s.Circle[11] = false;
            s.CircleInMiddle[11] = true;

            s.Shapes[12].Paint += new PaintEventHandler(b13_draw);
            s.Red[12] = false;
            s.Big[12] = true;
            s.Circle[12] = true;
            s.CircleInMiddle[12] = false;

            s.Shapes[13].Paint += new PaintEventHandler(b14_draw);
            s.Red[13] = false;
            s.Big[13] = true;
            s.Circle[13] = true;
            s.CircleInMiddle[13] = true;

            s.Shapes[14].Paint += new PaintEventHandler(b15_draw);
            s.Red[14] = false;
            s.Big[14] = false;
            s.Circle[14] = true;
            s.CircleInMiddle[14] = false;

            s.Shapes[15].Paint += new PaintEventHandler(b16_draw);
            s.Red[15] = false;
            s.Big[15] = false;
            s.Circle[15] = true;
            s.CircleInMiddle[15] = true;


            for (int i = 0; i < 16; i++)
                s.MovedToDeck[i] = false;

            for (int i = 0; i < 16; i++)
            {
                p.Positionn[i].Text = i.ToString();
                p.Positionn[i].Enabled = false;
            }
            for (int i = 0; i < 16; i++)//default value of bool is true,so i should first change them all to false

                p.PositionNotEmpty[i] = false;


            t.Font = new Font("Monotype Corsiva", 22F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            t.FlatStyle = FlatStyle.Flat;
            t.BackColor = Color.Transparent;
            t.ForeColor = Color.BurlyWood;
            //t.FlatAppearance.BorderSize = 0;
            t.Location = new Point(s.Shapes[0].Location.X, s.Shapes[0].Location.Y - 80);
            t.Size = new Size(s.Shapes[0].Width*10, s.Shapes[0].Height);
            this.Controls.Add(t);

            for(int i=0;i<16;i++)
            {
                s.Shapes[i].Click += new EventHandler(Shape_Click);
                p.Positionn[i].Click += new EventHandler(position_Click);
            }

            if (!MainMenu.PlayAgainstCPU)
            {
                for (int i1 = 0; i1 < 5; i1++)
                {
                    if(!MainMenu.started[i1])
                    {
                        for (int i2 = 0; i2 < 16; i2++)
                        {
                            if (MainMenu.GamevsOther[i1, i2] != new Point(0, 0))
                            {

                                this.s.Shapes[i2].Location = MainMenu.GamevsOther[i1, i2];
                                this.s.Shapes[i2].BringToFront();
                                this.s.Shapes[i2].Enabled = false;
                                this.s.Shapes[i2].BackColor = Color.MidnightBlue;
                                this.s.MovedToDeck[i2] = true;
                                int s = 0;
                                while (s < p.Positionn.Length && p.Positionn[s].Location != this.s.Shapes[i2].Location)
                                    s++;
                                if(s!=16)
                                {
                                    p.PositionNotEmpty[s] = true;
                                    p.number_of_position_moved++;
                                    p.Check[0, s] = true;
                                    p.Check[1, s] = this.s.Red[i2];
                                    p.Check[2, s] = this.s.Big[i2];
                                    p.Check[3, s] = this.s.Circle[i2];
                                    p.Check[4, s] = this.s.CircleInMiddle[i2];

                                }
                               
                            }
                            if (p.number_of_position_moved >= 3 && !quarto.Enabled)
                                quarto.Enabled = Winners();
                        }
                        for (int i3 = 0; i3 < 4; i3++)
                            Turns[i3] = false;
                        Turns[MainMenu.TurnvsOther[i1, 0]] = true;
                        if (MainMenu.TurnvsOther[i1, 0] % 2 == 1)
                        {
                            for (int i4 = 0; i4 < 16; i4++)
                                if (!s.MovedToDeck[i4] && i4 != MainMenu.TurnvsOther[i1, 1])
                                {
                                    s.Color[0, i4] = Brushes.Black;
                                    s.Color[1, i4] = Brushes.Gray;
                                    s.Shapes[i4].Enabled = false;
                                }
                            double_click = true;
                            for (int k1 = 0; k1 < 16; k1++)
                            {
                                if (p.PositionNotEmpty[k1])
                                    p.Positionn[k1].Enabled = false;
                                else
                                    p.Positionn[k1].Enabled = true;
                            }
                        }
                        whostarted = MainMenu.whostarted[1, i1];
                    }
                }
            }
            else
            {
                for(int i1=0;i1<5;i1++)
                {
                    if (!MainMenu.startedCPU[i1])
                    {
                        for (int i2 = 0; i2 < 16; i2++)
                        {
                            if (MainMenu.GamevsCPU[i1, i2] != new Point(0, 0))
                            {

                                this.s.Shapes[i2].Location = MainMenu.GamevsCPU[i1, i2];
                                this.s.Shapes[i2].BringToFront();
                                this.s.Shapes[i2].Enabled = false;
                                this.s.Shapes[i2].BackColor = Color.MidnightBlue;
                                this.s.MovedToDeck[i2] = true;
                                int s = 0;
                                while (s < p.Positionn.Length && p.Positionn[s].Location != this.s.Shapes[i2].Location)
                                    s++;
                                p.PositionNotEmpty[s] = true;
                                p.number_of_position_moved++;
                                p.Check[0, s] = true;
                                p.Check[1, s] = this.s.Red[i2];
                                p.Check[2, s] = this.s.Big[i2];
                                p.Check[3, s] = this.s.Circle[i2];
                                p.Check[4, s] = this.s.CircleInMiddle[i2];
                            }
                            if (p.number_of_position_moved >= 3 && !quarto.Enabled)
                                quarto.Enabled = Winners();
                        }

                        for (int i3 = 0; i3 < 4; i3++)
                            Turns[i3] = false;

                        Turns[MainMenu.TurnvsCPU[i1, 0]] = true;
                        if (MainMenu.TurnvsCPU[i1, 0] % 2 == 1)
                        {
                            for (int i4 = 0; i4 < 16; i4++)
                                if (!s.MovedToDeck[i4] && i4 != MainMenu.TurnvsCPU[i1, 1])
                                {
                                    s.Color[0, i4] = Brushes.Black;
                                    s.Color[1, i4] = Brushes.Gray;
                                    s.Shapes[i4].Enabled = false;

                                }
                            s.Shapes[MainMenu.TurnvsCPU[i1, 1]].Enabled = false;
                            for (int k1 = 0; k1 < 16; k1++)
                            {
                                if (p.PositionNotEmpty[k1])
                                    p.Positionn[k1].Enabled = false;
                                else
                                    p.Positionn[k1].Enabled = true;
                            }
                            cpu_turn = false;
                            index_shape_cpu_choose = MainMenu.TurnvsCPU[i1, 1];
                        }
                        whostarted = MainMenu.whostarted[0, i1];
                    }
                }
            }
            int s1 = 0;
            while (s1 < 5 && MainMenu.startedCPU[s1])
                s1++;
            if (MainMenu.PlayAgainstCPU && Turns[1] && s1==5)
                CPU_Select_Shape();

            if (Turns[0])
                t.Text = "Please " + MainMenu.Names[0] + " select the shape";
            else if (Turns[1])
                t.Text = "Please " + MainMenu.Names[0] + " select the position";
            else if (Turns[2])
                t.Text = "Please " + MainMenu.Names[1] + " select the shape";
            else if (Turns[3])
                t.Text = "Please " + MainMenu.Names[1] + " select the position";

            Save.Location = new Point(50, 50);
            Save.Size = new Size(400, 100);
            Save.Text = "Save And Quit";
            Save.BackColor = Color.Transparent;
            Save.ForeColor = Color.BurlyWood;
            Save.FlatStyle = FlatStyle.Flat;
            Save.FlatAppearance.BorderColor = Color.BurlyWood;
            Save.FlatAppearance.BorderSize = 3;
            Save.Font = new Font("Monotype Corsiva", 20F, FontStyle.Bold);
            Save.Click += new EventHandler(SaveAndQuit);
            this.Controls.Add(Save);

            Quit.Location = new Point(50, 200);
            Quit.Size = new Size(400, 100);
            Quit.Text = "Quit Without Saving";
            Quit.BackColor = Color.Transparent;
            Quit.ForeColor = Color.BurlyWood;
            Quit.FlatStyle = FlatStyle.Flat;
            Quit.FlatAppearance.BorderColor = Color.BurlyWood;
            Quit.FlatAppearance.BorderSize = 3;
            Quit.Font = new Font("Monotype Corsiva", 20F, FontStyle.Bold);
            Quit.Click += new EventHandler(QuitWithoutSaving);
            this.Controls.Add(Quit);

            Phrases = MainMenu.PhrasesArranged;
            PhrasesCPU = MainMenu.PhrasesArrangedCPU;

            this.Refresh();
            
        }

        private void QuitWithoutSaving (object sender, EventArgs e)
        {
            if(!Quit.Text.Equals("Back To Main Menu"))
            {
                this.Hide();
                MainMenu f1 = new MainMenu();
                f1.ShowDialog();
                this.Close();
            }
            else
            {
                FileStream fs;
                for(int i=0;i<5;i++)
                {
                    if(!MainMenu.started[i])
                    {
                        fs = new FileStream("Game"+(i+1).ToString()+".data", FileMode.Create);
                        fs.Close();
                    }
                    if(!MainMenu.startedCPU[i])
                    {
                        fs = new FileStream("Game" + (i + 1).ToString() + "vsCPU.data", FileMode.Create);
                        fs.Close();
                    }
                }
                
                this.Hide();
                MainMenu f1 = new MainMenu();
                f1.ShowDialog();
                this.Close();
            }
        }
        private void draw_a_circle(object sender, PaintEventArgs e)
        {
            Button b = (Button)sender;
            e.Graphics.DrawEllipse(new Pen(circle_color, 3), new Rectangle(new Point(0, 0), new Size(b.Size.Width - 2, b.Size.Height - 2)));
        }
        
        Button bb16 = new Button();
        Button bb15 = new Button();

        private void b1_draw(object sender, PaintEventArgs e)
        {
            bb16.Size = new Size(50, 50);
            Point A = new Point(bb16.Width / 4, 0);
            Point B = new Point(bb16.Width, 0);
            Point C = new Point(3 * bb16.Width / 4, bb16.Height / 4);
            Point D = new Point(0, bb16.Height / 4);
            Point[] arr1 = { A, B, C, D };
            e.Graphics.FillPolygon(s.Color[1, 0], arr1);

            Point G = new Point(bb16.Width, 3 * bb16.Height / 4);
            Point F = new Point(3 * bb16.Width / 4, bb16.Height);
            Point E = new Point(0, bb16.Height);
            Point[] arr2 = { D, C, B, G, F, E };
            e.Graphics.FillPolygon(s.Color[0, 0], arr2);

            Point H = new Point(0, 5 * bb16.Height / 8);
            Point I = new Point(3 * bb16.Width / 4, 5 * bb16.Height / 8);
            Point J = new Point(bb16.Width, 3 * bb16.Height / 8);
            Point[] arr3 = { H, I, J };
            e.Graphics.DrawLines(new Pen(s.Color[1, 0], 4), arr3);
        }
        private void b2_draw(object sender, PaintEventArgs e)
        {
            Point A = new Point(bb16.Width / 4, 0);
            Point B = new Point(bb16.Width, 0);
            Point C = new Point(3 * bb16.Width / 4, bb16.Height / 4);
            Point D = new Point(0, bb16.Height / 4);
            Point[] arr1 = { A, B, C, D };
            e.Graphics.FillPolygon(s.Color[1, 1], arr1);

            Point G = new Point(bb16.Width, 3 * bb16.Height / 4);
            Point F = new Point(3 * bb16.Width / 4, bb16.Height);
            Point E = new Point(0, bb16.Height);
            Point[] arr2 = { D, C, B, G, F, E };
            e.Graphics.FillPolygon(s.Color[0, 1], arr2);

            Point H = new Point(0, 5 * bb16.Height / 8);
            Point I = new Point(3 * bb16.Width / 4, 5 * bb16.Height / 8);
            Point J = new Point(bb16.Width, 3 * bb16.Height / 8);
            Point[] arr3 = { H, I, J };
            e.Graphics.DrawLines(new Pen(s.Color[1, 1], 4), arr3);

            e.Graphics.FillEllipse(Brushes.White, new Rectangle(new Point(5 * bb16.Width / 16, bb16.Height / 16), new Size(3 * bb16.Width / 8, bb16.Height / 8)));
        }
        private void b3_draw(object sender, PaintEventArgs e)
        {
            Point A = new Point(bb16.Width / 4, 3 * bb16.Height / 8);
            Point B = new Point(bb16.Width, 3 * bb16.Height / 8);
            Point C = new Point(3 * bb16.Width / 4, 5 * bb16.Height / 8);
            Point D = new Point(0, 5 * bb16.Height / 8);
            Point[] arr1 = { A, B, C, D };
            e.Graphics.FillPolygon(s.Color[1, 2], arr1);

            Point G = new Point(bb16.Width, 3 * bb16.Height / 4);
            Point F = new Point(3 * bb16.Width / 4, bb16.Height);
            Point E = new Point(0, bb16.Height);
            Point[] arr2 = { D, C, B, G, F, E };
            e.Graphics.FillPolygon(s.Color[0, 2], arr2);
        }
        private void b4_draw(object sender, PaintEventArgs e)
        {
            Point A = new Point(bb16.Width / 4, 3 * bb16.Height / 8);
            Point B = new Point(bb16.Width, 3 * bb16.Height / 8);
            Point C = new Point(3 * bb16.Width / 4, 5 * bb16.Height / 8);
            Point D = new Point(0, 5 * bb16.Height / 8);
            Point[] arr1 = { A, B, C, D };
            e.Graphics.FillPolygon(s.Color[1, 3], arr1);

            Point G = new Point(bb16.Width, 3 * bb16.Height / 4);
            Point F = new Point(3 * bb16.Width / 4, bb16.Height);
            Point E = new Point(0, bb16.Height);
            Point[] arr2 = { D, C, B, G, F, E };
            e.Graphics.FillPolygon(s.Color[0, 3], arr2);

            e.Graphics.FillEllipse(Brushes.White, new Rectangle(new Point(5 * bb16.Width / 16, 7 * bb16.Height / 16), new Size(3 * bb16.Width / 8, bb16.Height / 8)));
        }
        private void b5_draw(object sender, PaintEventArgs e)
        {
            bb15.Size = new Size(50, 50);
            e.Graphics.FillRectangle(s.Color[0, 4], new Rectangle(new Point(0, bb15.Height / 8), new Size(bb15.Width, 3 * bb15.Height / 4)));
            e.Graphics.FillEllipse(s.Color[1, 4], new Rectangle(new Point(0, 0), new Size(bb15.Width, bb15.Height / 4)));
            e.Graphics.FillEllipse(s.Color[0, 4], new Rectangle(new Point(0, 3 * bb15.Height / 4), new Size(bb15.Width, bb15.Height / 4)));
            e.Graphics.DrawArc(new Pen(s.Color[1, 4], 4), new Rectangle(new Point(0, 3 * bb15.Height / 8), new Size(bb15.Width, bb15.Height / 4)), 0F, 180F);
        }
        private void b6_draw(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(s.Color[0, 5], new Rectangle(new Point(0, bb15.Height / 8), new Size(bb15.Width, 3 * bb15.Height / 4)));
            e.Graphics.FillEllipse(s.Color[1, 5], new Rectangle(new Point(0, 0), new Size(bb15.Width, bb15.Height / 4)));
            e.Graphics.FillEllipse(s.Color[0, 5], new Rectangle(new Point(0, 3 * bb15.Height / 4), new Size(bb15.Width, bb15.Height / 4)));
            e.Graphics.FillEllipse(Brushes.White, new Rectangle(new Point(bb15.Width / 4, bb15.Height / 16), new Size(bb15.Width / 2, bb15.Height / 8)));
            e.Graphics.DrawArc(new Pen(s.Color[1, 5], 4), new Rectangle(new Point(0, 3 * bb15.Height / 8), new Size(bb15.Width, bb15.Height / 4)), 0F, 180F);
        }
        private void b7_draw(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(s.Color[0, 6], new Rectangle(new Point(0, bb15.Height / 2), new Size(bb15.Width, 3 * bb15.Height / 8)));
            e.Graphics.FillEllipse(s.Color[1, 6], new Rectangle(new Point(0, 3 * bb15.Height / 8), new Size(bb15.Width, bb15.Height / 4)));
            e.Graphics.FillEllipse(s.Color[0, 6], new Rectangle(new Point(0, 3 * bb15.Height / 4), new Size(bb15.Width, bb15.Height / 4)));
        }
        private void b8_draw(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(s.Color[0, 7], new Rectangle(new Point(0, bb15.Height / 2), new Size(bb15.Width, 3 * bb15.Height / 8)));
            e.Graphics.FillEllipse(s.Color[1, 7], new Rectangle(new Point(0, 3 * bb15.Height / 8), new Size(bb15.Width, bb15.Height / 4)));
            e.Graphics.FillEllipse(s.Color[0, 7], new Rectangle(new Point(0, 3 * bb15.Height / 4), new Size(bb15.Width, bb15.Height / 4)));
            e.Graphics.FillEllipse(Brushes.White, new Rectangle(new Point(bb15.Width / 4, 7 * bb15.Height / 16), new Size(bb15.Width / 2, bb15.Height / 8)));
        }
        private void b9_draw(object sender, PaintEventArgs e)
        {
            Point A = new Point(bb16.Width / 4, 0);
            Point B = new Point(bb16.Width, 0);
            Point C = new Point(3 * bb16.Width / 4, bb16.Height / 4);
            Point D = new Point(0, bb16.Height / 4);
            Point[] arr1 = { A, B, C, D };
            e.Graphics.FillPolygon(s.Color[1, 8], arr1);

            Point G = new Point(bb16.Width, 3 * bb16.Height / 4);
            Point F = new Point(3 * bb16.Width / 4, bb16.Height);
            Point E = new Point(0, bb16.Height);
            Point[] arr2 = { D, C, B, G, F, E };
            e.Graphics.FillPolygon(s.Color[0, 8], arr2);

            Point H = new Point(0, 5 * bb16.Height / 8);
            Point I = new Point(3 * bb16.Width / 4, 5 * bb16.Height / 8);
            Point J = new Point(bb16.Width, 3 * bb16.Height / 8);
            Point[] arr3 = { H, I, J };
            e.Graphics.DrawLines(new Pen(s.Color[1, 8], 4), arr3);
        }
        private void b10_draw(object sender, PaintEventArgs e)
        {
            Point A = new Point(bb16.Width / 4, 0);
            Point B = new Point(bb16.Width, 0);
            Point C = new Point(3 * bb16.Width / 4, bb16.Height / 4);
            Point D = new Point(0, bb16.Height / 4);
            Point[] arr1 = { A, B, C, D };
            e.Graphics.FillPolygon(s.Color[1, 9], arr1);

            Point G = new Point(bb16.Width, 3 * bb16.Height / 4);
            Point F = new Point(3 * bb16.Width / 4, bb16.Height);
            Point E = new Point(0, bb16.Height);
            Point[] arr2 = { D, C, B, G, F, E };
            e.Graphics.FillPolygon(s.Color[0, 9], arr2);

            Point H = new Point(0, 5 * bb16.Height / 8);
            Point I = new Point(3 * bb16.Width / 4, 5 * bb16.Height / 8);
            Point J = new Point(bb16.Width, 3 * bb16.Height / 8);
            Point[] arr3 = { H, I, J };
            e.Graphics.DrawLines(new Pen(s.Color[1, 9], 4), arr3);

            e.Graphics.FillEllipse(Brushes.White, new Rectangle(new Point(5 * bb16.Width / 16, bb16.Height / 16), new Size(3 * bb16.Width / 8, bb16.Height / 8)));
        }
        private void b11_draw(object sender, PaintEventArgs e)
        {
            Point A = new Point(bb16.Width / 4, 3 * bb16.Height / 8);
            Point B = new Point(bb16.Width, 3 * bb16.Height / 8);
            Point C = new Point(3 * bb16.Width / 4, 5 * bb16.Height / 8);
            Point D = new Point(0, 5 * bb16.Height / 8);
            Point[] arr1 = { A, B, C, D };
            e.Graphics.FillPolygon(s.Color[1, 10], arr1);

            Point G = new Point(bb16.Width, 3 * bb16.Height / 4);
            Point F = new Point(3 * bb16.Width / 4, bb16.Height);
            Point E = new Point(0, bb16.Height);
            Point[] arr2 = { D, C, B, G, F, E };
            e.Graphics.FillPolygon(s.Color[0, 10], arr2);
        }
        private void b12_draw(object sender, PaintEventArgs e)
        {
            Point A = new Point(bb16.Width / 4, 3 * bb16.Height / 8);
            Point B = new Point(bb16.Width, 3 * bb16.Height / 8);
            Point C = new Point(3 * bb16.Width / 4, 5 * bb16.Height / 8);
            Point D = new Point(0, 5 * bb16.Height / 8);
            Point[] arr1 = { A, B, C, D };
            e.Graphics.FillPolygon(s.Color[1, 11], arr1);

            Point G = new Point(bb16.Width, 3 * bb16.Height / 4);
            Point F = new Point(3 * bb16.Width / 4, bb16.Height);
            Point E = new Point(0, bb16.Height);
            Point[] arr2 = { D, C, B, G, F, E };
            e.Graphics.FillPolygon(s.Color[0, 11], arr2);

            e.Graphics.FillEllipse(Brushes.White, new Rectangle(new Point(5 * bb16.Width / 16, 7 * bb16.Height / 16), new Size(3 * bb16.Width / 8, bb16.Height / 8)));
        }
        private void b13_draw(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(s.Color[0, 12], new Rectangle(new Point(0, bb15.Height / 8), new Size(bb15.Width, 3 * bb15.Height / 4)));
            e.Graphics.FillEllipse(s.Color[1, 12], new Rectangle(new Point(0, 0), new Size(bb15.Width, bb15.Height / 4)));
            e.Graphics.FillEllipse(s.Color[0, 12], new Rectangle(new Point(0, 3 * bb15.Height / 4), new Size(bb15.Width, bb15.Height / 4)));
            e.Graphics.DrawArc(new Pen(s.Color[1, 12], 4), new Rectangle(new Point(0, 3 * bb15.Height / 8), new Size(bb15.Width, bb15.Height / 4)), 0F, 180F);
        }
        private void b14_draw(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(s.Color[0, 13], new Rectangle(new Point(0, bb15.Height / 8), new Size(bb15.Width, 3 * bb15.Height / 4)));
            e.Graphics.FillEllipse(s.Color[1, 13], new Rectangle(new Point(0, 0), new Size(bb15.Width, bb15.Height / 4)));
            e.Graphics.FillEllipse(s.Color[0, 13], new Rectangle(new Point(0, 3 * bb15.Height / 4), new Size(bb15.Width, bb15.Height / 4)));
            e.Graphics.FillEllipse(Brushes.White, new Rectangle(new Point(bb15.Width / 4, bb15.Height / 16), new Size(bb15.Width / 2, bb15.Height / 8)));
            e.Graphics.DrawArc(new Pen(s.Color[1, 13], 4), new Rectangle(new Point(0, 3 * bb15.Height / 8), new Size(bb15.Width, bb15.Height / 4)), 0F, 180F);
        }
        private void b15_draw(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(s.Color[0, 14], new Rectangle(new Point(0, bb15.Height / 2), new Size(bb15.Width, 3 * bb15.Height / 8)));
            e.Graphics.FillEllipse(s.Color[1, 14], new Rectangle(new Point(0, 3 * bb15.Height / 8), new Size(bb15.Width, bb15.Height / 4)));
            e.Graphics.FillEllipse(s.Color[0, 14], new Rectangle(new Point(0, 3 * bb15.Height / 4), new Size(bb15.Width, bb15.Height / 4)));
        }
        private void b16_draw(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(s.Color[0, 15], new Rectangle(new Point(0, bb15.Height / 2), new Size(bb15.Width, 3 * bb15.Height / 8)));
            e.Graphics.FillEllipse(s.Color[1, 15], new Rectangle(new Point(0, 3 * bb15.Height / 8), new Size(bb15.Width, bb15.Height / 4)));
            e.Graphics.FillEllipse(s.Color[0, 15], new Rectangle(new Point(0, 3 * bb15.Height / 4), new Size(bb15.Width, bb15.Height / 4)));
            e.Graphics.FillEllipse(Brushes.White, new Rectangle(new Point(bb15.Width / 4, 7 * bb15.Height / 16), new Size(bb15.Width / 2, bb15.Height / 8)));
        }
        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            Point B = new Point(AA.X, AA.Y + side);
            Point C = new Point(AA.X + side, AA.Y + side);
            Point D = new Point(AA.X + side, AA.Y);

            e.Graphics.FillRectangle(Brushes.MidnightBlue, new Rectangle(AA, new Size(side, side)));

            int dev_x = 20;
            int dev_y = 20;
            Point E = new Point(AA.X + dev_x, AA.Y + side + dev_y);
            Point F = new Point(AA.X + dev_x + side, AA.Y + side + dev_y);
            Point G = new Point(D.X + dev_x, D.Y + dev_y);

            Point[] b = { B, E, F, C };

            Point[] c = { C, F, G, D };

            e.Graphics.FillPolygon(Brushes.SaddleBrown, b);
            e.Graphics.FillPolygon(Brushes.SaddleBrown, c);

            e.Graphics.DrawEllipse(new Pen(circle_color, 3.5f), new Rectangle(AA, new Size(side, side)));
        }
        bool double_click = false;
        private void Shape_Click(object sender, EventArgs e)
        {          
            Button b = (Button)sender;
            if (!double_click)
            {
                if(!MainMenu.PlayAgainstCPU)
                {
                    if (Turns[0])
                    {
                        Turns[0] = false;
                        Turns[3] = true;
                    }
                    else if (Turns[2])
                    {
                        Turns[2] = false;
                        Turns[1] = true;
                    }
                    if (Turns[0])
                        t.Text = "Please " + MainMenu.Names[0] + " select the shape";
                    else if (Turns[1])
                        t.Text = "Please " + MainMenu.Names[0] + " select the position";
                    else if (Turns[2])
                        t.Text = "Please " + MainMenu.Names[1] + " select the shape";
                    else if (Turns[3])
                        t.Text = "Please " + MainMenu.Names[1] + " select the position";
                }
                else
                {
                    if(Turns[0])
                    {
                        Turns[0] = false;
                        Turns[1] = true;
                    }
                }

                for (int i = 0; i < 16; i++)

                    if (!p.Check[0, i])
                        p.Positionn[i].Enabled = true;

                for (int i = 0; i < 16; i++)
                {
                    s.Shapes[i].Enabled = false;
                }
                b.Enabled = true;

                if (!MainMenu.PlayAgainstCPU)
                    for (int i = 0; i < 16; i++)
                         if (!s.Shapes[i].Enabled && !s.MovedToDeck[i])
                         {
                             s.Color[0, i] = Brushes.Black;
                             s.Color[1, i] = Brushes.Gray;
                         }

                double_click = true;
            }
            else
            {
                if(!MainMenu.PlayAgainstCPU)
                {
                    if (Turns[1])
                    {
                        Turns[1] = false;
                        Turns[2] = true;
                    }
                    else if (Turns[3])
                    {
                        Turns[3] = false;
                        Turns[0] = true;
                    }
                }
               
                if (Turns[0])
                    t.Text = "Please " + MainMenu.Names[0] + " select the shape";
                else if (Turns[1])
                    t.Text = "Please " + MainMenu.Names[0] + " select the position";
                else if (Turns[2])
                    t.Text = "Please " + MainMenu.Names[1] + " select the shape";
                else if (Turns[3])
                    t.Text = "Please " + MainMenu.Names[1] + " select the position";

                for (int j = 0; j < 8; j++)
                {
                    s.Color[0, j] = player1_color;
                    s.Color[1, j] = player1_dark_color;
                }
                for (int j = 8; j < 16; j++)
                {
                    s.Color[0, j] = player2_color;
                    s.Color[1, j] = player2_Dark_color;
                }

                for (int i = 0; i < 16; i++)
                    p.Positionn[i].Enabled = false;


                for (int j = 0; j < 16; j++)
                    s.Shapes[j].Enabled = true;

                for (int z = 0; z < 16; z++)
                    if (s.MovedToDeck[z] == true)
                        s.Shapes[z].Enabled = false;

                double_click = false;
            }

            if (MainMenu.PlayAgainstCPU)
            {
                cpu_turn = true;
                CPU_Select_Position();
            }
        }

        private void position_Click(object sender, EventArgs e)
        {

            if(!MainMenu.PlayAgainstCPU)
            {
                if (Turns[1])
                {
                    Turns[1] = false;
                    Turns[0] = true;
                }
                else if (Turns[3])
                {
                    Turns[3] = false;
                    Turns[2] = true;
                }
                if (Turns[0])
                    t.Text = "Please " + MainMenu.Names[0] + " select the shape";
                else if (Turns[1])
                    t.Text = "Please " + MainMenu.Names[0] + " select the position";
                else if (Turns[2])
                    t.Text = "Please " + MainMenu.Names[1] + " select the shape";
                else if (Turns[3])
                    t.Text = "Please " + MainMenu.Names[1] + " select the position";
            }
            else
            {
                Turns[0] = true;
                Turns[1] = false;
                if (Turns[0])
                    t.Text = "Please " + MainMenu.Names[0] + " select the shape";
                else if (Turns[1])
                    t.Text = "Please " + MainMenu.Names[0] + " select the position";
            }

            if (MainMenu.PlayAgainstCPU && cpu_turn)
            {
                CPU_Select_Shape();
            }
            else
            {
                double_click = false;

                for (int j = 0; j < 8; j++)
                {
                    s.Color[0, j] = player1_color;
                    s.Color[1, j] = player1_dark_color;
                }
                for (int j = 8; j < 16; j++)
                {
                    s.Color[0, j] = player2_color;
                    s.Color[1, j] = player2_Dark_color;
                }

                Button b = (Button)sender;
                int i = 0;

                while (i < 16 && !s.Shapes[i].Enabled)
                    i++;
                if (i == 16)
                    i = index_shape_cpu_choose;

                s.Shapes[i].BringToFront();


                //
                s.Shapes[i].Location = b.Location;

                s.MovedToDeck[i] = true;
                int v = 0;
                while (v < 16 && s.MovedToDeck[v])
                    v++;
                if (v == 16 && quarto.Enabled)
                    Controls.Remove(t);
                //

               /* while (true)
                {
                    if (shapes.Shapes[i].Location.X <= AA.X + side + 20)
                    {
                        shapes.Shapes[i].Location = b.Location;

                        shapes.MovedToDeck[i] = true;
                        int v = 0;
                        while (v < 16 && shapes.MovedToDeck[v])
                            v++;
                        if (v == 16 && quarto.Enabled)
                            Controls.Remove(t);
                        break;
                    }


                    if (shapes.Shapes[i].Location.X <= b.Location.X && shapes.Shapes[i].Location.Y >= b.Location.Y)
                        shapes.Shapes[i].Location = new Point(shapes.Shapes[i].Location.X + velocity, shapes.Shapes[i].Location.Y - velocity);

                    if (shapes.Shapes[i].Location.X >= b.Location.X && shapes.Shapes[i].Location.Y >= b.Location.Y)
                        shapes.Shapes[i].Location = new Point(shapes.Shapes[i].Location.X - velocity, shapes.Shapes[i].Location.Y - velocity);

                    if (shapes.Shapes[i].Location.X >= b.Location.X && shapes.Shapes[i].Location.Y <= b.Location.Y)
                        shapes.Shapes[i].Location = new Point(shapes.Shapes[i].Location.X - velocity, shapes.Shapes[i].Location.Y + velocity);

                    if (shapes.Shapes[i].Location.X <= b.Location.X && shapes.Shapes[i].Location.Y <= b.Location.Y)
                        shapes.Shapes[i].Location = new Point(shapes.Shapes[i].Location.X + velocity, shapes.Shapes[i].Location.Y + velocity);



                }*/

                int k = 0;
                while (k < 16)
                {
                    if (b == p.Positionn[k])
                    {
                        p.Location[k] = b.Text;
                        p.PositionNotEmpty[k] = true;
                        p.Check[0, k] = true;
                        p.Check[1, k] = s.Red[i];
                        p.Check[2, k] = s.Big[i];
                        p.Check[3, k] = s.Circle[i];
                        p.Check[4, k] = s.CircleInMiddle[i];
                        p.number_of_position_moved++;
                        break;
                    }
                    k++;
                }

                s.Shapes[i].BringToFront();
                s.Shapes[i].BackColor = Color.MidnightBlue;

                for (int j = 0; j < 16; j++)
                    p.Positionn[j].Enabled = false;


                for (int j = 0; j < 16; j++)
                    s.Shapes[j].Enabled = true;

                for (int z = 0; z < 16; z++)
                    if (s.MovedToDeck[z] == true)
                        s.Shapes[z].Enabled = false;


                if (p.number_of_position_moved >= 3 && !quarto.Enabled)//when quatro.enabled =true there is no need to check anymore you can win
                    quarto.Enabled = Winners();

                if (Draw())
                {
                    lw.Text = "DRAW!";
                    lw.BringToFront();
                    this.Controls.Add(lw);

                    Save.Text = "Restart Game";
                    Quit.Text = "Back To Main Menu";
                    for (int i3 = 0; i3 < 16; i3++)
                    {
                        s.Shapes[i3].Enabled = false;
                        p.Positionn[i3].Enabled = false;
                    }
                    this.Controls.Remove(t);
                }

            }
        }

        void CPU_Select_Shape()
        {
            int k = 0;

            bool can_win_this_round = true;
            bool[] shape_already_used = new bool[16];

            Random gen = new Random();
            bool accepted_decisision;

            index_shape_cpu_choose = 0;

            for (int i = 0; i < 16; i++)
            {

                shape_already_used[i] = s.MovedToDeck[i];
                if (s.MovedToDeck[i])
                    k++;
            }

            while (can_win_this_round && k < 16)
            {
                accepted_decisision = false;

                while (!accepted_decisision)
                {

                    index_shape_cpu_choose = gen.Next(16);
                    if (!shape_already_used[index_shape_cpu_choose])//eza tele3 false,ya3ne meno 3al deck w computer ba3d ma 3emel verification eza fi y7arko 
                    {         //eza tele3 true ya 3al deck ya byerba7 dede eza 7arakto

                        accepted_decisision = true;
                        shape_already_used[index_shape_cpu_choose] = true;//kermel eza ma zabtit ma ya3mol check 3laya mara tenye bel random
                        k++;

                    }
                }

                for (int l = 0; l < 16; l++)
                {
                    if (!p.Check[0, l])//eza ma 7atat hayde 7a ya3mol for 3layon kelon w yerja3 ysaferon bel if(!winner) aw else
                    {
                        p.Check[0, l] = true;
                        p.Check[1, l] = s.Red[index_shape_cpu_choose];
                        p.Check[2, l] = s.Big[index_shape_cpu_choose];
                        p.Check[3, l] = s.Circle[index_shape_cpu_choose];
                        p.Check[4, l] = s.CircleInMiddle[index_shape_cpu_choose];
                    }
                    else
                        continue;

                    if (!Winners())
                    {
                        can_win_this_round = false;
                        p.Check[0, l] = false;
                        p.Check[1, l] = false;
                        p.Check[2, l] = false;
                        p.Check[3, l] = false;
                        p.Check[4, l] = false;
                    }
                    else
                    {
                        p.Check[0, l] = false;
                        p.Check[1, l] = false;
                        p.Check[2, l] = false;
                        p.Check[3, l] = false;
                        p.Check[4, l] = false;
                        can_win_this_round = true;
                        break;
                    }
                }
            }

            s.MovedToDeck[index_shape_cpu_choose] = true;


            for (int i = 0; i < 16; i++)
                if (!p.Check[0, i])
                    p.Positionn[i].Enabled = true;

            for (int i = 0; i < 16; i++)
            {
                s.Shapes[i].Enabled = false;
            }

            s.Shapes[index_shape_cpu_choose].Enabled = true;

            for (int iii = 0; iii < 16; iii++)
            {
                if (!s.Shapes[iii].Enabled && !s.MovedToDeck[iii])
                {
                    s.Color[0, iii] = Brushes.Black;
                    s.Color[1, iii] = Brushes.Gray;
                }
            }

            s.Shapes[index_shape_cpu_choose].Enabled = false;
            s.MovedToDeck[index_shape_cpu_choose] = false;
            cpu_turn = false;
            if (Turns[0])
                t.Text = "Please " + MainMenu.Names[0] + " select the shape";
            else if (Turns[1])
                t.Text = "Please " + MainMenu.Names[0] + " select the position";
        }

        void CPU_Select_Position()
        {
            bool scoring_a_win = false;
            bool accepted_descision;
            bool[] position_already_used = new bool[16];
            int k = 0;
            int n = 0;
            Random gen = new Random();

            int i = 0;//to check wich shape the user has chosen for the cpu
            while (!s.Shapes[i].Enabled)
                i++;

            for (int j = 0; j < 16; j++)
            {
                position_already_used[j] = p.Check[0, j];
                if (p.Check[0, j])
                    k++;
            }

            while (!scoring_a_win && k < 16)
            {
                accepted_descision = false;
                while (!accepted_descision)
                {
                    n = gen.Next(16);
                    if (!position_already_used[n])
                    {
                        k++;
                        position_already_used[n] = true;
                        accepted_descision = true;
                    }
                }

                p.Check[0, n] = true;//here i need to enter all the data of the shape tp make sure of the winner methode
                p.Check[1, n] = s.Red[i];
                p.Check[2, n] = s.Big[i];
                p.Check[3, n] = s.Circle[i];
                p.Check[4, n] = s.CircleInMiddle[i];

                if (Winners())
                {
                    scoring_a_win = true;
                }
                else
                {
                    p.Check[0, n] = false;
                    p.Check[1, n] = false;
                    p.Check[2, n] = false;
                    p.Check[3, n] = false;
                    p.Check[4, n] = false;
                }

            }
            p.Check[0, n] = true;
            p.Check[1, n] = s.Red[i];
            p.Check[2, n] = s.Big[i];
            p.Check[3, n] = s.Circle[i];
            p.Check[4, n] = s.CircleInMiddle[i];



            //

            s.Shapes[i].Location = p.Positionn[n].Location;
            s.Shapes[i].BringToFront();
            s.Shapes[i].BackColor = Color.MidnightBlue;
            p.Positionn[n].Enabled = false;
            p.PositionNotEmpty[n] = true;
            s.MovedToDeck[i] = true;
            p.number_of_position_moved++;

            //


            /*while (true)
                {
                    if (shapes.Shapes[i].Location.X <= AA.X + side + 20)
                    {
                    
                    shapes.Shapes[i].Location = p.Positionn[n].Location;
                    shapes.Shapes[i].BringToFront();
                    shapes.Shapes[i].BackColor = Color.MidnightBlue;
                    p.Positionn[n].Enabled = false;
                    p.PositionNotEmpty[n] = true;
                    shapes.MovedToDeck[i] = true;
                    p.number_of_position_moved++;
                    break;

                        
                    }


                    if (shapes.Shapes[i].Location.X <= p.Positionn[n].Location.X && shapes.Shapes[i].Location.Y >= p.Positionn[n].Location.Y)
                        shapes.Shapes[i].Location = new Point(shapes.Shapes[i].Location.X + velocity, shapes.Shapes[i].Location.Y - velocity);

                    if (shapes.Shapes[i].Location.X >= p.Positionn[n].Location.X && shapes.Shapes[i].Location.Y >= p.Positionn[n].Location.Y)
                        shapes.Shapes[i].Location = new Point(shapes.Shapes[i].Location.X - velocity, shapes.Shapes[i].Location.Y - velocity);

                    if (shapes.Shapes[i].Location.X >= p.Positionn[n].Location.X && shapes.Shapes[i].Location.Y < p.Positionn[n].Location.Y)
                        shapes.Shapes[i].Location = new Point(shapes.Shapes[i].Location.X - velocity, shapes.Shapes[i].Location.Y + velocity);

                    if (shapes.Shapes[i].Location.X <= p.Positionn[n].Location.X && shapes.Shapes[i].Location.Y < p.Positionn[n].Location.Y)
                        shapes.Shapes[i].Location = new Point(shapes.Shapes[i].Location.X + velocity, shapes.Shapes[i].Location.Y + velocity);



                }*/



            if (Winners())
            {
                MessageBox.Show("Sorry, you Lost");
                for (int a = 0; a < 16; a++)
                {
                    s.Shapes[a].Enabled = false;
                    p.Positionn[a].Enabled = false;
                }
                lw.Text = "SORRY " + MainMenu.Names[0] +", YOU LOST";
                lw.BringToFront();
                this.Controls.Add(lw);
                Save.Text = "Restart Game";
                Quit.Text = "Back To Main Menu";
                //End_game();
                this.Controls.Remove(t);
            }
            else if (Draw())
            {
                lw.Text = "DRAW!";
                lw.BringToFront();
                this.Controls.Add(lw);
                Save.Text = "Restart Game";
                Quit.Text = "Back To Main Menu";
                for (int i3 = 0; i3 < 16; i3++)
                {
                    s.Shapes[i3].Enabled = false;
                    p.Positionn[i3].Enabled = false;
                }
                this.Controls.Remove(t);
            }
            else
            {
                CPU_Select_Shape();
            }
        }
        void quarto_click(object sender, EventArgs e)
        {
         
            if(t.Text.Equals("Please " + MainMenu.Names[0] + " select the shape"))
            {
                MessageBox.Show("CONGRATULATIONS " +MainMenu.Names[0]+ ", YOU WON", "QUARTO!", MessageBoxButtons.OK);
                lw.Text = MainMenu.Names[0]+" IS THE WINNER!";
                lw.BringToFront();
                this.Controls.Add(lw);
            }
                
            if (t.Text.Equals("Please " + MainMenu.Names[1] + " select the shape"))
            {
                MessageBox.Show("CONGRATULATIONS " + MainMenu.Names[1] + ", YOU WON", "QUARTO!", MessageBoxButtons.OK);
                lw.Text = MainMenu.Names[1] + " IS THE WINNER!";
                lw.BringToFront();
                this.Controls.Add(lw);
            }
                
            if (t.Text.Equals("Please " + MainMenu.Names[0] + " select the position"))
            {
                MessageBox.Show("CONGRATULATIONS " + MainMenu.Names[0] + ", YOU WON", "QUARTO!", MessageBoxButtons.OK);
                lw.Text = MainMenu.Names[0] + " IS THE WINNER!";
                lw.BringToFront();
                this.Controls.Add(lw);
            }
                
            if (t.Text.Equals("Please " + MainMenu.Names[1] + " select the position"))
            {
                MessageBox.Show("CONGRATULATIONS " + MainMenu.Names[1] + ", YOU WON", "QUARTO!", MessageBoxButtons.OK);
                lw.Text = MainMenu.Names[1] + " IS THE WINNER!";
                lw.BringToFront();
                this.Controls.Add(lw);
            }
            if (MainMenu.PlayAgainstCPU)
            {
                MainMenu.amount_of_gems += 25;
                MainMenu.gems.Text = MainMenu.amount_of_gems.ToString();
                FileStream fs1 = new FileStream("Colors.data", FileMode.Open);
                BinaryReader br = new BinaryReader(fs1);
                FileStream fs2 = new FileStream("temp.data", FileMode.Create);
                BinaryWriter bw = new BinaryWriter(fs2);
                bw.Write(MainMenu.amount_of_gems);
                if(fs1.Length!=0)
                {
                    br.ReadInt32();
                    if(br.PeekChar()!=-1)
                    {
                        for (int i = 0; i < 4; i++)
                            bw.Write(br.ReadBoolean());
                        bw.Write(br.ReadInt32());
                        bw.Write(br.ReadInt32());
                    }
                }

                bw.Close();
                fs2.Close();
                br.Close();
                fs1.Close();
                File.Delete("Colors.data");
                File.Move("temp.data", "Colors.data");
            }
            quarto.Enabled = false;
            Save.Text = "Restart Game";
            Quit.Text = "Back To Main Menu";
            for(int i =0;i<16;i++)
            {
                s.Shapes[i].Enabled = false;
                p.Positionn[i].Enabled = false;
            }
            this.Controls.Remove(t);
        }
        //void End_game()
  
        bool Winners()
        {
            int z = 0;
            for (int l = 0; l < 13; l += 4)
            {
                if (p.Check[0, l] && p.Check[0, l + 1] && p.Check[0, l + 2] && p.Check[0, l + 3])
                {
                    for (int i = 1; i < 5; i++)
                    {
                        z = 0;
                        for (int j = 0; j < 3; j++)
                        {
                            if (p.Check[i, l + j] != p.Check[i, l + j + 1])
                                break;
                            z++;
                            if (z == 3)
                                return true;
                        }
                    }
                }
            }

            for (int l = 0; l < 4; l++)
            {
                if (p.Check[0, l] && p.Check[0, l + 4] && p.Check[0, l + 8] && p.Check[0, l + 12])
                {
                    for (int i = 1; i < 5; i++)
                    {
                        z = 0;
                        for (int j = 0; j < 15; j += 4)
                        {
                            if (p.Check[i, l + j] != p.Check[i, l + j + 4])
                                break;
                            z++;
                            if (z == 3)
                                return true;
                        }
                    }
                }
            }

            if (p.Check[0, 3] && p.Check[0, 6] && p.Check[0, 9] && p.Check[0, 12])
            {
                for (int i = 1; i < 5; i++)
                {
                    z = 0;
                    for (int j = 3; j < 10; j+=3)
                    {
                        if (p.Check[i, j] != p.Check[i, j + 3])
                            break;
                        z++;
                        if (z == 3)
                            return true;
                    }
                }
            }

            if (p.Check[0, 0] && p.Check[0, 5] && p.Check[0, 10] && p.Check[0, 15])
            {
                for (int i = 1; i < 5; i++)
                {
                    z = 0;
                    for (int j = 0; j < 15; j += 5)
                    {
                        if (p.Check[i, j] != p.Check[i, j + 5])
                            break;
                        z++;
                        if (z == 3)
                            return true;
                    }
                }
            }

            return false;
        }

        private void Form1_ParentChanged(object sender, EventArgs e)
        {

        }
        private void fileSystemWatcher1_Changed(object sender, FileSystemEventArgs e)
        {

        }
        bool Draw()
        {
            int i2 = 0;
            while (i2 < 16 && s.MovedToDeck[i2] && !quarto.Enabled)
                i2++;
            if (i2 == 16)
            {
                return true;
            }
            return false;
        }
        private void FillFile( int index)
        {
            FileStream fs;
            if(!MainMenu.PlayAgainstCPU)
                fs = new FileStream("Game" + (index + 1).ToString() + ".data", FileMode.Create);
            else
                fs = new FileStream("Game" + (index + 1).ToString() + "vsCPU.data", FileMode.Create);

            BinaryWriter bw = new BinaryWriter(fs);
            Point[] NewGame = new Point[16];
            for (int i1 = 0; i1 < 16; i1++)
            {
                if (s.MovedToDeck[i1])
                {
                    NewGame[i1] = s.Shapes[i1].Location;
                }
            }
            for (int i2 = 0; i2 < 16; i2++)
            {
                bw.Write(NewGame[i2].X);
                bw.Write(NewGame[i2].Y);
            }
            DateTime time;
            time = DateTime.Now;
            int day = time.Day;
            int month = time.Month;
            int year = time.Year;
            int hour = time.Hour;
            int minute = time.Minute;
            int second = time.Second;
            bw.Write(MainMenu.Names[0]);
            bw.Write(MainMenu.Names[1]);
            bw.Write(year);
            bw.Write(month);
            bw.Write(day);
            bw.Write(hour);
            bw.Write(minute);
            bw.Write(second);
            bw.Write(whostarted);
            int i = 0;
            while (i < 4 && !Turns[i])
                i++;
            bw.Write(i);
            if(i%2==1)
            {             
                if (!MainMenu.PlayAgainstCPU)
                {
                    int j = 0;
                    while(j<16)
                    {
                        if (s.Color[0, j] != Brushes.Black)
                            if (!s.MovedToDeck[j])
                                break;
                        j++;
                    }
                    bw.Write(j);
                }
                else
                    bw.Write(index_shape_cpu_choose);
            }
            bw.Close();
            fs.Close();
        }

        private void SaveAndQuit(object sender, EventArgs e)
        {
            FileStream fs;
            if (Save.Text.Equals("Save And Quit"))
            {      
                BinaryWriter bw;

                if (!MainMenu.PlayAgainstCPU)
                {
                    int i = 0;
                    while (i < 5 && MainMenu.started[i])
                        i++;
                    if (i < 5)
                    {
                        if (!VerifyPass[1, i].Equals(""))
                        {
                            FillFile(i);
                            fs = new FileStream("Game" + (i + 1).ToString() + ".data", FileMode.Append);
                            bw = new BinaryWriter(fs);
                            bw.Write(VerifyPass[1, i]);
                            bw.Close();
                            fs.Close();
                            this.Hide();
                            MainMenu f1 = new MainMenu();
                            f1.ShowDialog();
                            this.Close();
                        }
                        else
                        {
                            index = i;
                            this.Controls.Add(No);
                            this.Controls.Add(Yes);
                            this.Controls.Add(panel);
                            this.Controls.Add(lp);
                            lp.BringToFront();
                            for (int j = 0; j < 16; j++)
                            {
                                s.Shapes[j].Enabled = false;
                                p.Positionn[j].Enabled = false;
                            }
                            Quit.Enabled = false;
                            Save.Enabled = false;
                            quarto.Enabled = false;
                        }
                    }
                    else
                    {
                        if (NumberOfSavedGames + 1 <= 5)
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                fs = new FileStream("Game" + (j + 1).ToString() + ".data", FileMode.Open);
                                if (fs.Length != 0)
                                {
                                    fs.Close();
                                    continue;
                                }
                                else
                                {
                                    fs.Close();
                                    index = j;
                                    break;
                                }
                            }
                            this.Controls.Add(lp);
                            this.Controls.Add(No);
                            this.Controls.Add(Yes);
                            this.Controls.Add(panel);
                            for (int s = 0; s < 16; s++)
                            {
                                this.s.Shapes[s].Enabled = false;
                                p.Positionn[s].Enabled = false;
                            }
                            Quit.Enabled = false;
                            Save.Enabled = false;
                            quarto.Enabled = false;
                        }
                        else
                        {
                            this.Controls.Add(Replace);

                            this.Controls.Add(c);
                            c.Items.Add(Phrases[0]);
                            c.Items.Add(Phrases[1]);
                            c.Items.Add(Phrases[2]);
                            c.Items.Add(Phrases[3]);
                            c.Items.Add(Phrases[4]);

                            this.Controls.Add(Back);

                            this.Controls.Add(l);

                            this.Controls.Add(panel);

                            for (int s = 0; s < 16; s++)
                            {
                                this.s.Shapes[s].Enabled = false;
                                p.Positionn[s].Enabled = false;
                            }
                            Quit.Enabled = false;
                            Save.Enabled = false;
                            quarto.Enabled = false;
                        }
                    }
                }
                else
                {
                    int i = 0;
                    while (i < 5 && MainMenu.startedCPU[i])
                        i++;
                    if (i < 5)
                    {
                        if (!VerifyPass[0, i].Equals(""))
                        {
                            FillFile(i);
                            fs = new FileStream("Game" + (i + 1).ToString() + "vsCPU.data", FileMode.Append);
                            bw = new BinaryWriter(fs);
                            bw.Write(VerifyPass[0, i]);
                            bw.Close();
                            fs.Close();
                            this.Hide();
                            MainMenu f1 = new MainMenu();
                            f1.ShowDialog();
                            this.Close();
                        }
                        else
                        {
                            index = i;
                            this.Controls.Add(No);
                            this.Controls.Add(Yes);
                            this.Controls.Add(panel);
                            this.Controls.Add(lp);
                            lp.BringToFront();
                            for (int j = 0; j < 16; j++)
                            {
                                s.Shapes[j].Enabled = false;
                                p.Positionn[j].Enabled = false;
                            }
                            Quit.Enabled = false;
                            Save.Enabled = false;
                            quarto.Enabled = false;

                        }
                    }
                    else
                    {
                        if (NumberOfSavedGamesCPU + 1 <= 5)
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                fs = new FileStream("Game" + (j + 1).ToString() + "vsCPU.data", FileMode.Open);
                                if (fs.Length != 0)
                                {
                                    fs.Close();
                                    continue;
                                }
                                else
                                {
                                    fs.Close();
                                    index = j;
                                    break;
                                }
                            }
                            this.Controls.Add(lp);
                            this.Controls.Add(No);
                            this.Controls.Add(Yes);
                            this.Controls.Add(panel);
                            for (int s = 0; s < 16; s++)
                            {
                                this.s.Shapes[s].Enabled = false;
                                p.Positionn[s].Enabled = false;
                            }
                            Quit.Enabled = false;
                            Save.Enabled = false;
                            quarto.Enabled = false;
                        }
                        else
                        {
                            this.Controls.Add(Replace);

                            this.Controls.Add(c);
                            c.Items.Add(PhrasesCPU[0]);
                            c.Items.Add(PhrasesCPU[1]);
                            c.Items.Add(PhrasesCPU[2]);
                            c.Items.Add(PhrasesCPU[3]);
                            c.Items.Add(PhrasesCPU[4]);

                            this.Controls.Add(Back);

                            this.Controls.Add(l);

                            this.Controls.Add(panel);

                            for (int s = 0; s < 16; s++)
                            {
                                this.s.Shapes[s].Enabled = false;
                                p.Positionn[s].Enabled = false;
                            }
                            Quit.Enabled = false;
                            Save.Enabled = false;
                            quarto.Enabled = false;
                        }
                    }
                }
            }
            else
            {
                if(!MainMenu.PlayAgainstCPU)
                {
                    int m = 0;
                    while (m < 5 && MainMenu.started[m])
                        m++;
                    if(m<5)
                    {
                        fs = new FileStream("Game" + (m + 1).ToString() + ".data", FileMode.Create);
                        fs.Close();
                        MainMenu.started[m] = true;
                        NumberOfSavedGames--;
                        for (int i = 0; i < 4; i++)
                            MainMenu.Turns[i] = false;
                        MainMenu.Turns[whostarted] = true;
                    }
                }
                else
                {
                    int m = 0;
                    while (m < 5 && MainMenu.startedCPU[m])
                        m++;
                    if(m<5)
                    {
                        fs = new FileStream("Game" + (m + 1).ToString() + "vsCPU.data", FileMode.Create);
                        fs.Close();
                        MainMenu.startedCPU[m] = true;
                        NumberOfSavedGamesCPU--;
                        for (int i = 0; i < 4; i++)
                            MainMenu.Turns[i] = false;
                        MainMenu.Turns[whostarted] = true;
                    }
                }
                this.Hide();
                GamePlay f2 = new GamePlay();
                f2.ShowDialog();
                this.Close();
            }
            
        }

        private void YesNoEnterClick (object sender,EventArgs e)
        {
            Button b = (Button)sender;
            if(b.Text.Equals("YES"))
            {
                No.Text = "BACK";
                Yes.Text = "ENTER";
                this.Controls.Add(tp);
                tp.BringToFront();
                //lp.Text = "PLEASE ENTER YOUR PASSWORD(3 CHARACTERS MINIMUM NO SPACES ALLOWED AND CONTAINS AT LEAST ONE ALPHABETICAL LETTER)";
                lp.Text="Please enter a password for this game (this non-empty password should contain at least one alphabetical letter, should not contain any spaces and it's length should be at least 3 characters!)";
            }
            else if (b.Text.Equals("NO"))
            {
                FillFile(index);
                this.Hide();
                MainMenu f1 = new MainMenu();
                f1.ShowDialog();
                this.Close();
            }
            else if (b.Text.Equals("ENTER"))
            {
                bool NotAllowedPass = false;
                if (tp.Text.Length == 0)
                    MessageBox.Show("Please enter a non-empty password", "Password not entered", MessageBoxButtons.OK);
                else if (!ContainsLetters(tp.Text))
                {
                    tp.Clear();
                    MessageBox.Show("Please enter a password with at least one alphabetical letter", "Password not accepted", MessageBoxButtons.OK);
                }
                else if (tp.Text.Contains(" "))
                {
                    tp.Clear();
                    MessageBox.Show("Please enter a password without spaces", "Password not accepted", MessageBoxButtons.OK);
                }
                else if (tp.Text.Length<3)
                {
                    tp.Clear();
                    MessageBox.Show("The entered password is too short, please enter a longer password", "Password not accepted", MessageBoxButtons.OK);
                }
                else if (lp.Text == "In order to continue, please enter the password of this game")
                {
                    if(MainMenu.PlayAgainstCPU)
                    {
                        if (!tp.Text.Equals(VerifyPass[0,index]))
                        {
                            tp.Clear();
                            MessageBox.Show("The password you entered is wrong, please enter another one", "Wrong Password", MessageBoxButtons.OK);
                            NotAllowedPass = true;
                        }
                    }
                    else
                    {
                        if (!tp.Text.Equals(VerifyPass[1, index]))
                        {
                            tp.Clear();
                            MessageBox.Show("The password you entered is wrong, please enter another one", "Wrong Password", MessageBoxButtons.OK);
                            NotAllowedPass = true;
                        }
                    }
                }
                if (tp.Text.Length != 0 && tp.Text.Length>=3 && !NotAllowedPass && !tp.Text.Contains(" ") && ContainsLetters(tp.Text))
                {
                    if(lp.Text != "In order to continue, please enter the password of this game")
                    {
                        FileStream fs;
                        BinaryWriter bw;
                        if (!MainMenu.PlayAgainstCPU)
                        {
                            FillFile(index);
                            fs = new FileStream("Game" + (index + 1).ToString() + ".data", FileMode.Append);
                            bw = new BinaryWriter(fs);
                            bw.Write(tp.Text);
                            bw.Close();
                            fs.Close();
                        }
                        else
                        {
                            FillFile(index);
                            fs = new FileStream("Game" + (index + 1).ToString() + "vsCPU.data", FileMode.Append);
                            bw = new BinaryWriter(fs);
                            bw.Write(tp.Text);
                            bw.Close();
                            fs.Close();
                        }
                        this.Hide();
                        MainMenu f1 = new MainMenu();
                        f1.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        tp.Clear();
                        No.Text = "NO";
                        Yes.Text = "YES";
                        lp.Text = "Do you want to add a password to protect your saved game?";
                        this.Controls.Remove(tp);
                        //tp.UseSystemPasswordChar = true;
                    }
                }
            }
            else
            {
                c.SelectedIndex = -1;
                this.Controls.Remove(No);
                this.Controls.Remove(Yes);
                this.Controls.Remove(panel);
                this.Controls.Remove(lp);
                this.Controls.Remove(tp);
                tp.Clear();
                No.Text = "NO";
                Yes.Text = "YES";
                lp.Text = "Do you want to add a password to protect your saved game?";
                if (MainMenu.PlayAgainstCPU)
                {
                    if (NumberOfSavedGamesCPU + 1 <= 5)
                    {
                        Quit.Enabled = true;
                        Save.Enabled = true;
                        string[] arr = t.Text.Split(' ');
                        if (arr[4].Equals("shape"))
                            for (int i = 0; i < 16; i++)
                            {
                                s.Shapes[i].Enabled = true;
                            }
                        else if (arr[4].Equals("position"))
                        {
                            for (int i = 0; i < 16; i++)
                            {
                                p.Positionn[i].Enabled = true;
                                if (s.Color[0, i] != Brushes.Black && !s.MovedToDeck[i] && !MainMenu.PlayAgainstCPU)
                                    s.Shapes[i].Enabled = true;
                            }
                        }
                        for (int i = 0; i < 16; i++)
                            if (s.MovedToDeck[i])
                                s.Shapes[i].Enabled = false;
                        for (int i = 0; i < 16; i++)
                            if (p.PositionNotEmpty[i])
                                p.Positionn[i].Enabled = false;
                        if (p.number_of_position_moved >= 3 && !quarto.Enabled)//when quatro.enabled =true there is no need to check anymore you can win
                            quarto.Enabled = Winners();
                        c.Items.Clear();
                    }
                    else
                    {
                        int b1 = 0;
                        while (b1 < 5 && MainMenu.startedCPU[b1])
                            b1++;
                        if (b1==5)
                        {
                            this.Controls.Add(c);
                            this.Controls.Add(l);
                            this.Controls.Add(Replace);
                            this.Controls.Add(Back);
                            this.Controls.Add(panel);
                        }
                        else
                        {
                            Quit.Enabled = true;
                            Save.Enabled = true;
                            string[] arr = t.Text.Split(' ');
                            if (arr[4].Equals("shape"))
                                for (int i = 0; i < 16; i++)
                                {
                                    s.Shapes[i].Enabled = true;
                                }
                            else if (arr[4].Equals("position"))
                            {
                                for (int i = 0; i < 16; i++)
                                {
                                    p.Positionn[i].Enabled = true;
                                    if (s.Color[0, i] != Brushes.Black && !s.MovedToDeck[i] && !MainMenu.PlayAgainstCPU)
                                        s.Shapes[i].Enabled = true;
                                }
                            }
                            for (int i = 0; i < 16; i++)
                                if (s.MovedToDeck[i])
                                    s.Shapes[i].Enabled = false;
                            for (int i = 0; i < 16; i++)
                                if (p.PositionNotEmpty[i])
                                    p.Positionn[i].Enabled = false;
                            if (p.number_of_position_moved >= 3 && !quarto.Enabled)//when quatro.enabled =true there is no need to check anymore you can win
                                quarto.Enabled = Winners();
                            c.Items.Clear();
                        }
                    }
                }
                else
                {
                    if (NumberOfSavedGames + 1 <= 5)
                    {
                        Quit.Enabled = true;
                        Save.Enabled = true;
                        string[] arr = t.Text.Split(' ');
                        if (arr[4].Equals("shape"))
                            for (int i = 0; i < 16; i++)
                            {
                                s.Shapes[i].Enabled = true;
                            }
                        else if (arr[4].Equals("position"))
                        {
                            for (int i = 0; i < 16; i++)
                            {
                                p.Positionn[i].Enabled = true;
                                if (s.Color[0, i] != Brushes.Black && !s.MovedToDeck[i] && !MainMenu.PlayAgainstCPU)
                                    s.Shapes[i].Enabled = true;
                            }
                        }
                        for (int i = 0; i < 16; i++)
                            if (s.MovedToDeck[i])
                                s.Shapes[i].Enabled = false;
                        for (int i = 0; i < 16; i++)
                            if (p.PositionNotEmpty[i])
                                p.Positionn[i].Enabled = false;
                        if (p.number_of_position_moved >= 3 && !quarto.Enabled)//when quatro.enabled =true there is no need to check anymore you can win
                            quarto.Enabled = Winners();
                        c.Items.Clear();
                    }
                    else
                    {
                        int b1 = 0;
                        while (b1 < 5 && MainMenu.started[b1])
                            b1++;
                        if(b1==5)
                        {
                            this.Controls.Add(c);
                            this.Controls.Add(l);
                            this.Controls.Add(Replace);
                            this.Controls.Add(Back);
                            this.Controls.Add(panel);
                        }
                        else
                        {
                            Quit.Enabled = true;
                            Save.Enabled = true;
                            string[] arr = t.Text.Split(' ');
                            if (arr[4].Equals("shape"))
                                for (int i = 0; i < 16; i++)
                                {
                                    s.Shapes[i].Enabled = true;
                                }
                            else if (arr[4].Equals("position"))
                            {
                                for (int i = 0; i < 16; i++)
                                {
                                    p.Positionn[i].Enabled = true;
                                    if (s.Color[0, i] != Brushes.Black && !s.MovedToDeck[i] && !MainMenu.PlayAgainstCPU)
                                        s.Shapes[i].Enabled = true;
                                }
                            }
                            for (int i = 0; i < 16; i++)
                                if (s.MovedToDeck[i])
                                    s.Shapes[i].Enabled = false;
                            for (int i = 0; i < 16; i++)
                                if (p.PositionNotEmpty[i])
                                    p.Positionn[i].Enabled = false;
                            if (p.number_of_position_moved >= 3 && !quarto.Enabled)//when quatro.enabled =true there is no need to check anymore you can win
                                quarto.Enabled = Winners();
                            c.Items.Clear();
                        }
                    }
                }

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

        private void ReplaceGame(object sender, EventArgs e)
        {
            if (c.SelectedItem != null)
            {
                if (!MainMenu.PlayAgainstCPU)
                {
                    int i = 0;
                    while (i < 5 && !c.SelectedItem.ToString().Equals(MainMenu.phrases[i]))
                        i++;
                    if (VerifyPass[1,i] != "")
                    {
                        No.Text = "BACK";
                        Yes.Text = "ENTER";
                        tp.UseSystemPasswordChar = true;
                        this.Controls.Add(tp);
                        tp.BringToFront();
                        lp.Text = "In order to continue, please enter the password of this game";         
                    }
                    index = i;
                }
                else
                {
                    int i = 0;
                    while (i < 5 && !c.SelectedItem.ToString().Equals(MainMenu.phrasesCPU[i]))
                        i++;
                    if(VerifyPass[0,i] != "")
                    {
                        //tp.UseSystemPasswordChar = true;
                        No.Text = "BACK";
                        Yes.Text = "ENTER";
                        this.Controls.Add(tp);
                        tp.BringToFront();
                        lp.Text = "In order to continue, please enter the password of this game";
                    }
                    index = i;
                }
                this.Controls.Add(No);
                this.Controls.Add(Yes);
                Yes.BringToFront();
                No.BringToFront();
                this.Controls.Add(lp);
                lp.BringToFront();
                this.Controls.Remove(c);
                c.SelectedIndex = -1;
                c.Text = "";
                this.Controls.Remove(Back);
                this.Controls.Remove(Replace);
                this.Controls.Remove(l);
            }
            else
                MessageBox.Show("Please select item from combobox", "Item not selected", MessageBoxButtons.OK);
        }
        private void BACK(object sender, EventArgs e)
        {
            Quit.Enabled = true;
            Save.Enabled = true;
            string[] arr = t.Text.Split(' ');
            if (arr[4].Equals("shape"))
                for (int i = 0; i < 16; i++)
                {
                    s.Shapes[i].Enabled = true;
                }
            else if (arr[4].Equals("position"))
            {
                for (int i = 0; i < 16; i++)
                {
                    p.Positionn[i].Enabled = true;
                    if (s.Color[0, i] != Brushes.Black && !s.MovedToDeck[i] && !MainMenu.PlayAgainstCPU)
                        s.Shapes[i].Enabled = true;
                }
            }
            for (int i = 0; i < 16; i++)
                if (s.MovedToDeck[i])
                    s.Shapes[i].Enabled = false;
            for (int i = 0; i < 16; i++)
                if (p.PositionNotEmpty[i])
                    p.Positionn[i].Enabled = false;
              if (p.number_of_position_moved >= 3 && !quarto.Enabled)//when quatro.enabled =true there is no need to check anymore you can win
                quarto.Enabled = Winners();
           
            c.Items.Clear();
            c.SelectedIndex = -1;
            this.Controls.Remove(c);
            this.Controls.Remove(Back);
            this.Controls.Remove(l);
            this.Controls.Remove(panel);
            this.Controls.Remove(Replace);
        }
    }

    class Shape
    {
        Button[] shapes = new Button[16];
        Brush[,] color = new Brush[2, 16];//first row for the color,second for the dark color of the shape
        Point[] position = new Point[16];
        bool[] moved_to_deck = new bool[16];
        bool[] red = new bool[16];
        bool[] big = new bool[16];
        bool[] circle = new bool[16];
        bool[] circle_in_middle = new bool[16];
        public Button[] Shapes
        {
            get { return shapes; }
            set { shapes = value; }
        }
        public Brush[,] Color
        {
            get { return color; }
            set { color = value; }
        }
        public Point[] Position
        {
            get { return position; }
            set { position = value; }
        }
        public bool[] MovedToDeck
        {
            get { return moved_to_deck; }
            set { moved_to_deck = value; }
        }
        public bool[] Red
        {
            get { return red; }
            set { red = value; }
        }
        public bool[] Big
        {
            get { return big; }
            set { big = value; }
        }
        public bool[] Circle
        {
            get { return circle; }
            set { circle = value; }
        }
        public bool[] CircleInMiddle
        {
            get { return circle_in_middle; }
            set { circle_in_middle = value; }
        }
    }
    class Position
    {
        Button[] position = new Button[16];
        string[] location = new string[16];//as nunmber of the position not location 
        bool[] position_not_empty = new bool[16];
        public int number_of_position_moved = 0;//if it's less then 4 no need to check if there is a winner
        bool[,] check = new bool[5, 16];//1-if the shaps is on deck; 2-red; 3-big; 4-circle; 5-circle in middle.
        public Button[] Positionn
        {
            get { return position; }
            set { position = value; }
        }
        public string[] Location
        {
            get { return location; }
            set { location = value; }
        }
        public bool[] PositionNotEmpty
        {
            get { return position_not_empty; }
            set { position_not_empty = value; }
        }
        public bool[,] Check
        {
            get { return check; }
            set { check = value; }
        }
    }
}

