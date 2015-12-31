
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

    public partial class _Data_SelectPassword :Goedel.Trojan.Data  {
		public Dialog_SelectPassword Dialog;

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

		// Output backing variables
		string _Output_PasswordConfiguration;
		public string Output_PasswordConfiguration {
            get { return _Output_PasswordConfiguration; }
            set { _Output_PasswordConfiguration = value;   Refresh (); }
            }



		/// <summary>
		/// Here goes the action to be overriden
		/// </summary>

		public virtual bool AddPassword () {
			return true;
			}

		/// <summary>
		/// Here goes the action to be overriden
		/// </summary>

		public virtual bool CancelPassword () {
			return true;
			}


		}

    public partial class SelectPassword : _Data_SelectPassword {

		
		public SelectPassword (SampleApplication  Data) {
			_Data = Data;

			// NB call to the initializer before we creaate the dialog so the
			// dialog can display the initialized data.
			Initialize ();
			this.Dialog = new Dialog_SelectPassword (this);
			}
		}


    /// <summary>
	/// This is the code behind for the XAML generated class.
    /// </summary>
    public partial class Dialog_SelectPassword : Page {

		public SelectPassword  Data;


		public Dialog_SelectPassword (SelectPassword Data) {
			InitializeComponent();
			this.Data = Data;
			Refresh ();

			}

		public void Refresh () {
			Output_PasswordConfiguration.Text  = Data.Output_PasswordConfiguration;
			}

        private void Action_AddPassword(object sender, RoutedEventArgs e) {
			var Result = Data.AddPassword ();
			if (Result) {
				Data.Data.Navigate (Data.Data.Data_PasswordDialog);
				}
            }
        private void Action_CancelPassword(object sender, RoutedEventArgs e) {
			var Result = Data.CancelPassword ();
			if (Result) {
				Data.Data.Navigate (Data.Data.Data_SelectApplication);
				}
            }



		}
	}

