using innovateKUYS.Models.Context;
using innovateKUYS.Models.Entities;
using innovateKUYS.Models.ViewsModels.StudentVM;

namespace innovateKUYS.Business
{
    public class StudentService
    {
        private DatabaseContext _db=new DatabaseContext();

        public ServiceResult StudentCreate(StudentViewModel model)
        {
            ServiceResult rst=new ServiceResult();

            if (_db.Students.Any(z => z.StudentCode.ToLower() == model.StudentCode.ToLower()))
            {
                rst.AddError($"'{model.StudentCode}' adresi zaten kayıtlıdır.");
                return rst;
            }
            
            _db.Students.Add(new Student
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                StudentCode = model.StudentCode,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Password = model.Password,
                RegistrationTime = model.RegistrationTime,
                CreatedUser = "System1",
                CreatedDtm = DateTime.Now,
                IsActive=true,
                IsGraduate=false,
            });

            if (_db.SaveChanges() == 0)
            {
                rst.AddError("kayıt yapılmadı");
                return rst;
            }
            else
            {
                rst.IsError = false;
                rst.Errors.Add("kayıt yapıldı");
                return rst;
            }
        }
    }
}
