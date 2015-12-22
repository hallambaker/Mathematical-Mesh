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

namespace Goedel.MeshSampleClient {

    public partial class _Data_SelectEmail :Goedel.Trojan.Data  {
		public Dialog_SelectEmail Dialog;

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
		string _Output_EmailConfiguration;
		public string Output_EmailConfiguration {
            get { return _Output_EmailConfiguration; }
            set { _Output_EmailConfiguration = value;   Refresh (); }
            }



		/// <summary>
		/// Here goes the action to be overriden
		/// </summary>

		public virtual bool SetEmail () {
			return true;
			}

		/// <summary>
		/// Here goes the action to be overriden
		/// </summary>

		public virtual bool CancelEmail () {
			return true;
			}


		}

    public partial class SelectEmail : _Data_SelectEmail {

		
		public SelectEmail (SampleApplication  Data) {
			_Data = Data;

			// NB call to the initializer before we creaate the dialog so the
			// dialog can display the initialized data.
			Initialize ();
			this.Dialog = new Dialog_SelectEmail (this);
			}
		}


    /// <summary>
	/// This is the code behind for the XAML generated class.
    /// </summary>
    public partial class Dialog_SelectEmail : Page {

		public SelectEmail  Data;


		public Dialog_SelectEmail (SelectEmail Data) {
			InitializeComponent();
			this.Data = Data;
			Refresh ();

			}

		public void Refresh () {
			Output_EmailConfiguration.Text  = Data.Output_EmailConfiguration;
			}

        private void Action_SetEmail(object sender, RoutedEventArgs e) {
			var Result = Data.SetEmail ();
			if (Result) {
				Data.Data.Navigate (Data.Data.Data_EmailDialog);
				}
            }
        private void Action_CancelEmail(object sender, RoutedEventArgs e) {
			var Result = Data.CancelEmail ();
			if (Result) {
				Data.Data.Navigate (Data.Data.Data_SelectApplication);
				}
            }



		}
	}

