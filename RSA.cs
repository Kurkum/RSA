using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.IO;


namespace RSA
{
    class Program
    {
        public static BigInteger[] RSA(BigInteger[] tab, BigInteger e, BigInteger n)
        {
            for (int i = 0; i < tab.Length; i++)
            {
                Console.Write(".");
                tab[i] = BigInteger.Pow(tab[i], (int)e) % n;
            }
            return tab;
        }
        public static BigInteger[] ASR(BigInteger[] tab, BigInteger d, BigInteger n)
        {
            for (int i = 0; i < tab.Length; i++)
            {
                Console.Write(".");
                tab[i] = BigInteger.Pow(tab[i], (int)d) % n;
            }
            return tab;
        }

        public static bool czyPierwsza(BigInteger x)
        {
            if (x < 2) return false;
            for(int i = 2; i < x; i++)
            {
                if (x % i == 0) return false;
            }
            return true;
        }

        public static BigInteger getE(BigInteger phi)
        {
            BigInteger e;
            Random rnd = new Random();
            e = rnd.Next(2, (int)(phi));
            while (!czyPierwsza(e))
            {
                e = rnd.Next(2, (int)(phi));
            }
            return e;
        }

        public static BigInteger getD(BigInteger e, BigInteger phi)
        {
            BigInteger d=1;
            


            while(((e*d-1) % phi) != 0)
            {
                //Console.WriteLine(d);
                d++;
            }
            //1mod phi=e*d



            return d;
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Oto nasze dane: ");
            BigInteger p = 1009;
            Console.WriteLine("p = " + p);
            BigInteger q = 1013;
            Console.WriteLine("q = " + q);
            BigInteger n = p * q;
            Console.WriteLine("n = " + n);
            BigInteger phi = (p - 1) * (q - 1);
            Console.WriteLine("phi = " + phi);
            BigInteger e = getE(phi);
            Console.WriteLine("e = " + e);
            BigInteger d = getD(e,phi);
            Console.WriteLine("d = " + d);




 





            /*
             * KLUCZ PUBLICZNY:
             *      e i n
             * KLUCZ PRYWATNY:
             *      d i n
            */


            BigInteger[] tab = new BigInteger[50];

            for (int i = 0; i < tab.Length; i++)
            {
                tab[i] = i;
            }

            Console.WriteLine("Oto nasza tablica: ");
            for (int i = 0; i < tab.Length; i++)
            {
                Console.Write(tab[i] + " ");
            }
            Console.WriteLine();


            tab = RSA(tab, e, n);

            Console.WriteLine("\nOto nasza ZASZYFROWANA tablica: ");
            for (int i = 0; i < tab.Length; i++)
            {
                Console.Write(tab[i] + " ");
            }
            Console.WriteLine();


            tab = ASR(tab, d, n);

            Console.WriteLine("\nOto nasza ODSZYFROWANA tablica: ");
            for (int i = 0; i < tab.Length; i++)
            {
                Console.Write(tab[i] + " ");
            }
            Console.WriteLine();





            /*
            BigInteger b = 2;

            Console.WriteLine("BigInteger: {0}", b.ToString("N"));

            Console.WriteLine("Double:     {0}", Math.Pow(2, 64).ToString("N"));

            Console.WriteLine();

            b = BigInteger.Pow(2, 128);
            BigInteger c = BigInteger.Pow(2, (int)b);

            Console.WriteLine("BigInteger: {0}", b.ToString("N"));

            Console.WriteLine("Double:     {0}", ((double)b).ToString("N"));
            */



        }
    }
}
