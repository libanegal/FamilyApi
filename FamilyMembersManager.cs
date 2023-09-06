using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using using_DB.Models;

namespace using_DB
{
    public class FamilyMembersManager : IFamilyMemberManager
    {
        private readonly APIDbContext _context;
        public FamilyMembersManager(APIDbContext context)
        {
            _context = context;
        }
        public async void UpdateMember(FamilyMember familyMember) 
        {

            var existingFamilyMember = _context.FamilyMembers.Where(m => m.FirstName == familyMember.FirstName);
            
            if (existingFamilyMember == null)
            {
                Console.WriteLine("Member does not exist");
            }
            else 
            {
                _context.Entry(familyMember).State = EntityState.Modified;
                await _context.SaveChangesAsync();

            }
        
        }
        public void Add(FamilyMember familyMember)
        {
            var check = _context.FamilyMembers.Where(c => c.id == familyMember.id);
            if (check != null)
            {
                _context.Add(familyMember);
                _context.SaveChangesAsync();
                _context.Update(familyMember);
                
            }
            else
            {
                Console.WriteLine("Member you want to add already exists");
            }
        }

        public void DeleteFamilyMember(string firstName)
        {
            var member =  _context.FamilyMembers.Where(m => m.FirstName == firstName).FirstOrDefaultAsync();
            if (member == null)
            {
                Console.WriteLine("Family member you want to delete doesn't exist"); 
            }
            else
            {
                _context.FamilyMembers.Remove(member.Result); // Mark the entity for deletion
                _context.SaveChangesAsync(); // Commit the deletion to the database
                
            }
        }

        public List<FamilyMember> GetaFamily(string lastName)
        {
            var family = _context.FamilyMembers.Where(m => m.SecondName == lastName).ToListAsync();
            return family.Result;
        }
        public List<FamilyMember> GetAll()
        {
            var list = _context.FamilyMembers.ToListAsync().Result;

            return list;
        }      

        public IQueryable<FamilyMember> GetFamilyMember(string FirstName)
        {
            var familyMember = _context.FamilyMembers.Where(member => member.FirstName == FirstName);
            if (familyMember == null)
            {
                Console.WriteLine("Member you want to get doesn't exist");
            }
            return familyMember;
        }

        private IQueryable<FamilyMember> NotFound()
        {
            throw new NotImplementedException();
        }
    }
}
