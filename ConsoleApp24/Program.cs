using System;
using System.Numerics;

public class Program
{
    public static void Main(string[] args)
    {
        
        Wektor v1 = new Wektor(1, 2, 3);
        Wektor v2 = new Wektor(4, 5, 6);
        Wektor suma = v1 + v2;
        Wektor różnica = v2 - v1;
        Wektor iloczyn = v1 * 2.5;
        Wektor iloraz = v2 / 3;

        Console.WriteLine("Wektor v1: " + WypiszWspółrzędne(v1));
        Console.WriteLine("Wektor v2: " + WypiszWspółrzędne(v2));
        Console.WriteLine("Suma v1 + v2: " + WypiszWspółrzędne(suma));
        Console.WriteLine("Różnica v2 - v1: " + WypiszWspółrzędne(różnica));
        Console.WriteLine("Iloczyn v1 * 2.5: " + WypiszWspółrzędne(iloczyn));
        Console.WriteLine("Iloraz v2 / 3: " + WypiszWspółrzędne(iloraz));

        double iloczynSkalarny = Wektor.IloczynSkalarny(v1, v2);
        Console.WriteLine("Iloczyn skalarny v1 * v2: " + iloczynSkalarny);

        Console.ReadKey();
    }

    private static string WypiszWspółrzędne(Wektor v)
    {
        string współrzędne = "";
        for (byte i = 0; i < v.Wymiar; i++)
        {
            współrzędne += v[i] + " ";
        }
        return współrzędne;
    }
}

