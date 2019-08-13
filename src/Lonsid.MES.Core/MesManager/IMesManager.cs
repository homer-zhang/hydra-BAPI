using System;
using System.Collections.Generic;
using System.Text;
using Abp.Dependency;

namespace Lonsid.MES.MesManager
{
    public interface IMesManager : ITransientDependency
    {
        string CallBapi(string parm);
    }
}
