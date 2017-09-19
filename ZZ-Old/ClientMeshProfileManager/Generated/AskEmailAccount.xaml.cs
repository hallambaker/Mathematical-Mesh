
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

    public partial class _Data_AskEmailAccount :Goedel.Trojan.Data  {
		public Dialog_AskEmailAccount Dialog;

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
		string _Output_AccountName;
		public string Output_AccountName {
            get { return _Output_AccountName; }
            set { _Output_AccountName = value;   Refresh (); }
            }
		string _Output_AccountAddress;
		public string Output_AccountAddress {
            get { return _Output_AccountAddress; }
            set { _Output_AccountAddress = value;   Refresh (); }
            }
		string _Output_AccountPersonal;
		public string Output_AccountPersonal {
            get { return _Output_AccountPersonal; }
            set { _Output_AccountPersonal = value;   Refresh (); }
            }



		/// <summary>
		/// Here goes the action to be overriden
		/// </summary>

		public virtual bool YesEmail () {
			return true;
			}

		/// <summary>
		/// Here goes the action to be overriden
		/// </summary>

		public virtual bool NoEmail () {
			return true;
			}


		}

    public partial class AskEmailAccount : _Data_AskEmailAccount {

		
		public AskEmailAccount (AddProfile  Data) {
			_Data = Data;

			// NB call to the initializer before we creaate the dialog so the
			// dialog can display the initialized data.
			Initialize ();
			this.Dialog = new Dialog_AskEmailAccount (this);
			}
		}


    /// <summary>
	/// This is the code behind for the XAML generated class.
    /// </summary>
    public partial class Dialog_AskEmailAccount : Page {

		public AskEmailAccount  Data;


		public Dialog_AskEmailAccount (AskEmailAccount Data) {
			InitializeComponent();
			this.Data = Data;
			Refresh ();

			}

		public void Refresh () {
			Output_AccountName.Text  = Data.Output_AccountName;
			Output_AccountAddress.Text  = Data.Output_AccountAddress;
			Output_AccountPersonal.Text  = Data.Output_AccountPersonal;
			}

        private void Action_YesEmail(object sender, RoutedEventArgs e) {
			var Result = Data.YesEmail ();
			if (Result) {
				Data.Data.Navigate (Data.Data.Data_AskEmailAccount);
				}
            }
        private void Action_NoEmail(object sender, RoutedEventArgs e) {
			var Result = Data.NoEmail ();
			if (Result) {
				Data.Data.Navigate (Data.Data.Data_AskEmailAccount);
				}
            }



		}
	}

