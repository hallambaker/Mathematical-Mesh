using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Goedel.Utilities;
using Goedel.Protocol;
namespace Goedel.Mesh.Server {

    /// <summary>
    /// Host session.
    /// </summary>
    public class JpcSessionHost : JpcSession {

        /// <summary>
        /// Default constructor.
        /// </summary>
        public JpcSessionHost() : base("nobody@example.com") {
            }

        public override IJpcSession Rebind(string accountAddress) => throw new NotImplementedException();
        }
    }
