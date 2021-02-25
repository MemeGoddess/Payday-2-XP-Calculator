using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payday2XPCalculator
{
    public partial class Form1 : Form
    {
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        public Form1()
        {
            InitializeComponent();
        }
        Timer t = new Timer();
        private void Form1_Load(object sender, EventArgs e)
        {
            t = new Timer();
            t.Tick += t_Tick;
            t.Interval = 50;
            t.Start();
            listBox1.SelectedIndex = 0;
            listBox1.Refresh();
            listBox1.BackColor = Color.FromArgb(7, 8, 10);
            BackColor = Color.FromArgb(7, 8, 10);
            listBox1.BorderStyle = BorderStyle.None;
            checkBox3.Checked = true;
            
        }
        Size Old;
        void t_Tick(object sender, EventArgs e)
        {
            if (xpItemView1.Size != Old)
            {
                listBox1.Size = new Size(listBox1.Size.Width, 563 - xpItemView1.Size.Height);
                Old = xpItemView1.Size;
            }
        }
        string path = "Heists.ini";
        public string IniReadValue(string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, "", temp,
                                            255, path);
            return temp.ToString();

        }

        public void IniWriteValue(string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, path);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
         //   xpItemView1.Heist = GetIDbyString(comboBox1.SelectedItem.ToString());
        }


        public string GetIDbyString(string text)
        {
            switch (text)
            {
                case "Art Gallery":
                    return "1";
                case "Bank Heist: Pro":
                    return "2";
                case "Bank Heist: Cash":
                    return "3";
                case "Bank Heist: Deposit":
                    return "4";
                case "Bank Heist: Gold Pro":
                    return "5";
                case "Car Shop":
                    return "6";
                case "Cook Off":
                    return "7";
                case "Diamond Store":
                    return "8";
                case "GO Bank":
                    return "9";
                case "Jewelry Store":
                    return "10";
                case "Shadow Raid":
                    return "11";
                case "Alesso Heist":
                    return "12";
                case "Transport: Crossroads":
                    return "13";
                case "Transport: Downtown":
                    return "14";
                case "Transport: Harbor":
                    return "15";
                case "Transport: Park":
                    return "16";
                case "Transport: Train Heist":
                    return "17";
                case "Transport: Underpass":
                    return "18";
                case "Firestarter":
                    return "19";
                case "Firestarter Pro":
                    return "20";
                case "Rats":
                    return "21";
                case "Rats Pro":
                    return "22";
                case "Watch Dogs":
                    return "23";
                case "Watch Dogs Pro":
                    return "24";
                case "The Bomb: Dockyard":
                    return "25";
                case "The Bomb: Forest":
                    return "26";
                case "Golden Grin Casino":
                    return "27";
                case "Hotline Miami":
                    return "28";
                case "Hotline Miami Pro":
                    return "29";
                case "Hoxton Breakout":
                    return "30";
                case "Hoxton Breakout Pro":
                    return "31";
                case "Hoxton Revenge":
                    return "32";
                case "The Big Bank":
                    return "33";
                case "The Diamond":
                    return "34";
                case "Big Oil":
                    return "35";
                case "Election Day":
                    return "36";
                case "Election Day Pro":
                    return "37";
                case "Framing Frame":
                    return "38";
                case "Framing Frame Pro":
                    return "39";
                case "Four Stores":
                    return "40";
                case "Mallcrasher":
                    return "41";
                case "Meltdown":
                    return "42";
                case "Nightclub":
                    return "43";
                case "Ukrainian Job":
                    return "44";
                case "White Xmas":
                    return "45";
                case "First World Bank":
                    return "51";
                case "Slaughter House":
                    return "52";
            }
            return "";
        }
        string Backup = "1";
        int Days = 1;
        int OldH;
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != OldH)
            {
                Backup = GetIDbyString(listBox1.SelectedItem.ToString());
                OldH = listBox1.SelectedIndex;
                xpItemView1.Day1XP = 0;
                xpItemView1.Day2XP = 0;
                xpItemView1.Day3XP = 0;
                xpItemView1.Heist = GetIDbyString(listBox1.SelectedItem.ToString());
                Days = 1;
                switch (xpItemView1.Heist)
                {
                    case "19":
                        Backup = "19";
                        Days = 3;
                        break;
                    case "20":
                        Backup = "20";
                        Days = 3;
                        break;
                    case "21":
                        Backup = "21";
                        Days = 3;
                        break;
                    case "22":
                        Backup = "22";
                        Days = 3;
                        break;
                    case "23":
                        Backup = "23";
                        Days = 2;
                        break;
                    case "24":
                        Backup = "24";
                        Days = 2;
                        break;
                }
                if (Days >= 2)
                {
                    button2.Enabled = true;
                }
                else
                {
                    button2.Enabled = false;
                }
                if (Days == 3)
                {
                    button3.Enabled = true;
                }
                else
                {
                    button3.Enabled = false;
                }
            }
        }

        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            
            e.DrawBackground();
            if (listBox1.Items[e.Index].ToString().EndsWith("Pro") || listBox1.Items[e.Index].ToString() == "Big Oil" ||  listBox1.Items[e.Index].ToString() == "Ukrainian Job")
            {
                e.Graphics.DrawString(listBox1.Items[e.Index].ToString(), listBox1.Font, Brushes.Red, e.Bounds);
            }
            else
            {
                e.Graphics.DrawString(listBox1.Items[e.Index].ToString(), listBox1.Font, new SolidBrush(Color.FromArgb(77, 198, 255)), e.Bounds);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (xpItemView1.Heist.EndsWith("b"))
            {
                xpItemView1.Day2XP = Convert.ToInt32(xpItemView1.l1.Text.Replace(",", "")) - xpItemView1.Day1XP - xpItemView1.Day3XP;
            }
            else if (xpItemView1.Heist.EndsWith("c"))
            {
                xpItemView1.Day3XP = Convert.ToInt32(xpItemView1.l1.Text.Replace(",", "")) - xpItemView1.Day1XP - xpItemView1.Day2XP;
            }
            else
            {
                xpItemView1.Day1XP = Convert.ToInt32(xpItemView1.l1.Text.Replace(",", "")) - xpItemView1.Day2XP - xpItemView1.Day3XP;
            }
            
            xpItemView1.Heist = Backup;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (xpItemView1.Heist.EndsWith("b"))
            {
                xpItemView1.Day2XP = Convert.ToInt32(xpItemView1.l1.Text.Replace(",", "")) - xpItemView1.Day1XP - xpItemView1.Day3XP;
            }
            else if (xpItemView1.Heist.EndsWith("c"))
            {
                xpItemView1.Day3XP = Convert.ToInt32(xpItemView1.l1.Text.Replace(",", "")) - xpItemView1.Day1XP - xpItemView1.Day2XP;
            }
            else
            {
                xpItemView1.Day1XP = Convert.ToInt32(xpItemView1.l1.Text.Replace(",", "")) - xpItemView1.Day2XP - xpItemView1.Day3XP;
            }
            xpItemView1.Heist = Backup + "b";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (xpItemView1.Heist.EndsWith("b"))
            {
                xpItemView1.Day2XP = Convert.ToInt32(xpItemView1.l1.Text.Replace(",", "")) - xpItemView1.Day1XP - xpItemView1.Day3XP;
            }
            else if (xpItemView1.Heist.EndsWith("c"))
            {
                xpItemView1.Day3XP = Convert.ToInt32(xpItemView1.l1.Text.Replace(",", "")) - xpItemView1.Day1XP - xpItemView1.Day2XP;
            }
            else
            {
                xpItemView1.Day1XP = Convert.ToInt32(xpItemView1.l1.Text.Replace(",", "")) - xpItemView1.Day2XP - xpItemView1.Day3XP;
            }
            xpItemView1.Heist = Backup + "c";
        }
        int Difficulty = 1;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Difficulty = 1;
            CalculateXP();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Difficulty = 2;
            CalculateXP();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Difficulty = 3;
            CalculateXP();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Difficulty = 4;
            CalculateXP();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Difficulty = 5;
            CalculateXP();
        }

        void CalculateXP()
        {
            double InfamyBonus = 0;
            double Skill = 1;
            double Gage = 1;
            int Risk = 1;
            double Crew = 0;
            if (checkBox2.Checked)
            {
                Skill = 1.45;
            }
            if (checkBox1.Checked)
            {
                Gage = 1.05;
            }
            for (int i = 0; i < numericUpDown4.Value; i++)
            {
                Crew += 10;
            }
            Crew /= 100;
            Crew++;
            for (int i = 0; i < numericUpDown1.Value; i++)
            {
                InfamyBonus += 5;
            }
            for (int i = 0; i < numericUpDown2.Value; i++)
            {
                InfamyBonus += 7.5;
            }
            for (int i = 0; i < numericUpDown3.Value; i++)
            {
                InfamyBonus += 10;
            }
            InfamyBonus /= 100;
            InfamyBonus++;
            if (Difficulty == 1)
            {
                Risk = 1;
            }
            if (Difficulty == 2)
            {
                Risk = 3;
            }
            if (Difficulty == 3)
            {
                Risk = 6;
            }
            if (Difficulty == 4)
            {
                Risk = 11;
            }
            if (Difficulty == 5)
            {
                Risk = 13;
            }
            //double XP = xpItemView1.TotalBase * Risk * Skill * InfamyBonus * Gage;
            double XP = Convert.ToInt32(xpItemView1.l1.Text.Replace(",", "")) * Risk;
            double SkillXP = XP * Skill - XP;
            double InfamyXP = XP * InfamyBonus - XP;
            double GageXP = XP * Gage - XP;
            double CrewXP = XP * Crew - XP;
            XP = XP + SkillXP + InfamyXP + GageXP + CrewXP;
            double RoundXP = XP;
            string Suffix = "";
            if (RoundXP >= 1000000)
            {
                RoundXP /= 1000000;
                Suffix = "m";
            }
            else if (RoundXP >= 1000)
            {
                RoundXP /= 1000;
                Suffix = "k";

            }
            RoundXP = Math.Round(RoundXP, 2);
            label4.Text = "Experience: " + RoundXP + Suffix + " ("+XP+")";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value = 5;
            numericUpDown2.Value = 8;
            numericUpDown3.Value = 12;
        }

        private void listBox1_MouseEnter(object sender, EventArgs e)
        {
            listBox1.Focus();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                xpItemView1.Loud = true;
            }
            else
            {
                xpItemView1.Loud = false;
            }
        }
    }
}
