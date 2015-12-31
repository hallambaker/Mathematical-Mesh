
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

    public partial class _Data_SelectNetwork :Goedel.Trojan.Data  {
		public Dialog_SelectNetwork Dialog;

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
		string _Output_NetworkConfiguration;
		public string Output_NetworkConfiguration {
            get { return _Output_NetworkConfiguration; }
            set { _Output_NetworkConfiguration = value;   Refresh (); }
            }



		/// <summary>
		/// Here goes the action to be overriden
		/// </summary>

		public virtual bool SetNetwork () {
			return true;
			}

		/// <summary>
		/// Here goes the action to be overriden
		/// </summary>

		public virtual bool CancelNetwork () {
			return true;
			}


		}

    public partial class SelectNetwork : _Data_SelectNetwork {

		
		public SelectNetwork (SampleApplication  Data) {
			_Data = Data;

			// NB call to the initializer before we creaate the dialog so the
			// dialog can display the initialized data.
			Initialize ();
			this.Dialog = new Dialog_SelectNetwork (this);
			}
		}


    /// <summary>
	/// This is the code behind for the XAML generated class.
    /// </summary>
    public partial class Dialog_SelectNetwork : Page {

		public SelectNetwork  Data;


		public Dialog_SelectNetwork (SelectNetwork Data) {
			InitializeComponent();
			this.Data = Data;
			Refresh ();

			}

		public void Refresh () {
			Output_NetworkConfiguration.Text  = Data.Output_NetworkConfiguration;
			}

        private void Action_SetNetwork(object sender, RoutedEventArgs e) {
			var Result = Data.SetNetwork ();
			if (Result) {
				Data.Data.Navigate (Data.Data.Data_NetworkDialog);
				}
            }
        private void Action_CancelNetwork(object sender, RoutedEventArgs e) {
			var Result = Data.CancelNetwork ();
			if (Result) {
				Data.Data.Navigate (Data.Data.Data_SelectApplication);
				}
            }



		}
	}

