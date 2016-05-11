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
        public int _optionChoisis;
        public int _a;
        public int _b;
        public int _yMax;
        public int _aireRectangle;
        public double _réponseOpt;

        public PFI3()
        {
            InitializeComponent();
        }
        public PFI3(int option)
        {
            InitializeComponent();
            _optionChoisis = option;
            _réponseOpt = 0;
        }
        private void PFI3_Load(object sender, EventArgs e)
        {
            Points p = new Points(2, 10, 11);            
            //label1.Text = p.GetX().ToString() + " " + p.GetY().ToString();
        }

        #region Calculer aire rectangle
        private void BTN_CalculerAire_Click(object sender, EventArgs e)
        {
            _a = Int32.Parse(NUD_a.Text);
            _b = Int32.Parse(NUD_b.Text);
            _yMax = Int32.Parse(NUD_yMax.Text);
            Calculer_AireRectangle();
        }
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
        //TO VÉRIFIER
        #region Calcule pour les options 1 à 5
        public void CalculeOpt1(double x)
        {
            double xExpo2;
            xExpo2 = Math.Pow(x, 2);
            _réponseOpt = Math.Pow((xExpo2 - 16 * x + 63 + 4), 1 / 3);
        }
        public void CalculeOpt2(double x)
        {
            _réponseOpt = 3 * Math.Pow((x - 7 / 5), 5) - 5 * Math.Pow((x - 7 / 5), 3) + 3;
        }
        public void CalculeOpt3(double x)
        {
            _réponseOpt = -(1 / 3) * Math.Pow((x - 6), 2) + 12;
        }
        public void CalculeOpt4(double x)
        {
            _réponseOpt = x + Math.Sin(x);
        }
        public void CalculeOpt5(double x)
        {
            _réponseOpt = Math.Cos(x) + 3;
        }
        #endregion
    }
}
