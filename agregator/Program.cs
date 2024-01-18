using System;
using System.Collections.Generic;
using System.Linq.Expressions;

internal class Program
{

  
    static void Main(string[] args)
    {
        Console.SetIn(new System.IO.StringReader(test)); // do usunięcia przy ocenie


        var login_czas = new SortedDictionary<string, int>();
        var login_ip = new SortedDictionary<string, SortedSet<string>>();
        int n = int.Parse(Console.ReadLine());
        for(int i = 0; i < n; i++) 
        {
            var linia = Console.ReadLine();
            var dane = linia.Trim().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string ip = dane[0];
            string login = dane[1];
            int czas = int.Parse(dane[2]);

            //Console.WriteLine($"{ip} / {login} / {czas}");
            
            //umieszczanie danych w strukturach (pamięci)
            if (login_czas.ContainsKey(login))
            {   //update
                login_czas[login] += czas;
                login_ip[login].Add(ip);
            }
            else
            {   //insert
                login_czas.Add(login, czas);
                login_ip.Add(login, new SortedSet<string>());
                login_ip[login].Add(ip);
            }

            
        }

        foreach(var login in login_czas.Keys) 
        {
            Console.WriteLine($"{login}: {login_czas[login]} [{string.Join(", ", login_ip[login])}]");
        }
    }
}
