using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goedel.Carnet;


/// <summary>
/// Extensions class. Provides static convenience extensions.
/// </summary>
public static class Extensions {

    ///// <summary>
    ///// Create a registry account under the name <paramref name="accountAddress"/> 
    ///// </summary>
    ///// <param name="contextUser"></param>
    ///// <param name="accountAddress"></param>
    ///// <returns></returns>
    ///// <exception cref="NYI"></exception>
    //public static ContextCarnet CreateCarnet(this ContextUser contextUser, string accountAddress) =>
    //    ContextCarnet.Create(contextUser, accountAddress);
    //}


    public static int Spend(this ContextUser contextUser, int amount) {
        throw new NotImplementedException();
        }


    }
