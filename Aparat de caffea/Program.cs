using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aparat_de_cafea
{
    class Program
    { 
        //introducerea variabilelor globale
        static int monede = 0;
        static int rest = 0;
        static char cazuri = 'O';

        //introducerea functiei ce afiseaza in consola instructiunile de utilizare ale programului
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

        //functie ce afiseaza mesajul initial pe "ecranul" aparatului
        private static void Mesajintro()
        {

            Console.WriteLine($"Aveti disponibili {monede} centi in automat.");
            Console.WriteLine("*****************Alegeti tipul de moneda pe care doriti sa o introduceti.*****************");
            Console.WriteLine("N=Nickel, D=Dime, Q=Quarter");
            Console.Write("N          ");
            Console.Write("D          ");
            Console.WriteLine("Q        ");
        }

        //cazul A
        private static void Alegere()
        {

            if (monede < 20) //daca numarul de monede disponibil este sub 20 atunci se trece la tratarea cazurilor
            {

                Mesajintro(); //pentru a introduce dinnou o alta moneda
                GetCoins();
                switch (cazuri)
                {
                    case 'N': //daca la suma se adauga 5 monede atunci se trce la cazul N unde va trata cazul B
                        monede = monede + 5;
                        AlegereB();
                        break;
                    case 'D': //daca la suma se adauga 10 monede atunci se trce la cazul D unde va trata cazul C
                        monede = monede + 10;
                        AlegereC();
                        break;
                    case 'Q': //daca la suma se adauga 25 monede atunci se trce la cazul Q unde va trata cazul A
                        monede = monede + 25;
                        Alegere();
                        break;
                    default: //in momentul in care suma din var "monede" nu corespunde cerintelor atunci se va relua alegerea
                        Console.WriteLine("Alegerea facuta nu poate fi acceptata. Incercati dinnou:");
                        Alegere();
                        break;
                }
            }
            else //daca monedele introduse au fost suficiente pentru achizitionarea produsului atunci
            {
                Console.WriteLine("Va rugam sa ridicati produsul!"); //se va ridica produsul ales aflanduse restul
                rest = monede - 20;
                if (rest != 0) // daca restul este diferit de 0 se va accesa functia Rest pentru a putea fi innapoiat
                    Rest();
            }
        }

        //cazul B; liniile de cod identice cu cele de la cazul A, respecta aceleasi proceduri (implicit au acelasi comentariu)
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

        //Restituirea restului
        private static void Rest()
        {
            monede = monede - 20;
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

        //cazul C
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

        //cazul D
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


    