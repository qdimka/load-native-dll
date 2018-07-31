using System;
using NUnit.Framework;

namespace DynamicLibraries.TestProject
{
    [TestFixture]
    public class Tests
    {
        private readonly string _libraryName 
            = "C:\\Users\\dd\\RiderProjects\\DynamicLibraries\\DynamicLibraries.Library\\bin\\Debug\\x86\\DynamicLibraries.Library.dll";
        
        [Test]
        public void Test1()
        {
            Module.Module module = new Module.Module();

            module.Method(_libraryName, "version of OS:");
        }
    }
}