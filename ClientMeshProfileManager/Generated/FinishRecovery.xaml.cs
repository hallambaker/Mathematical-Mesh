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

    public partial class _Data_FinishRecovery :Goedel.Trojan.Data  {
		public Dialog_FinishRecovery Dialog;

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
		string _Output_Fingerprintf;
		public string Output_Fingerprintf {
            get { return _Output_Fingerprintf; }
            set { _Output_Fingerprintf = value;   Refresh (); }
            }
		string _Output_RecoveryShare1f;
		public string Output_RecoveryShare1f {
            get { return _Output_RecoveryShare1f; }
            set { _Output_RecoveryShare1f = value;   Refresh (); }
            }
		string _Output_RecoveryShare2f;
		public string Output_RecoveryShare2f {
            get { return _Output_RecoveryShare2f; }
            set { _Output_RecoveryShare2f = value;   Refresh (); }
            }
		string _Output_RecoveryShare3f;
		public string Output_RecoveryShare3f {
            get { return _Output_RecoveryShare3f; }
            set { _Output_RecoveryShare3f = value;   Refresh (); }
            }



		/// <summary>
		/// Here goes the action to be overriden
		/// </summary>

		public virtual bool NextClose1 () {
			return true;
			}


		}

    public partial class FinishRecovery : _Data_FinishRecovery {

		
		public FinishRecovery (AddProfile  Data) {
			_Data = Data;

			// NB call to the initializer before we creaate the dialog so the
			// dialog can display the initialized data.
			Initialize ();
			this.Dialog = new Dialog_FinishRecovery (this);
			}
		}


    /// <summary>
	/// This is the code behind for the XAML generated class.
    /// </summary>
    public partial class Dialog_FinishRecovery : Page {

		public FinishRecovery  Data;


		public Dialog_FinishRecovery (FinishRecovery Data) {
			InitializeComponent();
			this.Data = Data;
			Refresh ();

			}

		public void Refresh () {
			Output_Fingerprintf.Text  = Data.Output_Fingerprintf;
			Output_RecoveryShare1f.Text  = Data.Output_RecoveryShare1f;
			Output_RecoveryShare2f.Text  = Data.Output_RecoveryShare2f;
			Output_RecoveryShare3f.Text  = Data.Output_RecoveryShare3f;
			}

        private void Action_NextClose1(object sender, RoutedEventArgs e) {
			var Result = Data.NextClose1 ();
			if (Result) {
				Data.Data.Navigate (Data.Data.Data_SetupComplete);
				}
            }



		}
	}

