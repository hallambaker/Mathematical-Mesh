
//  This file was automatically generated at 6/10/2024 6:25:34 PM
//   
//  Changes to this file may be overwritten without warning
//  
//  Generator:  asn2 version 3.0.0.864
//      Goedel Script Version : 0.1   Generated 
//      Goedel Schema Version : 0.1   Generated
//  
//      Copyright : © 2015-2021
//  
//  Build Platform: Win32NT 10.0.22631.0
//  
//  
using System;
using System.Collections.Generic;
using System.Text;
using Goedel.ASN;

// This is the generated code Don't edit.


// Generate OID declarations
#pragma warning disable IDE0022
#pragma warning disable CA1707
#pragma warning disable CA1051
#pragma warning disable CA1062

namespace Goedel.ASN {  // default namespace

	}
namespace Goedel.Cryptography.PKIX {

    /// <summary>
    /// id_pkix =  iso(1)  identified_organization(3)  dod(6)  internet(1)  security(5)  mechanisms(5)  pkix(7) 
    /// </summary>
	public static partial class Constants {
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
	public static partial class Constants {
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
    /// rsadsi =  iso(1)  member_body(2)  us(840)  rsadsi(113549) 
    /// </summary>
	public static partial class Constants {
		/// <summary>
		/// rsadsi as integer sequence
		/// </summary>
		public readonly static int [] OID__rsadsi = new int [] { 1, 2, 840, 113549};
		/// <summary>
		/// rsadsi as string
		/// </summary>
		public const string OIDS__rsadsi = "1.2.840.113549";


		/// <summary>
		/// pkcs = rsadsi (1) as integer sequence
		/// </summary>
		public readonly static int [] OID__pkcs = new int [] { 1, 2, 840, 113549, 1};
		/// <summary>
		/// pkcs = rsadsi (1) as string
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
		/// rsaOAEPEncryptionSET = pkcs_1 (6) as integer sequence
		/// </summary>
		public readonly static int [] OID__rsaOAEPEncryptionSET = new int [] { 1, 2, 840, 113549, 1, 1, 6};
		/// <summary>
		/// rsaOAEPEncryptionSET = pkcs_1 (6) as string
		/// </summary>
		public const string OIDS__rsaOAEPEncryptionSET = "1.2.840.113549.1.1.6";



		/// <summary>
		/// id_RSAES_OAEP = pkcs_1 (7) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_RSAES_OAEP = new int [] { 1, 2, 840, 113549, 1, 1, 7};
		/// <summary>
		/// id_RSAES_OAEP = pkcs_1 (7) as string
		/// </summary>
		public const string OIDS__id_RSAES_OAEP = "1.2.840.113549.1.1.7";



		/// <summary>
		/// rsassa_pss = pkcs_1 (10) as integer sequence
		/// </summary>
		public readonly static int [] OID__rsassa_pss = new int [] { 1, 2, 840, 113549, 1, 1, 10};
		/// <summary>
		/// rsassa_pss = pkcs_1 (10) as string
		/// </summary>
		public const string OIDS__rsassa_pss = "1.2.840.113549.1.1.10";



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



		/// <summary>
		/// digestAlgorithm = rsadsi (2) as integer sequence
		/// </summary>
		public readonly static int [] OID__digestAlgorithm = new int [] { 1, 2, 840, 113549, 2};
		/// <summary>
		/// digestAlgorithm = rsadsi (2) as string
		/// </summary>
		public const string OIDS__digestAlgorithm = "1.2.840.113549.2";



		/// <summary>
		/// id_hmacWithSHA224 = digestAlgorithm (8) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_hmacWithSHA224 = new int [] { 1, 2, 840, 113549, 2, 8};
		/// <summary>
		/// id_hmacWithSHA224 = digestAlgorithm (8) as string
		/// </summary>
		public const string OIDS__id_hmacWithSHA224 = "1.2.840.113549.2.8";



		/// <summary>
		/// id_hmacWithSHA256 = digestAlgorithm (9) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_hmacWithSHA256 = new int [] { 1, 2, 840, 113549, 2, 9};
		/// <summary>
		/// id_hmacWithSHA256 = digestAlgorithm (9) as string
		/// </summary>
		public const string OIDS__id_hmacWithSHA256 = "1.2.840.113549.2.9";



		/// <summary>
		/// id_hmacWithSHA384 = digestAlgorithm (10) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_hmacWithSHA384 = new int [] { 1, 2, 840, 113549, 2, 10};
		/// <summary>
		/// id_hmacWithSHA384 = digestAlgorithm (10) as string
		/// </summary>
		public const string OIDS__id_hmacWithSHA384 = "1.2.840.113549.2.10";



		/// <summary>
		/// id_hmacWithSHA512 = digestAlgorithm (11) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_hmacWithSHA512 = new int [] { 1, 2, 840, 113549, 2, 11};
		/// <summary>
		/// id_hmacWithSHA512 = digestAlgorithm (11) as string
		/// </summary>
		public const string OIDS__id_hmacWithSHA512 = "1.2.840.113549.2.11";


		}
    /// <summary>
    /// id_ce =  joint_iso_ccitt(2)  ds(5)  ce(29) 
    /// </summary>
	public static partial class Constants {
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
	public static partial class Constants {
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
	public static partial class Constants {
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
		/// id_aes128_wrap = nist_aes (5) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_aes128_wrap = new int [] { 2, 16, 840, 1, 101, 3, 4, 1, 5};
		/// <summary>
		/// id_aes128_wrap = nist_aes (5) as string
		/// </summary>
		public const string OIDS__id_aes128_wrap = "2.16.840.1.101.3.4.1.5";



		/// <summary>
		/// id_aes128_gcm = nist_aes (6) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_aes128_gcm = new int [] { 2, 16, 840, 1, 101, 3, 4, 1, 6};
		/// <summary>
		/// id_aes128_gcm = nist_aes (6) as string
		/// </summary>
		public const string OIDS__id_aes128_gcm = "2.16.840.1.101.3.4.1.6";



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
		/// id_aes192_wrap = nist_aes (25) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_aes192_wrap = new int [] { 2, 16, 840, 1, 101, 3, 4, 1, 25};
		/// <summary>
		/// id_aes192_wrap = nist_aes (25) as string
		/// </summary>
		public const string OIDS__id_aes192_wrap = "2.16.840.1.101.3.4.1.25";



		/// <summary>
		/// id_aes192_gcm = nist_aes (26) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_aes192_gcm = new int [] { 2, 16, 840, 1, 101, 3, 4, 1, 26};
		/// <summary>
		/// id_aes192_gcm = nist_aes (26) as string
		/// </summary>
		public const string OIDS__id_aes192_gcm = "2.16.840.1.101.3.4.1.26";



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



		/// <summary>
		/// id_aes256_wrap = nist_aes (45) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_aes256_wrap = new int [] { 2, 16, 840, 1, 101, 3, 4, 1, 45};
		/// <summary>
		/// id_aes256_wrap = nist_aes (45) as string
		/// </summary>
		public const string OIDS__id_aes256_wrap = "2.16.840.1.101.3.4.1.45";



		/// <summary>
		/// id_aes256_gcm = nist_aes (46) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_aes256_gcm = new int [] { 2, 16, 840, 1, 101, 3, 4, 1, 46};
		/// <summary>
		/// id_aes256_gcm = nist_aes (46) as string
		/// </summary>
		public const string OIDS__id_aes256_gcm = "2.16.840.1.101.3.4.1.46";


		}
    /// <summary>
    /// dod_arc =  iso(1)  identified_organization(3)  dod(6)  internet(1)  private(4)  enterprise(1)  number(6449)  certificates(1)  categories(3)  certified_delivery(5) 
    /// </summary>
	public static partial class Constants {
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
    /// <summary>
    /// dds_arc =  iso(1)  identified_organization(3)  dod(6)  internet(1)  private(4)  enterprise(1)  number(35405) 
    /// </summary>
	public static partial class Constants {
		/// <summary>
		/// dds_arc as integer sequence
		/// </summary>
		public readonly static int [] OID__dds_arc = new int [] { 1, 3, 6, 1, 4, 1, 35405};
		/// <summary>
		/// dds_arc as string
		/// </summary>
		public const string OIDS__dds_arc = "1.3.6.1.4.1.35405";


		/// <summary>
		/// dds_algorithms = dds_arc (1) as integer sequence
		/// </summary>
		public readonly static int [] OID__dds_algorithms = new int [] { 1, 3, 6, 1, 4, 1, 35405, 1};
		/// <summary>
		/// dds_algorithms = dds_arc (1) as string
		/// </summary>
		public const string OIDS__dds_algorithms = "1.3.6.1.4.1.35405.1";



		/// <summary>
		/// dds_algorithms_dh = dds_algorithms (22) as integer sequence
		/// </summary>
		public readonly static int [] OID__dds_algorithms_dh = new int [] { 1, 3, 6, 1, 4, 1, 35405, 1, 22};
		/// <summary>
		/// dds_algorithms_dh = dds_algorithms (22) as string
		/// </summary>
		public const string OIDS__dds_algorithms_dh = "1.3.6.1.4.1.35405.1.22";



		/// <summary>
		/// id_dh_domain = dds_algorithms_dh (0) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_dh_domain = new int [] { 1, 3, 6, 1, 4, 1, 35405, 1, 22, 0};
		/// <summary>
		/// id_dh_domain = dds_algorithms_dh (0) as string
		/// </summary>
		public const string OIDS__id_dh_domain = "1.3.6.1.4.1.35405.1.22.0";



		/// <summary>
		/// id_dh_public = dds_algorithms_dh (1) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_dh_public = new int [] { 1, 3, 6, 1, 4, 1, 35405, 1, 22, 1};
		/// <summary>
		/// id_dh_public = dds_algorithms_dh (1) as string
		/// </summary>
		public const string OIDS__id_dh_public = "1.3.6.1.4.1.35405.1.22.1";



		/// <summary>
		/// id_dh_private = dds_algorithms_dh (2) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_dh_private = new int [] { 1, 3, 6, 1, 4, 1, 35405, 1, 22, 2};
		/// <summary>
		/// id_dh_private = dds_algorithms_dh (2) as string
		/// </summary>
		public const string OIDS__id_dh_private = "1.3.6.1.4.1.35405.1.22.2";


		}
    /// <summary>
    /// id_crfg_curve_algs =  iso(1)  identified_organization(3)  Thawte(101) 
    /// </summary>
	public static partial class Constants {
		/// <summary>
		/// id_crfg_curve_algs as integer sequence
		/// </summary>
		public readonly static int [] OID__id_crfg_curve_algs = new int [] { 1, 3, 101};
		/// <summary>
		/// id_crfg_curve_algs as string
		/// </summary>
		public const string OIDS__id_crfg_curve_algs = "1.3.101";


		/// <summary>
		/// id_X25519 = id_crfg_curve_algs (110) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_X25519 = new int [] { 1, 3, 101, 110};
		/// <summary>
		/// id_X25519 = id_crfg_curve_algs (110) as string
		/// </summary>
		public const string OIDS__id_X25519 = "1.3.101.110";



		/// <summary>
		/// id_X448 = id_crfg_curve_algs (111) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_X448 = new int [] { 1, 3, 101, 111};
		/// <summary>
		/// id_X448 = id_crfg_curve_algs (111) as string
		/// </summary>
		public const string OIDS__id_X448 = "1.3.101.111";



		/// <summary>
		/// id_Ed25519 = id_crfg_curve_algs (112) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_Ed25519 = new int [] { 1, 3, 101, 112};
		/// <summary>
		/// id_Ed25519 = id_crfg_curve_algs (112) as string
		/// </summary>
		public const string OIDS__id_Ed25519 = "1.3.101.112";



		/// <summary>
		/// id_Ed448 = id_crfg_curve_algs (113) as integer sequence
		/// </summary>
		public readonly static int [] OID__id_Ed448 = new int [] { 1, 3, 101, 113};
		/// <summary>
		/// id_Ed448 = id_crfg_curve_algs (113) as string
		/// </summary>
		public const string OIDS__id_Ed448 = "1.3.101.113";


		}
	}


// Generate Classes
namespace Goedel.ASN {  // default namespace

	}
namespace Goedel.Cryptography.PKIX {
    /// <summary>
	/// Certificate 
    /// </summary>
	public partial class Certificate : Goedel.ASN.Root {

		/// <summary> ASN.1 member TBSCertificate </summary>
		public Goedel.Cryptography.PKIX.TBSCertificate TBSCertificate  {get; set;}

		/// <summary> ASN.1 member SignatureAlgorithm </summary>
		public Goedel.Cryptography.PKIX.AlgorithmIdentifier SignatureAlgorithm  {get; set;}

		/// <summary> ASN.1 member Signature </summary>
		public byte []  Signature  {get; set;}


		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN.Buffer Buffer) {
			int Position = Buffer.Encode__Sequence_Start ();

			Buffer.Encode__Bits  (Signature, 0, -1);
			Buffer.Debug ("Signature");

			Buffer.Encode__Object (SignatureAlgorithm, 0, -1);
			Buffer.Debug ("SignatureAlgorithm");

			Buffer.Encode__Object (TBSCertificate, 0, -1);
			Buffer.Debug ("TBSCertificate");
			Buffer.Encode__Sequence_End (Position);
            }

			/*
		/// <summary>
		/// Decode buffer to populate class members
		///
		/// This is done in the forward direction
		/// </summary>
        public override void Decode (Goedel.ASN.Buffer Buffer) {
			int Position = Buffer.Decode__Sequence_Start ();

			Buffer.Decode__Object (TBSCertificate, 0, -1);
			Buffer.Debug ("TBSCertificate");

			Buffer.Decode__Object (SignatureAlgorithm, 0, -1);
			Buffer.Debug ("SignatureAlgorithm");

			Buffer.Decode__Bits  (Signature, 0, -1);
			Buffer.Debug ("Signature");
			Buffer.Decode__Sequence_End (Position);
            }
			*/

		}
    /// <summary>
	/// TBSCertificate 
    /// </summary>
	public partial class TBSCertificate : Goedel.ASN.Root {

		/// <summary> ASN.1 member Version </summary>
		public int  Version  {get; set;}

		/// <summary> ASN.1 member SerialNumber </summary>
		public byte []  SerialNumber  {get; set;}

		/// <summary> ASN.1 member Signature </summary>
		public Goedel.Cryptography.PKIX.AlgorithmIdentifier Signature  {get; set;}

		/// <summary> ASN.1 member Issuer </summary>
		public List <Goedel.Cryptography.PKIX.Name > Issuer  {get; set;}

		/// <summary> ASN.1 member Validity </summary>
		public Goedel.Cryptography.PKIX.Validity Validity  {get; set;}

		/// <summary> ASN.1 member Subject </summary>
		public List <Goedel.Cryptography.PKIX.Name > Subject  {get; set;}

		/// <summary> ASN.1 member SubjectPublicKeyInfo </summary>
		public Goedel.Cryptography.PKIX.SubjectPublicKeyInfo SubjectPublicKeyInfo  {get; set;}

		/// <summary> ASN.1 member IssuerUniqueID </summary>
		public byte []  IssuerUniqueID  {get; set;}

		/// <summary> ASN.1 member SubjectUniqueID </summary>
		public byte []  SubjectUniqueID  {get; set;}

		/// <summary> ASN.1 member Extensions </summary>
		public List <Goedel.Cryptography.PKIX.Extension > Extensions  {get; set;}


		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN.Buffer Buffer) {
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

			/*
		/// <summary>
		/// Decode buffer to populate class members
		///
		/// This is done in the forward direction
		/// </summary>
        public override void Decode (Goedel.ASN.Buffer Buffer) {
			int Position = Buffer.Decode__Sequence_Start ();

			Buffer.Encode__Integer  (Version, 2, 0);
			Buffer.Debug ("Version");

			Buffer.Decode__BigInteger  (SerialNumber, 0, -1);
			Buffer.Debug ("SerialNumber");

			Buffer.Decode__Object (Signature, 0, -1);
			Buffer.Debug ("Signature");

			if (Issuer == null || Issuer.Count == 0) {
				Buffer.Decode__Object (null, 0, -1);
				}
			else {
				int XPosition = Buffer.Decode__Sequence_Start();
				foreach (Goedel.Cryptography.PKIX.Name  _Index in Issuer) {
		
			Buffer.Encode__Object (_Index, 0, 0);
					}
				Buffer.Decode__Sequence_End(XPosition, 0, -1);
			}
			Buffer.Debug ("Issuer");

			Buffer.Decode__Object (Validity, 0, -1);
			Buffer.Debug ("Validity");

			if (Subject == null || Subject.Count == 0) {
				Buffer.Decode__Object (null, 0, -1);
				}
			else {
				int XPosition = Buffer.Decode__Sequence_Start();
				foreach (Goedel.Cryptography.PKIX.Name  _Index in Subject) {
		
			Buffer.Encode__Object (_Index, 0, 0);
					}
				Buffer.Decode__Sequence_End(XPosition, 0, -1);
			}
			Buffer.Debug ("Subject");

			Buffer.Decode__Object (SubjectPublicKeyInfo, 0, -1);
			Buffer.Debug ("SubjectPublicKeyInfo");

			Buffer.Decode__Bits  (IssuerUniqueID, 5, 1);
			Buffer.Debug ("IssuerUniqueID");

			Buffer.Decode__Bits  (SubjectUniqueID, 5, 2);
			Buffer.Debug ("SubjectUniqueID");

			if (Extensions == null || Extensions.Count == 0) {
				Buffer.Decode__Object (null, 6, 3);
				}
			else {
				int XPosition = Buffer.Decode__Sequence_Start();
				foreach (Goedel.Cryptography.PKIX.Extension  _Index in Extensions) {
		
			Buffer.Encode__Object (_Index, 0, 0);
					}
				Buffer.Decode__Sequence_End(XPosition, 6, 3);
			}
			Buffer.Debug ("Extensions");
			Buffer.Decode__Sequence_End (Position);
            }
			*/

		}
    /// <summary>
	/// SubjectPublicKeyInfo 
    /// </summary>
	public partial class SubjectPublicKeyInfo : Goedel.ASN.Root {

		/// <summary> ASN.1 member Algorithm </summary>
		public Goedel.Cryptography.PKIX.AlgorithmIdentifier Algorithm  {get; set;}

		/// <summary> ASN.1 member SubjectPublicKey </summary>
		public byte []  SubjectPublicKey  {get; set;}


		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN.Buffer Buffer) {
			int Position = Buffer.Encode__Sequence_Start ();

			Buffer.Encode__Bits  (SubjectPublicKey, 0, -1);
			Buffer.Debug ("SubjectPublicKey");

			Buffer.Encode__Object (Algorithm, 0, -1);
			Buffer.Debug ("Algorithm");
			Buffer.Encode__Sequence_End (Position);
            }

			/*
		/// <summary>
		/// Decode buffer to populate class members
		///
		/// This is done in the forward direction
		/// </summary>
        public override void Decode (Goedel.ASN.Buffer Buffer) {
			int Position = Buffer.Decode__Sequence_Start ();

			Buffer.Decode__Object (Algorithm, 0, -1);
			Buffer.Debug ("Algorithm");

			Buffer.Decode__Bits  (SubjectPublicKey, 0, -1);
			Buffer.Debug ("SubjectPublicKey");
			Buffer.Decode__Sequence_End (Position);
            }
			*/

		}
    /// <summary>
	/// DigestInfo 
    /// </summary>
	public partial class DigestInfo : Goedel.ASN.Root {

		/// <summary> ASN.1 member Algorithm </summary>
		public Goedel.Cryptography.PKIX.AlgorithmIdentifier Algorithm  {get; set;}

		/// <summary> ASN.1 member SubjectPublicKey </summary>
		public byte []  SubjectPublicKey  {get; set;}


		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN.Buffer Buffer) {
			int Position = Buffer.Encode__Sequence_Start ();

			Buffer.Encode__Octets  (SubjectPublicKey, 0, -1);
			Buffer.Debug ("SubjectPublicKey");

			Buffer.Encode__Object (Algorithm, 0, -1);
			Buffer.Debug ("Algorithm");
			Buffer.Encode__Sequence_End (Position);
            }

			/*
		/// <summary>
		/// Decode buffer to populate class members
		///
		/// This is done in the forward direction
		/// </summary>
        public override void Decode (Goedel.ASN.Buffer Buffer) {
			int Position = Buffer.Decode__Sequence_Start ();

			Buffer.Decode__Object (Algorithm, 0, -1);
			Buffer.Debug ("Algorithm");

			Buffer.Decode__Octets  (SubjectPublicKey, 0, -1);
			Buffer.Debug ("SubjectPublicKey");
			Buffer.Decode__Sequence_End (Position);
            }
			*/

		}
    /// <summary>
	/// AlgorithmIdentifier 
    /// </summary>
	public partial class AlgorithmIdentifier : Goedel.ASN.Root {

		/// <summary> ASN.1 member Algorithm </summary>
		public int []  Algorithm  {get; set;}

		/// <summary> ASN.1 member Parameters </summary>
		public List <byte []  > Parameters  {get; set;}


		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN.Buffer Buffer) {
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

			/*
		/// <summary>
		/// Decode buffer to populate class members
		///
		/// This is done in the forward direction
		/// </summary>
        public override void Decode (Goedel.ASN.Buffer Buffer) {
			int Position = Buffer.Decode__Sequence_Start ();

			Buffer.Decode__OIDRef  (Algorithm, 0, -1);
			Buffer.Debug ("Algorithm");

			if (Parameters == null || Parameters.Count == 0) {
				Buffer.Decode__Object (null, 0, -1);
				}
			else {
				int XPosition = Buffer.Decode__Sequence_Start();
				foreach (byte []   _Index in Parameters) {
		
			Buffer.Encode__Any  (_Index, 0, 0);
					}
				Buffer.Decode__Sequence_End(XPosition, 0, -1);
			}
			Buffer.Debug ("Parameters");
			Buffer.Decode__Sequence_End (Position);
            }
			*/

		}
    /// <summary>
	/// TaggedBitString 
    /// </summary>
	public partial class TaggedBitString : Goedel.ASN.Root {

		/// <summary> ASN.1 member Algorithm </summary>
		public int []  Algorithm  {get; set;}

		/// <summary> ASN.1 member SubjectPublicKey </summary>
		public byte []  SubjectPublicKey  {get; set;}


		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN.Buffer Buffer) {
			int Position = Buffer.Encode__Sequence_Start ();

			Buffer.Encode__Bits  (SubjectPublicKey, 0, -1);
			Buffer.Debug ("SubjectPublicKey");

			Buffer.Encode__OIDRef  (Algorithm, 0, -1);
			Buffer.Debug ("Algorithm");
			Buffer.Encode__Sequence_End (Position);
            }

			/*
		/// <summary>
		/// Decode buffer to populate class members
		///
		/// This is done in the forward direction
		/// </summary>
        public override void Decode (Goedel.ASN.Buffer Buffer) {
			int Position = Buffer.Decode__Sequence_Start ();

			Buffer.Decode__OIDRef  (Algorithm, 0, -1);
			Buffer.Debug ("Algorithm");

			Buffer.Decode__Bits  (SubjectPublicKey, 0, -1);
			Buffer.Debug ("SubjectPublicKey");
			Buffer.Decode__Sequence_End (Position);
            }
			*/

		}
    /// <summary>
	/// Extension 
    /// </summary>
	public partial class Extension : Goedel.ASN.Root {

		/// <summary> ASN.1 member ObjectIdentifier </summary>
		public int []  ObjectIdentifier  {get; set;}

		/// <summary> ASN.1 member Critical </summary>
		public bool  Critical  {get; set;}

		/// <summary> ASN.1 member Data </summary>
		public byte []  Data  {get; set;}


		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN.Buffer Buffer) {
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

			/*
		/// <summary>
		/// Decode buffer to populate class members
		///
		/// This is done in the forward direction
		/// </summary>
        public override void Decode (Goedel.ASN.Buffer Buffer) {
			int Position = Buffer.Decode__Sequence_Start ();

			Buffer.Decode__OIDRef  (ObjectIdentifier, 0, -1);
			Buffer.Debug ("ObjectIdentifier");

			// Default is false
			if (Critical != false) {
				Buffer.Decode__Boolean (Critical, 4, -1);
				}
			Buffer.Debug ("Critical");

			Buffer.Decode__Octets  (Data, 0, -1);
			Buffer.Debug ("Data");
			Buffer.Decode__Sequence_End (Position);
            }
			*/

		}
    /// <summary>
	/// Validity 
    /// </summary>
	public partial class Validity : Goedel.ASN.Root {

		/// <summary> ASN.1 member NotBefore </summary>
		public DateTime  NotBefore  {get; set;}

		/// <summary> ASN.1 member NotAfter </summary>
		public DateTime  NotAfter  {get; set;}


		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN.Buffer Buffer) {
			int Position = Buffer.Encode__Sequence_Start ();

			Buffer.Encode__Time  (NotAfter, 0, -1);
			Buffer.Debug ("NotAfter");

			Buffer.Encode__Time  (NotBefore, 0, -1);
			Buffer.Debug ("NotBefore");
			Buffer.Encode__Sequence_End (Position);
            }

			/*
		/// <summary>
		/// Decode buffer to populate class members
		///
		/// This is done in the forward direction
		/// </summary>
        public override void Decode (Goedel.ASN.Buffer Buffer) {
			int Position = Buffer.Decode__Sequence_Start ();

			Buffer.EDecode__Time  (NotBefore, 0, -1);
			Buffer.Debug ("NotBefore");

			Buffer.EDecode__Time  (NotAfter, 0, -1);
			Buffer.Debug ("NotAfter");
			Buffer.Decode__Sequence_End (Position);
            }
			*/

		}
    /// <summary>
	/// CertificateList 
    /// </summary>
	public partial class CertificateList : Goedel.ASN.Root {

		/// <summary> ASN.1 member TBSCertList </summary>
		public Goedel.Cryptography.PKIX.TBSCertList TBSCertList  {get; set;}

		/// <summary> ASN.1 member Signature </summary>
		public Goedel.Cryptography.PKIX.TaggedBitString Signature  {get; set;}


		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN.Buffer Buffer) {
			int Position = Buffer.Encode__Sequence_Start ();

			Buffer.Encode__Object (Signature, 0, -1);
			Buffer.Debug ("Signature");

			Buffer.Encode__Object (TBSCertList, 0, -1);
			Buffer.Debug ("TBSCertList");
			Buffer.Encode__Sequence_End (Position);
            }

			/*
		/// <summary>
		/// Decode buffer to populate class members
		///
		/// This is done in the forward direction
		/// </summary>
        public override void Decode (Goedel.ASN.Buffer Buffer) {
			int Position = Buffer.Decode__Sequence_Start ();

			Buffer.Decode__Object (TBSCertList, 0, -1);
			Buffer.Debug ("TBSCertList");

			Buffer.Decode__Object (Signature, 0, -1);
			Buffer.Debug ("Signature");
			Buffer.Decode__Sequence_End (Position);
            }
			*/

		}
    /// <summary>
	/// TBSCertList 
    /// </summary>
	public partial class TBSCertList : Goedel.ASN.Root {

		/// <summary> ASN.1 member Version </summary>
		public int  Version  {get; set;}

		/// <summary> ASN.1 member Signature </summary>
		public Goedel.Cryptography.PKIX.AlgorithmIdentifier Signature  {get; set;}

		/// <summary> ASN.1 member Issuer </summary>
		public List <Goedel.Cryptography.PKIX.Name > Issuer  {get; set;}

		/// <summary> ASN.1 member ThisUpdate </summary>
		public DateTime  ThisUpdate  {get; set;}

		/// <summary> ASN.1 member NextUpdate </summary>
		public DateTime  NextUpdate  {get; set;}

		/// <summary> ASN.1 member RevokedCertificates </summary>
		public List <Goedel.Cryptography.PKIX.CertEntry > RevokedCertificates  {get; set;}

		/// <summary> ASN.1 member CrlExtensions </summary>
		public List <Goedel.Cryptography.PKIX.Extension > CrlExtensions  {get; set;}


		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN.Buffer Buffer) {
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

			/*
		/// <summary>
		/// Decode buffer to populate class members
		///
		/// This is done in the forward direction
		/// </summary>
        public override void Decode (Goedel.ASN.Buffer Buffer) {
			int Position = Buffer.Decode__Sequence_Start ();

			Buffer.Encode__Integer  (Version, 4, -1);
			Buffer.Debug ("Version");

			Buffer.Decode__Object (Signature, 0, -1);
			Buffer.Debug ("Signature");

			if (Issuer == null || Issuer.Count == 0) {
				Buffer.Decode__Object (null, 0, -1);
				}
			else {
				int XPosition = Buffer.Decode__Sequence_Start();
				foreach (Goedel.Cryptography.PKIX.Name  _Index in Issuer) {
		
			Buffer.Encode__Object (_Index, 0, 0);
					}
				Buffer.Decode__Sequence_End(XPosition, 0, -1);
			}
			Buffer.Debug ("Issuer");

			Buffer.EDecode__Time  (ThisUpdate, 0, -1);
			Buffer.Debug ("ThisUpdate");

			Buffer.EDecode__Time  (NextUpdate, 4, -1);
			Buffer.Debug ("NextUpdate");

			if (RevokedCertificates == null || RevokedCertificates.Count == 0) {
				Buffer.Decode__Object (null, 4, -1);
				}
			else {
				int XPosition = Buffer.Decode__Sequence_Start();
				foreach (Goedel.Cryptography.PKIX.CertEntry  _Index in RevokedCertificates) {
		
			Buffer.Encode__Object (_Index, 0, 0);
					}
				Buffer.Decode__Sequence_End(XPosition, 4, -1);
			}
			Buffer.Debug ("RevokedCertificates");

			if (CrlExtensions == null || CrlExtensions.Count == 0) {
				Buffer.Decode__Object (null, 2, 0);
				}
			else {
				int XPosition = Buffer.Decode__Sequence_Start();
				foreach (Goedel.Cryptography.PKIX.Extension  _Index in CrlExtensions) {
		
			Buffer.Encode__Object (_Index, 0, 0);
					}
				Buffer.Decode__Sequence_End(XPosition, 2, 0);
			}
			Buffer.Debug ("CrlExtensions");
			Buffer.Decode__Sequence_End (Position);
            }
			*/

		}
    /// <summary>
	/// CertEntry 
    /// </summary>
	public partial class CertEntry : Goedel.ASN.Root {

		/// <summary> ASN.1 member UserCertificate </summary>
		public byte []  UserCertificate  {get; set;}

		/// <summary> ASN.1 member RevocationDate </summary>
		public DateTime  RevocationDate  {get; set;}

		/// <summary> ASN.1 member CrlEntryExtensions </summary>
		public List <Goedel.Cryptography.PKIX.Extension > CrlEntryExtensions  {get; set;}


		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN.Buffer Buffer) {
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

			/*
		/// <summary>
		/// Decode buffer to populate class members
		///
		/// This is done in the forward direction
		/// </summary>
        public override void Decode (Goedel.ASN.Buffer Buffer) {
			int Position = Buffer.Decode__Sequence_Start ();

			Buffer.Decode__BigInteger  (UserCertificate, 0, -1);
			Buffer.Debug ("UserCertificate");

			Buffer.EDecode__Time  (RevocationDate, 0, -1);
			Buffer.Debug ("RevocationDate");

			if (CrlEntryExtensions == null || CrlEntryExtensions.Count == 0) {
				Buffer.Decode__Object (null, 6, -1);
				}
			else {
				int XPosition = Buffer.Decode__Sequence_Start();
				foreach (Goedel.Cryptography.PKIX.Extension  _Index in CrlEntryExtensions) {
		
			Buffer.Encode__Object (_Index, 0, 0);
					}
				Buffer.Decode__Sequence_End(XPosition, 6, -1);
			}
			Buffer.Debug ("CrlEntryExtensions");
			Buffer.Decode__Sequence_End (Position);
            }
			*/

		}

	// Singular, no sequence boundaries
    /// <summary>
	/// Name 
    /// </summary>
	public partial class Name : Goedel.ASN.Root {
		/// <summary>
		/// The OID value
		/// </summary>
		public override int [] OID  => Constants.OID__id_at;  

		/// <summary> ASN.1 member Member </summary>
		public List <Goedel.Cryptography.PKIX.AttributeTypeValue > Member  {get; set;}

		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN.Buffer Buffer) {

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

			/*
		/// <summary>
		/// Decode buffer to populate class members
		///
		/// This is done in the forward direction
		/// </summary>
        public override void Decode (Goedel.ASN.Buffer Buffer) {
			int Position = Buffer.Decode__Sequence_Start ();

			if (Member == null || Member.Count == 0) {
				Buffer.Decode__Object (null, 0, -1);
				}
			else {
				int XPosition = Decode.Encode__Set_Start();
				foreach (Goedel.Cryptography.PKIX.AttributeTypeValue  _Index in Member) {
		
			Buffer.Encode__Object (_Index, 0, 0);
					}
				Buffer.Decode__Set_End(XPosition, 0, -1);
			}
			Buffer.Debug ("Member");
			Buffer.Decode__Sequence_End (Position);
            }
			*/

		}

    /// <summary>
	/// AttributeTypeValue 
    /// </summary>
	public partial class AttributeTypeValue : Goedel.ASN.Root {

		/// <summary> ASN.1 member Type </summary>
		public int []  Type  {get; set;}

		/// <summary> ASN.1 member Value </summary>
		public Goedel.Cryptography.PKIX.AnyString Value  {get; set;}


		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN.Buffer Buffer) {
			int Position = Buffer.Encode__Sequence_Start ();

			Buffer.Encode__Object (Value, 0, -1);
			Buffer.Debug ("Value");

			Buffer.Encode__OIDRef  (Type, 0, -1);
			Buffer.Debug ("Type");
			Buffer.Encode__Sequence_End (Position);
            }

			/*
		/// <summary>
		/// Decode buffer to populate class members
		///
		/// This is done in the forward direction
		/// </summary>
        public override void Decode (Goedel.ASN.Buffer Buffer) {
			int Position = Buffer.Decode__Sequence_Start ();

			Buffer.Decode__OIDRef  (Type, 0, -1);
			Buffer.Debug ("Type");

			Buffer.Decode__Object (Value, 0, -1);
			Buffer.Debug ("Value");
			Buffer.Decode__Sequence_End (Position);
            }
			*/

		}

	// Singular, no sequence boundaries
    /// <summary>
	/// AnyString 
    /// </summary>
	public partial class AnyString : Goedel.ASN.Root {
		/// <summary>
		/// The OID value
		/// </summary>
		public override int [] OID  => Constants.OID__id_at;  

		/// <summary> ASN.1 member IA5String </summary>
		public string IA5String  {get; set;}

		/// <summary> ASN.1 member BMPString </summary>
		public string BMPString  {get; set;}

		/// <summary> ASN.1 member UTF8String </summary>
		public string UTF8String  {get; set;}

		/// <summary> ASN.1 member PrintableString </summary>
		public string PrintableString  {get; set;}

		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN.Buffer Buffer) {

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

			/*
		/// <summary>
		/// Decode buffer to populate class members
		///
		/// This is done in the forward direction
		/// </summary>
        public override void Decode (Goedel.ASN.Buffer Buffer) {
			int Position = Buffer.Decode__Sequence_Start ();

	// Do Choice
            //

			Buffer.Encode__IA5String  (IA5String, 4, -1);
            //

			Buffer.Encode__BMPString  (BMPString, 4, -1);
            //

			Buffer.Encode__UTF8String  (UTF8String, 4, -1);
            //

			Buffer.Encode__PrintableString  (PrintableString, 4, -1);
			Buffer.Debug ("Value");
			Buffer.Decode__Sequence_End (Position);
            }
			*/

		}

    /// <summary>
	/// CertificationRequest 
    /// </summary>
	public partial class CertificationRequest : Goedel.ASN.Root {

		/// <summary> ASN.1 member CertificationRequestInfo </summary>
		public Goedel.Cryptography.PKIX.CertificationRequestInfo CertificationRequestInfo  {get; set;}

		/// <summary> ASN.1 member SignatureAlgorithm </summary>
		public Goedel.Cryptography.PKIX.AlgorithmIdentifier SignatureAlgorithm  {get; set;}

		/// <summary> ASN.1 member Signature </summary>
		public byte []  Signature  {get; set;}


		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN.Buffer Buffer) {
			int Position = Buffer.Encode__Sequence_Start ();

			Buffer.Encode__Bits  (Signature, 0, -1);
			Buffer.Debug ("Signature");

			Buffer.Encode__Object (SignatureAlgorithm, 0, -1);
			Buffer.Debug ("SignatureAlgorithm");

			Buffer.Encode__Object (CertificationRequestInfo, 0, -1);
			Buffer.Debug ("CertificationRequestInfo");
			Buffer.Encode__Sequence_End (Position);
            }

			/*
		/// <summary>
		/// Decode buffer to populate class members
		///
		/// This is done in the forward direction
		/// </summary>
        public override void Decode (Goedel.ASN.Buffer Buffer) {
			int Position = Buffer.Decode__Sequence_Start ();

			Buffer.Decode__Object (CertificationRequestInfo, 0, -1);
			Buffer.Debug ("CertificationRequestInfo");

			Buffer.Decode__Object (SignatureAlgorithm, 0, -1);
			Buffer.Debug ("SignatureAlgorithm");

			Buffer.Decode__Bits  (Signature, 0, -1);
			Buffer.Debug ("Signature");
			Buffer.Decode__Sequence_End (Position);
            }
			*/

		}
    /// <summary>
	/// CertificationRequestInfo 
    /// </summary>
	public partial class CertificationRequestInfo : Goedel.ASN.Root {

		/// <summary> ASN.1 member Version </summary>
		public int  Version  {get; set;}

		/// <summary> ASN.1 member Subject </summary>
		public List <Goedel.Cryptography.PKIX.Name > Subject  {get; set;}

		/// <summary> ASN.1 member SubjectPublicKeyInfo </summary>
		public Goedel.Cryptography.PKIX.SubjectPublicKeyInfo SubjectPublicKeyInfo  {get; set;}

		/// <summary> ASN.1 member Attributes </summary>
		public List <Goedel.Cryptography.PKIX.AttributeTypeValues > Attributes  {get; set;}


		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN.Buffer Buffer) {
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

			/*
		/// <summary>
		/// Decode buffer to populate class members
		///
		/// This is done in the forward direction
		/// </summary>
        public override void Decode (Goedel.ASN.Buffer Buffer) {
			int Position = Buffer.Decode__Sequence_Start ();

			Buffer.Encode__Integer  (Version, 0, -1);
			Buffer.Debug ("Version");

			if (Subject == null || Subject.Count == 0) {
				Buffer.Decode__Object (null, 0, -1);
				}
			else {
				int XPosition = Buffer.Decode__Sequence_Start();
				foreach (Goedel.Cryptography.PKIX.Name  _Index in Subject) {
		
			Buffer.Encode__Object (_Index, 0, 0);
					}
				Buffer.Decode__Sequence_End(XPosition, 0, -1);
			}
			Buffer.Debug ("Subject");

			Buffer.Decode__Object (SubjectPublicKeyInfo, 0, -1);
			Buffer.Debug ("SubjectPublicKeyInfo");

			if (Attributes == null || Attributes.Count == 0) {
				Buffer.Decode__Object (null, 1, 0);
				}
			else {
				int XPosition = Buffer.Decode__Sequence_Start();
				foreach (Goedel.Cryptography.PKIX.AttributeTypeValues  _Index in Attributes) {
		
			Buffer.Encode__Object (_Index, 0, 0);
					}
				Buffer.Decode__Sequence_End(XPosition, 1, 0);
			}
			Buffer.Debug ("Attributes");
			Buffer.Decode__Sequence_End (Position);
            }
			*/

		}
    /// <summary>
	/// AttributeTypeValues 
    /// </summary>
	public partial class AttributeTypeValues : Goedel.ASN.Root {

		/// <summary> ASN.1 member Type </summary>
		public int []  Type  {get; set;}

		/// <summary> ASN.1 member Value </summary>
		public List <byte []  > Value  {get; set;}


		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN.Buffer Buffer) {
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

			/*
		/// <summary>
		/// Decode buffer to populate class members
		///
		/// This is done in the forward direction
		/// </summary>
        public override void Decode (Goedel.ASN.Buffer Buffer) {
			int Position = Buffer.Decode__Sequence_Start ();

			Buffer.Decode__OIDRef  (Type, 0, -1);
			Buffer.Debug ("Type");

			if (Value == null || Value.Count == 0) {
				Buffer.Decode__Object (null, 0, -1);
				}
			else {
				int XPosition = Decode.Encode__Set_Start();
				foreach (byte []   _Index in Value) {
		
			Buffer.Encode__Any  (_Index, 0, 0);
					}
				Buffer.Decode__Set_End(XPosition, 0, -1);
			}
			Buffer.Debug ("Value");
			Buffer.Decode__Sequence_End (Position);
            }
			*/

		}
    /// <summary>
	/// AuthorityKeyIdentifier 
    /// </summary>
	public partial class AuthorityKeyIdentifier : Goedel.ASN.Root {
		/// <summary>
		/// The OID value
		/// </summary>
		public override int [] OID => Constants.OID__id_ce_authorityKeyIdentifier; 

		/// <summary> ASN.1 member KeyIdentifier </summary>
		public byte []  KeyIdentifier  {get; set;}

		/// <summary> ASN.1 member AuthorityCertIssuer </summary>
		public List <Goedel.Cryptography.PKIX.GeneralName > AuthorityCertIssuer  {get; set;}

		/// <summary> ASN.1 member AuthorityCertSerialNumber </summary>
		public int  AuthorityCertSerialNumber  {get; set;}

		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN.Buffer Buffer) {
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

			/*
		/// <summary>
		/// Decode buffer to populate class members
		///
		/// This is done in the forward direction
		/// </summary>
        public override void Decode (Goedel.ASN.Buffer Buffer) {
			int Position = Buffer.Decode__Sequence_Start ();

			Buffer.Decode__Octets  (KeyIdentifier, 12, 0);
			Buffer.Debug ("KeyIdentifier");

			if (AuthorityCertIssuer == null || AuthorityCertIssuer.Count == 0) {
				Buffer.Decode__Object (null, 12, 1);
				}
			else {
				int XPosition = Buffer.Decode__Sequence_Start();
				foreach (Goedel.Cryptography.PKIX.GeneralName  _Index in AuthorityCertIssuer) {
		
			Buffer.Encode__Object (_Index, 0, 0);
					}
				Buffer.Decode__Sequence_End(XPosition, 12, 1);
			}
			Buffer.Debug ("AuthorityCertIssuer");

			Buffer.Encode__Integer  (AuthorityCertSerialNumber, 12, 2);
			Buffer.Debug ("AuthorityCertSerialNumber");
			Buffer.Decode__Sequence_End (Position);
            }
			*/
		}


	// Singular, no sequence boundaries
    /// <summary>
	/// SubjectKeyIdentifier 
    /// </summary>
	public partial class SubjectKeyIdentifier : Goedel.ASN.Root {
		/// <summary>
		/// The OID value
		/// </summary>
		public override int [] OID  => Constants.OID__id_ce_subjectKeyIdentifier;  

		/// <summary> ASN.1 member Value </summary>
		public byte []  Value  {get; set;}

		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN.Buffer Buffer) {

			Buffer.Encode__Octets  (Value, 0, -1);
            }

			/*
		/// <summary>
		/// Decode buffer to populate class members
		///
		/// This is done in the forward direction
		/// </summary>
        public override void Decode (Goedel.ASN.Buffer Buffer) {
			int Position = Buffer.Decode__Sequence_Start ();

			Buffer.Decode__Octets  (Value, 0, -1);
			Buffer.Debug ("Value");
			Buffer.Decode__Sequence_End (Position);
            }
			*/

		}


	// Singular, no sequence boundaries
    /// <summary>
	/// KeyUsage 
    /// </summary>
	public partial class KeyUsage : Goedel.ASN.Root {
		/// <summary>
		/// The OID value
		/// </summary>
		public override int [] OID  => Constants.OID__id_ce_keyUsage;  

		/// <summary> ASN.1 member Value </summary>
		public byte []  Value  {get; set;}

		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN.Buffer Buffer) {

			Buffer.Encode__VBits  (Value, 0, -1);
            }

			/*
		/// <summary>
		/// Decode buffer to populate class members
		///
		/// This is done in the forward direction
		/// </summary>
        public override void Decode (Goedel.ASN.Buffer Buffer) {
			int Position = Buffer.Decode__Sequence_Start ();

			Buffer.Decode__VBits  (Value, 0, -1);
			Buffer.Debug ("Value");
			Buffer.Decode__Sequence_End (Position);
            }
			*/

		}


	// Singular, no sequence boundaries
    /// <summary>
	/// CertificatePolicies 
    /// </summary>
	public partial class CertificatePolicies : Goedel.ASN.Root {
		/// <summary>
		/// The OID value
		/// </summary>
		public override int [] OID  => Constants.OID__id_ce_certificatePolicies;  

		/// <summary> ASN.1 member Value </summary>
		public List <Goedel.Cryptography.PKIX.PolicyInformation > Value  {get; set;}

		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN.Buffer Buffer) {

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

			/*
		/// <summary>
		/// Decode buffer to populate class members
		///
		/// This is done in the forward direction
		/// </summary>
        public override void Decode (Goedel.ASN.Buffer Buffer) {
			int Position = Buffer.Decode__Sequence_Start ();

			if (Value == null || Value.Count == 0) {
				Buffer.Decode__Object (null, 0, -1);
				}
			else {
				int XPosition = Buffer.Decode__Sequence_Start();
				foreach (Goedel.Cryptography.PKIX.PolicyInformation  _Index in Value) {
		
			Buffer.Encode__Object (_Index, 0, 0);
					}
				Buffer.Decode__Sequence_End(XPosition, 0, -1);
			}
			Buffer.Debug ("Value");
			Buffer.Decode__Sequence_End (Position);
            }
			*/

		}

    /// <summary>
	/// PolicyInformation 
    /// </summary>
	public partial class PolicyInformation : Goedel.ASN.Root {

		/// <summary> ASN.1 member PolicyIdentifier </summary>
		public int []  PolicyIdentifier  {get; set;}

		/// <summary> ASN.1 member PolicyQualifiers </summary>
		public List <Goedel.Cryptography.PKIX.PolicyQualifierInfo > PolicyQualifiers  {get; set;}


		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN.Buffer Buffer) {
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

			/*
		/// <summary>
		/// Decode buffer to populate class members
		///
		/// This is done in the forward direction
		/// </summary>
        public override void Decode (Goedel.ASN.Buffer Buffer) {
			int Position = Buffer.Decode__Sequence_Start ();

			Buffer.Decode__OIDRef  (PolicyIdentifier, 0, -1);
			Buffer.Debug ("PolicyIdentifier");

			if (PolicyQualifiers == null || PolicyQualifiers.Count == 0) {
				Buffer.Decode__Object (null, 4, -1);
				}
			else {
				int XPosition = Buffer.Decode__Sequence_Start();
				foreach (Goedel.Cryptography.PKIX.PolicyQualifierInfo  _Index in PolicyQualifiers) {
		
			Buffer.Encode__Object (_Index, 0, 0);
					}
				Buffer.Decode__Sequence_End(XPosition, 4, -1);
			}
			Buffer.Debug ("PolicyQualifiers");
			Buffer.Decode__Sequence_End (Position);
            }
			*/

		}
    /// <summary>
	/// PolicyQualifierInfo 
    /// </summary>
	public partial class PolicyQualifierInfo : Goedel.ASN.Root {

		/// <summary> ASN.1 member PolicyQualifierId </summary>
		public int []  PolicyQualifierId  {get; set;}

		/// <summary> ASN.1 member Qualifier </summary>
		public byte []  Qualifier  {get; set;}


		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN.Buffer Buffer) {
			int Position = Buffer.Encode__Sequence_Start ();

			Buffer.Encode__Any  (Qualifier, 0, -1);
			Buffer.Debug ("Qualifier");

			Buffer.Encode__OIDRef  (PolicyQualifierId, 0, -1);
			Buffer.Debug ("PolicyQualifierId");
			Buffer.Encode__Sequence_End (Position);
            }

			/*
		/// <summary>
		/// Decode buffer to populate class members
		///
		/// This is done in the forward direction
		/// </summary>
        public override void Decode (Goedel.ASN.Buffer Buffer) {
			int Position = Buffer.Decode__Sequence_Start ();

			Buffer.Decode__OIDRef  (PolicyQualifierId, 0, -1);
			Buffer.Debug ("PolicyQualifierId");

			Buffer.Decode__Any  (Qualifier, 0, -1);
			Buffer.Debug ("Qualifier");
			Buffer.Decode__Sequence_End (Position);
            }
			*/

		}

	// Singular, no sequence boundaries
    /// <summary>
	/// SubjectAltName 
    /// </summary>
	public partial class SubjectAltName : Goedel.ASN.Root {
		/// <summary>
		/// The OID value
		/// </summary>
		public override int [] OID  => Constants.OID__id_ce_subjectAltName;  

		/// <summary> ASN.1 member Names </summary>
		public List <Goedel.Cryptography.PKIX.GeneralName > Names  {get; set;}

		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN.Buffer Buffer) {

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

			/*
		/// <summary>
		/// Decode buffer to populate class members
		///
		/// This is done in the forward direction
		/// </summary>
        public override void Decode (Goedel.ASN.Buffer Buffer) {
			int Position = Buffer.Decode__Sequence_Start ();

			if (Names == null || Names.Count == 0) {
				Buffer.Decode__Object (null, 0, -1);
				}
			else {
				int XPosition = Buffer.Decode__Sequence_Start();
				foreach (Goedel.Cryptography.PKIX.GeneralName  _Index in Names) {
		
			Buffer.Encode__Object (_Index, 0, 0);
					}
				Buffer.Decode__Sequence_End(XPosition, 0, -1);
			}
			Buffer.Debug ("Names");
			Buffer.Decode__Sequence_End (Position);
            }
			*/

		}


	// Singular, no sequence boundaries
    /// <summary>
	/// GeneralName 
    /// </summary>
	public partial class GeneralName : Goedel.ASN.Root {
		/// <summary>
		/// The OID value
		/// </summary>
		public override int [] OID  => Constants.OID__id_ce_subjectAltName;  

		/// <summary> ASN.1 member RFC822Name </summary>
		public string RFC822Name  {get; set;}

		/// <summary> ASN.1 member DNSName </summary>
		public string DNSName  {get; set;}

		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN.Buffer Buffer) {

			Buffer.Encode__IA5String  (DNSName, 12, 2);

			Buffer.Encode__IA5String  (RFC822Name, 12, 1);
            }

			/*
		/// <summary>
		/// Decode buffer to populate class members
		///
		/// This is done in the forward direction
		/// </summary>
        public override void Decode (Goedel.ASN.Buffer Buffer) {
			int Position = Buffer.Decode__Sequence_Start ();

			Buffer.Decode__IA5String  (RFC822Name, 12, 1);
			Buffer.Debug ("RFC822Name");

			Buffer.Decode__IA5String  (DNSName, 12, 2);
			Buffer.Debug ("DNSName");
			Buffer.Decode__Sequence_End (Position);
            }
			*/

		}

    /// <summary>
	/// BasicConstraints 
    /// </summary>
	public partial class BasicConstraints : Goedel.ASN.Root {
		/// <summary>
		/// The OID value
		/// </summary>
		public override int [] OID => Constants.OID__id_ce_basicConstraints; 

		/// <summary> ASN.1 member CA </summary>
		public bool  CA  {get; set;}

		/// <summary> ASN.1 member PathLenConstraint </summary>
		public int  PathLenConstraint  {get; set;}

		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN.Buffer Buffer) {
			int Position = Buffer.Encode__Sequence_Start ();

			Buffer.Encode__Integer  (PathLenConstraint, 4, -1);

			// Default is false
			if (CA != false) {
				Buffer.Encode__Boolean (CA, 0, -1);
				}
			Buffer.Encode__Sequence_End (Position);
            }

			/*
		/// <summary>
		/// Decode buffer to populate class members
		///
		/// This is done in the forward direction
		/// </summary>
        public override void Decode (Goedel.ASN.Buffer Buffer) {
			int Position = Buffer.Decode__Sequence_Start ();

			// Default is false
			if (CA != false) {
				Buffer.Decode__Boolean (CA, 0, -1);
				}
			Buffer.Debug ("CA");

			Buffer.Encode__Integer  (PathLenConstraint, 4, -1);
			Buffer.Debug ("PathLenConstraint");
			Buffer.Decode__Sequence_End (Position);
            }
			*/
		}

    /// <summary>
	/// NameConstraints 
    /// </summary>
	public partial class NameConstraints : Goedel.ASN.Root {
		/// <summary>
		/// The OID value
		/// </summary>
		public override int [] OID => Constants.OID__id_ce_nameConstraints; 

		/// <summary> ASN.1 member PermittedSubtrees </summary>
		public Goedel.Cryptography.PKIX.GeneralSubtrees PermittedSubtrees  {get; set;}

		/// <summary> ASN.1 member ExcludedSubtrees </summary>
		public Goedel.Cryptography.PKIX.GeneralSubtrees ExcludedSubtrees  {get; set;}

		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN.Buffer Buffer) {
			int Position = Buffer.Encode__Sequence_Start ();

			Buffer.Encode__Object (ExcludedSubtrees, 0, 1);

			Buffer.Encode__Object (PermittedSubtrees, 0, 0);
			Buffer.Encode__Sequence_End (Position);
            }

			/*
		/// <summary>
		/// Decode buffer to populate class members
		///
		/// This is done in the forward direction
		/// </summary>
        public override void Decode (Goedel.ASN.Buffer Buffer) {
			int Position = Buffer.Decode__Sequence_Start ();

			Buffer.Decode__Object (PermittedSubtrees, 0, 0);
			Buffer.Debug ("PermittedSubtrees");

			Buffer.Decode__Object (ExcludedSubtrees, 0, 1);
			Buffer.Debug ("ExcludedSubtrees");
			Buffer.Decode__Sequence_End (Position);
            }
			*/
		}

    /// <summary>
	/// GeneralSubtrees 
    /// </summary>
	public partial class GeneralSubtrees : Goedel.ASN.Root {

		/// <summary> ASN.1 member Base </summary>
		public Goedel.Cryptography.PKIX.GeneralName Base  {get; set;}

		/// <summary> ASN.1 member Minimum </summary>
		public int  Minimum  {get; set;}

		/// <summary> ASN.1 member Maximum </summary>
		public int  Maximum  {get; set;}


		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN.Buffer Buffer) {
			int Position = Buffer.Encode__Sequence_Start ();

			Buffer.Encode__Integer  (Maximum, 0, 1);
			Buffer.Debug ("Maximum");

			Buffer.Encode__Integer  (Minimum, 0, 0);
			Buffer.Debug ("Minimum");

			Buffer.Encode__Object (Base, 0, -1);
			Buffer.Debug ("Base");
			Buffer.Encode__Sequence_End (Position);
            }

			/*
		/// <summary>
		/// Decode buffer to populate class members
		///
		/// This is done in the forward direction
		/// </summary>
        public override void Decode (Goedel.ASN.Buffer Buffer) {
			int Position = Buffer.Decode__Sequence_Start ();

			Buffer.Decode__Object (Base, 0, -1);
			Buffer.Debug ("Base");

			Buffer.Encode__Integer  (Minimum, 0, 0);
			Buffer.Debug ("Minimum");

			Buffer.Encode__Integer  (Maximum, 0, 1);
			Buffer.Debug ("Maximum");
			Buffer.Decode__Sequence_End (Position);
            }
			*/

		}

	// Singular, no sequence boundaries
    /// <summary>
	/// ExtendedKeyUsage 
    /// </summary>
	public partial class ExtendedKeyUsage : Goedel.ASN.Root {
		/// <summary>
		/// The OID value
		/// </summary>
		public override int [] OID  => Constants.OID__id_ce_extKeyUsage;  

		/// <summary> ASN.1 member KeyPurpose </summary>
		public List <int []  > KeyPurpose  {get; set;}

		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN.Buffer Buffer) {

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

			/*
		/// <summary>
		/// Decode buffer to populate class members
		///
		/// This is done in the forward direction
		/// </summary>
        public override void Decode (Goedel.ASN.Buffer Buffer) {
			int Position = Buffer.Decode__Sequence_Start ();

			if (KeyPurpose == null || KeyPurpose.Count == 0) {
				Buffer.Decode__Object (null, 0, -1);
				}
			else {
				int XPosition = Buffer.Decode__Sequence_Start();
				foreach (int []   _Index in KeyPurpose) {
		
			Buffer.Encode__OIDRef  (_Index, 0, 0);
					}
				Buffer.Decode__Sequence_End(XPosition, 0, -1);
			}
			Buffer.Debug ("KeyPurpose");
			Buffer.Decode__Sequence_End (Position);
            }
			*/

		}

    /// <summary>
	/// PFX 
    /// </summary>
	public partial class PFX : Goedel.ASN.Root {

		/// <summary> ASN.1 member Version </summary>
		public int  Version  {get; set;}

		/// <summary> ASN.1 member AuthSafe </summary>
		public Goedel.Cryptography.PKIX.ContentInfo AuthSafe  {get; set;}

		/// <summary> ASN.1 member MacData </summary>
		public Goedel.Cryptography.PKIX.MacData MacData  {get; set;}


		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN.Buffer Buffer) {
			int Position = Buffer.Encode__Sequence_Start ();

			Buffer.Encode__Object (MacData, 4, -1);
			Buffer.Debug ("MacData");

			Buffer.Encode__Object (AuthSafe, 0, -1);
			Buffer.Debug ("AuthSafe");

			Buffer.Encode__Integer  (Version, 0, -1);
			Buffer.Debug ("Version");
			Buffer.Encode__Sequence_End (Position);
            }

			/*
		/// <summary>
		/// Decode buffer to populate class members
		///
		/// This is done in the forward direction
		/// </summary>
        public override void Decode (Goedel.ASN.Buffer Buffer) {
			int Position = Buffer.Decode__Sequence_Start ();

			Buffer.Encode__Integer  (Version, 0, -1);
			Buffer.Debug ("Version");

			Buffer.Decode__Object (AuthSafe, 0, -1);
			Buffer.Debug ("AuthSafe");

			Buffer.Decode__Object (MacData, 4, -1);
			Buffer.Debug ("MacData");
			Buffer.Decode__Sequence_End (Position);
            }
			*/

		}
    /// <summary>
	/// ContentInfo 
    /// </summary>
	public partial class ContentInfo : Goedel.ASN.Root {

		/// <summary> ASN.1 member ContentType </summary>
		public int []  ContentType  {get; set;}

		/// <summary> ASN.1 member Content </summary>
		public byte []  Content  {get; set;}


		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN.Buffer Buffer) {
			int Position = Buffer.Encode__Sequence_Start ();

			Buffer.Encode__Any  (Content, 2, 0);
			Buffer.Debug ("Content");

			Buffer.Encode__OIDRef  (ContentType, 0, -1);
			Buffer.Debug ("ContentType");
			Buffer.Encode__Sequence_End (Position);
            }

			/*
		/// <summary>
		/// Decode buffer to populate class members
		///
		/// This is done in the forward direction
		/// </summary>
        public override void Decode (Goedel.ASN.Buffer Buffer) {
			int Position = Buffer.Decode__Sequence_Start ();

			Buffer.Decode__OIDRef  (ContentType, 0, -1);
			Buffer.Debug ("ContentType");

			Buffer.Decode__Any  (Content, 2, 0);
			Buffer.Debug ("Content");
			Buffer.Decode__Sequence_End (Position);
            }
			*/

		}
    /// <summary>
	/// MacData 
    /// </summary>
	public partial class MacData : Goedel.ASN.Root {

		/// <summary> ASN.1 member MAC </summary>
		public Goedel.Cryptography.PKIX.DigestInfo MAC  {get; set;}

		/// <summary> ASN.1 member MacSalt </summary>
		public byte []  MacSalt  {get; set;}

		/// <summary> ASN.1 member Iterations </summary>
		public int  Iterations  {get; set;}


		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN.Buffer Buffer) {
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

			/*
		/// <summary>
		/// Decode buffer to populate class members
		///
		/// This is done in the forward direction
		/// </summary>
        public override void Decode (Goedel.ASN.Buffer Buffer) {
			int Position = Buffer.Decode__Sequence_Start ();

			Buffer.Decode__Object (MAC, 0, -1);
			Buffer.Debug ("MAC");

			Buffer.Decode__Octets  (MacSalt, 0, -1);
			Buffer.Debug ("MacSalt");

			// Default is 1
			if (Iterations != 1) {
				Buffer.Decode__Integer (Iterations, 0, -1);
				}
			Buffer.Debug ("Iterations");
			Buffer.Decode__Sequence_End (Position);
            }
			*/

		}
    /// <summary>
	/// EncryptedData 
    /// </summary>
	public partial class EncryptedData : Goedel.ASN.Root {

		/// <summary> ASN.1 member Version </summary>
		public int  Version  {get; set;}

		/// <summary> ASN.1 member EncryptedContent </summary>
		public Goedel.Cryptography.PKIX.EncryptedContentInfo EncryptedContent  {get; set;}


		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN.Buffer Buffer) {
			int Position = Buffer.Encode__Sequence_Start ();

			Buffer.Encode__Object (EncryptedContent, 0, -1);
			Buffer.Debug ("EncryptedContent");

			Buffer.Encode__Integer  (Version, 0, -1);
			Buffer.Debug ("Version");
			Buffer.Encode__Sequence_End (Position);
            }

			/*
		/// <summary>
		/// Decode buffer to populate class members
		///
		/// This is done in the forward direction
		/// </summary>
        public override void Decode (Goedel.ASN.Buffer Buffer) {
			int Position = Buffer.Decode__Sequence_Start ();

			Buffer.Encode__Integer  (Version, 0, -1);
			Buffer.Debug ("Version");

			Buffer.Decode__Object (EncryptedContent, 0, -1);
			Buffer.Debug ("EncryptedContent");
			Buffer.Decode__Sequence_End (Position);
            }
			*/

		}
    /// <summary>
	/// EncryptedContentInfo 
    /// </summary>
	public partial class EncryptedContentInfo : Goedel.ASN.Root {

		/// <summary> ASN.1 member ContentType </summary>
		public int []  ContentType  {get; set;}

		/// <summary> ASN.1 member Algorithm </summary>
		public Goedel.Cryptography.PKIX.AlgorithmIdentifier Algorithm  {get; set;}

		/// <summary> ASN.1 member EncryptedContent </summary>
		public byte []  EncryptedContent  {get; set;}


		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN.Buffer Buffer) {
			int Position = Buffer.Encode__Sequence_Start ();

			Buffer.Encode__Octets  (EncryptedContent, 5, 0);
			Buffer.Debug ("EncryptedContent");

			Buffer.Encode__Object (Algorithm, 0, -1);
			Buffer.Debug ("Algorithm");

			Buffer.Encode__OIDRef  (ContentType, 0, -1);
			Buffer.Debug ("ContentType");
			Buffer.Encode__Sequence_End (Position);
            }

			/*
		/// <summary>
		/// Decode buffer to populate class members
		///
		/// This is done in the forward direction
		/// </summary>
        public override void Decode (Goedel.ASN.Buffer Buffer) {
			int Position = Buffer.Decode__Sequence_Start ();

			Buffer.Decode__OIDRef  (ContentType, 0, -1);
			Buffer.Debug ("ContentType");

			Buffer.Decode__Object (Algorithm, 0, -1);
			Buffer.Debug ("Algorithm");

			Buffer.Decode__Octets  (EncryptedContent, 5, 0);
			Buffer.Debug ("EncryptedContent");
			Buffer.Decode__Sequence_End (Position);
            }
			*/

		}
    /// <summary>
	/// EncryptedPrivateKeyInfo 
    /// </summary>
	public partial class EncryptedPrivateKeyInfo : Goedel.ASN.Root {

		/// <summary> ASN.1 member EncryptionAlgorithm </summary>
		public Goedel.Cryptography.PKIX.AlgorithmIdentifier EncryptionAlgorithm  {get; set;}

		/// <summary> ASN.1 member EncryptedData </summary>
		public byte []  EncryptedData  {get; set;}


		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN.Buffer Buffer) {
			int Position = Buffer.Encode__Sequence_Start ();

			Buffer.Encode__Octets  (EncryptedData, 0, -1);
			Buffer.Debug ("EncryptedData");

			Buffer.Encode__Object (EncryptionAlgorithm, 0, -1);
			Buffer.Debug ("EncryptionAlgorithm");
			Buffer.Encode__Sequence_End (Position);
            }

			/*
		/// <summary>
		/// Decode buffer to populate class members
		///
		/// This is done in the forward direction
		/// </summary>
        public override void Decode (Goedel.ASN.Buffer Buffer) {
			int Position = Buffer.Decode__Sequence_Start ();

			Buffer.Decode__Object (EncryptionAlgorithm, 0, -1);
			Buffer.Debug ("EncryptionAlgorithm");

			Buffer.Decode__Octets  (EncryptedData, 0, -1);
			Buffer.Debug ("EncryptedData");
			Buffer.Decode__Sequence_End (Position);
            }
			*/

		}
    /// <summary>
	/// PrivateKeyInfo 
    /// </summary>
	public partial class PrivateKeyInfo : Goedel.ASN.Root {

		/// <summary> ASN.1 member Version </summary>
		public int  Version  {get; set;}

		/// <summary> ASN.1 member PrivateKeyAlgorithm </summary>
		public Goedel.Cryptography.PKIX.AlgorithmIdentifier PrivateKeyAlgorithm  {get; set;}

		/// <summary> ASN.1 member PrivateKey </summary>
		public byte []  PrivateKey  {get; set;}

		/// <summary> ASN.1 member Attributes </summary>
		public List <Goedel.Cryptography.PKIX.AttributeTypeValues > Attributes  {get; set;}


		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN.Buffer Buffer) {
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

			/*
		/// <summary>
		/// Decode buffer to populate class members
		///
		/// This is done in the forward direction
		/// </summary>
        public override void Decode (Goedel.ASN.Buffer Buffer) {
			int Position = Buffer.Decode__Sequence_Start ();

			Buffer.Encode__Integer  (Version, 0, -1);
			Buffer.Debug ("Version");

			Buffer.Decode__Object (PrivateKeyAlgorithm, 0, -1);
			Buffer.Debug ("PrivateKeyAlgorithm");

			Buffer.Decode__Octets  (PrivateKey, 0, -1);
			Buffer.Debug ("PrivateKey");

			if (Attributes == null || Attributes.Count == 0) {
				Buffer.Decode__Object (null, 1, 0);
				}
			else {
				int XPosition = Decode.Encode__Set_Start();
				foreach (Goedel.Cryptography.PKIX.AttributeTypeValues  _Index in Attributes) {
		
			Buffer.Encode__Object (_Index, 0, 0);
					}
				Buffer.Decode__Set_End(XPosition, 1, 0);
			}
			Buffer.Debug ("Attributes");
			Buffer.Decode__Sequence_End (Position);
            }
			*/

		}
    /// <summary>
	/// PkixPublicKeyRsa 
    /// </summary>
	public partial class PkixPublicKeyRsa : Goedel.ASN.Root {

		/// <summary> ASN.1 member Modulus </summary>
		public byte []  Modulus  {get; set;}

		/// <summary> ASN.1 member PublicExponent </summary>
		public byte []  PublicExponent  {get; set;}


		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN.Buffer Buffer) {
			int Position = Buffer.Encode__Sequence_Start ();

			Buffer.Encode__BigInteger  (PublicExponent, 0, -1);
			Buffer.Debug ("PublicExponent");

			Buffer.Encode__BigInteger  (Modulus, 0, -1);
			Buffer.Debug ("Modulus");
			Buffer.Encode__Sequence_End (Position);
            }

			/*
		/// <summary>
		/// Decode buffer to populate class members
		///
		/// This is done in the forward direction
		/// </summary>
        public override void Decode (Goedel.ASN.Buffer Buffer) {
			int Position = Buffer.Decode__Sequence_Start ();

			Buffer.Decode__BigInteger  (Modulus, 0, -1);
			Buffer.Debug ("Modulus");

			Buffer.Decode__BigInteger  (PublicExponent, 0, -1);
			Buffer.Debug ("PublicExponent");
			Buffer.Decode__Sequence_End (Position);
            }
			*/

		}
    /// <summary>
	/// PkixPrivateKeyRsa 
    /// </summary>
	public partial class PkixPrivateKeyRsa : Goedel.ASN.Root {

		/// <summary> ASN.1 member Version </summary>
		public int  Version  {get; set;}

		/// <summary> ASN.1 member Modulus </summary>
		public byte []  Modulus  {get; set;}

		/// <summary> ASN.1 member PublicExponent </summary>
		public byte []  PublicExponent  {get; set;}

		/// <summary> ASN.1 member PrivateExponent </summary>
		public byte []  PrivateExponent  {get; set;}

		/// <summary> ASN.1 member Prime1 </summary>
		public byte []  Prime1  {get; set;}

		/// <summary> ASN.1 member Prime2 </summary>
		public byte []  Prime2  {get; set;}

		/// <summary> ASN.1 member Exponent1 </summary>
		public byte []  Exponent1  {get; set;}

		/// <summary> ASN.1 member Exponent2 </summary>
		public byte []  Exponent2  {get; set;}

		/// <summary> ASN.1 member Coefficient </summary>
		public byte []  Coefficient  {get; set;}


		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN.Buffer Buffer) {
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

			/*
		/// <summary>
		/// Decode buffer to populate class members
		///
		/// This is done in the forward direction
		/// </summary>
        public override void Decode (Goedel.ASN.Buffer Buffer) {
			int Position = Buffer.Decode__Sequence_Start ();

			Buffer.Encode__Integer  (Version, 0, -1);
			Buffer.Debug ("Version");

			Buffer.Decode__BigInteger  (Modulus, 0, -1);
			Buffer.Debug ("Modulus");

			Buffer.Decode__BigInteger  (PublicExponent, 0, -1);
			Buffer.Debug ("PublicExponent");

			Buffer.Decode__BigInteger  (PrivateExponent, 0, -1);
			Buffer.Debug ("PrivateExponent");

			Buffer.Decode__BigInteger  (Prime1, 0, -1);
			Buffer.Debug ("Prime1");

			Buffer.Decode__BigInteger  (Prime2, 0, -1);
			Buffer.Debug ("Prime2");

			Buffer.Decode__BigInteger  (Exponent1, 0, -1);
			Buffer.Debug ("Exponent1");

			Buffer.Decode__BigInteger  (Exponent2, 0, -1);
			Buffer.Debug ("Exponent2");

			Buffer.Decode__BigInteger  (Coefficient, 0, -1);
			Buffer.Debug ("Coefficient");
			Buffer.Decode__Sequence_End (Position);
            }
			*/

		}
    /// <summary>
	/// DHDomain 
    /// </summary>
	public partial class DHDomain : Goedel.ASN.Root {

		/// <summary> ASN.1 member Modulus </summary>
		public byte []  Modulus  {get; set;}

		/// <summary> ASN.1 member Generator </summary>
		public byte []  Generator  {get; set;}


		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN.Buffer Buffer) {
			int Position = Buffer.Encode__Sequence_Start ();

			Buffer.Encode__BigInteger  (Generator, 0, -1);
			Buffer.Debug ("Generator");

			Buffer.Encode__BigInteger  (Modulus, 0, -1);
			Buffer.Debug ("Modulus");
			Buffer.Encode__Sequence_End (Position);
            }

			/*
		/// <summary>
		/// Decode buffer to populate class members
		///
		/// This is done in the forward direction
		/// </summary>
        public override void Decode (Goedel.ASN.Buffer Buffer) {
			int Position = Buffer.Decode__Sequence_Start ();

			Buffer.Decode__BigInteger  (Modulus, 0, -1);
			Buffer.Debug ("Modulus");

			Buffer.Decode__BigInteger  (Generator, 0, -1);
			Buffer.Debug ("Generator");
			Buffer.Decode__Sequence_End (Position);
            }
			*/

		}
    /// <summary>
	/// PKIXPublicKeyDH 
    /// </summary>
	public partial class PKIXPublicKeyDH : Goedel.ASN.Root {

		/// <summary> ASN.1 member Shared </summary>
		public byte []  Shared  {get; set;}

		/// <summary> ASN.1 member Public </summary>
		public byte []  Public  {get; set;}


		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN.Buffer Buffer) {
			int Position = Buffer.Encode__Sequence_Start ();

			Buffer.Encode__BigInteger  (Public, 0, -1);
			Buffer.Debug ("Public");

			Buffer.Encode__Octets  (Shared, 0, -1);
			Buffer.Debug ("Shared");
			Buffer.Encode__Sequence_End (Position);
            }

			/*
		/// <summary>
		/// Decode buffer to populate class members
		///
		/// This is done in the forward direction
		/// </summary>
        public override void Decode (Goedel.ASN.Buffer Buffer) {
			int Position = Buffer.Decode__Sequence_Start ();

			Buffer.Decode__Octets  (Shared, 0, -1);
			Buffer.Debug ("Shared");

			Buffer.Decode__BigInteger  (Public, 0, -1);
			Buffer.Debug ("Public");
			Buffer.Decode__Sequence_End (Position);
            }
			*/

		}
    /// <summary>
	/// PKIXPrivateKeyDH 
    /// </summary>
	public partial class PKIXPrivateKeyDH : Goedel.ASN.Root {

		/// <summary> ASN.1 member Shared </summary>
		public byte []  Shared  {get; set;}

		/// <summary> ASN.1 member Public </summary>
		public byte []  Public  {get; set;}

		/// <summary> ASN.1 member Private </summary>
		public byte []  Private  {get; set;}


		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN.Buffer Buffer) {
			int Position = Buffer.Encode__Sequence_Start ();

			Buffer.Encode__BigInteger  (Private, 0, -1);
			Buffer.Debug ("Private");

			Buffer.Encode__BigInteger  (Public, 0, -1);
			Buffer.Debug ("Public");

			Buffer.Encode__Octets  (Shared, 0, -1);
			Buffer.Debug ("Shared");
			Buffer.Encode__Sequence_End (Position);
            }

			/*
		/// <summary>
		/// Decode buffer to populate class members
		///
		/// This is done in the forward direction
		/// </summary>
        public override void Decode (Goedel.ASN.Buffer Buffer) {
			int Position = Buffer.Decode__Sequence_Start ();

			Buffer.Decode__Octets  (Shared, 0, -1);
			Buffer.Debug ("Shared");

			Buffer.Decode__BigInteger  (Public, 0, -1);
			Buffer.Debug ("Public");

			Buffer.Decode__BigInteger  (Private, 0, -1);
			Buffer.Debug ("Private");
			Buffer.Decode__Sequence_End (Position);
            }
			*/

		}
    /// <summary>
	/// AgreementDH 
    /// </summary>
	public partial class AgreementDH : Goedel.ASN.Root {

		/// <summary> ASN.1 member Result </summary>
		public byte []  Result  {get; set;}


		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN.Buffer Buffer) {
			int Position = Buffer.Encode__Sequence_Start ();

			Buffer.Encode__BigInteger  (Result, 0, -1);
			Buffer.Debug ("Result");
			Buffer.Encode__Sequence_End (Position);
            }

			/*
		/// <summary>
		/// Decode buffer to populate class members
		///
		/// This is done in the forward direction
		/// </summary>
        public override void Decode (Goedel.ASN.Buffer Buffer) {
			int Position = Buffer.Decode__Sequence_Start ();

			Buffer.Decode__BigInteger  (Result, 0, -1);
			Buffer.Debug ("Result");
			Buffer.Decode__Sequence_End (Position);
            }
			*/

		}
    /// <summary>
	/// Endorsement 
    /// </summary>
	public partial class Endorsement : Goedel.ASN.Root {

		/// <summary> ASN.1 member TBSEndorsement </summary>
		public Goedel.Cryptography.PKIX.TBSEndorsement TBSEndorsement  {get; set;}

		/// <summary> ASN.1 member SignatureAlgorithm </summary>
		public Goedel.Cryptography.PKIX.AlgorithmIdentifier SignatureAlgorithm  {get; set;}

		/// <summary> ASN.1 member Signature </summary>
		public byte []  Signature  {get; set;}


		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN.Buffer Buffer) {
			int Position = Buffer.Encode__Sequence_Start ();

			Buffer.Encode__Bits  (Signature, 0, -1);
			Buffer.Debug ("Signature");

			Buffer.Encode__Object (SignatureAlgorithm, 0, -1);
			Buffer.Debug ("SignatureAlgorithm");

			Buffer.Encode__Object (TBSEndorsement, 0, -1);
			Buffer.Debug ("TBSEndorsement");
			Buffer.Encode__Sequence_End (Position);
            }

			/*
		/// <summary>
		/// Decode buffer to populate class members
		///
		/// This is done in the forward direction
		/// </summary>
        public override void Decode (Goedel.ASN.Buffer Buffer) {
			int Position = Buffer.Decode__Sequence_Start ();

			Buffer.Decode__Object (TBSEndorsement, 0, -1);
			Buffer.Debug ("TBSEndorsement");

			Buffer.Decode__Object (SignatureAlgorithm, 0, -1);
			Buffer.Debug ("SignatureAlgorithm");

			Buffer.Decode__Bits  (Signature, 0, -1);
			Buffer.Debug ("Signature");
			Buffer.Decode__Sequence_End (Position);
            }
			*/

		}
    /// <summary>
	/// TBSEndorsement 
    /// </summary>
	public partial class TBSEndorsement : Goedel.ASN.Root {

		/// <summary> ASN.1 member Version </summary>
		public int  Version  {get; set;}

		/// <summary> ASN.1 member Issued </summary>
		public DateTime  Issued  {get; set;}

		/// <summary> ASN.1 member IssuerKeyIdentifier </summary>
		public byte []  IssuerKeyIdentifier  {get; set;}

		/// <summary> ASN.1 member SubjectKeyIdentifier </summary>
		public byte []  SubjectKeyIdentifier  {get; set;}

		/// <summary> ASN.1 member Subject </summary>
		public List <Goedel.Cryptography.PKIX.Name > Subject  {get; set;}

		/// <summary> ASN.1 member SubjectAltName </summary>
		public List <Goedel.Cryptography.PKIX.SubjectAltName > SubjectAltName  {get; set;}

		/// <summary> ASN.1 member Extensions </summary>
		public List <Goedel.Cryptography.PKIX.Extension > Extensions  {get; set;}


		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN.Buffer Buffer) {
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

			/*
		/// <summary>
		/// Decode buffer to populate class members
		///
		/// This is done in the forward direction
		/// </summary>
        public override void Decode (Goedel.ASN.Buffer Buffer) {
			int Position = Buffer.Decode__Sequence_Start ();

			Buffer.Encode__Integer  (Version, 0, -1);
			Buffer.Debug ("Version");

			Buffer.EDecode__Time  (Issued, 0, -1);
			Buffer.Debug ("Issued");

			Buffer.Decode__Octets  (IssuerKeyIdentifier, 0, -1);
			Buffer.Debug ("IssuerKeyIdentifier");

			Buffer.Decode__Octets  (SubjectKeyIdentifier, 0, -1);
			Buffer.Debug ("SubjectKeyIdentifier");

			if (Subject == null || Subject.Count == 0) {
				Buffer.Decode__Object (null, 0, -1);
				}
			else {
				int XPosition = Buffer.Decode__Sequence_Start();
				foreach (Goedel.Cryptography.PKIX.Name  _Index in Subject) {
		
			Buffer.Encode__Object (_Index, 0, 0);
					}
				Buffer.Decode__Sequence_End(XPosition, 0, -1);
			}
			Buffer.Debug ("Subject");

			if (SubjectAltName == null || SubjectAltName.Count == 0) {
				Buffer.Decode__Object (null, 0, -1);
				}
			else {
				int XPosition = Buffer.Decode__Sequence_Start();
				foreach (Goedel.Cryptography.PKIX.SubjectAltName  _Index in SubjectAltName) {
		
			Buffer.Encode__Object (_Index, 0, 0);
					}
				Buffer.Decode__Sequence_End(XPosition, 0, -1);
			}
			Buffer.Debug ("SubjectAltName");

			if (Extensions == null || Extensions.Count == 0) {
				Buffer.Decode__Object (null, 0, -1);
				}
			else {
				int XPosition = Buffer.Decode__Sequence_Start();
				foreach (Goedel.Cryptography.PKIX.Extension  _Index in Extensions) {
		
			Buffer.Encode__Object (_Index, 0, 0);
					}
				Buffer.Decode__Sequence_End(XPosition, 0, -1);
			}
			Buffer.Debug ("Extensions");
			Buffer.Decode__Sequence_End (Position);
            }
			*/

		}
    /// <summary>
	/// RFC2631OtherInfo 
    /// </summary>
	public partial class RFC2631OtherInfo : Goedel.ASN.Root {

		/// <summary> ASN.1 member KeyInfo </summary>
		public Goedel.Cryptography.PKIX.KeySpecificInfo KeyInfo  {get; set;}

		/// <summary> ASN.1 member PartyAInfo </summary>
		public byte []  PartyAInfo  {get; set;}

		/// <summary> ASN.1 member SuppPubInfo </summary>
		public byte []  SuppPubInfo  {get; set;}


		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN.Buffer Buffer) {
			int Position = Buffer.Encode__Sequence_Start ();

			Buffer.Encode__Octets  (SuppPubInfo, 0, 2);
			Buffer.Debug ("SuppPubInfo");

			Buffer.Encode__Octets  (PartyAInfo, 4, 0);
			Buffer.Debug ("PartyAInfo");

			Buffer.Encode__Object (KeyInfo, 0, -1);
			Buffer.Debug ("KeyInfo");
			Buffer.Encode__Sequence_End (Position);
            }

			/*
		/// <summary>
		/// Decode buffer to populate class members
		///
		/// This is done in the forward direction
		/// </summary>
        public override void Decode (Goedel.ASN.Buffer Buffer) {
			int Position = Buffer.Decode__Sequence_Start ();

			Buffer.Decode__Object (KeyInfo, 0, -1);
			Buffer.Debug ("KeyInfo");

			Buffer.Decode__Octets  (PartyAInfo, 4, 0);
			Buffer.Debug ("PartyAInfo");

			Buffer.Decode__Octets  (SuppPubInfo, 0, 2);
			Buffer.Debug ("SuppPubInfo");
			Buffer.Decode__Sequence_End (Position);
            }
			*/

		}
    /// <summary>
	/// KeySpecificInfo 
    /// </summary>
	public partial class KeySpecificInfo : Goedel.ASN.Root {

		/// <summary> ASN.1 member Algorithm </summary>
		public int []  Algorithm  {get; set;}

		/// <summary> ASN.1 member Counter </summary>
		public byte []  Counter  {get; set;}


		/// <summary>
		/// Encode ASN.1 class members to specified buffer. 
		///
		/// NB Assinine ASN.1 DER encoding rules requires members be added in reverse order.
		/// </summary>
		/// <param name="Buffer">Output buffer</param>
        public override void Encode (Goedel.ASN.Buffer Buffer) {
			int Position = Buffer.Encode__Sequence_Start ();

			Buffer.Encode__Octets  (Counter, 0, -1);
			Buffer.Debug ("Counter");

			Buffer.Encode__OIDRef  (Algorithm, 0, -1);
			Buffer.Debug ("Algorithm");
			Buffer.Encode__Sequence_End (Position);
            }

			/*
		/// <summary>
		/// Decode buffer to populate class members
		///
		/// This is done in the forward direction
		/// </summary>
        public override void Decode (Goedel.ASN.Buffer Buffer) {
			int Position = Buffer.Decode__Sequence_Start ();

			Buffer.Decode__OIDRef  (Algorithm, 0, -1);
			Buffer.Debug ("Algorithm");

			Buffer.Decode__Octets  (Counter, 0, -1);
			Buffer.Debug ("Counter");
			Buffer.Decode__Sequence_End (Position);
            }
			*/

		}
	}
#pragma warning restore IDE0022	
