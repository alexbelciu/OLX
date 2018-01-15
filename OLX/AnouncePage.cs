using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OLX
{

    public partial class AnouncePage : Form
    {
        int vot;
        string userID = "";
        int anuntID;
        bool IsTheCreator;
        string pachetSelectat = "";
        public static IQueryable printAnounceComments(int id_anunt)
        {
            var context = new OLXDataContext();
            var result = from c in context.ANOUNCES_COMMENTs
                         where c.ID_ANUNT == id_anunt
                         orderby c.DATA_ADAUGAT descending
                         select new
                         {
                             c.ID_USER,
                             c.COMENTARIU
                         };
            return result;
        }

        public AnouncePage(string idUsr, int idAnun, bool Euamcreat)
        {
            InitializeComponent();
            userID = idUsr;
            anuntID = idAnun;
            IsTheCreator = Euamcreat;
            if (Euamcreat == true) {
                Button btn = new Button();
                btn.Left = 24;
                btn.Top = 284;
                btn.Text = "Promoveaza anunt";
                btn.Width = 175;
                btn.Height = 24;
                panel2.Controls.Add(btn); //here
                btn.Click += ButtonPromote_Click;

                Label lbpachet = new Label();
                lbpachet.Text = "Pachet promovare";
                lbpachet.Top = 300;
                lbpachet.Left = 24;
                panel2.Controls.Add(lbpachet);

                ComboBox cboxpachet = new ComboBox();
                var con = new OLXDataContext();
                cboxpachet.Top = 316;
                cboxpachet.Left = 24;
                panel2.Controls.Add(cboxpachet);
                var rez = from p in con.DB_PROMOTE_PACKAGEs
                          select p.NUME_PACHET;
                foreach (var item1 in rez)
                {
                    cboxpachet.Items.AddRange(new object[] { item1.ToString() });
                }
                cboxpachet.SelectedIndexChanged += Pachet_SelectedIndexChanged;
                
            }

            var context = new OLXDataContext();
            context.spAccesAnounce(anuntID);//NR VIZUALIZARI ++
        }
        private void ButtonPromote_Click(object sender, EventArgs e)
        {
            var context = new OLXDataContext();
            context.spAddPromotedAnounce(anuntID, pachetSelectat);
            
            var results = from c in context.DB_PROMOTE_PACKAGEs
                          where c.NUME_PACHET == pachetSelectat
                          select new
                          {
                              c.NR_ZILE,
                              c.SUMA
                          };

            string message = "Ati selectat pachetul" + pachetSelectat + "valabil" + results.FirstOrDefault().NR_ZILE + "\n" + "la pretul de numai" + results.FirstOrDefault().SUMA;
            MessageBox.Show(message);
            this.Hide();
        }
        private void Pachet_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox p = (ComboBox)sender;
            pachetSelectat = p.ToString();
        }

        private void star1_Click_1(object sender, EventArgs e)
        {
             star1.BackgroundImage = Properties.Resources.rsz_star;
             star2.BackgroundImage = Properties.Resources.rsz_star_blue_empty;
             star3.BackgroundImage = Properties.Resources.rsz_star_blue_empty;
             star4.BackgroundImage = Properties.Resources.rsz_star_blue_empty;
             star5.BackgroundImage = Properties.Resources.rsz_star_blue_empty;
             vot = 1;
             OLXDataContext dbContext;
             dbContext = new OLXDataContext();
             dbContext.tranAddVoteAnounce(userID, anuntID, vot);
            
        }
        private void star2_Click_1(object sender, EventArgs e)
        {
            star1.BackgroundImage = Properties.Resources.rsz_star;
            star2.BackgroundImage = Properties.Resources.rsz_star;
            star3.BackgroundImage = Properties.Resources.rsz_star_blue_empty;
            star4.BackgroundImage = Properties.Resources.rsz_star_blue_empty;
            star5.BackgroundImage = Properties.Resources.rsz_star_blue_empty;
            vot = 2;
            OLXDataContext dbContext;
            dbContext = new OLXDataContext();
            dbContext.tranAddVoteAnounce(userID, anuntID, vot);
        }
        private void star3_Click_1(object sender, EventArgs e)
        {
            star1.BackgroundImage = Properties.Resources.rsz_star;
            star2.BackgroundImage = Properties.Resources.rsz_star;
            star3.BackgroundImage = Properties.Resources.rsz_star;
            star4.BackgroundImage = Properties.Resources.rsz_star_blue_empty;
            star5.BackgroundImage = Properties.Resources.rsz_star_blue_empty;
            vot = 3;
            OLXDataContext dbContext;
            dbContext = new OLXDataContext();
            dbContext.tranAddVoteAnounce(userID, anuntID, vot);
        }
        private void star4_Click_1(object sender, EventArgs e)
        {
            star1.BackgroundImage = Properties.Resources.rsz_star;
            star2.BackgroundImage = Properties.Resources.rsz_star;
            star3.BackgroundImage = Properties.Resources.rsz_star;
            star4.BackgroundImage = Properties.Resources.rsz_star;
            star5.BackgroundImage = Properties.Resources.rsz_star_blue_empty;
            vot = 4;
            OLXDataContext dbContext;
            dbContext = new OLXDataContext();
            dbContext.tranAddVoteAnounce(userID, anuntID, vot);
        }
        private void star5_Click_1(object sender, EventArgs e)
        {
            star1.BackgroundImage = Properties.Resources.rsz_star;
            star2.BackgroundImage = Properties.Resources.rsz_star;
            star3.BackgroundImage = Properties.Resources.rsz_star;
            star4.BackgroundImage = Properties.Resources.rsz_star;
            star5.BackgroundImage = Properties.Resources.rsz_star;
            vot = 5;
            OLXDataContext dbContext;
            dbContext = new OLXDataContext();
            dbContext.tranAddVoteAnounce(userID, anuntID, vot);

        }

        private void AnouncePage_Load(object sender, EventArgs e)
        {
            var context = new OLXDataContext();
            dataGridView1.DataSource = printAnounceComments(anuntID);// dbContext.spGetAnounceComments(anuntID);
            //dbContext.spGetVotUserPentruAnuntCurent(userID, anuntID);
            var result = from c in context.DB_ANOUNCEs
                         join o in context.DB_USERs
                         on c.ID_USER equals o.ID
                         where c.ID == anuntID
                         select new
                         {
                             c.ID,
                             c.LOC_INTALNIRE,
                             c.TITLU,
                             c.PRET,
                             c.DETALII,
                             c.NEGOCIABIL,
                             c.STARE_PRODUS,
                             c.DATA_ADAUGAT,
                             o.ID_JUDET,
                             o.ID_ORAS,
                             o.NUME,
                             o.TELEFON
                         };
            foreach (var index in result)
            {
                label1.Text = index.PRET.ToString();

                if (index.NEGOCIABIL.ToString() == "0") {
                    label2.Visible = false;
                }
                else label2.Visible = true;

                if (index.STARE_PRODUS.ToString() == "0"){
                    label8.Text = "";
                }
                else label8.Text = "Stare Produs: " + index.STARE_PRODUS.ToString();

                label6.Text = index.DATA_ADAUGAT.ToString();

                richTextBox1.Text = index.DETALII.ToString();

                label18.Text = index.ID.ToString();

                labelTitlu.Text = index.TITLU.ToString();

                labelNume.Text = result.FirstOrDefault().NUME.ToString();

                var judoras = from i in context.DB_RO_COUNTies
                              where i.ID == Convert.ToInt32(index.ID_JUDET.ToString())
                              select new{ i.NUME_JUDET };
                labelJudet.Text = judoras.FirstOrDefault().NUME_JUDET.ToString();

                var oras = from i in context.DB_RO_CITies
                              where i.ID == Convert.ToInt32(index.ID_ORAS.ToString()) 
                              select new { i.NUME_ORAS };
                labelOras.Text = oras.FirstOrDefault().NUME_ORAS.ToString();

                var viz = (from a in context.ANOUNCE_ACCSES_STATs
                           where a.ID_ANUNT.ToString() == anuntID.ToString()
                           select a.NR_VIZUALIZARI);
                List<string> temp = new List<string>();
                foreach(var item in viz)
                {
                    temp.Add(item.ToString());
                }
                if (temp.Count == 0)
                {
                    label5.Text = "0";
                }
                else label5.Text = temp[0];

                var m= (from a in context.ANOUNCE_ACCSES_STATs
                           where a.ID_ANUNT.ToString() == anuntID.ToString()
                           select a.NR_VIZUALIZARI);
                List<string> temp2 = new List<string>();
                foreach (var item in m)
                {
                    temp2.Add(item.ToString());
                }
                if (temp2.Count == 0)
                {
                    labelMedie.Text = "0.0";
                }
                else labelMedie.Text = context.spGetMedieVoturi(anuntID).ToString();

            }
            ////if-uri detalii
            
            dataGridView2.DataSource = context.spGetAnounceDetails(anuntID);
            if (!context.spGetAnounceDetails(anuntID).Any()) {
                panel3.Visible = false;
            }

        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            OLXDataContext dbContext;
            dbContext = new OLXDataContext();
            var context = new OLXDataContext();
            var result = from u in context.DB_USERs
                         where u.ID == Program.OLXusername
                         select u.ID;
            List<string> t = new List<string>();
            foreach (var item in result)
            {
                t.Add(item.ToString());
            }
            if (t.Count != 0)//e in DB_USERS
            {
                dbContext.spAddToFavorite(Program.OLXusername, anuntID);
                MessageBox.Show("Adaugata la favoite");
            }
            else
            {
                Login l = new Login("FAV", anuntID);
                l.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var context = new OLXDataContext();
            var result = from u in context.DB_USERs
                         where u.ID == Program.OLXusername
                         select u.ID;
            List<string> t = new List<string>();
            foreach (var item in result)
            {
                t.Add(item.ToString());
            }
            if (t.Count != 0)//e in DB_USERS
            {
                CasutaChat chat = new CasutaChat(Program.OLXusername, userID);
                chat.Show();
            }
            else
            {
                Login log = new Login("CHAT", userID);
                log.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var context = new OLXDataContext();
            var result = from u in context.DB_USERs
                         where u.ID == Program.OLXusername
                         select u.ID;
            List<string> t = new List<string>();
            foreach (var item in result)
            {
                t.Add(item.ToString());
            }
            if (t.Count != 0)//e in DB_USERS
            {
                context.spAddComentariu(anuntID, Program.OLXusername, textBox2.Text);
                dataGridView1.DataSource = context.spGetAnounceComments(anuntID);
            }
            else
            {
                Login log = new Login();
                log.Show();
            }
        }

        private void buttonDetalii_Click(object sender, EventArgs e)
        {
            var context = new OLXDataContext();
            int topLabel = 300;
            int leftLabel = 10;

            Label lbtel = new Label();
            Label lbemail= new Label();
            Label lb1 = new Label();
            TextBox tboxloc = new TextBox();
            
            var result = from u in context.DB_USERs
                         join j in context.DB_RO_COUNTies on u.ID_JUDET equals j.ID
                         join o in context.DB_RO_CITies on u.ID_ORAS equals o.ID
                         where u.ID.ToString() == userID
                         select new
                         {
                             u.ID,
                             u.NUME,
                             u.TELEFON,
                             j.NUME_JUDET,
                             o.NUME_ORAS
                         };


            lbtel.Top = topLabel + 25;
            lbtel.Left = leftLabel;
            lbtel.Text = "TELEFON: "+result.FirstOrDefault().TELEFON.ToString();
            panel2.Controls.Add(lbtel);

            lbemail.Top = topLabel + 50;
            lbemail.Left = leftLabel;
            lbemail.Text = "EMAIL: " + result.FirstOrDefault().ID.ToString();
            panel2.Controls.Add(lbemail);

            lb1.Top = topLabel + 75;
            lb1.Left = leftLabel;
            lb1.Text = "Punct de intalnire";
            panel2.Controls.Add(lb1);

            var meet = from an in context.DB_ANOUNCEs
                       where an.ID == anuntID
                       select new
                       {
                           an.LOC_INTALNIRE
                       };
            tboxloc.Top = topLabel + 100;
            tboxloc.Left = leftLabel;
            tboxloc.Text = meet.FirstOrDefault().LOC_INTALNIRE.ToString();
            panel2.Controls.Add(tboxloc);

            context.spGetUserExtraInfo(anuntID);//NR ACCES TEL++
        }
        
    }
}
