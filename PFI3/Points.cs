using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFI3
{
    public class Points
    {
        public const int NB_MAXIMUM_POINTS = 10000;
        private int _x;
        private int _y;

        private int _a;
        private int _b;
        private int _max;

        private Random _r = null;
        public Points(int A1, int B1, int Max1)
        {
            _a = A1;
            _b = B1;
            _max = Max1;
            Generate();
        }
        // Génère aléatoirement un point entre A et B (x) et A et Max (y)
        private void Generate()
        {
           _r = new Random();
           _x = _r.Next(_a, _b + 1);
           _y = _r.Next(0, _max + 1);
        }

        // Retourne le Point X
        public int GetX() { return _x; }

        // Retourne le point Y
        public int GetY() { return _y; }

        // Retourne un tableau avec les coordonnées du point ([0] = X, [1] = Y)
        public int[] GetPoint() { return new int[] { _x, _y }; }
    }
}
