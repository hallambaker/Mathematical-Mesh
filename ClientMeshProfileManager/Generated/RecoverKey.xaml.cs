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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Threading;
using Goedel.Trojan;

namespace Goedel.MeshProfileManager {

    public partial class _Data_RecoverKey :Goedel.Trojan.Data  {
		public Dialog_RecoverKey Dialog;

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
		string _Input_RecoveryShare1;
		public string Input_RecoveryShare1 {
            get { return _Input_RecoveryShare1; }
            set { _Input_RecoveryShare1 = value;  Refresh (); }
            }
		string _Input_RecoveryShare2;
		public string Input_RecoveryShare2 {
            get { return _Input_RecoveryShare2; }
            set { _Input_RecoveryShare2 = value;  Refresh (); }
            }

		// Output backing variables



		/// <summary>
		/// Here goes the action to be overriden
		/// </summary>

		public virtual bool Recover () {
			return true;
			}


		}

    public partial class RecoverKey : _Data_RecoverKey {

		
		public RecoverKey (AddProfile  Data) {
			_Data = Data;

			// NB call to the initializer before we creaate the dialog so the
			// dialog can display the initialized data.
			Initialize ();
			this.Dialog = new Dialog_RecoverKey (this);
			}
		}


    /// <summary>
	/// This is the code behind for the XAML generated class.
    /// </summary>
    public partial class Dialog_RecoverKey : Page {

		public RecoverKey  Data;


		public Dialog_RecoverKey (RecoverKey Data) {
			InitializeComponent();
			this.Data = Data;
			Refresh ();

			}

		public void Refresh () {
			Input_RecoveryShare1.Text  = Data.Input_RecoveryShare1;
			Input_RecoveryShare2.Text  = Data.Input_RecoveryShare2;
			}

        private void Action_Recover(object sender, RoutedEventArgs e) {
			var Result = Data.Recover ();
			if (Result) {
				Data.Data.Navigate (Data.Data.Data_RecoverKeySuccess);
				}
            }


		private void Changed_Input_RecoveryShare1 (object sender, TextChangedEventArgs e) {
			Data.Input_RecoveryShare1 = Input_RecoveryShare1.Text;
			}
		private void Changed_Input_RecoveryShare2 (object sender, TextChangedEventArgs e) {
			Data.Input_RecoveryShare2 = Input_RecoveryShare2.Text;
			}

		}
	}

