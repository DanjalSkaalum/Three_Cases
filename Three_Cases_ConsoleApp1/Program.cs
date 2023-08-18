using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;
using ClassLibrary2;
using ClassLibrary3;
using ClassLibrary4;

namespace Three_Cases_ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Stier for login filerne
            string path = "C:/Users/DanSka/source/repos/Three_Cases/Check.txt";
            string passpath = "C:/Users/DanSka/source/repos/Three_Cases/Pass.txt";

            // Variabler
            string tast, mål, navn = "";
            int antalaflevering = 0, score = 0;

            // Tjekker filerne og laver dem hvis de ikke exister
            if (!File.Exists(path))
            {
                File.Create(path);
            }

            if (!File.Exists(passpath))
            {
                File.Create(passpath);
            }

            // Spørg om debug mode prÆference
            Logger.WriteLine("Debug mode spørgelse!");
            Logger.WriteLine("Venligst svar med 'Ja' hvis du vil aktiver debug mode, i stedet for console mode:");
            string debug = Console.ReadLine().ToLower();

            // Aktiverer debug mode hvis øndsket
            if (debug == "ja")
            {
                ClassLibrary4.Logger.CurrentMode = LoggingMode.Debug;
                Logger.WriteLine("Debug mode er nu aktiveret!");
            }

            // Starter password modulen
            Password.Start(path, passpath);

            do
            {
                // Viser menu valg muligheder
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Logger.WriteLine("Velkommen til The Three Cases programmet");
                Logger.WriteLine("");

                Console.BackgroundColor = ConsoleColor.Blue;
                Logger.Write("   ");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Logger.WriteLine("1. Fodbold - Fan Support case:");

                Console.BackgroundColor = ConsoleColor.Red;
                Logger.Write("   ");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Logger.WriteLine("2. Dansekonkurrence case:");

                Console.BackgroundColor = ConsoleColor.Gray;
                Logger.Write("   ");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Logger.WriteLine("X. Afslut programmet");

                // Modtager brugerens valg
                tast = Console.ReadLine();

                Console.Clear();

                // Handter brugerens valg med en switch
                switch (tast)
                {
                    case "1":
                        // Fodbold - Fan Support casen
                        Logger.WriteLine("Du har valgt Fodbold - Fan Support casen.");
                        Logger.WriteLine("Venligst skriv hvor mange aflevering dit hold har lavet.");
                        antalaflevering = Convert.ToInt32(Console.ReadLine());

                        // Spørgelse om mål
                        Logger.WriteLine("Venligst svar om dit hold har lavet mål denne gang. Svar med 'mål' hvis ja.");
                        mål = Console.ReadLine();

                        // Kalder til Foldbold.Fansupport metoden og viser resulatet
                        string Foldbold = ClassLibrary1.Fodbold.Fansupport(antalaflevering, mål);
                        Logger.WriteLine(Foldbold);
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "2":
                        // Dansekonkurrence casen og spørgelse om den første partners navn
                        Logger.WriteLine("Du har valgt Dansekonkurrence casen.");
                        Logger.WriteLine("Venligst skriv den første partner's navn.");
                        navn = Console.ReadLine();
                        HoldNavne deltager1navn = new HoldNavne(navn);

                        // Spørgelse om den første partners score
                        Logger.WriteLine("Venligst skriv den første partner's antal points(1 eller 2 eller 3, osv).");
                        score = Convert.ToInt32(Console.ReadLine());
                        HoldPoint deltager1score = new HoldPoint(score);

                        // Spørgelse om den anden partners navn
                        Logger.WriteLine("Venligst skriv den anden partner's navn.");
                        navn = Console.ReadLine();
                        HoldNavne deltager2navn = new HoldNavne(navn);

                        // Spørgelse om den anden partners score
                        Logger.WriteLine("Venligst skriv den anden partner's antal points(1 eller 2 eller 3, osv).");
                        score = Convert.ToInt32(Console.ReadLine());
                        HoldPoint deltager2score = new HoldPoint(score);

                        // Kombinere partnernes navne og scores
                        HoldNavne samletnavn = deltager1navn + deltager2navn;
                        HoldPoint samletscore = deltager1score + deltager2score;
                        // Viser kombinerede info
                        Logger.Write(samletnavn.navn);
                        Logger.Write(samletscore.score);
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "x":
                        // Forlader programmet
                        Logger.WriteLine("Du har afsluttet programmet.");
                        Console.ReadKey();
                        break;

                    default:
                        // Handter forkerte indskrivelser
                        if (tast != "1" || tast != "2" || tast != "x")
                        {
                            Logger.WriteLine("Fejl! - Du har trykket noget forkert. Venligst prøv igen.");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                }
            } while (tast != "x");

            // Slutning af programmet
            Logger.WriteLine("Hav en god dag!");
            Console.ReadKey();
        }
    }
}
