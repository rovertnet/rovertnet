using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GOS.FRM
{
    public partial class Frm_FonctGrade : Form
    {
        //Connexion à la base de donnée
        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=GOS;Integrated Security=True");

        public Frm_FonctGrade()
        {
            InitializeComponent();
        }
        private void ViderChamps()
        {
            txtCodFonct.Clear(); 
            txtCodGrad.Clear();
            txtLibFonct.Clear();
            txtLibGrad.Clear();
        }
        #region TABLE FONCTION
        //Charger dataGride Fonction 
        public void chargerListe()
        {

            try
            {
                SqlCommand cmd = new SqlCommand("Select * from T_Fonction", con);
                DataTable dt = new DataTable();
                con.Open();

                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);
                con.Close();

                dtgliste.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de chargement suite : " + ex.Message);
            }
        }
        //Nouvelle fonction
        private void button2_Click(object sender, EventArgs e)
        {
            pnlMaj.Visible = true;
            pnlNouv.Visible = false;
            btnSauv.Text = "Enregistrer";
            ViderChamps(); 
        }
        //Enregistrement et modification de la fonction 
        private void button8_Click(object sender, EventArgs e)
        {
            

            if (btnSauv.Text == "Enregistrer")
            {

                try
                {
                    SqlCommand cmd = new SqlCommand("Insert into T_Fonction values (@CodFonct, @LibFonct)", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@CodFonct", txtCodFonct.Text);
                    cmd.Parameters.AddWithValue("@LibFonct", txtLibFonct.Text);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Données  enregistrées avec succès", "Enregister", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    chargerListe();
                    ViderChamps();
                    pnlMaj.Visible = false;
                    pnlNouv.Visible = true;
                }
                catch (Exception)
                {
                    MessageBox.Show("Echec de l'opération", "erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("Update T_Fonction Set LibFonct = @LibFonct where CodFonct = @CodFonct", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@CodFonct", txtCodFonct.Text);
                    cmd.Parameters.AddWithValue("@LibFonct", txtLibFonct.Text);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Données  modifiées avec succès", "Mis à jour", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    chargerListe();
                    ViderChamps();
                    pnlMaj.Visible = false;
                    pnlNouv.Visible = true;
                }
                catch (Exception)
                {
                    MessageBox.Show("Veuillez selectionner une ligne", "Indication", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            pnlMaj.Visible = false;
            pnlNouv.Visible = true;
        }
        //Suppression d'une ligne 
        private void btnSupp_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Delete from T_Fonction where CodFonct= @CodFonct", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@CodFonct", dtgliste.CurrentRow.Cells[0].Value);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Suppression effectuée avec succès", "Enregister", MessageBoxButtons.OK, MessageBoxIcon.Information);
                chargerListe();
                pnlMaj.Visible = false;
                pnlNouv.Visible = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Veuillez selectionner une ligne", "Indication", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        //iNSTRUCTION POUR LA MIS A JOURS DE LA TABLE GRADE 
        #region GRADE 

        //Charger dataGride Grade 
        public void chargerListe1()
        {

            try
            {
                SqlCommand cmd = new SqlCommand("Select * from T_Grade", con);
                DataTable dt = new DataTable();
                con.Open();

                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);
                con.Close();

                dtgliste1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de chargement suite : " + ex.Message);
            }
        }
        //nouveau grade 
        private void button4_Click(object sender, EventArgs e)
        {
            pnlMaj1.Visible = true;
            pnlNouv1.Visible = false;
            btnSauv1.Text = "Enregistrer"; 
        }
        //enregistrer et modification grade 
        private void button6_Click(object sender, EventArgs e)
        {
      
            if (btnSauv1.Text == "Enregistrer")
            {

                try
                {
                    SqlCommand cmd = new SqlCommand("Insert into T_Grade values (@CodGrad, @LibGrad)", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@CodGrad", txtCodGrad.Text);
                    cmd.Parameters.AddWithValue("@LibGrad", txtLibGrad.Text);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Données  enregistrées avec succès", "Enregister", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
                    chargerListe1();
                    pnlMaj1.Visible = false;
                    pnlNouv1.Visible = true;
                }
                catch (Exception)
                {
                    MessageBox.Show("Echec de l'opération", "erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("Update T_Grade Set LibGrad = @LibGrad where CodGrad = @CodGrad", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@CodGrad", txtCodGrad.Text);
                    cmd.Parameters.AddWithValue("@LibGrad", txtLibGrad.Text);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Données  modifiées avec succès", "Mis à jour", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    chargerListe1();

                    pnlMaj.Visible = false;
                    pnlNouv.Visible = true;
                }
                catch (Exception)
                {
                    MessageBox.Show("Echec de l'opération", "erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            pnlMaj1.Visible = false;
            pnlNouv1.Visible = true;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Delete from T_Grade where CodGrad= @CodGrad", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@CodGrad", dtgliste1.CurrentRow.Cells[0].Value);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Suppression effectuée avec succès", "Enregister", MessageBoxButtons.OK, MessageBoxIcon.Information);
                chargerListe1();
                pnlMaj1.Visible = false;
                pnlNouv1.Visible = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Veuillez selectionner une ligne");
            }
        }
        #endregion

        private void Frm_FonctGrade_Load(object sender, EventArgs e)
        {
            chargerListe1();
            chargerListe();
        }
    }
}
