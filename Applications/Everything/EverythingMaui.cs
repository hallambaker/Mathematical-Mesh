using Goedel.Guigen;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

using Everything.Resources;

namespace Goedel.Everything;
public partial class EverythingMaui {
    ResourceManager ResourceManager;
    public EverythingMaui() {
        ResourceManager = Sketch_resources.ResourceManager;

        //var x = ResourceManager.GetString("Accounts");
        }
    public override string GetPrompt(GuiPrompt guiPrompt) {

        return ResourceManager.GetString(guiPrompt.Id);


        //return base.GetPrompt(guiPrompt);
        }
    }
