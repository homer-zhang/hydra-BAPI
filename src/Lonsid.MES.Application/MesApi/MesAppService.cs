using System;
using System.Collections.Generic;
using System.Text;
using Lonsid.MES.MesApi.Dtos;
using Lonsid.MES.MesManager;
using System.Text.RegularExpressions;


namespace Lonsid.MES.MesApi
{
    public class MesAppService : MESAppServiceBase, IMesAppService
    {
        private IMesManager iMesManager;
        public MesAppService(IMesManager iMesManager)
        {
            this.iMesManager = iMesManager;
        }
        public RetOutput Call(ParmInput input)
        {
            RetOutput ret = new RetOutput();
            string retstring = iMesManager.CallBapi(input.parm);

            string[] lines = retstring.Split("\r\n");

            foreach (var item in lines)
            {
                if (item.Contains("RET=") && item.Contains("KT="))
                {
                    string pattern = "(?<=RET\\=).*?(?=\\|)";
                    Match match = Regex.Match(item, pattern);
                    if(match.Success)
                    {
                        ret.Code = match.Value;
                    }

                    pattern = "(?<=\\|KT\\=).*?(?=\\|)";
                    match = Regex.Match(item, pattern);
                    if (match.Success)
                    {
                        ret.Error = match.Value;
                    }


                    pattern = "(?<=\\|LT\\=).*?(?=\\|)";
                    match = Regex.Match(item, pattern);
                    if (match.Success)
                    {
                        ret.ErrorDesc = match.Value;
                    }
                    break;
                }
            }
            //ret.ErrorDesc = retstring;
            return ret;
        }
    }
}
