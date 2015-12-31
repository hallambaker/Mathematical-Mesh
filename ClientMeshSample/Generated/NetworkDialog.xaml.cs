
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

namespace Goedel.MeshSampleClient {

    public partial class _Data_NetworkDialog :Goedel.Trojan.Data  {
		public Dialog_NetworkDialog Dialog;

		public override Page Page {
		    get { return Dialog; }
			}

		protected SampleApplication _Data;
		public SampleApplication Data {
			get {return _Data;}
			}


		public void Refresh () {
			if (Dialog != null) {
				Dialog.Refresh ();
				}
			}

//		protected Wizard_SampleApplication  _Wizard;	
//		public Wizard_SampleApplication  Wizard {
//				get {return _Wizard;}
//				}
//		public Data_SampleApplication  Data {
//				get {return Wizard.Data;}
//				}

		// Input backing variables
		string _Input_DNS1;
		public string Input_DNS1 {
            get { return _Input_DNS1; }
            set { _Input_DNS1 = value;  Refresh (); }
            }
		string _Input_DNS2;
		public string Input_DNS2 {
            get { return _Input_DNS2; }
            set { _Input_DNS2 = value;  Refresh (); }
            }
		string _Input_DNSProtocol;
		public string Input_DNSProtocol {
            get { return _Input_DNSProtocol; }
            set { _Input_DNSProtocol = value;  Refresh (); }
            }

		// Output backing variables



		/// <summary>
		/// Here goes the action to be overriden
		/// </summary>

		public virtual bool AcceptNetwork () {
			return true;
			}

		/// <summary>
		/// Here goes the action to be overriden
		/// </summary>

		public virtual bool CancelNetwork2 () {
			return true;
			}


		}

    public partial class NetworkDialog : _Data_NetworkDialog {

		
		public NetworkDialog (SampleApplication  Data) {
			_Data = Data;

			// NB call to the initializer before we creaate the dialog so the
			// dialog can display the initialized data.
			Initialize ();
			this.Dialog = new Dialog_NetworkDialog (this);
			}
		}


    /// <summary>
	/// This is the code behind for the XAML generated class.
    /// </summary>
    public partial class Dialog_NetworkDialog : Page {

		public NetworkDialog  Data;


		public Dialog_NetworkDialog (NetworkDialog Data) {
			InitializeComponent();
			this.Data = Data;
			Refresh ();

			}

		public void Refresh () {
			Input_DNS1.Text  = Data.Input_DNS1;
			Input_DNS2.Text  = Data.Input_DNS2;
			Input_DNSProtocol.Text  = Data.Input_DNSProtocol;
			}

        private void Action_AcceptNetwork(object sender, RoutedEventArgs e) {
			var Result = Data.AcceptNetwork ();
			if (Result) {
				Data.Data.Navigate (Data.Data.Data_SelectApplication);
				}
            }
        private void Action_CancelNetwork2(object sender, RoutedEventArgs e) {
			var Result = Data.CancelNetwork2 ();
			if (Result) {
				Data.Data.Navigate (Data.Data.Data_SelectApplication);
				}
            }


		private void Changed_Input_DNS1 (object sender, TextChangedEventArgs e) {
			Data.Input_DNS1 = Input_DNS1.Text;
			}
		private void Changed_Input_DNS2 (object sender, TextChangedEventArgs e) {
			Data.Input_DNS2 = Input_DNS2.Text;
			}
		private void Changed_Input_DNSProtocol (object sender, TextChangedEventArgs e) {
			Data.Input_DNSProtocol = Input_DNSProtocol.Text;
			}

		}
	}

