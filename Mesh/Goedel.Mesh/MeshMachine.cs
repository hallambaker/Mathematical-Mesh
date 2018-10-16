using System;
using System.Collections.Generic;
using System.Text;
using Goedel.Cryptography;

namespace Goedel.Mesh {


    public static class MeshMachine {
        public static IMeshMachine Default;

        }

    public interface IMeshMachine {

        KeyCollection KeyCollection { get; }




        void Register(ProfileDevice Device);
        void Register(ProfileMaster Device);
        void Register(ProfileApplication Device);


        }

    }
