//using System;
//using System.Text;
//using System.Collections.Generic;
//using Goedel.Utilities;
//using Goedel.Account;
//using Goedel.Confirm;
//using Goedel.Recrypt;

//namespace Goedel.Combined.Shell.Client {

//    /// <summary>
//    /// 
//    /// </summary>
//    public partial class ResultBase {

//        public virtual void Display(IReporting Options = null) => Console.Write(ToString());

//        }

//    public partial class ResultPersonalCreate {

//        public override string ToString () {
//            var Buffer = new StringBuilder();

//            Buffer.Append($"Created new personal profile {PersonalProfile.UDF}\n");
//            Buffer.Append($"Profile registered to {PortalAccount}\n");

//            return Buffer.ToString();
//            }
//        }

//    public partial class ResultAccountCreate {

//        public override string ToString () {
//            var Buffer = new StringBuilder();

//            Buffer.Append($"Created account {AccountID}\n");

//            return Buffer.ToString();
//            }
//        }

//    public partial class ResultAccountDelete {

//        public override string ToString () {
//            var Buffer = new StringBuilder();

//            Buffer.Append($"Deleted account {AccountID}\n");

//            return Buffer.ToString();
//            }
//        }

//    public partial class ResultAccountUpdate {

//        public override string ToString () {
//            var Buffer = new StringBuilder();



//            return Buffer.ToString();
//            }
//        }

//    public partial class ResultAccountGet {
//        GetResponse GetResponse => Response as GetResponse;

//        public override string ToString () {
//            var AccountData = GetResponse.Data;
//            var Buffer = new StringBuilder();

//            Buffer.Append($" {AccountData.AccountID}\n");
//            Buffer.Append($" {AccountData.Created}\n");
//            Buffer.Append($" {AccountData.Status}\n");
//            Buffer.Append($" {AccountData.MeshUDF}\n");
//            Buffer.Append($" {AccountData.Portal}\n");

//            foreach (var Entry in AccountData.Profiles) {
//                //Buffer.Append($" {AccountData.}\n");
//                //Buffer.Append($" {AccountData.}\n");
//                }

//            return Buffer.ToString();
//            }
//        }

//    public partial class ResultConfirmPost {
//        EnquireResponse EnquireResponse => Response as EnquireResponse;

//        public override string ToString () {
//            var Buffer = new StringBuilder();

//            Buffer.Append($" {EnquireResponse.BrokerID}\n");

//            return Buffer.ToString();
//            }
//        }

//    public partial class ResultConfirmStatus {
//        StatusResponse StatusResponse => Response as StatusResponse;
//        public override string ToString () {
//            var ResponseEntry = StatusResponse.Response;
//            var Buffer = new StringBuilder();

//            if (ResponseEntry == null) {
//                Buffer.Append($"Unknown\n");
//                }
//            else {
//                Buffer.Append($"{ResponseEntry.RequestStatus}\n");
//                }

//            return Buffer.ToString();
//            }
//        }

//    public partial class ResultConfirmPending {
//        PendingResponse PendingResponse => Response as PendingResponse;
//        public override string ToString () {
//            var Buffer = new StringBuilder();

//            if (PendingResponse.Entries == null || PendingResponse.Entries.Count == 0) {
//                Buffer.Append($"None\n");
//                }
//            else {
//                foreach (var Entry in PendingResponse.Entries) {
//                    var Request = TBSRequest.FromJSON(Entry.Request.JSONReader);
//                    Buffer.Append($"Account: {Entry.BrokerID}\n");
//                    Buffer.Append($"    From:    {Request.FromID}\n");
//                    Buffer.Append($"    To:      {Request.ToID}\n");
//                    Buffer.Append($"    Expires: {Entry.Expire}\n");
//                    Buffer.Append($"    Message: {Request.Text}\n");
//                    Buffer.Append("\n");
//                    }
//                }

//            return Buffer.ToString();
//            }
//        }

//    public partial class ResultConfirmRespond {

//        public override string ToString () {
//            var Buffer = new StringBuilder();



//            return Buffer.ToString();
//            }
//        }


//    public partial class ResultCreateGroup {

//        public override string ToString () {
//            var Buffer = new StringBuilder();



//            return Buffer.ToString();
//            }
//        }

//    public partial class ResultRecryptAdd {

//        public override string ToString () {
//            var Buffer = new StringBuilder();



//            return Buffer.ToString();
//            }
//        }
//    public partial class ResultEncrypt {

//        public override string ToString () {
//            var Buffer = new StringBuilder();



//            return Buffer.ToString();
//            }
//        }
//    public partial class ResultDecrypt {

//        public override string ToString () {
//            var Buffer = new StringBuilder();



//            return Buffer.ToString();
//            }
//        }




//    }
