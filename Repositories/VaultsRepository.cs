using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Dapper;

namespace Keepr.Repositories
{
    public class VaultsRepository
    {
        private readonly IDbConnection _db;

        public VaultsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Vault> Get(string userId)
        {
            string sql = "SELECT * FROM Vaults WHERE userId = @UserId;";
            return _db.Query<Vault>(sql, new { userId });
        }

        internal Vault GetById(int id) 
        {
            string sql = "SELECT * FROM Vaults WHERE id = @Id;";
            return _db.QueryFirstOrDefault<Vault>(sql, new {id});
        }

        internal Vault Create(Vault VaultData)
        {
            string sql = @"
            INSERT INTO Vaults
            (userId, name, description)
            VALUES
            (@UserId, @Name, @Description);
            SELECT LAST_INSERT_ID()";
            VaultData.Id = _db.ExecuteScalar<int>(sql, VaultData);
            return VaultData;
        }
        internal bool DeleteVault(string userId, int id)
        {
            string sql = "DELETE FROM vaults WHERE id = @Id AND userId = @UserId LIMIT 1";
            int affectedRows = _db.Execute(sql, new {userId, id});
            return affectedRows == 1;
        }
    }
}