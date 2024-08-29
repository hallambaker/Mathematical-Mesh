namespace Goedel.Mesh.ServiceAdmin;

/// <summary>
/// Service/Host configuration.
/// </summary>
public class Configuration : Disposable {

    ///<summary>Maps configuration entry to configuration.</summary> 
    public Dictionary<string, object> Dictionary = new();

    ///<summary>The logger service configuration.</summary> 
    public DareLoggerConfiguration DareLogger { get; set; }

    ///<summary>The host configuration.</summary> 
    public GenericHostConfiguration GenericHost { get; set; }

    ///<summary>The Mesh service configuration.</summary> 
    public MeshServiceConfiguration MeshService { get; set; }

    ///<summary>The Mesh service configuration.</summary> 
    public CallsignRegistryConfiguration CallsignRegistry { get; set; }

    ///<summary>The Mesh service configuration.</summary> 
    public CallsignResolverConfiguration CallsignResolver { get; set; }

    ///<summary>The Mesh service configuration.</summary> 
    public CarnetServiceConfiguration CarnetService { get; set; }
    ///<summary>The Mesh service configuration.</summary> 
    public RepositoryServiceConfiguration RepositoryService { get; set; }

    ///<summary>The Mesh service configuration.</summary> 
    public PresenceServiceConfiguration PresenceService { get; set; }


    JsonDocument JsonDocument { get; init; }

    /// <summary>
    /// Default constructor.
    /// </summary>
    public Configuration() {
        }

    ///<inheritdoc/>
    protected override void Disposing() {
        JsonDocument?.Dispose();
        }

    /// <summary>
    /// Read configuration from a file.
    /// </summary>
    /// <param name="path">The file name.</param>
    /// <returns>The parsed configuration.</returns>
    public static Configuration FromFile(string path) {
        using var stream = path.OpenFileReadShared();

        var config = new Configuration();
        var dom = JsonDocument.Parse(stream);

        var result = new Configuration() {
            JsonDocument = dom
            };

        result.DareLogger = result.Get<DareLoggerConfiguration>(DareLoggerConfiguration.ConfigurationEntry);
        result.GenericHost = result.Get<GenericHostConfiguration>(GenericHostConfiguration.ConfigurationEntry);
        result.MeshService = result.Get<MeshServiceConfiguration>(MeshServiceConfiguration.ConfigurationEntry);

        result.CallsignRegistry = result.Get<CallsignRegistryConfiguration>(CallsignRegistryConfiguration.ConfigurationEntry);
        result.CallsignResolver = result.Get<CallsignResolverConfiguration>(CallsignResolverConfiguration.ConfigurationEntry);
        result.CarnetService = result.Get<CarnetServiceConfiguration>(CarnetServiceConfiguration.ConfigurationEntry);
        result.RepositoryService = result.Get<RepositoryServiceConfiguration>(RepositoryServiceConfiguration.ConfigurationEntry);
        result.PresenceService = result.Get<PresenceServiceConfiguration>(PresenceServiceConfiguration.ConfigurationEntry);

        return result;
        }

    /// <summary>
    /// Get configuration entry described by <paramref name="configurationEntry"/>.
    /// </summary>
    /// <typeparam name="T">The returned type.</typeparam>
    /// <param name="configurationEntry">The configuration description.</param>
    /// <returns>The parsed configuration.</returns>
    public T Get<T>(ConfigurationEntry configurationEntry) where T : class {
        foreach (var entry in JsonDocument.RootElement.EnumerateObject()) {
            if (entry.Name == configurationEntry.Name) {
                var x = JsonSerializer.Deserialize(entry.Value, configurationEntry.Type);
                return x as T;
                }
            }
        return null;
        }

    /// <summary>
    /// Add a configuration entry to the configuration.
    /// </summary>
    /// <param name="entry">The entry.</param>
    /// 
    public void Add(IConfigurationEntry entry) {

        var configurationEntry = entry.GetConfigurationEntry();

        Dictionary.Add(configurationEntry.Name, entry);

        switch (entry) {
            case DareLoggerConfiguration dareLogger: {
                DareLogger = dareLogger;
                break;
                }
            case GenericHostConfiguration genericHost: {
                GenericHost = genericHost;
                break;
                }
            case MeshServiceConfiguration meshService: {
                MeshService = meshService;
                break;
                }
            case CallsignRegistryConfiguration callsignRegistry: {
                CallsignRegistry = callsignRegistry;
                break;
                }
            case CallsignResolverConfiguration callsignResolver: {
                CallsignResolver = callsignResolver;
                break;
                }
            case CarnetServiceConfiguration carnetService: {
                CarnetService = carnetService;
                break;
                }
            case RepositoryServiceConfiguration repositoryService: {
                RepositoryService = repositoryService;
                break;
                }
            case PresenceServiceConfiguration presenceService: {
                PresenceService = presenceService;
                break;
                }
            }
        }

    /// <summary>
    /// Write configuration to file.
    /// </summary>
    /// <param name="path">The output filename.</param>
    public void ToFile(string path) {
        using var stream = path.OpenFileNew();

        var jsonOptions = new JsonSerializerOptions() {
            WriteIndented = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            //Converters = {
            //    new JsonStringEnumConverter (JsonNamingPolicy.CamelCase, true)
            //    }
            };

        ////Console.WriteLine(JsonSerializer.Serialize<Dictionary<string, object>>(Dictionary, jsonOptions));
        JsonSerializer.Serialize(stream, Dictionary, jsonOptions);
        }



    }
