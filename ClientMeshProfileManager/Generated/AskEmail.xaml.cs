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

    public partial class _Data_AskEmail :Goedel.Trojan.Data  {
		public Dialog_AskEmail Dialog;

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

		public virtual bool ConfigureEmail () {
			return true;
			}

		/// <summary>
		/// Here goes the action to be overriden
		/// </summary>

		public virtual bool SkipEmail () {
			return true;
			}


		}

    public partial class AskEmail : _Data_AskEmail {

		
		public AskEmail (AddProfile  Data) {
			_Data = Data;

			// NB call to the initializer before we creaate the dialog so the
			// dialog can display the initialized data.
			Initialize ();
			this.Dialog = new Dialog_AskEmail (this);
			}
		}


    /// <summary>
	/// This is the code behind for the XAML generated class.
    /// </summary>
    public partial class Dialog_AskEmail : Page {

		public AskEmail  Data;


		public Dialog_AskEmail (AskEmail Data) {
			InitializeComponent();
			this.Data = Data;
			Refresh ();

			}

		public void Refresh () {
			}

        private void Action_ConfigureEmail(object sender, RoutedEventArgs e) {
			var Result = Data.ConfigureEmail ();
			if (Result) {
				Data.Data.Navigate (Data.Data.Data_AskEmailAccount);
				}
            }
        private void Action_SkipEmail(object sender, RoutedEventArgs e) {
			var Result = Data.SkipEmail ();
			if (Result) {
				Data.Data.Navigate (Data.Data.Data_AskRecovery);
				}
            }



		}
	}

