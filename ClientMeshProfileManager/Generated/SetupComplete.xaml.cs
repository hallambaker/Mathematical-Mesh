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

    public partial class _Data_SetupComplete :Goedel.Trojan.Data  {
		public Dialog_SetupComplete Dialog;

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
		string _Output_ProfileUDF;
		public string Output_ProfileUDF {
            get { return _Output_ProfileUDF; }
            set { _Output_ProfileUDF = value;   Refresh (); }
            }
		string _Output_AccountID;
		public string Output_AccountID {
            get { return _Output_AccountID; }
            set { _Output_AccountID = value;   Refresh (); }
            }



		/// <summary>
		/// Here goes the action to be overriden
		/// </summary>

		public virtual bool Scan () {
			return true;
			}


		}

    public partial class SetupComplete : _Data_SetupComplete {

		
		public SetupComplete (AddProfile  Data) {
			_Data = Data;

			// NB call to the initializer before we creaate the dialog so the
			// dialog can display the initialized data.
			Initialize ();
			this.Dialog = new Dialog_SetupComplete (this);
			}
		}


    /// <summary>
	/// This is the code behind for the XAML generated class.
    /// </summary>
    public partial class Dialog_SetupComplete : Page {

		public SetupComplete  Data;


		public Dialog_SetupComplete (SetupComplete Data) {
			InitializeComponent();
			this.Data = Data;
			Refresh ();

			}

		public void Refresh () {
			Output_ProfileUDF.Text  = Data.Output_ProfileUDF;
			Output_AccountID.Text  = Data.Output_AccountID;
			}

        private void Action_Scan(object sender, RoutedEventArgs e) {
			var Result = Data.Scan ();
			if (Result) {
				Data.Data.Navigate (Data.Data.Data_ProcessPending);
				}
            }



		}
	}

