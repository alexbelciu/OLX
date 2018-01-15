using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OLX
{
    static class Program
    {
        public static string getRandomUserID(int length)
        {
            Random random = new Random();
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static string OLXusername = getRandomUserID(16);

        public static string makeHash(string parola)
        {
            string HASH = "";
            string rez;
            for (int j = 0; j < parola.Length; j++)
            {
                HASH += parola[parola.Length - 1 - j].ToString();
            }
            if (HASH.GetHashCode() < 0)
            {
                rez = parola.GetHashCode().ToString() + (HASH.GetHashCode()+ 2*HASH.GetHashCode()).ToString();
            }
            else rez = parola.GetHashCode().ToString()+HASH.GetHashCode().ToString();

            return rez;
        }

        [STAThread]
        static void Main()
        {
            
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        System.Threading.Thread.CurrentThread.SetApartmentState(System.Threading.ApartmentState.STA);
        Application.Run(new MainPage());
        //Application.Run(new AnouncePage());
        //Application.Run(new FavoriresPage());
        //Application.Run(new Form4());
        //Application.Run(new RegisterPage());
        //Application.Run(new Logout());
        //Application.Run(new Login());
        //Application.Run(new AddAnunt());

        // Application.Run(new ListaConversatii());
        //Application.Run(new Logout());


        }
    }
}
