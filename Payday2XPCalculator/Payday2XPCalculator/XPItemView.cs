using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payday2XPCalculator
{
    class XPItemView : Panel
    {
        public double TotalBase = 0;
        public Label l1 = new Label();
        [Description("Test text displayed in the textbox"), Category("Data")]
        public string Heist
        {
            get { return this.HeistID; }
            set { this.HeistID = value; AddHeists(); }
        }
        [Description("Test text displayed in the textbox"), Category("Data")]
        public Boolean Loud
        {
            get { return this.LoudH; }
            set { this.LoudH = value; AddHeists(); }
        }
        string HeistID = "1";
        public HeistItem[] Items = new HeistItem[1000];
        public int Total = 0;
        Boolean LoudH = true;
        public int Day1XP = 0, Day2XP = 0, Day3XP = 0;
        public Label l = new Label();
        void AddHeists()
        {
            Controls.Clear();
            Total = 0;
            WorkHeistID();

            BackColor = Color.FromArgb(7, 8, 10);
            int count = Total;
            int scount = count - 1;
            Size = new Size(220, Total * 17 + 15);
            Location = new Point(0, 564 - Size.Height);
            l = new Label();
            l.Text = "Total XP:";
            l.AutoSize = true;
            l.ForeColor = Color.FromArgb(217, 217, 217);
            l.Location = new Point(0, 17 * count);
            Controls.Add(l);
            l1.Text = TotalBase.ToString() + Day1XP;
            l1.AutoSize = true;
            l1.ForeColor = Color.FromArgb(77, 198, 255);
            l1.Location = new Point(l.Size.Width - 3, 17 * count);
            Controls.Add(l1);
            Timer t = new Timer();
            t.Tick += t_Tick;
            t.Interval = 10;
            t.Start();
        }

        void WorkHeistID()
        {
            TotalBase = 0;
            switch(HeistID)
            {//public HeistItem(int id, string text, int xp, int sxp, Boolean loud, int type, XPItemView parent, int max, int mutualid, int onoff, Boolean aona)
                case "1": //Art Gallery
                    Items[Total] = new HeistItem(1, "Escape under 2 Minutes", 2000, 2000, LoudH, 1, this, 0, 2, 2, true, 0);
                    Items[Total] = new HeistItem(2, "Stealth Escape over 2 Minutes", 0, 12000, LoudH, 1, this, 0, 1, 2, true, 0);
                    Items[Total] = new HeistItem(2, "Loud Escape over 2 Minutes", 4000, 0, LoudH, 1, this, 0, 1, 2, true, 0); 
                    break;
                case "2": //Bank Heist: Pro
                    Items[Total] = new HeistItem(0, "Completion", 12000 * 1.2, 12000 * 1.2, LoudH, 1, this, 0, 0, 0, true, 0);
                    break;
                case "3"://Bank Heist: Cash
                    Items[Total] = new HeistItem(0, "Completion", 12000, 12000, LoudH, 1, this, 0, 0, 0, true, 0);
                    break;
                case "4"://Bank Heist: Deposit
                    Items[Total] = new HeistItem(0, "Completion", 12000, 12000, LoudH, 1, this, 0, 0, 0, true, 0);
                    break;
                case "5"://Bank Heist: Gold Pro
                    Items[Total] = new HeistItem(0, "Completion", 12000 * 1.2, 12000 * 1.2, LoudH, 1, this, 0, 0, 0, true, 0);
                    break;
                case "6"://Car Shop
                    new HeistItem("Stealth Only", true, LoudH, this);
                    Items[Total] = new HeistItem(0, "Securing a Car", 0, 3000, LoudH, 1, this, 0, 0, 0, true, 0);
                    Items[Total] = new HeistItem(0, "Finished Hack", 0, 3000, LoudH, 2, this, 0, 0, 0, true, 0);
                    Items[Total] = new HeistItem(0, "Planted C4", 0, 4000, LoudH, 2, this, 0, 0, 0, true, 0);
                    Items[Total] = new HeistItem(0, "Securing Extra Car", 0, 1000, LoudH, 3, this, 3, 0, 0, true, 0);
                    break;
                case "7"://Cook Off
                    new HeistItem("Loud Only", false, LoudH, this);
                    Items[Total] = new HeistItem(0, "Secured Bag", 8000, 0, LoudH, 3, this, 1000, 0, 0, true, 0);
                    break;
                case "8"://Diamond Store
                    Items[Total] = new HeistItem(1, "Stealth Escape under 3 Minutes", 0, 4000, LoudH, 1, this, 0, 2, 2, true, 0);
                    Items[Total] = new HeistItem(2, "Stealth Escape after 3 Minutes", 0, 12000, LoudH, 1, this, 0, 1, 2, true, 0);
                    Items[Total] = new HeistItem(0, "Loud Escape", 14000, 0, LoudH, 1, this, 0, 0, 0, true, 0);
                    break;
                case "9"://GO Bank
                    Items[Total] = new HeistItem(0, "Stealth Escape", 0, 12000, LoudH, 1, this, 0, 0, 0, true, 0);
                    Items[Total] = new HeistItem(0, "Loud Escape", 18000, 0, LoudH, 1, this, 0, 0, 0, true, 0);
                    break;
                case "10"://Jewelry Store
                    Items[Total] = new HeistItem(1, "Stealth Escape under 2 Minutes", 0, 2000, LoudH, 1, this, 0, 2, 2, true, 0);
                    Items[Total] = new HeistItem(2, "Stealth Escape after 2 Minutes", 0, 6000, LoudH, 1, this, 0, 1, 2, true, 0);
                    Items[Total] = new HeistItem(0, "Loud Escape", 8000, 0, LoudH, 1, this, 0, 0, 0, true, 0);
                    break;
                case "11"://Shadow Raid
                    new HeistItem("Stealth Only", true, LoudH, this);
                    Items[Total] = new HeistItem(0, "3 Bags", 0, 4000, LoudH, 1, this, 0, 0, 0, true, 0);
                    Items[Total] = new HeistItem(0, "Stealth Escape", 0, 4000, LoudH, 2, this, 0, 0, 0, true, 0);
                    Items[Total] = new HeistItem(0, "Securing Armor", 0, 6000, LoudH, 2, this, 0, 0, 0, true, 0);
                    Items[Total] = new HeistItem(0, "Secured Bag", 0, 500, LoudH, 3, this, 24, 0, 0, true, 0);
                    break;
                case "12"://Alesso Heist
                    Items[Total] = new HeistItem(0, "Security Hack", 10000, 0, LoudH, 1, this, 0, 0, 0, true, 0);
                    Items[Total] = new HeistItem(10, "C4 in Stealth", 2000, 2000, LoudH, 3, this, 5, 11, 0, true, 0);
                    Items[Total] = new HeistItem(11, "C4 in Loud", 1000, 0, LoudH, 3, this, 5,  10, 0, true, 0);
                    Items[Total] = new HeistItem(0, "Placing C4 Set", 2000, 2000, LoudH, 3, this, 3, 0, 0, true, 0);
                    Items[Total] = new HeistItem(0, "Pyro Set", 3000, 3000, LoudH, 3, this, 3, 0, 0, true, 0);
                    Items[Total] = new HeistItem(0, "Secured Bag in Stealth", 0, 1500, LoudH, 3, this, 18, 0, 0, true, 0);
                    Items[Total] = new HeistItem(0, "Secured Bag in Loud", 1200, 0, LoudH, 3, this, 18, 0, 0, true, 0);
                    break;
                case "13"://Crossroads
                    new HeistItem("Loud Only", false, LoudH, this);
                    Items[Total] = new HeistItem(0, "Completion", 12000, 0, LoudH, 1, this, 0, 0, 0, true, 0);
                    break;
                case "14"://Downtown
                    new HeistItem("Loud Only", false, LoudH, this);
                    Items[Total] = new HeistItem(0, "Completion", 12000, 0, LoudH, 1, this, 0, 0, 0, true, 0);
                    break;
                case "15"://Harbor
                    new HeistItem("Loud Only", false, LoudH, this);
                    Items[Total] = new HeistItem(0, "Completion", 12000, 0, LoudH, 1, this, 0, 0, 0, true, 0);
                    break;
                case "16"://Park
                    new HeistItem("Loud Only", false, LoudH, this);
                    Items[Total] = new HeistItem(0, "Completion", 12000, 0, LoudH, 1, this, 0, 0, 0, true, 0);
                    break;
                case "17"://Train
                    Items[Total] = new HeistItem(0, "Completion", 4000, 4000, LoudH, 1, this, 0, 0, 0, true, 0);
                    Items[Total] = new HeistItem(0, "First Turret Part", 7000, 7000, LoudH, 2, this, 0, 0, 0, true, 0);
                    Items[Total] = new HeistItem(0, "Each Vault", 3000, 3000, LoudH, 3, this, 3, 0, 0, true, 0);
                    Items[Total] = new HeistItem(0, "Secured Bag", 800, 800, LoudH, 3, this, 20, 0, 0, true, 0);
                    break;
                case "18"://Underpass
                    new HeistItem("Loud Only", false, LoudH, this);
                    Items[Total] = new HeistItem(0, "Completion", 12000, 0, LoudH, 1, this, 0, 0, 0, true, 0);
                    break;
                case "19"://Firestarter
                    Items[Total] = new HeistItem(1, "Destory Weapons", 8000, 0, LoudH, 1, this, 0, 2, 2, true, 1);
                    Items[Total] = new HeistItem(2, "Secure Weapons", 10000, 0, LoudH, 1, this, 0, 1, 2, true, 1);
                    Items[Total] = new HeistItem(0, "Secure all Weapons", 6000, 0, LoudH, 2, this, 0, 0, 0, true, 1);
                    new HeistItem("Loud Only", false, LoudH, this);
                    break;
                case "19b"://Day 2
                    Items[Total] = new HeistItem(1, "Escape under 3 Minutes", 6000, 6000, LoudH, 1, this, 0, 2, 2, true, 2);
                    Items[Total] = new HeistItem(2, "Stealth Escape over 3 Minutes", 0, 12000, LoudH, 1, this, 0, 1, 2, true, 2);
                    Items[Total] = new HeistItem(2, "Loud Escape over 3 Minutes", 10000, 0, LoudH, 1, this, 0, 1, 2, true, 2);
                    break;
                case "19c"://Day 3
                    Items[Total] = new HeistItem(0, "Completion", 16000, 16000, LoudH, 1, this, 0, 0, 0, true, 3);
                    break;
                case "20"://Firestarter Pro
                    Items[Total] = new HeistItem(1, "Destory Weapons", 8000 * 1.2, 0, LoudH, 1, this, 0, 2, 2, true, 1);
                    Items[Total] = new HeistItem(2, "Secure Weapons", 10000 * 1.2, 0, LoudH, 1, this, 0, 1, 2, true, 1);
                    Items[Total] = new HeistItem(0, "Secure all Weapons", 6000 * 1.2, 0, LoudH, 2, this, 0, 0, 0, true, 1);
                    new HeistItem("Loud Only", false, LoudH, this);
                    break;
                case "20b"://Day 2
                    Items[Total] = new HeistItem(1, "Escape under 3 Minutes", 6000 * 1.2, 6000 * 1.2, LoudH, 1, this, 0, 2, 2, true, 2);
                    Items[Total] = new HeistItem(2, "Stealth Escape over 3 Minutes", 0, 12000 * 1.2, LoudH, 1, this, 0, 1, 2, true, 2);
                    Items[Total] = new HeistItem(2, "Loud Escape over 3 Minutes", 10000 * 1.2, 0, LoudH, 1, this, 0, 1, 2, true, 2);
                    break;
                case "20c"://Day 3
                    Items[Total] = new HeistItem(0, "Completion", 16000 * 1.2, 16000 * 1.2, LoudH, 1, this, 0, 0, 0, true, 3);
                    break;
                case "21"://Rats
                    Items[Total] = new HeistItem(1, "Escape < 3 Bags", 12000, 0, LoudH, 1, this, 0, 2, 2, true, 1, 3);
                    Items[Total] = new HeistItem(2, "Escape > 3 Bags" , 30000, 0, LoudH, 1, this, 0, 1, 2, true, 1, 3);
                    Items[Total] = new HeistItem(3, "Escape 7 Bags", 40000, 0, LoudH, 1, this, 0, 1, 2, true, 1, 2);
                    new HeistItem("Loud Only", false, LoudH, this);
                    break;
                case "21b"://Day 2
                    Items[Total] = new HeistItem(1, "Escape without Intel", 4000, 0, LoudH, 1, this, 0, 2, 2, true, 2);
                    Items[Total] = new HeistItem(2, "Escape with Intel", 6000, 0, LoudH, 1, this, 0, 1, 2, true, 2);
                    Items[Total] = new HeistItem(0, "Secure all Meth", 4000, 0, LoudH, 2, this, 0, 0, 0, true, 2);
                    new HeistItem("Loud Only", false, LoudH, this);
                    break;
                case "21c"://Day 3
                    Items[Total] = new HeistItem(0, "Completion", 2000, 0, LoudH, 1, this, 0, 0, 0, true, 3);
                    Items[Total] = new HeistItem(0, "Secure >= Total Heist Bags", 14000, 0, LoudH, 2, this, 0, 0, 0, true, 3);
                    new HeistItem("Loud Only", false, LoudH, this);
                    break;
                case "22"://Rats Pro
                    Items[Total] = new HeistItem(1, "Escape < 3 Bags", 12000 * 1.2, 0, LoudH, 1, this, 0, 2, 2, true, 1, 3);
                    Items[Total] = new HeistItem(2, "Escape > 3 Bags", 30000 * 1.2, 0, LoudH, 1, this, 0, 1, 2, true, 1, 3);
                    Items[Total] = new HeistItem(3, "Escape 7 Bags", 40000 * 1.2, 0, LoudH, 1, this, 0, 1, 2, true, 1, 2);
                    new HeistItem("Loud Only", false, LoudH, this);
                    break;
                case "22b"://Day 2
                    Items[Total] = new HeistItem(1, "Escape without Intel", 4000 * 1.2, 0, LoudH, 1, this, 0, 2, 2, true, 2);
                    Items[Total] = new HeistItem(2, "Escape with Intel", 6000 * 1.2, 0, LoudH, 1, this, 0, 1, 2, true, 2);
                    Items[Total] = new HeistItem(0, "Secure all Meth", 4000 * 1.2, 0, LoudH, 2, this, 0, 0, 0, true, 2);
                    new HeistItem("Loud Only", false, LoudH, this);
                    break;
                case "22c"://Day 3
                    Items[Total] = new HeistItem(0, "Completion", 2000 * 1.2, 0, LoudH, 1, this, 0, 0, 0, true, 3);
                    Items[Total] = new HeistItem(0, "Secure >= Total Heist Bags", 14000 * 1.2, 0, LoudH, 2, this, 0, 0, 0, true, 3);
                    new HeistItem("Loud Only", false, LoudH, this);
                    break;
                case "23"://Watch Dogs
                    Items[Total] = new HeistItem(0, "Completion", 12000, 0, LoudH, 1, this, 0, 0, 0, true, 1);
                    Items[Total] = new HeistItem(0, "Chopper Escape", 2000, 0, LoudH, 2, this, 0, 0, 0, true, 1);
                    Items[Total] = new HeistItem(0, "Secured all Bags", 2000, 0, LoudH, 2, this, 0, 0, 0, true, 1);
                    new HeistItem("Loud Only", false, LoudH, this);
                    break;
                case "23b"://Day 2
                    Items[Total] = new HeistItem(0, "Completion", 12000, 0, LoudH, 1, this, 0, 0, 0, true, 2);
                    Items[Total] = new HeistItem(0, "Secured Bag after 3rd", 1500, 0, LoudH, 3, this, 9, 0, 0, true, 2);
                    new HeistItem("Loud Only", false, LoudH, this);
                    break;
                case "24"://Watch Dogs Pro
                    Items[Total] = new HeistItem(0, "Completion", 12000 * 1.2, 0, LoudH, 1, this, 0, 0, 0, true, 1);
                    Items[Total] = new HeistItem(0, "Chopper Escape", 2000 * 1.2, 0, LoudH, 2, this, 0, 0, 0, true, 1);
                    Items[Total] = new HeistItem(0, "Secured all Bags", 2000 * 1.2, 0, LoudH, 2, this, 0, 0, 0, true, 1);
                    new HeistItem("Loud Only", false, LoudH, this);
                    break;
                case "24b"://Day 2
                    Items[Total] = new HeistItem(0, "Completion", 12000 * 1.2, 0, LoudH, 1, this, 0, 0, 0, true, 2);
                    Items[Total] = new HeistItem(0, "Secured Bag after 3rd", 1500 * 1.2, 0, LoudH, 3, this, 9, 0, 0, true, 2);
                    new HeistItem("Loud Only", false, LoudH, this);
                    break;
                case "25"://Dockyard
                    Items[Total] = new HeistItem(0, "Completion", 6000, 6000, LoudH, 1, this, 0, 0, 0, true, 0);
                    Items[Total] = new HeistItem(0, "Bagging Bomb", 6000, 2500, LoudH, 3, this, 4, 0, 0, true, 0);
                    Items[Total] = new HeistItem(1, "Keycards Used (Rush)", 2500, 0, LoudH, 2, this, 0, 2, 2, true, 0);
                    Items[Total] = new HeistItem(0, "Keycards Used", 0, 2500, LoudH, 2, this, 0, 0, 0, true, 0);
                    Items[Total] = new HeistItem(0, "Comm Frequency", 0, 2500, LoudH, 2, this, 0, 0, 0, true, 0);
                    Items[Total] = new HeistItem(3, "Comm Frequency (Rush)", 2500, 0, LoudH, 2, this, 0, 4, 2, true, 0);
                    Items[Total] = new HeistItem(0, "Using Comms", 0, 2500, LoudH, 2, this, 0, 0, 0, true, 0);
                    Items[Total] = new HeistItem(2, "C4 Detonated", 6000, 0, LoudH, 2, this, 0, 1, 2, true, 0);
                    Items[Total] = new HeistItem(4, "Security Hack", 6000, 0, LoudH, 2, this, 0, 3, 2, true, 0);
                    Items[Total] = new HeistItem(0, "Secured Bag", 500, 500, LoudH, 3, this, 12, 0, 0, true, 0);
                    break;
                case "26":
                    Items[Total] = new HeistItem(0, "Completion", 6000, 0, LoudH, 1, this, 0, 0, 0, true, 0);
                    Items[Total] = new HeistItem(0, "Vault Discovered", 2000, 0, LoudH, 2, this, 0, 0, 0, true, 0);
                    Items[Total] = new HeistItem(0, "Vault filled with Water", 12000, 0, LoudH, 2, this, 0, 0, 0, true, 0);
                    Items[Total] = new HeistItem(0, "Picking up C4", 6000, 0, LoudH, 2, this, 0, 0, 0, true, 0);
                    Items[Total] = new HeistItem(0, "Secured Bag", 1500, 0, LoudH, 3, this, 0, 0, 0, true, 0);
                    new HeistItem("Loud Only", false, LoudH, this);
                    break;
                case "27":
                    Items[Total] = new HeistItem(0, "Silent Entry (Gear)", 1000, 1000, LoudH, 2, this, 0, 0, 0, true, 0);
                    Items[Total] = new HeistItem(0, "All Codes", 12000, 12000, LoudH, 2, this, 0, 0, 0, true, 0);
                    Items[Total] = new HeistItem(0, "Acquire Blueprints", 0, 4000, LoudH, 2, this, 0, 0, 0, true, 0);
                    Items[Total] = new HeistItem(0, "Sending Blueprints", 0, 4000, LoudH, 2, this, 0, 0, 0, true, 0);
                    Items[Total] = new HeistItem(0, "Sending USB", 0, 4000, LoudH, 2, this, 0, 0, 0, true, 0);
                    Items[Total] = new HeistItem(0, "Acquire Keycard", 0, 4000, LoudH, 2, this, 0, 0, 0, true, 0);
                    Items[Total] = new HeistItem(0, "Using Sleeping Gas", 0, 4000, LoudH, 2, this, 0, 0, 0, true, 0);
                    Items[Total] = new HeistItem(0, "Disabling Lasers", 0, 2000, LoudH, 2, this, 0, 0, 0, true, 0);
                    Items[Total] = new HeistItem(0, "Entering Armory", 2000, 0, LoudH, 2, this, 0, 0, 0, true, 0);
                    Items[Total] = new HeistItem(0, "Taking the C4", 2000, 0, LoudH, 2, this, 0, 0, 0, true, 0);
                    Items[Total] = new HeistItem(0, "Using the C4", 4000, 0, LoudH, 2, this, 0, 0, 0, true, 0);
                    Items[Total] = new HeistItem(0, "Winch parts", 3000, 0, LoudH, 2, this, 0, 0, 0, true, 0);
                    Items[Total] = new HeistItem(0, "Setting up Winch", 6000, 0, LoudH, 2, this, 0, 0, 0, true, 0);
                    Items[Total] = new HeistItem(0, "Fireworks", 2000, 0, LoudH, 2, this, 0, 0, 0, true, 0);
                    Items[Total] = new HeistItem(0, "Lowering Drill", 8000, 0, LoudH, 2, this, 0, 0, 0, true, 0);
                    Items[Total] = new HeistItem(0, "Connecting Winch", 1000, 0, LoudH, 2, this, 0, 0, 0, true, 0);
                    Items[Total] = new HeistItem(0, "Drill in Position", 2000, 0, LoudH, 2, this, 0, 0, 0, true, 0);
                    Items[Total] = new HeistItem(0, "Drill Started", 6000, 0, LoudH, 2, this, 0, 0, 0, true, 0);
                    Items[Total] = new HeistItem(0, "Drill Finished", 10000, 0, LoudH, 2, this, 0, 0, 0, true, 0);
                    Items[Total] = new HeistItem(0, "Dentist's Loot", 250, 250, LoudH, 2, this, 0, 0, 0, true, 0);
                    break;
                case "30"://Hoxton Breakout
                    new HeistItem("Loud Only", false, LoudH, this);
                    Items[Total] = new HeistItem(0, "Day 1 Completion", 16000, 0, LoudH, 1, this, 0, 0, 0, false, 0);
                    Items[Total] = new HeistItem(0, "Day 2 Completion", 30000, 0, LoudH, 1, this, 0, 0, 0, false, 0);
                    break;
                case "31"://Hoxton Breakout Pro
                    new HeistItem("Loud Only", false, LoudH, this);
                    Items[Total] = new HeistItem(0, "Day 1 Completion", 16000 * 1.2, 0, LoudH, 1, this, 0, 0, 0, false, 0);
                    Items[Total] = new HeistItem(0, "Day 2 Completion", 30000 * 1.2, 0, LoudH, 1, this, 0, 0, 0, false, 0);
                    break;
                case "34"://The Diamond
                    Items[Total] = new HeistItem(0, "Loud Completion", 6000, 4000, LoudH, 1, this, 0, 0, 0, false, 0);
                    Items[Total] = new HeistItem(0, "Diamond without Gas", 4000, 3000, LoudH, 2, this, 0, 0, 0, false, 0);
                    Items[Total] = new HeistItem(0, "Timelocks Finished", 10000, 4000, LoudH, 2, this, 0, 0, 0, false, 0);
                    Items[Total] = new HeistItem(13, "Secure 4 bonus Bags", 6000, 6000, LoudH, 2, this, 0 , 2, 2, true, 0); 
                    Items[Total] = new HeistItem(0, "Hack Security Room", 8000, 0, LoudH, 2, this, 0, 0, 0, false, 0);
                    Items[Total] = new HeistItem(0, "Rewire Power Boxes", 0, 6000, LoudH, 2, this, 0, 0, 0, false, 0);
                    Items[Total] = new HeistItem(2, "Per Secured Bag", 1000, 1000, LoudH, 3, this, 22, 13, 2, true, 0);
                    break;
                case "50"://Counterfeit
                    break;
                case "51"://First World Bank
                    Items[Total] = new HeistItem(0, "Completion", 2000, 2000, LoudH, 1, this, 0, 0, 0, false, 0);
                    Items[Total] = new HeistItem(0, "Open Server Room", 2000, 2000, LoudH, 2, this, 0, 0, 0, false, 0);
                    Items[Total] = new HeistItem(0, "Rewiring Box", 0, 1500, LoudH, 2, this, 3, 0, 0, false, 0);
                    Items[Total] = new HeistItem(0, "Finding Code", 0, 1000, LoudH, 2, this, 0, 0, 0, false, 0);
                    Items[Total] = new HeistItem(0, "Vault Area", 0, 2000, LoudH, 2, this, 0, 0, 0, false, 0);
                    Items[Total] = new HeistItem(0, "Vault Opened", 0, 2000, LoudH, 2, this, 0, 0, 0, false, 0);
                    Items[Total] = new HeistItem(0, "Magnetic Lock", 2000, 0, LoudH, 2, this, 0, 0, 0, false, 0);
                    Items[Total] = new HeistItem(0, "Drill Finished", 4000, 0, LoudH, 2, this, 0, 0, 0, false, 0);
                    Items[Total] = new HeistItem(0, "Thermite Started", 6000, 0, LoudH, 2, this, 0, 0, 0, false, 0);
                    Items[Total] = new HeistItem(0, "Wall Blown up", 2000, 0, LoudH, 2, this, 0, 0, 0, false, 0);
                    Items[Total] = new HeistItem(0, "Overvault Opened (DW)", 40000, 0, LoudH, 2, this, 0, 0, 0, false, 0);
                    Items[Total] = new HeistItem(0, "Secure Money", 1000, 1000, LoudH, 2, this, 0, 0, 0, false, 0);
                    Items[Total] = new HeistItem(0, "Secure All Gold (DW)", 10010, 0, LoudH, 2, this, 0, 0, 0, false, 0);
                    break;
                case "52":
                    new HeistItem("Loud Only", false, LoudH, this);
                    Items[Total] = new HeistItem(0, "Completion", 6000, 0, LoudH, 1, this, 0, 0, 0, false, 0);
                    Items[Total] = new HeistItem(0, "Truck Door Blown Up", 4000, 0, LoudH, 2, this, 0, 0, 0, false, 0);
                    Items[Total] = new HeistItem(0, "Safe Drilled", 6000, 0, LoudH, 2, this, 0, 0, 0, false, 0);
                    Items[Total] = new HeistItem(0, "Smokescreen Created", 4000, 0, LoudH, 2, this, 0, 0, 0, false, 0);
                    Items[Total] = new HeistItem(0, "Moved Gold Container", 6000, 0, LoudH, 2, this, 0, 0, 0, false, 0);
                    Items[Total] = new HeistItem(0, "Blue Container Opened", 6000, 0, Loud, 2, this, 0, 0, 0, false, 0);
                    Items[Total] = new HeistItem(1, "Secured Bag (Ovk/DW)", 800, 0, LoudH, 3, this, 8, 2, 2, true, 0);
                    Items[Total] = new HeistItem(2, "Secured Bag (>Ovk)", 1000, 0, LoudH, 3, this, 8, 1, 2, true, 0);
                    break;
            }
            
        }
        public XPItemView()
        {
            AddHeists();
        }

        void t_Tick(object sender, EventArgs e)
        {
            l1.Text = string.Format("{0:#,###0}", TotalBase + Day1XP + Day2XP + Day3XP);
            //string.Format("{0:#,###0}", XP);
        }
    }
}
