using Goedel.Mesh;
using Goedel.Mesh.Shell;
using Goedel.Mesh.Test;
using Goedel.Utilities;
using Goedel.IO;
using System;
using System.Collections.Generic;

namespace ExampleGenerator {
    public static class Extensions {

        public static ResultPending GetResultPending(
                    this List<ExampleResult> Results,
                    int index = 0) => GetResult(Results, index) as ResultPending;
        public static ResultSent GetResultSent(
            this List<ExampleResult> Results,
            int index = 0) => GetResult(Results, index) as ResultSent;
        public static ResultEscrow GetResultEscrow(
            this List<ExampleResult> Results,
            int index = 0) => GetResult(Results, index) as ResultEscrow;
        public static ResultCreateAccount GetResultCreateAccount(
            this List<ExampleResult> Results,
            int index = 0) => GetResult(Results, index) as ResultCreateAccount;
        public static ResultHello GetResultHello(
            this List<ExampleResult> Results,
            int index = 0) => GetResult(Results, index) as ResultHello;
        public static ResultPIN GetResultPIN(
            this List<ExampleResult> Results,
            int index = 0) => GetResult(Results, index) as ResultPIN;
        public static ResultPublishDevice GetResultPublishDevice(
            this List<ExampleResult> Results,
            int index = 0) => GetResult(Results, index) as ResultPublishDevice;
        public static ResultConnect GetResultConnect(
            this List<ExampleResult> Results,
            int index = 0) => GetResult(Results, index) as ResultConnect;


        public static ResultEntry GetResultEntry(
            this List<ExampleResult> Results,
            int index = 0) => GetResult(Results, index) as ResultEntry;

        public static ResultDump GetResultDump(
            this List<ExampleResult> Results,
            int index = 0) => GetResult(Results, index) as ResultDump;
        public static Result GetResult (
            this List<ExampleResult> Results,
            int index = 0) {

            if (Results == null || index >= Results.Count) {
                return null;
                }

            return Results[index].Result;


            }


        }
    }
