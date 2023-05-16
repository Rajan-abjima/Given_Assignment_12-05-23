using AutoMapper;
namespace StudentsDataAPI.Profiles
{
    public class StudentDataProfile : Profile
    {
        public StudentDataProfile()
        {
            CreateMap<Entities.StudentData, Models.StudentsDataTable>();
            CreateMap<Models.StudentsDataTable, Entities.StudentData>();
        }
    }
}
