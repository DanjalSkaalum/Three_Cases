using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Fodbold
    {
        public static string Fansupport(int antalafleverning, string mål)
        {
            // Tjekker om der er mål
            if ((mål == "mål") || (mål == "MÅL") || (mål == "Mål") || (mål == "mÅl") || (mål == "måL"))
            {
                // Vender tilbage med en festlig besked for målet
                    return "Olé olé olé";
            }

            else
            {
                // Tjekker om antallet af afleverninger er 10 eller mere
                if (antalafleverning >= 10)
                {
                    // Vender tilbage med et festligt high-five
                    return "High Five – Jubel!!!";
                }

                // Tjekker om antallet af afleverninger er mellem 1 og 9
                else if (antalafleverning > 0 && antalafleverning < 10)
                {
                    // Udskriver "Huh!" i et loop for hver afleverning
                    for (int i = 1; i <= antalafleverning; i++)
                    {
                        Console.Write("Huh! ");
                    }
                }

                else
                {
                    // Vender tilbage med et stille svar begrundet af ingen afleverninger
                    return "Shh";
                }
            }
            // Vender tilbage med en tom string for ordens skyld
            return " ";
        }
    }
}
