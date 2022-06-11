using innovateKUYS.Models.Context;
using innovateKUYS.Models.Entities;

namespace innovateKUYS
{
    public class DatabaseInitializer
    {
        private DatabaseContext _context;
        private AppSettings _appSettings;   
        public DatabaseInitializer(DatabaseContext context, AppSettings appSettings)
        {
            _context = context; 
            _appSettings = appSettings; 
        }
        public  void Seed()
        {
            if (_context.Users.Any(z => z.Email == _appSettings.AdminEmail) == false)
            {
                _context.Users.Add(new User
                {
                    Email = _appSettings.AdminEmail,    
                    Password = _appSettings.AdminPassword,
                    FirstName = _appSettings.AdminFirstName,    
                    LastName = _appSettings.AdminLastName,  
                    PhoneNumber=_appSettings.AdminPhone,
                    UserType=_appSettings.AdminType,
                    IsActive=true,
                    CreatedUser="Default",
                    CreatedDtm=DateTime.Now
                });
                _context.SaveChanges();
            }
        }
    }
}
