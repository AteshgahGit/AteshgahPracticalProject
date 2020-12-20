using AteshgahPracticalProject.Core.Aspects.PostSharp.ExceptionAspects;
using AteshgahPracticalProject.Core.Aspects.PostSharp.LogAspects;
using AteshgahPracticalProject.Core.Aspects.PostSharp.PerformanceAspects;
using AteshgahPracticalProject.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("AteshgahPracticalProject.Business")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("AteshgahPracticalProject.Business")]
[assembly: AssemblyCopyright("Copyright ©  2020")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
//[assembly: LogAspect(typeof(DatabaseLogger), AttributeTargetTypes = "AteshgahPracticalProject.Concrete.Managers.*")]
//[assembly: LogAspect(typeof(FileLogger), AttributeTargetTypes = "AteshgahPracticalProject.Business.Concrete.Managers.*")]
[assembly: ExceptionLogAspect(typeof(FileLogger), AttributeTargetTypes = "AteshgahPracticalProject.Business.Concrete.Managers.*")]
[assembly: ExceptionLogAspect(typeof(DatabaseLogger), AttributeTargetTypes = "AteshgahPracticalProject.Business.Concrete.Managers.*")]
//[assembly: PerformanceCounterAspect(AttributeTargetTypes = "AteshgahPracticalProject.Business.Concrete.Managers.Managers.*")]
// Setting ComVisible to false makes the types in this assembly not visible
// to COM components.  If you need to access a type in this assembly from
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("f61e73f3-909e-4add-b3e4-d64cad919145")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
