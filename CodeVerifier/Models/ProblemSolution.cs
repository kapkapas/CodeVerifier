using System;
using System.CodeDom.Compiler;
using System.IO;
using System.Runtime.InteropServices;
using System.Web;
using Microsoft.AspNet.Identity;

namespace CodeVerifier.Models
{
    public class ProblemSolution
    {
        public int Id { get; set; }
        public int ProblemId { get; set; }
        public string SolutionCode { get; set; }

        //method which compile code to executable file
        public static bool CompileCodeToFile(string source,string taskId, ref string result)
        {
            CodeDomProvider provider = null;
            string pathToSaveAssembly=HttpRuntime.AppDomainAppPath;

           result = string.Empty;
            bool compileOk = false;
            if (source != null)
            {
                provider = CodeDomProvider.CreateProvider("CSharp");
            }
            {
                //todo when there are no code situation
            }
            if (provider != null)
            {

                string exeName=string.Empty;// = @"D:\default.exe";
                exeName += pathToSaveAssembly + "WorkFolder\\" +System.Security.Principal.WindowsIdentity.GetCurrent().Name.ToString()+ DateTime.Now.ToShortDateString(); //+ "\\" + taskId + ".exe";

                if (!Directory.Exists(exeName))
                {
                    Directory.CreateDirectory(exeName);
                }
                exeName += "\\" + taskId + ".exe";
                CompilerParameters cp=new CompilerParameters();
                //generate executable file
                cp.GenerateExecutable = true;
                //name to assembly
                cp.OutputAssembly = exeName;
                //save assembly as file
                cp.GenerateInMemory = false;
                //set whetheer to treat all warnings and errors.
                cp.TreatWarningsAsErrors = false;
                
                //invoke compilation form source code
                CompilerResults cr = provider.CompileAssemblyFromSource(cp, source);
                if (cr.Errors.Count > 0)
                {
                    result += "Theere are errors in assembly";
                    foreach (var error in cr.Errors)
                    {
                        result += string.Format("{0}", error.ToString());
                    }
                }
                else
                {
                    result += "Successfully";
                    result += cr.PathToAssembly;
                }
                if (cr.Errors.Count>0)
                {
                    compileOk = false;
                }
                else
                {
                    compileOk = true;
                }
            }
            return compileOk;
        }
    }
}