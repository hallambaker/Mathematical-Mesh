using System.Collections.Generic;

using Goedel.Mesh.Test;

namespace ExampleGenerator {
    public class ShellAccount : ExampleSet {
        public List<ExampleResult> ConnectRequest;
        public List<ExampleResult> ConnectRequestMallet;
        public List<ExampleResult> ConnectPending;
        public List<ExampleResult> ConnectAccept;
        public List<ExampleResult> ConnectSync;
        public List<ExampleResult> ConnectPending2;
        public List<ExampleResult> ConnectReject;
        public List<ExampleResult> ConnectGetPin;
        public List<ExampleResult> ConnectPin;
        public List<ExampleResult> ConnectSyncPIN;
        public List<ExampleResult> ConnectPending3;

        public List<ExampleResult> ConnectEarlPrep;

        public List<ExampleResult> ConnectList;
        public List<ExampleResult> ConnectDelete;

        public List<ExampleResult> DeviceEarl1;
        public List<ExampleResult> DeviceEarl2;
        public List<ExampleResult> DeviceEarl3;
        public List<ExampleResult> DeviceEarl4;

        public List<ExampleResult> DeviceCreate;
        public string DeviceCreateUDF;
        public string DeviceCreateHTTP;


        public ShellAccount(CreateExamples createExamples) :
                base(createExamples) {

            }
        }
    }
