using innovateKUYS.Models.Context;
using innovateKUYS.Models.Entities;

namespace innovateKUYS.Business.CourseStudentBS
{
    public class CourseStudentService
    {
        private DatabaseContext _db = new DatabaseContext();

        public ServiceResult<List<CourseStudent>> List()
        {
            List<CourseStudent> rst = _db.CourseStudent.ToList();            
            ServiceResult<List<CourseStudent>> result = new ServiceResult<List<CourseStudent>>();
            result.Data = rst;
            return result;
        }
    }
}
