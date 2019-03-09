using System;
using System.Collections.Generic;
using Goedel.Mesh.Shell;

namespace MakeSiteDocs {
    public class CreateWeb {

        static void Main(string[] args) {
            Console.WriteLine("Hello World");
            var createWeb = new CreateWeb();
            }

        public CreateWeb() {

            var makeSiteDocs = new MakeSiteDocs();
            makeSiteDocs.WebDocs(this);

            _ProfileHello._DescribeCommand.Describe('/');
            }


        }
    }
