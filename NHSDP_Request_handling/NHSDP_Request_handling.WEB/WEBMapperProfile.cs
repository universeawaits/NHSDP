using AutoMapper;

using BaseModel = NHSDP_Request_handling.Core.Model;
using NHSDP_Request_handling.WEB.ViewModel;
using NHSDP_Request_handling.Core.Model;

namespace NHSDP_Request_handling.WEB
{
    public class WEBMapperProfile : Profile
    {
        public WEBMapperProfile()
        {
            CreateMap<Internship, InternshipVM>().ForMember(
                destination => destination.Id, options => options.MapFrom(source => source.Id)
                );
            CreateMap<InternshipVM, Internship>().ForMember(
                destination => destination.Id, options => options.MapFrom(source => source.Id)
                );
            CreateMap<BaseModel.Office, OfficeVM>().ForMember(
                destination => destination.Id, options => options.MapFrom(source => source.Id)
                );
            CreateMap<OfficeVM, BaseModel.Office>().ForMember(
                destination => destination.Id, options => options.MapFrom(source => source.Id)
                );
            CreateMap<BaseModel.Program, ProgramVM>().ForMember(
                destination => destination.Id, options => options.MapFrom(source => source.Id)
                );
            CreateMap<ProgramVM, BaseModel.Program>().ForMember(
                destination => destination.Id, options => options.MapFrom(source => source.Id)
                );
            CreateMap<BaseModel.StudyingPlace, StudyingPlaceVM>().ForMember(
                destination => destination.Id, options => options.MapFrom(source => source.Id)
                );
            CreateMap<StudyingPlaceVM, BaseModel.StudyingPlace>().ForMember(
                destination => destination.Id, options => options.MapFrom(source => source.Id)
                );
            CreateMap<BaseModel.Course, CourseVM>().ForMember(
                destination => destination.Id, options => options.MapFrom(source => source.Id)
                );
            CreateMap<CourseVM, BaseModel.Course>().ForMember(
                destination => destination.Id, options => options.MapFrom(source => source.Id)
                );
        }
    }
}
