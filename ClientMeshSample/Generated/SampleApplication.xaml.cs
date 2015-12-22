//   Copyright © 2015 by Comodo Group Inc.
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
//  
//  
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

