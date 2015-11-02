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

namespace Goedel.MeshSampleClient {


    public partial class Wizard_SampleApplication : Window {

        public SampleApplication Data;

        public Wizard_SampleApplication() {
            InitializeComponent();

            Data = new SampleApplication(this);
            }

        }

    public partial class SampleApplication : Goedel.Trojan.Data {
        public Wizard_SampleApplication Wizard;

		SelectApplication _Data_SelectApplication = null;
		SelectPassword _Data_SelectPassword = null;
		SelectNetwork _Data_SelectNetwork = null;
		SelectEmail _Data_SelectEmail = null;
		PasswordDialog _Data_PasswordDialog = null;
		NetworkDialog _Data_NetworkDialog = null;
		EmailDialog _Data_EmailDialog = null;
		TBS _Data_TBS = null;

		public SelectApplication Data_SelectApplication {
			get { _Data_SelectApplication = _Data_SelectApplication != null ? _Data_SelectApplication : new SelectApplication (this);
			return _Data_SelectApplication; } }
		public SelectPassword Data_SelectPassword {
			get { _Data_SelectPassword = _Data_SelectPassword != null ? _Data_SelectPassword : new SelectPassword (this);
			return _Data_SelectPassword; } }
		public SelectNetwork Data_SelectNetwork {
			get { _Data_SelectNetwork = _Data_SelectNetwork != null ? _Data_SelectNetwork : new SelectNetwork (this);
			return _Data_SelectNetwork; } }
		public SelectEmail Data_SelectEmail {
			get { _Data_SelectEmail = _Data_SelectEmail != null ? _Data_SelectEmail : new SelectEmail (this);
			return _Data_SelectEmail; } }
		public PasswordDialog Data_PasswordDialog {
			get { _Data_PasswordDialog = _Data_PasswordDialog != null ? _Data_PasswordDialog : new PasswordDialog (this);
			return _Data_PasswordDialog; } }
		public NetworkDialog Data_NetworkDialog {
			get { _Data_NetworkDialog = _Data_NetworkDialog != null ? _Data_NetworkDialog : new NetworkDialog (this);
			return _Data_NetworkDialog; } }
		public EmailDialog Data_EmailDialog {
			get { _Data_EmailDialog = _Data_EmailDialog != null ? _Data_EmailDialog : new EmailDialog (this);
			return _Data_EmailDialog; } }
		public TBS Data_TBS {
			get { _Data_TBS = _Data_TBS != null ? _Data_TBS : new TBS (this);
			return _Data_TBS; } }


		public SampleApplication (Wizard_SampleApplication Wizard) {
			this.Wizard = Wizard;
			Initialize ();
			if (CurrentDialog == null) {
				Navigate (Data_SelectApplication);
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

