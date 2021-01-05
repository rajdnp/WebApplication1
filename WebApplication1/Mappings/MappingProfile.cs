using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;
using WebApplication1.Resources;

namespace WebApplication1.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Make, MakeResource>();
            CreateMap<Model, ModelResource>();
            CreateMap<Feature, FeatureResource>();

            // API Resource to Domain
            CreateMap<SaveVehicleResource, Vehicle>()
                .ForPath(v => v.Id, opt => opt.Ignore())
                .ForPath(v => v.Contact.Email, opt => opt.MapFrom(vr => vr.Contact.Email))
                .ForPath(v => v.Contact.Phone, opt => opt.MapFrom(vr => vr.Contact.Phone))
                .ForPath(v => v.Contact.Name, opt => opt.MapFrom(vr => vr.Contact.Name))
                .ForPath(v => v.Features, opt => opt.Ignore())
                .AfterMap((vr, v) =>
                {
                    var removedFeatures = v.Features.Where(f => !vr.Features.Contains(f.Id));
                    foreach (var feature in removedFeatures)
                        v.Features.Remove(feature);

                    var addedFeatures = vr.Features.Where(id => !v.Features.Any(feature => feature.Id == feature.Id)).Select(x => new Feature { Id = x });
                    foreach (var feature in addedFeatures)
                        v.Features.Add(feature);
                });


            // Domain to API resource
            CreateMap<Vehicle, SaveVehicleResource>()
                .ForPath(vr => vr.Contact.Email, opt => opt.MapFrom(v => v.Contact.Email))
                .ForPath(vr => vr.Contact.Phone, opt => opt.MapFrom(v => v.Contact.Phone))
                .ForPath(vr => vr.Contact.Name, opt => opt.MapFrom(v => v.Contact.Name))
                .ForPath(vr => vr.Features, opt => opt.MapFrom(v => v.Features.Select(x => x.Id)));

            CreateMap<Vehicle, VehicleResource>()
                .ForPath(vr => vr.Make, opt => opt.MapFrom(v => v.Model.Make))
                .ForPath(vr => vr.Contact.Email, opt => opt.MapFrom(v => v.Contact.Email))
                .ForPath(vr => vr.Contact.Phone, opt => opt.MapFrom(v => v.Contact.Phone))
                .ForPath(vr => vr.Contact.Name, opt => opt.MapFrom(v => v.Contact.Name))
                .ForPath(vr => vr.Features, opt => opt.MapFrom(v => v.Features.Select(f => new Feature
                {
                    Id = f.Id,
                    Name = f.Name
                })));
        }
    }
}
