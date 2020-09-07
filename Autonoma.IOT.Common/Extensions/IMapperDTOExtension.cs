using AutoMapper;
using System.Collections.Generic;

namespace Autonoma.IOT.Common.Extensions
{
    public static class IMapperDTOExtension
    {
        /// <summary>
        /// Método para el mapeo entre dos clases
        /// </summary>
        /// <typeparam name="TR">Origen</typeparam>
        /// <typeparam name="TA">Destino</typeparam>
        /// <param name="destino">Valor de origen</param>
        /// <returns>TA</returns>
        public static TR MapperToObject<TR, TA>(this TA destino)
            where TR :  new()
        {
            
            Mapper.Initialize(c => c.CreateMap<TA, TR>());
            var a = Mapper.Map<TA,TR>(destino);
            return a;
        }

        /// <summary>
        ///     Extensión para mapear a un objeto
        /// </summary>
        /// <typeparam name="TR">Objeto</typeparam>
        /// <typeparam name="TA">Interface</typeparam>
        /// <param name="origen"></param>
        /// <returns>Objeto</returns>
        public static TA MapperToInterface<TR, TA>(this TR origen)
            where TR : TA, new()
        {
            Mapper.Initialize(c => c.CreateMap<TR, TA>());
            return origen.MapperToObject<TR, TA>();
        }

        /// <summary>
        /// Método para el mapeo entre dos clases
        /// </summary>
        /// <typeparam name="TR">Destino</typeparam>
        /// <typeparam name="TA">Origen</typeparam>
        /// <param name="destino">Valor de origen</param>
        /// <returns>TA</returns>
        public static List<TR> MapperListToObject<TR, TA>(this List<TA> destino)
            where TR : TA, new()
        {
            Mapper.Initialize(c => c.CreateMap<TA, TR>());
            return Mapper.Map<List<TA>, List<TR>>(destino);
        }


        /// <summary>
        ///     Extensión para mapear a una lista de interfaces
        /// </summary>
        /// <typeparam name="TR">Objeto</typeparam>
        /// <typeparam name="TA">Interface</typeparam>
        /// <param name="origen"></param>
        /// <returns>Interface</returns>
        public static List<TA> MapperListToInterface<TR, TA>(this List<TR> origen)
            where TR : TA, new()
        {
            Mapper.Initialize(c => c.CreateMap<TR, TA>());
            return Mapper.Map<List<TR>, List<TA>>(origen);
        }
    }
}
