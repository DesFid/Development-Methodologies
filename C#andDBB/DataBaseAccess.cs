using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace SaveDB {
    public class BDD {

        public void Insert (double x, double y, double x2, double y2) {
            var connString = "Host=localhost;Username=postgres;Password=CatDes30s;Database=postgres";
            using (var conn = new NpgsqlConnection (connString)) {
                conn.Open ();
                using (var cmd = new NpgsqlCommand ()) {
                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO test (x, y, x2, y2) VALUES (@x,@y,@x2,@y2)";
                    cmd.Parameters.AddWithValue ("x", x);
                    cmd.Parameters.AddWithValue ("y", y);
                    cmd.Parameters.AddWithValue ("x2", x2);
                    cmd.Parameters.AddWithValue ("y2", y2);
                    cmd.ExecuteNonQuery ();
                }
            }
        }

        public void Show () {
            var connString = "Host=localhost;Username=postgres;Password=CatDes30s;Database=postgres";

            using (var conn = new NpgsqlConnection (connString)) {
                conn.Open ();
                Console.WriteLine("ID\tX\t\tY");
                using (var cmd = new NpgsqlCommand ("SELECT id, x, y FROM test", conn))
                using (var reader = cmd.ExecuteReader ())
                while (reader.Read ())
                    Console.Write ("{0}\t{1}\t{2}\n", reader[0], reader[1], reader[2]);
            }
        }
        public void Delete (int id) {
            var connString = "Host=localhost;Username=postgres;Password=CatDes30s;Database=postgres";
            using (var conn = new NpgsqlConnection (connString)) {
                conn.Open ();
                using (var cmd = new NpgsqlCommand ()) {
                    cmd.Connection = conn;
                    cmd.CommandText = "DELETE FROM test WHERE id = @id";
                    cmd.Parameters.AddWithValue ("id", id);
                    Console.WriteLine("Row Deleted");
                    cmd.ExecuteNonQuery ();
                }
            }
        }

    }
}