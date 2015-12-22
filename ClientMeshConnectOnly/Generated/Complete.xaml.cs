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

namespace Goedel.MeshConnect {

    public partial class _Data_Complete :Goedel.Trojan.Data  {
		public Dialog_Complete Dialog;

		public override Page Page {
		    get { return Dialog; }
			}

		protected ConnectProfile _Data;
		public ConnectProfile Data {
			get {return _Data;}
			}


		public void Refresh () {
			if (Dialog != null) {
				Dialog.Refresh ();
				}
			}

//		protected Wizard_ConnectProfile  _Wizard;	
//		public Wizard_ConnectProfile  Wizard {
//				get {return _Wizard;}
//				}
//		public Data_ConnectProfile  Data {
//				get {return Wizard.Data;}
//				}

		// Input backing variables

		// Output backing variables
		string _Output_ProfileData;
		public string Output_ProfileData {
            get { return _Output_ProfileData; }
            set { _Output_ProfileData = value;   Refresh (); }
            }



		/// <summary>
		/// Here goes the action to be overriden
		/// </summary>

		public virtual bool ExitProgram () {
			return true;
			}


		}

    public partial class Complete : _Data_Complete {

		
		public Complete (ConnectProfile  Data) {
			_Data = Data;

			// NB call to the initializer before we creaate the dialog so the
			// dialog can display the initialized data.
			Initialize ();
			this.Dialog = new Dialog_Complete (this);
			}
		}


    /// <summary>
	/// This is the code behind for the XAML generated class.
    /// </summary>
    public partial class Dialog_Complete : Page {

		public Complete  Data;


		public Dialog_Complete (Complete Data) {
			InitializeComponent();
			this.Data = Data;
			Refresh ();

			}

		public void Refresh () {
			Output_ProfileData.Text  = Data.Output_ProfileData;
			}

        private void Action_ExitProgram(object sender, RoutedEventArgs e) {
			var Result = Data.ExitProgram ();
			if (Result) {
				Data.Data.Navigate (Data.Data.Data_ConnectDevice);
				}
            }



		}
	}

