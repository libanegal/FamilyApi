using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NuGet.Protocol;
using using_DB.Models;

namespace using_DB.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class FamilyMembersController : Controller
    {
        private readonly APIDbContext _context;
        private readonly IFamilyMemberManager _manager;


        public FamilyMembersController(APIDbContext context, IFamilyMemberManager manager)
        {
            _context = context;
            _manager = manager;
        }

        // GET: FamilyMembers
        [HttpGet("Get all family members")]
        public async Task<ActionResult<List<FamilyMember>>> GetAll()
        {
            return _manager.GetAll();           
        }

        // GET: FamilyMembers/Details/5
        [HttpGet("Retrieve single member")]
        public async Task<IQueryable<FamilyMember>> GetFamilyMember(string firstName)
        {
            return _manager.GetFamilyMember(firstName);
        }
        [HttpGet("List of Family")]
        public async Task<ActionResult<List<FamilyMember>>> GetaFamily(string lastName) 
        {

            return _manager.GetaFamily(lastName);
        }


        [HttpDelete("Delete")]
        public async Task<ActionResult<FamilyMember>> DeleteFamilyMember(string firstName)
        {
            _manager.DeleteFamilyMember(firstName);
            return Ok();
        }

        [HttpPost("Add a family member")]      
        public async Task<ActionResult<FamilyMember>> Add(FamilyMember familyMember)
        {
            _manager.Add(familyMember);
            return Ok();
          
        }
        [HttpPut("Update a family member")]
        public void  Update1(FamilyMember familyMember) 
        {
            _manager.UpdateMember(familyMember);
            
        }

    }
}
