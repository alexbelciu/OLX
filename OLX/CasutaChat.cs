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
    public partial class CasutaChat : Form
    {
        
        public string eu = "";
        public string el ="";
        public CasutaChat(string user_eu, string user_corespondent)
        {
            InitializeComponent();

            var context = new OLXDataContext();
            dataGridViewMesaje.DataSource = context.spGetMessagesBetweenUsers(user_eu, user_corespondent);
            eu = user_eu;
            el = user_corespondent;
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            var context = new OLXDataContext();
            context.spSendMesaj(eu, el, richTextBox1.Text.ToString());
            dataGridViewMesaje.Refresh();
        }

    }
}
