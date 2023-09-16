﻿using LocationModel.DT;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FacadeLocationContract
{
    public interface ICityLocationFacade
    {
        Task<List<CityDTO>> Get(string uf);
    }
}
