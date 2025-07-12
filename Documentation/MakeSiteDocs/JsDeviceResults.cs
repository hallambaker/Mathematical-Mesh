#region // Copyright - MIT License
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

using Goedel.Contacts;
using Goedel.Cryptography;
using Goedel.Cryptography.Jose;
using Goedel.Discovery;
using Goedel.Mesh;
using Goedel.Protocol;
using Goedel.Protocol.Service;
//using Proto=Goedel.Tool.ProtoGen;

using Microsoft.VisualStudio.TestPlatform.Utilities;

using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text;
using Microsoft.Extensions.Primitives;
using Goedel.Utilities;
using Proto=Goedel.Tool.ProtoGen;
using Goedel.Cryptography.Dare;


namespace ExampleGenerator;

public class JsDeviceResults {
    CreateExamples CreateExamples { get; }

    public Proto.AnnotateSchema AnnotatedSchema { get; set; }
    public Proto.AnnotateSchema AnnotatedSchemaBase { get; set; }


    public JsDevice JsDevice { get; }

    public JsDevice JsModel { get; }
    public string JmapBaseSchemaFile =>
        Path.Combine(CreateExamples.SourceDirectory, @"Libraries\Goedel.Contacts\JmapBase.Protocol");

    public string JsDeviceSchemaFile => 
            Path.Combine(CreateExamples.SourceDirectory, @"Libraries\Goedel.Contacts\DeviceSchema.Protocol");

    public EarlSet EarlSet { get; }

    public string EARL => EarlSet.Uri;

    public ContentMeta ProtectedHeaderJson { get; } = new ContentMeta() {
        ContentType = "application/jsdevice+json",
        Nonce = Udf.FixedNonce("JSDevice")
        };

    public KeyPairECDH SignatureEd448 { get; }



    public List<string> GeneralProperties = ["@type","uid", "version", "created", "updated",
        "kind", "language", "modelName", "manufacturer", "prodId", "dateManufacture", "endSupport", "endLife"];

    public List<string> PreparationProperties = ["components"];

    public List<string> MediaProperties = ["images", "documentation"];

    public List<string> OperationsProperties = ["suppliers", "maintenance", "relatedItems"];

    public List<string> NetworkProperties = ["network"];

    public JsDeviceResults(CreateExamples createExamples) {

        CreateExamples = createExamples;



        var date = DateTime.UtcNow;
        //For example, a webcam has a QR code containing a JSDevice QR code printed on it:
        JsDevice = new JsDevice() {
            Uid = Udf.FixedNonce("Some device"),
            Created = date,
            Updated = date,

            Version = "1.0",
            Kind = "device",
            Language = "en",

            DeviceId = Udf.FixedNonce("Some device"),
            ModelId = Udf.FixedNonce("Some model"),
            ModelName = "Acme WebCam 4K",
            Manufacturer = "Acme Corp.",
            DateManufacture = date,

            EndSupport = date.AddYears(5),
            EndLife = date.AddYears(10),
            ProdId = "Configulator/1.0",
            Localizations = new() {
                    { "cy", new () {
                        ModelName = "Acme GweGamera 4K"
                        } }
                },


            Components = new() {
                { "main", new () {
                    Dimensions =  new() {
                        { "typical",   new Dimensions () {
                            Kind="typical",
                            Weight = 0.050,
                            Width = 0.10,
                            Height = 0.10,
                            Depth = 0.10
                            } }
                        }
                    } }
                },

            Images = [
                    new () {
                        Uri = "https://acme.example.net/media/webcam4k.front.png",
                        MediaType = "image/png",
                        Kind = "front",
                        Label = "Front View"
                        },
                    new () {
                        Uri = "httpe://acme.example.net/media/webcam4k.rear.png",
                        MediaType = "image/png",
                        Kind = "rear",
                        Label = "Rear View"
                        },
                    new () {
                        Uri = "https://acme.example.net/media/webcam4k.schematic.svg",
                        MediaType = "image/svg",
                        Kind = "schematic",
                        Label = "Rear View"
                        }
                    ],

            Documentation = [
                    new () {
                        Uri = "httpe://acme.example.net/media/webcam4k.quickstart.pdf",
                        MediaType = "application/pdf",
                        Kind = "quickstart",
                        Label = "Quick Start Guide"
                        },
                    new () {
                        Uri = "https://acme.example.net/media/webcam4k.unboxing.pdf",
                        MediaType = "application/pdf",
                        Kind = "unpacking",
                        Label = "Rear View"
                        },
                    new () {
                        Uri = "httpe://acme.example.net/media/webcam4k.manual.pdf",
                        MediaType = "application/pdf",
                        Kind = "manual",
                        Label = "Manual"
                        }],

            //The motorized mount requires that the camera mount be lubricated and checked
            //every 24 months.These are manual processes but the device has the option of
            //tracking maintenance events by means of a button underneath a cover on the
            //camera which is pressed to signal a maintenance event was completed.The status
            //of this button is reported through another proprietary Web Service.
            Maintenance = new() {
                {"maint1", new  () {
                        Label = "Lubricate mount",
                        Uri =  "https://acme.example.net/media/webcam4k.manual.pdf#lubrication",
                        Recurring = true,
                        Months =24
                        }
                    }
                },

            RelatedItems = new() {
                {"part1", new  () {
                        Kind = "part",
                        Label = "Mount bearing",
                        Uri =  "https://acme.example.net/media/bearings/24U.jsdevice",
                        MediaType = "application/jsdevice"
                        }
                    },
                {"accessory1", new  () {
                        Kind = "accessory",
                        Label = "Lens Kit",
                        Uri =  "https://acme.example.net/media/lenses/telephoto200.jsdevice",
                        MediaType = "application/jsdevice"
                        }
                    }
                },

            Suppliers = [
                    new () {
                        Label = "Acme Store",
                        Uri =  "https://store.acme.example.net/webcam4k",
                        MediaType = "text/html"
                        }
                ],

            Services = new() {
                {"boot1", new Network () {
                        Kind="bootstrap",
                        Identifier = "mmm-connect",
                        Ports = [80],
                        Keys = new () {
                            {"id", "udf:MCBG-ZSI4-XSWX-UNEE-GU6X-YTBZ-XPH5" }  }
                        }
                    },
                {"disc1", new Network () {
                        Kind="discovery",
                        Identifier = "dhcp",
                        Endpoints = [
                            "ip"]
                        }
                    },
                // Anything - for IP, DNS and WebPKI
                {"disc2", new Network () {
                        Kind="discovery",
                        Identifier = "anything",
                        Endpoints = [
                            "ip", "dns", "webpki"]
                        }
                    },

                // Administration
                {"motor1", new Network () {
                        Kind="service",
                        Identifier = "acme_cam_control",
                        Ports = [443],
                        Endpoints = [
                            "dns", "webpki"],
                        Permissions = ["admin"]
                        }
                    }, 
                // WebRTC site
                { "web1", new Network () {
                        Kind="service",
                        Identifier = "https",
                        Ports = [443],
                        Endpoints = [
                            "dns", "webpki"],
                        Permissions = ["read"]
                        }
                    },

                // MOQ service
                {"moq1", new Network () {
                        Kind="service",
                        Identifier = "moq",
                        Endpoints = [
                            "dns", "webpki"],
                        Permissions = ["read"]
                        }

                    },
                },
            CryptoKeys = [

                ]



            };

        var model = DateTime.UtcNow.AddDays (-4);

        JsModel = new () {
            Uid = Udf.FixedNonce("Some model"),
            Created = model,

            Version = JsDevice.Version,
            Kind = "model",
            Language = JsDevice.Language,

            ModelName = JsDevice.ModelName,
            Manufacturer = JsDevice.Manufacturer,

            ProdId = JsDevice.ProdId,
            Localizations = JsDevice.Localizations,

            Components = JsDevice.Components,

            Images = JsDevice.Images,
            Documentation = JsDevice.Documentation,
            Maintenance = JsDevice.Maintenance,
            RelatedItems = JsDevice.RelatedItems,
            Suppliers = JsDevice.Suppliers
            };




        //For example, to add a webcam to her home security system, Alice needs to specify:
        //The DNS name by which the camera is to be addressed 
        //e.g. camera01.alice.example.com
        //The set of users authorized to view images provided by the camera
        //e.g. @alice.example.com, @bob.example.com
        //In addition, the webcam will require all the local and network configurations
        //and issue of certificates necessary to allow Alice and Bob to access the device as



        // For example, the webcam has links to images showing the device from multiple
        // angles, a schematic of the connection panel


        //The webcam supports viewing of the output via HTTP and MOQ and has a motorized
        //mount that can be controlled through the proprietary 'MoveMounting' Web Service:

        var contactBytes = JsDevice.GetJson(false);
        SignatureEd448 = KeyPairEd448.Generate(KeySecurity.Exportable, KeyUses.Sign);
        //SigningKeys.Add(SignatureEd448.KeyPairPublic());

        EarlSet = new EarlSet(ProtectedHeaderJson, contactBytes, [SignatureEd448],
            scheme: "jsdevice", authority: CreateExamples.AliceService);

        Console.WriteLine(JSONDebugWriter.Write(JsDevice, false));

        }



    }
