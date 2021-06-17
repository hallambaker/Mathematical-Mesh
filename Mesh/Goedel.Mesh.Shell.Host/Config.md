# Configuring a new Mesh Service

These instructions describe the initial configuration of a Mesh service.

Note that since it is necessary to bring up the Mesh service and 
synchronize it to the callsign registry before the service can interpret 
callsigns correctly, initial configuration of the service requires the use
of a DNS name for bootstrapping purposes.

## Service Creation.

To create a new service and initialize the initial host, the serviceadmin tool
create command is used.

Alice creates the Mesh service for example.com with service configuration file
mesh_example_com.json to be administered by her existing account 
alice@safe.example.com
as follows:

~~~~
serviceadmin create mesh_example_com.json example.com  /admin=alice@safe.example.com
~~~~

The genesis command causes the following operations to be performed:

* If the configuration file exists, it is validated, if any errors are found, 
this is reported to the user and the operation aborted. Otherwise a new 
configuration file is created using the current directory as the base path.

* The directories for storage of the log files and data are created.

* Profile(s) are created for the Mesh Service and the initial host.

* A Mesh Profile is created for alice@example.com which is granted administrator
privileges for the service.

* The service configuration is updated to include the fingerprints of the service, 
host and administrator.

* The Mesh service configuration is written out to the service configuration 
catalog.

Note that creating the service does not cause it to start. 

### Genesis Service Creation.

Since Mesh services make use of the Mesh for user authentication, creation of
a Mesh service from scratch presents a bootstrap problem. A Mesh profile is 
required to configure the service, the service is required to create the profile.

To allow for this corner case, the create command automatically detects an
attempt to create a service with the administration account on the service itself.
This mode of service installation is called a 'genesis installation'. In
addition to initializing the Mesh service and host, the serviceadmin tool 
creates the administration profile and populate the configuration files of 
each appropriately.

To avoid this problem, Alice first created a separate service safe.example.com
which has exactly one user, Alice herself:

~~~~
serviceadmin create safe_example_com.json safe.example.com /admin=alice@safe.example.com
~~~~

## Starting, Pausing and Stopping the Service

To start the service, it is necessary to start the service host daemon meshhost

~~~~
meshhost mesh_example_com.json
~~~~

By default, the meshhost demon uses the host specification whose name is the 
machine name of the machine the command runs on. This can be overriden with the
/host option.

Once started, the mesh host demon can only be stopped by killing the process or by
sending the service an instruction using the serviceadmin tool.

To stop the host daemon on host1, Aliceissues the command:

~~~~
serviceadmin stop example.com host1 
~~~~

Once the daemon is stopped, it can only be restarted from the machine on which it
runs. To avoid this, Alice can pause service instead. The service can then be 
restarted using the start command:

~~~~
meshhost mesh_example_com.json
serviceadmin pause example.com host1 
serviceadmin start example.com host1 
~~~~

To start, stop or pause all the services in a multi-hosted service, the 
/all flag is used:

~~~~
serviceadmin stop example.com /all 
~~~~


## The service description file

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


## Configuration Update

The fetch command is used to fetch a copy of the current service configuration
for a specified service:

~~~~
serviceadmin fetch mesh_example_com.json example.com
~~~~

Changes to the service configuration can be pushed out to the service using the
update command. It is not necessary to specify the service because this is 
specified in the config file.

~~~~
serviceadmin update mesh_example_com.json
~~~~

[Note, the service configuration is not currently signed. This should be
required and the update command automatically sign the update. These should
then be stored in order so that it is possible to track changes. The fetch 
command should verify the signature and replace it with a comment stating
when it was fetched and verified.

Note that some configuration changes can take some time to make. Completion of
the update command only reports that the change has been accepted, not that
it was completed.


The verify command MAY be used to verify configuration changes before they are
committed:

~~~~
serviceadmin verify mesh_example_com.json
~~~~

Note that in a multi-host service, it is only necessary to issue the serviceadmin 
command on one host. The changes are automatically directed to the other 
hosts as a multi-stage commit:

1. The new configuration is sent to all the hosts providing the service.

2. The initiator confirms receipt of the new configuration at all the hosts.

3. If necessary, the DNS configuration is updated to reflect the transition 
configuration.

4. The initiator notifies hosts to begin the transition process

5. The initiator waits for the transition process to complete

6. If necessary, the DNS configuration is updated to reflect the final 
configuration.

7. The update is complete and a new change can be initiated.


### DNS Configuration

The serviceadmin tool can automatically generate a DNS configuration file for the
service from the service configuration using the dns command:

~~~~
serviceadmin dns mesh_example_com.json config.bind
~~~~

## Managing Hosts in a Multi-Host Service.


[This is SOOOO not yet implemented.]

### Add a Host


To add a new host to the service, the following commands are issued on the host
to be added:

1. Fetch the service configuration file.

2. Use the host daemon to configure the local host and add an entry to the service 
configuration file.

3. Edit the service configuration to make any additional configuration services
required.

4. Update the service configuration

~~~~
serviceadmin fetch mesh_example_com.json example.com
meshhost init mesh_example_com.json host2
serviceadmin update mesh_example_com.json
~~~~

If the service provides multiple protocols, these can be initialized at the same 
time. 

At this point, the host is ready to run but lacks the credential necessary to act
on behalf of the service. To do this, we use the serviceadmin tool to approve the
connection of the host to the service.

~~~~
serviceadmin fetch mesh_example_com.json example.com
serviceadmin credential host2
serviceadmin update mesh_example_com.json
~~~~

At this point, we can start the service on the new host:

~~~~
serviceadmin fetch mesh_example_com.json example.com
meshhost start mesh_example_com.json 
~~~



### Remove a Host

To remove a host, we simply remove it from the service configuration.
