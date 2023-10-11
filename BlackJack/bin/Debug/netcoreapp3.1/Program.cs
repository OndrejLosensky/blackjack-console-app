using System;
using System.IO;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            // jméno konzole
           
             Console.Title = "Losenský Ročníková práce";
            Console.WriteLine("VÍTEJTE VE HŘE'BLACKJACK'! nyní vám budou volosovány dvě karty");
            Console.WriteLine("zadej prosím své jméno:");
            string jmenoHrace = Console.ReadLine();
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine();
            while (true)
            {


                int bodyHrace = 0;
                int bodyKupiera = 0;

                //vytvoříme náhodné RND
                Random rnd = new Random();
                Random rnd2 = new Random();
                bodyHrace += rnd.Next(7, 12);
                bodyHrace += rnd2.Next(7, 12);
                if (bodyHrace > 21)
                {
                    bodyHrace -= 10;
                }
                //Console.WriteLine("první karta" + bodyHrace.ToString() + "druhá karta" + bodyHrace.ToString());
                bodyKupiera += rnd.Next(7, 12);
                bodyKupiera += rnd2.Next(7, 12);

                if (bodyKupiera > 21)
                {
                    bodyKupiera -= 10;
                }


                while (true)
                {
                    //pokud uživatel za dva hody trefí číslo 21, ihned vyhrává
                    if (bodyHrace == 21)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Vyhrál jsi!!");
                        break;
                    }

                    if (bodyHrace < 15)
                    {
                        Console.WriteLine("Byla ti vylosována další karta z důvodu malého součtu prvních dvou karet");
                        Console.WriteLine("tvůj nynější součet je :", bodyHrace + bodyHrace);
                    }
                    //nyní vytvoříme proměnnou pro možnost vylosování další karty
                    Console.ForegroundColor = ConsoleColor.White;                   
                    Console.WriteLine("součet bodů hráče: " + bodyHrace.ToString());
                    Console.WriteLine("pro vylosování další karty napiš 'HIT', pro pokračování napiš 'STAND'");
                    string odpovedUzivatele = Console.ReadLine().ToLower();
                    Console.WriteLine();
                    //pokud bude odpověď uživatele hit, generátor vylosuje další číslo, pokud bude jeho odpověď stand, je na řadě kupiér.
                    if (odpovedUzivatele == "hit")
                    {
                        bodyHrace += rnd.Next(7, 12);
                        if (bodyHrace > 21)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Prohrál jsi!!!");
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else if (odpovedUzivatele == "stand")
                    {
                        break;
                    }
                    //jestliže uživatel zadá něco jiného, konzole vyzve o opakování odpověďi
                    else
                    {
                        Console.WriteLine("nesprávná odpověď,zadej prosím HIT/STAND");
                        continue;
                    }
                }
                //nyní konzole sečte body a určí kdo je vítěz!
                Console.WriteLine("součet bodů hráče je : " + bodyHrace.ToString());
                //řádek udělaný z pomlček kvůli lepšímu vyznání se v konzoli
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("--------------------------------------------------");
                if (bodyHrace <= 21)
                {
                    //pokud má kupiér méně bodů jak 21 a zároveň méně jak hráč, losuje znovu
                    while (bodyKupiera < 17)
                    {
                        bodyKupiera += rnd.Next(7, 12);
                    }
                    //jestliže mají stejný počet bodů, je to remíza
                    if (bodyHrace == bodyKupiera)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Výsledek hry je remíza, oba mají stejný počet bodů");
                    }
                    //pokud má hráč méně bodů jak kupiér zatímco počet bodů kupiéra se rovná 21 nebo méně, tak vyhrává kupiér
                    else if (bodyHrace < bodyKupiera && bodyKupiera <= 21)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Vyhrává kupiér!");

                        { }
                    }//pokud má hráč více bodů jak kupiér, vyhrává
                    else if (bodyKupiera < bodyHrace)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Vyhrává hráč, gratuluji!!");
                    }//pokud kupiér překročí součet bodů 21 automaticky prohrává 
                    else if (bodyKupiera >= 21)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Vyhrává hráč, gratuluji!!");
                    } //jestliže se body kupiéra rovnají 21, vyhrává
                    else if (bodyKupiera == 21)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Vyhrává kupiér!");
                    }// jesliže body hráče i kupiéra mají součet 21 je to remíza
                    else if (bodyHrace == 21 && bodyKupiera == 21)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("REMÍZA!!!");
                    }
                    else if (bodyKupiera > 21)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("kupiér prohrává!");
                    }
                }
                else
                {
                    Console.WriteLine("Kupiér vyhrává, hráč překročil součet 21 bodů!");
                }
                Console.ForegroundColor = ConsoleColor.White;
                //vypíšeme celkové body kupiéra
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("součet bodů kupiéra: " + bodyKupiera.ToString());
                //zde by měl být loop pro opakování hry po stisknutí klávesy 1
                Console.WriteLine();
                Console.WriteLine("Přejete si opakovat hru?ANO/NE");
                string odpoved = Console.ReadLine().ToLower();
                if (odpoved == "ano")
                {

                    continue;
                }
                else if (odpoved == "ne")
                {
                    Console.WriteLine();
                    Console.WriteLine("OK, hra bude ukončena!");
                }
                else if (odpoved != "ne")
                {
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("odpověď není ano/ne, prosím zadej odpověď znovu! 'A'/'N' ");
                        Console.ForegroundColor = ConsoleColor.White;
                        string odpoved2 = Console.ReadLine().ToLower();
                        if (odpoved2 == "a")
                        {
                            continue;
                        }
                        else if (odpoved2 == "n")
                        {
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Chyba:" + ex.Message);
                    }
                }
                 Console.WriteLine();
                 Console.WriteLine();
                 Console.WriteLine("------------------------------------------------------------------------------");
                 Console.WriteLine("SPSŠ Praha,Betlémská,Losenský Ondřej 1.I., Visual Studio 2019 Verze 16.9.4 ");
                 Console.WriteLine("------------------------------------------------------------------------------");


                 Console.ForegroundColor = ConsoleColor.White;
                 // odřádkujeme řádky v konzoli a poté vypíšeme údaje na poslední řádek               

                 //StreamWriter vypíše údaje do textového souboru,který je uložen v složce s celou aplikací
                 using (StreamWriter sw1 = new StreamWriter("TextFile2.txt", true))
                {

                    sw1.WriteLine(DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString());
                    sw1.WriteLine("počet hodů:{0}");

                    //pokud má hráč méně bodů než kupiér, prohrává!
                    if (bodyHrace <= bodyKupiera)
                    {
                        sw1.WriteLine("vyhrává kupiér!");
                    }
                    //pokud má hráč více bodů než kupiér, vyhrává!
                    else if (bodyHrace >= bodyKupiera)
                    {
                        sw1.WriteLine("vyhrává hráč!");
                    }
                    // jestliže-li mají oba stejný počet bodů,je to remíza!
                    else if (bodyKupiera == bodyHrace)
                    {
                        sw1.WriteLine("výsledek je remíza!");
                    }
                    sw1.WriteLine("jméno hráče:" + jmenoHrace);
                    sw1.WriteLine("--------------");
                };

                //příkazem break; ukončíme while loop a tím začneme další kolo Blackjacku pokud uživatel odpoví ano, pokud ne, program ukončí hru!
                if (Console.ReadLine() != "ano")
                {
                    break;
                }
                else
                {
                    continue;
                }
            }               
            Console.ReadLine();
        }              
    }
}
