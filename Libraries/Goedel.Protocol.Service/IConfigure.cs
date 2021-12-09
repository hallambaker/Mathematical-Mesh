using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goedel.Protocol.Service;

public interface IServiceConfiguration {
    string WellKnown { get; }

    List<string> Addresses { get; }





    }


public interface IHostConfiguration {

    ReportMode ConsoleOutput { get; }

    string Path { get; }

    string ProfileUdf { get; }

    string DeviceUdf { get; }


    string Id { get; }


    List<string> DNS { get; }


    int Port { get; }
    }