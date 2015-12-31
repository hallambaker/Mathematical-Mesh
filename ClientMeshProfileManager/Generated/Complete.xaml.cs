
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

    public partial class _Data_Complete :Goedel.Trojan.Data  {
		public Dialog_Complete Dialog;

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

		public virtual bool ExitProgram () {
			return true;
			}

		/// <summary>
		/// Here goes the action to be overriden
		/// </summary>

		public virtual bool CheckPending () {
			return true;
			}

		/// <summary>
		/// Here goes the action to be overriden
		/// </summary>

		public virtual bool Erase () {
			return true;
			}


		}

    public partial class Complete : _Data_Complete {

		
		public Complete (AddProfile  Data) {
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
			}

        private void Action_ExitProgram(object sender, RoutedEventArgs e) {
			var Result = Data.ExitProgram ();
			if (Result) {
				Data.Data.Navigate (Data.Data.Data_Complete);
				}
            }
        private void Action_CheckPending(object sender, RoutedEventArgs e) {
			var Result = Data.CheckPending ();
			if (Result) {
				Data.Data.Navigate (Data.Data.Data_Complete);
				}
            }
        private void Action_Erase(object sender, RoutedEventArgs e) {
			var Result = Data.Erase ();
			if (Result) {
				Data.Data.Navigate (Data.Data.Data_AddAccountStart);
				}
            }



		}
	}

