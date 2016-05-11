using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PFI3
{
    public partial class PFI3 : Form
    {
        public int _a;
        public int _b;
        public int _yMax;
        public int _aireRectangle;

        public PFI3()
        {
            InitializeComponent();
        }


        private void BTN_CalculerAire_Click(object sender, EventArgs e)
        {
            _a = Int32.Parse(NUD_a.Text);
            _b = Int32.Parse(NUD_b.Text);
            _yMax = Int32.Parse(NUD_yMax.Text);
            Calculer_AireRectangle();
        }
        #region Calculer aire rectangle
        // Calculer l'aire du rectangle
        public void Calculer_AireRectangle()
        {
            int réponse = 0;
            réponse = _b - _a;
            _aireRectangle = réponse * _yMax;
            Afficher_AireRectangle();
        }
        // Afficher l'aire du rectangle
        public void Afficher_AireRectangle()
        {
            LBL_AireRectangle.Text = _aireRectangle.ToString();
        }
        #endregion

        private void PFI3_Load(object sender, EventArgs e)
        {
            Points p = new Points(2, 10, 11);
            //label1.Text = p.GetX().ToString() + " " + p.GetY().ToString();
        }
    }
}
