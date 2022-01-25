
using System.Threading.Tasks;

namespace Goedel.Utilities;



public interface IConfiguredService {

    string Name { get; }


    Task StartServiceAsync();


    }





public interface IComponent {


    void Initialize();


    }

//public interface IConfiguration {


//    }