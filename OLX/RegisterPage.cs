using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Transactions;

namespace OLX
{
    public partial class RegisterPagePage : Form
    {
        public string email;
        public string oras;
        public string nume;
        public string telefon;
        public string password;
        public string judet;
        public RegisterPagePage()
        {
            InitializeComponent();
            var context = new OLXDataContext();

            var result1 =from j in context.DB_RO_COUNTies
                         select j.NUME_JUDET;
            foreach (var item in result1)
            {
                if (item.ToString() == "Toata tara")
                    continue;
                comboBoxJudete.Items.AddRange(new object[] { item.ToString() });
            }

            var result2 = from o in context.DB_RO_CITies
                          select o.NUME_ORAS;
            foreach (var item in result2)
            {
                if (item.ToString() == "Toata tara")
                    continue;
                comboBoxOrase.Items.AddRange(new object[] { item.ToString() });
            }
        }

        public bool RegisterPageTRANSACTION(string email, string nume, string oras, string telefon, string judet, string parola)
        {
            ///////////////////////////////////////////////////////////////////////////////
            using (TransactionScope trans = new TransactionScope())
            {
                var context = new OLXDataContext();

                var res = from u in context.DB_USERs
                          where u.NUME.ToString() == email
                          select new { u.ID };
                List<string> temp = new List<string>();
                foreach(var item in temp)
                {
                    temp.Add(item.ToString());
                }
                if (temp.Count != 0)
                    return false;//exista contul

                context.tranSignIn(email, nume, telefon, judet, oras, parola);
                context.SubmitChanges();
                this.Close();
                Login l = new Login();
                l.Show();
                trans.Complete();
                return true;
            }
            //////////////////////////////////////////////////////////////////////////////////////
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegisterPage_Click(object sender, EventArgs e)
        {
            email = tboxEmail.Text;
            nume = tboxNume.Text;
            telefon = tboxTelefon.Text;
            oras = comboBoxOrase.Text;
            judet = comboBoxJudete.Text;
            password = Program.makeHash(tboxPassword.Text.ToString());

            if (email == "")
            {
                MessageBox.Show("Nume incorect", "ATENTIE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (nume=="")
            {
                MessageBox.Show("Email incorect", "ATENTIE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (telefon.Length != 10)
            {
                MessageBox.Show("Format gresit de numar de telefon", "ATENTIE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (oras == "")
            {
                MessageBox.Show("Alegeti un oras", "ATENTIE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (judet== "")
            {
                MessageBox.Show("Alegeti un judet", "ATENTIE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (tboxPassword.Text.ToString()=="")
            {
                MessageBox.Show("Este necesara o parola", "ATENTIE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if(Program.makeHash(textBoxRepeatPass.Text.ToString()) != password)
            {
                MessageBox.Show("A doua parola este incorecta", "ATENTIE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else {
                if (RegisterPageTRANSACTION(email, nume, oras, telefon, judet, password) == true)
                {
                    MessageBox.Show("Cont creat cu succes! Bine ai venit, " + nume + "!", "CONT NOU", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Eroare la creerea contului.Email indisponibil", "CONT NOU", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void comboBoxJudete_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox TEXTJ = (ComboBox)sender;
            var context = new OLXDataContext();
            var resulto = from o in context.DB_RO_CITies
                          join j in context.DB_RO_COUNTies
                          on o.ID_JUDET equals j.ID
                          where j.NUME_JUDET == TEXTJ.Text.ToString()
                          select o.NUME_ORAS;
            comboBoxOrase.Items.Clear();
            foreach (var item in resulto)
            {
                comboBoxOrase.Items.AddRange(new object[] { item.ToString() });
            }
        }

        private void comboBoxOrase_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox TEXTO = (ComboBox)sender;
            var context = new OLXDataContext();
            var resultj = from j in context.DB_RO_COUNTies
                          join o in context.DB_RO_CITies
                          on j.ID equals o.ID_JUDET
                          where o.NUME_ORAS == TEXTO.Text.ToString()
                          select j.NUME_JUDET;
            comboBoxJudete.Items.Clear();
            foreach (var item in resultj)
            {
                comboBoxJudete.Items.AddRange(new object[] { item.ToString() });
            }
        }

        /*private void RegisterPage_Load(object sender, EventArgs e)
        {
        }*/
    }
}
