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

        public List<Points> listePoints;

        public PFI3()
        {
            InitializeComponent();
        }
        public PFI3(int option)
        {
            InitializeComponent();
            _optionChoisis = option;
            _réponseOpt = 0;
            // Initialise la valeur de LAB_YMax
            switch (option)
            {
                case 1:
                    LAB_YMax.Text = "5";
                    break;
                case 2:
                    LAB_YMax.Text = "5";
                    break;
                case 3:
                    LAB_YMax.Text = "12";
                    break;
                case 4:
                    LAB_YMax.Text = "10";
                    break;
                case 5:
                    LAB_YMax.Text = "4";
                    break;
                default:
                    MessageBox.Show("Erreur dans le code; Choix fonction");
                    break;
            }
        }
        private void PFI3_Load(object sender, EventArgs e)
        {
            LAB_Pi.Text = Estimer();
        }

        #region Calculer aire rectangle
        private void BTN_CalculerAire_Click(object sender, EventArgs e)
        {
            _a = Int32.Parse(NUD_a.Text);
            _b = Int32.Parse(NUD_b.Text);
            _yMax = Int32.Parse(LAB_YMax.Text);
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
        //TODO VÉRIFIER
        #region Calcule pour les options 1 à 5
        // retourne si le point en paramètre en à l'extérieur ou à l'intérieur de la fonction 1
        public bool CalculeOpt1(int[] p)
        {
            // Pow(x,y) est l'équivalent d'un exposant, x étant le nombre à calculer, y étant l'exposant
            // Ici nous faisons l'équivalent d'une ³√ en faisant x^1/3
            if (p[1] <= (Math.Pow((Math.Pow(p[0], 2) - 16 * p[0] + 63), (1 / 3)) * -1) + 4)
                return true;
            return false;
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

        #region EstimerProportion
        // Retourne l'aire sous la courbre selon les paramètres (en format string).
        public String Estimer()
        {
            listePoints = new List<Points>();
            // Store le nombre de points à l'intérieur de la fonction
            double Interieur = 0;

            // Générer les 10 000 points
            for (int i = 0; i < Points.NB_MAXIMUM_POINTS; ++i)
            {
                listePoints.Add(new Points(Convert.ToInt32(NUD_a.Value), Convert.ToInt32(NUD_b.Value), Convert.ToInt32(LAB_YMax.Text)));
            }
            // Vérifie l'emplacement des 10 000 points selon l'option choisi
            for (int i = 0; i < Points.NB_MAXIMUM_POINTS; ++i)
            {
                switch (_optionChoisis)
                {
                    case 1:
                        if (CalculeOpt1(listePoints[i].GetPoint()))
                            ++Interieur;
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    default:
                        MessageBox.Show("Erreur dans le code; Choix fonction");
                        break;
                }
            }
            return (Interieur / Points.NB_MAXIMUM_POINTS * 100).ToString() + " %";
        }
        #endregion

        private void NUD_a_ValueChanged(object sender, EventArgs e)
        {
            LAB_Pi.Text = Estimer();
        }

        private void NUD_b_ValueChanged(object sender, EventArgs e)
        {
            NUD_a.Maximum = NUD_b.Value;
            LAB_Pi.Text = Estimer();
        }
    }
}
