using Goedel.Guigen;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

using Everything.Resources;
using Goedel.Mesh;
using Goedel.Cryptography.Core;

namespace Goedel.Everything;
public partial class EverythingMaui {
    ResourceManager ResourceManager;


    public IMeshMachineClient MeshMachine;


    public EverythingMaui() {
        ResourceManager = Sketch_resources.ResourceManager;

        MeshMachine = new MeshMachineCore();

        //KeyCollectionCore.SetPlatformDirect(@"C:\\Users\\hallam\\Test\\Deterministic");


        }
    public override string GetPrompt(GuiPrompt guiPrompt) {

        return ResourceManager.GetString(guiPrompt.Id);


        }
    }
