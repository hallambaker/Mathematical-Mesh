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
using Proto=Goedel.Tool.ProtoGen;

using Microsoft.VisualStudio.TestPlatform.Utilities;

using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text;
using Microsoft.Extensions.Primitives;
using Goedel.Utilities;


namespace ExampleGenerator;

public class JsDeviceResults {
    CreateExamples CreateExamples { get; }
    public string DefinitionFile => 
            Path.Combine(CreateExamples.SourceDirectrory, @"Libraries\Goedel.Contacts\DeviceSchema.Protocol");


    public JsDeviceResults(CreateExamples createExamples) {

        CreateExamples = createExamples;





        var date = DateTime.UtcNow;
        //For example, a webcam has a QR code containing a JSDevice QR code printed on it:
        var device = new JsDevice() {
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

            Localizations =
                new () {
                        { "cy", new JsDevice() {
                            ModelName = "Acme GweGamera 4K"
                            } }
                    },


            Images = [
                    new () {
                        Uri = "https://acme.example.net/media/webcam4k.front.png",
                        MediaType = "image/png",
                        Kind = "photo",
                        Label = "Front View"
                        },
                    new () {
                        Uri = "httpe://acme.example.net/media/webcam4k.rear.png",
                        MediaType = "image/png",
                        Kind = "photo",
                        Label = "Rear View"
                        },
                    new () {
                        Uri = "https://acme.example.net/media/webcam4k.schematic.svg",
                        MediaType = "image/svg",
                        Kind = "schematic",
                        Label = "Rear View"
                        }
                    ],

            Manuals = [                    
                    new () {
                        Uri = "httpe://acme.example.net/media/webcam4k.quickstart.pdf",
                        MediaType = "application/pdf",
                        Kind = "quickstart",
                        Label = "Quick Start Guide"
                        },
                    new () {
                        Uri = "https://acme.example.net/media/webcam4k.unboxing.pdf",
                        MediaType = "application/pdf",
                        Kind = "unboxing",
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
            Maintenance = [
                    new () {
                        Label = "Lubricate mount",
                        Uri =  "https://acme.example.net/media/webcam4k.manual.pdf#lubrication",
                        Recurring = true,
                        Months =24
                        }
                ],

            Consumables = [
                    new () {
                        Label = "Mount bearing",
                        Uri =  "https://acme.example.net/media/bearings/24U.jsdevice",
                        MediaType = "application/jsdevice"
                        }
                ],

            Accessories = [
                    new () {
                        Label = "Lens Kit",
                        Uri =  "https://acme.example.net/media/lenses/telephoto200.jsdevice",
                        MediaType = "application/jsdevice"
                        }
                ],

            Suppliers = [
                    new () {
                        Label = "Acme Store",
                        Uri =  "https://store.acme.example.net/webcam4k",
                        MediaType = "text/html"
                        }
                ],

            Bootstraps = [
                new () {
                    Identifier = "mmm-connect",
                    Port = 80,
                    Keys = new () { 
                       {"id", "udf:MCBG-ZSI4-XSWX-UNEE-GU6X-YTBZ-XPH5" }  }
                    },
                ],

            Provisioning = [
                // DHCP - for IP address
                new () {
                    Identifier = "dhcp",
                    Endpoints = [
                        "ip"]
                    },

                // Anything - for IP, DNS and WebPKI
                new () {
                    Identifier = "anything",
                    Endpoints = [
                        "ip", "dns", "webpki"]
                    },
                ],


            Services = [
                // Administration
                new () {
                    Identifier = "jsadmin",
                    Port = 443,
                    Endpoints = [
                        "dns", "webpki"],
                    Permissions = ["admin"]
                    },

                // WebRTC site
                new () {
                    Identifier = "https",
                    Port = 443,
                    Endpoints = [
                        "dns", "webpki"],
                    Permissions = ["read"]
                    },

                // MOQ service
                new () {
                    Identifier = "moq",
                    Endpoints = [
                        "dns", "webpki"],
                    Permissions = ["read"]
                    }

                ],

            CryptoKeys = [

                ]



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



        Console.WriteLine(JSONDebugWriter.Write(device, false));

        Proto.ProtoStruct Parse = new() {
            };
        using (Stream infile =
            new FileStream(DefinitionFile, FileMode.Open, FileAccess.Read)) {
            Lexer Schema = new(DefinitionFile);
            Schema.Process(infile, Parse);
            }

        Parse.Complete();
        var protocol = Parse.Top[0] as Proto.Protocol;


        var jsDevice = GetStructure(protocol, "JsDevice");

        foreach (var entry in jsDevice.Entries) {
            string typeDeclarator = null;
            List<Proto._Choice> options = null;

            switch (entry) {
                case Proto.String typeString: {
                    typeDeclarator = "String";
                    options = typeString.Options;
                    break;
                    }
                case Proto.Struct typeStruct: {
                    typeDeclarator = typeStruct.BaseType;
                    options = typeStruct.Options;
                    break;
                    }
                case Proto.DateTime typeDate: {
                    typeDeclarator = "UTCDateTime";
                    options = typeDate.Options;
                    break;
                    }
                }


            if (typeDeclarator is not null) {
                Console.WriteLine(MakeType(entry, typeDeclarator));
                var descriptions = GetDescription(options);

                foreach (var line in descriptions) {
                    Console.WriteLine(line);
                    }
                Console.WriteLine(GetExample(device, entry.ID));
                }

            }


        }


    string GetExample(JsonObject jsonObject, string tag) {
        var builder = new MemoryStream();
        var writer = new JsonWriter(builder);

        var binding = jsonObject._Binding;

        if (binding.Properties.TryGetValue(tag, out var property)) {

            property.Serialize(jsonObject, writer);

            }
        return builder.ToArray().ToUTF8();
        }


    List<string> GetDescription(List<Proto._Choice> options) {
        var result = new List<string>();
        foreach (var option in options) {
            if (option is Proto.Description description) {
                var para = "";
                foreach (var line in description.Text1) {
                    para = para + line + "\n";
                    }
                result.Add(para);
                }
            }

        return result;
        }

    string MakeType(Proto._Choice entry, string type) {
        var builder = new StringBuilder();
        builder.Append("\"");
        builder.Append(entry.ID);
        builder.Append("\": ");

        if (entry.Dictionary) {
            builder.Append($"String[{type}]");
            }
        else if (entry.Multiple) {
            builder.Append($"{type}[]");
            }
        else {
            builder.Append(type);
            }

        builder.Append(entry.Required ? " (mandatory)" : " (optional)");


            return builder.ToString();

        }

    Proto.Structure GetStructure(Goedel.Tool.ProtoGen.Protocol protocol, string tag) {
        foreach (var entry in protocol.Entries) {
            if (entry is Proto.Structure structure) {

                if (structure.Id.Label == tag) {
                    return structure;
                    }
                }
            }
        return null;
        }

    }
