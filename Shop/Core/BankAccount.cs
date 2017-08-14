using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Shop.Core
{
    public class Transaction : IEnumerable<Transaction>
    {
        public decimal amount;

        public Transaction(decimal balance)
        {
            amount = balance;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<Transaction> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        //other details
    }

    public class BankAccount //transactions are data, balance is method.
    {
        private List<Transaction> transactions = GetTransactionsFromDatabase();

        public static List<Transaction> GetTransactionsFromDatabase()
        {
            var list = new List<Transaction>() { }; ;
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString =
                @"Data Source=.\SHOP;" +
                "Initial Catalog=ShopBook;" +
                "Integrated Security=true;" +
                @"Timeout=3; ";

                con.Open();


                SqlCommand command = new SqlCommand("SELECT Value FROM Transakcje", con);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // while there is another record present
                    while (reader.Read())
                    {
                        list.Add(new Transaction((decimal)reader[0]));
                    }
                }

                con.Close();
            }
            return list;
        }

        public void AddTransaction(Transaction t)
        {
            transactions.Add(t);
        }

        public decimal GetBalance()
        {
            return transactions.Select(x => x.amount).Sum();
        }


    }

}