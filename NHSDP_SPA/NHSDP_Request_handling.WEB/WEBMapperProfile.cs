using AutoMapper;

using BaseModel = NHSDP_SPA.Core.Model;
using NHSDP_SPA.WEB.ViewModel;
using NHSDP_SPA.Core.Model;
using NHSDP_SPA.Logic;


namespace NHSDP_SPA.WEB
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
            CreateMap<Office, OfficeVM>().ForMember(
                destination => destination.Id, options => options.MapFrom(source => source.Id)
                );
            CreateMap<OfficeVM, Office>().ForMember(
                destination => destination.Id, options => options.MapFrom(source => source.Id)
                );
            CreateMap<BaseModel.Program, ProgramVM>().ForMember(
                destination => destination.Id, options => options.MapFrom(source => source.Id)
                );
            CreateMap<ProgramVM, BaseModel.Program>().ForMember(
                destination => destination.Id, options => options.MapFrom(source => source.Id)
                );
            CreateMap<StudyingPlace, StudyingPlaceVM>().ForMember(
                destination => destination.Id, options => options.MapFrom(source => source.Id)
                );
            CreateMap<StudyingPlaceVM, StudyingPlace>().ForMember(
                destination => destination.Id, options => options.MapFrom(source => source.Id)
                );
            CreateMap<Course, CourseVM>().ForMember(
                destination => destination.Id, options => options.MapFrom(source => source.Id)
                );
            CreateMap<CourseVM, Course>().ForMember(
                destination => destination.Id, options => options.MapFrom(source => source.Id)
                );
            CreateMap<ErrorVM, Error>();
            CreateMap<Error, ErrorVM>();
        }
    }
}
