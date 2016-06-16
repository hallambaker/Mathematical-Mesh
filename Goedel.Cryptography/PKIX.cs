//   Copyright © 2015 by Comodo Group Inc.
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
//  
//  

using System;
using System.Collections.Generic;
using System.Text;
using Goedel.ASN1;

// This is the generated code Don't edit.


// Generate OID declarations

namespace Goedel.ASN1 {  // default namespace

	}
namespace Goedel.Cryptography.PKIX {

    /// <summary>
    /// id_pkix =  iso(1)  identified_organization(3)  dod(6)  internet(1)  security(5)  mechanisms(5)  pkix(7) 
    /// </summary>
	public partial class Constants {
		/// <summary>
		/// id_pkix as integer sequence
		/// </summary>
		public readonly static int [] OID__id_pkix = new int [] { 1, 3, 6, 1, 5, 5, 7};
		/// <summary>
		/// id_pkix as string
		/// </summary>
		public const string OIDS__id_pkix = "1.3.6.1.5.5.7";


		/// <summary>
		/// id_pe = id_pkix (1) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_pe = new int [] { 1, 3, 6, 1, 5, 5, 7, 1};
		/// <summary>
		/// id_pe = id_pkix (1) as string
		/// </summary>
		public const string OIDS__id_pe = "1.3.6.1.5.5.7.1";



		/// <summary>
		/// id_pe_authorityInfoAccess = id_pe (1) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_pe_authorityInfoAccess = new int [] { 1, 3, 6, 1, 5, 5, 7, 1, 1};
		/// <summary>
		/// id_pe_authorityInfoAccess = id_pe (1) as string
		/// </summary>
		public const string OIDS__id_pe_authorityInfoAccess = "1.3.6.1.5.5.7.1.1";



		/// <summary>
		/// id_pe_subjectInfoAccess = id_pe (11) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_pe_subjectInfoAccess = new int [] { 1, 3, 6, 1, 5, 5, 7, 1, 11};
		/// <summary>
		/// id_pe_subjectInfoAccess = id_pe (11) as string
		/// </summary>
		public const string OIDS__id_pe_subjectInfoAccess = "1.3.6.1.5.5.7.1.11";



		/// <summary>
		/// id_qt = id_pkix (2) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_qt = new int [] { 1, 3, 6, 1, 5, 5, 7, 2};
		/// <summary>
		/// id_qt = id_pkix (2) as string
		/// </summary>
		public const string OIDS__id_qt = "1.3.6.1.5.5.7.2";



		/// <summary>
		/// id_qt_cps = id_qt (1) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_qt_cps = new int [] { 1, 3, 6, 1, 5, 5, 7, 2, 1};
		/// <summary>
		/// id_qt_cps = id_qt (1) as string
		/// </summary>
		public const string OIDS__id_qt_cps = "1.3.6.1.5.5.7.2.1";



		/// <summary>
		/// id_qt_unotice = id_qt (2) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_qt_unotice = new int [] { 1, 3, 6, 1, 5, 5, 7, 2, 2};
		/// <summary>
		/// id_qt_unotice = id_qt (2) as string
		/// </summary>
		public const string OIDS__id_qt_unotice = "1.3.6.1.5.5.7.2.2";



		/// <summary>
		/// id_kp = id_pkix (3) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_kp = new int [] { 1, 3, 6, 1, 5, 5, 7, 3};
		/// <summary>
		/// id_kp = id_pkix (3) as string
		/// </summary>
		public const string OIDS__id_kp = "1.3.6.1.5.5.7.3";



		/// <summary>
		/// id_kp_serverAuth = id_kp (1) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_kp_serverAuth = new int [] { 1, 3, 6, 1, 5, 5, 7, 3, 1};
		/// <summary>
		/// id_kp_serverAuth = id_kp (1) as string
		/// </summary>
		public const string OIDS__id_kp_serverAuth = "1.3.6.1.5.5.7.3.1";



		/// <summary>
		/// id_kp_clientAuth = id_kp (2) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_kp_clientAuth = new int [] { 1, 3, 6, 1, 5, 5, 7, 3, 2};
		/// <summary>
		/// id_kp_clientAuth = id_kp (2) as string
		/// </summary>
		public const string OIDS__id_kp_clientAuth = "1.3.6.1.5.5.7.3.2";



		/// <summary>
		/// id_kp_codeSigning = id_kp (3) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_kp_codeSigning = new int [] { 1, 3, 6, 1, 5, 5, 7, 3, 3};
		/// <summary>
		/// id_kp_codeSigning = id_kp (3) as string
		/// </summary>
		public const string OIDS__id_kp_codeSigning = "1.3.6.1.5.5.7.3.3";



		/// <summary>
		/// id_kp_emailProtection = id_kp (4) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_kp_emailProtection = new int [] { 1, 3, 6, 1, 5, 5, 7, 3, 4};
		/// <summary>
		/// id_kp_emailProtection = id_kp (4) as string
		/// </summary>
		public const string OIDS__id_kp_emailProtection = "1.3.6.1.5.5.7.3.4";



		/// <summary>
		/// id_kp_timeStamping = id_kp (8) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_kp_timeStamping = new int [] { 1, 3, 6, 1, 5, 5, 7, 3, 8};
		/// <summary>
		/// id_kp_timeStamping = id_kp (8) as string
		/// </summary>
		public const string OIDS__id_kp_timeStamping = "1.3.6.1.5.5.7.3.8";



		/// <summary>
		/// id_kp_OCSPSigning = id_kp (9) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_kp_OCSPSigning = new int [] { 1, 3, 6, 1, 5, 5, 7, 3, 9};
		/// <summary>
		/// id_kp_OCSPSigning = id_kp (9) as string
		/// </summary>
		public const string OIDS__id_kp_OCSPSigning = "1.3.6.1.5.5.7.3.9";



		/// <summary>
		/// id_ad = id_pkix (48) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_ad = new int [] { 1, 3, 6, 1, 5, 5, 7, 48};
		/// <summary>
		/// id_ad = id_pkix (48) as string
		/// </summary>
		public const string OIDS__id_ad = "1.3.6.1.5.5.7.48";



		/// <summary>
		/// id_ad_ocsp = id_ad (1) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_ad_ocsp = new int [] { 1, 3, 6, 1, 5, 5, 7, 48, 1};
		/// <summary>
		/// id_ad_ocsp = id_ad (1) as string
		/// </summary>
		public const string OIDS__id_ad_ocsp = "1.3.6.1.5.5.7.48.1";



		/// <summary>
		/// id_ad_caIssuers = id_ad (2) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_ad_caIssuers = new int [] { 1, 3, 6, 1, 5, 5, 7, 48, 2};
		/// <summary>
		/// id_ad_caIssuers = id_ad (2) as string
		/// </summary>
		public const string OIDS__id_ad_caIssuers = "1.3.6.1.5.5.7.48.2";



		/// <summary>
		/// id_ad_timeStamping = id_ad (3) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_ad_timeStamping = new int [] { 1, 3, 6, 1, 5, 5, 7, 48, 3};
		/// <summary>
		/// id_ad_timeStamping = id_ad (3) as string
		/// </summary>
		public const string OIDS__id_ad_timeStamping = "1.3.6.1.5.5.7.48.3";



		/// <summary>
		/// id_ad_caRepository = id_ad (5) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_ad_caRepository = new int [] { 1, 3, 6, 1, 5, 5, 7, 48, 5};
		/// <summary>
		/// id_ad_caRepository = id_ad (5) as string
		/// </summary>
		public const string OIDS__id_ad_caRepository = "1.3.6.1.5.5.7.48.5";


		}
    /// <summary>
    /// id_at =  joint_iso_ccitt(2)  ds(5)  at(4) 
    /// </summary>
	public partial class Constants {
		/// <summary>
		/// id_at as integer sequence
		/// </summary>
		public readonly static int [] OID__id_at = new int [] { 2, 5, 4};
		/// <summary>
		/// id_at as string
		/// </summary>
		public const string OIDS__id_at = "2.5.4";


		/// <summary>
		/// id_at_countryName = id_at (6) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_at_countryName = new int [] { 2, 5, 4, 6};
		/// <summary>
		/// id_at_countryName = id_at (6) as string
		/// </summary>
		public const string OIDS__id_at_countryName = "2.5.4.6";



		/// <summary>
		/// id_at_organizationName = id_at (10) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_at_organizationName = new int [] { 2, 5, 4, 10};
		/// <summary>
		/// id_at_organizationName = id_at (10) as string
		/// </summary>
		public const string OIDS__id_at_organizationName = "2.5.4.10";



		/// <summary>
		/// id_at_organizationalUnitName = id_at (11) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_at_organizationalUnitName = new int [] { 2, 5, 4, 11};
		/// <summary>
		/// id_at_organizationalUnitName = id_at (11) as string
		/// </summary>
		public const string OIDS__id_at_organizationalUnitName = "2.5.4.11";



		/// <summary>
		/// id_at_dnQualifier = id_at (46) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_at_dnQualifier = new int [] { 2, 5, 4, 46};
		/// <summary>
		/// id_at_dnQualifier = id_at (46) as string
		/// </summary>
		public const string OIDS__id_at_dnQualifier = "2.5.4.46";



		/// <summary>
		/// id_at_stateOrProvinceName = id_at (8) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_at_stateOrProvinceName = new int [] { 2, 5, 4, 8};
		/// <summary>
		/// id_at_stateOrProvinceName = id_at (8) as string
		/// </summary>
		public const string OIDS__id_at_stateOrProvinceName = "2.5.4.8";



		/// <summary>
		/// id_at_commonName = id_at (3) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_at_commonName = new int [] { 2, 5, 4, 3};
		/// <summary>
		/// id_at_commonName = id_at (3) as string
		/// </summary>
		public const string OIDS__id_at_commonName = "2.5.4.3";



		/// <summary>
		/// id_at_serialNumber = id_at (5) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_at_serialNumber = new int [] { 2, 5, 4, 5};
		/// <summary>
		/// id_at_serialNumber = id_at (5) as string
		/// </summary>
		public const string OIDS__id_at_serialNumber = "2.5.4.5";



		/// <summary>
		/// id_at_localityName = id_at (7) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_at_localityName = new int [] { 2, 5, 4, 7};
		/// <summary>
		/// id_at_localityName = id_at (7) as string
		/// </summary>
		public const string OIDS__id_at_localityName = "2.5.4.7";



		/// <summary>
		/// id_at_title = id_at (12) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_at_title = new int [] { 2, 5, 4, 12};
		/// <summary>
		/// id_at_title = id_at (12) as string
		/// </summary>
		public const string OIDS__id_at_title = "2.5.4.12";



		/// <summary>
		/// id_at_name = id_at (41) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_at_name = new int [] { 2, 5, 4, 41};
		/// <summary>
		/// id_at_name = id_at (41) as string
		/// </summary>
		public const string OIDS__id_at_name = "2.5.4.41";



		/// <summary>
		/// id_at_surname = id_at (4) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_at_surname = new int [] { 2, 5, 4, 4};
		/// <summary>
		/// id_at_surname = id_at (4) as string
		/// </summary>
		public const string OIDS__id_at_surname = "2.5.4.4";



		/// <summary>
		/// id_at_givenName = id_at (42) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_at_givenName = new int [] { 2, 5, 4, 42};
		/// <summary>
		/// id_at_givenName = id_at (42) as string
		/// </summary>
		public const string OIDS__id_at_givenName = "2.5.4.42";



		/// <summary>
		/// id_at_initials = id_at (43) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_at_initials = new int [] { 2, 5, 4, 43};
		/// <summary>
		/// id_at_initials = id_at (43) as string
		/// </summary>
		public const string OIDS__id_at_initials = "2.5.4.43";



		/// <summary>
		/// id_at_pseudonym = id_at (65) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_at_pseudonym = new int [] { 2, 5, 4, 65};
		/// <summary>
		/// id_at_pseudonym = id_at (65) as string
		/// </summary>
		public const string OIDS__id_at_pseudonym = "2.5.4.65";



		/// <summary>
		/// id_at_generationQualifier = id_at (44) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_at_generationQualifier = new int [] { 2, 5, 4, 44};
		/// <summary>
		/// id_at_generationQualifier = id_at (44) as string
		/// </summary>
		public const string OIDS__id_at_generationQualifier = "2.5.4.44";


		}
    /// <summary>
    /// pkcs =  iso(1)  member_body(2)  us(840)  rsadsi(113549)  pkcs(1) 
    /// </summary>
	public partial class Constants {
		/// <summary>
		/// pkcs as integer sequence
		/// </summary>
		public readonly static int [] OID__pkcs = new int [] { 1, 2, 840, 113549, 1};
		/// <summary>
		/// pkcs as string
		/// </summary>
		public const string OIDS__pkcs = "1.2.840.113549.1";


		/// <summary>
		/// pkcs_9 = pkcs (9) as integer sequence
		/// </summary>
		public readonly static int [] OID__pkcs_9 = new int [] { 1, 2, 840, 113549, 1, 9};
		/// <summary>
		/// pkcs_9 = pkcs (9) as string
		/// </summary>
		public const string OIDS__pkcs_9 = "1.2.840.113549.1.9";



		/// <summary>
		/// id_emailAddress = pkcs_9 (1) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_emailAddress = new int [] { 1, 2, 840, 113549, 1, 9, 1};
		/// <summary>
		/// id_emailAddress = pkcs_9 (1) as string
		/// </summary>
		public const string OIDS__id_emailAddress = "1.2.840.113549.1.9.1";



		/// <summary>
		/// pkcs_1 = pkcs (1) as integer sequence
		/// </summary>
		public readonly static int [] OID__pkcs_1 = new int [] { 1, 2, 840, 113549, 1, 1};
		/// <summary>
		/// pkcs_1 = pkcs (1) as string
		/// </summary>
		public const string OIDS__pkcs_1 = "1.2.840.113549.1.1";



		/// <summary>
		/// rsaEncryption = pkcs_1 (1) as integer sequence
		/// </summary>
		public readonly static int [] OID__rsaEncryption = new int [] { 1, 2, 840, 113549, 1, 1, 1};
		/// <summary>
		/// rsaEncryption = pkcs_1 (1) as string
		/// </summary>
		public const string OIDS__rsaEncryption = "1.2.840.113549.1.1.1";



		/// <summary>
		/// sha1WithRSAEncryption = pkcs_1 (5) as integer sequence
		/// </summary>
		public readonly static int [] OID__sha1WithRSAEncryption = new int [] { 1, 2, 840, 113549, 1, 1, 5};
		/// <summary>
		/// sha1WithRSAEncryption = pkcs_1 (5) as string
		/// </summary>
		public const string OIDS__sha1WithRSAEncryption = "1.2.840.113549.1.1.5";



		/// <summary>
		/// sha224WithRSAEncryption = pkcs_1 (14) as integer sequence
		/// </summary>
		public readonly static int [] OID__sha224WithRSAEncryption = new int [] { 1, 2, 840, 113549, 1, 1, 14};
		/// <summary>
		/// sha224WithRSAEncryption = pkcs_1 (14) as string
		/// </summary>
		public const string OIDS__sha224WithRSAEncryption = "1.2.840.113549.1.1.14";



		/// <summary>
		/// sha256WithRSAEncryption = pkcs_1 (11) as integer sequence
		/// </summary>
		public readonly static int [] OID__sha256WithRSAEncryption = new int [] { 1, 2, 840, 113549, 1, 1, 11};
		/// <summary>
		/// sha256WithRSAEncryption = pkcs_1 (11) as string
		/// </summary>
		public const string OIDS__sha256WithRSAEncryption = "1.2.840.113549.1.1.11";



		/// <summary>
		/// sha384WithRSAEncryption = pkcs_1 (12) as integer sequence
		/// </summary>
		public readonly static int [] OID__sha384WithRSAEncryption = new int [] { 1, 2, 840, 113549, 1, 1, 12};
		/// <summary>
		/// sha384WithRSAEncryption = pkcs_1 (12) as string
		/// </summary>
		public const string OIDS__sha384WithRSAEncryption = "1.2.840.113549.1.1.12";



		/// <summary>
		/// sha512WithRSAEncryption = pkcs_1 (13) as integer sequence
		/// </summary>
		public readonly static int [] OID__sha512WithRSAEncryption = new int [] { 1, 2, 840, 113549, 1, 1, 13};
		/// <summary>
		/// sha512WithRSAEncryption = pkcs_1 (13) as string
		/// </summary>
		public const string OIDS__sha512WithRSAEncryption = "1.2.840.113549.1.1.13";



		/// <summary>
		/// pkcs_12 = pkcs (12) as integer sequence
		/// </summary>
		public readonly static int [] OID__pkcs_12 = new int [] { 1, 2, 840, 113549, 1, 12};
		/// <summary>
		/// pkcs_12 = pkcs (12) as string
		/// </summary>
		public const string OIDS__pkcs_12 = "1.2.840.113549.1.12";



		/// <summary>
		/// pkcs_12_10 = pkcs_12 (10) as integer sequence
		/// </summary>
		public readonly static int [] OID__pkcs_12_10 = new int [] { 1, 2, 840, 113549, 1, 12, 10};
		/// <summary>
		/// pkcs_12_10 = pkcs_12 (10) as string
		/// </summary>
		public const string OIDS__pkcs_12_10 = "1.2.840.113549.1.12.10";



		/// <summary>
		/// pkcs_12_bagtype = pkcs_12_10 (1) as integer sequence
		/// </summary>
		public readonly static int [] OID__pkcs_12_bagtype = new int [] { 1, 2, 840, 113549, 1, 12, 10, 1};
		/// <summary>
		/// pkcs_12_bagtype = pkcs_12_10 (1) as string
		/// </summary>
		public const string OIDS__pkcs_12_bagtype = "1.2.840.113549.1.12.10.1";



		/// <summary>
		/// pkcs_12_keybag = pkcs_12_bagtype (1) as integer sequence
		/// </summary>
		public readonly static int [] OID__pkcs_12_keybag = new int [] { 1, 2, 840, 113549, 1, 12, 10, 1, 1};
		/// <summary>
		/// pkcs_12_keybag = pkcs_12_bagtype (1) as string
		/// </summary>
		public const string OIDS__pkcs_12_keybag = "1.2.840.113549.1.12.10.1.1";



		/// <summary>
		/// pkcs_12_shroudedbag = pkcs_12_bagtype (2) as integer sequence
		/// </summary>
		public readonly static int [] OID__pkcs_12_shroudedbag = new int [] { 1, 2, 840, 113549, 1, 12, 10, 1, 2};
		/// <summary>
		/// pkcs_12_shroudedbag = pkcs_12_bagtype (2) as string
		/// </summary>
		public const string OIDS__pkcs_12_shroudedbag = "1.2.840.113549.1.12.10.1.2";



		/// <summary>
		/// pkcs_12_certbag = pkcs_12_bagtype (3) as integer sequence
		/// </summary>
		public readonly static int [] OID__pkcs_12_certbag = new int [] { 1, 2, 840, 113549, 1, 12, 10, 1, 3};
		/// <summary>
		/// pkcs_12_certbag = pkcs_12_bagtype (3) as string
		/// </summary>
		public const string OIDS__pkcs_12_certbag = "1.2.840.113549.1.12.10.1.3";



		/// <summary>
		/// pkcs_12_crlbag = pkcs_12_bagtype (4) as integer sequence
		/// </summary>
		public readonly static int [] OID__pkcs_12_crlbag = new int [] { 1, 2, 840, 113549, 1, 12, 10, 1, 4};
		/// <summary>
		/// pkcs_12_crlbag = pkcs_12_bagtype (4) as string
		/// </summary>
		public const string OIDS__pkcs_12_crlbag = "1.2.840.113549.1.12.10.1.4";



		/// <summary>
		/// pkcs_12_secretbag = pkcs_12_bagtype (5) as integer sequence
		/// </summary>
		public readonly static int [] OID__pkcs_12_secretbag = new int [] { 1, 2, 840, 113549, 1, 12, 10, 1, 5};
		/// <summary>
		/// pkcs_12_secretbag = pkcs_12_bagtype (5) as string
		/// </summary>
		public const string OIDS__pkcs_12_secretbag = "1.2.840.113549.1.12.10.1.5";



		/// <summary>
		/// pkcs_12_safecontentsbag = pkcs_12_bagtype (6) as integer sequence
		/// </summary>
		public readonly static int [] OID__pkcs_12_safecontentsbag = new int [] { 1, 2, 840, 113549, 1, 12, 10, 1, 6};
		/// <summary>
		/// pkcs_12_safecontentsbag = pkcs_12_bagtype (6) as string
		/// </summary>
		public const string OIDS__pkcs_12_safecontentsbag = "1.2.840.113549.1.12.10.1.6";


		}
    /// <summary>
    /// id_ce =  joint_iso_ccitt(2)  ds(5)  ce(29) 
    /// </summary>
	public partial class Constants {
		/// <summary>
		/// id_ce as integer sequence
		/// </summary>
		public readonly static int [] OID__id_ce = new int [] { 2, 5, 29};
		/// <summary>
		/// id_ce as string
		/// </summary>
		public const string OIDS__id_ce = "2.5.29";


		/// <summary>
		/// id_ce_authorityKeyIdentifier = id_ce (35) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_ce_authorityKeyIdentifier = new int [] { 2, 5, 29, 35};
		/// <summary>
		/// id_ce_authorityKeyIdentifier = id_ce (35) as string
		/// </summary>
		public const string OIDS__id_ce_authorityKeyIdentifier = "2.5.29.35";



		/// <summary>
		/// id_ce_subjectKeyIdentifier = id_ce (14) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_ce_subjectKeyIdentifier = new int [] { 2, 5, 29, 14};
		/// <summary>
		/// id_ce_subjectKeyIdentifier = id_ce (14) as string
		/// </summary>
		public const string OIDS__id_ce_subjectKeyIdentifier = "2.5.29.14";



		/// <summary>
		/// id_ce_keyUsage = id_ce (15) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_ce_keyUsage = new int [] { 2, 5, 29, 15};
		/// <summary>
		/// id_ce_keyUsage = id_ce (15) as string
		/// </summary>
		public const string OIDS__id_ce_keyUsage = "2.5.29.15";



		/// <summary>
		/// id_ce_privateKeyUsagePeriod = id_ce (16) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_ce_privateKeyUsagePeriod = new int [] { 2, 5, 29, 16};
		/// <summary>
		/// id_ce_privateKeyUsagePeriod = id_ce (16) as string
		/// </summary>
		public const string OIDS__id_ce_privateKeyUsagePeriod = "2.5.29.16";



		/// <summary>
		/// id_ce_certificatePolicies = id_ce (32) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_ce_certificatePolicies = new int [] { 2, 5, 29, 32};
		/// <summary>
		/// id_ce_certificatePolicies = id_ce (32) as string
		/// </summary>
		public const string OIDS__id_ce_certificatePolicies = "2.5.29.32";



		/// <summary>
		/// anyPolicy = id_ce_certificatePolicies (0) as integer sequence
		/// </summary>
		public readonly static int [] OID__anyPolicy = new int [] { 2, 5, 29, 32, 0};
		/// <summary>
		/// anyPolicy = id_ce_certificatePolicies (0) as string
		/// </summary>
		public const string OIDS__anyPolicy = "2.5.29.32.0";



		/// <summary>
		/// id_ce_policyMappings = id_ce (33) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_ce_policyMappings = new int [] { 2, 5, 29, 33};
		/// <summary>
		/// id_ce_policyMappings = id_ce (33) as string
		/// </summary>
		public const string OIDS__id_ce_policyMappings = "2.5.29.33";



		/// <summary>
		/// id_ce_subjectAltName = id_ce (17) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_ce_subjectAltName = new int [] { 2, 5, 29, 17};
		/// <summary>
		/// id_ce_subjectAltName = id_ce (17) as string
		/// </summary>
		public const string OIDS__id_ce_subjectAltName = "2.5.29.17";



		/// <summary>
		/// id_ce_issuerAltName = id_ce (18) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_ce_issuerAltName = new int [] { 2, 5, 29, 18};
		/// <summary>
		/// id_ce_issuerAltName = id_ce (18) as string
		/// </summary>
		public const string OIDS__id_ce_issuerAltName = "2.5.29.18";



		/// <summary>
		/// id_ce_subjectDirectoryAttributes = id_ce (9) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_ce_subjectDirectoryAttributes = new int [] { 2, 5, 29, 9};
		/// <summary>
		/// id_ce_subjectDirectoryAttributes = id_ce (9) as string
		/// </summary>
		public const string OIDS__id_ce_subjectDirectoryAttributes = "2.5.29.9";



		/// <summary>
		/// id_ce_basicConstraints = id_ce (19) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_ce_basicConstraints = new int [] { 2, 5, 29, 19};
		/// <summary>
		/// id_ce_basicConstraints = id_ce (19) as string
		/// </summary>
		public const string OIDS__id_ce_basicConstraints = "2.5.29.19";



		/// <summary>
		/// id_ce_nameConstraints = id_ce (30) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_ce_nameConstraints = new int [] { 2, 5, 29, 30};
		/// <summary>
		/// id_ce_nameConstraints = id_ce (30) as string
		/// </summary>
		public const string OIDS__id_ce_nameConstraints = "2.5.29.30";



		/// <summary>
		/// id_ce_policyConstraints = id_ce (36) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_ce_policyConstraints = new int [] { 2, 5, 29, 36};
		/// <summary>
		/// id_ce_policyConstraints = id_ce (36) as string
		/// </summary>
		public const string OIDS__id_ce_policyConstraints = "2.5.29.36";



		/// <summary>
		/// id_ce_cRLDistributionPoints = id_ce (31) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_ce_cRLDistributionPoints = new int [] { 2, 5, 29, 31};
		/// <summary>
		/// id_ce_cRLDistributionPoints = id_ce (31) as string
		/// </summary>
		public const string OIDS__id_ce_cRLDistributionPoints = "2.5.29.31";



		/// <summary>
		/// id_ce_extKeyUsage = id_ce (37) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_ce_extKeyUsage = new int [] { 2, 5, 29, 37};
		/// <summary>
		/// id_ce_extKeyUsage = id_ce (37) as string
		/// </summary>
		public const string OIDS__id_ce_extKeyUsage = "2.5.29.37";



		/// <summary>
		/// id_ce_cRLNumber = id_ce (20) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_ce_cRLNumber = new int [] { 2, 5, 29, 20};
		/// <summary>
		/// id_ce_cRLNumber = id_ce (20) as string
		/// </summary>
		public const string OIDS__id_ce_cRLNumber = "2.5.29.20";



		/// <summary>
		/// id_ce_issuingDistributionPoint = id_ce (28) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_ce_issuingDistributionPoint = new int [] { 2, 5, 29, 28};
		/// <summary>
		/// id_ce_issuingDistributionPoint = id_ce (28) as string
		/// </summary>
		public const string OIDS__id_ce_issuingDistributionPoint = "2.5.29.28";



		/// <summary>
		/// id_ce_deltaCRLIndicator = id_ce (27) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_ce_deltaCRLIndicator = new int [] { 2, 5, 29, 27};
		/// <summary>
		/// id_ce_deltaCRLIndicator = id_ce (27) as string
		/// </summary>
		public const string OIDS__id_ce_deltaCRLIndicator = "2.5.29.27";



		/// <summary>
		/// id_ce_cRLReasons = id_ce (21) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_ce_cRLReasons = new int [] { 2, 5, 29, 21};
		/// <summary>
		/// id_ce_cRLReasons = id_ce (21) as string
		/// </summary>
		public const string OIDS__id_ce_cRLReasons = "2.5.29.21";



		/// <summary>
		/// id_ce_certificateIssuer = id_ce (29) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_ce_certificateIssuer = new int [] { 2, 5, 29, 29};
		/// <summary>
		/// id_ce_certificateIssuer = id_ce (29) as string
		/// </summary>
		public const string OIDS__id_ce_certificateIssuer = "2.5.29.29";



		/// <summary>
		/// id_ce_holdInstructionCode = id_ce (23) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_ce_holdInstructionCode = new int [] { 2, 5, 29, 23};
		/// <summary>
		/// id_ce_holdInstructionCode = id_ce (23) as string
		/// </summary>
		public const string OIDS__id_ce_holdInstructionCode = "2.5.29.23";



		/// <summary>
		/// id_ce_invalidityDate = id_ce (24) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_ce_invalidityDate = new int [] { 2, 5, 29, 24};
		/// <summary>
		/// id_ce_invalidityDate = id_ce (24) as string
		/// </summary>
		public const string OIDS__id_ce_invalidityDate = "2.5.29.24";



		/// <summary>
		/// id_ce_inhibitAnyPolicy = id_ce (54) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_ce_inhibitAnyPolicy = new int [] { 2, 5, 29, 54};
		/// <summary>
		/// id_ce_inhibitAnyPolicy = id_ce (54) as string
		/// </summary>
		public const string OIDS__id_ce_inhibitAnyPolicy = "2.5.29.54";



		/// <summary>
		/// id_ce_freshestCRL = id_ce (46) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_ce_freshestCRL = new int [] { 2, 5, 29, 46};
		/// <summary>
		/// id_ce_freshestCRL = id_ce (46) as string
		/// </summary>
		public const string OIDS__id_ce_freshestCRL = "2.5.29.46";


		}
    /// <summary>
    /// holdInstruction =  joint_iso_itu_t(2)  member_body(2)  us(840)  x9cm(10040)  holdInstruction(2) 
    /// </summary>
	public partial class Constants {
		/// <summary>
		/// holdInstruction as integer sequence
		/// </summary>
		public readonly static int [] OID__holdInstruction = new int [] { 2, 2, 840, 10040, 2};
		/// <summary>
		/// holdInstruction as string
		/// </summary>
		public const string OIDS__holdInstruction = "2.2.840.10040.2";


		/// <summary>
		/// id_holdinstruction_none = holdInstruction (1) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_holdinstruction_none = new int [] { 2, 2, 840, 10040, 2, 1};
		/// <summary>
		/// id_holdinstruction_none = holdInstruction (1) as string
		/// </summary>
		public const string OIDS__id_holdinstruction_none = "2.2.840.10040.2.1";



		/// <summary>
		/// id_holdinstruction_callissuer = holdInstruction (2) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_holdinstruction_callissuer = new int [] { 2, 2, 840, 10040, 2, 2};
		/// <summary>
		/// id_holdinstruction_callissuer = holdInstruction (2) as string
		/// </summary>
		public const string OIDS__id_holdinstruction_callissuer = "2.2.840.10040.2.2";



		/// <summary>
		/// id_holdinstruction_reject = holdInstruction (3) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_holdinstruction_reject = new int [] { 2, 2, 840, 10040, 2, 3};
		/// <summary>
		/// id_holdinstruction_reject = holdInstruction (3) as string
		/// </summary>
		public const string OIDS__id_holdinstruction_reject = "2.2.840.10040.2.3";


		}
    /// <summary>
    /// nistalgorithm =  joint_iso_itu_t(2)  country(16)  us(840)  organization(1)  gov(101)  csor(3)  nistalgorithm(4) 
    /// </summary>
	public partial class Constants {
		/// <summary>
		/// nistalgorithm as integer sequence
		/// </summary>
		public readonly static int [] OID__nistalgorithm = new int [] { 2, 16, 840, 1, 101, 3, 4};
		/// <summary>
		/// nistalgorithm as string
		/// </summary>
		public const string OIDS__nistalgorithm = "2.16.840.1.101.3.4";


		/// <summary>
		/// nist_hashalgs = nistalgorithm (2) as integer sequence
		/// </summary>
		public readonly static int [] OID__nist_hashalgs = new int [] { 2, 16, 840, 1, 101, 3, 4, 2};
		/// <summary>
		/// nist_hashalgs = nistalgorithm (2) as string
		/// </summary>
		public const string OIDS__nist_hashalgs = "2.16.840.1.101.3.4.2";



		/// <summary>
		/// id_sha224 = nist_hashalgs (4) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_sha224 = new int [] { 2, 16, 840, 1, 101, 3, 4, 2, 4};
		/// <summary>
		/// id_sha224 = nist_hashalgs (4) as string
		/// </summary>
		public const string OIDS__id_sha224 = "2.16.840.1.101.3.4.2.4";



		/// <summary>
		/// id_sha256 = nist_hashalgs (1) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_sha256 = new int [] { 2, 16, 840, 1, 101, 3, 4, 2, 1};
		/// <summary>
		/// id_sha256 = nist_hashalgs (1) as string
		/// </summary>
		public const string OIDS__id_sha256 = "2.16.840.1.101.3.4.2.1";



		/// <summary>
		/// id_sha384 = nist_hashalgs (2) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_sha384 = new int [] { 2, 16, 840, 1, 101, 3, 4, 2, 2};
		/// <summary>
		/// id_sha384 = nist_hashalgs (2) as string
		/// </summary>
		public const string OIDS__id_sha384 = "2.16.840.1.101.3.4.2.2";



		/// <summary>
		/// id_sha512 = nist_hashalgs (3) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_sha512 = new int [] { 2, 16, 840, 1, 101, 3, 4, 2, 3};
		/// <summary>
		/// id_sha512 = nist_hashalgs (3) as string
		/// </summary>
		public const string OIDS__id_sha512 = "2.16.840.1.101.3.4.2.3";



		/// <summary>
		/// nist_aes = nistalgorithm (1) as integer sequence
		/// </summary>
		public readonly static int [] OID__nist_aes = new int [] { 2, 16, 840, 1, 101, 3, 4, 1};
		/// <summary>
		/// nist_aes = nistalgorithm (1) as string
		/// </summary>
		public const string OIDS__nist_aes = "2.16.840.1.101.3.4.1";



		/// <summary>
		/// id_aes128_ecb = nist_aes (1) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_aes128_ecb = new int [] { 2, 16, 840, 1, 101, 3, 4, 1, 1};
		/// <summary>
		/// id_aes128_ecb = nist_aes (1) as string
		/// </summary>
		public const string OIDS__id_aes128_ecb = "2.16.840.1.101.3.4.1.1";



		/// <summary>
		/// id_aes128_cbc = nist_aes (2) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_aes128_cbc = new int [] { 2, 16, 840, 1, 101, 3, 4, 1, 2};
		/// <summary>
		/// id_aes128_cbc = nist_aes (2) as string
		/// </summary>
		public const string OIDS__id_aes128_cbc = "2.16.840.1.101.3.4.1.2";



		/// <summary>
		/// id_aes128_ofb = nist_aes (3) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_aes128_ofb = new int [] { 2, 16, 840, 1, 101, 3, 4, 1, 3};
		/// <summary>
		/// id_aes128_ofb = nist_aes (3) as string
		/// </summary>
		public const string OIDS__id_aes128_ofb = "2.16.840.1.101.3.4.1.3";



		/// <summary>
		/// id_aes128_cfb = nist_aes (4) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_aes128_cfb = new int [] { 2, 16, 840, 1, 101, 3, 4, 1, 4};
		/// <summary>
		/// id_aes128_cfb = nist_aes (4) as string
		/// </summary>
		public const string OIDS__id_aes128_cfb = "2.16.840.1.101.3.4.1.4";



		/// <summary>
		/// id_aes192_ecb = nist_aes (21) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_aes192_ecb = new int [] { 2, 16, 840, 1, 101, 3, 4, 1, 21};
		/// <summary>
		/// id_aes192_ecb = nist_aes (21) as string
		/// </summary>
		public const string OIDS__id_aes192_ecb = "2.16.840.1.101.3.4.1.21";



		/// <summary>
		/// id_aes192_cbc = nist_aes (22) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_aes192_cbc = new int [] { 2, 16, 840, 1, 101, 3, 4, 1, 22};
		/// <summary>
		/// id_aes192_cbc = nist_aes (22) as string
		/// </summary>
		public const string OIDS__id_aes192_cbc = "2.16.840.1.101.3.4.1.22";



		/// <summary>
		/// id_aes192_ofb = nist_aes (23) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_aes192_ofb = new int [] { 2, 16, 840, 1, 101, 3, 4, 1, 23};
		/// <summary>
		/// id_aes192_ofb = nist_aes (23) as string
		/// </summary>
		public const string OIDS__id_aes192_ofb = "2.16.840.1.101.3.4.1.23";



		/// <summary>
		/// id_aes192_cfb = nist_aes (24) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_aes192_cfb = new int [] { 2, 16, 840, 1, 101, 3, 4, 1, 24};
		/// <summary>
		/// id_aes192_cfb = nist_aes (24) as string
		/// </summary>
		public const string OIDS__id_aes192_cfb = "2.16.840.1.101.3.4.1.24";



		/// <summary>
		/// id_aes256_ecb = nist_aes (41) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_aes256_ecb = new int [] { 2, 16, 840, 1, 101, 3, 4, 1, 41};
		/// <summary>
		/// id_aes256_ecb = nist_aes (41) as string
		/// </summary>
		public const string OIDS__id_aes256_ecb = "2.16.840.1.101.3.4.1.41";



		/// <summary>
		/// id_aes256_cbc = nist_aes (42) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_aes256_cbc = new int [] { 2, 16, 840, 1, 101, 3, 4, 1, 42};
		/// <summary>
		/// id_aes256_cbc = nist_aes (42) as string
		/// </summary>
		public const string OIDS__id_aes256_cbc = "2.16.840.1.101.3.4.1.42";



		/// <summary>
		/// id_aes256_ofb = nist_aes (43) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_aes256_ofb = new int [] { 2, 16, 840, 1, 101, 3, 4, 1, 43};
		/// <summary>
		/// id_aes256_ofb = nist_aes (43) as string
		/// </summary>
		public const string OIDS__id_aes256_ofb = "2.16.840.1.101.3.4.1.43";



		/// <summary>
		/// id_aes256_cfb = nist_aes (44) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_aes256_cfb = new int [] { 2, 16, 840, 1, 101, 3, 4, 1, 44};
		/// <summary>
		/// id_aes256_cfb = nist_aes (44) as string
		/// </summary>
		public const string OIDS__id_aes256_cfb = "2.16.840.1.101.3.4.1.44";


		}
    /// <summary>
    /// dod_arc =  iso(1)  identified_organization(3)  dod(6)  internet(1)  private(4)  enterprise(1)  number(6449)  certificates(1)  categories(3)  certified_delivery(5) 
    /// </summary>
	public partial class Constants {
		/// <summary>
		/// dod_arc as integer sequence
		/// </summary>
		public readonly static int [] OID__dod_arc = new int [] { 1, 3, 6, 1, 4, 1, 6449, 1, 3, 5};
		/// <summary>
		/// dod_arc as string
		/// </summary>
		public const string OIDS__dod_arc = "1.3.6.1.4.1.6449.1.3.5";


		/// <summary>
		/// netscape_smime = dod_arc (2) as integer sequence
		/// </summary>
		public readonly static int [] OID__netscape_smime = new int [] { 1, 3, 6, 1, 4, 1, 6449, 1, 3, 5, 2};
		/// <summary>
		/// netscape_smime = dod_arc (2) as string
		/// </summary>
		public const string OIDS__netscape_smime = "1.3.6.1.4.1.6449.1.3.5.2";


		}
	}


// Generate Classes
namespace Goedel.ASN1 {  // default namespace

	}
namespace Goedel.Cryptography.PKIX {
    /// <summary>
	/// Certificate 
    /// </summary>
	public partial class Certificate : Goedel.ASN1.Root {

		/// <summary>
		/// ASN.1 member Signature 
		/// </summary>
		public byte []  Signature ;
		/// <summary>
		/// ASN.1 member SignatureAlgorithm 
		/// </summary>
		public Goedel.Cryptography.PKIX.AlgorithmIdentifier SignatureAlgorithm ;
		/// <summary>
		/// ASN.1 member TBSCertificate 
		/// </summary>
		public Goedel.Cryptography.PKIX.TBSCertificate TBSCertificate ;

		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN1.Buffer Buffer) {
			int Position = Buffer.Encode__Sequence_Start ();

			Buffer.Encode__Bits  (Signature, 0, -1);
			Buffer.Debug ("Signature");

			Buffer.Encode__Object (SignatureAlgorithm, 0, -1);
			Buffer.Debug ("SignatureAlgorithm");

			Buffer.Encode__Object (TBSCertificate, 0, -1);
			Buffer.Debug ("TBSCertificate");
			Buffer.Encode__Sequence_End (Position);
            }

		}
    /// <summary>
	/// TBSCertificate 
    /// </summary>
	public partial class TBSCertificate : Goedel.ASN1.Root {

		/// <summary>
		/// ASN.1 member Extensions 
		/// </summary>
		public List <Goedel.Cryptography.PKIX.Extension > Extensions ;
		/// <summary>
		/// ASN.1 member SubjectUniqueID 
		/// </summary>
		public byte []  SubjectUniqueID ;
		/// <summary>
		/// ASN.1 member IssuerUniqueID 
		/// </summary>
		public byte []  IssuerUniqueID ;
		/// <summary>
		/// ASN.1 member SubjectPublicKeyInfo 
		/// </summary>
		public Goedel.Cryptography.PKIX.SubjectPublicKeyInfo SubjectPublicKeyInfo ;
		/// <summary>
		/// ASN.1 member Subject 
		/// </summary>
		public List <Goedel.Cryptography.PKIX.Name > Subject ;
		/// <summary>
		/// ASN.1 member Validity 
		/// </summary>
		public Goedel.Cryptography.PKIX.Validity Validity ;
		/// <summary>
		/// ASN.1 member Issuer 
		/// </summary>
		public List <Goedel.Cryptography.PKIX.Name > Issuer ;
		/// <summary>
		/// ASN.1 member Signature 
		/// </summary>
		public Goedel.Cryptography.PKIX.AlgorithmIdentifier Signature ;
		/// <summary>
		/// ASN.1 member SerialNumber 
		/// </summary>
		public byte []  SerialNumber ;
		/// <summary>
		/// ASN.1 member Version 
		/// </summary>
		public int  Version ;

		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN1.Buffer Buffer) {
			int Position = Buffer.Encode__Sequence_Start ();

			if (Extensions == null || Extensions.Count == 0) {
				Buffer.Encode__Object (null, 6, 3);
				}
			else {
				int XPosition = Buffer.Encode__Sequence_Start();
				foreach (Goedel.Cryptography.PKIX.Extension  _Index in Extensions) {
		
			Buffer.Encode__Object (_Index, 0, 0);
					}
				Buffer.Encode__Sequence_End(XPosition, 6, 3);
			}
			Buffer.Debug ("Extensions");

			Buffer.Encode__Bits  (SubjectUniqueID, 5, 2);
			Buffer.Debug ("SubjectUniqueID");

			Buffer.Encode__Bits  (IssuerUniqueID, 5, 1);
			Buffer.Debug ("IssuerUniqueID");

			Buffer.Encode__Object (SubjectPublicKeyInfo, 0, -1);
			Buffer.Debug ("SubjectPublicKeyInfo");

			if (Subject == null || Subject.Count == 0) {
				Buffer.Encode__Object (null, 0, -1);
				}
			else {
				int XPosition = Buffer.Encode__Sequence_Start();
				foreach (Goedel.Cryptography.PKIX.Name  _Index in Subject) {
		
			Buffer.Encode__Object (_Index, 0, 0);
					}
				Buffer.Encode__Sequence_End(XPosition, 0, -1);
			}
			Buffer.Debug ("Subject");

			Buffer.Encode__Object (Validity, 0, -1);
			Buffer.Debug ("Validity");

			if (Issuer == null || Issuer.Count == 0) {
				Buffer.Encode__Object (null, 0, -1);
				}
			else {
				int XPosition = Buffer.Encode__Sequence_Start();
				foreach (Goedel.Cryptography.PKIX.Name  _Index in Issuer) {
		
			Buffer.Encode__Object (_Index, 0, 0);
					}
				Buffer.Encode__Sequence_End(XPosition, 0, -1);
			}
			Buffer.Debug ("Issuer");

			Buffer.Encode__Object (Signature, 0, -1);
			Buffer.Debug ("Signature");

			Buffer.Encode__BigInteger  (SerialNumber, 0, -1);
			Buffer.Debug ("SerialNumber");

			Buffer.Encode__Integer  (Version, 2, 0);
			Buffer.Debug ("Version");
			Buffer.Encode__Sequence_End (Position);
            }

		}
    /// <summary>
	/// SubjectPublicKeyInfo 
    /// </summary>
	public partial class SubjectPublicKeyInfo : Goedel.ASN1.Root {

		/// <summary>
		/// ASN.1 member SubjectPublicKey 
		/// </summary>
		public byte []  SubjectPublicKey ;
		/// <summary>
		/// ASN.1 member Algorithm 
		/// </summary>
		public Goedel.Cryptography.PKIX.AlgorithmIdentifier Algorithm ;

		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN1.Buffer Buffer) {
			int Position = Buffer.Encode__Sequence_Start ();

			Buffer.Encode__Bits  (SubjectPublicKey, 0, -1);
			Buffer.Debug ("SubjectPublicKey");

			Buffer.Encode__Object (Algorithm, 0, -1);
			Buffer.Debug ("Algorithm");
			Buffer.Encode__Sequence_End (Position);
            }

		}
    /// <summary>
	/// DigestInfo 
    /// </summary>
	public partial class DigestInfo : Goedel.ASN1.Root {

		/// <summary>
		/// ASN.1 member SubjectPublicKey 
		/// </summary>
		public byte []  SubjectPublicKey ;
		/// <summary>
		/// ASN.1 member Algorithm 
		/// </summary>
		public Goedel.Cryptography.PKIX.AlgorithmIdentifier Algorithm ;

		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN1.Buffer Buffer) {
			int Position = Buffer.Encode__Sequence_Start ();

			Buffer.Encode__Octets  (SubjectPublicKey, 0, -1);
			Buffer.Debug ("SubjectPublicKey");

			Buffer.Encode__Object (Algorithm, 0, -1);
			Buffer.Debug ("Algorithm");
			Buffer.Encode__Sequence_End (Position);
            }

		}
    /// <summary>
	/// AlgorithmIdentifier 
    /// </summary>
	public partial class AlgorithmIdentifier : Goedel.ASN1.Root {

		/// <summary>
		/// ASN.1 member Parameters 
		/// </summary>
		public List <byte []  > Parameters ;
		/// <summary>
		/// ASN.1 member Algorithm 
		/// </summary>
		public int []  Algorithm ;

		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN1.Buffer Buffer) {
			int Position = Buffer.Encode__Sequence_Start ();

			if (Parameters == null || Parameters.Count == 0) {
				Buffer.Encode__Object (null, 0, -1);
				}
			else {
				int XPosition = Buffer.Encode__Sequence_Start();
				foreach (byte []   _Index in Parameters) {
		
			Buffer.Encode__Any  (_Index, 0, 0);
					}
				Buffer.Encode__Sequence_End(XPosition, 0, -1);
			}
			Buffer.Debug ("Parameters");

			Buffer.Encode__OIDRef  (Algorithm, 0, -1);
			Buffer.Debug ("Algorithm");
			Buffer.Encode__Sequence_End (Position);
            }

		}
    /// <summary>
	/// TaggedBitString 
    /// </summary>
	public partial class TaggedBitString : Goedel.ASN1.Root {

		/// <summary>
		/// ASN.1 member SubjectPublicKey 
		/// </summary>
		public byte []  SubjectPublicKey ;
		/// <summary>
		/// ASN.1 member Algorithm 
		/// </summary>
		public int []  Algorithm ;

		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN1.Buffer Buffer) {
			int Position = Buffer.Encode__Sequence_Start ();

			Buffer.Encode__Bits  (SubjectPublicKey, 0, -1);
			Buffer.Debug ("SubjectPublicKey");

			Buffer.Encode__OIDRef  (Algorithm, 0, -1);
			Buffer.Debug ("Algorithm");
			Buffer.Encode__Sequence_End (Position);
            }

		}
    /// <summary>
	/// Extension 
    /// </summary>
	public partial class Extension : Goedel.ASN1.Root {

		/// <summary>
		/// ASN.1 member Data 
		/// </summary>
		public byte []  Data ;
		/// <summary>
		/// ASN.1 member Critical 
		/// </summary>
		public bool  Critical ;
		/// <summary>
		/// ASN.1 member ObjectIdentifier 
		/// </summary>
		public int []  ObjectIdentifier ;

		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN1.Buffer Buffer) {
			int Position = Buffer.Encode__Sequence_Start ();

			Buffer.Encode__Octets  (Data, 0, -1);
			Buffer.Debug ("Data");

			// Default is false
			if (Critical != false) {
				Buffer.Encode__Boolean (Critical, 4, -1);
				}
			Buffer.Debug ("Critical");

			Buffer.Encode__OIDRef  (ObjectIdentifier, 0, -1);
			Buffer.Debug ("ObjectIdentifier");
			Buffer.Encode__Sequence_End (Position);
            }

		}
    /// <summary>
	/// Validity 
    /// </summary>
	public partial class Validity : Goedel.ASN1.Root {

		/// <summary>
		/// ASN.1 member NotAfter 
		/// </summary>
		public DateTime  NotAfter ;
		/// <summary>
		/// ASN.1 member NotBefore 
		/// </summary>
		public DateTime  NotBefore ;

		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN1.Buffer Buffer) {
			int Position = Buffer.Encode__Sequence_Start ();

			Buffer.Encode__Time  (NotAfter, 0, -1);
			Buffer.Debug ("NotAfter");

			Buffer.Encode__Time  (NotBefore, 0, -1);
			Buffer.Debug ("NotBefore");
			Buffer.Encode__Sequence_End (Position);
            }

		}
    /// <summary>
	/// CertificateList 
    /// </summary>
	public partial class CertificateList : Goedel.ASN1.Root {

		/// <summary>
		/// ASN.1 member Signature 
		/// </summary>
		public Goedel.Cryptography.PKIX.TaggedBitString Signature ;
		/// <summary>
		/// ASN.1 member TBSCertList 
		/// </summary>
		public Goedel.Cryptography.PKIX.TBSCertList TBSCertList ;

		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN1.Buffer Buffer) {
			int Position = Buffer.Encode__Sequence_Start ();

			Buffer.Encode__Object (Signature, 0, -1);
			Buffer.Debug ("Signature");

			Buffer.Encode__Object (TBSCertList, 0, -1);
			Buffer.Debug ("TBSCertList");
			Buffer.Encode__Sequence_End (Position);
            }

		}
    /// <summary>
	/// TBSCertList 
    /// </summary>
	public partial class TBSCertList : Goedel.ASN1.Root {

		/// <summary>
		/// ASN.1 member CrlExtensions 
		/// </summary>
		public List <Goedel.Cryptography.PKIX.Extension > CrlExtensions ;
		/// <summary>
		/// ASN.1 member RevokedCertificates 
		/// </summary>
		public List <Goedel.Cryptography.PKIX.CertEntry > RevokedCertificates ;
		/// <summary>
		/// ASN.1 member NextUpdate 
		/// </summary>
		public DateTime  NextUpdate ;
		/// <summary>
		/// ASN.1 member ThisUpdate 
		/// </summary>
		public DateTime  ThisUpdate ;
		/// <summary>
		/// ASN.1 member Issuer 
		/// </summary>
		public List <Goedel.Cryptography.PKIX.Name > Issuer ;
		/// <summary>
		/// ASN.1 member Signature 
		/// </summary>
		public Goedel.Cryptography.PKIX.AlgorithmIdentifier Signature ;
		/// <summary>
		/// ASN.1 member Version 
		/// </summary>
		public int  Version ;

		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN1.Buffer Buffer) {
			int Position = Buffer.Encode__Sequence_Start ();

			if (CrlExtensions == null || CrlExtensions.Count == 0) {
				Buffer.Encode__Object (null, 2, 0);
				}
			else {
				int XPosition = Buffer.Encode__Sequence_Start();
				foreach (Goedel.Cryptography.PKIX.Extension  _Index in CrlExtensions) {
		
			Buffer.Encode__Object (_Index, 0, 0);
					}
				Buffer.Encode__Sequence_End(XPosition, 2, 0);
			}
			Buffer.Debug ("CrlExtensions");

			if (RevokedCertificates == null || RevokedCertificates.Count == 0) {
				Buffer.Encode__Object (null, 4, -1);
				}
			else {
				int XPosition = Buffer.Encode__Sequence_Start();
				foreach (Goedel.Cryptography.PKIX.CertEntry  _Index in RevokedCertificates) {
		
			Buffer.Encode__Object (_Index, 0, 0);
					}
				Buffer.Encode__Sequence_End(XPosition, 4, -1);
			}
			Buffer.Debug ("RevokedCertificates");

			Buffer.Encode__Time  (NextUpdate, 4, -1);
			Buffer.Debug ("NextUpdate");

			Buffer.Encode__Time  (ThisUpdate, 0, -1);
			Buffer.Debug ("ThisUpdate");

			if (Issuer == null || Issuer.Count == 0) {
				Buffer.Encode__Object (null, 0, -1);
				}
			else {
				int XPosition = Buffer.Encode__Sequence_Start();
				foreach (Goedel.Cryptography.PKIX.Name  _Index in Issuer) {
		
			Buffer.Encode__Object (_Index, 0, 0);
					}
				Buffer.Encode__Sequence_End(XPosition, 0, -1);
			}
			Buffer.Debug ("Issuer");

			Buffer.Encode__Object (Signature, 0, -1);
			Buffer.Debug ("Signature");

			Buffer.Encode__Integer  (Version, 4, -1);
			Buffer.Debug ("Version");
			Buffer.Encode__Sequence_End (Position);
            }

		}
    /// <summary>
	/// CertEntry 
    /// </summary>
	public partial class CertEntry : Goedel.ASN1.Root {

		/// <summary>
		/// ASN.1 member CrlEntryExtensions 
		/// </summary>
		public List <Goedel.Cryptography.PKIX.Extension > CrlEntryExtensions ;
		/// <summary>
		/// ASN.1 member RevocationDate 
		/// </summary>
		public DateTime  RevocationDate ;
		/// <summary>
		/// ASN.1 member UserCertificate 
		/// </summary>
		public byte []  UserCertificate ;

		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN1.Buffer Buffer) {
			int Position = Buffer.Encode__Sequence_Start ();

			if (CrlEntryExtensions == null || CrlEntryExtensions.Count == 0) {
				Buffer.Encode__Object (null, 6, -1);
				}
			else {
				int XPosition = Buffer.Encode__Sequence_Start();
				foreach (Goedel.Cryptography.PKIX.Extension  _Index in CrlEntryExtensions) {
		
			Buffer.Encode__Object (_Index, 0, 0);
					}
				Buffer.Encode__Sequence_End(XPosition, 6, -1);
			}
			Buffer.Debug ("CrlEntryExtensions");

			Buffer.Encode__Time  (RevocationDate, 0, -1);
			Buffer.Debug ("RevocationDate");

			Buffer.Encode__BigInteger  (UserCertificate, 0, -1);
			Buffer.Debug ("UserCertificate");
			Buffer.Encode__Sequence_End (Position);
            }

		}

	// Singular, no sequence boundaries
    /// <summary>
	/// Name 
    /// </summary>
	public partial class Name : Goedel.ASN1.Root {
		/// <summary>
		/// The OID value
		/// </summary>
		public override int [] OID { 
			get { return Constants.OID__id_at; } }  

		/// <summary>
		/// ASN.1 member Member 
		/// </summary>
		public List <Goedel.Cryptography.PKIX.AttributeTypeValue > Member ;
		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN1.Buffer Buffer) {

			if (Member == null || Member.Count == 0) {
				Buffer.Encode__Object (null, 0, -1);
				}
			else {
				int XPosition = Buffer.Encode__Set_Start();
				foreach (Goedel.Cryptography.PKIX.AttributeTypeValue  _Index in Member) {
		
			Buffer.Encode__Object (_Index, 0, 0);
					}
				Buffer.Encode__Set_End(XPosition, 0, -1);
			}
            }
		}

    /// <summary>
	/// AttributeTypeValue 
    /// </summary>
	public partial class AttributeTypeValue : Goedel.ASN1.Root {

		/// <summary>
		/// ASN.1 member Value 
		/// </summary>
		public Goedel.Cryptography.PKIX.AnyString Value ;
		/// <summary>
		/// ASN.1 member Type 
		/// </summary>
		public int []  Type ;

		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN1.Buffer Buffer) {
			int Position = Buffer.Encode__Sequence_Start ();

			Buffer.Encode__Object (Value, 0, -1);
			Buffer.Debug ("Value");

			Buffer.Encode__OIDRef  (Type, 0, -1);
			Buffer.Debug ("Type");
			Buffer.Encode__Sequence_End (Position);
            }

		}

	// Singular, no sequence boundaries
    /// <summary>
	/// AnyString 
    /// </summary>
	public partial class AnyString : Goedel.ASN1.Root {
		/// <summary>
		/// The OID value
		/// </summary>
		public override int [] OID { 
			get { return Constants.OID__id_at; } }  

		/// <summary>
		/// ASN.1 member IA5String 
		/// </summary>
		public string IA5String ;
		/// <summary>
		/// ASN.1 member BMPString 
		/// </summary>
		public string BMPString ;
		/// <summary>
		/// ASN.1 member UTF8String 
		/// </summary>
		public string UTF8String ;
		/// <summary>
		/// ASN.1 member PrintableString 
		/// </summary>
		public string PrintableString ;
		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN1.Buffer Buffer) {

	// Do Choice
            //

			Buffer.Encode__IA5String  (IA5String, 4, -1);
            //

			Buffer.Encode__BMPString  (BMPString, 4, -1);
            //

			Buffer.Encode__UTF8String  (UTF8String, 4, -1);
            //

			Buffer.Encode__PrintableString  (PrintableString, 4, -1);
            }
		}

    /// <summary>
	/// CertificationRequest 
    /// </summary>
	public partial class CertificationRequest : Goedel.ASN1.Root {

		/// <summary>
		/// ASN.1 member Signature 
		/// </summary>
		public byte []  Signature ;
		/// <summary>
		/// ASN.1 member SignatureAlgorithm 
		/// </summary>
		public Goedel.Cryptography.PKIX.AlgorithmIdentifier SignatureAlgorithm ;
		/// <summary>
		/// ASN.1 member CertificationRequestInfo 
		/// </summary>
		public Goedel.Cryptography.PKIX.CertificationRequestInfo CertificationRequestInfo ;

		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN1.Buffer Buffer) {
			int Position = Buffer.Encode__Sequence_Start ();

			Buffer.Encode__Bits  (Signature, 0, -1);
			Buffer.Debug ("Signature");

			Buffer.Encode__Object (SignatureAlgorithm, 0, -1);
			Buffer.Debug ("SignatureAlgorithm");

			Buffer.Encode__Object (CertificationRequestInfo, 0, -1);
			Buffer.Debug ("CertificationRequestInfo");
			Buffer.Encode__Sequence_End (Position);
            }

		}
    /// <summary>
	/// CertificationRequestInfo 
    /// </summary>
	public partial class CertificationRequestInfo : Goedel.ASN1.Root {

		/// <summary>
		/// ASN.1 member Attributes 
		/// </summary>
		public List <Goedel.Cryptography.PKIX.AttributeTypeValues > Attributes ;
		/// <summary>
		/// ASN.1 member SubjectPublicKeyInfo 
		/// </summary>
		public Goedel.Cryptography.PKIX.SubjectPublicKeyInfo SubjectPublicKeyInfo ;
		/// <summary>
		/// ASN.1 member Subject 
		/// </summary>
		public List <Goedel.Cryptography.PKIX.Name > Subject ;
		/// <summary>
		/// ASN.1 member Version 
		/// </summary>
		public int  Version ;

		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN1.Buffer Buffer) {
			int Position = Buffer.Encode__Sequence_Start ();

			if (Attributes == null || Attributes.Count == 0) {
				Buffer.Encode__Object (null, 1, 0);
				}
			else {
				int XPosition = Buffer.Encode__Sequence_Start();
				foreach (Goedel.Cryptography.PKIX.AttributeTypeValues  _Index in Attributes) {
		
			Buffer.Encode__Object (_Index, 0, 0);
					}
				Buffer.Encode__Sequence_End(XPosition, 1, 0);
			}
			Buffer.Debug ("Attributes");

			Buffer.Encode__Object (SubjectPublicKeyInfo, 0, -1);
			Buffer.Debug ("SubjectPublicKeyInfo");

			if (Subject == null || Subject.Count == 0) {
				Buffer.Encode__Object (null, 0, -1);
				}
			else {
				int XPosition = Buffer.Encode__Sequence_Start();
				foreach (Goedel.Cryptography.PKIX.Name  _Index in Subject) {
		
			Buffer.Encode__Object (_Index, 0, 0);
					}
				Buffer.Encode__Sequence_End(XPosition, 0, -1);
			}
			Buffer.Debug ("Subject");

			Buffer.Encode__Integer  (Version, 0, -1);
			Buffer.Debug ("Version");
			Buffer.Encode__Sequence_End (Position);
            }

		}
    /// <summary>
	/// AttributeTypeValues 
    /// </summary>
	public partial class AttributeTypeValues : Goedel.ASN1.Root {

		/// <summary>
		/// ASN.1 member Value 
		/// </summary>
		public List <byte []  > Value ;
		/// <summary>
		/// ASN.1 member Type 
		/// </summary>
		public int []  Type ;

		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN1.Buffer Buffer) {
			int Position = Buffer.Encode__Sequence_Start ();

			if (Value == null || Value.Count == 0) {
				Buffer.Encode__Object (null, 0, -1);
				}
			else {
				int XPosition = Buffer.Encode__Set_Start();
				foreach (byte []   _Index in Value) {
		
			Buffer.Encode__Any  (_Index, 0, 0);
					}
				Buffer.Encode__Set_End(XPosition, 0, -1);
			}
			Buffer.Debug ("Value");

			Buffer.Encode__OIDRef  (Type, 0, -1);
			Buffer.Debug ("Type");
			Buffer.Encode__Sequence_End (Position);
            }

		}
    /// <summary>
	/// RSAPublicKey 
    /// </summary>
	public partial class RSAPublicKey : Goedel.ASN1.Root {

		/// <summary>
		/// ASN.1 member PublicExponent 
		/// </summary>
		public byte []  PublicExponent ;
		/// <summary>
		/// ASN.1 member Modulus 
		/// </summary>
		public byte []  Modulus ;

		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN1.Buffer Buffer) {
			int Position = Buffer.Encode__Sequence_Start ();

			Buffer.Encode__BigInteger  (PublicExponent, 0, -1);
			Buffer.Debug ("PublicExponent");

			Buffer.Encode__BigInteger  (Modulus, 0, -1);
			Buffer.Debug ("Modulus");
			Buffer.Encode__Sequence_End (Position);
            }

		}
    /// <summary>
	/// AuthorityKeyIdentifier 
    /// </summary>
	public partial class AuthorityKeyIdentifier : Goedel.ASN1.Root {
		/// <summary>
		/// The OID value
		/// </summary>
		public override int [] OID { 
			get { return Constants.OID__id_ce_authorityKeyIdentifier; } }  

		/// <summary>
		/// ASN.1 member AuthorityCertSerialNumber 
		/// </summary>
		public int  AuthorityCertSerialNumber ;
		/// <summary>
		/// ASN.1 member AuthorityCertIssuer 
		/// </summary>
		public List <Goedel.Cryptography.PKIX.GeneralName > AuthorityCertIssuer ;
		/// <summary>
		/// ASN.1 member KeyIdentifier 
		/// </summary>
		public byte []  KeyIdentifier ;
		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN1.Buffer Buffer) {
			int Position = Buffer.Encode__Sequence_Start ();

			Buffer.Encode__Integer  (AuthorityCertSerialNumber, 12, 2);

			if (AuthorityCertIssuer == null || AuthorityCertIssuer.Count == 0) {
				Buffer.Encode__Object (null, 12, 1);
				}
			else {
				int XPosition = Buffer.Encode__Sequence_Start();
				foreach (Goedel.Cryptography.PKIX.GeneralName  _Index in AuthorityCertIssuer) {
		
			Buffer.Encode__Object (_Index, 0, 0);
					}
				Buffer.Encode__Sequence_End(XPosition, 12, 1);
			}

			Buffer.Encode__Octets  (KeyIdentifier, 12, 0);
			Buffer.Encode__Sequence_End (Position);
            }
		}


	// Singular, no sequence boundaries
    /// <summary>
	/// SubjectKeyIdentifier 
    /// </summary>
	public partial class SubjectKeyIdentifier : Goedel.ASN1.Root {
		/// <summary>
		/// The OID value
		/// </summary>
		public override int [] OID { 
			get { return Constants.OID__id_ce_subjectKeyIdentifier; } }  

		/// <summary>
		/// ASN.1 member Value 
		/// </summary>
		public byte []  Value ;
		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN1.Buffer Buffer) {

			Buffer.Encode__Octets  (Value, 0, -1);
            }
		}


	// Singular, no sequence boundaries
    /// <summary>
	/// KeyUsage 
    /// </summary>
	public partial class KeyUsage : Goedel.ASN1.Root {
		/// <summary>
		/// The OID value
		/// </summary>
		public override int [] OID { 
			get { return Constants.OID__id_ce_keyUsage; } }  

		/// <summary>
		/// ASN.1 member Value 
		/// </summary>
		public byte []  Value ;
		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN1.Buffer Buffer) {

			Buffer.Encode__VBits  (Value, 0, -1);
            }
		}


	// Singular, no sequence boundaries
    /// <summary>
	/// certificatePolicies 
    /// </summary>
	public partial class certificatePolicies : Goedel.ASN1.Root {
		/// <summary>
		/// The OID value
		/// </summary>
		public override int [] OID { 
			get { return Constants.OID__id_ce_certificatePolicies; } }  

		/// <summary>
		/// ASN.1 member Value 
		/// </summary>
		public List <Goedel.Cryptography.PKIX.PolicyInformation > Value ;
		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN1.Buffer Buffer) {

			if (Value == null || Value.Count == 0) {
				Buffer.Encode__Object (null, 0, -1);
				}
			else {
				int XPosition = Buffer.Encode__Sequence_Start();
				foreach (Goedel.Cryptography.PKIX.PolicyInformation  _Index in Value) {
		
			Buffer.Encode__Object (_Index, 0, 0);
					}
				Buffer.Encode__Sequence_End(XPosition, 0, -1);
			}
            }
		}

    /// <summary>
	/// PolicyInformation 
    /// </summary>
	public partial class PolicyInformation : Goedel.ASN1.Root {

		/// <summary>
		/// ASN.1 member PolicyQualifiers 
		/// </summary>
		public List <Goedel.Cryptography.PKIX.PolicyQualifierInfo > PolicyQualifiers ;
		/// <summary>
		/// ASN.1 member PolicyIdentifier 
		/// </summary>
		public int []  PolicyIdentifier ;

		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN1.Buffer Buffer) {
			int Position = Buffer.Encode__Sequence_Start ();

			if (PolicyQualifiers == null || PolicyQualifiers.Count == 0) {
				Buffer.Encode__Object (null, 4, -1);
				}
			else {
				int XPosition = Buffer.Encode__Sequence_Start();
				foreach (Goedel.Cryptography.PKIX.PolicyQualifierInfo  _Index in PolicyQualifiers) {
		
			Buffer.Encode__Object (_Index, 0, 0);
					}
				Buffer.Encode__Sequence_End(XPosition, 4, -1);
			}
			Buffer.Debug ("PolicyQualifiers");

			Buffer.Encode__OIDRef  (PolicyIdentifier, 0, -1);
			Buffer.Debug ("PolicyIdentifier");
			Buffer.Encode__Sequence_End (Position);
            }

		}
    /// <summary>
	/// PolicyQualifierInfo 
    /// </summary>
	public partial class PolicyQualifierInfo : Goedel.ASN1.Root {

		/// <summary>
		/// ASN.1 member Qualifier 
		/// </summary>
		public byte []  Qualifier ;
		/// <summary>
		/// ASN.1 member PolicyQualifierId 
		/// </summary>
		public int []  PolicyQualifierId ;

		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN1.Buffer Buffer) {
			int Position = Buffer.Encode__Sequence_Start ();

			Buffer.Encode__Any  (Qualifier, 0, -1);
			Buffer.Debug ("Qualifier");

			Buffer.Encode__OIDRef  (PolicyQualifierId, 0, -1);
			Buffer.Debug ("PolicyQualifierId");
			Buffer.Encode__Sequence_End (Position);
            }

		}

	// Singular, no sequence boundaries
    /// <summary>
	/// SubjectAltName 
    /// </summary>
	public partial class SubjectAltName : Goedel.ASN1.Root {
		/// <summary>
		/// The OID value
		/// </summary>
		public override int [] OID { 
			get { return Constants.OID__id_ce_subjectAltName; } }  

		/// <summary>
		/// ASN.1 member Names 
		/// </summary>
		public List <Goedel.Cryptography.PKIX.GeneralName > Names ;
		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN1.Buffer Buffer) {

			if (Names == null || Names.Count == 0) {
				Buffer.Encode__Object (null, 0, -1);
				}
			else {
				int XPosition = Buffer.Encode__Sequence_Start();
				foreach (Goedel.Cryptography.PKIX.GeneralName  _Index in Names) {
		
			Buffer.Encode__Object (_Index, 0, 0);
					}
				Buffer.Encode__Sequence_End(XPosition, 0, -1);
			}
            }
		}


	// Singular, no sequence boundaries
    /// <summary>
	/// GeneralName 
    /// </summary>
	public partial class GeneralName : Goedel.ASN1.Root {
		/// <summary>
		/// The OID value
		/// </summary>
		public override int [] OID { 
			get { return Constants.OID__id_ce_subjectAltName; } }  

		/// <summary>
		/// ASN.1 member DNSName 
		/// </summary>
		public string DNSName ;
		/// <summary>
		/// ASN.1 member RFC822Name 
		/// </summary>
		public string RFC822Name ;
		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN1.Buffer Buffer) {

			Buffer.Encode__IA5String  (DNSName, 12, 2);

			Buffer.Encode__IA5String  (RFC822Name, 12, 1);
            }
		}

    /// <summary>
	/// BasicConstraints 
    /// </summary>
	public partial class BasicConstraints : Goedel.ASN1.Root {
		/// <summary>
		/// The OID value
		/// </summary>
		public override int [] OID { 
			get { return Constants.OID__id_ce_basicConstraints; } }  

		/// <summary>
		/// ASN.1 member PathLenConstraint 
		/// </summary>
		public int  PathLenConstraint ;
		/// <summary>
		/// ASN.1 member CA 
		/// </summary>
		public bool  CA ;
		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN1.Buffer Buffer) {
			int Position = Buffer.Encode__Sequence_Start ();

			Buffer.Encode__Integer  (PathLenConstraint, 4, -1);

			// Default is false
			if (CA != false) {
				Buffer.Encode__Boolean (CA, 0, -1);
				}
			Buffer.Encode__Sequence_End (Position);
            }
		}

    /// <summary>
	/// NameConstraints 
    /// </summary>
	public partial class NameConstraints : Goedel.ASN1.Root {
		/// <summary>
		/// The OID value
		/// </summary>
		public override int [] OID { 
			get { return Constants.OID__id_ce_nameConstraints; } }  

		/// <summary>
		/// ASN.1 member ExcludedSubtrees 
		/// </summary>
		public Goedel.Cryptography.PKIX.GeneralSubtrees ExcludedSubtrees ;
		/// <summary>
		/// ASN.1 member PermittedSubtrees 
		/// </summary>
		public Goedel.Cryptography.PKIX.GeneralSubtrees PermittedSubtrees ;
		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN1.Buffer Buffer) {
			int Position = Buffer.Encode__Sequence_Start ();

			Buffer.Encode__Object (ExcludedSubtrees, 0, 1);

			Buffer.Encode__Object (PermittedSubtrees, 0, 0);
			Buffer.Encode__Sequence_End (Position);
            }
		}

    /// <summary>
	/// GeneralSubtrees 
    /// </summary>
	public partial class GeneralSubtrees : Goedel.ASN1.Root {

		/// <summary>
		/// ASN.1 member Maximum 
		/// </summary>
		public int  Maximum ;
		/// <summary>
		/// ASN.1 member Minimum 
		/// </summary>
		public int  Minimum ;
		/// <summary>
		/// ASN.1 member Base 
		/// </summary>
		public Goedel.Cryptography.PKIX.GeneralName Base ;

		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN1.Buffer Buffer) {
			int Position = Buffer.Encode__Sequence_Start ();

			Buffer.Encode__Integer  (Maximum, 0, 1);
			Buffer.Debug ("Maximum");

			Buffer.Encode__Integer  (Minimum, 0, 0);
			Buffer.Debug ("Minimum");

			Buffer.Encode__Object (Base, 0, -1);
			Buffer.Debug ("Base");
			Buffer.Encode__Sequence_End (Position);
            }

		}

	// Singular, no sequence boundaries
    /// <summary>
	/// ExtendedKeyUsage 
    /// </summary>
	public partial class ExtendedKeyUsage : Goedel.ASN1.Root {
		/// <summary>
		/// The OID value
		/// </summary>
		public override int [] OID { 
			get { return Constants.OID__id_ce_extKeyUsage; } }  

		/// <summary>
		/// ASN.1 member KeyPurpose 
		/// </summary>
		public List <int []  > KeyPurpose ;
		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN1.Buffer Buffer) {

			if (KeyPurpose == null || KeyPurpose.Count == 0) {
				Buffer.Encode__Object (null, 0, -1);
				}
			else {
				int XPosition = Buffer.Encode__Sequence_Start();
				foreach (int []   _Index in KeyPurpose) {
		
			Buffer.Encode__OIDRef  (_Index, 0, 0);
					}
				Buffer.Encode__Sequence_End(XPosition, 0, -1);
			}
            }
		}

    /// <summary>
	/// PFX 
    /// </summary>
	public partial class PFX : Goedel.ASN1.Root {

		/// <summary>
		/// ASN.1 member MacData 
		/// </summary>
		public Goedel.Cryptography.PKIX.MacData MacData ;
		/// <summary>
		/// ASN.1 member AuthSafe 
		/// </summary>
		public Goedel.Cryptography.PKIX.ContentInfo AuthSafe ;
		/// <summary>
		/// ASN.1 member Version 
		/// </summary>
		public int  Version ;

		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN1.Buffer Buffer) {
			int Position = Buffer.Encode__Sequence_Start ();

			Buffer.Encode__Object (MacData, 4, -1);
			Buffer.Debug ("MacData");

			Buffer.Encode__Object (AuthSafe, 0, -1);
			Buffer.Debug ("AuthSafe");

			Buffer.Encode__Integer  (Version, 0, -1);
			Buffer.Debug ("Version");
			Buffer.Encode__Sequence_End (Position);
            }

		}
    /// <summary>
	/// ContentInfo 
    /// </summary>
	public partial class ContentInfo : Goedel.ASN1.Root {

		/// <summary>
		/// ASN.1 member Content 
		/// </summary>
		public byte []  Content ;
		/// <summary>
		/// ASN.1 member ContentType 
		/// </summary>
		public int []  ContentType ;

		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN1.Buffer Buffer) {
			int Position = Buffer.Encode__Sequence_Start ();

			Buffer.Encode__Any  (Content, 2, 0);
			Buffer.Debug ("Content");

			Buffer.Encode__OIDRef  (ContentType, 0, -1);
			Buffer.Debug ("ContentType");
			Buffer.Encode__Sequence_End (Position);
            }

		}
    /// <summary>
	/// MacData 
    /// </summary>
	public partial class MacData : Goedel.ASN1.Root {

		/// <summary>
		/// ASN.1 member Iterations 
		/// </summary>
		public int  Iterations ;
		/// <summary>
		/// ASN.1 member MacSalt 
		/// </summary>
		public byte []  MacSalt ;
		/// <summary>
		/// ASN.1 member MAC 
		/// </summary>
		public Goedel.Cryptography.PKIX.DigestInfo MAC ;

		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN1.Buffer Buffer) {
			int Position = Buffer.Encode__Sequence_Start ();

			// Default is 1
			if (Iterations != 1) {
				Buffer.Encode__Integer (Iterations, 0, -1);
				}
			Buffer.Debug ("Iterations");

			Buffer.Encode__Octets  (MacSalt, 0, -1);
			Buffer.Debug ("MacSalt");

			Buffer.Encode__Object (MAC, 0, -1);
			Buffer.Debug ("MAC");
			Buffer.Encode__Sequence_End (Position);
            }

		}
    /// <summary>
	/// EncryptedData 
    /// </summary>
	public partial class EncryptedData : Goedel.ASN1.Root {

		/// <summary>
		/// ASN.1 member EncryptedContent 
		/// </summary>
		public Goedel.Cryptography.PKIX.EncryptedContentInfo EncryptedContent ;
		/// <summary>
		/// ASN.1 member Version 
		/// </summary>
		public int  Version ;

		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN1.Buffer Buffer) {
			int Position = Buffer.Encode__Sequence_Start ();

			Buffer.Encode__Object (EncryptedContent, 0, -1);
			Buffer.Debug ("EncryptedContent");

			Buffer.Encode__Integer  (Version, 0, -1);
			Buffer.Debug ("Version");
			Buffer.Encode__Sequence_End (Position);
            }

		}
    /// <summary>
	/// EncryptedContentInfo 
    /// </summary>
	public partial class EncryptedContentInfo : Goedel.ASN1.Root {

		/// <summary>
		/// ASN.1 member EncryptedContent 
		/// </summary>
		public byte []  EncryptedContent ;
		/// <summary>
		/// ASN.1 member Algorithm 
		/// </summary>
		public Goedel.Cryptography.PKIX.AlgorithmIdentifier Algorithm ;
		/// <summary>
		/// ASN.1 member ContentType 
		/// </summary>
		public int []  ContentType ;

		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN1.Buffer Buffer) {
			int Position = Buffer.Encode__Sequence_Start ();

			Buffer.Encode__Octets  (EncryptedContent, 5, 0);
			Buffer.Debug ("EncryptedContent");

			Buffer.Encode__Object (Algorithm, 0, -1);
			Buffer.Debug ("Algorithm");

			Buffer.Encode__OIDRef  (ContentType, 0, -1);
			Buffer.Debug ("ContentType");
			Buffer.Encode__Sequence_End (Position);
            }

		}
    /// <summary>
	/// EncryptedPrivateKeyInfo 
    /// </summary>
	public partial class EncryptedPrivateKeyInfo : Goedel.ASN1.Root {

		/// <summary>
		/// ASN.1 member EncryptedData 
		/// </summary>
		public byte []  EncryptedData ;
		/// <summary>
		/// ASN.1 member EncryptionAlgorithm 
		/// </summary>
		public Goedel.Cryptography.PKIX.AlgorithmIdentifier EncryptionAlgorithm ;

		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN1.Buffer Buffer) {
			int Position = Buffer.Encode__Sequence_Start ();

			Buffer.Encode__Octets  (EncryptedData, 0, -1);
			Buffer.Debug ("EncryptedData");

			Buffer.Encode__Object (EncryptionAlgorithm, 0, -1);
			Buffer.Debug ("EncryptionAlgorithm");
			Buffer.Encode__Sequence_End (Position);
            }

		}
    /// <summary>
	/// PrivateKeyInfo 
    /// </summary>
	public partial class PrivateKeyInfo : Goedel.ASN1.Root {

		/// <summary>
		/// ASN.1 member Attributes 
		/// </summary>
		public List <Goedel.Cryptography.PKIX.AttributeTypeValues > Attributes ;
		/// <summary>
		/// ASN.1 member PrivateKey 
		/// </summary>
		public byte []  PrivateKey ;
		/// <summary>
		/// ASN.1 member PrivateKeyAlgorithm 
		/// </summary>
		public Goedel.Cryptography.PKIX.AlgorithmIdentifier PrivateKeyAlgorithm ;
		/// <summary>
		/// ASN.1 member Version 
		/// </summary>
		public int  Version ;

		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN1.Buffer Buffer) {
			int Position = Buffer.Encode__Sequence_Start ();

			if (Attributes == null || Attributes.Count == 0) {
				Buffer.Encode__Object (null, 1, 0);
				}
			else {
				int XPosition = Buffer.Encode__Set_Start();
				foreach (Goedel.Cryptography.PKIX.AttributeTypeValues  _Index in Attributes) {
		
			Buffer.Encode__Object (_Index, 0, 0);
					}
				Buffer.Encode__Set_End(XPosition, 1, 0);
			}
			Buffer.Debug ("Attributes");

			Buffer.Encode__Octets  (PrivateKey, 0, -1);
			Buffer.Debug ("PrivateKey");

			Buffer.Encode__Object (PrivateKeyAlgorithm, 0, -1);
			Buffer.Debug ("PrivateKeyAlgorithm");

			Buffer.Encode__Integer  (Version, 0, -1);
			Buffer.Debug ("Version");
			Buffer.Encode__Sequence_End (Position);
            }

		}
    /// <summary>
	/// RSAPrivateKey 
    /// </summary>
	public partial class RSAPrivateKey : Goedel.ASN1.Root {

		/// <summary>
		/// ASN.1 member Coefficient 
		/// </summary>
		public byte []  Coefficient ;
		/// <summary>
		/// ASN.1 member Exponent2 
		/// </summary>
		public byte []  Exponent2 ;
		/// <summary>
		/// ASN.1 member Exponent1 
		/// </summary>
		public byte []  Exponent1 ;
		/// <summary>
		/// ASN.1 member Prime2 
		/// </summary>
		public byte []  Prime2 ;
		/// <summary>
		/// ASN.1 member Prime1 
		/// </summary>
		public byte []  Prime1 ;
		/// <summary>
		/// ASN.1 member PrivateExponent 
		/// </summary>
		public byte []  PrivateExponent ;
		/// <summary>
		/// ASN.1 member PublicExponent 
		/// </summary>
		public byte []  PublicExponent ;
		/// <summary>
		/// ASN.1 member Modulus 
		/// </summary>
		public byte []  Modulus ;
		/// <summary>
		/// ASN.1 member Version 
		/// </summary>
		public int  Version ;

		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN1.Buffer Buffer) {
			int Position = Buffer.Encode__Sequence_Start ();

			Buffer.Encode__BigInteger  (Coefficient, 0, -1);
			Buffer.Debug ("Coefficient");

			Buffer.Encode__BigInteger  (Exponent2, 0, -1);
			Buffer.Debug ("Exponent2");

			Buffer.Encode__BigInteger  (Exponent1, 0, -1);
			Buffer.Debug ("Exponent1");

			Buffer.Encode__BigInteger  (Prime2, 0, -1);
			Buffer.Debug ("Prime2");

			Buffer.Encode__BigInteger  (Prime1, 0, -1);
			Buffer.Debug ("Prime1");

			Buffer.Encode__BigInteger  (PrivateExponent, 0, -1);
			Buffer.Debug ("PrivateExponent");

			Buffer.Encode__BigInteger  (PublicExponent, 0, -1);
			Buffer.Debug ("PublicExponent");

			Buffer.Encode__BigInteger  (Modulus, 0, -1);
			Buffer.Debug ("Modulus");

			Buffer.Encode__Integer  (Version, 0, -1);
			Buffer.Debug ("Version");
			Buffer.Encode__Sequence_End (Position);
            }

		}
    /// <summary>
	/// Endorsement 
    /// </summary>
	public partial class Endorsement : Goedel.ASN1.Root {

		/// <summary>
		/// ASN.1 member Signature 
		/// </summary>
		public byte []  Signature ;
		/// <summary>
		/// ASN.1 member SignatureAlgorithm 
		/// </summary>
		public Goedel.Cryptography.PKIX.AlgorithmIdentifier SignatureAlgorithm ;
		/// <summary>
		/// ASN.1 member TBSEndorsement 
		/// </summary>
		public Goedel.Cryptography.PKIX.TBSEndorsement TBSEndorsement ;

		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN1.Buffer Buffer) {
			int Position = Buffer.Encode__Sequence_Start ();

			Buffer.Encode__Bits  (Signature, 0, -1);
			Buffer.Debug ("Signature");

			Buffer.Encode__Object (SignatureAlgorithm, 0, -1);
			Buffer.Debug ("SignatureAlgorithm");

			Buffer.Encode__Object (TBSEndorsement, 0, -1);
			Buffer.Debug ("TBSEndorsement");
			Buffer.Encode__Sequence_End (Position);
            }

		}
    /// <summary>
	/// TBSEndorsement 
    /// </summary>
	public partial class TBSEndorsement : Goedel.ASN1.Root {

		/// <summary>
		/// ASN.1 member Extensions 
		/// </summary>
		public List <Goedel.Cryptography.PKIX.Extension > Extensions ;
		/// <summary>
		/// ASN.1 member SubjectAltName 
		/// </summary>
		public List <Goedel.Cryptography.PKIX.SubjectAltName > SubjectAltName ;
		/// <summary>
		/// ASN.1 member Subject 
		/// </summary>
		public List <Goedel.Cryptography.PKIX.Name > Subject ;
		/// <summary>
		/// ASN.1 member SubjectKeyIdentifier 
		/// </summary>
		public byte []  SubjectKeyIdentifier ;
		/// <summary>
		/// ASN.1 member IssuerKeyIdentifier 
		/// </summary>
		public byte []  IssuerKeyIdentifier ;
		/// <summary>
		/// ASN.1 member Issued 
		/// </summary>
		public DateTime  Issued ;
		/// <summary>
		/// ASN.1 member Version 
		/// </summary>
		public int  Version ;

		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN1.Buffer Buffer) {
			int Position = Buffer.Encode__Sequence_Start ();

			if (Extensions == null || Extensions.Count == 0) {
				Buffer.Encode__Object (null, 0, -1);
				}
			else {
				int XPosition = Buffer.Encode__Sequence_Start();
				foreach (Goedel.Cryptography.PKIX.Extension  _Index in Extensions) {
		
			Buffer.Encode__Object (_Index, 0, 0);
					}
				Buffer.Encode__Sequence_End(XPosition, 0, -1);
			}
			Buffer.Debug ("Extensions");

			if (SubjectAltName == null || SubjectAltName.Count == 0) {
				Buffer.Encode__Object (null, 0, -1);
				}
			else {
				int XPosition = Buffer.Encode__Sequence_Start();
				foreach (Goedel.Cryptography.PKIX.SubjectAltName  _Index in SubjectAltName) {
		
			Buffer.Encode__Object (_Index, 0, 0);
					}
				Buffer.Encode__Sequence_End(XPosition, 0, -1);
			}
			Buffer.Debug ("SubjectAltName");

			if (Subject == null || Subject.Count == 0) {
				Buffer.Encode__Object (null, 0, -1);
				}
			else {
				int XPosition = Buffer.Encode__Sequence_Start();
				foreach (Goedel.Cryptography.PKIX.Name  _Index in Subject) {
		
			Buffer.Encode__Object (_Index, 0, 0);
					}
				Buffer.Encode__Sequence_End(XPosition, 0, -1);
			}
			Buffer.Debug ("Subject");

			Buffer.Encode__Octets  (SubjectKeyIdentifier, 0, -1);
			Buffer.Debug ("SubjectKeyIdentifier");

			Buffer.Encode__Octets  (IssuerKeyIdentifier, 0, -1);
			Buffer.Debug ("IssuerKeyIdentifier");

			Buffer.Encode__Time  (Issued, 0, -1);
			Buffer.Debug ("Issued");

			Buffer.Encode__Integer  (Version, 0, -1);
			Buffer.Debug ("Version");
			Buffer.Encode__Sequence_End (Position);
            }

		}
	}

