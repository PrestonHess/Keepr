using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Dapper;

namespace Keepr.Repositories
{
    public class KeepsRepository
    {
        private readonly IDbConnection _db;

        public KeepsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Keep> Get()
        {
            string sql = "SELECT * FROM Keeps WHERE isPrivate = 0;";
            return _db.Query<Keep>(sql);
        }

        internal Keep Create(Keep KeepData)
        {
            string sql = @"
            INSERT INTO keeps
            (userId, name, description, img, isPrivate, views, shares, keeps)
            VALUES
            (@UserId, @Name, @Description, @Img, @IsPrivate, @Views, @Shares, @Keeps);
            SELECT LAST_INSERT_ID()";
            KeepData.Id = _db.ExecuteScalar<int>(sql, KeepData);
            return KeepData;
        }

        internal Keep GetById(int id)
        {
            string sql = "SELECT * FROM keeps WHERE id = @Id";
            return _db.QueryFirstOrDefault<Keep>(sql, new { id });
        }

        internal IEnumerable<Keep> GetKeepsByUser(string userId) {
            string sql = "SELECT * FROM keeps WHERE userid = @UserId";
            return _db.Query<Keep>(sql, new { userId });
        }

        internal IEnumerable<VaultKeepViewModel> GetVaultKeeps(string userId, int vaultId)
        {
            string sql = @"
            SELECT 
            k.*,
            vk.id as vaultKeepId
            FROM vaultkeeps vk
            INNER JOIN keeps k ON k.id = vk.keepId 
            WHERE (vaultId = @vaultId AND vk.userId = @userId)";
            return _db.Query<VaultKeepViewModel>(sql, new { userId, vaultId });
        }

        internal bool UpdateViews(Keep keepData)
        {
            string sql = @"
            UPDATE keeps
            SET
            views = @Views
            WHERE id = @Id";
            int affectedRows = _db.Execute(sql, keepData);
            return affectedRows == 1;
        }
        internal bool UpdateKeepCount(Keep keepData)
        {
            string sql = @"
            UPDATE keeps
            SET
            keeps = @Keeps
            WHERE id = @Id";
            int affectedRows = _db.Execute(sql, keepData);
            return affectedRows == 1;
        }

        internal bool Delete(int id, string userId)
        {
            string sql = "DELETE FROM keeps WHERE id = @Id AND userId = @UserId LIMIT 1";
            int affectedRows = _db.Execute(sql, new {id, userId});
            return affectedRows == 1;
        }
    }
}