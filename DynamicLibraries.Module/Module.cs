using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace DynamicLibraries.Module
{
    [Guid("152D08DD-397C-4548-984E-5D57AAC2E03C")]
    public interface IModule
    {
        string Method(string path, string body);
    }
    
    [Guid("50BB5450-A3FB-465B-80B5-7C82F14C2DFE")]
    public class Module : IModule
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate string MethodDelegate(string body);
        
        public string Method(string path, string body)
        {
            var library = NativeLibrary.LoadLibrary(path);
            
            var function = NativeLibrary.GetProcAddress(library, "Method");

            var error = Marshal.GetLastWin32Error().ToString();

            var method = (MethodDelegate) Marshal
                .GetDelegateForFunctionPointer(function, typeof(MethodDelegate));

            var response = method(body);

            NativeLibrary.FreeLibrary(library);
        
            return response;
        }
    }
}