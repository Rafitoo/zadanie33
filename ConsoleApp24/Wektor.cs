
public class Wektor
{
    private double[] współrzędne;

    public Wektor(params double[] współrzędne)
    {
        this.współrzędne = (double[])współrzędne.Clone();// klonować .clone utworzyć nową tablicę skopiować rzeczy je tam rzucić - czyli stworzyc nową tablicę żeby nie psuło hermetyzacji , z metoda array clone , i użyć castnig , chodzi o to żeby nik nie mógł pozmieniać zawartości       
    }
    
    public byte Wymiar => (byte)współrzędne.Length;

    public double this[byte indeks] 
    {
        get { return współrzędne[indeks]; }
        set { współrzędne[indeks] = value; }
    }

    public double Długość
    {
        get { return Math.Sqrt(IloczynSkalarny(this, this)); }
    }

    public static double IloczynSkalarny(Wektor V, Wektor W)
    {
        if (V.Wymiar != W.Wymiar)
        {
            throw new ArgumentException("Wektory muszą mieć ten sam wymiar.");
        }

        double iloczyn = 0;
        for (byte i = 0; i < V.Wymiar; i++)
        {
            iloczyn += V[i] * W[i];
        }
        return iloczyn;
    }

    public static Wektor Suma(params Wektor[] Wektory)
    {
        if (Wektory.Length == 0)
        {
            throw new ArgumentException("Brak wektorów do zsumowania.");
        }

        byte wymiar = Wektory[0].Wymiar;
        for (int i = 1; i < Wektory.Length; i++)
        {
            if (Wektory[i].Wymiar != wymiar)
            {
                throw new ArgumentException("Wektory muszą mieć ten sam wymiar.");
            }
        }

        double[] noweWspółrzędne = new double[wymiar];
        for (byte i = 0; i < wymiar; i++)
        {
            double suma = 0;
            for (int j = 0; j < Wektory.Length; j++)
            {
                suma += Wektory[j][i];
            }
            noweWspółrzędne[i] = suma;
        }
        return new Wektor(noweWspółrzędne);
    }

    public static Wektor operator +(Wektor V, Wektor W)
    {
        return Suma(V, W);
    }

    public static Wektor operator -(Wektor V, Wektor W)
    {
        return Suma(V, -1 * W);
    }

    public static Wektor operator *(Wektor v, double skalar)
    {
        double[] noweWspółrzędne = new double[v.Wymiar];
        for (byte i = 0; i < v.Wymiar; i++)
        {
            noweWspółrzędne[i] = v[i] * skalar;
        }
        return new Wektor(noweWspółrzędne);
    }

    public static Wektor operator *(double skalar, Wektor v)
    {
        return v * skalar;
    }

    public static Wektor operator /(Wektor v, double skalar)
    {
        if (skalar == 0)
        {
            throw new DivideByZeroException("Nie można dzielić przez zero.");
        }

        double[] noweWspółrzędne = new double[v.Wymiar];
        for (byte i = 0; i < v.Wymiar; i++)
        {
            noweWspółrzędne[i] = v[i] / skalar;
        }
        return new Wektor(noweWspółrzędne);
    }
}
