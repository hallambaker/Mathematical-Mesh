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
using System.Windows.Shapes;
using System.Threading;
using System.ComponentModel;
using Goedel.Trojan;

namespace Goedel.MeshConnect {


    public partial class Wizard_ConnectProfile : Window {

        public ConnectProfile Data;

        public Wizard_ConnectProfile() {
            InitializeComponent();

            Data = new ConnectProfile(this);
            }

        }

    public partial class ConnectProfile : Goedel.Trojan.Data {
        public Wizard_ConnectProfile Wizard;

		ConnectDevice _Data_ConnectDevice = null;
		ConnectPending _Data_ConnectPending = null;
		CheckFingerPrint _Data_CheckFingerPrint = null;
		WaitToComplete _Data_WaitToComplete = null;
		Complete _Data_Complete = null;

		public ConnectDevice Data_ConnectDevice {
			get { _Data_ConnectDevice = _Data_ConnectDevice != null ? _Data_ConnectDevice : new ConnectDevice (this);
			return _Data_ConnectDevice; } }
		public ConnectPending Data_ConnectPending {
			get { _Data_ConnectPending = _Data_ConnectPending != null ? _Data_ConnectPending : new ConnectPending (this);
			return _Data_ConnectPending; } }
		public CheckFingerPrint Data_CheckFingerPrint {
			get { _Data_CheckFingerPrint = _Data_CheckFingerPrint != null ? _Data_CheckFingerPrint : new CheckFingerPrint (this);
			return _Data_CheckFingerPrint; } }
		public WaitToComplete Data_WaitToComplete {
			get { _Data_WaitToComplete = _Data_WaitToComplete != null ? _Data_WaitToComplete : new WaitToComplete (this);
			return _Data_WaitToComplete; } }
		public Complete Data_Complete {
			get { _Data_Complete = _Data_Complete != null ? _Data_Complete : new Complete (this);
			return _Data_Complete; } }


		public ConnectProfile (Wizard_ConnectProfile Wizard) {
			this.Wizard = Wizard;
			Initialize ();
			if (CurrentDialog == null) {
				Navigate (Data_ConnectDevice);
				}
			}


		/// <summary>
		/// The currently active dialog
		/// </summary>
		public Goedel.Trojan.Data CurrentDialog = null ;

		/// <summary>
		/// Navigate to a new dialog.
		/// </summary>
		public void Navigate (Goedel.Trojan.Data Dialog) {
			if (CurrentDialog != null) {
				CurrentDialog.Exit ();
				}
			CurrentDialog = Dialog;
			CurrentDialog.Enter ();

			Wizard.Main.Navigate (Dialog.Page);
			}

		}
	}

