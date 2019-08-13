using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services;
using Lonsid.MES.MesApi.Dtos;

namespace Lonsid.MES.MesApi
{
    public interface IMesAppService : IApplicationService
    {
        RetOutput Call(ParmInput parm);
    }
}
