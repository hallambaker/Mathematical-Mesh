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
using Microsoft.UI.Xaml.Controls.Primitives;
using System.Collections;

namespace Goedel.Everything;
public partial class EverythingMaui {
    ResourceManager ResourceManager;


    public IMeshMachineClient MeshMachine;
    public MeshHost MeshHost => MeshMachine.MeshHost;


    public ContextUser ContextUser {get; set;}



    public EverythingMaui() {
        ResourceManager = Sketch_resources.ResourceManager;

        MeshMachine = new MeshMachineCore();
        SetContext(MeshHost.GetContext(MeshHost.DefaultAccount) as ContextUser);

        }


    public void SetContext(ContextUser contextUser) {
        ContextUser = contextUser;

        var accounts = new Accounts(contextUser);

        SectionAccounts.Data = accounts;
        SectionCredentials.BindData = () => accounts.Credentials;
        

        }



    public override string GetPrompt(GuiPrompt guiPrompt) {

        return ResourceManager.GetString(guiPrompt.Id);


        }

    public static Dictionary<Type, GuiBinding> BindingDictionary = new() {
            { typeof(CatalogedCredential), BindingCatalogedCredential }
        };

    public static GuiBinding GetBinding(object data) {
        if (BindingDictionary.TryGetValue(data.GetType(), out var binding)) return binding; 

        throw new NotImplementedException();
        }
    }





public partial class Accounts {
    ContextUser ContextUser { get; }


    public Credentials Credentials => credentials ?? new Credentials(ContextUser).CacheValue(out credentials);
    Credentials credentials;

    public override string ServiceAddress => ContextUser.ServiceAddress;

    public override string ProfileUDF => ContextUser.Profile.UdfString;

    public override string LocalAddress => ContextUser.CatalogedMachine.Local;


    public Accounts(ContextUser contextUser) {
        ContextUser = contextUser;
        }
    }

public partial class Credentials {
    ContextUser ContextUser { get; }

    public Credentials(ContextUser contextUser) {
        ContextUser = contextUser;

        ChooseCredential = new CatalogSelector(ContextUser.GetStore(CatalogCredential.Label));
        }

    }


public class CatalogSelector : ISelectCollection {

    public Store Store;



    public List<string> Test => new List<string>() { "apple", "bob"};

    public GuiBinding Binding { get; set; }

    public Func<GuiBinding, object> BindingDelegate { get; }

    public CatalogSelector(Store store) {
        Store = store;
        BindingDelegate = EverythingMaui.GetBinding;
        }

    public IEnumerator GetEnumerator() => Store.Enumerate();
    }



