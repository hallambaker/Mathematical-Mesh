
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Threading;
using Goedel.Trojan;

namespace Goedel.MeshConnect {

    public partial class _Data_ConnectPending :Goedel.Trojan.Data  {
		public Dialog_ConnectPending Dialog;

		public override Page Page {
		    get { return Dialog; }
			}

		protected ConnectProfile _Data;
		public ConnectProfile Data {
			get {return _Data;}
			}


		public void Refresh () {
			if (Dialog != null) {
				Dialog.Refresh ();
				}
			}

//		protected Wizard_ConnectProfile  _Wizard;	
//		public Wizard_ConnectProfile  Wizard {
//				get {return _Wizard;}
//				}
//		public Data_ConnectProfile  Data {
//				get {return Wizard.Data;}
//				}

		// Input backing variables

		// Output backing variables
		string _Output_ProfileUDF;
		public string Output_ProfileUDF {
            get { return _Output_ProfileUDF; }
            set { _Output_ProfileUDF = value;   Refresh (); }
            }
		string _Output_DeviceUDF;
		public string Output_DeviceUDF {
            get { return _Output_DeviceUDF; }
            set { _Output_DeviceUDF = value;   Refresh (); }
            }




		}

    public partial class ConnectPending : _Data_ConnectPending {

		
		public ConnectPending (ConnectProfile  Data) {
			_Data = Data;

			// NB call to the initializer before we creaate the dialog so the
			// dialog can display the initialized data.
			Initialize ();
			this.Dialog = new Dialog_ConnectPending (this);
			}
		}


    /// <summary>
	/// This is the code behind for the XAML generated class.
    /// </summary>
    public partial class Dialog_ConnectPending : Page {

		public ConnectPending  Data;


		public Dialog_ConnectPending (ConnectPending Data) {
			InitializeComponent();
			this.Data = Data;
			Refresh ();

			}

		public void Refresh () {
			Output_ProfileUDF.Text  = Data.Output_ProfileUDF;
			Output_DeviceUDF.Text  = Data.Output_DeviceUDF;
			}




		}
	}

