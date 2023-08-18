using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2
{
    public class HoldPoint
    {
        // Indholder scoret
        public int score { get; set; }

        // En konstructor for scores
        public HoldPoint(int score)
        {
            this.score = score;
        }
        // Overloadet "+" operator for at kombinere HoldPoint objecter
        public static HoldPoint operator +(HoldPoint a, HoldPoint b)
        {
            // Vender tilbage med et new HoldPoint object med sumen af scorerne
            return new HoldPoint(a.score + b.score);
        }
    }
    public class HoldNavne
    {
        // Indholder navne
        public string navn { get; set; }

        // En konstructor for scores
        public HoldNavne(string navn)
     {
        this.navn = navn;
     }
        // Overloadet "+" operator for at kombinere HoldNavne objecter
        public static HoldNavne operator +(HoldNavne a, HoldNavne b)
        {
            // Vender tilbage med et new HoldNavn object med sumen af navnene
          return new HoldNavne(a.navn + " & " + b.navn + " fik: ");
        }
     }
}

