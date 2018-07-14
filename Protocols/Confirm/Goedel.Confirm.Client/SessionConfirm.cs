using System;
using System.IO;
using System.Collections.Generic;
using Goedel.Utilities;
using Goedel.Mesh;
using Goedel.Mesh.Portal.Client;
using Goedel.Cryptography.Dare;

namespace Goedel.Confirm.Client {


    public static partial class Extension {

        public static SessionConfirm SessionConfirm (
            this SessionPersonal SessionPersonal,
            string UDF = null,
            string ShortId = null) {

            var Found = SessionPersonal.MeshMachine.Find(
                out var Result,
                "SessionConfirm",
                UDF: UDF,
                ShortId: ShortId);

            return Result as SessionConfirm;
            }

        public static SessionConfirm GetConfirm(
            this SessionPersonal SessionPersonal,
            string Identifier = null) => throw new NYI();

        }

    /// <summary>
    /// Manage a set of application sessions that are recryption sessions bound to
    /// a single personal session. This allows for methods such as 'get set of candidate keys'
    /// </summary>
    public partial class SessionConfirm : SessionApplication {

        public override ApplicationProfile ApplicationProfile => ConfirmProfile;
        public ConfirmProfile ConfirmProfile;


        /// <summary>
        /// Construct a SessionRecryption from a personal session.
        /// </summary>
        /// <param name="SessionPersonal">The personal session to construct from.</param>
        public SessionConfirm(
                    SessionPersonal SessionPersonal,
                    ConfirmProfile ConfirmProfile,
                    bool Write = true) : base(SessionPersonal, ConfirmProfile, Write) => this.ConfirmProfile = ConfirmProfile;



        public override void GetFromPortal() => throw new NotImplementedException();

        public override void MakeDefault() => throw new NotImplementedException();

        public EnquireResponse PostRequest(RequestEntry RequestEntry) => throw new NYI();

        public StatusResponse CheckStatus(EnquireResponse EnquireResponse) => throw new NYI();

        public StatusResponse CheckStatus(string BrokerID, bool Cancel) => throw new NYI();

        public PendingResponse CheckPending() => throw new NYI();

        }

    }
