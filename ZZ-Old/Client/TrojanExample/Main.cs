using System;
using System.Collections.Generic;
using Goedel.Trojan;
using Goedel.Trojan.GTK;


namespace PHB.Apps.Mesh.ProfileManager {
    public class Wrapper {
        static void Main(string[] args) {
            //Application.Init();
            //new MainWindow();
            //Application.Run();


            var Binding = new BindingGTK(); // Initialize the window system
            var ProfileManager = new ProfileManager(Binding);
            Binding.Run();
            }
        }


    public partial class ProfileManager {
        Binding Binding;
        Window MainWindow;

        public ProfileManager(Binding Binding) {

            // Here fill up the selection list with 
            // profiles, applications, devices
            Populate();

            // Now creat the window system
            this.Binding = Binding;
            MainWindow = new MainWindow(this, Binding);


            }

        public override void Quit() {
            Binding.Quit();
            }

        public void Populate() {
            var Profile1 = new Profile {
                Title = "Main Profile",
                Fingerprint = "blahdy blah" };
            Selector.Add(Profile1);

            var Profile2 = new Profile {
                Title = "Site Profile",
                Fingerprint = "More blahdy blah"
                };
            Selector.Add(Profile2);


            Profile1.Devices = new List<Device>();
            var Device1 = new Device {
                Title = "Voodoo" };
            Profile1.Devices.Add(Device1);

            var Device2 = new Device {
                Title = "iPad"};
            Profile1.Devices.Add(Device2);

            var Device3 = new Device {
                Title = "Router"};
            Profile1.Devices.Add(Device3);


            }

        }


    public partial class MainWindow {




        }


    }


    //Dictionary<ToggleButton, Widget> children = new Dictionary<ToggleButton, Widget>();


    //public MainWindow() : base("This is my Window") {
    //    Resize(200, 200);


    //    VBox box1 = new VBox(false, 0);
    //    Add(box1);


    //    MenuBar menubar = new MenuBar();
    //    box1.PackStart(menubar, false, true, 0);


    //    MenuItem menuitem = new MenuItem("test\nline2");
    //    menubar.Append(menuitem);

    //    var Pane = new HPaned();
    //    box1.Add(Pane);

    //    Frame frame = new Frame();
    //    frame.ShadowType = ShadowType.In;
    //    frame.SetSizeRequest(60, 60);
    //    Pane.Add1(frame);

    //    Gtk.Button button = new Button("_Hi there");
    //    frame.Add(button);

    //    frame = new Frame();
    //    frame.ShadowType = ShadowType.In;
    //    frame.SetSizeRequest(80, 60);
    //    Pane.Add2(frame);

    //    frame = new Frame();
    //    frame.ShadowType = ShadowType.In;
    //    frame.SetSizeRequest(60, 80);
    //    Pane.Add2(frame);


    //    // Now create toggle buttons to control sizing
    //    box1.PackStart(CreatePaneOptions(Pane,
    //                       "Horizontal",
    //                       "Left",
    //                       "Right"),
    //            false, false, 0);

    //    ShowAll();
    //    }


    //Frame CreatePaneOptions(Paned paned, string frameLabel,
    //             string label1, string label2) {
    //    Frame frame = new Frame(frameLabel);
    //    frame.BorderWidth = 4;

    //    Table table = new Table(3, 2, true);
    //    frame.Add(table);

    //    Label label = new Label(label1);
    //    table.Attach(label, 0, 1, 0, 1);

    //    CheckButton check = new CheckButton("_Resize");
    //    table.Attach(check, 0, 1, 1, 2);
    //    check.Toggled += new EventHandler(ToggleResize);
    //    children[check] = paned.Child1;

    //    check = new CheckButton("_Shrink");
    //    table.Attach(check, 0, 1, 2, 3);
    //    check.Active = true;
    //    check.Toggled += new EventHandler(ToggleShrink);
    //    children[check] = paned.Child1;

    //    label = new Label(label2);
    //    table.Attach(label, 1, 2, 0, 1);

    //    check = new CheckButton("_Resize");
    //    table.Attach(check, 1, 2, 1, 2);
    //    check.Active = true;
    //    check.Toggled += new EventHandler(ToggleResize);
    //    children[check] = paned.Child2;

    //    check = new CheckButton("_Shrink");
    //    table.Attach(check, 1, 2, 2, 3);
    //    check.Active = true;
    //    check.Toggled += new EventHandler(ToggleShrink);
    //    children[check] = paned.Child2;

    //    return frame;
    //    }

    //private void ToggleResize(object obj, EventArgs args) {
    //    ToggleButton toggle = obj as ToggleButton;
    //    Widget child = children[toggle];
    //    Paned paned = child.Parent as Paned;

    //    Paned.PanedChild pc = paned[child] as Paned.PanedChild;
    //    pc.Resize = toggle.Active;
    //    }

    //private void ToggleShrink(object obj, EventArgs args) {
    //    ToggleButton toggle = obj as ToggleButton;
    //    Widget child = children[toggle];
    //    Paned paned = child.Parent as Paned;

    //    Paned.PanedChild pc = paned[child] as Paned.PanedChild;
    //    pc.Shrink = toggle.Active;
    //    }


