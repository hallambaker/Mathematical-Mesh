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

namespace Goedel.MeshProfileManager {


    public partial class Wizard_AddProfile : Window {

        public AddProfile Data;

        public Wizard_AddProfile() {
            InitializeComponent();

            Data = new AddProfile(this);
            }

        }

    public partial class AddProfile : Goedel.Trojan.Data {
        public Wizard_AddProfile Wizard;

		AddAccountStart _Data_AddAccountStart = null;
		SelectAdvanced _Data_SelectAdvanced = null;
		SelectNormal _Data_SelectNormal = null;
		AskPassword _Data_AskPassword = null;
		AskNetwork _Data_AskNetwork = null;
		AskEmail _Data_AskEmail = null;
		AskEmailAccount _Data_AskEmailAccount = null;
		NoEmailFound _Data_NoEmailFound = null;
		AskRecovery _Data_AskRecovery = null;
		GenerateKeys _Data_GenerateKeys = null;
		GenerateRecoveryKeys _Data_GenerateRecoveryKeys = null;
		Finish _Data_Finish = null;
		FinishRecovery _Data_FinishRecovery = null;
		ConnectDevice _Data_ConnectDevice = null;
		ConnectPending _Data_ConnectPending = null;
		CheckFingerPrint _Data_CheckFingerPrint = null;
		RecoverKey _Data_RecoverKey = null;
		RecoverKeySuccess _Data_RecoverKeySuccess = null;
		WaitToComplete _Data_WaitToComplete = null;
		Cancelled _Data_Cancelled = null;
		TBS _Data_TBS = null;
		SetupComplete _Data_SetupComplete = null;
		ProcessPending _Data_ProcessPending = null;
		Complete _Data_Complete = null;

		public AddAccountStart Data_AddAccountStart {
			get { _Data_AddAccountStart = _Data_AddAccountStart != null ? _Data_AddAccountStart : new AddAccountStart (this);
			return _Data_AddAccountStart; } }
		public SelectAdvanced Data_SelectAdvanced {
			get { _Data_SelectAdvanced = _Data_SelectAdvanced != null ? _Data_SelectAdvanced : new SelectAdvanced (this);
			return _Data_SelectAdvanced; } }
		public SelectNormal Data_SelectNormal {
			get { _Data_SelectNormal = _Data_SelectNormal != null ? _Data_SelectNormal : new SelectNormal (this);
			return _Data_SelectNormal; } }
		public AskPassword Data_AskPassword {
			get { _Data_AskPassword = _Data_AskPassword != null ? _Data_AskPassword : new AskPassword (this);
			return _Data_AskPassword; } }
		public AskNetwork Data_AskNetwork {
			get { _Data_AskNetwork = _Data_AskNetwork != null ? _Data_AskNetwork : new AskNetwork (this);
			return _Data_AskNetwork; } }
		public AskEmail Data_AskEmail {
			get { _Data_AskEmail = _Data_AskEmail != null ? _Data_AskEmail : new AskEmail (this);
			return _Data_AskEmail; } }
		public AskEmailAccount Data_AskEmailAccount {
			get { _Data_AskEmailAccount = _Data_AskEmailAccount != null ? _Data_AskEmailAccount : new AskEmailAccount (this);
			return _Data_AskEmailAccount; } }
		public NoEmailFound Data_NoEmailFound {
			get { _Data_NoEmailFound = _Data_NoEmailFound != null ? _Data_NoEmailFound : new NoEmailFound (this);
			return _Data_NoEmailFound; } }
		public AskRecovery Data_AskRecovery {
			get { _Data_AskRecovery = _Data_AskRecovery != null ? _Data_AskRecovery : new AskRecovery (this);
			return _Data_AskRecovery; } }
		public GenerateKeys Data_GenerateKeys {
			get { _Data_GenerateKeys = _Data_GenerateKeys != null ? _Data_GenerateKeys : new GenerateKeys (this);
			return _Data_GenerateKeys; } }
		public GenerateRecoveryKeys Data_GenerateRecoveryKeys {
			get { _Data_GenerateRecoveryKeys = _Data_GenerateRecoveryKeys != null ? _Data_GenerateRecoveryKeys : new GenerateRecoveryKeys (this);
			return _Data_GenerateRecoveryKeys; } }
		public Finish Data_Finish {
			get { _Data_Finish = _Data_Finish != null ? _Data_Finish : new Finish (this);
			return _Data_Finish; } }
		public FinishRecovery Data_FinishRecovery {
			get { _Data_FinishRecovery = _Data_FinishRecovery != null ? _Data_FinishRecovery : new FinishRecovery (this);
			return _Data_FinishRecovery; } }
		public ConnectDevice Data_ConnectDevice {
			get { _Data_ConnectDevice = _Data_ConnectDevice != null ? _Data_ConnectDevice : new ConnectDevice (this);
			return _Data_ConnectDevice; } }
		public ConnectPending Data_ConnectPending {
			get { _Data_ConnectPending = _Data_ConnectPending != null ? _Data_ConnectPending : new ConnectPending (this);
			return _Data_ConnectPending; } }
		public CheckFingerPrint Data_CheckFingerPrint {
			get { _Data_CheckFingerPrint = _Data_CheckFingerPrint != null ? _Data_CheckFingerPrint : new CheckFingerPrint (this);
			return _Data_CheckFingerPrint; } }
		public RecoverKey Data_RecoverKey {
			get { _Data_RecoverKey = _Data_RecoverKey != null ? _Data_RecoverKey : new RecoverKey (this);
			return _Data_RecoverKey; } }
		public RecoverKeySuccess Data_RecoverKeySuccess {
			get { _Data_RecoverKeySuccess = _Data_RecoverKeySuccess != null ? _Data_RecoverKeySuccess : new RecoverKeySuccess (this);
			return _Data_RecoverKeySuccess; } }
		public WaitToComplete Data_WaitToComplete {
			get { _Data_WaitToComplete = _Data_WaitToComplete != null ? _Data_WaitToComplete : new WaitToComplete (this);
			return _Data_WaitToComplete; } }
		public Cancelled Data_Cancelled {
			get { _Data_Cancelled = _Data_Cancelled != null ? _Data_Cancelled : new Cancelled (this);
			return _Data_Cancelled; } }
		public TBS Data_TBS {
			get { _Data_TBS = _Data_TBS != null ? _Data_TBS : new TBS (this);
			return _Data_TBS; } }
		public SetupComplete Data_SetupComplete {
			get { _Data_SetupComplete = _Data_SetupComplete != null ? _Data_SetupComplete : new SetupComplete (this);
			return _Data_SetupComplete; } }
		public ProcessPending Data_ProcessPending {
			get { _Data_ProcessPending = _Data_ProcessPending != null ? _Data_ProcessPending : new ProcessPending (this);
			return _Data_ProcessPending; } }
		public Complete Data_Complete {
			get { _Data_Complete = _Data_Complete != null ? _Data_Complete : new Complete (this);
			return _Data_Complete; } }


		public AddProfile (Wizard_AddProfile Wizard) {
			this.Wizard = Wizard;
			Initialize ();
			if (CurrentDialog == null) {
				Navigate (Data_AddAccountStart);
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

