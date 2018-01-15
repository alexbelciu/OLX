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
using System.Drawing.Design;

namespace OLX
{
    public partial class MainPage : Form
    {
        private string mainCategory = "Auto, Moto, Ambarcatiuni";
        private string subCategory = "Toate";
        private string ORAS;
        private string JUDET;
        static public Panel panel3 = new Panel();
        private List<int> REZ_CAUTARE = new List<int>();
        public static IQueryable printPromotedAnounces()
        {
            var context = new OLXDataContext();

            context.spDeletedOldPromotedAnounces();

            var result = (from a in context.DB_PROMOTED_ANOUNCEs
                          join p in context.DB_PROMOTE_PACKAGEs on a.ID_PACHET equals p.ID
                          orderby p.SUMA, a.DATA_START descending
                          select a.ID_ANUNT
                          );
            return result;
        }

        static List<int> getSearchResult(string text_cautat)
        {
            var context = new OLXDataContext();
            string sep = " ,;:!?";
            Dictionary<int, int> REZ = new Dictionary<int, int>();//id_uri anunturi, nr_potriviri
            List<int> REZ_sortate = new List<int>();
            List<string> splitSearch = new List<string>();

            foreach (string cuvant in text_cautat.Split(sep.ToCharArray()))
            {
                splitSearch.Add(cuvant);
            }

            foreach (string cuvant in splitSearch)
            {
                var listaAnunturiAsociate = from a in context.DB_ASSOCIATED_WORDs
                                            join w in context.DB_SEARCH_WORDs on a.ID_CUVANT equals w.ID_CUVANT
                                            where w.CUVANT.ToString() == cuvant
                                            select a.ID_ANUNT;
                foreach (var anunt_nou in listaAnunturiAsociate)//verificam fiecare cuvant
                {
                    bool gasit = false;
                    foreach (KeyValuePair<int, int> anunt_existent in REZ)//cautam in anunturile deja gasite
                    {
                        if (anunt_existent.Key.ToString() == anunt_nou.ToString())
                        {
                            int a = Convert.ToInt32(anunt_existent.Key.ToString());
                            REZ[a]++;
                            gasit = true;
                            break;
                        }
                    }
                    if (gasit == false)
                    {
                        int r = Convert.ToInt32(anunt_nou.ToString());
                        REZ.Add(r, 1);//se adauga daca nu se gaseste
                    }
                        
                }
            }

            int max = 0;
            foreach (KeyValuePair<int, int> item in REZ)
            {
                if (item.Value > max)
                    max = item.Value;
            }
            for (int i = max; i >= 1; i--)
            {
                foreach (KeyValuePair<int, int> item in REZ)
                {
                    if (item.Value == i)
                    {
                        REZ_sortate.Add(item.Key);
                    }
                }
            }

            return REZ_sortate;
        }

        public MainPage()
        {
            var dbContext = new OLXDataContext();
            InitializeComponent();
            panel3.Top = 4;
            panel3.Left = 961;
            panel3.Width = 151;
            panel3.Height = 52;
            panel_up.Controls.Add(panel3);

            
            dbContext.SubmitChanges();

            var result1 = from j in dbContext.DB_RO_COUNTies
                         select j.NUME_JUDET;
            foreach (var item in result1)
            {
                comboBox1.Items.AddRange(new object[] { item.ToString() });
            }
            var result2 = from o in dbContext.DB_RO_CITies
                         select o.NUME_ORAS;
            foreach (var item in result2)
            {
                comboBox2.Items.AddRange(new object[] { item.ToString() });
            }
            comboBox3.Items.AddRange(new object[] { "Toate" });
            comboBox3.Items.AddRange(new object[] { "lei" });
            comboBox3.Items.AddRange(new object[] { "euro" });

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;

            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = printPromotedAnounces(); //dbContext.spGetFirstDisplay();// 
            //dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.Refresh();

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            var dbContext = new OLXDataContext();
            if (textBox1.Text != "")
            {
                dbContext.spAddSearchFilterMinPrice(Program.OLXusername, Convert.ToInt32(textBox1.Text));
            }
            if (textBox2.Text != "")
            {
                dbContext.spAddSearchFilterMaxPrice(Program.OLXusername, Convert.ToInt32(textBox2.Text));
            }
            if (JUDET != "" && JUDET != "Toata tara")
            {
                dbContext.spAddSearchFilterCounty(Program.OLXusername,JUDET);
            }
            if (ORAS != "" && ORAS != "Toata tara")
            {
                dbContext.spAddSearchFilterCity(Program.OLXusername, ORAS);
            }
            if (comboBox3.Text != "" && comboBox3.Text != "Toate")
            {
                dbContext.spAddSearchFilterMoneda(Program.OLXusername, comboBox3.Text);
            }
            if(textBox3.Text != "")
            {
                dbContext.spAddSearchText(Program.OLXusername, textBox3.Text);
            }

            
            foreach(int item in getSearchResult(textBox3.Text))
            {
                int a = Convert.ToInt32(item.ToString());
                REZ_CAUTARE.Add(a);
            }
            foreach(int anunt in REZ_CAUTARE)
            {
                dbContext.spInsertSearchResult(Program.OLXusername, anunt); 
            }

            var final_result = from r in dbContext.USER_SEARCH_RESULTs
                               where r.ID_USER == Program.OLXusername
                               select new
                               {
                                   r.ID_ANUNT,
                                   r.TITLU,
                                   r.ID_PROPRIETAR,
                                   r.PRET,
                                   r.NEGOCIABIL,
                                   r.JUDET,
                                   r.ORAS,
                                   r.POZA
                               };
            dataGridView1.DataSource = final_result;
            dataGridView1.Refresh();

        }
       
        private void ButtonCat_Click(object sender, EventArgs e)
        {
            var dbContext = new OLXDataContext();
            Button button = (Button)sender;
            mainCategory = button.Text;
            dbContext.spAddSearchFilterCategorie(Program.OLXusername, mainCategory);
            panel2.Controls.Clear();
            panel2.Refresh();
        }
        private void ButtonSubCat_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            subCategory = button.Text;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            var connection = new SqlConnection();
            connection.ConnectionString = "Server=CRISTI-PC\\MSSQLSERVER2012;Database=OLX;Trusted_Connection=true";
            connection.Open();
            
            int Y = 7;
            int left = 12, top = 7;
            
            int i = 0;
            List<int> lista_categorii = new List<int>();

            //var projection1 = (from rep in dbContext.DB_SEARCH_CATEGORies select new { rep.NUME_CATEGORIE}  ).ToList();
            
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
        
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            var connection = new SqlConnection();
            connection.ConnectionString = "Server=CRISTI-PC\\MSSQLSERVER2012;Database=OLX;Trusted_Connection=true";
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
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var dbContext = new OLXDataContext();
            DataGridView dgv = sender as DataGridView;
            if (dgv == null)
                return;
            foreach (DataGridViewRow row in dgv.SelectedRows)
            {
                int idanunt = Convert.ToInt32(row.Cells["ID_ANUNT"].Value.ToString());

                bool IStheCreator=false;
                if (dbContext.spVerificaUserToAnounce(idanunt).ToString() == Program.OLXusername)
                    IStheCreator = true;

                AnouncePage a = new AnouncePage(row.Cells["ID_PROPRIETAR"].Value.ToString(), idanunt, IStheCreator);//id anunt ev driv corespunzator
                a.Show();
            }
        }
        
        
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox c = (ComboBox)sender;
            ORAS = c.Text;
        }

        private void AddAnunt_Click(object sender, EventArgs e)
        {
            var dbContext = new OLXDataContext();
            var result = from u in dbContext.DB_USERs
                         where u.ID == Program.OLXusername
                         select u.ID;
            List<string> t = new List<string>();
            foreach(var item in result)
            {
                t.Add(item.ToString());
            }
            if (t.Count!=0)//e in DB_USERS
            {
                AddAnunt a = new AddAnunt();
                a.Show();
            }
            else
            {
                Login l = new Login("ADD");
                l.Show();
                
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            var dbContext = new OLXDataContext();
            var result = from u in dbContext.DB_USERs
                         where u.ID == Program.OLXusername
                         select u.ID;
            List<string> t = new List<string>();
            foreach (var item in result)
            {
                t.Add(item.ToString());
            }
            if (t.Count == 0)//e in DB_USERS
            {
                Login log = new Login();
                log.Show();
            }
            else
            {
                UserPage pag = new UserPage(Program.OLXusername);
                pag.Show();
            }
        }
        private void buttonFavorite_Click(object sender, EventArgs e)
        {
            var dbContext = new OLXDataContext();
            var login = from l in dbContext.DB_LOGINs
                        where l.ID_USER == Program.OLXusername
                        select l.ID_USER;
            List<string> temp = new List<string>();
            foreach (var item in login)
            {
                temp.Add(item.ToString());
            }
            if (temp.Count != 0)//buton de log out
            {
                FavoriresPage a = new FavoriresPage(Program.OLXusername);
                a.Show();
            }
        }
        
        static public void load_LogOutButton()
        {
            var dbContext = new OLXDataContext();
            var login = from l in dbContext.DB_LOGINs
                        where l.ID_USER == Program.OLXusername
                        select l.ID_USER;
            List<string> temp = new List<string>();
            foreach (var item in login)
            {
                temp.Add(item.ToString());
            }
            if (temp.Count != 0)//buton de log out
            {
                Label lbnume = new Label();
                lbnume.Text = "Bine ai venit, "+Program.OLXusername;
                lbnume.Top = 3;
                lbnume.Left = 3;
                MainPage.panel3.Controls.Add(lbnume);

                Button btnLogOut = new Button();
                btnLogOut.Left = 3;
                btnLogOut.Top = 29;
                btnLogOut.Text = "Log Out";
                btnLogOut.Width = 114;
                btnLogOut.Height = 23;
                MainPage.panel3.Controls.Add(btnLogOut); //here
                btnLogOut.Click += buttonLogOut_Click;
            }
        }
        static public void hide_LogOutButton()
        {
            MainPage.panel3.Controls.Clear();
        }
        static public void buttonLogOut_Click(object sender, EventArgs e)
        {
            var dbContext = new OLXDataContext();
            var result = from u in dbContext.DB_LOGINs
                         where u.DATA_DELOGAT == null
                         select new { u.ID_USER };

            bool este = false;
            foreach (var item in result)
            {
                if (item.ID_USER.ToString().Equals(Program.OLXusername))
                {
                    este = true;
                    break;
                }
            }
            if (este == true)
            {
                dbContext.tranLogOut(Program.OLXusername);
                Program.OLXusername = Program.getRandomUserID(16);
                MessageBox.Show("V-ati delogat");
                OLX.MainPage.hide_LogOutButton();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var dbContext = new OLXDataContext();
            comboBox2.Items.Clear();

            var judet = comboBox1.Text;

            var id_judet = from o in dbContext.DB_RO_COUNTies
                           where o.NUME_JUDET.ToString() == judet.ToString()
                           select o.ID;

            var result = from o in dbContext.DB_RO_CITies
                         join j in dbContext.DB_RO_COUNTies
                         on o.ID_JUDET equals j.ID
                         where j.NUME_JUDET == judet.ToString()
                         select o.NUME_ORAS;

            foreach (var item in result)
            {
                comboBox2.Items.AddRange(new object[] { item.ToString() });
            }

            ComboBox c = (ComboBox)sender;
            JUDET = c.Text;
        }
        
    }
}
