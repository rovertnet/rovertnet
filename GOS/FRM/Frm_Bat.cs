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
    public partial class Frm_Bat : Form
    {
        //Connexion _ la base de données 
        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=GOS;Integrated Security=True");

        public Frm_Bat()
        {
            InitializeComponent();
        }
        //Vider les champs 
        private void Viderchamps ()
        {
            txtCodLoc.Clear(); 
            txtCodNiv.Clear();
            txtLibLoc.Clear();
            txtLibNiv.Clear();
            txtSitCod.Clear();
            txtSitLib.Clear();
            
           
        }
        //Region pour la table SITE
        #region SITE    
        public void chargerListe()
        {

            try
            {
                
                SqlCommand cmd = new SqlCommand("Select * FROM T_Site", con);
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
        

        private void button2_Click(object sender, EventArgs e)
        {
            pnlMaj.Visible = true;
            pnlNouv.Visible = false;
            btnSauvSite.Text = "Enregistrer";
            Viderchamps();
        }
        private void btnSauvSite_Click(object sender, EventArgs e)
        {
            if (btnSauvSite.Text == "Enregistrer")
            {

                try
                {
                    SqlCommand cmd = new SqlCommand("Insert into T_Site values (@CodSit, @LibSit)", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@CodSit", txtSitCod.Text);
                    cmd.Parameters.AddWithValue("@LibSit", txtSitLib.Text);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Données  enregistrées avec succès", "Enregister", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    pnlMaj.Visible = false;
                    pnlNouv.Visible = true;
                    chargerListe();
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
                    SqlCommand cmd = new SqlCommand("Update T_Site Set LibSit = @LibSit where CodSit = @CodSit", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@CodSit", txtSitCod.Text);
                    cmd.Parameters.AddWithValue("@LibSit", txtSitLib.Text);

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
        
        private void btnSauvAnn_Click(object sender, EventArgs e)
        {
            pnlMaj.Visible = false;
            pnlNouv.Visible = true;
        }
        //suppression de la ligne selectionner dans la table Site
        private void button1_Click(object sender, EventArgs e)
        {
          
            try
            {
                SqlCommand cmd = new SqlCommand("Delete from T_Site where CodSit= @CodSit", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@CodSit", dtgliste.CurrentRow.Cells[0].Value);

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

        //LES INSTRUCTION DES LA TABLES LOCAL 
        #region LOCAL
        public void chargerListe2()
        {

            try
            {
                SqlCommand cmd = new SqlCommand("Select * from T_Local", con);
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
        private void button10_Click(object sender, EventArgs e)
        {
            pnlMaj2.Visible = true;
            pnlNouv2.Visible = false;
            btnSauvLoc.Text = "Enregistrer";
            Viderchamps();
        }

        private void btnSauvLocal_Click(object sender, EventArgs e)
        {
           

            if (btnSauvLoc.Text == "Enregistrer")
            {

                try
                {
                    SqlCommand cmd = new SqlCommand("Insert into T_Local values (@CodLoc, @Intitul,@CodNiv)", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@CodLoc", txtCodLoc.Text);
                    cmd.Parameters.AddWithValue("@Intitul", txtLibLoc.Text);
                    cmd.Parameters.AddWithValue("@CodNiv", cmbSite.ValueMember);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Données  enregistrées avec succès", "Enregister", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    chargerListe2();

                    pnlMaj2.Visible = false;
                    pnlNouv2.Visible = true;
                }
                catch (Exception)
                {
                    MessageBox.Show("Echec de l'opération");
                }
            }
            else
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("Update T_Local Set Intitul = @Intitul, Set CodNiv = @CodNiv where CodLoc = @CodLoc", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@CodLoc", txtCodLoc.Text);
                    cmd.Parameters.AddWithValue("@Intitul", txtLibLoc.Text);
                    cmd.Parameters.AddWithValue("@CodNiv", cmbSite.ValueMember);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Données  modifiées avec succès", "Mis à jour", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                    chargerListe2();

                    pnlMaj2.Visible = false;
                    pnlNouv2.Visible = true;
                }
                catch (Exception)
                {
                    MessageBox.Show("Echec de l'opération");
                }
            }

        }

        private void btnAnn3_Click(object sender, EventArgs e)
        {
            pnlMaj2.Visible = false;
            pnlNouv2.Visible = true;


          
        }
        private void btnSupLoc_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Delete from T_Local where CodLoc= @CodLoc", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@CodLoc", dtgliste2.CurrentRow.Cells[0].Value);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Suppression effectuée avec succès", "Enregister", MessageBoxButtons.OK, MessageBoxIcon.Information);

                chargerListe2();
                pnlMaj2.Visible = false;
                pnlNouv2.Visible = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Veuillez selectionner une ligne", "Indication", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion


        //Les INSTRUCTION DE LA TABLES NIVEAU
        #region NIVEAU 
        public void chargerListe1()
        {

            try
            {
                SqlCommand cmd = new SqlCommand("Select * from T_Niveau", con);
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
        private void button4_Click(object sender, EventArgs e)
        {
            pnlMaj1.Visible = true;
            pnlNouv1.Visible = false;
            btnSauvNiv.Text = "Enregistrer";
            Viderchamps();
        }
        //Enregistrement et modification (s'il est ecrit enregistrer sur le bouton que la première condition sxécute sinon la deuxième s'exécute   
        private void button6_Click(object sender, EventArgs e)
        {


            if (btnSauvNiv.Text == "Enregistrer")
            {

                try
                {
                    SqlCommand cmd = new SqlCommand("Insert into T_Niveau values (@CodNiv, @Descript)", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@CodNiv", txtCodNiv.Text);
                    cmd.Parameters.AddWithValue("@Descript", txtLibNiv.Text);
                    MessageBox.Show("Données  enregistrées avec succès", "Enregister", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

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
                    SqlCommand cmd = new SqlCommand("Update T_Niv Set Descript = @Descript where CodNiv = @CodNiv", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@CodNiv", txtCodNiv.Text);
                    cmd.Parameters.AddWithValue("@Descript", txtLibNiv.Text);

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

        //Suppression 
       
        private void btnSuppNiv_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Delete from T_Niveau where CodNiv= @CodNiv", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@CodNiv", dtgliste1.CurrentRow.Cells[0].Value);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Suppression effectuée avec succès", "Enregister", MessageBoxButtons.OK, MessageBoxIcon.Information);
                chargerListe2();
                pnlMaj1.Visible = false;
                pnlNouv1.Visible = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Echec de l'opération");
            }
        }
        private void btnAnnNiv_Click(object sender, EventArgs e)
        {
            pnlMaj1.Visible = false;
            pnlNouv1.Visible = true;
        }
        public void chargerCombo()
        {
            SqlDataAdapter cmd = new SqlDataAdapter("Select * FROM T_Niveau", con);
            DataTable dt = new DataTable();
            cmd.Fill(dt);
            DataRow row = dt.NewRow();
            row[0] = 0;
            row[1] = "Veuiller selectionner";
            dt.Rows.InsertAt(row, 0);
            cmbSite.DataSource = dt;
            cmbSite.DisplayMember = "Descript";
            cmbSite.ValueMember = "CodNiv";
        }
        #endregion

        private void Frm_Bat_Load(object sender, EventArgs e)
        {
            chargerListe1();
            chargerListe2();
            chargerListe();
            chargerCombo();
        }
    }
}
