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

    public partial class _Data_CheckFingerPrint :Goedel.Trojan.Data  {
		public Dialog_CheckFingerPrint Dialog;

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
		string _Output_Fingerprint2;
		public string Output_Fingerprint2 {
            get { return _Output_Fingerprint2; }
            set { _Output_Fingerprint2 = value;   Refresh (); }
            }



		/// <summary>
		/// Here goes the action to be overriden
		/// </summary>

		public virtual bool AcceptFingerprint () {
			return true;
			}

		/// <summary>
		/// Here goes the action to be overriden
		/// </summary>

		public virtual bool RejectFingerprint () {
			return true;
			}


		}

    public partial class CheckFingerPrint : _Data_CheckFingerPrint {

		
		public CheckFingerPrint (AddProfile  Data) {
			_Data = Data;

			// NB call to the initializer before we creaate the dialog so the
			// dialog can display the initialized data.
			Initialize ();
			this.Dialog = new Dialog_CheckFingerPrint (this);
			}
		}


    /// <summary>
	/// This is the code behind for the XAML generated class.
    /// </summary>
    public partial class Dialog_CheckFingerPrint : Page {

		public CheckFingerPrint  Data;


		public Dialog_CheckFingerPrint (CheckFingerPrint Data) {
			InitializeComponent();
			this.Data = Data;
			Refresh ();

			}

		public void Refresh () {
			Output_Fingerprint2.Text  = Data.Output_Fingerprint2;
			}

        private void Action_AcceptFingerprint(object sender, RoutedEventArgs e) {
			var Result = Data.AcceptFingerprint ();
			if (Result) {
				Data.Data.Navigate (Data.Data.Data_WaitToComplete);
				}
            }
        private void Action_RejectFingerprint(object sender, RoutedEventArgs e) {
			var Result = Data.RejectFingerprint ();
			if (Result) {
				Data.Data.Navigate (Data.Data.Data_Cancelled);
				}
            }



		}
	}

