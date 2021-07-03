using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;

namespace TPWebGroupe.App_Start
{
    public class Helper
    {

        public static void WriteFileError(string message)
        {
            try
            {
                string path = System.Web.HttpContext.Current.Server.MapPath("~/Error/erreur.txt");
                System.IO.TextWriter writerFile = new StreamWriter(path, true);
                writerFile.WriteLine("" + DateTime.Now);
                writerFile.WriteLine(message);
                writerFile.WriteLine("-----------------------------------------------");
                writerFile.Flush();
                writerFile.Close();
                writerFile = null;

            } catch (IOException e)
            {
                WriteLogSystem(e.ToString(), "CreateFile");
            }
        }

        public bool CreateFile(string message)
        {
            bool rep = false;
            string fileName = string.Format("{0}{1}{2}", DateTime.Now.Year, DateTime.Now.Day);
            try
            {
                string path = System.Web.HttpContext.Current.Server.MapPath("~/Error/erreur.txt");
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                File.Create(path);
                bool fileUse = true;

                while (fileUse)
                {
                    try
                    {
                        System.IO.TextWriter writeFile = new StreamWriter(path, true);
                        writeFile.WriteLine("" + DateTime.Now);
                        writeFile.WriteLine("--------------------------------------------------");
                        writeFile.Flush();
                        writeFile.Close();
                        writeFile = null;
                        fileUse = false;
                    } catch (Exception e)
                    {
                       WriteLogSystem(e.ToString(), "CreateFile");
                    }
                }
                rep = true;
            }
            catch (IOException e)
            {
                WriteLogSystem(e.ToString(), "CreateFile");
            }
            return rep;
        }

        public void WriteErrorLoad(List<string> message, string theFile)
        {
            try
            {
                string path = System.Web.HttpContext.Current.Server.MapPath("~/Error/erreur.txt");
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                System.IO.TextWriter writeFile = new StreamWriter(path, true);
                writeFile.WriteLine("-------------------------DEBUT-------------------------");
                foreach(var item in message)
                {
                    writeFile.WriteLine(item);
                }
                writeFile.WriteLine("-------------------------FIN-------------------------");
                writeFile.Flush();
                writeFile.Close();
                writeFile = null;

            }
            catch (IOException e)
            {
                WriteLogSystem(e.ToString(), "CreateFile");
            }
        }

        public static void WriteLogSystem(string erreur, string libelle)
        {
            using (EventLog eventLog = new EventLog("Application"))
            {
                eventLog.Source = "TP Web Application Groupe";
                eventLog.WriteEntry(string.Format("date : {0}, libelle: {1}, description: {2}"));
            }
        }


    }
}