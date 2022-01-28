using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Goedel.Protocol.Service;

namespace Goedel.Protocol.GenericHost;
using Microsoft.Extensions.Logging;
public class LogServiceGeneric : LogService {


    public LogServiceGeneric(
                    IServiceConfiguration serviceConfiguration,
            IHostConfiguration hostConfiguration,
            HostMonitor hostMonitor,
            ILogger logger,
            long first = 0) : base(
                serviceConfiguration, hostConfiguration, hostMonitor, first) {




        }
    
    
    }
