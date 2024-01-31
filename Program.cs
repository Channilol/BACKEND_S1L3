using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp1
{
    internal class Program
    { 
        static void Main(string[] args)
        {
            //ESERCIZIO 1
            //ContoCorrente pippo = new ContoCorrente();
            //pippo.GetName();
            //pippo.GetAccount(); 

            //ESERCIZIO 2           
            //GetName(); array con oggetti già popolati
            //GetNameHardMode(); // array con numero predefinito ma con oggetti da popolare -> versione migliore

            //ESERCIZIO 3
            //GetNumbers();
        }

        //ESERCIZIO 3

        static void GetNumbers()
        {
            int[] arrayNum = new int[3];
            for (int i = 0; i < arrayNum.Length; i++)
                {
                    Console.WriteLine($"Scrivi il {i + 1}° numero:");
                    CheckNumber(Convert.ToInt32(Console.ReadLine()), i);
                }
            NumActions();

            

            void CheckNumber(int number, int index)
            {
                if (number > 0)
                {
                    arrayNum[index] = number;
                }
                else
                {
                    Console.WriteLine("Scrivi un numero maggiore di 0!");
                }
            }

            void NumActions()
            {
                Console.WriteLine("Digita: \n 1 per fare la somma dei numeri \n 2 per fare la media dei numeri \n 3 per chiudere l'applicazione");
                switch (Console.ReadLine())
                {
                    case "1":
                        GetSum();
                        break;
                    case "2":
                        GetAverage();
                        break;
                    case "3":
                        Console.WriteLine("Chiusura applicazione");
                        break;
                    default:
                        Console.WriteLine("Scelta non valida");
                        NumActions();
                        break;
                }
            }

            void GetSum()
            {
                int sum = arrayNum[0] + arrayNum[1] + arrayNum[2];
                Console.WriteLine($"La somma è: {sum} \n");
                NumActions();
            }

            void GetAverage()
            {
                int sum = arrayNum[0] + arrayNum[1] + arrayNum[2];
                int average = sum / 3;
                Console.WriteLine($"La media è: {average} \n");
                NumActions();
            }

        }

        //ESERCIZIO 2

        static void GetName()
        {
            string[] arrayNomi = { "Francesco", "Lorenzo", "Daniel" };
            Console.WriteLine("Scrivi un nome:");
            string nomeScritto = Console.ReadLine();

            if (arrayNomi.Contains(nomeScritto))
            {
                Console.WriteLine($"{nomeScritto} è presente nell'array");
                GetName();
            }
            else
            {
                Console.WriteLine($"{nomeScritto} non è presente nell'array :(");
                GetName();
            }
        }

        static void GetNameHardMode()
        {
            string[] arrayNomi = new string[3];
            Console.WriteLine("Scrivi il primo nome:");
            arrayNomi[0] = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Scrivi il secondo nome:");
            arrayNomi[1] = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Scrivi il terzo nome:");
            arrayNomi[2] = Console.ReadLine();
            Console.Clear();
            CheckNames();

            void CheckNames()
            {
                Console.WriteLine("Scrivi un nome per controllare se è presente dentro l'array:");
                string nomeScritto = Console.ReadLine().ToLower();

                if (arrayNomi.Any(nome => nome.ToLower() == nomeScritto))
                {
                    Console.WriteLine($"{nomeScritto} è presente nell'array \n");
                    CheckNames();
                }
                else
                {
                    Console.WriteLine($"{nomeScritto} non è presente nell'array :( \n");
                    CheckNames();
                }
            }
        }

        //ESERCIZIO 1

        public class ContoCorrente
        {
            private string _name;
            private int _account;

            public string Name
            {
                get
                {
                    return _name;
                }
                set
                {
                    _name = value;
                }
            }

            public int Account
            {
                get
                {
                    return _account;
                }
                set
                {
                    _account = value;
                }
            }

            public void GetName()
            {
                Console.WriteLine("Scrivi il nome dell'intestatario del conto:");
                string input = Console.ReadLine();

                if (input.All(char.IsLetter) && !string.IsNullOrWhiteSpace(input))
                {
                    _name = input;
                }
                else
                {
                    Console.WriteLine("Scrivi un nome vero! \n");
                    GetName();
                }
            }

            public void GetAccount()
            {
                Console.WriteLine("Digita la cifra iniziale da depositare, a partire da un minimo di 1000 euro:");
                string input = Console.ReadLine();

                bool accountCash = int.TryParse(input, out int account);

                if (accountCash && account >= 1000)
                {
                    _account = account;
                    Console.WriteLine("Conto aperto con successo! \n");
                    GetDetails();
                }
                else
                {
                    Console.WriteLine("Devi depositare una cifra minima di 1000 euro! \n");
                    GetAccount();
                }
            }

            public void GetDetails()
            {
                Console.WriteLine($"Dati conto: \n Proprietario: {Name} \n Acconto: {Account} euro \n");
                Actions();
            }

            public void Deposit()
            {
                Console.WriteLine("Digita la cifra che desideri depositare nel conto:");
                string input = Console.ReadLine();

                bool depositCash = int.TryParse(input,out int deposit);

                if (depositCash && deposit > 0)
                {
                    _account += deposit;
                    Console.WriteLine($"Cifra depositata con successo: {deposit} euro \n");
                    GetDetails();
                    Actions();
                }
                else
                {
                    Console.WriteLine("Devi depositare almeno 1 euro nel conto per continuare \n");
                    Deposit();
                }
            }

            public void Withdraw()
            {
                Console.WriteLine("Digita la cifra che desideri ritirare dal conto:");
                string input = Console.ReadLine();

                bool withdrawCash = int.TryParse(input, out int withdraw);

                if (withdrawCash && withdraw > 0)
                {
                    _account -= withdraw;
                    Console.WriteLine($"Cifra ritirata con successo: {withdraw} euro \n");
                    GetDetails();
                    Actions();
                }
                else
                {
                    Console.WriteLine("Devi ritirare almeno 1 euro dal conto per continuare \n");
                    Withdraw();
                }
            }

            public void Actions()
            {
                Console.WriteLine("Digita: \n 1 per depositare \n 2 per prelevare \n 3 per controllare il conto \n 4 chiudi l'applicazione");
                switch (Console.ReadLine())
                {
                    case "1":
                        Deposit();
                        break;
                    case "2":
                        Withdraw();
                        break;
                    case "3":
                        GetDetails();
                        break;
                    case "4":
                        Console.WriteLine("Chiusura applicazione");
                        break;
                    default:
                        Console.WriteLine("Scelta non valida");
                        Actions();
                        break;
                }
            }
        }

    }
}
