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

        private double Proportion;
        private double ME;
        private String IC;

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
            Calculer();
        }

        private void NUD_a_ValueChanged(object sender, EventArgs e)
        {
            Calculer();
        }
        private void NUD_b_ValueChanged(object sender, EventArgs e)
        {
            NUD_a.Maximum = NUD_b.Value;
            Calculer();
        }
        // Update les Labels proportions, Marge d'erreur et Interval de Confiance
        private void Calculer()
        {
            LAB_p.Text = Estimer();
            LAB_Me.Text = CalculerME();
            LAB_IC.Text = CalculeIC();
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
            if (p[1] <= (Math.Pow((Math.Pow(p[0], 2d) - 16d * p[0] + 63d), (1d / 3d)) * -1d) + 4d)
                return true;
            return false;
        }
        public bool CalculeOpt2(int[] p)
        {
            if (p[1] <= 3d * Math.Pow(((p[0] - 7d) / 5d), 5d) - 5d * Math.Pow(((p[0] - 7d) / 5d), 3d) + 3d)
                return true;
            return false;
        }
        public bool CalculeOpt3(int[] p)
        {
            double Line = -1d * (1d / 3d) * Math.Pow((p[0] - 6d), 2d) + 12d;
            if (p[1] <= Line)
                return true;
            return false;
        }
        public bool CalculeOpt4(int[] p)
        {
            if (p[1] <= p[0] + Math.Sin(p[0]))
                return true;
            return false;
        }
        public bool CalculeOpt5(int[] p)
        {
            if (p[1] <= Math.Cos(p[0]) + 3d)
                return true;
            return false;
        }
        #endregion

        #region EstimerProportion
        // Retourne l'aire sous la courbre selon les paramètres (en format string(pour le mettre directement dans le Label)).
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
                        if (CalculeOpt2(listePoints[i].GetPoint()))
                            ++Interieur;
                        break;
                    case 3:
                        if (CalculeOpt3(listePoints[i].GetPoint()))
                            ++Interieur;
                        break;               
                    case 4:
                        if (CalculeOpt4(listePoints[i].GetPoint()))
                            ++Interieur;
                        break;
                    case 5:
                        if (CalculeOpt5(listePoints[i].GetPoint()))
                            ++Interieur;
                        break;
                    default:
                        MessageBox.Show("Erreur dans le code; Choix fonction");
                        break;
                }
            }
            Proportion = Interieur / Points.NB_MAXIMUM_POINTS * 100d;
            return Proportion.ToString() + " %";
        }
        #endregion

        #region Calculer la marge d'erreur
        public String CalculerME()
        {
            // TODO
            // Le z du tableau de loi normale
            double z = 0d;
            // Le pourcentage de l'aire totale sous la courbe
            double p = 0d;
            ME = z * Math.Pow((p * (1d - p) / Convert.ToDouble(Points.NB_MAXIMUM_POINTS)), 0.5d);
            return ME.ToString();
        }
        #endregion

        #region Calcule Interval de Confiance
        // Calcule l'interval de confiance selon la proportion estimée et la marge d'erreur
        public String CalculeIC()
        {
            double proportion = Convert.ToDouble(Proportion);
            double Marge = Convert.ToDouble(ME);
            IC = "[" + (proportion - Marge).ToString() + ";" + (proportion + Marge).ToString() + "]";
            return IC; 
        }
        #endregion
    }
}
