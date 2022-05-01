using System;
using System.Collections;
//sealed - nie można dziedziczyć z tej klasy
namespace AbstractEx
{


      abstract class Publikacja
    {
        public string Tytul { get; set; }
        public string Wydawca { get; set; }
        public string Autor { get; }
        public int Cena { get; set; }
        public readonly string Waluta = "PLN";

        public Publikacja(string T, string W, string A, int C)
        {
            this.Tytul = T;
            this.Wydawca = W;
            this.Autor = A;
            this.Cena = C;
            
        }


        public class Egzamplarze : IEnumerable
        {
            private Publikacja[] _egzemplarze;
            public Egzamplarze(Publikacja[] pArray)
            {
                _egzemplarze = new Publikacja[pArray.Length];
                for (int i = 0; i < pArray.Length; i++)
                {
                    _egzemplarze[i] = pArray[i];
                }
                    
            }


            IEnumerator IEnumerable.GetEnumerator()
            {
                return (IEnumerator)GetEnumerator();
            }

            public EgzemplarzeEnum GetEnumerator()
            {
                return new EgzemplarzeEnum(_egzemplarze);
            }


        }

        public class EgzemplarzeEnum : IEnumerator
        {
            public Publikacja[] _egzemplarze;
            int pozycja = -1;

            public EgzemplarzeEnum(Publikacja[] list)
            {
                _egzemplarze = list;
            }
            public bool MoveNext()
            {
                pozycja++;
                return (pozycja < _egzemplarze.Length);
            }

            public void Reset()
            {
                pozycja = -1;
            }

            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }

            public Publikacja Current
            {
                get
                {
                    try
                    {
                        return _egzemplarze[pozycja];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }
        }


        abstract public void ZmianaCeny(int NowaCena);
       abstract public  void WyswietlDane();






        //~Publikacja();
    }


    sealed class Ksiazka:Publikacja

    {

        public string ISBN { get;  }

        public Ksiazka(string T, string W, string A, int C) :base(T,W,A,C )
        {
            
        }

        public Ksiazka(string T, string W, string A, string IS, int C ) : this(T, W, A, C)
        {
            ISBN = IS;
        }

        public override  void ZmianaCeny(int NowaCena)
        {
           Cena = NowaCena;
            Console.WriteLine("Nowa cena wynosi {0} {1}", Cena, Waluta);

        }

        public override void WyswietlDane()
        {
            //Console.Clear();
            Console.WriteLine("Tytuł: {0} Wydawca: {1} Autor: {2} ISBN: {3} Cena: {4}{5}",Tytul, Wydawca, Autor,ISBN, Cena,Waluta);
        }

        


    }
    class Czasopismo : Publikacja
    {
        public Czasopismo(string T, string W, string A, int C) : base(T, W, A,C)
        {

        }
        public override void ZmianaCeny(int NowaCena)
        {
            Cena = NowaCena;
            Console.WriteLine("Nowa cena wynosi {0} {1}", Cena, Waluta);

        }

        public override void WyswietlDane()
        {
            Console.Clear();
            Console.WriteLine("Tytuł: {0} Wydawca: {1} Autor: {2} Cena: {4}{5}", Tytul, Wydawca, Autor, Cena, Waluta);
        }

    }
    class Magazyn : Czasopismo
    {
        public Magazyn(string T, string W, string A, int C) : base(T, W, A, C)
        {

        }
        public override void ZmianaCeny(int NowaCena)
        {
            Cena = NowaCena;
            Console.WriteLine("Nowa cena wynosi {0} {1}", Cena, Waluta);

        }
        public override void WyswietlDane()
        {
            
            Console.WriteLine("Tytuł: {0} Wydawca: {1} Autor: {2} Cena: {4}{5}", Tytul, Wydawca, Autor, Cena, Waluta);
        }
    }
    
    sealed class Dziennik : Czasopismo
    {
        public Dziennik(string T, string W, string A, int C) : base(T, W, A, C)
        {

        }
        public override void ZmianaCeny(int NowaCena)
        {
            Cena = NowaCena;
            Console.WriteLine("Nowa cena wynosi {0} {1}", Cena, Waluta);

        }
        public override void WyswietlDane()
        {
           
            Console.WriteLine("Tytuł: {0} Wydawca: {1} Autor: {2} Cena: {4}{5}", Tytul, Wydawca, Autor, Cena, Waluta);
        }
    }
    sealed class Gazeta : Czasopismo
    {
        public Gazeta(string T, string W, string A, int C) : base(T, W, A, C)
        {

        }
        public override void ZmianaCeny(int NowaCena)
        {
            Cena = NowaCena;
            Console.WriteLine("Nowa cena wynosi {0} {1}", Cena, Waluta);

        }
        public override void WyswietlDane()
        {
            
            Console.WriteLine("Tytuł: {0} Wydawca: {1} Autor: {2} Cena: {4}{5}", Tytul, Wydawca, Autor, Cena, Waluta);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            
            int ZmianaCeny;
            

            Ksiazka[] listaKsiazek = new Ksiazka[2]
            {
                new Ksiazka("wichry namiętności", "twoja stara", "marianpazdzioch", "1234", 14),
                new Ksiazka("blabla", "dupa", "stara jarka", "567", 134)
            };


        
            
                Console.WriteLine("1-wyswietl ksiazki, 2-zmien cene");

                int x;
                x = Int16.Parse(Console.ReadLine());
                switch (x)
                {
                    case 1:
                        {
                            for (int i = 0; i < listaKsiazek.Length; i++)
                            {
                                
                                listaKsiazek[i].WyswietlDane();
                            }
                            break;
                        }
                    case 2:
                        {
                        Console.WriteLine("Podaj ISBN:");
                        string temp = Console.ReadLine();

                        for(int i = 0; i < listaKsiazek.Length; i++)
                        {
                            if (temp.Equals(listaKsiazek[i].ISBN) == true)
                            {
                                listaKsiazek[i].WyswietlDane();

                                Console.WriteLine("Czy Chcesz zmienić cenę? tak/nie" );
                                    {
                                    temp = Console.ReadLine();
                                    if (temp.Equals("tak"))
                                    {
                                        Console.WriteLine("Podaj nową kwotę:");
                                        int temp2;
                                        temp2 = Int16.Parse(Console.ReadLine());
                                        listaKsiazek[i].ZmianaCeny(temp2);
                                    }
                                    else { break; }
                                    }
                            }
                            

                        }
                    

                        break;
                         }
                           
                            
                 }
                  
                    
                    
                
                     
        }    



    }            
                    
}

    
    
    


