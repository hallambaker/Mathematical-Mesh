#region // Copyright
//  © 2021 by Phill Hallam-Baker
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
#endregion

using System;
using System.Collections.Generic;

namespace Goedel.Cryptography.PKIX {
    public partial class TBSCertificate {

        /// <summary>
        /// Construct from a subject key, subject name and issuer name.
        /// </summary>
        /// <param name="SubjectKey">Key that the certificate will authenticate.</param>
        /// <param name="SubjectName">Subject name.</param>
        public TBSCertificate(
                CryptoProvider SubjectKey,
                 List<Name> SubjectName) : this() {

            SetValidity();
            Subject = SubjectName;
            var KeyPair = SubjectKey.KeyPair;
            SubjectPublicKeyInfo = KeyPair.KeyInfoData;
            }

        /// <summary>
        /// Construct from a subject key, subject name and issuer name.
        /// </summary>
        /// <param name="SubjectKey">Key that the certificate will authenticate.</param>
        /// <param name="SubjectName">Subject name.</param>
        public TBSCertificate(
                KeyPair SubjectKey,
                 List<Name> SubjectName)
            : this() {

            SetValidity();
            Subject = SubjectName;
            var KeyPair = SubjectKey;
            SubjectPublicKeyInfo = KeyPair.KeyInfoData;
            }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public TBSCertificate() {
            Version = 2; // Which is really X.509v3
            SerialNumber = CryptoCatalog.GetBytes(16);
            Subject = null;
            Issuer = null;
            IssuerUniqueID = null;
            SubjectUniqueID = null;
            Extensions = new List<Extension>();
            }

        /// <summary>
        /// The raw certificate data, as populated by the 'convert from binary
        /// certificate method.
        /// </summary>
        /// 
        public byte[] RawData { get; set; }



        /// <summary>
        /// Set the default validity interval of 1 year from the present date.
        /// </summary>
        public void SetValidity() => SetValidity(1);

        /// <summary>
        /// Set the validity interval in years from the present date.
        /// 
        /// To reduce errors caused by clock skew between machines, the time interval
        /// is backdated to one minute after midnight UTC on the day of one hour before the
        /// current time.
        /// </summary>
        /// <param name="Years">Number of years for certificate to be valid</param>
        public void SetValidity(int Years) {
            TimeSpan TimeSpan = new TimeSpan(366 * Years, 0, 0, 0);
            SetValidity(TimeSpan);
            }

        /// <summary>
        /// Set the validity interval to the present data plus a specified time span.
        /// 
        /// To reduce errors caused by clock skew between machines, the time interval
        /// is backdated to one minute after midnight UTC on the day of one hour before the
        /// current time.
        /// </summary>
        /// <param name="TimeSpan">Time interval.</param>
        public void SetValidity(TimeSpan TimeSpan) {
            DateTime NotBefore = DateTime.Now.ToUniversalTime();
            DateTime NotAfter = NotBefore.Add(TimeSpan);

            // Predate the certificate by one day plus an hour to avoid issues with the day roll round
            NotBefore = NotBefore.AddHours(-25);

            // Predate the certificate to 1 minute past midnight (UTC) on the date of 
            // issue to avoid clock sync issues
            NotBefore = new DateTime(NotBefore.Year, NotBefore.Month, NotBefore.Day,
                        0, 0, 1, DateTimeKind.Utc);

            SetValidity(NotBefore, NotAfter);
            }

        /// <summary>
        /// Set the validity interval to the specified NotBefore and NotAfter times.
        /// </summary>
        /// <param name="NotBefore">First time instant that the certificate is valid.</param>
        /// <param name="NotAfter">Last time instant that the certificate is valid.</param>
        public void SetValidity(DateTime NotBefore, DateTime NotAfter) => Validity = new Validity(NotBefore, NotAfter);

        /// <summary>
        /// Add an X.509v3 extension encty
        /// </summary>
        /// <param name="Extension">The extension to add.</param>
        public void AddExtension(Extension Extension) {
            if (Extensions == null) {
                Extensions = new List<Extension>();
                }
            Extensions.Add(Extension);
            }

        /// <summary>
        /// Set the Authority Key Identifier extension
        /// </summary>
        /// <param name="ID">The authority identifier</param>

        public void SetAuthorityKeyIdentifier(byte[] ID) {
            AuthorityKeyIdentifier AuthorityKeyIdentifier =
                        new AuthorityKeyIdentifier {
                            AuthorityCertSerialNumber = System.Int32.MinValue,
                            KeyIdentifier = ID
                            };
            AddExtension(new Extension(AuthorityKeyIdentifier, false));
            }

        /// <summary>
        /// Set the subject key identifier extension.
        /// </summary>
        /// <param name="ID">The key identifier</param>
        public void SetSubjectKeyIdentifier(byte[] ID) {
            SubjectKeyIdentifier SubjectKeyIdentifier = new SubjectKeyIdentifier {
                Value = ID
                };
            AddExtension(new Extension(SubjectKeyIdentifier, false));
            }

        /// <summary>
        /// Set the subject alt name
        /// </summary>
        /// <param name="Name">Name to set</param>
        public void SetSubjectAltName(string Name) {
            GeneralName GeneralName = new GeneralName(Name);
            SubjectAltName SubjectAltName = new SubjectAltName(GeneralName);
            AddExtension(new Extension(SubjectAltName, false));
            }

        /// <summary>
        /// Set the profile for a certificate
        /// </summary>
        /// <param name="Use">Use for the certificate</param>
        /// <param name="PathLen">Path length constraint</param>
        public void SetProfile(Application Use, int PathLen = -1) {

            bool CA = false;

            List<int[]> Uses = new List<int[]>();
            KeyUses KeyUses = 0;

            if ((Use & Application.ServerAuth) > 0) {
                Uses.Add(Constants.OID__id_kp_serverAuth);
                KeyUses |= KeyUses.KeyAgreement;
                }

            if ((Use & Application.ClientAuth) > 0) {
                Uses.Add(Constants.OID__id_kp_clientAuth);
                KeyUses |= KeyUses.KeyAgreement;
                }

            if ((Use & Application.CodeSigning) > 0) {
                Uses.Add(Constants.OID__id_kp_codeSigning);
                KeyUses |= KeyUses.DigitalSignature;
                }

            bool EmailProtection = false;
            if ((Use & Application.EmailEncryption) > 0) {
                Uses.Add(Constants.OID__id_kp_emailProtection);
                //Uses.Add(Constants.OID__netscape_smime); // required by some S/MIME clients
                EmailProtection = true;
                KeyUses |= KeyUses.KeyEncipherment;
                }

            if ((Use & Application.EmailSignature) > 0) {
                if (!EmailProtection) {
                    Uses.Add(Constants.OID__id_kp_emailProtection);
                    }
                KeyUses |= KeyUses.DigitalSignature;
                }

            if ((Use & Application.DataEncryption) > 0) {
                KeyUses |= KeyUses.KeyEncipherment;
                }

            if ((Use & Application.DataSignature) > 0) {
                KeyUses |= KeyUses.DigitalSignature;
                }

            if ((Use & Application.TimeStamping) > 0) {
                Uses.Add(Constants.OID__id_kp_timeStamping);
                KeyUses |= KeyUses.DigitalSignature;
                }

            if ((Use & Application.OCSP) > 0) {
                Uses.Add(Constants.OID__id_kp_OCSPSigning);
                KeyUses |= KeyUses.DigitalSignature;
                }

            if ((Use & Application.CRL) > 0) {
                KeyUses |= KeyUses.CRLSign;
                }

            if (((Use & Application.PersonalMaster) > 0) | ((Use & Application.DeviceMaster) > 0)) {
                KeyUses |= KeyUses.DigitalSignature;
                }

            if ((Use & Application.Confirmation) > 0) {
                KeyUses = KeyUses | KeyUses.DigitalSignature | KeyUses.NonRepudiation;
                }

            if (((Use & Application.CA) > 0) | ((Use & Application.PersonalMaster) > 0) | ((Use & Application.DeviceMaster) > 0)) {
                CA = true;
                KeyUses |= KeyUses.KeyCertSign;
                }

            if ((Use & Application.Root) > 0) {
                CA = true;
                KeyUses |= KeyUses.KeyCertSign;
                }

            SetBasicConstraints(CA, PathLen);
            if (Uses.Count > 0) {
                SetExtendedKeyUsage(Uses);
                }
            SetKeyUsage(KeyUses);
            }


        /// <summary>
        /// Set the basic constraints field
        /// </summary>
        /// <param name="CA">If true, can act as a CA</param>
        /// <param name="PathLength">Maximum path length of a chain.</param>
        public void SetBasicConstraints(bool CA, int PathLength) {
            BasicConstraints BasicConstraints =
                        new BasicConstraints {
                            CA = CA,
                            PathLenConstraint = PathLength < 0 ?
                System.Int32.MinValue : PathLength
                            };
            AddExtension(new Extension(BasicConstraints, true));
            }

        /// <summary>
        /// Pack key usage data into the stupidest bit field format in the known universe
        /// </summary>
        /// <param name="KeyUses">PKIX Key uses.</param>
        public void SetKeyUsage(KeyUses KeyUses) {

            int Uses = (int)KeyUses;
            byte[] Value = Assanine_wankathon(Uses);

            KeyUsage KeyUsage = new KeyUsage {
                Value = Value
                };
            AddExtension(new Extension(KeyUsage, true));
            }

        /// <summary>
        /// PKIX extended key uses
        /// </summary>
        /// <param name="Values">The key usage values</param>
        public void SetExtendedKeyUsage(List<int[]> Values) {
            ExtendedKeyUsage ExtendedKeyUsage = new ExtendedKeyUsage {
                KeyPurpose = Values
                };
            AddExtension(new Extension(ExtendedKeyUsage, false));
            }


        // Total turd polishing here.
        // There is no reason this could not have been a simple bitfield
        // Instead it uses the binary field 'feature' of ASN.1

        // In DER format the data has to be represented in the least number
        // of bits possible with leading zeros (or maybe its trailing) 
        // suppressed.

        private static byte[] Assanine_wankathon(int data) {


            int reversed = 0;
            int bits = 0;

            for (int i = 0; i < 24; i++) {
                reversed <<= 1; // shift the accumulator first
                if ((data & 1) == 1) {
                    reversed |= 1;
                    bits = i + 1;
                    }
                data >>= 1; // read the next bit
                }

            int bytes = (bits + 7) / 8;

            byte[] result = new byte[bytes + 1];
            result[0] = (byte)(8 - (bits % 8));
            result[1] = (byte)(0xff & (reversed >> 16));

            if (bytes > 1) {
                result[2] = (byte)(0xff & (reversed >> 8));
                }
            if (bytes > 2) {
                result[3] = (byte)(0xff & (reversed));
                }
            return result;
            }

        }

    /// <summary>
    /// X.509v3 Extension
    /// </summary>
    public partial class Extension {
        /// <summary>
        /// Create an extension from the specified object with optional 
        /// criticality flag.
        /// </summary>
        /// <param name="Object">The object to encode.</param>
        /// <param name="Critical">If true, the extension will be marked as
        ///   'critical' meaning that backwards compatibility will be broken 
        ///   and legacy relying parties MUST reject the certificate. Only use
        ///   if this is the intended behavior.</param>
        public Extension(Goedel.ASN.Root Object, bool Critical) {
            this.ObjectIdentifier = Object.OID;
            this.Critical = Critical;
            this.Data = Object.DER();
            }
        }

    public partial class Validity {
        /// <summary>
        /// Create Validity interval with specified NotBefore and NotAfter times.
        /// </summary>
        /// <param name="NotBefore">Time before which the enclosing certificate is not valid.</param>
        /// <param name="NotAfter">Time after which the enclosing certificate is not valid.</param>
        public Validity(DateTime NotBefore, DateTime NotAfter) {
            this.NotBefore = NotBefore;
            this.NotAfter = NotAfter;
            }
        }

    /// <summary>
    /// Subject Alt Name.
    /// </summary>
    public partial class SubjectAltName {
        /// <summary>
        /// Construct from a general name.
        /// </summary>
        /// <param name="GeneralName">General name to encode</param>
        public SubjectAltName(GeneralName GeneralName) => Names = new List<GeneralName> {
                GeneralName
                };
        }

    /// <summary>
    /// Construct a generalized name depending on whether the name provided
    /// is an RFC822 mail address or not.
    /// </summary>
    public partial class GeneralName {
        /// <summary>
        /// Construct from the specified string.
        /// </summary>
        /// <param name="Name">The name to use. the type is inferred from the 
        /// syntax.</param>
        public GeneralName(string Name) {
            if (Name.IndexOf('@') < 0) {
                this.DNSName = Name;
                }
            else {
                this.RFC822Name = Name;
                }
            }
        }

    public partial class Name {
        /// <summary>
        /// Conver a common name string to a list of Name segments.
        /// </summary>
        /// <param name="CommonName">Common name to convert</param>
        /// <returns>List of Name segments.</returns>
        public static List<Name> ToName(string CommonName) {
            List<Name> Result = new List<Name>();
            Name Segment = new Name(CommonName);
            Result.Add(Segment);
            return Result;
            }
        }
    }
