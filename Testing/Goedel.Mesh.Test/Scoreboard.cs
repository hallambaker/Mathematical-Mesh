#region // Copyright - MIT License
//  © 2021 by Phill Hallam-Baker
//  
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

using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using System.Net;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.IO;
using Goedel.Mesh.Management;
using Goedel.Mesh.Server;
using Goedel.Mesh.ServiceAdmin;
using Goedel.Mesh.Shell.Host;
using Goedel.Protocol;
using Goedel.Protocol.Presentation;
using Goedel.Protocol.Service;
using Goedel.Test.Core;
using Goedel.Utilities;
using Microsoft.Extensions.Configuration;

namespace Goedel.Mesh.Test;


public class Scoreboard {

    public IServiceListener ServiceListener { get; set; }

    public IMeshMachine MeshMachineCore { get; set; }
    }

public class Collector {

    public Collector(
            Scoreboard scoreboard,
            IServiceListener serviceListener,
            IMeshMachine meshMachineCore) {
        scoreboard.ServiceListener = serviceListener;
        scoreboard.MeshMachineCore = meshMachineCore;
        }
    }