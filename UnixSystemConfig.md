# Configuring UNIX Services


Which pile of festering crap are we using?

~~~~
On Debian based linux distributions :

$ dpkg -S $(which init)
systemd-sysv: /sbin/init
On Redhat based linux distributions :

$ rpm -qf $(which init)
upstart-0.6.5-16.el6.x86_64
~~~~

## Startup and shutdown process

By default, a SIGTERM is sent, followed by 90 seconds of waiting followed by a SIGKILL.

I recommend reading all of man systemd.kill as well as reading about ExecStop= in man systemd.service.


https://medium.com/@rainer_8955/gracefully-shutdown-c-apps-2e9711215f6d
https://docs.microsoft.com/en-us/dotnet/core/extensions/generic-host

## Common steps

### Create a user account for the service

### Create directories with least privilege

#### Data

#### Logs

https://docs.microsoft.com/en-us/dotnet/core/extensions/logging?tabs=command-line



## systemd-sysv 

Reference

https://www.freedesktop.org/software/systemd/man/systemd.service.html

Tutorial

https://medium.com/@benmorel/creating-a-linux-service-with-systemd-611b5c8b91d6


~~~~
[Unit]
Description=ROT13 demo service
After=network.target
StartLimitIntervalSec=0
[Service]
Type=simple
Restart=always
RestartSec=1
User=centos
ExecStart=/usr/bin/env php /path/to/server.php

[Install]
WantedBy=multi-user.target
~~~~



## upstart

