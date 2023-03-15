using Goedel.Cryptography.Dare;
using Goedel.Mesh;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goedel.Callsign.Resolver;
public partial class ResolverResponse {

    public ResolverResponse(int status = 202) {
        Status = status;

        }


    }


public partial class QueryResponse {

    public QueryResponse() {
        }

    public QueryResponse(Enveloped<Registration> result) {
        Result = result;
        Status = result == null ? 404 : 201;
        if (result != null) {
            Status = 200;
            }
        else {
            Status = 400 ;
            StatusDescriptionCode = MeshConstants.MeshServerStatusNotFoundTag;
            StatusExtended = (int)MeshServerStatus.NotFound;
            }
        }


    }
