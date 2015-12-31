
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

    public partial class _Data_SelectApplication :Goedel.Trojan.Data  {
		public Dialog_SelectApplication Dialog;

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



		/// <summary>
		/// Here goes the action to be overriden
		/// </summary>

		public virtual bool Password () {
			return true;
			}

		/// <summary>
		/// Here goes the action to be overriden
		/// </summary>

		public virtual bool Network () {
			return true;
			}

		/// <summary>
		/// Here goes the action to be overriden
		/// </summary>

		public virtual bool Email () {
			return true;
			}


		}

    public partial class SelectApplication : _Data_SelectApplication {

		
		public SelectApplication (SampleApplication  Data) {
			_Data = Data;

			// NB call to the initializer before we creaate the dialog so the
			// dialog can display the initialized data.
			Initialize ();
			this.Dialog = new Dialog_SelectApplication (this);
			}
		}


    /// <summary>
	/// This is the code behind for the XAML generated class.
    /// </summary>
    public partial class Dialog_SelectApplication : Page {

		public SelectApplication  Data;


		public Dialog_SelectApplication (SelectApplication Data) {
			InitializeComponent();
			this.Data = Data;
			Refresh ();

			}

		public void Refresh () {
			}

        private void Action_Password(object sender, RoutedEventArgs e) {
			var Result = Data.Password ();
			if (Result) {
				Data.Data.Navigate (Data.Data.Data_SelectPassword);
				}
            }
        private void Action_Network(object sender, RoutedEventArgs e) {
			var Result = Data.Network ();
			if (Result) {
				Data.Data.Navigate (Data.Data.Data_SelectNetwork);
				}
            }
        private void Action_Email(object sender, RoutedEventArgs e) {
			var Result = Data.Email ();
			if (Result) {
				Data.Data.Navigate (Data.Data.Data_SelectEmail);
				}
            }



		}
	}

