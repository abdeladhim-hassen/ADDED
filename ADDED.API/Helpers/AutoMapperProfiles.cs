using System.Linq;
using ADDED.API.Data;
using ADDED.API.Dtos;
using ADDED.API.Models;
using AutoMapper;

namespace ADDED.API.Helpers
{
    public class AutoMapperProfiles: Profile
    {       private readonly DataContext _context;
        public AutoMapperProfiles(DataContext context)
        {
            _context = context;

        }
        public AutoMapperProfiles()
        {
            CreateMap<Portabletocreate, Portable>();


            CreateMap<Portable, PortableDto>();


             CreateMap<Portable, PortableForAffectation>();


            CreateMap<District, DistrictDto>();


            CreateMap<Localite, LocaliteDto>();



            CreateMap<Chef, ChefDto>();


            CreateMap<Releveurtocreate, Releveur>();





             CreateMap<Releveur, ReleveurForAffectation>()
            .ForMember(dest => dest.LibLocalite, opt =>
                {
                    opt.MapFrom(src => src.LocaliteNavigation.LibLocalite);
                });





            CreateMap<Releveur, ReleveurDto>()
            .ForMember(dest => dest.LibLocalite, opt =>
                {
                    opt.MapFrom(src => src.LocaliteNavigation.LibLocalite);
                });






            CreateMap<Tournee, TourneeDto>();
            CreateMap<Releveur, ReleveurForAffectation>()
            .ForMember(dest => dest.LibLocalite, opt =>
                {
                    opt.MapFrom(src => src.LocaliteNavigation.LibLocalite);
                });





            CreateMap<Releveur, AffectationDto>()
            .ForMember(dest => dest.IdPort, opt =>
                {
                    opt.MapFrom(src => src.Portable.IdPort);
                })
            .ForMember(dest => dest.MarquePort, opt =>
                {
                    opt.MapFrom(src => (src.Portable.MarquePort));
                })
            .ForMember(dest => dest.LibLocalite, opt =>
                {
                    opt.MapFrom(src => src.LocaliteNavigation.LibLocalite);
                });





                CreateMap<Releveur, PlanningDto>()
                .ForMember(dest => dest.IdPort, opt =>
                {
                    opt.MapFrom(src => src.Portable.IdPort);
                })
            .ForMember(dest => dest.MarquePort, opt =>
                {
                    opt.MapFrom(src => (src.Portable.MarquePort));
                })
            .ForMember(dest => dest.LibLocalite, opt =>
                {
                    opt.MapFrom(src => src.LocaliteNavigation.LibLocalite);
                })
            .ForMember(dest => dest.Tournee, opt =>
                {
                    opt.MapFrom(src => src.Tournee.ToArray());
                })
            .ForMember(dest => dest.DatAffect, opt =>
                {
                    opt.MapFrom(src => src.Tournee.FirstOrDefault().DatAffect);
                });




            CreateMap<Creation, CompteurDto>()
            .ForMember(dest => dest.LibAno, opt =>
                {
                    opt.MapFrom(src => src.AnoNavigation.LibAno);
                });





            CreateMap<ListAnomalie, AnomalieDto>()
            .ForMember(dest => dest.Ordre, opt =>
                {
                    opt.MapFrom(src => src.IdOrdrNavigation.IdOrdr);
                })
            .ForMember(dest => dest.Tour, opt =>
                {
                    opt.MapFrom(src => src.IdOrdrNavigation.IdTourNavigation.Tour);
                })
            .ForMember(dest => dest.Ordre, opt =>
                {
                    opt.MapFrom(src => src.IdOrdrNavigation.Ordre);
                })
            .ForMember(dest => dest.PoLice, opt =>
                {
                    opt.MapFrom(src => src.IdOrdrNavigation.Police);
                })
            .ForMember(dest => dest.LibAno, opt =>
                {
                    opt.MapFrom(src => src.IdAnoNavigation.LibAno);
                });




                CreateMap<Index, IndexDto>()
            .ForMember(dest => dest.Tour, opt =>
                {
                    opt.MapFrom(src => src.IdOrdrNavigation.IdTourNavigation.Tour);
                })
            .ForMember(dest => dest.Ordre, opt =>
                {
                    opt.MapFrom(src => src.IdOrdrNavigation.Ordre);
                })
            .ForMember(dest => dest.Police, opt =>
                {
                    opt.MapFrom(src => src.IdOrdrNavigation.Police);
                })
            .ForMember(dest => dest.AncienIndex, opt =>
                {
                    opt.MapFrom(src => src.IdOrdrNavigation.AncienIndex);
                });
        }
    }
}