using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OLX
{
    public partial class AddAnunt : Form
    {
        public string autoMarca;
        public string autoModel;
        public string autoCuloare;
        public string autoCutieViteze;
        public string autoAn;
        public string autoNrKM;
        public string autoCaroserie;
        public string autoCombustibil;
        public string autoCapacitateMotor;
        public string muncaTip;
        public string muncaTipMob;
        public int muncaSalariu;
        public string fashionTipArticol;
        public string fashionMarimea;
        public string fashionCuloare;
        public string fashionMarca;
        public string casaCamere;
        public string casaSuprafata;
        public string casaCompartimentare;
        public string casaAn;
        public string casaTipVanzator;
        public bool casaParcare;
        public string casaSuprafataCurte;

        Label lbIDMarca = new Label();
        ComboBox cboxMarca = new ComboBox();
        Label lbModel = new Label();
        TextBox tboxModel = new TextBox();
        Label lbCuloareAuto = new Label();
        TextBox tboxCuloareAuto = new TextBox();
        Label lbCutieViteze = new Label();
        TextBox tboxCutieViteze = new TextBox();
        Label lbAnAuto = new Label();
        TextBox tboxAnAuto = new TextBox();
        Label lbRulaj = new Label();
        TextBox tboxRulaj = new TextBox();
        Label lbCaroserie = new Label();
        TextBox tboxCaroserie = new TextBox();
        Label lbFuel = new Label();
        TextBox tboxFuel = new TextBox();
        Label lbMotor = new Label();
        TextBox tboxMotor = new TextBox();

        Label lbTipMunca = new Label();
        TextBox tboxTipMunca = new TextBox();
        Label lbSalariu = new Label();
        TextBox tboxSalariu = new TextBox();
        Label lbTipMobilitate = new Label();
        TextBox tboxTipMobilitate = new TextBox();
        
        Label lbTipArticolVestimentar = new Label();
        TextBox tboxTipArticolVestimentar = new TextBox();
        Label lbMarime = new Label();
        TextBox tboxMarime = new TextBox();
        Label lbCuloareModa = new Label();
        TextBox tboxCuloareModa = new TextBox();
        Label lbMarcaModa = new Label();
        TextBox tboxMarcaModa = new TextBox();
        Label lbNrCamere = new Label();

        TextBox tboxNrCamere = new TextBox();
        Label lbSuprafata = new Label();
        TextBox tboxSuprafata = new TextBox();
        Label lbCompartimente = new Label();
        TextBox tboxCompartimente = new TextBox();
        Label lbAnCasa = new Label();
        TextBox tboxAnCasa = new TextBox();
        Label lbTipVanzator = new Label();
        TextBox tboxTipVanzator = new TextBox();
        Label lbParcare = new Label();
        CheckBox checkboxParcare = new CheckBox();
        Label lbSupCurte = new Label();
        TextBox tboxSupCurte = new TextBox();
        static void InsertKeyWords(int id_anunt, string titlu, int pret)
        {
            var context = new OLXDataContext();
            string sep = " ,;:!?";
            foreach (string cuvant in titlu.Split(sep.ToCharArray()))
            {
                context.spInsertAsociatedWord(id_anunt, cuvant);
            }
            context.spInsertAsociatedWord(id_anunt, pret.ToString());
        }


        public AddAnunt()
        {
            InitializeComponent();

            var context = new OLXDataContext();
            var result = from c in context.DB_SEARCH_CATEGORies
                         select c.NUME_CATEGORIE;

            foreach (var item in result)
            {
                comboBoxCategorie.Items.AddRange(new object[] { item.ToString() });
            }
        }
        
        private void btnAdaugaAnunt_Click(object sender, EventArgs e)
        {
            string titlu = tboxTitlu.Text;
            string stare = tboxStare.Text;
            string categ = comboBoxCategorie.Text;
            string subcateg = comboBoxSubcategorie.Text;
            int pret = Convert.ToInt32(tboxPret.Text.ToString());
            bool negociabil;
            if (cboxNegociabil.Checked)
                negociabil = true;
            else negociabil = false;
            string descriere = tboxDescriere.Text;
            string locIntalnire = richTextBoxLocIntalnire.Text;


            var context = new OLXDataContext();
            context.spADDprod(Program.OLXusername, titlu, stare, categ, subcateg, pret, negociabil, descriere, locIntalnire, ConvertFiletoByte(this.pictureBox1.ImageLocation));
            context.SubmitChanges();

            if (categ == "Auto, Moto, Ambarcatiuni") // autoturisme
            {
                autoMarca = cboxMarca.Text;
                autoModel = tboxModel.Text;
                autoCuloare = tboxCuloareAuto.Text;
                autoCutieViteze = tboxCutieViteze.Text;
                autoAn = tboxAnAuto.Text;
                autoNrKM = tboxRulaj.Text;
                autoCaroserie = tboxCaroserie.Text;
                autoCombustibil = tboxFuel.Text;
                autoCapacitateMotor = tboxMotor.Text;

                context.spADDprod_details_auto(Program.OLXusername, titlu, autoMarca, autoModel, autoCuloare, autoCutieViteze, autoAn, autoNrKM, autoCaroserie, autoCombustibil, autoCapacitateMotor);
                context.SubmitChanges();
            }
            if (categ == "Locuri de munca")
            {
                muncaTip = tboxTipMunca.Text;
                muncaTipMob = tboxTipMobilitate.Text;
                muncaSalariu = Convert.ToInt32(tboxSalariu.Text.ToString());

                context.spADDprod_details_work(Program.OLXusername, titlu, muncaTip, muncaTipMob, muncaSalariu);
                context.SubmitChanges();
            }
            if (categ== "Moda & frumusete")
            {
                fashionTipArticol = tboxTipArticolVestimentar.Text;
                fashionMarimea = tboxCutieViteze.Text;
                fashionCuloare = tboxCuloareModa.Text;
                fashionMarca = tboxMarcaModa.Text;

                context.spADDprod_details_fashion(Program.OLXusername, titlu, fashionTipArticol, fashionMarimea, fashionCuloare, fashionMarca);
                context.SubmitChanges();
            }
            if (categ == "Imobiliare")
            {
                casaCamere = tboxNrCamere.Text;
                casaSuprafata = tboxSuprafata.Text;
                casaCompartimentare = tboxCompartimente.Text;
                casaAn = tboxAnCasa.Text;
                casaTipVanzator = tboxTipVanzator.Text;
                if (checkboxParcare.Checked)
                {
                    casaParcare = true;
                }
                else casaParcare = false;
                casaSuprafataCurte = tboxSupCurte.Text;

                context.spADDprod_details_house(Program.OLXusername, titlu, casaCamere, casaSuprafata, casaCompartimentare, casaAn ,casaTipVanzator, casaParcare, casaSuprafata);
                context.SubmitChanges();
            }

            InsertKeyWords(Convert.ToInt32(context.spGetIDAnunt(Program.OLXusername, titlu).ToString()), titlu, pret);
            MessageBox.Show("Anunt adaugat cu succes!");
            this.Close();
            
        }

        private void comboBoxCategorie_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxSubcategorie.Items.Clear();
            
            string categ = comboBoxCategorie.Text;

            var context = new OLXDataContext();
            var id_categ = from o in context.DB_SEARCH_CATEGORies
                           where o.NUME_CATEGORIE.ToString() == categ
                           select o.ID;

            var result = from o in context.DB_SEARCH_SUBCATEGORies
                         join j in context.DB_SEARCH_CATEGORies
                         on o.ID_CATEGORIE equals j.ID
                         where j.NUME_CATEGORIE == categ.ToString()
                         select o.NUME_SUBCATEGORIE;

            foreach (var item in result)
            {
                comboBoxSubcategorie.Items.AddRange(new object[] { item.ToString() });
            }

            int topLabel = 117;
            int leftLabel = 0;
            int topCbox = 117;
            int leftCbox = 100;

            string categorie = comboBoxCategorie.Text.ToString();


            if (categorie == "Auto, Moto, Ambarcatiuni") // autoturisme
            {
                panel2.Controls.Clear();
                panel2.Refresh();
                lbIDMarca.Text = "Marca";
                lbIDMarca.Top = topLabel;
                lbIDMarca.Left = leftLabel;
                panel2.Controls.Add(lbIDMarca);
                
                cboxMarca.Top = topCbox;
                cboxMarca.Left = leftCbox;
                panel2.Controls.Add(cboxMarca);
                var rez = from p in context.AUTO_BRANDs
                          select p.NUME_MARCA;
                foreach (var item1 in rez)
                {
                    cboxMarca.Items.AddRange(new object[] { item1.ToString() });
                }
                string marca = cboxMarca.Text;
                ///////////////////////////////
                
                lbModel.Top = topLabel + 25;
                lbModel.Left = leftLabel;
                lbModel.Text = "Model";
                tboxModel.Top = topLabel + 25;
                tboxModel.Left = leftCbox;
                panel2.Controls.Add(tboxModel);
                panel2.Controls.Add(lbModel);
                //////////////////////////////////
                
                lbCuloareAuto.Top = topLabel + 50;
                lbCuloareAuto.Left = leftLabel;
                lbCuloareAuto.Text = "Culoare";
                tboxCuloareAuto.Top = topLabel + 50;
                tboxCuloareAuto.Left = leftCbox;
                panel2.Controls.Add(tboxCuloareAuto);
                panel2.Controls.Add(lbCuloareAuto);
                //////////////////////////////////////////
                
                lbCutieViteze.Top = topLabel + 75;
                lbCutieViteze.Left = leftLabel;
                lbCutieViteze.Text = "Cutie de viteze";
                tboxCutieViteze.Top = topLabel + 75;
                tboxCutieViteze.Left = leftCbox;
                panel2.Controls.Add(tboxCutieViteze);
                panel2.Controls.Add(lbCutieViteze);
                ///////////////////////////////////////////
                
                lbAnAuto.Top = topLabel + 100;
                lbAnAuto.Left = leftLabel;
                lbAnAuto.Text = "An";
                tboxAnAuto.Top = topLabel + 100;
                tboxAnAuto.Left = leftCbox;
                panel2.Controls.Add(tboxAnAuto);
                panel2.Controls.Add(lbAnAuto);
                ///////////////////////////////////////
                
                lbRulaj.Top = topLabel + 125;
                lbRulaj.Left = leftLabel;
                lbRulaj.Text = "Rulaj km";
                tboxRulaj.Top = topLabel + 125;
                tboxRulaj.Left = leftCbox;
                panel2.Controls.Add(tboxRulaj);
                panel2.Controls.Add(lbRulaj);
                ///////////////////////////////////////
                
                lbCaroserie.Top = topLabel + 150;
                lbCaroserie.Left = leftLabel;
                lbCaroserie.Text = "Caroserie";
                tboxCaroserie.Top = topLabel + 150;
                tboxCaroserie.Left = leftCbox;
                panel2.Controls.Add(tboxCaroserie);
                panel2.Controls.Add(lbCaroserie);
                ///////////////////////////////////////
                
                lbFuel.Top = topLabel + 175;
                lbFuel.Left = leftLabel;
                lbFuel.Text = "Combustibil";
                tboxFuel.Top = topLabel + 175;
                tboxFuel.Left = leftCbox;
                panel2.Controls.Add(tboxFuel);
                panel2.Controls.Add(lbFuel);
                ///////////////////////////////////////
                
                lbMotor.Top = topLabel + 200;
                lbMotor.Left = leftLabel;
                lbMotor.Text = "Capacitate motor";
                tboxMotor.Top = topLabel + 200;
                tboxMotor.Left = leftCbox;
                panel2.Controls.Add(tboxMotor);
                panel2.Controls.Add(lbMotor);
                ///////////////////////////////////////
            }
            else if (categorie == "Locuri de munca")
            {
                panel2.Controls.Clear();
                panel2.Refresh();
                //////////////////////////////////////////
                
                lbTipMunca.Top = topLabel;
                lbTipMunca.Left = leftLabel;
                lbTipMunca.Text = "Tip munca";
                tboxTipMunca.Top = topLabel;
                tboxTipMunca.Left = leftCbox;
                panel2.Controls.Add(tboxTipMunca);
                panel2.Controls.Add(lbTipMunca);
                //////////////////////////////////////////
                
                lbTipMobilitate.Top = topLabel + 25;
                lbTipMobilitate.Left = leftLabel;
                lbTipMobilitate.Text = "Tip mobilitate";
                tboxTipMobilitate.Top = topLabel + 25;
                tboxTipMobilitate.Left = leftCbox;
                panel2.Controls.Add(tboxTipMobilitate);
                panel2.Controls.Add(lbTipMobilitate);
                //////////////////////////////////////////
                
                lbSalariu.Top = topLabel + 50;
                lbSalariu.Left = leftLabel;
                lbSalariu.Text = "Salariu";
                tboxSalariu.Top = topLabel + 50;
                tboxSalariu.Left = leftCbox;
                panel2.Controls.Add(tboxSalariu);
                panel2.Controls.Add(lbSalariu);

            }
            else if (categorie == "Moda & frumusete")
            {
                panel2.Controls.Clear();
                panel2.Refresh();
                //////////////////////////////////////////
                lbTipArticolVestimentar.Top = topLabel;
                lbTipArticolVestimentar.Left = leftLabel;
                lbTipArticolVestimentar.Text = "Tip Articol Vestimentar";
                tboxTipArticolVestimentar.Top = topLabel;
                tboxTipArticolVestimentar.Left = leftCbox;
                panel2.Controls.Add(tboxTipArticolVestimentar);
                panel2.Controls.Add(lbTipArticolVestimentar);
                //////////////////////////////////////////
                
                lbMarime.Top = topLabel + 25;
                lbMarime.Left = leftLabel;
                lbMarime.Text = "Marime";
                tboxMarime.Top = topLabel + 25;
                tboxMarime.Left = leftCbox;
                panel2.Controls.Add(tboxMarime);
                panel2.Controls.Add(lbMarime);
                //////////////////////////////////////////
                lbCuloareModa.Top = topLabel + 50;
                lbCuloareModa.Left = leftLabel;
                lbCuloareModa.Text = "Culoare";
                tboxCuloareModa.Top = topLabel + 50;
                tboxCuloareModa.Left = leftCbox;
                panel2.Controls.Add(tboxCuloareModa);
                panel2.Controls.Add(lbCuloareModa);
                //////////////////////////////////////////
                
                lbMarcaModa.Top = topLabel + 50;
                lbMarcaModa.Left = leftLabel;
                lbMarcaModa.Text = "Marca";
                tboxMarcaModa.Top = topLabel + 50;
                tboxMarcaModa.Left = leftCbox;
                panel2.Controls.Add(tboxMarcaModa);
                panel2.Controls.Add(lbMarcaModa);
                
            }
            else if (categorie == "Imobiliare")
            {
                panel2.Controls.Clear();
                lbNrCamere.Top = topLabel + 25;
                lbNrCamere.Left = leftLabel;
                lbNrCamere.Text = "Nr. camere";
                tboxNrCamere.Top = topLabel + 25;
                tboxNrCamere.Left = leftCbox;
                panel2.Controls.Add(tboxNrCamere);
                panel2.Controls.Add(lbNrCamere);
                //////////////////////////////////////////////////////////

                lbSuprafata.Top = topLabel + 50;
                lbSuprafata.Left = leftLabel;
                lbSuprafata.Text = "Suprafata";
                tboxSuprafata.Top = topLabel + 50;
                tboxSuprafata.Left = leftCbox;
                panel2.Controls.Add(tboxSuprafata);
                panel2.Controls.Add(lbSuprafata);
                //////////////////////////////////////////

                lbCompartimente.Top = topLabel + 75;
                lbCompartimente.Left = leftLabel;
                lbCompartimente.Text = "Compartimentare";
                tboxCompartimente.Top = topLabel + 75;
                tboxCompartimente.Left = leftCbox;
                panel2.Controls.Add(tboxCompartimente);
                panel2.Controls.Add(lbCompartimente);
                ///////////////////////////////////////////

                lbAnCasa.Top = topLabel + 100;
                lbAnCasa.Left = leftLabel;
                lbAnCasa.Text = "An";
                tboxAnCasa.Top = topLabel + 100;
                tboxAnCasa.Left = leftCbox;
                panel2.Controls.Add(tboxAnCasa);
                panel2.Controls.Add(lbAnCasa);
                ///////////////////////////////////////

                lbTipVanzator.Top = topLabel + 125;
                lbTipVanzator.Left = leftLabel;
                lbTipVanzator.Text = "Tip Vanzator";
                tboxTipVanzator.Top = topLabel + 125;
                tboxTipVanzator.Left = leftCbox;
                panel2.Controls.Add(tboxTipVanzator);
                panel2.Controls.Add(lbTipVanzator);
                ///////////////////////////////////////

                lbParcare.Top = topLabel + 150;
                lbParcare.Left = leftLabel;
                lbParcare.Text = "Parcare";
                checkboxParcare.Top = topLabel + 150;
                checkboxParcare.Left = leftCbox;
                panel2.Controls.Add(checkboxParcare);
                panel2.Controls.Add(lbParcare);
                ///////////////////////////////////////

                lbSupCurte.Top = topLabel + 200;
                lbSupCurte.Left = leftLabel;
                lbSupCurte.Text = "Suprafata Curte";
                tboxSupCurte.Top = topLabel + 200;
                tboxSupCurte.Left = leftCbox;
                panel2.Controls.Add(tboxSupCurte);
                panel2.Controls.Add(lbSupCurte);
                
            }
            else
            {
                panel2.Controls.Clear();
                panel2.Refresh();
            }
        }


        private byte[] ConvertFiletoByte(string sPath)
        {
            byte[] data = null;
            FileInfo finfo = new FileInfo(sPath);
            long numBytes = finfo.Length;
            FileStream fstream = new FileStream(sPath, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fstream);
            data = br.ReadBytes((int)numBytes);
            return data;
        }

        private void btnCautaFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Selecteaza imagine";
            ofd.Filter = "JPG|*.jpg| PNG | *.png | All files | *.*";
            ofd.Multiselect = false;
            // ofd.ShowDialog();
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.pictureBox1.ImageLocation = ofd.FileName;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Selecteaza imagine";
            ofd.Filter = "JPG|*.jpg| PNG | *.png | All files | *.*";
            ofd.Multiselect = false;
            // ofd.ShowDialog();
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.pictureBox1.ImageLocation = ofd.FileName;
            }
        }

        /*private void AddAnunt_Load(object sender, EventArgs e)
        {

        }*/
    }
}
