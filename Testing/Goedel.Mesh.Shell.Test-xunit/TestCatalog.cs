using System;
using System.Collections.Generic;
using Xunit;
using Goedel.Mesh.Shell;
using Goedel.Cryptography;
using Goedel.Mesh.Test;
using Goedel.Test.Core;
using Goedel.Test;
using Goedel.Utilities;


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
            var account = "alice@example.com";

            var contact1UDF = UDF.Random(125);
            var contact2UDF = UDF.Random(125);
            var contact3UDF = UDF.Random(125);

            var contact1 = $"bob@@example.com.mm--{contact1UDF}";
            var contact2 = $"carol@@example.com.mm--{contact2UDF}";
            var contact3 = $"bob2@@example.com.mm--{contact3UDF}";

            CreateAccount(account);

            // Check that looking for a non existent entry fails
            // This makes sure that we don't end up picking up stale results from prior tests etc.
            FailContactResult(contact1);

            // Add a single entry and check that it is correctly registered.
            Dispatch($"contact add {contact1}");
            CheckContactResult(contact1);

            // Add a second entry, check that the first and second are correctly registered,
            Dispatch($"contact add {contact2}");
            CheckContactResult(contact1);
            CheckContactResult(contact2);

            // Delete the second entry, check that only the first is still there.
            Dispatch($"contact delete {contact2}");
            CheckContactResult(contact1);

            FailContactResult(contact2);
            // Update the first entry, check that it is correctly updated.
            Dispatch($"contact add {contact3}");
            CheckContactResult(contact3);

            FailContactResult(contact2);
            // Re-add the second entry, check that it is correctly registered.
            Dispatch($"contact add {contact2}");
            CheckContactResult(contact2);
            CheckContactResult(contact3);
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

        [Fact]
        public void TestProfileCalendar() {
            var account = "alice@example.com";

            string task1 = "task1", title1 = "title1", title1a = "title1a";
            string task2 = "task2", title2 = "title2";
            string title3 = "title3";

            CreateAccount(account);

            // Check that looking for a non existent entry fails
            // This makes sure that we don't end up picking up stale results from prior tests etc.
            FailTaskResult(task1);

            // Add a single entry and check that it is correctly registered.
            Dispatch($"calendar add {task1} {title1}");
            CheckTaskResult(task1, title1);

            // Add a second entry, check that the first and second are correctly registered,
            Dispatch($"calendar add {task2} {title2}");
            CheckTaskResult(task1, title1);
            CheckTaskResult(task2, title2);

            // Delete the second entry, check that only the first is still there.
            Dispatch($"calendar delete {task2}");
            CheckTaskResult(task1, title1);

            FailTaskResult(task2);
            // Update the first entry, check that it is correctly updated.
            Dispatch($"calendar add {task1} {title1a}");
            CheckTaskResult(task1, title1a);

            // Re-add the second entry, check that it is correctly registered.
            Dispatch($"calendar add {task2} {title3}");
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
