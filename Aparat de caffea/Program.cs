using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aparat_de_cafea
{
    class Program
    {
        static int monede = 0;
        static int rest = 0;
        static char cazuri = 'O';

        static void Instructiuni()
        {
            Console.WriteLine("Instructiuni de utilizare:");
            Console.WriteLine("1. Se vor introduce doar litere de tip uppercase");
            Console.WriteLine("2. Daca alegerea nu este acceptata, incercati reintroducerea optiunii alese, verificand ca aceasta sa indeplineasca conditiile de mai sus.");
        }
        static void GetCoins()
        {
                    
            cazuri = char.Parse(Console.ReadLine());
            Console.Clear();
        }
        private static void Mesajintro()
        {

            Console.WriteLine($"Aveti disponibili {monede} centi in automat.");
            Console.WriteLine("*****************Alegeti tipul de moneda pe care doriti sa o introduceti.*****************");
            Console.WriteLine("N=Nickel, D=Dime, Q=Quarter");
            Console.Write("N          ");
            Console.Write("D          ");
            Console.WriteLine("Q        ");
        }

        private static void Alegere()
        {

            if (monede < 20)
            {

                Mesajintro();
                GetCoins();
                switch (cazuri)
                {
                    case 'N':
                        monede = monede + 5;
                        AlegereB();
                        break;
                    case 'D':
                        monede = monede + 10;
                        AlegereC();
                        break;
                    case 'Q':
                        monede = monede + 25;
                        Alegere();
                        break;
                    default:
                        Console.WriteLine("Alegerea facuta nu poate fi acceptata. Incercati dinnou:");
                        Alegere();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Va rugam sa ridicati produsul!");
                rest = monede - 20;
                if (rest != 0)
                    Rest();
            }
        }

        private static void AlegereB()
        {

            if (monede <= 20)
            {

                Mesajintro();
                GetCoins();
                switch (cazuri)
                {
                    case 'N':
                        monede = monede + 5;
                        AlegereC();
                        break;
                    case 'D':
                        monede = monede + 10;
                        AlegereD();
                        break;
                    case 'Q':
                        monede = monede + 25;
                        Alegere();
                        break;
                    default:
                        Console.WriteLine("Alegerea facuta nu poate fi acceptata. Incercati dinnou:");
                        AlegereB();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Va rugam sa ridicati produsul!");
                rest = monede - 20;
                if (rest != 0)
                    Rest();
            }

        }

        private static void Rest()
        {
            monede -= 20;
            switch (rest)
            {
                case 5:
                    Console.WriteLine("Va rugam ridicati restul de: un Nickel!");
                    monede = monede - 5;
                    break;
                case 10:
                    Console.WriteLine("Va rugam ridicati restul de: un Dime!");
                    monede = monede - 10;
                    break;
                case 15:
                    Console.WriteLine("Va rugam ridicati restul de: un Nickel si un Dime!");
                    monede = monede - 15;
                    break;
                case 20:
                    Console.WriteLine("Va rugam ridicati restul de: un Nickel rest si un Dime!");
                    monede = monede - 15;
                    AlegereB();
                    break;
                default:
                    break;
            }
        }

        private static void AlegereC()
        {
            Mesajintro();
            GetCoins();
            switch (cazuri)
            {
                case 'N':
                    monede = monede + 5;
                    AlegereD();
                    break;
                case 'D':
                    monede = monede + 10;
                    Alegere();
                    break;
                case 'Q':
                    monede = monede + 25;
                    Alegere();
                    break;
                default:
                    Console.WriteLine("Alegerea facuta nu poate fi acceptata. Incercati dinnou:");
                    AlegereC();
                    break;
            }

        }

        private static void AlegereD()
        {

            Mesajintro();
            GetCoins();
            switch (cazuri)
            {
                case 'N':
                    monede = monede + 5;
                    Alegere();
                    break;
                case 'D':
                    monede = monede + 10;
                    Alegere();
                    break;
                case 'Q':
                    monede = monede + 25;
                    AlegereB();
                    break;
                default:
                    Console.WriteLine("Alegerea facuta nu poate fi acceptata. Incercati dinnou:");
                    AlegereD();
                    break;
            }

        }


        static void Main(string[] args)
        {
            Instructiuni();
            
            Console.WriteLine("__________________________________________________________________________________________");
            Console.WriteLine();
            
            Alegere();

            
        }
    }
}


    