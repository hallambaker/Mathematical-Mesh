
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

namespace Goedel.MeshProfileManager {

    public partial class _Data_ConnectDevice :Goedel.Trojan.Data  {
		public Dialog_ConnectDevice Dialog;

		public override Page Page {
		    get { return Dialog; }
			}

		protected AddProfile _Data;
		public AddProfile Data {
			get {return _Data;}
			}


		public void Refresh () {
			if (Dialog != null) {
				Dialog.Refresh ();
				}
			}

//		protected Wizard_AddProfile  _Wizard;	
//		public Wizard_AddProfile  Wizard {
//				get {return _Wizard;}
//				}
//		public Data_AddProfile  Data {
//				get {return Wizard.Data;}
//				}

		// Input backing variables
		string _Input_MeshGateway2;
		public string Input_MeshGateway2 {
            get { return _Input_MeshGateway2; }
            set { _Input_MeshGateway2 = value;  Refresh (); }
            }
		string _Input_AccountName3;
		public string Input_AccountName3 {
            get { return _Input_AccountName3; }
            set { _Input_AccountName3 = value;  Refresh (); }
            }

		// Output backing variables



		/// <summary>
		/// Here goes the action to be overriden
		/// </summary>

		public virtual bool WaitConnect () {
			return true;
			}


		}

    public partial class ConnectDevice : _Data_ConnectDevice {

		
		public ConnectDevice (AddProfile  Data) {
			_Data = Data;

			// NB call to the initializer before we creaate the dialog so the
			// dialog can display the initialized data.
			Initialize ();
			this.Dialog = new Dialog_ConnectDevice (this);
			}
		}


    /// <summary>
	/// This is the code behind for the XAML generated class.
    /// </summary>
    public partial class Dialog_ConnectDevice : Page {

		public ConnectDevice  Data;


		public Dialog_ConnectDevice (ConnectDevice Data) {
			InitializeComponent();
			this.Data = Data;
			Refresh ();

			}

		public void Refresh () {
			Input_MeshGateway2.Text  = Data.Input_MeshGateway2;
			Input_AccountName3.Text  = Data.Input_AccountName3;
			}

        private void Action_WaitConnect(object sender, RoutedEventArgs e) {
			var Result = Data.WaitConnect ();
			if (Result) {
				Data.Data.Navigate (Data.Data.Data_ConnectPending);
				}
            }


		private void Changed_Input_MeshGateway2 (object sender, TextChangedEventArgs e) {
			Data.Input_MeshGateway2 = Input_MeshGateway2.Text;
			}
		private void Changed_Input_AccountName3 (object sender, TextChangedEventArgs e) {
			Data.Input_AccountName3 = Input_AccountName3.Text;
			}

		}
	}

