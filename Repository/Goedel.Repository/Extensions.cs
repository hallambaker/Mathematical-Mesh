using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goedel.Repository;
/// <summary>
/// Extensions class. Provides static convenience extensions.
/// </summary>
public static class Extensions {

    /// <summary>
    /// Register the repository service <paramref name="repositoryServer"/> under the
    /// user contect <paramref name="contextUser"/>.
    /// </summary>
    /// <param name="contextUser">The user context.</param>
    /// <param name="repositoryServer">The repository service</param>
    /// <returns>The corresponding repository context.</returns>
    /// <exception cref="NotImplementedException"></exception>
    public static ContextRepository Register(this ContextUser contextUser, RepositoryService repositoryServer) {
        throw new NotImplementedException();
        }

    /// <summary>
    /// Publish <paramref name="data"/> to the context <paramref name="contextUser"/>
    /// </summary>
    /// <param name="contextUser">The repository context.</param>
    /// <param name="data">The data to publish.</param>
    /// <returns>The publication message.</returns>
    /// <exception cref="NotImplementedException"></exception>
    public static Message Publish(this ContextRepository contextUser, byte[] data) {
        throw new NotImplementedException();
        }

    }
