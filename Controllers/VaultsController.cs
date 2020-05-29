using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Keepr.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VaultsController : ControllerBase
    {
        private readonly VaultsService _vs;
        private readonly KeepsService _ks;
        public VaultsController(VaultsService vs, KeepsService ks)
        {
            _vs = vs;
            _ks = ks;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Vault>> Get()
        {
            try
            {
                Claim user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
                if (user == null) {
                    throw new Exception("Not logged in.");
                }
                string userId = user.Value;
                return Ok(_vs.Get(userId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            };
        }

        [HttpGet("{id}/keeps")]
        [Authorize]
        public ActionResult<IEnumerable<VaultKeepViewModel>> GetVaultKeeps(int id) 
        {
            try
            {
                Claim user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
                if (user == null)
                {
                    throw new Exception("Must be logged in!");
                }
                string userId = user.Value;
                Vault vault = _vs.GetById(id);
                if (vault == null) 
                {
                    throw new Exception("Not Vault to be found");
                }
                return Ok(_ks.GetVaultKeeps(userId, id));
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpPost]
        [Authorize]
        public ActionResult<Vault> Post([FromBody] Vault newVault)
        {
            try
            {
                var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                newVault.UserId = userId;
                return Ok(_vs.Create(newVault));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult<string> DeleteVault(int id)
        {
            try
            {
                Claim user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
                if (user == null) {
                    throw new Exception("You're not logged in.");
                }
                string userId = user.Value;
                Vault vault = _vs.GetById(id);
                if (vault == null) 
                {
                    throw new Exception("Not Vault to be found");
                }
                if (_vs.DeleteVault(userId, id))
                {
                    return "Successfully Deleted Vault!";
                }
                return "Could Not Delete This Vault";
            }
            catch (System.Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}