
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

    public partial class _Data_RecoverKeySuccess :Goedel.Trojan.Data  {
		public Dialog_RecoverKeySuccess Dialog;

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
		string _Input_MeshGateway1;
		public string Input_MeshGateway1 {
            get { return _Input_MeshGateway1; }
            set { _Input_MeshGateway1 = value;  Refresh (); }
            }
		string _Input_AccountName1;
		public string Input_AccountName1 {
            get { return _Input_AccountName1; }
            set { _Input_AccountName1 = value;  Refresh (); }
            }

		// Output backing variables



		/// <summary>
		/// Here goes the action to be overriden
		/// </summary>

		public virtual bool RecoverRegister () {
			return true;
			}


		}

    public partial class RecoverKeySuccess : _Data_RecoverKeySuccess {

		
		public RecoverKeySuccess (AddProfile  Data) {
			_Data = Data;

			// NB call to the initializer before we creaate the dialog so the
			// dialog can display the initialized data.
			Initialize ();
			this.Dialog = new Dialog_RecoverKeySuccess (this);
			}
		}


    /// <summary>
	/// This is the code behind for the XAML generated class.
    /// </summary>
    public partial class Dialog_RecoverKeySuccess : Page {

		public RecoverKeySuccess  Data;


		public Dialog_RecoverKeySuccess (RecoverKeySuccess Data) {
			InitializeComponent();
			this.Data = Data;
			Refresh ();

			}

		public void Refresh () {
			Input_MeshGateway1.Text  = Data.Input_MeshGateway1;
			Input_AccountName1.Text  = Data.Input_AccountName1;
			}

        private void Action_RecoverRegister(object sender, RoutedEventArgs e) {
			var Result = Data.RecoverRegister ();
			if (Result) {
				Data.Data.Navigate (Data.Data.Data_Finish);
				}
            }


		private void Changed_Input_MeshGateway1 (object sender, TextChangedEventArgs e) {
			Data.Input_MeshGateway1 = Input_MeshGateway1.Text;
			}
		private void Changed_Input_AccountName1 (object sender, TextChangedEventArgs e) {
			Data.Input_AccountName1 = Input_AccountName1.Text;
			}

		}
	}

