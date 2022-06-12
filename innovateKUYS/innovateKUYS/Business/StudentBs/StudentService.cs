using innovateKUYS.Models.Context;
using innovateKUYS.Models.Entities;
using innovateKUYS.Models.ViewsModels.StudentVM;

namespace innovateKUYS.Business.StudentBs
{
    public class StudentService
    {
        private DatabaseContext _db = new DatabaseContext();

        public ServiceResult<object> StudentCreate(StudentViewModel model)
        {
            ServiceResult<object> rst = new ServiceResult<object>();

            if (_db.Students.Any(z => z.StudentCode.ToLower() == model.StudentCode.ToLower()))
            {
                rst.AddError($"'{model.StudentCode}' adresi zaten kayıtlıdır.");
                return rst;
            }

            _db.Students.Add(new Student
            {
                FirstName = model.FirstName.Trim(),
                LastName = model.LastName.Trim(),
                StudentCode = model.StudentCode.Trim(),
                Email = model.Email.Trim(),
                PhoneNumber = model.PhoneNumber.Trim(),
                Password = model.Password.Trim(),
                RegistrationTime = model.RegistrationTime,
                CreatedUser = "System1",
                CreatedDtm = DateTime.Now,
                IsActive = true,
                IsGraduate = false,
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


        public ServiceResult<List<Student>> List()
        {
           List<Student> rst = _db.Students.ToList();
            rst.ForEach(a => a.Password = String.Empty);
            ServiceResult<List<Student>> result = new ServiceResult<List<Student>>();
            result.Data = rst;
            return result;
        }

        public ServiceResult<Student> Find(int id)
        {
            ServiceResult<Student> result = new ServiceResult<Student>()
            {
                Data = _db.Students.Find(id)
            };
            if (result.Data == null)
                result.AddError("Kayıt Bulunamadı.");
            return result;
        }

        public ServiceResult<Student> Update(int id, StudentEditViewModel model)
        {
            ServiceResult<Student> result=new ServiceResult<Student>(); 
            if(_db.Students.Any(x=>x.StudentCode.ToLower()==model.StudentCode.ToLower()&& x.Id != id))
            {
                result.AddError($"'{model.StudentCode}' numarası zaten kayıtlıdır.");
                return result;
            }
           Student student= _db.Students.Find(id);
            student.FirstName = model.FirstName.Trim();
            student.LastName = model.LastName.Trim();
            student.StudentCode=model.StudentCode.Trim();
            student.Email=model.Email.Trim();
            student.GraduationTime = model.GraduationTime;
            student.IsGraduate = model.IsGraduate;
            student.ModifiedUser = "System";
            student.ModifiedDtm = DateTime.Now;
            student.IsActive = model.IsActive;
            student.PhoneNumber = model.PhoneNumber;
            if (_db.SaveChanges() == 0)
            {
                result.AddError("Güncelleme yapılamadı.");
            }
            else
            {
                result.Data = student;
            }
            return result;
        }

        public ServiceResult<object> Remove(int id)
        {

            ServiceResult<object> result=new ServiceResult<object>();

            Student student= _db.Students.Find(id);
            if (student != null)
            {
                _db.Students.Remove(student);
                if (_db.SaveChanges() == 0)
                    result.AddError("Silme işlem yapılamadı.");
            }
            return result;
        }
    }
}
