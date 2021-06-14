# Configuring a new Mesh Service

These instructions describe the initial configuration of a Mesh service.

Note that since it is necessary to bring up the Mesh service and 
synchronize it to the callsign registry before the service can interpret 
callsigns correctly, initial configuration of the service requires the use
of a DNS name for bootstrapping purposes.

## Create initial service description.

The first step is to create the base service configuration file, this 
MUST contain one service and one host.

The active service configuration file ALWAYS has the file name 'serviceconfig.json'.

The service descrption specifies the protocols to be serviced, the DNS and
callsigns by which the service may be discovered and the identifiers of the 
hosts that are to provide that service:

~~~~
{
	"Service": {
		"Id": "MathMesh",
		"Description": "Example Mesh service config on one host",
		"Hosts": [ "Voodoo" ],
		"Protocol": "mmm",
		"Addresses": [ "example.com"],
	}
}
~~~~

If the administrator has already created a Mesh account serviced by an
existing Mesh service, this may be specified by means of an administrator property
specifying a Strong Internet Name for the account. [NYI]

The host description specifies the host identifier and basic configuration
information including:

* The role (at least one host MUST have the fixed role)

* The IP address(es) through which service is to be provided on that host

* Destinations to which local and remote log entries are to be sent.

* Relative priority values to be used to assign work to this host according
  to storage and load capacities.

~~~~
{
	"Host": {
		"Id": "Voodoo",
		"Description": "The host to run the service",
		"Role": ["Fixed"],
		"Directory": "Data/Mesh",
		"IP": [ "192.168.1.21:9999", "10.1.2.3:9998" ],
		"Log": [
			{
			    "Directory": "Log/Mesh",	
			    "File": "errors.log",
				"Event": [ "Error" ],
				"Roll": "1d"
			}
		],
		"Remote": [
			{
				"Uri": "mlog:offsite.example.com",
				"Event": [ "Append" ],
				"Roll": "1d"
			}
		],
		"Storage": 100,
		"Load": 100
	}
}
~~~~

## Initilize the service

The serviceadmin tool is used to initialize the service. Since we do not have a 
mesh profile ourselves yet, one is created using the /admin option.

~~~~
serviceadmin init /admin=alice@example.com
~~~~

The init command causes the following operations to be performed:

* The configuration file is validated, if any errors are found, this is reported to
the user and the operation aborted.

* The directories for storage of the log files and data directories are created.

* Profile(s) are created for the Mesh Service and the initial host.

* A Mesh Profile is created for alice@example.com which is granted administrator
privileges for the service.

* The service configuration is updated to include the fingerprints of the service, 
host and administrator.

* The Mesh service configuration is written out to the service configuration 
catalog.

Every time the service configuration is updated, the following steps are
performed:

* The old serviceconfig.json is renamed to serviceconfig-yyyy-mm-dd:HH:MM:SS.json

* A new serviceconfig.json is created and populated with the new data values.

* A host configuration file is created for the current host and written to
hostconfig.json

* If the DNS parameters have been changed, a new DNS zone file is created with 
the new service settings.

* The configuration for

Note that the function of the server configuration file is to provide a convenient
means of reviewing and editing the service configuration. The canonical source
of the service configuration is the catalog.

## Start the service

The serviceadmin tool is used to configure the service, it is not the service itself. 
We start the service on the current host using the meshhost command:

~~~~
meshhost hostconfig.json
~~~~

Hosts are always brought up in the paused state. To start the service the
serviceadmin tool is used:

~~~~
serviceadmin start
~~~~

## Stop the service

The service is stopped using the serviceadmin tool. 

~~~~
serviceadmin stop
~~~~

## Pause the service

The pausing the service causes it to refuse all commands except for administration 
commands.

~~~~
serviceadmin pause
~~~~



## Change the server configuration

To change the service configuration, we edit the serviceconfig.json file and 
tell the service to use the new configuration using the serviceadmin tool

~~~~
serviceadmin update
~~~~

Note that in a multi-host service, it is only necessary to issue the serviceadmin 
command on the host where the serviceconfig.json has been updated. The changes 
are automatically directed to the other hosts as a multi-stage commit:

1. The new configuration is sent to all the hosts providing the service.

2. The initiator confirms receipt of the new configuration at all the hosts.

3. If necessary, the DNS configuration is updated to reflect the transition 
configuration.

4. The initiator notifies hosts to begin the transition process

5. The initiator waits for the transition process to complete

6. If necessary, the DNS configuration is updated to reflect the final 
configuration.

7. The update is complete and a new change can be initiated.

## Add a Host

[This is SOOOO not yet implemented.]

To add a new host to the service, an administrator uses their Mesh profile 
credential to authenticate the request:

A hostconfig.json file containing the configuration parameters for the new host
is created. This must at minimum speficy the identifier for the host:

~~~~
serviceadmin add mathmesh.com hostconfig.json
~~~~

By default, new hosts are added with Storage and Load factors of zero so that no
tasks will be transfered to them until after the correct configuration of the
new host have been verified.

## Remove a Host

To remove a host, we merely specify the host to be removed

~~~~
meshman remove voodoo
~~~~

The time taken to remove a host depends on the role the host is acting in. If the 
host is merely acting as a cache to take load off another machine, removal can 
take effect as soon as the discovery tables have been updated to direct traffic back
to the original. If the host is a primary or secondary repository for active
accounts, the removal cannot take effect until these responsibilities have been
transfered to other machines.


## Change Host Priorities

It is possible to change the role and priority settings for individual hosts remotely

~~~~
meshman config voodoo /store=100 /load=100 /role=fixed
~~~~



## Change Account properties

The serviceadmin tool is also used to modify account settings. Note that this is
only possible when the service is running. 


