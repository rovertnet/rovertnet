using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GOS.Etat_Sortie
{
    public partial class Etat_Signalitique : Form
    {
        public Etat_Signalitique()
        {
            InitializeComponent();
        }

        private void Etat_Signalitique_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=GOS;Integrated Security=True;");
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM V_Enseignant_Local", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                ReportDataSource rds = new ReportDataSource("DataSet1", dt);
                reportViewer1.LocalReport.ReportPath = @"C:\Users\Joel LUNANA\Desktop\robert isipa\GOS1\GOS\Etat_Sortie\report3.rdlc";

                // reportViewer1.LocalReport.ReportPath = global::\Etat\reportClient.rdlc;
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(rds);
                reportViewer1.RefreshReport();
            }
            catch (Exception)
            {
                MessageBox.Show("Echec chargement");
            }
        }
    }
}
