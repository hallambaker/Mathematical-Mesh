//Sample license text.

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

    public partial class _Data_ProcessPending :Goedel.Trojan.Data  {
		public Dialog_ProcessPending Dialog;

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

		// Output backing variables
		string _Output_PendingUDF;
		public string Output_PendingUDF {
            get { return _Output_PendingUDF; }
            set { _Output_PendingUDF = value;   Refresh (); }
            }
		string _Output_AccountID1;
		public string Output_AccountID1 {
            get { return _Output_AccountID1; }
            set { _Output_AccountID1 = value;   Refresh (); }
            }



		/// <summary>
		/// Here goes the action to be overriden
		/// </summary>

		public virtual bool AcceptPending () {
			return true;
			}

		/// <summary>
		/// Here goes the action to be overriden
		/// </summary>

		public virtual bool RejectPending () {
			return true;
			}


		}

    public partial class ProcessPending : _Data_ProcessPending {

		
		public ProcessPending (AddProfile  Data) {
			_Data = Data;

			// NB call to the initializer before we creaate the dialog so the
			// dialog can display the initialized data.
			Initialize ();
			this.Dialog = new Dialog_ProcessPending (this);
			}
		}


    /// <summary>
	/// This is the code behind for the XAML generated class.
    /// </summary>
    public partial class Dialog_ProcessPending : Page {

		public ProcessPending  Data;


		public Dialog_ProcessPending (ProcessPending Data) {
			InitializeComponent();
			this.Data = Data;
			Refresh ();

			}

		public void Refresh () {
			Output_PendingUDF.Text  = Data.Output_PendingUDF;
			Output_AccountID1.Text  = Data.Output_AccountID1;
			}

        private void Action_AcceptPending(object sender, RoutedEventArgs e) {
			var Result = Data.AcceptPending ();
			if (Result) {
				Data.Data.Navigate (Data.Data.Data_SetupComplete);
				}
            }
        private void Action_RejectPending(object sender, RoutedEventArgs e) {
			var Result = Data.RejectPending ();
			if (Result) {
				Data.Data.Navigate (Data.Data.Data_SetupComplete);
				}
            }



		}
	}

