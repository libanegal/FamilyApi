using using_DB.Models;

namespace using_DB
{
    public interface IFamilyMemberManager 
    {
        public List<FamilyMember> GetAll();
        public  IQueryable<FamilyMember> GetFamilyMember(string FirstName);
        void DeleteFamilyMember(string firstName);
        public List<FamilyMember> GetaFamily(string lastName);
        void Add(FamilyMember familyMember);
        void UpdateMember(FamilyMember familyMember);
    }
    
}
