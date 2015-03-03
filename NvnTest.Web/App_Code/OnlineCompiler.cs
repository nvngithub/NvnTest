using System;
using System.Collections.Generic;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.IO;
using Microsoft.VisualBasic;
using Microsoft.VJSharp;
using Microsoft.CSharp;

public class CompilerMessage
{
    private bool success = false;
    private string exe = string.Empty;
    private string exe1 = string.Empty;
    private List<string> errorMessages = new List<string>();

    public bool Success
    {
        get { return success; }
        set { success = value; }
    }

    public string Exe
    {
        get { return exe; }
        set { exe = value; }
    }

    // This is used by for java auto compilation
    public string Exe1
    {
        get { return exe1; }
        set { exe1 = value; }
    }

    public List<string> ErrorMessages
    {
        get { return errorMessages; }
    }
}

internal interface ICompiler
{
    CompilerMessage Compile(string sourceFilename, string outputFilename);
    CompilerMessage Compile(string mainClassFile, string codeFile, string outputFilename);
}

internal class BorlandCompiler : ICompiler
{
    private const string borlandCompilerPath = @"C:\Borland\Bin\";
    private const string compileBatchFile = borlandCompilerPath + "compile.bat";

    private void FormatMessage(string output, CompilerMessage message)
    {
        bool success = true;
        if (String.IsNullOrEmpty(output) == false)
        {
            string[] lines = output.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            Regex filePathRegex = new Regex(@"\bC\b[:\\\w_\d\.]+", RegexOptions.Compiled);
            foreach (string line in lines)
            {
                if (line.Trim().StartsWith("Error"))
                {
                    string formattedLine = filePathRegex.Replace(line, ""); // TODO: 
                    message.ErrorMessages.Add(formattedLine);

                    success = false;
                }
            }

            message.Success = success;
        }
    }

    public CompilerMessage Compile(string sourceFilename, string outputFilename)
    {
        CompilerMessage message = new CompilerMessage();
        try
        {
            ProcessStartInfo startInfo = new ProcessStartInfo(compileBatchFile);
            startInfo.Arguments = sourceFilename;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;

            Process process = new Process();
            process.StartInfo = startInfo;

            process.Start();

            string output = process.StandardOutput.ReadToEnd();

            FormatMessage(output, message);
        }
        catch
        {
            message.Success = false;
            message.ErrorMessages.Add("Unexpected error occured");
        }

        return message;
    }

    public CompilerMessage Compile(string mainClassFile, string codeFile, string outputFilename)
    {
        return null;
    }
}

internal class DotNetCompiler : ICompiler
{
    private CodeDomProvider codeDomProvider;
    internal DotNetCompiler(CodeDomProvider codeDomProvider)
    {
        this.codeDomProvider = codeDomProvider;
    }

    public CompilerMessage Compile(string sourceFilename, string outputFilename)
    {
        CompilerMessage message = new CompilerMessage();

        try
        {
            CompilerParameters compilerParams = new CompilerParameters();
            compilerParams.OutputAssembly = outputFilename;
            compilerParams.GenerateExecutable = true;

            CompilerResults results = codeDomProvider.CompileAssemblyFromFile(compilerParams, sourceFilename);

            message.Success = results.Errors.Count == 0;
            foreach (CompilerError error in results.Errors)
            {
                message.ErrorMessages.Add(error.Line + ": " + error.ErrorText);
            }
        }
        catch
        {
            message.Success = false;
            message.ErrorMessages.Add("Unexpected error occured");
        }

        return message;
    }

    public CompilerMessage Compile(string mainClassFile, string codeFile, string outputFilename)
    {
        CompilerMessage message = new CompilerMessage();

        try
        {
            CompilerParameters compilerParams = new CompilerParameters();
            compilerParams.OutputAssembly = outputFilename;
            compilerParams.GenerateExecutable = true;

            CompilerResults results = codeDomProvider.CompileAssemblyFromFile(compilerParams, mainClassFile, codeFile);

            message.Success = results.Errors.Count == 0;
            foreach (CompilerError error in results.Errors)
            {
                message.ErrorMessages.Add(error.Line + ": " + error.ErrorText);
            }
        }
        catch
        {
            message.Success = false;
            message.ErrorMessages.Add("Unexpected error occured");
        }

        return message;
    }
}

internal class JavaCompiler : ICompiler
{
    private const string javaCompilerPath = @"C:\Program Files\Java\jdk1.7.0_06\bin\javac.exe";

    private void FormatMessage(string output, CompilerMessage message)
    {
        message.Success = true;
        if (String.IsNullOrEmpty(output) == false)
        {
            string[] lines = output.Split("^".ToCharArray());
            message.ErrorMessages.AddRange(lines);
            message.Success = false;
        }
    }

    public CompilerMessage Compile(string sourceFilename, string sourceFilename2)
    {
        return Compile(sourceFilename);
    }

    public CompilerMessage Compile(string mainClassFile, string codeFile, string outputFilename)
    {
        return Compile(mainClassFile + " " + codeFile);
    }

    private CompilerMessage Compile(string args)
    {
        CompilerMessage message = new CompilerMessage();
        try
        {
            ProcessStartInfo startInfo = new ProcessStartInfo(javaCompilerPath);
            startInfo.Arguments = args;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;

            Process process = new Process();
            process.StartInfo = startInfo;

            process.Start();

            string output = process.StandardError.ReadToEnd();

            FormatMessage(output, message);
        }
        catch
        {
            message.Success = false;
            message.ErrorMessages.Add("Unexpected error occured");
        }

        return message;
    }
}

// Manual compilation
internal abstract class CompilerBase
{
    protected string sourceFilename = string.Empty;
    protected string outputFilename = string.Empty;
    protected string extension = string.Empty;
    protected string path = string.Empty;

    protected ICompiler compiler;

    protected virtual void SaveCode(string code, string sessionId)
    {
        if (Directory.Exists(path) == false)
        {
            Directory.CreateDirectory(path);
        }

        sourceFilename = path + "_" + sessionId + "." + extension;
        outputFilename = path + "_" + sessionId + ".exe";

        File.WriteAllText(sourceFilename, code);
    }

    protected string ExeToString(string filename)
    {
        string exeStream = string.Empty;
        using (FileStream fs = new FileStream(filename, FileMode.Open))
        {
            using (BinaryReader br = new BinaryReader(fs))
            {
                byte[] bin = br.ReadBytes(Convert.ToInt32(fs.Length));
                exeStream = Convert.ToBase64String(bin);
            }
        }

        return exeStream;
    }

    public virtual CompilerMessage Compile(string code, string sessionId)
    {
        SaveCode(code, sessionId);

        CompilerMessage message = compiler.Compile(sourceFilename, outputFilename);

        if (message.Success && File.Exists(outputFilename))
        {
            message.Exe = ExeToString(outputFilename);
        }

        return message;
    }
}

internal class CCompiler : CompilerBase
{
    internal CCompiler()
    {
        extension = "c";
        path = @"C:\Borland\Bin\";
        compiler = new BorlandCompiler();
    }
}

internal class CPPCompiler : CompilerBase
{
    internal CPPCompiler()
    {
        extension = "cpp";
        path = @"C:\Borland\Bin\";
        compiler = new BorlandCompiler();
    }
}

internal class CSharpDotNetCompiler : CompilerBase
{
    internal CSharpDotNetCompiler()
    {
        extension = "cs";
        path = @"C:\Source\";
        compiler = new DotNetCompiler(new CSharpCodeProvider());
    }
}

internal class VBDotNetCompiler : CompilerBase
{
    internal VBDotNetCompiler()
    {
        extension = "vb";
        path = @"C:\Source\";
        compiler = new DotNetCompiler(new VBCodeProvider());
    }
}

internal class JSharpDotNetCompiler : CompilerBase
{
    internal JSharpDotNetCompiler()
    {
        extension = "java";
        path = @"C:\Source\";
        compiler = new DotNetCompiler(new VJSharpCodeProvider());
    }
}

internal class JavaCodeCompiler : CompilerBase
{
    private const string javaSourceDirectory = @"C:\Source\";
    private string sourceDirectory = string.Empty;

    protected override void SaveCode(string code, string sessionId)
    {
        sourceDirectory = javaSourceDirectory + sessionId + Path.DirectorySeparatorChar;
        string className = GetJavaClassName(code);

        // 1. Create directory
        if (Directory.Exists(sourceDirectory) == false)
        {
            Directory.CreateDirectory(sourceDirectory);
        }

        // 2. Where to store java source code
        if (String.IsNullOrEmpty(className))
        {
            // Simply create java file if no class files are found. Use Session Id
            sourceFilename = sourceDirectory + sessionId + ".java";
            outputFilename = sourceDirectory + sessionId + ".class";
        }
        else
        {
            sourceFilename = sourceDirectory + className + ".java";
            outputFilename = sourceDirectory + className + ".class";
        }

        // Write source code to file
        File.WriteAllText(sourceFilename, code);
    }

    private string GetJavaClassName(string source)
    {
        string className = string.Empty;
        Regex classNameRegex = new Regex(@"class[\s]+(?<name>[\w]+)", RegexOptions.Compiled);
        Match match = classNameRegex.Match(source);
        if (match.Success)
        {
            className = match.Groups["name"].Value;
        }

        return className;
    }

    public JavaCodeCompiler()
    {
        compiler = new JavaCompiler();
    }
}

// Auto compilation
internal abstract class AutoCompilerBase
{
    protected string ExeToString(string filename)
    {
        string exeStream = string.Empty;
        using (FileStream fs = new FileStream(filename, FileMode.Open))
        {
            using (BinaryReader br = new BinaryReader(fs))
            {
                byte[] bin = br.ReadBytes(Convert.ToInt32(fs.Length));
                exeStream = Convert.ToBase64String(bin);
            }
        }

        return exeStream;
    }

    public abstract CompilerMessage Compile(AutoProgrammingQuestion question, string code, string sessionId, bool isTestMode);
    public abstract string GetTemplateCode(AutoProgrammingQuestion question);
}

internal abstract class CSharp_VB_Java_AutoCodeCompiler : AutoCompilerBase
{
    protected string baseSourceDirectory = string.Empty;
    protected string sourceDirectory = string.Empty;
    protected string extension;
    protected string newline;

    protected AutoProgrammingQuestion question;
    protected bool isTestMode = true;

    protected string mainClassTemplate;
    protected string testCaseTemplate;
    protected string functionCallTemplate;
    protected string classTemplate;
    protected string functionTemplate;

    protected ICompiler compiler;

    public override CompilerMessage Compile(AutoProgrammingQuestion question, string code, string sessionId, bool isTestMode)
    {
        this.question = question;
        this.isTestMode = isTestMode;

        SaveCode(code, sessionId);

        sourceDirectory = baseSourceDirectory + sessionId + Path.DirectorySeparatorChar;
        string codeFilename = sourceDirectory + "Test." + extension;
        string mailClassFilename = sourceDirectory + "Program." + extension;
        string outfile = sourceDirectory + "out.exe";

        CompilerMessage message = compiler.Compile(mailClassFilename, codeFilename, outfile);

        if (message.Success && File.Exists(outfile))
        {
            message.Exe = ExeToString(outfile);
        }

        return message;
    }

    public override string GetTemplateCode(AutoProgrammingQuestion question)
    {
        classTemplate = classTemplate.Replace("###FunctionSignature", GetFunctionSignature(question.Config));

        return classTemplate;
    }

    private string GetFunctionSignature(AutoQuestionSignatureConfig config)
    {
        string signature = string.Empty;

        string returnType = GetValueType(config.ReturnType);

        List<string> args = new List<string>();
        foreach (FunctionInput input in config.Inputs)
        {
            string arg = GetFunctionSingnatureArg(input);

            args.Add(arg);
        }

        functionTemplate = functionTemplate.Replace("###ReturnType", returnType);
        functionTemplate = functionTemplate.Replace("###FunctionName", config.FunctionName);
        functionTemplate = functionTemplate.Replace("###Args", String.Join(", ", args.ToArray()));

        string defaultReturn = "0";
        switch (config.ReturnType)
        {
            case AutoQuestionValueType.String: 
                defaultReturn = @""""""; break;
            case AutoQuestionValueType.Integer:
            case AutoQuestionValueType.Long:
            case AutoQuestionValueType.Float:
            case AutoQuestionValueType.Double:
                defaultReturn = "0"; break;
            case AutoQuestionValueType.Boolean:
                // TODO:
                break;
        }

        functionTemplate = functionTemplate.Replace("###DefaultReturn", defaultReturn);

        return functionTemplate;
    }

    protected virtual string GetFunctionSingnatureArg(FunctionInput input)
    {
        return GetValueType(input.ArgType) + " " + input.Name;
    }

    protected void SaveCode(string code, string sessionId)
    {
        sourceDirectory = baseSourceDirectory + sessionId + Path.DirectorySeparatorChar;
        
        if (Directory.Exists(sourceDirectory))
        {
            Directory.Delete(sourceDirectory, true);
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        Directory.CreateDirectory(sourceDirectory);

        // Save code 
        string codeFilename = sourceDirectory + "Test." + extension;
        File.WriteAllText(codeFilename, code);

        // Get test cases
        List<string> testCases = new List<string>();
        for (int i = 0; i < question.TestCases.Count; i++)
        {
            AutoQuestionTestCase testCase = question.TestCases[i];
            string formateedTestCase = GetTestCase(testCase, i);
            if (String.IsNullOrEmpty(formateedTestCase) == false)
            {
                testCases.Add(formateedTestCase);
            }
        }

        // Save main function with test cases
        mainClassTemplate = mainClassTemplate.Replace("###TestCases", String.Join(Environment.NewLine, testCases.ToArray()));

        string mailClassFilename = sourceDirectory + "Program." + extension;
        File.WriteAllText(mailClassFilename, mainClassTemplate);
    }

    private string GetTestCase(AutoQuestionTestCase testCase, int index)
    {
        if (isTestMode && testCase.IsAllowedInTestMode == false)
        {
            // this test is available only at the backend
            return string.Empty;
        }

        string returnType = GetValueType(question.Config.ReturnType);

        string template = testCaseTemplate;

        template = template.Replace("###Index", "" + (index + 1));
        template = template.Replace("###ExpectedValue", String.Format("{0}{1}{0}", (question.Config.ReturnType == AutoQuestionValueType.String ? @"""" : ""), testCase.ExpectedValue));
        template = template.Replace("###ReturnType", returnType);
        template = template.Replace("###InputValues", GetInputValues(testCase));
        template = template.Replace("###CallFunction", GetCallStatement(testCase));

        return template;
    }

    private string GetCallStatement(AutoQuestionTestCase testCase)
    {
        List<string> args = new List<string>();
        for (int i = 0; i < testCase.InputValues.Count; i++)
        {
            switch (question.Config.Inputs[i].ArgType)
            {
                case AutoQuestionValueType.String:
                    args.Add(String.Format("{0}{1}{0}", @"""", testCase.InputValues[i])); break;
                case AutoQuestionValueType.Integer:
                case AutoQuestionValueType.Long:
                case AutoQuestionValueType.Float:
                case AutoQuestionValueType.Double:
                case AutoQuestionValueType.Boolean:
                    args.Add(String.Format("{0}", testCase.InputValues[i])); break;
            }
        }

        functionCallTemplate = functionCallTemplate.Replace("###Args", String.Join(", ", args.ToArray()));
        functionCallTemplate = functionCallTemplate.Replace("###FunctionName", question.Config.FunctionName);

        return functionCallTemplate;
    }

    private string GetInputValues(AutoQuestionTestCase testCase)
    {
        string inputValues = string.Empty;

        List<string> vals = new List<string>();
        for (int i = 0; i < testCase.InputValues.Count; i++)
        {
            string argName = question.Config.Inputs[i].Name;
            string value = testCase.InputValues[0];

            vals.Add(@"""" + argName + ":" + value + @"""");
            inputValues += @"""" + argName + ":" + value + @"""";
        }

        inputValues = String.Join(" + " + newline + " + ", vals.ToArray());

        return inputValues;
    }

    protected abstract string GetValueType(AutoQuestionValueType type);
}

internal abstract class C_CPP_AutoCodeCompiler : AutoCompilerBase
{
    protected string path = @"C:\Borland\Bin\";
    protected string extension;
    protected string sourceFilename = string.Empty;
    protected string outputFilename = string.Empty;

    protected AutoProgrammingQuestion question;
    protected bool isTestMode = true;

    protected string mainFunctionTemplate;
    protected string testCaseTemplate;
    protected string functionCallTemplate;
    protected string functionTemplate;

    protected ICompiler compiler;

    protected void SaveCode(AutoProgrammingQuestion question, string code, string sessionId)
    {
        if (Directory.Exists(path) == false)
        {
            Directory.CreateDirectory(path);
        }

        sourceFilename = path + "_" + sessionId + "." + extension;
        outputFilename = path + "_" + sessionId + ".exe";

        // Get test cases
        List<string> testCases = new List<string>();
        for (int i = 0; i < question.TestCases.Count; i++)
        {
            AutoQuestionTestCase testCase = question.TestCases[i];
            string formateedTestCase = GetTestCase(testCase, i);
            if (String.IsNullOrEmpty(formateedTestCase) == false)
            {
                testCases.Add(formateedTestCase);
            }
        }

        // Save main function with test cases            
        string returnType = GetValueType(question.Config.ReturnType);
        mainFunctionTemplate = mainFunctionTemplate.Replace("###ReturnType", returnType);
        mainFunctionTemplate = mainFunctionTemplate.Replace("###FunctionSignature", GetFunctionSignature(question.Config));
        mainFunctionTemplate = mainFunctionTemplate.Replace("###TestCases", String.Join(Environment.NewLine, testCases.ToArray()));
        mainFunctionTemplate = mainFunctionTemplate.Replace("###Code", code);

        File.WriteAllText(sourceFilename, mainFunctionTemplate);
    }

    public override CompilerMessage Compile(AutoProgrammingQuestion question, string code, string sessionId, bool isTestMode)
    {
        this.question = question;
        this.isTestMode = isTestMode;

        // save code written by the programmer and template code with test cases
        SaveCode(question, code, sessionId);

        CompilerMessage message = compiler.Compile(sourceFilename, outputFilename);

        if (message.Success && File.Exists(outputFilename))
        {
            message.Exe = ExeToString(outputFilename);
        }

        return message;
    }

    public override string GetTemplateCode(AutoProgrammingQuestion question)
    {
        string code = "/* Please do not include any header files. Header files: stdio.h, string.h are included by default. */" + Environment.NewLine + Environment.NewLine;

        string returnType = GetValueType(question.Config.ReturnType);

        List<string> args = new List<string>();
        foreach (FunctionInput input in question.Config.Inputs)
        {
            string arg = GetValueType(input.ArgType) + " " + input.Name;

            args.Add(arg);
        }

        functionTemplate = functionTemplate.Replace("###ReturnType", returnType);
        functionTemplate = functionTemplate.Replace("###FunctionName", question.Config.FunctionName);
        functionTemplate = functionTemplate.Replace("###Args", String.Join(", ", args.ToArray()));

        string defaultReturn = "0";
        switch (question.Config.ReturnType)
        {
            case AutoQuestionValueType.String: 
                defaultReturn = @""""""; break;
            case AutoQuestionValueType.Integer:
            case AutoQuestionValueType.Long:
            case AutoQuestionValueType.Float:
            case AutoQuestionValueType.Double:
            case AutoQuestionValueType.Boolean:
                defaultReturn = "0"; break;
        }

        functionTemplate = functionTemplate.Replace("###DefaultReturn", defaultReturn);

        return code + functionTemplate;
    }

    protected string GetTestCase(AutoQuestionTestCase testCase, int index)
    {
        if (isTestMode && testCase.IsAllowedInTestMode == false)
        {
            // this test is available only at the backend
            return string.Empty;
        }

        string returnType = GetValueType(question.Config.ReturnType);

        string template = testCaseTemplate;

        template = template.Replace("###ReturnType", returnType);
        template = template.Replace("###Index", "" + (index + 1));
        template = template.Replace("###CallFunction", GetCallStatement(testCase));
        template = template.Replace("###InputValues", GetInputValues(testCase));
        template = template.Replace("###ExpectedValue", testCase.ExpectedValue);
        template = template.Replace("###OutputValue", GetOutputStatement(question.Config.ReturnType));
        template = template.Replace("###Status", GetStatusStatement(question.Config.ReturnType, testCase.ExpectedValue));

        return template;
    }

    private string GetCallStatement(AutoQuestionTestCase testCase)
    {
        List<string> args = new List<string>();
        for (int i = 0; i < testCase.InputValues.Count; i++)
        {
            switch (question.Config.Inputs[i].ArgType)
            {
                case AutoQuestionValueType.String:
                    args.Add(String.Format("{0}{1}{0}", @"""", testCase.InputValues[i])); break;
                case AutoQuestionValueType.Integer:
                case AutoQuestionValueType.Long:
                case AutoQuestionValueType.Float:
                case AutoQuestionValueType.Double:
                case AutoQuestionValueType.Boolean:
                    args.Add(String.Format("{0}", testCase.InputValues[i])); break;
            }
        }

        functionCallTemplate = functionCallTemplate.Replace("###Args", String.Join(", ", args.ToArray()));
        functionCallTemplate = functionCallTemplate.Replace("###FunctionName", question.Config.FunctionName);

        return functionCallTemplate;
    }

    private string GetInputValues(AutoQuestionTestCase testCase)
    {
        string inputValues = string.Empty;

        List<string> vals = new List<string>();
        for (int i = 0; i < testCase.InputValues.Count; i++)
        {
            string argName = question.Config.Inputs[i].Name;
            string value = testCase.InputValues[i];

            vals.Add(argName + ":" + value); ;
        }

        inputValues = @"" + String.Join(@"\n", vals.ToArray()) + @"";

        return inputValues;
    }

    private string GetOutputStatement(AutoQuestionValueType type)
    {
        string statement = string.Empty;
        switch (type)
        {
            case AutoQuestionValueType.String: 
                statement = "val"; break;
            case AutoQuestionValueType.Integer: 
                statement = "itoa(val, buffer, 10)"; break;
            case AutoQuestionValueType.Long:
            case AutoQuestionValueType.Float:
            case AutoQuestionValueType.Double:
            case AutoQuestionValueType.Boolean:
                // TODO
                break;
        }

        return statement;
    }

    private string GetStatusStatement(AutoQuestionValueType type, string value)
    {
        string statement = string.Empty;
        switch (type)
        {
            case AutoQuestionValueType.String:
                statement = String.Format(@"(strcmp(val, ""{0}"") == 0 ? ""SUCCESS"":""FAIL"")", value);
                break;
            case AutoQuestionValueType.Integer:
            case AutoQuestionValueType.Long:
            case AutoQuestionValueType.Float:
            case AutoQuestionValueType.Double:
            case AutoQuestionValueType.Boolean:
                statement = String.Format(@"(val == {0} ? ""SUCCESS"":""FAIL"");", value);
                break;
        }

        return statement;
    }

    protected string GetFunctionSignature(AutoQuestionSignatureConfig config)
    {
        string signature = string.Empty;

        string returnType = GetValueType(config.ReturnType);

        List<string> args = new List<string>();
        foreach (FunctionInput input in config.Inputs)
        {
            string arg = GetValueType(input.ArgType) + " " + input.Name;

            args.Add(arg);
        }

        signature = returnType + " " + config.FunctionName + "(" + String.Join(", ", args.ToArray()) + ");";

        return signature;
    }

    private string GetValueType(AutoQuestionValueType type)
    {
        string valueType = string.Empty;
        switch (type)
        {
            case AutoQuestionValueType.String: valueType = "char*"; break;
            case AutoQuestionValueType.Integer: valueType = "int"; break;
            case AutoQuestionValueType.Long: valueType = "long"; break;
            case AutoQuestionValueType.Float: valueType = "float"; break;
            case AutoQuestionValueType.Double: valueType = "double"; break;
            case AutoQuestionValueType.Boolean: valueType = "int"; break;
        }

        return valueType;
    }
}

internal class AutoCSharpDotNetCompiler : CSharp_VB_Java_AutoCodeCompiler
{
    internal AutoCSharpDotNetCompiler()
    {
        baseSourceDirectory = @"C:\Source\CS\";
        extension = "cs";
        newline = "Environment.NewLine";
        mainClassTemplate = CodeTemplates.Get_CSharp_MainClass_Template();
        testCaseTemplate = CodeTemplates.CSharp_TestCase_Template;
        functionCallTemplate = CodeTemplates.CSharp_FunctionCall_Template;
        classTemplate = CodeTemplates.Get_CSharp_Class_Template();
        functionTemplate = CodeTemplates.CSharp_Function_Template;

        compiler = new DotNetCompiler(new CSharpCodeProvider());
    }

    protected override string GetValueType(AutoQuestionValueType type)
    {
        string valueType = string.Empty;
        switch (type)
        {
            case AutoQuestionValueType.String: valueType = "string"; break;
            case AutoQuestionValueType.Integer: valueType = "int"; break;
            case AutoQuestionValueType.Long: valueType = "long"; break;
            case AutoQuestionValueType.Float: valueType = "float"; break;
            case AutoQuestionValueType.Double: valueType = "double"; break;
            case AutoQuestionValueType.Boolean: valueType = "bool"; break;
        }

        return valueType;
    }
}

internal class AutoVBDotNetCompiler : CSharp_VB_Java_AutoCodeCompiler
{
    internal AutoVBDotNetCompiler()
    {
        baseSourceDirectory = @"C:\Source\VB\";
        extension = "vb";
        newline = "Environment.NewLine";
        mainClassTemplate = CodeTemplates.Get_VB_MainClass_Template();
        testCaseTemplate = CodeTemplates.VB_TestCase_Template;
        functionCallTemplate = CodeTemplates.VB_FunctionCall_Template;
        classTemplate = CodeTemplates.Get_VB_Class_Template();
        functionTemplate = CodeTemplates.VB_Function_Template;

        compiler = new DotNetCompiler(new VBCodeProvider());
    }

    protected override string GetFunctionSingnatureArg(FunctionInput input)
    {
        return "ByVal " + input.Name + " As " + GetValueType(input.ArgType);
    }

    protected override string GetValueType(AutoQuestionValueType type)
    {
        string valueType = string.Empty;
        switch (type)
        {
            case AutoQuestionValueType.String: valueType = "String"; break;
            case AutoQuestionValueType.Integer: valueType = "Integer"; break;
            case AutoQuestionValueType.Long: valueType = "Long"; break;
            case AutoQuestionValueType.Float: valueType = "Single"; break;
            case AutoQuestionValueType.Double: valueType = "Double"; break;
            case AutoQuestionValueType.Boolean: valueType = "Boolean"; break;
        }

        return valueType;
    }
}

internal class AutoJavaCompiler : CSharp_VB_Java_AutoCodeCompiler
{
    internal AutoJavaCompiler()
    {
        baseSourceDirectory = @"C:\Source\Java\";
        extension = "java";
        newline = "GetNewLine()";
        mainClassTemplate = CodeTemplates.Get_Java_MainClass_Template();
        testCaseTemplate = CodeTemplates.Java_TestCase_Template;
        functionCallTemplate = CodeTemplates.Java_FunctionCall_Template;
        classTemplate = CodeTemplates.Get_Java_Class_Template();
        functionTemplate = CodeTemplates.Java_Function_Template;

        compiler = new JavaCompiler();
    }

    protected override string GetValueType(AutoQuestionValueType type)
    {
        string valueType = string.Empty;
        switch (type)
        {
            case AutoQuestionValueType.String: valueType = "String"; break;
            case AutoQuestionValueType.Integer: valueType = "int"; break;
            case AutoQuestionValueType.Long: valueType = "long"; break;
            case AutoQuestionValueType.Float: valueType = "float"; break;
            case AutoQuestionValueType.Double: valueType = "double"; break;
            case AutoQuestionValueType.Boolean: valueType = "boolean"; break;
        }

        return valueType;
    }

    // Base class "Compile" is Overridden here two files need to be returned unlike other type of languages which create only on exe
    public override CompilerMessage Compile(AutoProgrammingQuestion question, string code, string sessionId, bool isTestMode)
    {
        this.question = question;
        this.isTestMode = isTestMode;

        // save code written by the programmer and template code with test cases
        SaveCode(code, sessionId);

        // Compile code. Return error message if compilation fails
        sourceDirectory = baseSourceDirectory + sessionId + Path.DirectorySeparatorChar;
        string codeFilename = sourceDirectory + "Test.java";
        string mailClassFilename = sourceDirectory + "Program.java";
        string mainOutfile = sourceDirectory + "Program.class";
        string testOutfile = sourceDirectory + "Test.class";

        CompilerMessage message = compiler.Compile(codeFilename, mailClassFilename, "");

        if (message.Success && File.Exists(mainOutfile))
        {
            message.Exe = ExeToString(mainOutfile);
        }

        if (message.Success && File.Exists(testOutfile))
        {
            message.Exe1 = ExeToString(testOutfile);
        }

        return message;
    }
}

internal class AutoCCompiler : C_CPP_AutoCodeCompiler
{
    internal AutoCCompiler()
    {
        extension = "c";
        mainFunctionTemplate = CodeTemplates.Get_C_Main_Function_Template();
        testCaseTemplate = CodeTemplates.Get_C_TestCase_Template();
        functionCallTemplate = CodeTemplates.C_FunctionCall_Template;
        functionTemplate = CodeTemplates.C_Function_Template;

        compiler = new BorlandCompiler();
    }
}

internal class AutoCPPCompiler : C_CPP_AutoCodeCompiler
{
    internal AutoCPPCompiler()
    {
        extension = "cpp";
        mainFunctionTemplate = CodeTemplates.Get_CPP_Main_Function_Template();
        testCaseTemplate = CodeTemplates.Get_CPP_TestCase_Template();
        functionCallTemplate = CodeTemplates.CPP_FunctionCall_Template;
        functionTemplate = CodeTemplates.CPP_Function_Template;

        compiler = new BorlandCompiler();
    }
}

public class CodeTemplates
{
    #region C# Templates
    public static string CSharp_Function_Template = @"public static ###ReturnType ###FunctionName(###Args){
        return ###DefaultReturn;
    }";

    public static string CSharp_TestCase_Template = @"###ReturnType output###Index = ###CallFunction;
            bool match###Index = Assert(###ExpectedValue, output###Index);
            ProcessTestCase(###Index, ###InputValues, ###ExpectedValue, output###Index, match###Index);";

    public static string CSharp_FunctionCall_Template = @"Test.###FunctionName(###Args)";

    public static string Get_CSharp_Class_Template()
    {
        return File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath(@"~/App_Code/CodeTemplates/Auto_CSharp_Class_Template.txt"));
    }

    public static string Get_CSharp_MainClass_Template()
    {
        return File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath(@"~/App_Code/CodeTemplates/Auto_CSharp_Main_Template.txt"));
    }
    #endregion

    #region VB Templates
    public static string VB_Function_Template = @"Public Shared Function ###FunctionName(###Args) As ###ReturnType
        Return ###DefaultReturn
    End Function";

    public static string VB_TestCase_Template = @"Dim output###Index As ###ReturnType = ###CallFunction
            Dim match###Index As Boolean = Assert(###ExpectedValue, output###Index)
            ProcessTestCase(###Index, ###InputValues, ###ExpectedValue, output###Index, match###Index)";

    public static string VB_FunctionCall_Template = @"Test.###FunctionName(###Args)";

    public static string Get_VB_Class_Template()
    {
        return File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath(@"~/App_Code/CodeTemplates/Auto_VB_Class_Template.txt"));
    }

    public static string Get_VB_MainClass_Template()
    {
        return File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath(@"~/App_Code/CodeTemplates/Auto_VB_Main_Template.txt"));
    }
    #endregion

    #region Java Templates
    public static string Java_Function_Template = @"public static ###ReturnType ###FunctionName(###Args){
        return ###DefaultReturn;
    }";

    public static string Java_TestCase_Template = @"###ReturnType output###Index = ###CallFunction;
            boolean match###Index = Assert(###ExpectedValue, output###Index);
            ProcessTestCase(###Index, ###InputValues, ###ExpectedValue, output###Index, match###Index);";

    public static string Java_FunctionCall_Template = @"Test.###FunctionName(###Args)";

    public static string Get_Java_Class_Template()
    {
        return File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath(@"~/App_Code/CodeTemplates/Auto_Java_Class_Template.txt"));
    }

    public static string Get_Java_MainClass_Template()
    {
        return File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath(@"~/App_Code/CodeTemplates/Auto_Java_Main_Template.txt"));
    }
    #endregion

    #region C Templates
    public static string C_Function_Template = @"###ReturnType ###FunctionName(###Args){
    return ###DefaultReturn;
}";

    public static string C_FunctionCall_Template = @"###FunctionName(###Args);";

    public static string Get_C_Main_Function_Template()
    {
        return File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath(@"~/App_Code/CodeTemplates/Auto_C_Main_Function_Template.txt"));
    }

    public static string Get_C_TestCase_Template()
    {
        return File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath(@"~/App_Code/CodeTemplates/Auto_C_TestCase_Template.txt"));
    }
    #endregion

    #region C++ Templates
    public static string CPP_Function_Template = @"###ReturnType ###FunctionName(###Args){
    return ###DefaultReturn;
}";

    public static string CPP_FunctionCall_Template = @"###FunctionName(###Args);";

    public static string Get_CPP_Main_Function_Template()
    {
        return File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath(@"~/App_Code/CodeTemplates/Auto_CPP_Main_Function_Template.txt"));
    }

    public static string Get_CPP_TestCase_Template()
    {
        return File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath(@"~/App_Code/CodeTemplates/Auto_CPP_TestCase_Template.txt"));
    }
    #endregion
}