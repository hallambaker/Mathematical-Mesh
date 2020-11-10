﻿using Goedel.Cryptography;
using Goedel.Mesh;
using Goedel.Mesh.Shell;

using Xunit;


namespace Goedel.XUnit {
    public partial class ShellTests {
        /// <summary>
        /// Basic check on the password catalog lifecycle. A new account is created, passwords
        /// are added, updated and deleted with checks to ensure each operation completes 
        /// correctly.
        /// </summary>
        [Fact]
        public void TestProfilePassword() {
            var account = "alice@example.com";
            var site1 = "example.com"; var username1 = "alice1"; var password1 = "password1";
            var site2 = "example.net"; var username2 = "alice2"; var password2 = "password2";
            var username3 = "alice3"; var password3 = "password3";
            var username4 = "alice4"; var password4 = "password4";

            CreateAccount(account);

            // Check that looking for a non existent entry fails
            // This makes sure that we don't end up picking up stale results from prior tests etc.
            FailPasswordResult(site1);

            // Add a single entry and check that it is correctly registered.
            Dispatch($"password add  {site1} {username1} {password1}");
            CheckPasswordResult(site1, username1, password1);

            // Add a second entry, check that the first and second are correctly registered,
            Dispatch($"password add  {site2} {username2}  {password2}");
            CheckPasswordResult(site1, username1, password1);
            CheckPasswordResult(site2, username2, password2);

            // Delete the second entry, check that only the first is still there.
            Dispatch($"password delete {site2}");
            CheckPasswordResult(site1, username1, password1);
            FailPasswordResult(site2);

            // Update the first entry, check that it is correctly updated.
            Dispatch($"password add {site1} {username3}  {password3}");
            CheckPasswordResult(site1, username3, password3);
            FailPasswordResult(site2);

            // Re-add the second entry, check that it is correctly registered.
            Dispatch($"password add {site2} {username4} {password4}");
            CheckPasswordResult(site1, username3, password3);
            CheckPasswordResult(site2, username4, password4);
            }


        [Fact]
        public void TestProfileContact() {

            var device1 = GetTestCLI("Device1");
            var device2 = GetTestCLI("Device2");
            var device3 = GetTestCLI("Device3");

            var fileA = $"Contact-{AliceAccount}.mcf";
            var fileB = $"Contact-{AccountB}.mcf";
            var fileC = $"Contact-{AccountC}.mcf";

            // rewrite this test so that we create three accounts, export the contact self values
            // then test import into the catalog from the file.

            // create the accounts
            device1.Dispatch($"account create {AliceAccount}");
            device2.Dispatch($"account create {AccountB}");
            device3.Dispatch($"account create {AccountC}");

            // Check each account has exactly the right set of contacts (i.e. self):
            ValidContact(device1, AliceAccount);
            ValidContact(device2, AccountB);
            ValidContact(device3, AccountC);


            // export the contact data to a file
            device1.Dispatch($"contact export {AliceAccount} {fileA}");
            device2.Dispatch($"contact export {AccountB} {fileB}");
            device3.Dispatch($"contact export {AccountC} {fileC}");

            // Add a single entry and check that it is correctly registered.
            var contactID1 = GetContactKey(device1.Dispatch($"contact add {fileB}"));
            ValidContact(device1, AliceAccount, AccountB);
            ValidContact(device2, AccountB);
            ValidContact(device3, AccountC);

            // Add a second entry, check that the first and second are correctly registered,
            var contactID2 = GetContactKey(device1.Dispatch($"contact add {fileC}"));
            ValidContact(device1, AliceAccount, AccountB, AccountC);
            ValidContact(device2, AccountB);
            ValidContact(device3, AccountC);


            // Delete the second entry, check that only the first is still there.
            device1.Dispatch($"contact delete {AccountB}");
            ValidContact(device1, AliceAccount, AccountC);
            ValidContact(device2, AccountB);
            ValidContact(device3, AccountC);

            // Add it back and check
            var contactID3 = GetContactKey(device1.Dispatch($"contact add {fileB}"));
            ValidContact(device1, AliceAccount, AccountB, AccountC);
            ValidContact(device2, AccountB);
            ValidContact(device3, AccountC);
            }


        [Fact]
        public void TestProfileBookmark() {
            var account = "alice@example.com";

            string uri1 = "http://www.site1.com", title1 = "site1", path1 = "Sites.1";
            string uri2 = "http://www.site2.com", title2 = "site2", path2 = "Sites.2";
            string uri3 = "http://www.site3.com", title3 = "site3", path3 = "Sites.3";

            CreateAccount(account);

            // Check that looking for a non existent entry fails
            // This makes sure that we don't end up picking up stale results from prior tests etc.
            FailBookmarkResult(path1);

            // Add a single entry and check that it is correctly registered.
            Dispatch($"bookmark add {path1} {uri1} {title1}");
            CheckBookmarkResult(path1, uri1, title1);

            // Add a second entry, check that the first and second are correctly registered,
            Dispatch($"bookmark add {path2} {uri2} {title2}");
            CheckBookmarkResult(path1, uri1, title1);
            CheckBookmarkResult(path2, uri2, title2);

            // Delete the second entry, check that only the first is still there.
            Dispatch($"bookmark delete {path2}");
            CheckBookmarkResult(path1, uri1, title1);

            FailBookmarkResult(path2);
            // Update the first entry, check that it is correctly updated.
            Dispatch($"bookmark add {path3} {uri3} {title3}");
            CheckBookmarkResult(path3, uri3, title3);

            // Re-add the second entry, check that it is correctly registered.
            Dispatch($"bookmark add {path2} {uri2} {title2}");
            CheckBookmarkResult(path2, uri2, title2);
            CheckBookmarkResult(path3, uri3, title3);
            }

        string GetTaskKey(ShellResult result) =>
            ((result as ResultEntry).CatalogEntry as CatalogedTask).Key;
        string GetContactKey(ShellResult result) =>
            ((result as ResultEntry).CatalogEntry as CatalogedContact).Key;


        [Fact]
        public void TestProfileCalendar() {
            var account = "alice@example.com";

            string title1 = "title1", title1a = "title1a";
            string title2 = "title2";
            string title3 = "title3";

            CreateAccount(account);

            // Check that looking for a non existent entry fails
            // This makes sure that we don't end up picking up stale results from prior tests etc.
            FailTaskResult("NYI");

            // Add a single entry and check that it is correctly registered.
            var result1 = Dispatch($"calendar add {title1}");
            var task1 = GetTaskKey(result1);

            CheckTaskResult(task1, title1);

            // Add a second entry, check that the first and second are correctly registered,
            var result2 = Dispatch($"calendar add {title2}");
            var task2 = GetTaskKey(result2);

            CheckTaskResult(task1, title1);
            CheckTaskResult(task2, title2);

            // Delete the second entry, check that only the first is still there.
            Dispatch($"calendar delete {task2}");
            CheckTaskResult(task1, title1);

            FailTaskResult(task2);
            // Update the first entry, check that it is correctly updated.
            Dispatch($"calendar add {title1a} /id={task1} ");
            CheckTaskResult(task1, title1a);

            // Re-add the second entry, check that it is correctly registered.
            Dispatch($"calendar add  {title3} /id={task2} ");
            CheckTaskResult(task2, title3);
            CheckTaskResult(task1, title1a);
            }


        [Fact]
        public void TestProfileNetwork() {
            var account = "alice@example.com";
            string ssid1 = "ssid1", password1 = "password1", password1a = "password1a";
            string ssid2 = "ssid2", password2 = "password2";

            CreateAccount(account);

            // Check that looking for a non existent entry fails
            // This makes sure that we don't end up picking up stale results from prior tests etc.
            FailNetworkResult(ssid1);

            // Add a single entry and check that it is correctly registered.
            Dispatch($"network add {ssid1} {password1}");
            CheckNetworkResult(ssid1, password1);

            // Add a second entry, check that the first and second are correctly registered,
            Dispatch($"network add {ssid2} {password2}");
            CheckNetworkResult(ssid1, password1);
            CheckNetworkResult(ssid2, password2);

            // Delete the second entry, check that only the first is still there.
            Dispatch($"network delete {ssid2}");
            CheckNetworkResult(ssid1, password1);

            FailNetworkResult(ssid2);
            // Update the first entry, check that it is correctly updated.
            Dispatch($"network add {ssid1} {password1a}");
            CheckNetworkResult(ssid1, password1a);

            // Re-add the second entry, check that it is correctly registered.
            Dispatch($"network add {ssid2} {password2}");
            CheckNetworkResult(ssid2, password2);
            CheckNetworkResult(ssid1, password1a);

            }
        }
    }
