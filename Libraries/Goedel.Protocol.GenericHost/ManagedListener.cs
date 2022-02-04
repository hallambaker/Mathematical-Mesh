﻿using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using Goedel.Protocol.Service;
using System.Text;
using Goedel.Mesh;
using Goedel.Utilities;
using Microsoft.Extensions.Options;

namespace Goedel.Protocol.GenericHost;


/// <summary>
/// Dependency injection wrapper that applies application lifetime management 
/// to a listener dispatching to a set of configured services.
/// </summary>
public class ManagedListener : IHostedService {
    private ILogger Logger { get; }
    private IHostApplicationLifetime AppLifetime { get; }

    private IServiceListener ServiceDispatch { get; }

    /// <summary>
    /// Constructor for configuration via dependency injection.
    /// </summary>
    /// <param name="logger">Logger instance.</param>
    /// <param name="appLifetime">Manage the application lifetime (kill events).</param>
    /// <param name="configuredServices">Configured service providers.</param>
    /// <param name="serviceDispatch">Network dispatch shell.</param>
    public ManagedListener(
            ILogger<ManagedListener> logger,
            IHostApplicationLifetime appLifetime,

            IServiceListener serviceDispatch) {
        Logger = logger;
        AppLifetime = appLifetime;
        ServiceDispatch = serviceDispatch;
        }


    public Task StartAsync(CancellationToken cancellationToken) {

        Logger.Log(Event.Starting, string.Join(" ", Environment.GetCommandLineArgs()));
        AppLifetime.ApplicationStarted.Register(() => {
            Task.Run(async () => {
                try {
                    Logger.Log(Event.HelloWorld);
                    await ServiceDispatch.StartAsync(cancellationToken);
                    }
                catch (Exception ex) {
                    Logger.Log(Event.UnhandledException, ex);
                    }
                finally {
                    AppLifetime.StopApplication();
                    }
            });
        });

        return Task.CompletedTask;
        }

    public Task StopAsync(CancellationToken cancellationToken) {
        return Task.CompletedTask;
        }
    }