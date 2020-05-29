using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
    public class KeepsService
    {
        private readonly KeepsRepository _repo;
        public KeepsService(KeepsRepository repo)
        {
            _repo = repo;
        }
        public IEnumerable<Keep> Get()
        {
            return _repo.Get();
        }

        public Keep Create(Keep newKeep)
        {
            return _repo.Create(newKeep);
        }

        public Keep GetById(int id)
        {
            Keep foundKeep = _repo.GetById(id);
            if (foundKeep == null)
            {
                throw new Exception("Invalid ID");
            }
            return foundKeep;
        }

        public IEnumerable<Keep> GetKeepsByUser(string userId)
        {
            return _repo.GetKeepsByUser(userId);
        }

        public IEnumerable<VaultKeepViewModel> GetVaultKeeps(string userId, int id)
        {
            return _repo.GetVaultKeeps(userId, id);
        }

        public string UpdateViews(int id) {
            Keep foundKeep = GetById(id);
            foundKeep.Views += 1;
            if (_repo.UpdateViews(foundKeep))
            {
                return "Successfully updated view count!";
            }
            return "Unable to update views!";
        }
        public string UpdateKeepCount(int id) {
            Keep foundKeep = GetById(id);
            foundKeep.Keeps += 1;
            if (_repo.UpdateKeepCount(foundKeep))
            {
                return "Successfully updated view count!";
            }
            return "Unable to update views!";
        }

        internal string Delete(int id, string userId)
        {
            Keep foundKeep = GetById(id);
            if (foundKeep.UserId != userId) {
                throw new Exception("This is not your Keep!");
            }
            if (_repo.Delete(id, userId))
            {
                return "Keep has been deleted!";
            }
            throw new Exception("Invalid ID");
        }
    }
}