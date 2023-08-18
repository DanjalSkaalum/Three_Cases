using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ClassLibrary4;

namespace ClassLibrary3
{
    public class Password
    {
        public static void Start(string path, string passpath)
        {
            // Opsettelse af Login Tjek
            bool godkendt = false;

            do
            {
                Console.Clear();

                // Viser valg for at log in eller at oprette en ny bruger
                Logger.WriteLine("Venligst vælg om du vil logge in eller om du vil oprette en ny bruger.");
                Logger.WriteLine("For at logge in, venligst indtast: L");
                Logger.WriteLine("For at oprette en ny bruger, venligst indtast: O");
                string svar = Console.ReadLine().ToLower();

                Console.Clear();

                if (svar == "l")
                {
                    // Spørgelse om login info
                    int flag = 0;
                    Logger.Write("Venligst indtast brugernavn ");
                    string user = Console.ReadLine();
                    Logger.Write("Venligst indtast password: ");
                    string pass = Console.ReadLine();

                    Console.Clear();

                    // Ser igennem hver linje in password filen
                    foreach (string line in File.ReadLines(path))
                    {
                        // Tjekker om brugernavn og password er korrekte
                        if (line.Contains(user) && line.Contains(pass))
                        {
                            Logger.WriteLine("Adgang godkendt!");
                            Console.ReadKey();
                            Console.Clear();
                            // Login tjek er færdigt
                            flag++;
                            godkendt = true;
                        }
                    }

                    // Tjekker om der bliv korrekt loget in.
                    if (flag == 0)
                    {
                        // Informer brugern at loginet ikke bliv godkendt
                        Logger.WriteLine("Adgang nægtet!");
                        Logger.WriteLine("Brugernavn og/eller password var forkert!");
                        Console.ReadKey();
                    }
                }

                else if (svar == "o")
                {
                    // Spørgelse om nyt brugernavn
                    Logger.WriteLine("Venligst indtast et nyt brugernavn: ");
                    string brugerinput = Console.ReadLine();

                    // Spørgelse om nyt password
                    Logger.WriteLine("Venligst indtast et nyt password: ");
                    string passinput = Console.ReadLine();

                    // Laver tjeks på passwordet
                    bool længde = længdecheck(passinput);
                    bool mellem = mellemrumcheck(passinput);
                    bool bogstav = bogstavcheck(passinput);
                    bool special = special_tal_check(passinput);
                    bool startslut = start_slut_talcheck(passinput);
                    bool samme = bruger_lig_passcheck(passinput, brugerinput);
                    bool Old = old(passinput);

                    // En funktion som tjekker passwordets længde
                    bool længdecheck(string x)
                    {
                        int len = x.Length;
                        if (len >= 12)
                        {
                            return true;
                        }
                        return false;
                    }

                    // En funktion som tjekker om passwordet har både stor og små bogstaver
                    bool bogstavcheck(string x)
                    {
                        // Variabler for både små og stor bogstaver
                        int checklower = 0;
                        int checkupper = 0;

                        // Tjekker hver karakter
                        foreach (char c in x)
                        {
                            // Tæller bogstaver og om de er stor eller små
                            if (char.IsLower(c))
                                checklower++;
                            if (char.IsUpper(c))
                                checkupper++;
                        }

                        // Tjekker om der er mindste et af hver størrelse
                        if (checkupper > 0 && checklower > 0)
                        {
                            return true;
                        }
                        return false;
                    }

                    // En funktion som tjekker om passwordet har speciale karakter eller tal
                    bool special_tal_check(string x)
                    {
                        // Variabler for tal og speciale karakter 
                        int checktal = 0;
                        int checkchar = 0;
                        string specialChar = @"\|!#$%&'()*+,-./:;<=>?@[\]^_`{|}~";

                        // Tjekker hver karakter
                        foreach (var item in specialChar)
                        {
                            // Tæller speciale karakter
                            if (x.Contains(item))
                                checkchar++;
                        }

                        string tal = @"0123456789";

                        // Tjekker hver karakter
                        foreach (var item in tal)
                        {
                            // Tæller tal karakter
                            if (x.Contains(item))
                                checktal++;
                        }

                        // Tjekker om der er mindste et af hver karakter
                        if (checktal > 0 && checkchar > 0)
                        {
                            return true;
                        }
                        return false;
                    }

                    // En funktion som tjekker om passwordet starter eller ender med et tal
                    bool start_slut_talcheck(string x)
                    {
                        // Varabler for tal position
                        int check = 0;
                        bool StartMedNum = char.IsDigit(x.First());
                        bool SlutMedNum = char.IsDigit(x.Last());

                        // Tjekker om der IKKE er et tal i starten af passwordet
                        if (StartMedNum == false)
                        {
                            check++;
                        }

                        // Tjekker om der IKKE er et tal i slutningen af passwordet
                        if (SlutMedNum == false)
                        {
                            check++;
                        }

                        // Tjekker om der er ingen tal i starten og slutningen af passwordet
                        if (check == 2)
                        {
                            return true;
                        }
                        return false;
                    }

                    // En funktion som tjekker om passwordet indholder mellemrum
                    bool mellemrumcheck(string x)
                    {
                        // Tjekker om passwordet indholder et mellemrum
                        bool mellemrum = x.Contains(" ");

                        if (mellemrum == false)
                        {
                            return true;
                        }
                        return false;
                    }

                    // En funktion som tjekker at passwordet ikke er det samme som brugernavnet
                    bool bruger_lig_passcheck(string x, string y)
                    {
                        // Tjekker om password og brugernavn varablerne indholder det samme
                        if (x.ToLower() == y.ToLower())
                        {
                            return false;
                        }
                        return true;
                    }

                    // En funktion som tjekker om dette password er det samme som et gammelt password
                    bool old(string x)
                    {
                        int check = 0;

                        // Tjekker hver linje i filen
                        foreach (string line in File.ReadLines(passpath))
                        {
                            // Tjekker om filen indholder passwordet
                            if (line.Contains(x))
                            {
                                check++;
                            }
                        }

                        if (check > 0)
                        {
                            return false;
                        }
                        return true;
                    }

                    // Tjekker om password kriterier er overholdt
                    if (længde == false || mellem == false || bogstav == false || special == false || startslut == false || samme == false || Old == false)
                    {
                        // Informer bruger at passwordet ikke er blivet godkendt
                        Logger.WriteLine("Password IKKE godkendt!");
                        Console.ReadKey();
                    }

                    else
                    {
                        // Informer brugeren at passwordet er blivet godkendt
                        Logger.WriteLine("Password godkendt!");
                        // Gemmer det nye brugerdata i filerne
                        File.WriteAllText(path, brugerinput + " " + passinput + "\n");
                        File.AppendAllText(passpath, passinput + "\n");
                        Console.ReadKey();
                    }
                }
            } while (godkendt != true);
        }
    }
}
