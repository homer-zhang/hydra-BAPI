using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Lonsid.MES.MesManager
{
    public class MesManager : IMesManager
    {
        public MesManager()
        {
            
        }

        public string CallBapi(string parm)
        {
            string output = ""; //输出字符串  
            if (!string.IsNullOrWhiteSpace(parm))
            {
                Process process = new Process();//创建进程对象  
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.WorkingDirectory = "D:\\HYDRA";
                startInfo.FileName = "D:\\HYDRA\\hysys.bat";
                startInfo.Arguments = string.Format("1 \"{0}\"", parm);//“/C”表示执行完命令后马上退出  
                startInfo.UseShellExecute = false;//不使用系统外壳程序启动 
                startInfo.RedirectStandardInput = false;//不重定向输入  
                startInfo.RedirectStandardOutput = true; //重定向输出  
                startInfo.CreateNoWindow = false;//不创建窗口 
        
                process.StartInfo = startInfo;

                try
                {
                    if (process.Start())//开始进程  
                    {
                        //process.WaitForExit(300000);//这里无限等待进程结束  
                        output += process.StandardOutput.ReadToEnd();//读取进程的输出  
                    }
                    else
                        throw new Exception("启动进程失败！");
                }
                catch (Exception ex)
                {
                    output += "进程执行过程中发生错误\r\n";
                    output = ex.Message;//捕获异常，输出异常信息
                }
                finally
                {
                    if (process != null)
                        process.Close();
                }
            }
            return output;
        }
    }
}
