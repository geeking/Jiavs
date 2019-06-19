using AutoMapper;
using Jiavs.Application.AutoMapper.Profiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jiavs.Application.AutoMapper
{
    public class Config
    {
        public static void RegisterProfile()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<DomainToDto>();
                cfg.AddProfile<DtoToDomain>();
                cfg.AddProfile<DtoToCommand>();
            });
        }
    }
}