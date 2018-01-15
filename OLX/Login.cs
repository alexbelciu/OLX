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
using System.Configuration;
using System.Data.Common;
using System.Transactions;

namespace OLX
{
    public partial class Login : Form
    {
        public string actiune = "";
        public string corespondent = "";
        public int anunt = 0;
        public Login()
        {
            InitializeComponent();
        }
        public Login(string act)
        {
            InitializeComponent();
            actiune = act;
        }
        public Login(string act, string user_el)
        {
            InitializeComponent();
            actiune = act;
            corespondent = user_el;
        }
        public Login(string act, int id_anunt)
        {
            InitializeComponent();
            actiune = act;
            anunt = id_anunt;
        }



        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegisterPage_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegisterPagePage reg = new RegisterPagePage();
            reg.Show();
        }

        public bool LoginPageTRANSACTION(string email, string hash_parola)
        {
            ///////////////////////////////////////////////////////////////////////////////
            using (TransactionScope trans = new TransactionScope())
            {
                var context = new OLXDataContext();
                string parolaBD = "";

                var rez = from ps in context.DB_PASSWORDs
                          select new { ps.PAROLA, ps.ID_USER };
                foreach (var item in rez)
                {
                    if (item.ID_USER == email)
                        parolaBD = item.PAROLA.ToString();
                }

                if (parolaBD != hash_parola)
                {
                    MessageBox.Show("Email sau parola gresita", "EROARE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                var log = from l in context.DB_LOGINs
                          where l.ID_USER == email
                          select l.ID_USER;
                List<string> temp = new List<string>();
                foreach(var item in log)
                {
                    temp.Add(item.ToString());
                }
                if (temp.Count != 0)
                {
                    var log1 = from l in context.DB_LOGINs
                              where l.ID_USER == email
                              select l.DATA_DELOGAT;
                    List<string> temp1 = new List<string>();
                    foreach (var item in log1)
                    {
                        temp1.Add(item.ToString());
                    }
                    if (temp1.Count == 0)
                    {
                        MessageBox.Show("Sunteti deja conectat", "ATENTIE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                }

                context.tranLogIn(email, hash_parola);
                context.SubmitChanges();

                this.Close();
                trans.Complete();
                return true;
            }
            //////////////////////////////////////////////////////////////////////////////////////
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var context = new OLXDataContext();
            string email = tboxEmail.Text;
            string hash = Program.makeHash(tboxPassword.Text);
            
            if (LoginPageTRANSACTION(email,hash)==true)
            {
                MessageBox.Show("Esti logat!");
                Program.OLXusername = email;

                if (actiune == "ADD")
                {
                    AddAnunt a = new AddAnunt();
                    a.Show();
                }
                if (actiune == "FAV")
                {
                    context.spAddToFavorite(Program.OLXusername, anunt);
                }
                if (actiune == "CHAT")
                {
                    CasutaChat c = new CasutaChat(Program.OLXusername, corespondent);
                    c.Show();
                }

                this.Close();
                OLX.MainPage.load_LogOutButton();
            }
        }
        

        /*private void Login_Load(object sender, EventArgs e)
        {
        }*/
    }
}
