using AutoMapper;
using ECommerce.Context.Entities;
using ECommerce.Models.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Service.Helpers
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductsDto>();
        }
    }
}
