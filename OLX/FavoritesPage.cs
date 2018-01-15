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
    public partial class FavoriresPage : Form
    {
        string crtUsr;
        public FavoriresPage(string UserCurent)
        {
            crtUsr = UserCurent;
            InitializeComponent();
            OLXDataContext dbContext;
            dbContext = new OLXDataContext();
            dataGridView1.DataSource = dbContext.spGetFavoriteAnounces(UserCurent);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv == null)
                return;
            foreach (DataGridViewRow row in dgv.SelectedRows)
            {
                int idanunt = Convert.ToInt32(row.Cells["ID"].Value.ToString());
                AnouncePage a = new AnouncePage(crtUsr, idanunt,true);//id anunt ev driv corespunzator
                a.Show();
            }
        }

        private void FavoriresPage_Load(object sender, EventArgs e)
        {

        }
    }
}
