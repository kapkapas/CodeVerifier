using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace CodeVerifier.Models
{
    public class ProblemSolution
    {
        public int Id { get; set; }
        public int ProblemId { get; set; }
        public string SolutionCode { get; set; }

        public static bool CompileCodeToFile(string source, ref string result)
        {
            CodeDomProvider provider = null;
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
                string exeName = @"default.exe";
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
                        result += string.Format("   {0} \n", error.ToString());
                    }
                }
                else
                {
                    result += "Successfully";
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