using System;
using System.Collections.Generic;
using AutoMapper;

namespace HistoryMvc
{
    public static class AutoMapConfig
    {
        public static void RegisterMappings()
        {
            //Mapper.CreateMap<UserProfile, IUserInfoViewModel>();

            Mapper.AssertConfigurationIsValid();
        }
    }
}