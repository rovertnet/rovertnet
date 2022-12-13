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
    public partial class Frm_SemCours : Form
    {
        //Connexion à la base de donnée
        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=GOS;Integrated Security=True");

        public Frm_SemCours()
        {
            InitializeComponent();
        }

        private void ViderChamps()
        {
            txtCodCours.Clear(); 
            txtCodSem.Clear();
            txtLibCours.Clear();
            txtLibSem.Clear();
        }
        //mis a jours Semestres 
        #region SEMESTRE
            //Charge les données de la table semestre dans le datagrid
        public void chargerListe()
        {

            try
            {
                SqlCommand cmd = new SqlCommand("Select * from T_Semetre", con);
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

        //Ouvrir interface ajouter semestre 
        private void button2_Click(object sender, EventArgs e)
        {
            pnlMaj.Visible = true;
            pnlNouv.Visible = false;
            btnSauv.Text = "Enregistrer"; 
            ViderChamps(); 
        }

        //MIS A JOUR SEMESTRE 
     private void button8_Click(object sender, EventArgs e)
        {

            

            if (btnSauv.Text == "Enregistrer")
            {

                try
                {
                    SqlCommand cmd = new SqlCommand("Insert into T_Semetre values (@CodSem, @LibSem)", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@CodSem", txtCodSem.Text);
                    cmd.Parameters.AddWithValue("@LibSem", txtLibSem.Text);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Données  enregistrées avec succès", "Enregister", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    chargerListe();

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
                    SqlCommand cmd = new SqlCommand("Update T_Semetre Set LibSem = @LibSem where CodSem = @CodSem", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@CodSem", txtCodSem.Text);
                    cmd.Parameters.AddWithValue("@LibSem", txtLibSem.Text);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Données  modifiées avec succès", "Mis à jour", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    chargerListe();

                    pnlMaj.Visible = false;
                    pnlNouv.Visible = true;
                }
                catch (Exception)
                {
                    MessageBox.Show("Echec de l'opération", "erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //aNNULER L'OP2RATION
     private void button7_Click(object sender, EventArgs e)
        {
            pnlMaj.Visible = false;
            pnlNouv.Visible = true;
        }
        //Suppresion de la ligne selectionnée du semestre
    private void btnSupp_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Delete from T_Semetre where CodSem= @CodSem", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@CodSem", dtgliste.CurrentRow.Cells[0].Value);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Suppression effectuée avec succès", "Enregister", MessageBoxButtons.OK, MessageBoxIcon.Information);
                chargerListe();
            }
            catch (Exception)
            {
                MessageBox.Show("Veuillez selectionner une ligne", "Indication", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        //mis a jour table cours 
        #region COURS
        //Charger données de la table cours 
        public void chargerListe1()
        {

            try
            {
                SqlCommand cmd = new SqlCommand("Select * from T_Cours", con);
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

        //Afficher interface de mis a jour cours 
        private void button4_Click(object sender, EventArgs e)
        {
            pnlMaj1.Visible = true;
            pnlNouv1.Visible = false;
            btnSauv1.Text = "Enregistrer";
            ViderChamps();
        }

        //enregstrer et modification des données cours
        private void button6_Click(object sender, EventArgs e)
        {
            

            if (btnSauv1.Text == "Enregistrer")
            {

                try
                {
                    SqlCommand cmd = new SqlCommand("Insert into T_Cours values (@CodCour, @LibCour)", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@CodCour", txtCodCours.Text);
                    cmd.Parameters.AddWithValue("@LibCour", txtLibCours.Text);

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
                    SqlCommand cmd = new SqlCommand("Update T_Cours Set LibCour = @LibCour where CodCour = @CodCour", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@CodCour", txtCodCours.Text);
                    cmd.Parameters.AddWithValue("@LibCour", txtLibCours.Text);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Données  modifiées avec succès", "Mis à jour", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    chargerListe1();

                    pnlMaj1.Visible = false;
                    pnlNouv1.Visible = true;
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
        private void btnSupp1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Delete from T_Cours where CodCour= @CodCour", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@CodNat", dtgliste1.CurrentRow.Cells[0].Value);

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
                MessageBox.Show("Veuillez selectionner une ligne", "Indication", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion

        private void Frm_SemCours_Load(object sender, EventArgs e)
        {
            chargerListe1();
            chargerListe();
            ChargerCombo1();
            ChargerCombo();
            chargerListe2();
        }
        #region ProgrammeCours
        private void button2_Click_1(object sender, EventArgs e)
        {
            pnlMaj2.Visible = true;
            pnlNouv2.Visible = false;
        }
        public void chargerListe2()
        {

            try
            {
                SqlCommand cmd = new SqlCommand("Select * from T_EtreProgrammer", con);
                DataTable dt = new DataTable();
                con.Open();

                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);
                con.Close();

                dtgliste2.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de chargement suite : " + ex.Message);
            }
        }
        #endregion

        private void btnSauv2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Insert into T_EtreProgrammer values (@CodSem, @CodCour)", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@CodCour", cmbCour.SelectedValue);
                cmd.Parameters.AddWithValue("@CodSem", cmbSem.SelectedValue);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Données  enregistrées avec succès", "Enregister", MessageBoxButtons.OK, MessageBoxIcon.Information);
                chargerListe2();

                pnlMaj1.Visible = false;
                pnlNouv1.Visible = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Echec de l'opération", "erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSupp2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Delete from T_EtreProgrammer where CodCour= @CodCour", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@CodCour", dtgliste2.CurrentRow.Cells[0].Value);

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
                MessageBox.Show("Veuillez selectionner une ligne", "Indication", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAnn2_Click(object sender, EventArgs e)
        {
            pnlMaj2.Visible = false;
            pnlNouv2.Visible = true;
        }
        private void ChargerCombo()
        {
            SqlDataAdapter cmd = new SqlDataAdapter("Select * FROM T_Cours", con);
            DataTable dt = new DataTable();
            cmd.Fill(dt);
            DataRow row = dt.NewRow();
            row[0] = 0;
            row[1] = "Veuiller selectionner";
            dt.Rows.InsertAt(row, 0);
            cmbCour.DataSource = dt;
            cmbCour.DisplayMember = "LibCour";
            cmbCour.ValueMember = "CodCour";
        }
        private void ChargerCombo1()
        {
            SqlDataAdapter cmd = new SqlDataAdapter("Select * FROM T_Semetre", con);
            DataTable dt = new DataTable();
            cmd.Fill(dt);
            DataRow row = dt.NewRow();
            row[0] = 0;
            row[1] = "Veuiller selectionner";
            dt.Rows.InsertAt(row, 0);
            cmbSem.DataSource = dt;
            cmbSem.DisplayMember = "LibSem";
            cmbSem.ValueMember = "CodSem";
        }
    }
}
