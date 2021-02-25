using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payday2XPCalculator
{
    class HeistItem : Panel
    {
        int ID;
        Boolean Loud;
        Label l = new Label();
        XPItemView P;
        int Type;// 1 Compulsory, 2 Optional, 3 Repeatable
        double XP;
        Boolean Added = false;
        int AddAmount = 0;
        int Max;
        //int StealthXP;
        Label l1 = new Label();
        Color TextB;
        string TextA;
        int MID;
        int MID2;
        int OnOff;
        Boolean AonA;
        public HeistItem(string text, Boolean Appear, Boolean loud, XPItemView parent)
        {
            if (Appear == loud)
            {
                BackColor = Color.FromArgb(4, 31, 45);
                l.AutoSize = true;
                l.ForeColor = Color.FromArgb(217, 217, 217);
                TextB = l.ForeColor;
                Controls.Add(l);
                l.MaximumSize = new Size(180, 15);
                l.Text = text;
                Size = new Size(220, 15);
                Location = new Point(0, 17 * parent.Controls.Count);
                parent.Controls.Add(this);
            }
        }

        public HeistItem(int id, string text, double xp, double sxp, Boolean loud, int type, XPItemView parent, int max, int mutualid, int onoff, Boolean aona, int day, int mutalid2)
        {
            MID2 = mutalid2;
            P = parent;
            Type = type;
            Max = max;
            TextA = text;
            MID = mutualid;
            OnOff = onoff;
            AonA = aona;
            ID = id;
            P.Total++;
            Day = day;
            if (loud)
            {
                XP = xp;
            }
            else
            {
                if (sxp > 0)
                {
                    XP = sxp;
                }
                else { XP = 0; }
            }
            if (Type == 1 && !Added && ID == 0)
            {
                if (day == 1 && P.Day1XP == 0)
                {
                    P.TotalBase += XP;
                    Added = true;
                }
                else if (day == 2 && P.Day2XP == 0)
                {
                    P.TotalBase += XP;
                    Added = true;
                }
                else if (day == 3 && P.Day3XP == 0)
                {
                    P.TotalBase += XP;
                    Added = true;
                }
            }
            if (Added && XP == 0)
            {
                if (Loud)
                {
                    //P.TotalBase -= sxp;
                }
                else
                {
                    //P.TotalBase -= xp;
                }
            }

            //StealthXP = sxp;
            Size = new Size(220, 15);
            Location = new Point(0, 17 * parent.Controls.Count);
            BackColor = Color.FromArgb(4, 31, 45);



            ID = id;
            Loud = loud;
            l.AutoSize = true;
            l.ForeColor = Color.FromArgb(217, 217, 217);
            TextB = l.ForeColor;
            Controls.Add(l);
            l.MaximumSize = new Size(180, 15);

            l1.TextAlign = ContentAlignment.TopRight;
            l1.Visible = true;
            l1.AutoSize = true;
            l1.Text = "+" + string.Format("{0:#,###0}", XP);
            l1.ForeColor = Color.FromArgb(77, 198, 255);
            if (Type == 1)
            {
                if (ID == 0 && Day == 0)
                {
                    l.Text = text;
                    l.ForeColor = l1.ForeColor;
                    P.TotalBase += XP;
                }
                else
                {
                    l.Text = text;
                }

                //BackColor = Color.FromArgb(13, 101, 145);
            }
            else if (Type == 2)
            {
                if (Added)
                {
                    //l.Text = text + " (Counted)";
                    l.ForeColor = l1.ForeColor;
                }
                else
                {
                    l.Text = text;
                }
                l1.ForeColor = Color.FromArgb(191, 221, 125);
            }
            else if (Type == 3)
            {
                l.Text = text + " (" + AddAmount + ")";
                l1.ForeColor = Color.FromArgb(255, 188, 0);
                //BackColor = Color.FromArgb(230, 219, 19, 19);
                //l.BackColor = Color.FromArgb(0, 0, 0, 0);
            }
            Controls.Add(l1);
            l1.Size = new Size(Size.Width - l1.Size.Width, l1.Size.Height);
            l1.Location = new Point(Size.Width - l1.Size.Width, 0);
            l.TextAlign = ContentAlignment.TopLeft;
            parent.Controls.Add(this);
            if (ID != 13)
            {
                MouseDown += HeistItem_MouseClick;
                l1.MouseDown += HeistItem_MouseClick;
                l.MouseDown += HeistItem_MouseClick;
                lB = l.BackColor;
                l1B = l1.BackColor;
            }
            else
            {
                l.Text = "Secure 4 bonus Bags, Broken";
            }
            if (XP == 0)
            {
                this.Dispose();
                P.Total--;
            }
        }
        int Day;
        public HeistItem(int id, string text, double xp, double sxp, Boolean loud, int type, XPItemView parent, int max, int mutualid, int onoff, Boolean aona, int day)
        {
            P = parent;
            Type = type;
            Max = max;
            TextA = text;
            MID = mutualid;
            OnOff = onoff;
            AonA = aona;
            ID = id;
            P.Total++;
            Day = day;
            if (loud)
            {
                XP = xp;
            }
            else
            {
                if (sxp > 0)
                {
                    XP = sxp;
                }
                else { XP = 0; }
            }
            if (Type == 1 && !Added && ID == 0)
            {
                if (day == 1 && P.Day1XP == 0)
                {
                    P.TotalBase += XP;
                    Added = true;
                }
                else if (day == 2 && P.Day2XP == 0)
                {
                    P.TotalBase += XP;
                    Added = true;
                }
                else if (day == 3 && P.Day3XP == 0)
                {
                    P.TotalBase += XP;
                    Added = true;
                }
            }
            if (Added && XP == 0)
            {
                if (Loud)
                {
                    //P.TotalBase -= sxp;
                }
                else
                {
                    //P.TotalBase -= xp;
                }
            }

            //StealthXP = sxp;
            Size = new Size(220, 15);
            Location = new Point(0, 17 * parent.Controls.Count);
            BackColor = Color.FromArgb(4, 31, 45);
            ID = id;
            Loud = loud;
            l.AutoSize = true;
            l.ForeColor = Color.FromArgb(217, 217, 217);
            TextB = l.ForeColor;
            Controls.Add(l);
            l.MaximumSize = new Size(180, 15);
            
            l1.TextAlign = ContentAlignment.TopRight;
            l1.Visible = true;
            l1.AutoSize = true;
            l1.Text = "+" + string.Format("{0:#,###0}", XP);
            l1.ForeColor = Color.FromArgb(77, 198, 255);
            if (Type == 1)
            {
                if (ID == 0)
                {
                    if (Day == 1)
                    {
                        l.Text = text;
                        l.ForeColor = l1.ForeColor;
                        P.Day1XP -= (int)XP;
                        P.TotalBase += XP;
                    }
                    else if (Day == 2)
                    {
                        l.Text = text;
                        l.ForeColor = l1.ForeColor;
                        P.Day2XP -= (int)XP;
                        P.TotalBase += XP;
                    }
                    else if (Day == 3)
                    {
                        l.Text = text;
                        l.ForeColor = l1.ForeColor;
                        P.Day3XP -= (int)XP;
                        P.TotalBase += XP;
                    }
                    else if (Day == 0)
                    {
                        l.Text = text;
                        l.ForeColor = l1.ForeColor;
                        P.TotalBase += XP;
                    }
                    else
                    {
                        l.Text = text;
                        l.ForeColor = l1.ForeColor;
                    }
                }
                else
                {
                    l.Text = text;
                }
                
                //BackColor = Color.FromArgb(13, 101, 145);
            }
            else if (Type == 2)
            {
                if (Added)
                {
                    //l.Text = text + " (Counted)";
                    l.ForeColor = l1.ForeColor;
                }
                else
                {
                    l.Text = text;
                }
                l1.ForeColor = Color.FromArgb(191, 221, 125);
            }
            else if (Type == 3)
            {
                l.Text = text + " (" + AddAmount + ")";
                l1.ForeColor = Color.FromArgb(255, 188, 0);
                //BackColor = Color.FromArgb(230, 219, 19, 19);
                //l.BackColor = Color.FromArgb(0, 0, 0, 0);
            }
            Controls.Add(l1);
            l1.Size = new Size(Size.Width - l1.Size.Width, l1.Size.Height);
            l1.Location = new Point(Size.Width - l1.Size.Width, 0);
            l.TextAlign = ContentAlignment.TopLeft;
            parent.Controls.Add(this);
            if (ID != 13)
            {
                MouseDown += HeistItem_MouseClick;
                l1.MouseDown += HeistItem_MouseClick;
                l.MouseDown += HeistItem_MouseClick;
                lB = l.BackColor;
                l1B = l1.BackColor;
            }
            else
            {
                l.Text = "Secure 4 bonus Bags, Broken";
            }
            if (XP == 0)
            {
                this.Dispose();
                P.Total--;
            }
        }
        Timer t = new Timer();
        Timer tS = new Timer();
        Color lB, l1B;
        void HeistItem_MouseClick(object sender, MouseEventArgs e)
        {
            if (Type == 3 && AddAmount == Max && e.Button == System.Windows.Forms.MouseButtons.Left && ID != 10 && ID != 11)
            { 
                BackColor = Color.FromArgb(230, 219, 19, 19);
                l.BackColor = Color.FromArgb(0, 0, 0, 0);
                l1.BackColor = Color.FromArgb(0, 0, 0, 0);
                t = new Timer();
                t.Tick += t_Tick;
                t.Interval = 50;
                t.Start();
                
            }
            else if (Type == 3 && AddAmount == 0 && e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                BackColor = Color.FromArgb(230, 219, 19, 19);
                l.BackColor = Color.FromArgb(0, 0, 0, 0);
                l1.BackColor = Color.FromArgb(0, 0, 0, 0);
                t = new Timer();
                t.Tick += t_Tick;
                t.Interval = 50;
                t.Start();
            }
            else
            {


                if ((!Added || Type == 3) && Type != 1 && e.Button == System.Windows.Forms.MouseButtons.Left && ID != 10 && ID != 11)
                {
                    if (Type != 3)
                    {
                        Added = true;
                        //l.Text = TextB + " (Counted)";
                        l.ForeColor = l1.ForeColor;
                        AddAmount++;
                    }
                    else
                    {
                        Added = true;
                        AddAmount++;
                        l.Text = TextA + " (" + AddAmount + ")";
                        l.ForeColor = l1.ForeColor;
                    }
                    if (Day == 1 && P.Day1XP != 0)
                    {
                        P.Day1XP = 0;
                    }
                    else if (Day == 2 && P.Day2XP != 0)
                    {
                        P.Day2XP = 0;
                    }
                    else if (Day == 3 && P.Day3XP != 0)
                    {
                        P.Day3XP = 0;
                    }
                    P.TotalBase += XP;
                    if (MID != 0 && AonA)
                    {
                        HeistItem a = GetItemByID(MID);
                        if (OnOff == 1)
                        {
                            a.Activate();
                        }
                        else
                        {
                            a.Deactivate();
                        }
                    }
                    if (MID2 != 0 && AonA)
                    {
                        HeistItem a = GetItemByID(MID2);
                        if (OnOff == 1)
                        {
                            a.Activate();
                        }
                        else
                        {
                            a.Deactivate();
                        }
                    }
                    BackColor = Color.FromArgb(13, 101, 145);
                    l.BackColor = Color.FromArgb(0, 0, 0, 0);
                    l1.BackColor = Color.FromArgb(0, 0, 0, 0);
                    t = new Timer();
                    t.Tick += t_Tick;
                    t.Interval = 50;
                    t.Start();
                }
                else if ((ID == 10 || ID == 11) && e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    if (AddAmount + GetItemByID(MID).AddAmount != Max)
                    {
                        Added = true;
                        AddAmount++;
                        l.Text = TextA + " (" + AddAmount + ")";
                        l.ForeColor = l1.ForeColor;
                        P.TotalBase += XP;
                    }
                    else
                    {
                        BackColor = Color.FromArgb(230, 219, 19, 19);
                        l.BackColor = Color.FromArgb(0, 0, 0, 0);
                        l1.BackColor = Color.FromArgb(0, 0, 0, 0);
                        HeistItem a = GetItemByID(MID);
                        a.BackColor = Color.FromArgb(230, 219, 19, 19);
                        a.l.BackColor = Color.FromArgb(0, 0, 0, 0);
                        a.l1.BackColor = Color.FromArgb(0, 0, 0, 0);//Do Special Timer shit right here
                        tS = new Timer();
                        tS.Tick += tS_Tick;
                        tS.Interval = 50;
                        tS.Start();
                    }
                }
                else if (!Added && e.Button == System.Windows.Forms.MouseButtons.Left && Type == 1 && ID != 0)
                {
                    Added = true;
                    AddAmount++;
                    l.ForeColor = l1.ForeColor;
                    if (Day == 1 && P.Day1XP != 0)
                    {
                        P.Day1XP = 0;
                    }
                    else if (Day == 2 && P.Day2XP != 0)
                    {
                        P.Day2XP = 0;
                    }
                    else if (Day == 3 && P.Day3XP != 0)
                    {
                        P.Day3XP = 0;
                    }
                    P.TotalBase += XP;
                    if (MID != 0 && AonA)
                    {
                        HeistItem a = GetItemByID(MID);
                        if (OnOff == 1)
                        {
                            a.Activate();
                        }
                        else
                        {
                            a.Deactivate();
                        }
                    }
                    if (MID2 != 0 && AonA)
                    {
                        HeistItem a = GetItemByID(MID2);
                        if (OnOff == 1)
                        {
                            a.Activate();
                        }
                        else
                        {
                            a.Deactivate();
                        }
                    }
                    BackColor = Color.FromArgb(13, 101, 145);
                    l.BackColor = Color.FromArgb(0, 0, 0, 0);
                    l1.BackColor = Color.FromArgb(0, 0, 0, 0);
                    t = new Timer();
                    t.Tick += t_Tick;
                    t.Interval = 50;
                    t.Start();
                }
                else if (Added && e.Button == System.Windows.Forms.MouseButtons.Right && Type == 1 && ID != 0)
                {
                    Added = false;
                    AddAmount--;
                    l.ForeColor = TextB;
                    P.TotalBase -= XP;
                    if (MID != 0 && !AonA)
                    {
                        HeistItem a = GetItemByID(MID);
                        if (OnOff == 1)
                        {
                            a.Activate();
                        }
                        else
                        {
                            a.Deactivate();
                        }
                    }
                    if (MID2 != 0 && !AonA)
                    {
                        HeistItem a = GetItemByID(MID2);
                        if (OnOff == 1)
                        {
                            a.Activate();
                        }
                        else
                        {
                            a.Deactivate();
                        }
                    }
                    BackColor = Color.FromArgb(13, 101, 145);
                    l.BackColor = Color.FromArgb(0, 0, 0, 0);
                    l1.BackColor = Color.FromArgb(0, 0, 0, 0);
                    t = new Timer();
                    t.Tick += t_Tick;
                    t.Interval = 50;
                    t.Start();
                }
                else if (e.Button == System.Windows.Forms.MouseButtons.Right && Type != 1 && AddAmount > 0)
                {
                    if (Type != 3)
                    {
                        Added = false;
                        l.ForeColor = TextB;
                    }
                    else
                    {
                        Added = false;
                        AddAmount--;
                        l.Text = TextA + " (" + AddAmount + ")";
                        if (AddAmount == 0)
                        {
                            l.ForeColor = TextB;
                        }
                    }
                    P.TotalBase -= XP;
                    if (MID != 0 && !AonA)
                    {
                        HeistItem a = GetItemByID(MID);
                        if (OnOff == 1)
                        {
                            a.Activate();
                        }
                        else
                        {
                            a.Deactivate();
                        }
                    }
                    if (MID2 != 0 && !AonA)
                    {
                        HeistItem a = GetItemByID(MID2);
                        if (OnOff == 1)
                        {
                            a.Activate();
                        }
                        else
                        {
                            a.Deactivate();
                        }
                    }
                    BackColor = Color.FromArgb(13, 101, 145);
                    l.BackColor = Color.FromArgb(0, 0, 0, 0);
                    l1.BackColor = Color.FromArgb(0, 0, 0, 0);
                    t = new Timer();
                    t.Tick += t_Tick;
                    t.Interval = 50;
                    t.Start();
                }
            }
        }

        private void tS_Tick(object sender, EventArgs e)
        {
            BackColor = Color.FromArgb(4, 31, 45);
            l1.BackColor = l1B;
            l.BackColor = lB;
            HeistItem a = GetItemByID(MID);
            a.BackColor = Color.FromArgb(4, 31, 45);
            a.l1.BackColor = l1B;
            a.l.BackColor = lB;
            tS.Dispose();
            
        }

        public HeistItem GetItemByID(int ID)
        {
            foreach (HeistItem a in P.Items)
            {
                if (a.ID == ID)
                {
                    return a;
                }
            }
            return null;
        }

        public void Activate()
        {
            if (!Added)
            {
                
                if (Type != 3)
                {
                    Added = true;
                    l.Text = TextA;
                    l.ForeColor = l1.ForeColor;
                    AddAmount++;
                }
                else
                {
                    Added = true;
                    AddAmount++;
                    l.Text = TextA + " (" + AddAmount + ")";
                    l.ForeColor = l1.ForeColor;
                }
                P.TotalBase += XP;
            }
        }

        public void Deactivate()
        {
            if (Added)
            {
                if (Type != 3)
                {
                    Added = false;
                    l.ForeColor = TextB;
                    P.TotalBase -= XP;
                }
                else
                {
                    //AddAmount--;
                    //l.Text = TextB + " (" + AddAmount + ")";
                    Added = false;
                    P.TotalBase -= XP * AddAmount;
                    AddAmount = 0;
                    l.Text = TextA + " (" + AddAmount + ")";
                    l.ForeColor = TextB;
                }
                
            }
        }

        void t_Tick(object sender, EventArgs e)
        {
            BackColor = Color.FromArgb(4, 31, 45);
            l1.BackColor = l1B;
            l.BackColor = lB;
            t.Dispose();
        }
    }
}
