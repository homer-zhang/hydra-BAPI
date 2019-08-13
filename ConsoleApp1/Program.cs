using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            test();


            Console.ReadKey();
        }

        static void test()
        {
            string output = "err";
            string parm = "DLG=ANR.MODIFY|PPS=J|ANR.ATYP=AU|ANR.TRANSFER=PPS|ANR.ANR=P0000012|ANR.AUART=0|ANR.ATK=2020040023|ANR.ATKBEZ=这是成产的成品|ANR.KDBEZ=|ANR.KDAUNR=|ANR.KDAUPOS=|ANR.EXTPRIO=|ANR.AUIDX=+00.00|ANR.SGE:B=ST|ANR.SGR:GUTB=+0000000100.000|ANR.SGR:AUSB=+0000000001.000|ANR.MATTYP=SYSTEM|ANR.CNR=|ANR.PCNR=|ANR.PPKTTYP=|ANR.DATFB=|ANR.ZEIFB=00000|ANR.DATSE=|ANR.ZEISE=00000|ANR.DATTERMB=|ANR.ZEITERMB=00000|ANR.DATTERME=|ANR.ZEITERME=00000|ANR.TERMART=|ANR.REDSTRAT=|ANR.AUGRP=|ANR.DISP=|ANR.PRJNR=|ANR.PLANAUNR=|ANR.KTR=|ANR.APNR=|ANR.APVER=|ANR.SLVER=|ANR.KLKK:MNR=+0000000000.000|ANR.KLKK:L=+0000000000.000|ANR.KLKK:MAT=+0000000000.000|ANR.KLKK:SONST=+0000000000.000|ANR.MATWERT:GUT=+0000000000.000|ANR.MATWERT:AUS=+0000000000.000|ANR.KBN:LBEZID=|ANR.ATKIDX=||USR=9999|";
                //"DLG=A_AN|MNR=20000220|USR=2009|ANR=P00000010010|KNR=80000031|DAT=today|ZEI=now";
            //"hymw.exe -u9999 -d -c\"DLG=CNR.UPDATE|CNR.STA=A|CNR.CNR=PR14M7A113\""; //"hymw.exe -u9999 -d -c\"DLG=A_AN|MNR=M100|USR=2010|ANR=000000dd0002|KNR=9999|DAT=today|ZEI=now\"";
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
            Console.WriteLine("a");
            try
            {
                Console.WriteLine("b");
                if (process.Start())//开始进程  
                {
                    //process.WaitForExit(300000);//这里无限等待进程结束  
                    output = process.StandardOutput.ReadToEnd();//读取进程的输出  

                    Console.WriteLine(output);

                    string[] lines = output.Split("\r\n");

                    foreach (var item in lines)
                    {
                        Console.WriteLine(item);
                        if (item.Contains("RET="))
                        {
                            string pattern = "(?<=RET\\=).*?(?=\\|)";
                            if (!item.StartsWith("RET="))
                                pattern = "(?<=\\|RET\\=).*?(?=\\|)";
                            Match match = Regex.Match(item, pattern);
                            if (match.Success)
                            {
                                Console.WriteLine(match.Value);
                            }

                            pattern = "(?<=\\|KT\\=).*?(?=\\|)";
                            match = Regex.Match(item, pattern);
                            if (match.Success)
                            {
                                Console.WriteLine(match.Value);
                            }


                            pattern = "(?<=\\|LT\\=).*?(?=\\|)";
                            match = Regex.Match(item, pattern);
                            if (match.Success)
                            {
                                Console.WriteLine(match.Value);
                            }
                        }
                    }

                }
                Console.WriteLine("c");
            }
            catch (Exception ex)
            {
                output = ex.Message;//捕获异常，输出异常信息
            }
            finally
            {
                if (process != null)
                    process.Close();
            }
            Console.WriteLine("d");
        }

        static void testReg()
        {
            string item = "ANR.ANR=P0000012|ANR.AUNR=P0000012|ANR.AGNR=|ANR.AFOLG=|ANR.UAGNR=|ANR.SPLNR=|ANR.TABLE=A|ANR.ATYP=AU|ANR.AUART=0|ANR.ADEPROVERWEIS=0|ANR.AST=L|ANR.OPT:PKENN=L|ANR.ANZSPLIT=0|ANR.KAT=|ANR.BEARB=@|ANR.BEARBDAT=08/07/2019|ANR.BEARBZEI=40788|PPS.=J|ANR.SAP=|ANR.MOD:SMENGEABGL=|ANR.MOD:SMENGEABGL2=|ANR.MOD:INSERTRES=|ANR.RMNR=|ANR.MNR=|ANR.ASTUFE=0|ANR.OPT:MULTIMNR=N|ANR.KDBEZ=|ANR.PMNR=|ANR.SGE:B=ST|ANR.SGE:P=|ANR.SGE:GUT=|ANR.SGE:S=|ANR.SGE:T=|ANR.SGE:LI=|ANR.SGR:GUTB=100|ANR.SGR:GUTP=0|ANR.SGR:GUT=0|ANR.SGR:GUTS=0|ANR.SGR:GUTT=0|ANR.SGR:AUSB=1|ANR.SGR:AUSP=0|ANR.SGR:AUS=0|ANR.SGR:AUSS=0|ANR.SGR:AUST=0|ANR.UMRFAKTLI:Z=0|ANR.UMRFAKTLI:N=0|ANR.UMRFAKTP:Z=0|ANR.UMRFAKTP:N=0|ANR.UMRFAKTS:Z=0|ANR.UMRFAKTS:N=0|ANR.UMRFAKTT:Z=0|ANR.UMRFAKTT:N=0|ANR.TLG=1|ANR.IMPFAKT=0|ANR.EINHMENGE=0|ANR.EINHMENGEEINH=|ANR.SZY=0|ANR.SZY:FMT=|ANR.SZY:EXPR=|ANR.SZY:MOD=|ANR.VLZ=0|ANR.WEIGMENGE=0|ANR.AKKORD=E|ANR.RLZ:EXPR=|ANR.RLZ2:EXPR=|ANR.APNR=|ANR.RES:WNR=|ANR.WNR:WNR=|ANR.RES:DNC=|ANR.RES:EMAT=|ANR.OPT:FREMDFERT=N|ANR.WARTZ:NORM=0|ANR.WARTZ=0|ANR.WARTZ:MIN=0|ANR.WARTZ:MOD=|ANR.WARTZ:EXPR=|ANR.RUEZ=0|ANR.RUEZ:MOD=|ANR.RUEZ:EXPR=|ANR.RUEZ:ZUSCHL=0|ANR.BEARBZ=0|ANR.BEARBZ:MOD=|ANR.BEARBZ:EXPR=|ANR.PZ=0|ANR.PZ:MOD=|ANR.PZ:EXPR=|ANR.ABRZ=0|ANR.ABRZ:MOD=|ANR.ABRZ:EXPR=|ANR.LIEZ=0|ANR.LIEZ:MAX=0|ANR.TPZ:NORM=0|ANR.TPZ=0|ANR.TPZ:MIN=0|ANR.TPZ:KAL=0|ANR.LIZ=0|ANR.LSTCODE=|ANR.BMK01=0|ANR.BMK01:MOD=|ANR.BMK02=0|ANR.BMK02:MOD=|ANR.BMK03=0|ANR.BMK03:MOD=|ANR.BMK04=0|ANR.BMK04:MOD=|ANR.BMK05=0|ANR.BMK05:MOD=|ANR.BMK06=0|ANR.BMK06:MOD=|ANR.BMK07=0|ANR.BMK07:MOD=|ANR.BMK08=0|ANR.BMK08:MOD=|ANR.BMK09=0|ANR.BMK09:MOD=|ANR.BMK10=0|ANR.BMK10:MOD=|ANR.BMK11=0|ANR.BMK11:MOD=|ANR.BMK12=0|ANR.BMK12:MOD=|ANR.PBMK01=0|ANR.PBMK01:MOD=|ANR.PBMK02=0|ANR.PBMK02:MOD=|ANR.PBMK03=0|ANR.PBMK03:MOD=|ANR.PBMK04=0|ANR.PBMK04:MOD=|ANR.PBMK05=0|ANR.PBMK05:MOD=|ANR.PBMK06=0|ANR.PBMK06:MOD=|ANR.PBMK07=0|ANR.PBMK07:MOD=|ANR.PBMK08=0|ANR.PBMK08:MOD=|ANR.PBMK09=0|ANR.PBMK09:MOD=|ANR.PBMK10=0|ANR.PBMK10:MOD=|ANR.PBMK11=0|ANR.PBMK11:MOD=|ANR.PBMK12=0|ANR.PBMK12:MOD=|ANR.PDAUER=0|ANR.PDAUER:MOD=|ANR.DAUER=0|ANR.DAUER:MOD=|ANR.LST01=0|ANR.LST01:MOD=|ANR.LST02=0|ANR.LST02:MOD=|ANR.LST03=0|ANR.LST03:MOD=|ANR.LST04=0|ANR.LST04:MOD=|ANR.LST05=0|ANR.LST05:MOD=|ANR.LST06=0|ANR.LST06:MOD=|ANR.LST07=0|ANR.LST07:MOD=|ANR.LST08=0|ANR.LST08:MOD=|ANR.LST09=0|ANR.LST09:MOD=|ANR.LST10=0|ANR.LST10:MOD=|ANR.MGRP=|ANR.MBVERH:NORM=0|ANR.MBVERH:RUE=0|ANR.QUAL:NORM=0|ANR.QUAL:RUE=0|ANR.DATFB=|ANR.ZEIFB=0|ANR.DATSB=|ANR.ZEISB=0|ANR.DATFE=|ANR.ZEIFE=0|ANR.DATSE=|ANR.ZEISE=0|ANR.DATB=|ANR.ZEIB=0|ANR.DATE=|ANR.ZEIE=0|ANR.DATTERMB=|ANR.ZEITERMB=0|ANR.DATTERME=|ANR.ZEITERME=0|ANR.EXTPRIO=0|ANR.AGBEZ=|ANR.TE=0|ANR.TE:FMT=|ANR.TE:EXPR=|ANR.TE:MOD=|ANR.TR=0|ANR.TR:EXPR=|ANR.TR:MOD=|ANR.TEB=0|ANR.TEB:FMT=|ANR.TEB:EXPR=|ANR.TEB:MOD=|ANR.TRB=0|ANR.TRB:EXPR=|ANR.TRB:MOD=|ANR.LART=|ANR.OPT:SPLIT=N|ANR.MAXANZSPLIT=0|ANR.OPT:SNR=N|ANR.OPT:CNR=N|ANR.VERWEIS:FERTVAR=0|ANR.DSBEZ=|ANR.MATTYP=\u001a\u001a|ANR.COLOR=|ANR.SAPAUNR=|ANR.SAPAFOLG=|ANR.SAPVGNR=|ANR.SAPUVGNR=|ANR.SAP:SPLIT=0|ANR.SAP:MRFLG=|ANR.VAB=|ANR.WERK:S=|ANR.SAPAUNRV=|ANR.SAPAFOLGV=|ANR.SAPVGNRV=|ANR.SAPAUNRK=|ANR.SAP:BZGFOLG=|ANR.SAP:VGNRA=|ANR.SAP:VGNRR=|ANR.SAP:USR00=|ANR.SAP:USR01=|ANR.SAP:USR04=0|ANR.SAP:USR04EINH=|ANR.SAPSYS=|ANR.BUPID=|ANR.SGE:BUP=|ANR.SGEISO:BUP=|ANR.SGR:BUP=0|ANR.EXTUMRFAKT:Z=0|ANR.EXTUMRFAKT:N=0|ANR.OPT:UNTLI= |ANR.OPT:UEBLI= |ANR.MENGEPROZ:UEBLI=100|ANR.MENGEPROZ:UNTLI=100|ANR.ATK=2020040023|ANR.ATKBEZ=\u001a\u001a\u001a\u001a\u001a\u001a\u001a|ANR.RFMANR=P0000012|ANR.RFOPT:RS=|ANR.SAP:OPCODE=|ANR.RFBREITEE=0|ANR.RFBREITEA=0|ANR.RFAGVFA=0|ANR.RFRANZ=0|ANR.RFSTKF=0|ANR.RFBSBRS=0|ANR.RFZUZM=0|ANR.RFAGTYP=|ANR.RFABZ=|ANR.RFZUZ=|ANR.RFHUEGEW=0|ANR.RFTRANZ=0|ANR.RFTRANZSUM=0|ANR.PPLNR=0|ANR.PPNR=|ANR.FIR=|ANR.KST=|ANR.KART=|ANR.VGWCODE=|ANR.VGW01=0|ANR.VGW02=0|ANR.VGW03=0|ANR.VGW04=0|ANR.VGW05=0|ANR.VGW06=0|ANR.VGW07=0|ANR.VGW08=0|ANR.VGW09=0|ANR.VGW10=0|ANR.USRFLD=|ANR.FU:1=|ANR.FU:2=|ANR.FU:3=|ANR.FU:4=|ANR.FU:5=|ANR.FU:6=|ANR.FU:7=0|ANR.FU:8=0|ANR.FU:9=0|ANR.FU:10=0|ANR.FU:11=0|ANR.FU:12=0|ANR.FU:13=0|ANR.FU:14=0|ANR.FU:15=0|ANR.FU:16=0|ANR.FU:17=0|ANR.FU:18=0|ANR.FU:19=0|ANR.FU:20=0|ANR.FU:21=0|ANR.FU:22=0|ANR.FU:23=0|ANR.FU:24=0|ANR.FU:25=0|ANR.FU:26=0|ANR.FU:27=0|ANR.FU:28=0|ANR.FU:29=|ANR.FU:30=|ANR.FU:31=|ANR.FU:32=|ANR.FU:33=|ANR.FU:34=|ANR.FU:35=|ANR.FU:36=|ANR.FU:37=|ANR.FU:38=|ANR.FU:39=|ANR.FU:40=|ANR.FU:41=|ANR.FU:42=|ANR.FU:43=|ANR.FU:44=|ANR.FU:45=|ANR.FU:46=|ANR.FU:47=|ANR.FU:48=|ANR.FU:49=|ANR.FU:50=|ANR.FU:51=|ANR.FU:52=|ANR.FU:53=|ANR.FU:54=|ANR.FU:55=|ANR.FU:56=|ANR.FU:57=|ANR.FU:58=|ANR.FU:59=|ANR.FU:60=|ANR.FU:61=|ANR.FU:62=|ANR.FU:63=|ANR.FU:64=|ANR.FU:65=|ANR.FU:66=|ANR.VERARBCODE=SYSTEM|ANR.OPT:VLIST=J|ANR.OPT:ERF=J|PPS.=J|ANR.ANLAG=@|ANR.ANLAGDAT=08/07/2019|ANR.ANLAGZEI=39702|ANR.TRANSFER=PPS|ANR.TRANSFERDAT=08/07/2019|ANR.TRANSFERZEI=39702|ANR.CNR=|ANR.PUFZ=0|ANR.REDPUFZ=0|ANR.OPT:TERM=|ANR.TERMART=|ANR.AUIDX=0|ANR.REDSTRAT=|ANR.REDSTUFE=0|ANR.APVER=|ANR.SLVER=|ANR.DISP=|ANR.AUGRP=|ANR.PCNR=|ANR.PPKTTYP=|ANR.PLANAUNR=|ANR.KDAUNR=|ANR.KDAUPOS=|ANR.PRJNR=|ANR.KTR=|ANR.DLZ=0|ANR.DLZ:MIN=0|ANR.KLKK:L=0|ANR.KLKK:MAT=0|ANR.KLKK:MNR=0|ANR.KLKK:SONST=0|ANR.MATWERT:GUT=0|ANR.MATWERT:AUS=0|ANR.OPT:PLAN=G|ANR.OPT:FIX=|ANR.RESSTA:1=|ANR.RESSTA:2=|ANR.RESSTA:3=|ANR.RESSTA:4=|ANR.RESSTA:5=|ANR.RESSTA:6=|ANR.CALC:MENGE=|ANR.LAY=|ANR.LGORT=|ANR.FERTVER=|ANR.STRGREZ=|ANR.QMMANR=|ANR.QMAGTYP=|ANR.VKNTYP=H|ANR.ATKIDX=|ANR.AST:SEK=|ANR.SPERRKZ= |ANR.SPERR= |ANR.SPERRDAT=|ANR.SPERRZEI=0|ANR.AKTIV= |ANR.AKTIVDAT=|ANR.AKTIVZEI=0|ANR.SPERRKZ:EDIT=|ANR.SPERR:EDIT=|ANR.SPERRDAT:EDIT=|ANR.SPERRZEI:EDIT=|ANR.REAK=|ANR.REAKDAT=|ANR.REAKZEI=|ANR.DATB:E=|ANR.ZEIB:E=0|ANR.DATE:L=|ANR.ZEIE:L=0|ANR.BEARB:PPS=J|ANR.BEARB:HYDRA=|ANR.AFOLG:AKTIV=|ANR.OPT:APPRN=|ANR.AGTYP=|ANR.EGR:GUTB=0|ANR.EGR:GUTP=0|ANR.EGR:GUT=0|ANR.EGR:GUTS=0|ANR.EGR:GUTT=0|ANR.EGR:AUSB=0|ANR.EGR:AUSP=0|ANR.EGR:AUS=0|ANR.EGR:AUSS=0|ANR.EGR:AUST=0|ANR.MNRBARCODE=________|RET=1991|KT=AUNR nicht aenderbar|LT=Auftragskopf kann nicht geaendert werden|";
            string pattern = "(?<=RET\\=).*?(?=\\|)";
            Match match = Regex.Match(item, pattern);
            if (match.Success)
            {
                var Code = match.Value;
                Console.WriteLine(Code);
            }

            pattern = "(?<=\\|KT\\=).*?(?=\\|)";
            match = Regex.Match(item, pattern);
            if (match.Success)
            {
                var Error = match.Value;
                Console.WriteLine(Error);
            }


            pattern = "(?<=\\|LT\\=).*?(?=\\|)";
            match = Regex.Match(item, pattern);
            if (match.Success)
            {
                var ErrorDesc = match.Value;
                Console.WriteLine(ErrorDesc);
            }
        }
    }
}
