using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Linq;
using Dapper;

namespace DataLayer
{
    public class ContactRepositoryEx
    {
        private IDbConnection db;

        public ContactRepositoryEx(string connString)
        {
            this.db = new SqlConnection(connString);
        }

        public int BulkInsertContacts(List<Contact> contacts)
        {
            var sql =
                "INSERT INTO Contacts (FirstName, LastName, Email, Company, Title) VALUES(@FirstName, @LastName, @Email, @Company, @Title); " +
                "SELECT CAST(SCOPE_IDENTITY() AS INT); ";
            return this.db.Execute(sql, contacts);
        }

        public List<Contact> GetContactsById(params int[] ids)
        {
            return this.db.Query<Contact>("SELECT * FROM Contacts WHERE Id IN @Ids", new { Ids = ids }).ToList();
        }

        public List<dynamic> GetDynamicContactsById(params int[] ids)
        {
            return this.db.Query("SELECT * FROM Contacts WHERE Id IN @Ids", new { Ids = ids }).ToList();
        }
    }
}
