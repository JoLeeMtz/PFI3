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
        public double CalculeOpt1(int x)
        {
            // Pow(x,y) est l'équivalent d'un exposant, x étant le nombre à calculer, y étant l'exposant
            // Ici nous faisons l'équivalent d'une ³√ en faisant x^1/3
            return (Math.Pow((Math.Pow(x, 2d) - 16d * x + 63d), (1d / 3d)) * -1d) + 4d;
        }
        public double CalculeOpt2(int x)
        {
            return 3d * Math.Pow(((x - 7d) / 5d), 5d) - 5d * Math.Pow(((x - 7d) / 5d), 3d) + 3d;
        }
        public double CalculeOpt3(int x)
        {
            return -1d * (1d / 3d) * Math.Pow((x - 6d), 2d) + 12d;
        }
        public double CalculeOpt4(int x)
        {
            return x + Math.Sin(x);
        }
        public double CalculeOpt5(int x)
        {
            return Math.Cos(x) + 3d;
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
                        if (listePoints[i].GetY() <= CalculeOpt1(listePoints[i].GetX()))
                            ++Interieur;
                        break;
                    case 2:
                        if (listePoints[i].GetY() <= CalculeOpt2(listePoints[i].GetX()))
                            ++Interieur;
                        break;
                    case 3:
                        if (listePoints[i].GetY() <= CalculeOpt3(listePoints[i].GetX()))
                            ++Interieur;
                        break;
                    case 4:
                        if (listePoints[i].GetY() <= CalculeOpt4(listePoints[i].GetX()))
                            ++Interieur;
                        break;
                    case 5:
                        if (listePoints[i].GetY() <= CalculeOpt5(listePoints[i].GetX()))
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
            // Calculer la moyenne
            double Moyenne = CalculeMoyenne();
            // Calculer l'écart type
            // TODO, DAFUQ is F ? (s = √ (Σ(x - moyenne)² * f)/n)
            //Calculer Z
            // Le z du tableau de loi normale
            double z = 0d;
            // Le pourcentage de l'aire totale sous la courbe
            double p = Proportion / 100d;
            ME = z * Math.Pow((p * (1d - p) / Convert.ToDouble(Points.NB_MAXIMUM_POINTS)), 0.5d);
            return ME.ToString();
        }
        // Calculer la moyenne dans l'intervalle selectionné
        public double CalculeMoyenne()
        {
            int Cases = Convert.ToInt32(NUD_b.Value - NUD_a.Value);
            double[] t = new double[Cases];
            int pos = 0;
            for (int i = Convert.ToInt32(NUD_a.Value); i <= Convert.ToInt32(NUD_b.Value); ++i)
            {
                switch (_optionChoisis)
                {
                    case 1:
                        t[pos] = CalculeOpt1(i);
                        break;
                    case 2:
                        t[pos] = CalculeOpt2(i);
                        break;
                    case 3:
                        t[pos] = CalculeOpt3(i);
                        break;
                    case 4:
                        t[pos] = CalculeOpt4(i);
                        break;
                    case 5:
                        t[pos] = CalculeOpt5(i);
                        break;
                }
                ++pos;
            }
            pos = 0;
            double Moyenne = 0d;
            for (int i = 0; i < Cases; ++i)
            {
                Moyenne += t[i];
            }
            Moyenne = Moyenne / Cases;
            return Moyenne;
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
