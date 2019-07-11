using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using APIScarby.Models;
using Newtonsoft.Json;

namespace APIScarby.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmacyController : ControllerBase
    {
        private readonly AppContext _context;
        public PharmacyController(AppContext baContext)
        {
            _context = baContext;
        }
        [HttpGet]
        public async Task<ActionResult> getUserRoles()
        {
            //           IEnumerable<userRole> test=_context.userRoles.ToList();
            List<pharmacy> tuser = new List<pharmacy>();
            tuser = await _context.pharmacys.ToListAsync();
            return Ok(JsonConvert.SerializeObject(tuser));
        }
        [HttpGet("{phPincode}")]
        public async Task<ActionResult> getUserRoles(string keyName,string phPincode)
        {
            //           IEnumerable<userRole> test=_context.userRoles.ToList();
            List<pharmacy> tuser = new List<pharmacy>();
            tuser = await _context.pharmacys.ToListAsync();
            if(keyName!=null){
            tuser=tuser.Where(er=>er.DrugName.Replace(" ","").ToLower().Contains(keyName.ToLower())).ToList();
            }
            if(phPincode!=null){
                tuser=tuser.Where(er=>er.pharmaPincode==phPincode).ToList();
            }
            return Ok(JsonConvert.SerializeObject(tuser));
        }
    }
}