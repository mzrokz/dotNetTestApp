using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using AdoTest.Models;
using AutoMapper;
using AutoMapper.Data;
namespace AdoTest.Infrastructure
{
    public static class AutoMapperProfile
    {
        public static MapperConfiguration Config;
        public static Mapper Mp;

        public static void Run()
        {
            Config = new MapperConfiguration(cfg =>
            {
                cfg.AddDataReaderMapping();
                cfg.CreateMap<IDataReader, PlayerDto>();
            });

            Mp = new Mapper(Config);
        }

    }
}