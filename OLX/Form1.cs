using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Linq;
using System.Data.Common;
using System.Data.SqlClient;

namespace OLX
{
    
    public partial class Form1 : Form
    {
        DataClasses1DataContext dbContext;
        string mainCategory= "Auto, Moto, Ambarcatiuni";
        public Form1()
        {
            
            InitializeComponent();
            dbContext= new DataClasses1DataContext();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string produs;
            string locatie;
            string judet;

            produs = textBox3.Text;
            locatie = textBox2.Text;
            judet = textBox1.Text;
            var projection = (from rep in dbContext.DB_RO_COUNTies where rep.NUME_JUDET==judet
                              select new { rep.ID,rep.NUME_JUDET }  ).ToList();
             dataGridView1.DataSource = projection;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        
        private void ButtonCat_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            mainCategory = button.Text;
            panel2.Controls.Clear();
            panel2.Refresh();
        }
        private void ButtonSubCat_Click(object sender, EventArgs e)
        {

            Button button = (Button)sender;
            /////////////////
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            var connection = new SqlConnection();
            connection.ConnectionString = "Server=.;Database=OLX;Trusted_Connection=true";
            connection.Open();


            int Y = 7;
            int left=12, top=7;
            
            //////
            int i = 0;
            List<int> lista_categorii = new List<int>();
            
            var projection1 = (from rep in dbContext.DB_SEARCH_CATEGORies select new { rep.NUME_CATEGORIE}  ).ToList();
           
            ////
            var cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT NUME_CATEGORIE FROM DB_SEARCH_CATEGORIES";
            DbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Button button = new Button();
                button.Left = left;
                button.Top = top;
                button.Text = reader["NUME_CATEGORIE"].ToString();
                button.Width = 200;
                panel1.Controls.Add(button); //here
                button.Click += ButtonCat_Click;


                if ((i + 1) % 3 != 0)
                {
                    top += button.Height + 4;
                }
                else
                {
                    left += button.Width + 4;
                    top = Y;
                }
                i++;
            }
            connection.Close();


        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            var connection = new SqlConnection();
            connection.ConnectionString = "Server=.;Database=OLX;Trusted_Connection=true";
            connection.Open();


            int Y = 7;
            int left = 12, top = 7;

            //////
            int i = 0;
           

            ////
            var cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            var parameter = cmd.CreateParameter();
            parameter.ParameterName = "@MainCat";
            parameter.Value = mainCategory;
            cmd.Parameters.Add(parameter);
            cmd.CommandText = "SELECT ID FROM DB_SEARCH_CATEGORIES WHERE NUME_CATEGORIE=@MainCat";
            var id = cmd.ExecuteScalar();
            parameter = cmd.CreateParameter();
            parameter.ParameterName = "@id";
            parameter.Value = id;
            cmd.Parameters.Add(parameter);
            cmd.CommandText = "SELECT NUME_SUBCATEGORIE FROM DB_SEARCH_SUBCATEGORIES WHERE ID_CATEGORIE=@id";
            DbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Button button = new Button();
                button.Left = left;
                button.Top = top;
                button.Text = reader["NUME_SUBCATEGORIE"].ToString();
                button.Width = 200;
                panel2.Controls.Add(button); //here
                button.Click += ButtonSubCat_Click;


                if ((i + 1) % 3 != 0)
                {
                    top += button.Height + 4;
                }
                else
                {
                    left += button.Width + 4;
                    top = Y;
                }
                i++;
            }
            connection.Close();
        }
    }
}
