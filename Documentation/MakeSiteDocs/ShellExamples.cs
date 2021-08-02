namespace ExampleGenerator {
    public partial class CreateExamples {

        public void LayerAccount() {
            //DoCommandsCreateAcount();

            ShellAccount = new ShellAccount(this);

            ShellBookmark = new ShellBookmark(this);
            ShellPassword = new ShellPassword(this);
            ShellNetwork = new ShellNetwork(this);
            ShellCalendar = new ShellCalendar(this);
            ShellMessage = new ShellMessage(this);
            ShellContact = new ShellContact(this);
            ShellGroup = new ShellGroup(this);

            ShellSSH = new ShellSSH(this);
            ShellMail = new ShellMail(this);
            }


        }
    }
