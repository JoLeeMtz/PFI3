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
        private void NUD_IC_ValueChanged(object sender, EventArgs e)
        {
            Calculer();
        }

        // Update les Labels proportions, Marge d'erreur et Interval de Confiance
        private void Calculer()
        {
            LAB_p.Text = Estimer();
            LAB_Me.Text = CalculerME();
            LAB_IC.Text = CalculeIC();
            Draw();
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
        public double CalculeOpt1(double x)
        {
            // Pow(x,y) est l'équivalent d'un exposant, x étant le nombre à calculer, y étant l'exposant
            // Ici nous faisons l'équivalent d'une ³√ en faisant x^1/3

            // (Math.Pow((Math.Pow(x,2d) -16d * x + 63d),(1d/3d)) *-1) +4d
            double a1 = Math.Pow(x, 2d);
            double a2 = -16d * x;
            double a3 = a1 + a2;
            double a4 = a3 + 63d;
            //double a5 = Math.Pow(a4, (1d / 3d));
            double a5;
            if (a4 < 0)
                a5 = -Math.Pow(Math.Abs(a4), (1d / 3d));
            else
                a5 = Math.Pow(a4, (1d / 3d));
            double a6 = a5 * -1d;
            double a7 = a6 + 4d;

            return a7;
        }
        public double CalculeOpt2(double x)
        {
            return 3d * Math.Pow(((x - 7d) / 5d), 5d) - 5d * Math.Pow(((x - 7d) / 5d), 3d) + 3d;
        }
        public double CalculeOpt3(double x)
        {
            return -1d * (1d / 3d) * Math.Pow((x - 6d), 2d) + 12d;
        }
        public double CalculeOpt4(double x)
        {
            return x + Math.Sin(x);
        }
        public double CalculeOpt5(double x)
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
        // Calcule la marge d'erreur
        public String CalculerME()
        {
            double Z = LoiNormale.GetZ((Convert.ToInt32(NUD_IC.Value) / 2f) / 100f);
            double p = Proportion / 100;
            double n = Points.NB_MAXIMUM_POINTS;

            double Marge = Z * Math.Sqrt((p * (1 - p)) / n);
            String[] m = Marge.ToString().Split(',');
            // faire en sorte que la Marge est seulement 4 chiffres après la virgule
            if (m.Length > 1)
            {
                m[1] = m[1].Remove(4);
                Marge = Convert.ToDouble(m[0] + "," + m[1]);
            }
            
            
            ME = Marge;
            return Marge.ToString();
        }
        #endregion

        #region Calcule Interval de Confiance
        // Calcule l'interval de confiance selon la proportion estimée et la marge d'erreur
        public String CalculeIC()
        {
            double proportion = Convert.ToDouble(Proportion / 100d);
            float Marge = float.Parse(ME.ToString());

            // Pour avoir seulement 2 chiffres après la virgule
            String[] Minimum = ((proportion - Marge) * 100f).ToString().Split(',');
            if (Minimum.Length > 1)
                Minimum[1] = Minimum[1].Remove(2);
            String[] Maximum = ((proportion + Marge) * 100f).ToString().Split(',');
            if (Maximum.Length > 1)
                Maximum[1] = Maximum[1].Remove(2);

            // Dans le cas que Plus petite valeur Intervalle ou plus Grande == 0
            if (Minimum.Length > 1 && Maximum.Length > 1)
                IC = "[" + Minimum[0] + "," + Minimum[1] + "% ; " + Maximum[0] + "," + Maximum[1] + "%]";
            else if (Minimum.Length > 1 && Maximum.Length == 1)
                IC = "[" + Minimum[0] + "," + Minimum[1] + "% ; " + Maximum[0] + "%]";
            else if (Minimum.Length == 1 && Maximum.Length > 1)
                IC = "[" + Minimum[0] + "% ; " + Maximum[0] + "," + Maximum[1] + "%]";
            else
                IC = "[" + Minimum[0] + "% ; " + Maximum[0] + "%]";


            return IC;
        }
        #endregion

        #region Graph
        private RectangleF rect;
        private int Bottom;
        private int Left;
        private int MarkerDistanceY;
        private int MarkerDistanceX;
        private bool GT5 = false;
        private PointF[] res = new PointF[56];

        private int DISTANCEAXIS = 15;
        private int MARKERLENGTH;
        // dessine le graphique
        private void Draw()
        {
            Panel PB = PB_Graph;
            Graphics DC = PB.CreateGraphics();
            DC.Clear(this.BackColor);
            DrawAxes(DC);
            for (int x = 0; x <= 55; ++x)
            {
                switch (_optionChoisis)
                {
                    case 1:
                        res[x] = new PointF(Left + (x / 5f * MarkerDistanceX), Bottom - ((float)CalculeOpt1(x / 5d) * MarkerDistanceY));
                        break;
                    case 2:
                        res[x] = new PointF(Left + (x / 5f * MarkerDistanceX), Bottom - ((float)CalculeOpt2(x / 5d) * MarkerDistanceY));
                        break;
                    case 3:
                        res[x] = new PointF(Left + (x / 5f * MarkerDistanceX), Bottom - ((float)CalculeOpt3(x / 5d) * MarkerDistanceY));
                        break;
                    case 4:
                        res[x] = new PointF(Left + (x / 5f * MarkerDistanceX), Bottom - ((float)CalculeOpt4(x / 5d) * MarkerDistanceY));
                        break;
                    case 5:
                        res[x] = new PointF(Left + (x / 5f * MarkerDistanceX), Bottom - ((float)CalculeOpt5(x / 5d) * MarkerDistanceY));
                        break;
                }
            }
            DrawFunction(DC, res);
            DrawBox(DC);
        }
        // dessine la fonction selectionnée
        private void DrawFunction(Graphics DC, PointF[] p)
        {
            DC.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            DC.DrawLines(new Pen(Color.Black), p);
        }
        // Dessine la boite selectionné (ou le calcule sera fait)
        private void DrawBox(Graphics DC)
        {
            Pen pen = new Pen(Color.Red);
            int Min = Convert.ToInt32(NUD_a.Value);
            int Max = Convert.ToInt32(NUD_b.Value);

            PointF[] p = new PointF[5];

            if (GT5)
                p[0] = new PointF(Min * MarkerDistanceX + DISTANCEAXIS, _yMax * (MarkerDistanceY / 2));
            else
                p[0] = new PointF(Min * MarkerDistanceX + DISTANCEAXIS, _yMax * (MarkerDistanceY));
            p[1] = new PointF(Min * MarkerDistanceX + DISTANCEAXIS, Bottom);
            p[2] = new PointF(Max * MarkerDistanceX + DISTANCEAXIS, Bottom);
            if (GT5)
                p[3] = new PointF(Max * MarkerDistanceX + DISTANCEAXIS, _yMax * (MarkerDistanceY / 2));
            else
                p[3] = new PointF(Max * MarkerDistanceX + DISTANCEAXIS, _yMax * (MarkerDistanceY));
            p[4] = p[0];

            DC.DrawLines(pen, p);
        }
        // Dessine les axes du graphique
        private void DrawAxes(Graphics DC)
        {
            #region VariablesDeclaration
            Pen pen = new Pen(Color.Black, 1);
            RectangleF rect = DC.VisibleClipBounds;

            this.rect = rect;

            Font f = this.Font;
            bool GT5 = false;
            Brush b = new SolidBrush(Color.Black);

            int Bottom = Convert.ToInt32(rect.Bottom - DISTANCEAXIS);
            int Left = Convert.ToInt32(rect.Left + DISTANCEAXIS);

            this.Bottom = Bottom;
            this.Left = Left;

            int YMax = Convert.ToInt32(LAB_YMax.Text);
            if (YMax > 5)
            {
                GT5 = true;
                this.GT5 = GT5;
                if (YMax % 2 > 0)
                    YMax += 1;
            }
            if (YMax > 10)
                DISTANCEAXIS = 18;

            MARKERLENGTH = DISTANCEAXIS / 5;

            int markerDistance = Convert.ToInt32(Bottom / YMax - 1);
            this.MarkerDistanceY = markerDistance;
            #endregion

            // Draw Main axis
            DC.DrawLine(pen, Left, rect.Y, Left, Bottom);
            DC.DrawLine(pen, Left, Bottom, rect.Right, Bottom);

            //Draw Markers Y Axis
            for (int i = 0; i <= YMax; ++i)
            {
                if (GT5)
                {
                    if (i % 2 == 0)
                    {
                        DC.DrawString(i.ToString(), f, b, new PointF(Left - TextRenderer.MeasureText(i.ToString(), f).Width, Bottom - (i * markerDistance) - DISTANCEAXIS / 2));
                        if (i != 0)
                            DC.DrawLine(pen, Left - MARKERLENGTH, Bottom - (i * markerDistance), Left + MARKERLENGTH, Bottom - (i * markerDistance));
                    }
                }
                else
                {
                    DC.DrawString(i.ToString(), f, b, new PointF(Left - TextRenderer.MeasureText(i.ToString(), f).Width, Bottom - (i * markerDistance) - DISTANCEAXIS / 2));
                    if (i != 0)
                        DC.DrawLine(pen, Left - MARKERLENGTH, Bottom - (i * markerDistance), Left + MARKERLENGTH, Bottom - (i * markerDistance));
                }
            }
            //Draw Markers X Axis
            markerDistance = Convert.ToInt32(rect.Right / 11 - 2);
            this.MarkerDistanceX = markerDistance;
            for (int i = 0; i <= 11; ++i)
            {
                Size StringSize = TextRenderer.MeasureText(i.ToString(), f);
                DC.DrawString(i.ToString(), f, b, new PointF(Left + (i * markerDistance) - StringSize.Width / 2 + 1, Bottom + StringSize.Height / 3));
                if (i != 0)
                    DC.DrawLine(pen, Left + (i * markerDistance), Bottom - MARKERLENGTH, Left + (i * markerDistance), Bottom + MARKERLENGTH);
            }
        }
        #endregion

        private void PB_Graph_Paint(object sender, PaintEventArgs e)
        {
            Draw();
        }
    }
}
