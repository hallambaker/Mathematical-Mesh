#region // Copyright - MIT License
//  Copyright © 2015 by Comodo Group Inc.
//  Copyright © 2019-2021 by Phill Hallam-Baker
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
#endregion
using Goedel.IO;
using Goedel.Mesh.Shell.Host;

internal sealed class Program {
    static void Main(string[] args) {
        Shell shell = new() {
            MeshMachine = new MeshMachineCore(fileStatus: FileStatus.Read),
            AddPlatformServices = AddPlatformServices
            };

        shell.Dispatch(args, Console.Out);
        }
    
    public static HostBuilderContext AddPlatformServices(
            HostBuilderContext host, 
            IServiceCollection services) {

#if USE_PLATFORM_WINDOWS
        services.AddSingleton<IComponent, Goedel.Cryptography.Windows.ComponentCryptographyWindows>();
#elif USE_PLATFORM_LINUX
#endif
        return host;
        }
    }

