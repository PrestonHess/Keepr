using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Dapper;

namespace Keepr.Repositories
{
    public class VaultKeepsRepository
    {
        private readonly IDbConnection _db;

        public VaultKeepsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal bool DeleteVK(int id)
        {
            string sql = "DELETE FROM vaultkeeps WHERE id = @Id LIMIT 1";
            int affectedRow = _db.Execute(sql, new { id });
            return affectedRow == 1;
        }

        internal VaultKeep Create(VaultKeep vaultKeepData)
        {
            string sql = @"
            INSERT INTO vaultkeeps
            (userId, vaultId, keepId)
            VALUES
            (@UserId, @VaultId, @KeepId);
            SELECT LAST_INSERT_ID()";
            vaultKeepData.Id = _db.ExecuteScalar<int>(sql, vaultKeepData);
            return vaultKeepData;
        }
    }
}