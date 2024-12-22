using System;
using System.Windows.Forms;

namespace KingVonPasswordManager
{
    public partial class PasswordGen : Form
    {
        private GeneratorController controller;
        public TrackBar GetTrackBar() { return trackBar1; } // getter for the trackbar

        public PasswordGen()    // constructor
        {
            InitializeComponent();  // initializes the components

            label1.Text = trackBar1.Value.ToString();   // sets the text of label1 to the value of the trackbar

            trackBar1.ValueChanged += TrackBar1ValueChanged;    // subscribes to the value changed event of the trackbar

            label1.Left = (this.ClientSize.Width - label1.Width) / 2;   // centers the label1
            label2.Left = (this.ClientSize.Width - label2.Width) / 2;   // centers the label2
            button1.Left = (this.ClientSize.Width - button1.Width) / 2; // centers the button1
            trackBar1.Left = (this.ClientSize.Width - trackBar1.Width) / 2; // centers the trackbar

            label2.Resize += CenterPassword;    // subscribes to the resize event of label2. Centers the label2 when the form is resized.

            controller = new GeneratorController(this); // new generator object with this form object as parameter
        }

        // event handler for the value changed event of the trackbar
        private void TrackBar1ValueChanged(object sender, EventArgs e) { label1.Text = trackBar1.Value.ToString(); }  // sets the text of label1 to the value of the trackbar

        // unused event handlers
        private void Form1_Load(object sender, EventArgs e) { }
        private void trackBar1_Scroll(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }

        // event handler for the generate password button
        private void button1_Click(object sender, EventArgs e)
        {
            controller.GeneratePassword();      // calls the generate password method from the generator object
            label2.Text = controller.GetPasswordAsString();     // sets the text of label2 to the password as string
        }

        // event handler for the copy password button
        private void button2_Click(object sender, EventArgs e)
        {
            if (controller.GetPasswordAsString() != null)   // checks if the password is not null
            {
                Clipboard.SetText(controller.GetPasswordAsString());    // copies the password to the clipboard
            }
            else { Clipboard.SetText(" "); }    // if the password is null, copies a space to the clipboard
        }

        // event handler for centering the password label
        private void CenterPassword(object sender, EventArgs e) { label2.Left = (this.ClientSize.Width - label2.Width) / 2; }   // centers the label2
    }
}
