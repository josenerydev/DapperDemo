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

        public List<Contact> GetContactsById(params int[] ids)
        {
            return this.db.Query<Contact>("SELECT * FROM Contacts WHERE Id IN @Ids", new { Ids = ids }).ToList();
        }
    }
}
