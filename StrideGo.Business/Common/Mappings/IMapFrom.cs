using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrideGo.Business.Common.Mappings
{
    public interface IMapFrom<T>
    {
        void Mapping(Profile profile);
    }
}
