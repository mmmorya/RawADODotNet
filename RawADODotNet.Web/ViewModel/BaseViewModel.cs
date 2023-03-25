using System;
using RawADODotNet.Web.Mappers;

namespace RawADODotNet.Web.ViewModel
{
    public abstract class BaseViewModel<TDto>
    {
        public TDto ToDto()
        {
            return WebProfileMapper.Mapper.Map<TDto>(this);
        }
    }
}

