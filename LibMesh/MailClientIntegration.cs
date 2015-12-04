using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goedel.Mesh {

    public abstract class IntegratorMailClient {
        public MailClientCatalog Catalog;
        public abstract void EnumerateAccounts();
        }

    }
