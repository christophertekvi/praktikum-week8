using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace praktikum_week8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        public static string sqlConnection = "server=localhost; uid=root; pwd=;database=premier_league";
        public MySqlConnection sqlConnect = new MySqlConnection(sqlConnection);
        public MySqlCommand sqlCommand;
        public MySqlDataAdapter sqlAdapter;
        public string sqlQuery;

        private void Form1_Load(object sender, EventArgs e)
        {
            lbl_captain1.Text = "";
            lbl_captain2.Text = "";
            lbl_manager1.Text = "";
            lbl_manager2.Text = "";
            lbl_namaStadium.Text = "";
            lbl_capacity.Text = "";
            DataTable dtTeam = new DataTable();
            sqlQuery = "select team_name as 'Nama Tim', team_id as 'ID TEAM' FROM TEAM";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dtTeam);
            cbox_1.DataSource = dtTeam;
            cbox_1.DisplayMember = "Nama Tim";
            cbox_1.ValueMember = "ID TEAM";
            cbox_2.DataSource = dtTeam;
            cbox_2.DisplayMember = "Nama Tim";
            cbox_2.ValueMember = "ID TEAM";
        }

        private void cbox_1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var manager1 = cbox_1.SelectedText;
            lbl_manager1.Text = manager1;
        }
    }
}
