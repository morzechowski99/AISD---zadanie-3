using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie_3
{
    public class Najemnicy
    {
        private int max_prowiant;
        private int max_rozrywka;
        private int liczba_najemnikow;
        private Najemnik[] najemnicy;
        private List<int> indeksy_najemnikow = new List<int>();
        public int[,,] wyniki;
        public int counter = 0;
        class Najemnik
        {
            public int sila;
            public int prowiant;
            public int rozrywka;
            
            public Najemnik(int sila, int prowiant, int rozrywka)
            {
                this.sila = sila;
                this.prowiant = prowiant;
                this.rozrywka = rozrywka;
            }
        }
        public Najemnicy()
        {
            StreamReader reader = new StreamReader("C:/Users/marci/Desktop/in.txt");
            string value = reader.ReadLine();
            String[] s = value.Split(null);
            max_prowiant = Int32.Parse(s[0]);
            max_rozrywka = Int32.Parse(s[1]);
            value = reader.ReadLine();
            s = value.Split(null);
            liczba_najemnikow = Int32.Parse(s[0]);
            najemnicy = new Najemnik[liczba_najemnikow];
            int i = 0;
            while((value = reader.ReadLine()) != null)
            {
                s = value.Split(null);
                najemnicy[i] = new Najemnik(Int32.Parse(s[0]), Int32.Parse(s[1]), Int32.Parse(s[2]));
                i++;
            }
            reader.Close();
            wyniki = new int[liczba_najemnikow+1, max_prowiant+1, max_rozrywka+1];
        }
        public void WriteData()
        {
            Console.WriteLine($"{max_prowiant} {max_rozrywka}");
            foreach(Najemnik n in najemnicy)
            {
                Console.WriteLine($"{n.sila} | {n.prowiant} | {n.rozrywka}");
            }
        }
        public int Najlepszy_wybor()
        {
          
            for (int i = 1; i <= liczba_najemnikow; i++)
                for (int j = 1; j <= max_prowiant; j++)
                    for (int g = 1; g <= max_rozrywka; g++)
                    {
                        if (najemnicy[i - 1].prowiant > j || najemnicy[i - 1].rozrywka > g) 
                            wyniki[i, j, g] = wyniki[i - 1, j, g];
                        else if ((wyniki[i - 1, j - najemnicy[i - 1].prowiant, g - najemnicy[i - 1].rozrywka] + najemnicy[i - 1].sila) > wyniki[i - 1, j, g])
                        {
                           wyniki[i, j, g] = wyniki[i - 1, j - najemnicy[i - 1].prowiant, g - najemnicy[i - 1].rozrywka] + najemnicy[i - 1].sila;
                        }
                        else wyniki[i, j, g] = wyniki[i - 1, j, g];
                        counter++;
                    }
            int x = liczba_najemnikow, y = max_prowiant, z = max_rozrywka;
            while(x!=0 && y!=0 && z!=0)
            {
                
                if (wyniki[x, y, z] == wyniki[x - 1, y, z]) x--;
                else
                {
                    indeksy_najemnikow.Add(x);
                    y -= najemnicy[x - 1].prowiant;
                    z -= najemnicy[x - 1].rozrywka;
                    x--;
                }
                counter++; 
            }
            return wyniki[liczba_najemnikow, max_prowiant, max_rozrywka];
        }
        public void Pisz_indeksy()
        {
            Console.Write("Indeksy najemnikow: ");
            for (int i  = indeksy_najemnikow.Count-1; i>=0;i--)
            {
                Console.Write($"{indeksy_najemnikow[i]}  ");
            }
        }
        public int getCounter()
        { return counter; }
    }
}
