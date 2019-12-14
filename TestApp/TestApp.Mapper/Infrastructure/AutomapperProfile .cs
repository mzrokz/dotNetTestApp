using AutoMapper;
using AutoMapper.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using TestApp.Models;

namespace TestApp.Mapper.Infrastructure
{
    public class AutoMapperProfile : AutoMapper.Profile
    {
        public static MapperConfiguration Config;
        //public static Mapper Mp;


        public AutoMapperProfile()
        {
            CreateMap<IDataReader, Person>();
        }

        public static void Run()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.AddDataReaderMapping();
                cfg.AddProfile<AutoMapperProfile>();
            });
        }

        //public static void Run()
        //{
        //    AutoMapper.Mapper.Initialize(a =>
        //    {
        //        a.AddProfile<AutomapperWebProfile>();


        //    });

        //    Config = new MapperConfiguration(cfg =>
        //    {
        //        cfg.AddDataReaderMapping();
        //        cfg.CreateMap<IDataReader, Person>();
        //    });

        //    Mp = new Mapper(Config);
        //}

    }
}