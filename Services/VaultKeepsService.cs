using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
    public class VaultKeepsService
    {
        private readonly VaultKeepsRepository _repo;
        public VaultKeepsService(VaultKeepsRepository repo)
        {
            _repo = repo;
        }

        public VaultKeep Create(VaultKeep newVK)
        {
            return _repo.Create(newVK);
        }

        public string DeleteVK(int id)
        {
            if (_repo.DeleteVK(id))
            {
                return "VaultKeep Destroyed!";
            }
            return "Denied Destruction of VaultKeep";
        }
    }
}