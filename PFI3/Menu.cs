using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PFI3
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        #region Passer informations à la prochaine fenêtre pour savoir le calcule qu'il faut faire
        private void BTN_Opt1_Click(object sender, EventArgs e)
        {
            OpenNewWindow(1);
        }
        private void BTN_Opt2_Click(object sender, EventArgs e)
        {
            OpenNewWindow(2);
        }
        private void BTN_Opt3_Click(object sender, EventArgs e)
        {
            OpenNewWindow(3);
        }
        private void BTN_Opt4_Click(object sender, EventArgs e)
        {
            OpenNewWindow(4);
        }
        private void BTN_Opt5_Click(object sender, EventArgs e)
        {
            OpenNewWindow(5);
        }
        #endregion

        #region Génerer la fenêtre configuration approprié
        // Ouvrir une fenêtre pour configurer les détails de l'option choisis
        private void OpenNewWindow(int option)
        {
            Thread th;
            //this.Close();

            if      (option == 1) th = new Thread(Open_Opt1);
            else if (option == 2) th = new Thread(Open_Opt2);
            else if (option == 3) th = new Thread(Open_Opt3);
            else if (option == 4) th = new Thread(Open_Opt4);
            else                  th = new Thread(Open_Opt5);

            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        // Ouvrir option #1
        private void Open_Opt1(object obj)
        {
            Application.Run(new PFI3(1));
        }
        // Ouvrir option #2
        private void Open_Opt2(object obj)
        {
            Application.Run(new PFI3(2));
        }
        // Ouvrir option #3
        private void Open_Opt3(object obj)
        {
            Application.Run(new PFI3(3));
        }
        // Ouvrir option #4
        private void Open_Opt4(object obj)
        {
            Application.Run(new PFI3(4));
        }
        // Ouvrir option #5
        private void Open_Opt5(object obj)
        {
            Application.Run(new PFI3(5));
        }
        #endregion
    }
}
