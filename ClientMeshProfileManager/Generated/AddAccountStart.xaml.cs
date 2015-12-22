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

    public partial class _Data_AddAccountStart :Goedel.Trojan.Data  {
		public Dialog_AddAccountStart Dialog;

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



		/// <summary>
		/// Here goes the action to be overriden
		/// </summary>

		public virtual bool NewAccount () {
			return true;
			}

		/// <summary>
		/// Here goes the action to be overriden
		/// </summary>

		public virtual bool ConnectAccount () {
			return true;
			}

		/// <summary>
		/// Here goes the action to be overriden
		/// </summary>

		public virtual bool RecoverAccount () {
			return true;
			}


		}

    public partial class AddAccountStart : _Data_AddAccountStart {

		
		public AddAccountStart (AddProfile  Data) {
			_Data = Data;

			// NB call to the initializer before we creaate the dialog so the
			// dialog can display the initialized data.
			Initialize ();
			this.Dialog = new Dialog_AddAccountStart (this);
			}
		}


    /// <summary>
	/// This is the code behind for the XAML generated class.
    /// </summary>
    public partial class Dialog_AddAccountStart : Page {

		public AddAccountStart  Data;


		public Dialog_AddAccountStart (AddAccountStart Data) {
			InitializeComponent();
			this.Data = Data;
			Refresh ();

			}

		public void Refresh () {
			}

        private void Action_NewAccount(object sender, RoutedEventArgs e) {
			var Result = Data.NewAccount ();
			if (Result) {
				Data.Data.Navigate (Data.Data.Data_SelectNormal);
				}
            }
        private void Action_ConnectAccount(object sender, RoutedEventArgs e) {
			var Result = Data.ConnectAccount ();
			if (Result) {
				Data.Data.Navigate (Data.Data.Data_ConnectDevice);
				}
            }
        private void Action_RecoverAccount(object sender, RoutedEventArgs e) {
			var Result = Data.RecoverAccount ();
			if (Result) {
				Data.Data.Navigate (Data.Data.Data_RecoverKey);
				}
            }



		}
	}

