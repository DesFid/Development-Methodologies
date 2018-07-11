using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace SaveDB {
    public class Program {
        public static void Main (string[] args) {
            var dB = new BDD ();
            var inWhile = true;
            while (inWhile) {
                Console.Write ("Choose a option\n1\t\tShow table\n2\t\tInsert a Row\n3\t\tDelete a Row\nOption: ");
                int op = Convert.ToInt32 (Console.ReadLine ());
                switch (op) {
                    case 1:
                        dB.Show ();
                        break;
                    case 2:
                        Console.Write ("Insert the field X: ");
                        int x = Convert.ToInt32 (Console.ReadLine ());
                        Console.Write ("Insert the field y: ");
                        int y = Convert.ToInt32 (Console.ReadLine ());
                        Console.Write ("Insert the field X2: ");
                        int x2 = Convert.ToInt32 (Console.ReadLine ());
                        Console.Write ("Insert the field Y2: ");
                        int y2 = Convert.ToInt32 (Console.ReadLine ());
                        dB.Insert (x, y, x2, y2);
                        break;
                    case 3:
                        dB.Show ();
                        Console.Write ("Insert the id for delete: ");
                        int id = Convert.ToInt32 (Console.ReadLine ());
                        dB.Delete (id);
                        break;
                    default:
                        inWhile = false;
                        break;
                }
            }
        }
    }
}