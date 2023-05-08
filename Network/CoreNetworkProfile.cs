using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MakoSystems.NetworkTransfer;
using MakoSystems.Sovienation.GameCore;
using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace MakoSystems.Sovienation.Mapper;

public class CoreNetworkProfile : Profile
{

    public CoreNetworkProfile()
    {
        CreateMap<MakoSystems.Sovienation.GameCore.Frame2,
            MakoSystems.NetworkTransfer.Frame>();
        CreateMap<MakoSystems.Sovienation.GameCore.FrameItem2,
            MakoSystems.NetworkTransfer.Frame.Types.FrameItem>();
    }
}

public static class MapperRegister
{
    public static IServiceCollection RegisterAutoMapper(this IServiceCollection services,
    IEnumerable<Profile> additilonalProfiles = null)
    {
        var configuration = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new CoreNetworkProfile());
            if (additilonalProfiles != null)
            {
                cfg.AddProfiles(additilonalProfiles);
            }
        });
        var mapper = configuration.CreateMapper();
        services.AddSingleton(mapper);
        return services;
    }
}
