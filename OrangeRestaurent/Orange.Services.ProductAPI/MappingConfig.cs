using AutoMapper;
using Orange.Services.ProductAPI.Models;
using Orange.Services.ProductAPI.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orange.Services.ProductAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
           {
               config.CreateMap<ProductDto, Product>();
               config.CreateMap<Product, ProductDto>();
           });

            return mappingConfig;
        }
    }
}
