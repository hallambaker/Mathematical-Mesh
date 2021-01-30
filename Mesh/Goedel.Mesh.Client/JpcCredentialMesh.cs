using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Goedel.Protocol;
using Goedel.Utilities;
using Goedel.Mesh;

namespace Goedel.Mesh.Client {
    public class JpcCredentialMesh : JpcCredential {


        public JpcCredentialMesh(ProfileAccount profileAccount) : 
                    base(profileAccount.AccountAddress) {

            }

        public virtual JpcSession GetJpcSession(JpcConnection jpcConnection) =>
            jpcConnection switch {
                JpcConnection.Direct => new JpcSessionDirect(AccountAddress),
                JpcConnection.Serialized => GetSessionSerialized(this),
                JpcConnection.Http => GetSessionHttp(this),
                JpcConnection.Ticketed => GetSessionTicketed(this),
                _ => throw new NYI()
                };



        }
    }
