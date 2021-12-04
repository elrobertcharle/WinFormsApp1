
namespace WindowsFormsApp2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SetCufCufdDateToXmlButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SignAndCompressButton = new System.Windows.Forms.Button();
            this.SendButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SetCufCufdDateToXmlButton
            // 
            this.SetCufCufdDateToXmlButton.Location = new System.Drawing.Point(281, 216);
            this.SetCufCufdDateToXmlButton.Name = "SetCufCufdDateToXmlButton";
            this.SetCufCufdDateToXmlButton.Size = new System.Drawing.Size(189, 23);
            this.SetCufCufdDateToXmlButton.TabIndex = 0;
            this.SetCufCufdDateToXmlButton.Text = "Set CUF, CUFD and Date";
            this.SetCufCufdDateToXmlButton.UseVisualStyleBackColor = true;
            this.SetCufCufdDateToXmlButton.Click += new System.EventHandler(this.SetCufCufdDateToXmlButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // SignAndCompressButton
            // 
            this.SignAndCompressButton.Location = new System.Drawing.Point(281, 155);
            this.SignAndCompressButton.Name = "SignAndCompressButton";
            this.SignAndCompressButton.Size = new System.Drawing.Size(189, 23);
            this.SignAndCompressButton.TabIndex = 1;
            this.SignAndCompressButton.Text = "Sign and Compress";
            this.SignAndCompressButton.UseVisualStyleBackColor = true;
            this.SignAndCompressButton.Click += new System.EventHandler(this.SignAndCompressButton_Click);
            // 
            // SendButton
            // 
            this.SendButton.Location = new System.Drawing.Point(281, 99);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(189, 23);
            this.SendButton.TabIndex = 2;
            this.SendButton.Text = "Send";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.SignAndCompressButton);
            this.Controls.Add(this.SetCufCufdDateToXmlButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SetCufCufdDateToXmlButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button SignAndCompressButton;
        private System.Windows.Forms.Button SendButton;
    }
}

