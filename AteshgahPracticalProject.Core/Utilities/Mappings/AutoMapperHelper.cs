using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AteshgahPracticalProject.Core.Utilities.Mappings
{
    public class AutoMapperHelper
    {
        public static List<T> MapToListBySameType<T>(List<T> entities)
        {
            Mapper.Initialize(c =>
            {
                c.CreateMap<T, T>();
            });

            List<T> result = Mapper.Map<List<T>, List<T>>(entities);

            return result;
        }

        public static T MapToItemBySameType<T>(T entity)
        {
            Mapper.Initialize(c =>
            {
                c.CreateMap<T, T>();
            });

            T result = Mapper.Map<T, T>(entity);

            return result;
        }
    }
}
