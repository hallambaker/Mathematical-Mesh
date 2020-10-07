//  Copyright © 2020 Threshold Secrets llc
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.

using Goedel.Cryptography;
using System;

namespace Goedel.Mesh {

   


    /////<summary>Enumeration for Key types</summary>
    //public enum MeshKeyType {

    //    ///<summary>Mask to recover seed type</summary>
    //    IndexSeedType = 0x10,

    //    ///<summary>Mask to recover seed type</summary>
    //    MaskSeedType = 0xF * IndexSeedType,

    //    ///<summary>Mask to recover seed type</summary>
    //    MaskKeyUse = 0x0F,


    //    // ** Key uses
    //    ///<summary>offline signature</summary>
    //    RootSign = 0x00,

    //    ///<summary>Master profile online signature</summary>
    //    AdminSign = 0x01,

    //    ///<summary>Master profile online signature</summary>
    //    Sign = 0x03,

    //    ///<summary>Encryption</summary>
    //    Encrypt = 0x04,

    //    ///<summary>Master profile authentication</summary>
    //    Authenticate = 0x05,

    //    ///<summary>Master profile authentication</summary>
    //    PartialUser = 0x06,

    //    ///<summary>Master profile authentication</summary>
    //    PartialService = 0x07,




    //    // ** Device Profile
    //    ///<summary>Master profile offline signature</summary>
    //    DeviceProfile = IndexSeedType * 2,

    //    ///<summary>Master profile offline signature</summary>
    //    DeviceSign = DeviceProfile + RootSign,


    //    ///<summary>Master profile encryption</summary>
    //    DeviceEncrypt = DeviceProfile + Encrypt,

    //    ///<summary>Master profile authentication</summary>
    //    DeviceAuthenticate = DeviceProfile + Authenticate,


    //    // ** Account Profile
    //    ///<summary>Master profile offline signature</summary>
    //    UserProfile = IndexSeedType * 3,

    //    ///<summary>Master profile offline signature</summary>
    //    UserRootSign = UserProfile + RootSign,

    //    ///<summary>Master profile offline signature</summary>
    //    UserAdminSign = UserProfile + AdminSign,
        
    //    ///<summary>Master profile offline signature</summary>
    //    UserSign = UserProfile + Sign,

    //    ///<summary>Master profile encryption</summary>
    //    UserEncrypt = UserProfile + Encrypt,

    //    ///<summary>Master profile authentication</summary>
    //    UserAuthenticate = UserProfile + Authenticate,


    //    // ** Group Profile
    //    ///<summary>Master profile offline signature</summary>
    //    GroupProfile = IndexSeedType * 4,

    //    ///<summary>Master profile offline signature</summary>
    //    GroupSign = GroupProfile + RootSign,

    //    ///<summary>Master profile encryption</summary>
    //    GroupEncrypt = GroupProfile + Encrypt,

    //    ///<summary>Master profile authentication</summary>
    //    GroupAuthenticate = GroupProfile + Authenticate,

    //    ///<summary>Master profile authentication</summary>
    //    GroupUser = GroupProfile + PartialUser,

    //    ///<summary>Master profile authentication</summary>
    //    GroupService = GroupProfile + PartialService,


    //    // ** Service Profile
    //    ///<summary>Master profile offline signature</summary>
    //    ServiceProfile = IndexSeedType * 5,

    //    ///<summary>Master profile offline signature</summary>
    //    ServiceSign = ServiceProfile + RootSign,

    //    ///<summary>Master profile encryption</summary>
    //    ServiceEncrypt = ServiceProfile + Encrypt,

    //    ///<summary>Master profile authentication</summary>
    //    ServiceAuthenticate = ServiceProfile + Authenticate,

    //    }

    /// <summary>
    /// Status values for Mesh Messages
    /// </summary>
    public enum MessageStatus {



        ///<summary>Message is unread.</summary>
        Unread = 0b1,

        ///<summary>Message has been read.</summary>
        Read = 0b10,

        ///<summary>Message has expired</summary>
        Unexpired = 0b100,

        ///<summary>Message has expired</summary>
        Expired = 0b1000,

        ///<summary>Message is open.</summary>
        Open = 0b1_0000,

        ///<summary>Message is closed.</summary>
        Closed = 0b10_0000,


        ///<summary>Initial Message Status</summary>
        Initial = Unread | Open,

        ///<summary>Initial Message Status</summary>
        Active = Unexpired | Open,


        ///<summary>All messages.</summary>
        All = 0b11_1111,

        ///<summary>No messages.</summary>
        None = 0b00_0000,

        }

    /// <summary>
    /// Collected constants used in the Mathematical Mesh
    /// </summary>
    public static partial class MeshConstants {
        // Constants for calculating timeout values.

        ///<summary>Number of ticks in a millisecond</summary>
        public const long MillisecondInTicks = 10_000;
        ///<summary>Number of ticks in a second</summary>
        public const long SecondInTicks = 1000 * MillisecondInTicks;
        ///<summary>Number of ticks in a minute</summary>
        public const long MinuteInTicks = 60 * SecondInTicks;
        ///<summary>Number of ticks in a hour</summary>
        public const long HourInTicks = 60 * MinuteInTicks;
        ///<summary>Number of ticks in a day</summary>
        public const long DayInTicks = 24 * HourInTicks;
        ///<summary>Number of ticks in a week</summary>
        public const long WeekInTicks = 7 * DayInTicks;
        ///<summary>Number of ticks in a year</summary>
        public const long YearInTicks = 365 * DayInTicks;


        // Constants used in conjunction with UDF derived keys.

        ///<summary>Default master seed size in bits.</summary>
        public const int DefaultMasterKeyBits = 256;


        // CryptoAlgorithmID related constants and convenience functions

        ///<summary>The default encryption algorithm</summary>
        public const CryptoAlgorithmId DefaultAlgorithmEncryptID = CryptoAlgorithmId.X448;
        ///<summary>The default signature algorithm</summary>
        public const CryptoAlgorithmId DefaultAlgorithmSignID = CryptoAlgorithmId.Ed448;
        ///<summary>The default authentication algorithm</summary>
        public const CryptoAlgorithmId DefaultAlgorithmAuthenticateID = CryptoAlgorithmId.X448;

        /// <summary>
        /// Convenience function that returns the value <see cref="DefaultAlgorithmEncryptID"/> if
        /// <paramref name="cryptoAlgorithmID"/> is <see cref="CryptoAlgorithmId.Default"/> 
        /// and <paramref name="cryptoAlgorithmID"/>
        /// otherwise.
        /// </summary>
        /// <param name="cryptoAlgorithmID">The CryptoAlgorithmID to default.</param>
        /// <returns>The value <paramref name="cryptoAlgorithmID"/> with the
        /// specified substitution if the value is <see cref="CryptoAlgorithmId.Default"/>.</returns>
        public static CryptoAlgorithmId DefaultAlgorithmEncrypt(this CryptoAlgorithmId cryptoAlgorithmID) =>
            cryptoAlgorithmID.DefaultMeta(DefaultAlgorithmEncryptID);

        /// <summary>
        /// Convenience function that returns the value <see cref="DefaultAlgorithmSignID"/> if
        /// <paramref name="cryptoAlgorithmID"/> is <see cref="CryptoAlgorithmId.Default"/> 
        /// and <paramref name="cryptoAlgorithmID"/>
        /// otherwise.
        /// </summary>
        /// <param name="cryptoAlgorithmID">The CryptoAlgorithmID to default.</param>
        /// <returns>The value <paramref name="cryptoAlgorithmID"/> with the
        /// specified substitution if the value is <see cref="CryptoAlgorithmId.Default"/>.</returns>
        public static CryptoAlgorithmId DefaultAlgorithmSign(this CryptoAlgorithmId cryptoAlgorithmID) =>
            cryptoAlgorithmID.DefaultMeta(DefaultAlgorithmSignID);

        /// <summary>
        /// Convenience function that returns the value <see cref="DefaultAlgorithmAuthenticateID"/> if
        /// <paramref name="cryptoAlgorithmID"/> is <see cref="CryptoAlgorithmId.Default"/> 
        /// and <paramref name="cryptoAlgorithmID"/>
        /// otherwise.
        /// </summary>
        /// <param name="cryptoAlgorithmID">The CryptoAlgorithmID to default.</param>
        /// <returns>The value <paramref name="cryptoAlgorithmID"/> with the
        /// specified substitution if the value is <see cref="CryptoAlgorithmId.Default"/>.</returns>
        public static CryptoAlgorithmId DefaultAlgorithmAuthenticate(this CryptoAlgorithmId cryptoAlgorithmID) =>
            cryptoAlgorithmID.DefaultMeta(DefaultAlgorithmAuthenticateID);

        }
    }
