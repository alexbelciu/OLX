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
    public partial class UserPage : Form
    {
        string USER = "";
        public UserPage(string user)
        {
            InitializeComponent();
            USER = user;
            var context = new OLXDataContext();
            var result = from u in context.DB_USERs
                         join j in context.DB_RO_COUNTies on u.ID_JUDET equals j.ID
                         join o in context.DB_RO_CITies on u.ID_ORAS equals o.ID
                         where u.ID == user
                         select new
                         {
                             u.NUME,
                             u.TELEFON,
                             j.NUME_JUDET,
                             o.NUME_ORAS
                         };

            labelNume.Text = result.FirstOrDefault().NUME.ToString();
            labelOras.Text = result.FirstOrDefault().NUME_ORAS.ToString();
            labelJudet.Text = result.FirstOrDefault().NUME_JUDET.ToString();
            labelTelefon.Text = result.FirstOrDefault().TELEFON.ToString();
            labelEmail.Text = user;

            var medie = context.spGetMedieUser(user);
            List<string> temp = new List<string>();
            foreach(var item in temp)
            {
                temp.Add(item.ToString());
            }
            if (temp.Count == 0)
                labelMedie.Text = "0.0";
            else labelMedie.Text = temp.First();
        }

        private void button1_Click(object sender, EventArgs e)
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
                if (USER == Program.OLXusername)
                {
                    ListaConversatii list = new ListaConversatii();
                    list.Show();
                }
                else
                {
                    CasutaChat chat = new CasutaChat(Program.OLXusername, USER);
                    chat.Show();
                }
            }
            else
            {
                Login log = new Login("CHAT", USER);
                log.Show();
            }
        }
    }
}
