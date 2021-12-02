
namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button2 = new System.Windows.Forms.Button();
            this.SendButton = new System.Windows.Forms.Button();
            this.SignAndCompressButton = new System.Windows.Forms.Button();
            this.VerifySignatureButton = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.CanonicalizeXmlButton = new System.Windows.Forms.Button();
            this.ValidateXmlButton = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.GenerateCufButton = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.SetCufCufdDateToXmlButton = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.CufdTextBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.CuisTextBox = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.CodigoSistemaTextBox = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.CodigoAmbienteTextBox = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(33, 88);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Modulus 11";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // SendButton
            // 
            this.SendButton.Location = new System.Drawing.Point(336, 99);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(75, 23);
            this.SendButton.TabIndex = 4;
            this.SendButton.Text = "Send";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // SignAndCompressButton
            // 
            this.SignAndCompressButton.Location = new System.Drawing.Point(336, 152);
            this.SignAndCompressButton.Name = "SignAndCompressButton";
            this.SignAndCompressButton.Size = new System.Drawing.Size(155, 23);
            this.SignAndCompressButton.TabIndex = 5;
            this.SignAndCompressButton.Text = "Sign and Compress";
            this.SignAndCompressButton.UseVisualStyleBackColor = true;
            this.SignAndCompressButton.Click += new System.EventHandler(this.SignAndCompressButton_Click);
            // 
            // VerifySignatureButton
            // 
            this.VerifySignatureButton.Location = new System.Drawing.Point(336, 199);
            this.VerifySignatureButton.Name = "VerifySignatureButton";
            this.VerifySignatureButton.Size = new System.Drawing.Size(75, 23);
            this.VerifySignatureButton.TabIndex = 6;
            this.VerifySignatureButton.Text = "Verify Sign";
            this.VerifySignatureButton.UseVisualStyleBackColor = true;
            this.VerifySignatureButton.Click += new System.EventHandler(this.VerifySignatureButton_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(578, 152);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 7;
            this.button6.Text = "Compress";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "XML|*.xml";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(336, 243);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 8;
            this.button7.Text = "Sign Other";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(497, 152);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 23);
            this.button8.TabIndex = 9;
            this.button8.Text = "Sign";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // CanonicalizeXmlButton
            // 
            this.CanonicalizeXmlButton.Location = new System.Drawing.Point(497, 199);
            this.CanonicalizeXmlButton.Name = "CanonicalizeXmlButton";
            this.CanonicalizeXmlButton.Size = new System.Drawing.Size(156, 23);
            this.CanonicalizeXmlButton.TabIndex = 10;
            this.CanonicalizeXmlButton.Text = "Canonicalize";
            this.CanonicalizeXmlButton.UseVisualStyleBackColor = true;
            this.CanonicalizeXmlButton.Click += new System.EventHandler(this.CanonicalizeXmlButton_Click);
            // 
            // ValidateXmlButton
            // 
            this.ValidateXmlButton.Location = new System.Drawing.Point(33, 214);
            this.ValidateXmlButton.Name = "ValidateXmlButton";
            this.ValidateXmlButton.Size = new System.Drawing.Size(112, 23);
            this.ValidateXmlButton.TabIndex = 13;
            this.ValidateXmlButton.Text = "Validate with XSD";
            this.ValidateXmlButton.UseVisualStyleBackColor = true;
            this.ValidateXmlButton.Click += new System.EventHandler(this.ValidateXmlButton_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(33, 30);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(282, 23);
            this.textBox2.TabIndex = 15;
            // 
            // GenerateCufButton
            // 
            this.GenerateCufButton.Location = new System.Drawing.Point(346, 647);
            this.GenerateCufButton.Name = "GenerateCufButton";
            this.GenerateCufButton.Size = new System.Drawing.Size(135, 23);
            this.GenerateCufButton.TabIndex = 16;
            this.GenerateCufButton.Text = "Generate CUF";
            this.GenerateCufButton.UseVisualStyleBackColor = true;
            this.GenerateCufButton.Click += new System.EventHandler(this.GenerateCufButton_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(432, 370);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(99, 23);
            this.textBox3.TabIndex = 17;
            this.textBox3.Text = "1014381027";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(346, 676);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(495, 23);
            this.textBox4.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(291, 373);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 15);
            this.label2.TabIndex = 19;
            this.label2.Text = "Nit:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(291, 402);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 15);
            this.label3.TabIndex = 21;
            this.label3.Text = "Sucursal:";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(432, 399);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(99, 23);
            this.textBox5.TabIndex = 20;
            this.textBox5.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(291, 431);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 23;
            this.label4.Text = "Modalidad:";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(432, 428);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(99, 23);
            this.textBox6.TabIndex = 22;
            this.textBox6.Text = "1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(291, 460);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 15);
            this.label5.TabIndex = 25;
            this.label5.Text = "Tipo Emision:";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(432, 457);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(99, 23);
            this.textBox7.TabIndex = 24;
            this.textBox7.Text = "1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(291, 518);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 15);
            this.label6.TabIndex = 29;
            this.label6.Text = "Tipo Documento Sector:";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(432, 515);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(99, 23);
            this.textBox8.TabIndex = 28;
            this.textBox8.Text = "1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(291, 489);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 15);
            this.label7.TabIndex = 27;
            this.label7.Text = "Tipo Factura:";
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(432, 486);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(99, 23);
            this.textBox9.TabIndex = 26;
            this.textBox9.Text = "1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(291, 547);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 15);
            this.label8.TabIndex = 31;
            this.label8.Text = "Numero Factura:";
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(432, 544);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(99, 23);
            this.textBox10.TabIndex = 30;
            this.textBox10.Text = "12345";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(291, 576);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 15);
            this.label9.TabIndex = 33;
            this.label9.Text = "Punto de Venta:";
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(432, 573);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(99, 23);
            this.textBox11.TabIndex = 32;
            this.textBox11.Text = "0";
            // 
            // SetCufCufdDateToXmlButton
            // 
            this.SetCufCufdDateToXmlButton.Location = new System.Drawing.Point(336, 291);
            this.SetCufCufdDateToXmlButton.Name = "SetCufCufdDateToXmlButton";
            this.SetCufCufdDateToXmlButton.Size = new System.Drawing.Size(317, 23);
            this.SetCufCufdDateToXmlButton.TabIndex = 34;
            this.SetCufCufdDateToXmlButton.Text = "Set CUF, CUFD and Date";
            this.SetCufCufdDateToXmlButton.UseVisualStyleBackColor = true;
            this.SetCufCufdDateToXmlButton.Click += new System.EventHandler(this.SetCufCufdDateToXmlButton_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(291, 605);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 15);
            this.label10.TabIndex = 36;
            this.label10.Text = "Fecha:";
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(432, 602);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(168, 23);
            this.textBox12.TabIndex = 35;
            this.textBox12.Text = "0";
            // 
            // textBox13
            // 
            this.textBox13.Location = new System.Drawing.Point(346, 705);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(495, 23);
            this.textBox13.TabIndex = 37;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(291, 684);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(24, 15);
            this.label11.TabIndex = 38;
            this.label11.Text = "cuf";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(291, 708);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 15);
            this.label12.TabIndex = 39;
            this.label12.Text = "cuf Ivan";
            // 
            // CufdTextBox
            // 
            this.CufdTextBox.Location = new System.Drawing.Point(346, 734);
            this.CufdTextBox.Name = "CufdTextBox";
            this.CufdTextBox.Size = new System.Drawing.Size(495, 23);
            this.CufdTextBox.TabIndex = 40;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(291, 737);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(31, 15);
            this.label13.TabIndex = 41;
            this.label13.Text = "cufd";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(585, 378);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(151, 15);
            this.label14.TabIndex = 43;
            this.label14.Text = "Codigo Documento Sector:";
            // 
            // textBox14
            // 
            this.textBox14.Location = new System.Drawing.Point(742, 373);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(99, 23);
            this.textBox14.TabIndex = 42;
            this.textBox14.Text = "1";
            // 
            // CuisTextBox
            // 
            this.CuisTextBox.Location = new System.Drawing.Point(742, 402);
            this.CuisTextBox.Name = "CuisTextBox";
            this.CuisTextBox.Size = new System.Drawing.Size(100, 23);
            this.CuisTextBox.TabIndex = 44;
            this.CuisTextBox.Text = "31629D89";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(585, 402);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(33, 15);
            this.label15.TabIndex = 45;
            this.label15.Text = "Cuis:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(585, 436);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(93, 15);
            this.label16.TabIndex = 47;
            this.label16.Text = "Codigo Sistema:";
            // 
            // CodigoSistemaTextBox
            // 
            this.CodigoSistemaTextBox.Location = new System.Drawing.Point(684, 431);
            this.CodigoSistemaTextBox.Name = "CodigoSistemaTextBox";
            this.CodigoSistemaTextBox.Size = new System.Drawing.Size(158, 23);
            this.CodigoSistemaTextBox.TabIndex = 46;
            this.CodigoSistemaTextBox.Text = "6D0A618E6B1727F00788EE7";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(586, 465);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(104, 15);
            this.label17.TabIndex = 49;
            this.label17.Text = "Codigo Ambiente:";
            // 
            // CodigoAmbienteTextBox
            // 
            this.CodigoAmbienteTextBox.Location = new System.Drawing.Point(743, 460);
            this.CodigoAmbienteTextBox.Name = "CodigoAmbienteTextBox";
            this.CodigoAmbienteTextBox.Size = new System.Drawing.Size(99, 23);
            this.CodigoAmbienteTextBox.TabIndex = 48;
            this.CodigoAmbienteTextBox.Text = "2";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(33, 59);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(282, 23);
            this.textBox1.TabIndex = 50;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 771);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.CodigoAmbienteTextBox);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.CodigoSistemaTextBox);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.CuisTextBox);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.textBox14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.CufdTextBox);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBox13);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBox12);
            this.Controls.Add(this.SetCufCufdDateToXmlButton);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBox11);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox10);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.GenerateCufButton);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.ValidateXmlButton);
            this.Controls.Add(this.CanonicalizeXmlButton);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.VerifySignatureButton);
            this.Controls.Add(this.SignAndCompressButton);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.button2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.Button SignAndCompressButton;
        private System.Windows.Forms.Button VerifySignatureButton;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button CanonicalizeXmlButton;
        private System.Windows.Forms.Button ValidateXmlButton;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button GenerateCufButton;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.Button SetCufCufdDateToXmlButton;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.TextBox textBox13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox CufdTextBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBox14;
        private System.Windows.Forms.TextBox CuisTextBox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox CodigoSistemaTextBox;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox CodigoAmbienteTextBox;
        private System.Windows.Forms.TextBox textBox1;
    }
}

