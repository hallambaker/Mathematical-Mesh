
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

    public partial class _Data_GenerateRecoveryKeys :Goedel.Trojan.Data  {
		public Dialog_GenerateRecoveryKeys Dialog;

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

		public int Completion_GenerateKeysTask2 = 0;

		public virtual void Do_GenerateKeysTask2 () {
            Completion_GenerateKeysTask2 = -1;
			Dialog.UpdateProgress ();
			GenerateKeysTask2 ();
            Completion_GenerateKeysTask2 = 100;
			Dialog.UpdateProgress ();
			}

		public virtual void GenerateKeysTask2 () {
            Thread.Sleep(2000);
            Completion_GenerateKeysTask2 = 100;
			}



		}

    public partial class GenerateRecoveryKeys : _Data_GenerateRecoveryKeys {

		
		public GenerateRecoveryKeys (AddProfile  Data) {
			_Data = Data;

			// NB call to the initializer before we creaate the dialog so the
			// dialog can display the initialized data.
			Initialize ();
			this.Dialog = new Dialog_GenerateRecoveryKeys (this);
			}
		}


    /// <summary>
	/// This is the code behind for the XAML generated class.
    /// </summary>
    public partial class Dialog_GenerateRecoveryKeys : Page {

		public GenerateRecoveryKeys  Data;

		public BackgroundWorker BackgroundWorker;

		public Dialog_GenerateRecoveryKeys (GenerateRecoveryKeys Data) {
			InitializeComponent();
			this.Data = Data;
			Refresh ();

            BackgroundWorker = new BackgroundWorker();
            BackgroundWorker.WorkerReportsProgress = true;
            BackgroundWorker.DoWork += new DoWorkEventHandler(DoWork);
            BackgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(RunWorkerCompleted);
            BackgroundWorker.ProgressChanged += new ProgressChangedEventHandler(ProgressChanged);
            BackgroundWorker.RunWorkerAsync();
			}

        // Should probably move this to the Data class so that it can be inherited
        public void DoWork(object sender, DoWorkEventArgs e) {
			Data.Do_GenerateKeysTask2 ();
            }

        public void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
			Data.Data.Navigate (Data.Data.Data_FinishRecovery);
            }

        public void ProgressChanged(object sender, ProgressChangedEventArgs e) {
			if (Data.Completion_GenerateKeysTask2 >= 0) {
				Task_GenerateKeysTask2.Value = Data.Completion_GenerateKeysTask2;
				Task_GenerateKeysTask2.IsIndeterminate = false;
				}
			else {
				Task_GenerateKeysTask2.IsIndeterminate = true;
				}
			Refresh ();
            }

		public void UpdateProgress () {
			BackgroundWorker.ReportProgress(100);
			} 
		public void Refresh () {
			}




		}
	}

