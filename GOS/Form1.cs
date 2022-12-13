using GOS.Etat_Sortie;
using GOS.FRM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GOS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            PanelWidth = panelLesft.Width;
            isCollpsed = false;
        }
        private void addForm(Form frm)
        {
            pnlParent.Controls.Clear();
            frm.TopLevel = false;
            frm.TopMost = true;
            //frm.Dock = DockStyle.Fill;
            pnlParent.Controls.Add(frm);
            frm.Show();
        }
        private void BtnPara_Click(object sender, EventArgs e)
        {
            pnlPara.Visible = true;
            pnlEtat.Visible = false;
            
        }

        private void BtnPerso_Click(object sender, EventArgs e)
        {
            pnlPara.Visible = false;
            pnlEtat.Visible = false;
            addForm(new Frm_Enseignant());
        }

        private void BtnEnseig_Click(object sender, EventArgs e)
        {
            pnlPara.Visible = false;
            addForm(new Frm_Enseignement());
        }

        private void BtnPogra_Click(object sender, EventArgs e)
        {
            pnlEtat.Visible = true;
            pnlPara.Visible = false;
        }

        private void BTN_Click(object sender, EventArgs e)
        {
            addForm(new Frm_SemCours());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            addForm(new FrmOptionProm());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            addForm(new Frm_FonctGrade());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            addForm(new Frm_Bat());
        }

        private void button10_Click(object sender, EventArgs e)
        {
            pnlPara.Visible = false;
            pnlEtat.Visible = false;
            Etat_ListeOption etatAff = new Etat_ListeOption();
            etatAff.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            pnlPara.Visible = false;
            pnlEtat.Visible = false;

            Etat_Horraire etatAff = new Etat_Horraire();
                etatAff.ShowDialog();
        }

        private void panelLesft_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            pnlPara.Visible = false;
            pnlEtat.Visible = false;

            Etat_Signalitique etatAff = new Etat_Signalitique();
            etatAff.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
        int PanelWidth;
        bool isCollpsed;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isCollpsed)
            {
                panelLesft.Width = panelLesft.Width + 10;
                if (panelLesft.Width >=PanelWidth )
                {
                    timer1.Stop();
                    isCollpsed = false;
                    this.Refresh();
                }
            }
            else
            {
                panelLesft.Width = panelLesft.Width - 10;
                if (panelLesft.Width <= 52)
                {
                    timer1.Stop();
                    isCollpsed = true;
                    this.Refresh();
                }
            }
        }
        public void ActiverFonction()
        {

            lblCon.Text = "Deconnecter";
            panelLesft.Enabled = true;
            pnlParent.Enabled = true;
            lblUser.Text = "0 Connecter";
        }

        private void lblCon_Click(object sender, EventArgs e)
        {
            Frm_Login affLog = new Frm_Login();
            lblCon.Text = "Connecter";
            lblUser.Text = "( ... )";
            panelLesft.Enabled = false;
            pnlParent.Enabled = false;
            pnlPara.Visible = false;
            addForm(new Frm_Acc());
            affLog.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            addForm(new Frm_Acc());
        }
    }
}
