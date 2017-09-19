
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

    public partial class _Data_WaitToComplete :Goedel.Trojan.Data  {
		public Dialog_WaitToComplete Dialog;

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
		string _Output_Device2;
		public string Output_Device2 {
            get { return _Output_Device2; }
            set { _Output_Device2 = value;   Refresh (); }
            }



		/// <summary>
		/// Here goes the action to be overriden
		/// </summary>

		public virtual bool Check () {
			return true;
			}


		}

    public partial class WaitToComplete : _Data_WaitToComplete {

		
		public WaitToComplete (ConnectProfile  Data) {
			_Data = Data;

			// NB call to the initializer before we creaate the dialog so the
			// dialog can display the initialized data.
			Initialize ();
			this.Dialog = new Dialog_WaitToComplete (this);
			}
		}


    /// <summary>
	/// This is the code behind for the XAML generated class.
    /// </summary>
    public partial class Dialog_WaitToComplete : Page {

		public WaitToComplete  Data;


		public Dialog_WaitToComplete (WaitToComplete Data) {
			InitializeComponent();
			this.Data = Data;
			Refresh ();

			}

		public void Refresh () {
			Output_Device2.Text  = Data.Output_Device2;
			}

        private void Action_Check(object sender, RoutedEventArgs e) {
			var Result = Data.Check ();
			if (Result) {
				Data.Data.Navigate (Data.Data.Data_Complete);
				}
            }



		}
	}

