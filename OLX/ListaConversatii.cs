using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Common;

using System.Data.Linq;
using System.Data.SqlClient;

namespace OLX
{
    public partial class ListaConversatii : Form
    {
        public static string CHATselectat = "";

        public ListaConversatii()
        {
            InitializeComponent();

            label2.Text = Program.OLXusername;
            panel1.Visible = true;
            int Y = 7, i = 0;
            int left = 12, top = 7;

            //List<string> conversatii = new List<string>();
            //var chats = context.spGetChatsList(Program.OLXusername);
            //foreach (var item in chats)
            //{
            //    conversatii.Add(item.ToString());
            //}
            var context = new OLXDataContext();
            var results = from c in context.ACCOUNT_MESSAGEs
                          where c.ID_USER_CURENT == Program.OLXusername
                          select new
                          {
                              c.ID_USER_CURENT,
                              c.ID_USER_DESTINATAR,
                              c.MESAJ
                          };
            //foreach(var persoana in conversatii)
            foreach (var index in results)
            {
                Button button = new Button();
                button.Left = left;
                button.Top = top;

                MaskedTextBox mask = new MaskedTextBox();
                mask.Left = left + button.Width + 30;
                mask.Top = top;


                button.Width = 100;
                button.Text = index.ID_USER_CURENT.ToString();
                panel1.Controls.Add(button); //here
                button.Click += buttonConversatie_Click;
                //mask.Text = context.spGetLastMessage(Program.OLXusername, persoana.ToString()).ToString();
                mask.Text = index.MESAJ;
                mask.Width = 300;
                panel1.Controls.Add(mask);

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

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
            int Y = 7, i = 0;
            int left = 12, top = 7;

            //List<string> conversatii = new List<string>();
            //var chats = context.spGetChatsList(Program.OLXusername);
            //foreach (var item in chats)
            //{
            //    conversatii.Add(item.ToString());
            //}
            var context = new OLXDataContext();
            var results = from c in context.ACCOUNT_MESSAGEs
                          where c.ID_USER_CURENT == Program.OLXusername
                          select new
                          {
                              c.ID_USER_CURENT,
                              c.ID_USER_DESTINATAR,
                              c.MESAJ
                          };
            //foreach(var persoana in conversatii)
            foreach (var index in results)
            {
                Button button = new Button();
                button.Left = left;
                button.Top = top;

                MaskedTextBox mask = new MaskedTextBox();
                mask.Left = left + button.Width + 30;
                mask.Top = top;


                button.Width = 100;
                button.Text = index.ID_USER_CURENT.ToString();
                panel1.Controls.Add(button); //here
                button.Click += buttonConversatie_Click;
                //mask.Text = context.spGetLastMessage(Program.OLXusername, persoana.ToString()).ToString();
                mask.Text = index.MESAJ;
                mask.Width = 300;
                panel1.Controls.Add(mask);

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
        }

        private void buttonConversatie_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            CHATselectat = button.Text;
            CasutaChat chat = new CasutaChat(Program.OLXusername, CHATselectat);
            chat.Show();
        }

        private void ListaConversatii_Load(object sender, EventArgs e)
        {

        }
    }
}
