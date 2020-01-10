namespace PFW.CSIST203.Project1
{
    partial class frmMain
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
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.txtArray1 = new System.Windows.Forms.TextBox();
            this.btnReverse = new System.Windows.Forms.Button();
            this.txtArray2 = new System.Windows.Forms.TextBox();
            this.btnShiftLeft = new System.Windows.Forms.Button();
            this.txtArray3 = new System.Windows.Forms.TextBox();
            this.btnShiftRight = new System.Windows.Forms.Button();
            this.txtArray4 = new System.Windows.Forms.TextBox();
            this.btnRandomize = new System.Windows.Forms.Button();
            this.txtArray5 = new System.Windows.Forms.TextBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.Label5 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.lblOperator = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtValue1 = new System.Windows.Forms.TextBox();
            this.txtValue2 = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtResultant = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSubtract = new System.Windows.Forms.Button();
            this.btnMultiply = new System.Windows.Forms.Button();
            this.btnDivide = new System.Windows.Forms.Button();
            this.btnModulus = new System.Windows.Forms.Button();
            this.btnPower = new System.Windows.Forms.Button();
            this.GroupBox2.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.Label4);
            this.GroupBox2.Controls.Add(this.txtArray1);
            this.GroupBox2.Controls.Add(this.btnReverse);
            this.GroupBox2.Controls.Add(this.txtArray2);
            this.GroupBox2.Controls.Add(this.btnShiftLeft);
            this.GroupBox2.Controls.Add(this.txtArray3);
            this.GroupBox2.Controls.Add(this.btnShiftRight);
            this.GroupBox2.Controls.Add(this.txtArray4);
            this.GroupBox2.Controls.Add(this.btnRandomize);
            this.GroupBox2.Controls.Add(this.txtArray5);
            this.GroupBox2.Controls.Add(this.btnLoad);
            this.GroupBox2.Controls.Add(this.Label5);
            this.GroupBox2.Controls.Add(this.btnSave);
            this.GroupBox2.Controls.Add(this.Label6);
            this.GroupBox2.Controls.Add(this.Label8);
            this.GroupBox2.Controls.Add(this.Label7);
            this.GroupBox2.Location = new System.Drawing.Point(32, 238);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(603, 196);
            this.GroupBox2.TabIndex = 31;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Array Functions";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(45, 49);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(39, 13);
            this.Label4.TabIndex = 17;
            this.Label4.Text = "Data 1";
            // 
            // txtArray1
            // 
            this.txtArray1.Location = new System.Drawing.Point(45, 81);
            this.txtArray1.Name = "txtArray1";
            this.txtArray1.Size = new System.Drawing.Size(100, 20);
            this.txtArray1.TabIndex = 12;
            this.txtArray1.Text = "first";
            // 
            // btnReverse
            // 
            this.btnReverse.Location = new System.Drawing.Point(452, 121);
            this.btnReverse.Name = "btnReverse";
            this.btnReverse.Size = new System.Drawing.Size(75, 23);
            this.btnReverse.TabIndex = 27;
            this.btnReverse.Text = "Reverse";
            this.btnReverse.UseVisualStyleBackColor = true;
            this.btnReverse.Click += new System.EventHandler(this.BtnReverse_Click);
            // 
            // txtArray2
            // 
            this.txtArray2.Location = new System.Drawing.Point(151, 81);
            this.txtArray2.Name = "txtArray2";
            this.txtArray2.Size = new System.Drawing.Size(100, 20);
            this.txtArray2.TabIndex = 13;
            this.txtArray2.Text = "second";
            // 
            // btnShiftLeft
            // 
            this.btnShiftLeft.Location = new System.Drawing.Point(370, 121);
            this.btnShiftLeft.Name = "btnShiftLeft";
            this.btnShiftLeft.Size = new System.Drawing.Size(75, 23);
            this.btnShiftLeft.TabIndex = 26;
            this.btnShiftLeft.Text = "Shift Left";
            this.btnShiftLeft.UseVisualStyleBackColor = true;
            this.btnShiftLeft.Click += new System.EventHandler(this.BtnShiftLeft_Click);
            // 
            // txtArray3
            // 
            this.txtArray3.Location = new System.Drawing.Point(258, 80);
            this.txtArray3.Name = "txtArray3";
            this.txtArray3.Size = new System.Drawing.Size(100, 20);
            this.txtArray3.TabIndex = 14;
            this.txtArray3.Text = "third";
            // 
            // btnShiftRight
            // 
            this.btnShiftRight.Location = new System.Drawing.Point(288, 121);
            this.btnShiftRight.Name = "btnShiftRight";
            this.btnShiftRight.Size = new System.Drawing.Size(75, 23);
            this.btnShiftRight.TabIndex = 25;
            this.btnShiftRight.Text = "Shift Right";
            this.btnShiftRight.UseVisualStyleBackColor = true;
            this.btnShiftRight.Click += new System.EventHandler(this.BtnShiftRight_Click);
            // 
            // txtArray4
            // 
            this.txtArray4.Location = new System.Drawing.Point(370, 80);
            this.txtArray4.Name = "txtArray4";
            this.txtArray4.Size = new System.Drawing.Size(100, 20);
            this.txtArray4.TabIndex = 15;
            this.txtArray4.Text = "fourth";
            // 
            // btnRandomize
            // 
            this.btnRandomize.Location = new System.Drawing.Point(207, 121);
            this.btnRandomize.Name = "btnRandomize";
            this.btnRandomize.Size = new System.Drawing.Size(75, 23);
            this.btnRandomize.TabIndex = 24;
            this.btnRandomize.Text = "Randomize";
            this.btnRandomize.UseVisualStyleBackColor = true;
            this.btnRandomize.Click += new System.EventHandler(this.BtnRandomize_Click);
            // 
            // txtArray5
            // 
            this.txtArray5.Location = new System.Drawing.Point(477, 80);
            this.txtArray5.Name = "txtArray5";
            this.txtArray5.Size = new System.Drawing.Size(100, 20);
            this.txtArray5.TabIndex = 16;
            this.txtArray5.Text = "fifth";
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(127, 121);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 23;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.BtnLoad_Click);
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(148, 49);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(39, 13);
            this.Label5.TabIndex = 18;
            this.Label5.Text = "Data 2";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(45, 121);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 22;
            this.btnSave.Text = "Store";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(255, 49);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(39, 13);
            this.Label6.TabIndex = 19;
            this.Label6.Text = "Data 3";
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(474, 49);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(39, 13);
            this.Label8.TabIndex = 21;
            this.Label8.Text = "Data 5";
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(367, 49);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(39, 13);
            this.Label7.TabIndex = 20;
            this.Label7.Text = "Data 4";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.lblOperator);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.txtValue1);
            this.GroupBox1.Controls.Add(this.txtValue2);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.txtResultant);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.btnAdd);
            this.GroupBox1.Controls.Add(this.btnSubtract);
            this.GroupBox1.Controls.Add(this.btnMultiply);
            this.GroupBox1.Controls.Add(this.btnDivide);
            this.GroupBox1.Controls.Add(this.btnModulus);
            this.GroupBox1.Controls.Add(this.btnPower);
            this.GroupBox1.Location = new System.Drawing.Point(32, 23);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(603, 197);
            this.GroupBox1.TabIndex = 30;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Mathematical Functions";
            // 
            // lblOperator
            // 
            this.lblOperator.AutoSize = true;
            this.lblOperator.Location = new System.Drawing.Point(204, 65);
            this.lblOperator.Name = "lblOperator";
            this.lblOperator.Size = new System.Drawing.Size(13, 13);
            this.lblOperator.TabIndex = 12;
            this.lblOperator.Text = "+";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(54, 43);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(43, 13);
            this.Label1.TabIndex = 2;
            this.Label1.Text = "Value 1";
            // 
            // txtValue1
            // 
            this.txtValue1.Location = new System.Drawing.Point(54, 62);
            this.txtValue1.Name = "txtValue1";
            this.txtValue1.Size = new System.Drawing.Size(127, 20);
            this.txtValue1.TabIndex = 0;
            this.txtValue1.Text = "0";
            // 
            // txtValue2
            // 
            this.txtValue2.Location = new System.Drawing.Point(239, 62);
            this.txtValue2.Name = "txtValue2";
            this.txtValue2.Size = new System.Drawing.Size(126, 20);
            this.txtValue2.TabIndex = 1;
            this.txtValue2.Text = "0";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(239, 42);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(43, 13);
            this.Label2.TabIndex = 3;
            this.Label2.Text = "Value 2";
            // 
            // txtResultant
            // 
            this.txtResultant.Enabled = false;
            this.txtResultant.Location = new System.Drawing.Point(435, 62);
            this.txtResultant.Name = "txtResultant";
            this.txtResultant.Size = new System.Drawing.Size(100, 20);
            this.txtResultant.TabIndex = 4;
            this.txtResultant.Text = "0";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(432, 42);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(52, 13);
            this.Label3.TabIndex = 5;
            this.Label3.Text = "Resultant";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(54, 142);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "+";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // btnSubtract
            // 
            this.btnSubtract.Location = new System.Drawing.Point(135, 142);
            this.btnSubtract.Name = "btnSubtract";
            this.btnSubtract.Size = new System.Drawing.Size(75, 23);
            this.btnSubtract.TabIndex = 7;
            this.btnSubtract.Text = "-";
            this.btnSubtract.UseVisualStyleBackColor = true;
            this.btnSubtract.Click += new System.EventHandler(this.BtnSubtract_Click);
            // 
            // btnMultiply
            // 
            this.btnMultiply.Location = new System.Drawing.Point(216, 142);
            this.btnMultiply.Name = "btnMultiply";
            this.btnMultiply.Size = new System.Drawing.Size(75, 23);
            this.btnMultiply.TabIndex = 8;
            this.btnMultiply.Text = "*";
            this.btnMultiply.UseVisualStyleBackColor = true;
            this.btnMultiply.Click += new System.EventHandler(this.BtnMultiply_Click);
            // 
            // btnDivide
            // 
            this.btnDivide.Location = new System.Drawing.Point(297, 142);
            this.btnDivide.Name = "btnDivide";
            this.btnDivide.Size = new System.Drawing.Size(75, 23);
            this.btnDivide.TabIndex = 9;
            this.btnDivide.Text = "/";
            this.btnDivide.UseVisualStyleBackColor = true;
            this.btnDivide.Click += new System.EventHandler(this.BtnDivide_Click);
            // 
            // btnModulus
            // 
            this.btnModulus.Location = new System.Drawing.Point(379, 142);
            this.btnModulus.Name = "btnModulus";
            this.btnModulus.Size = new System.Drawing.Size(75, 23);
            this.btnModulus.TabIndex = 10;
            this.btnModulus.Text = "%";
            this.btnModulus.UseVisualStyleBackColor = true;
            this.btnModulus.Click += new System.EventHandler(this.BtnModulus_Click);
            // 
            // btnPower
            // 
            this.btnPower.Location = new System.Drawing.Point(461, 142);
            this.btnPower.Name = "btnPower";
            this.btnPower.Size = new System.Drawing.Size(75, 23);
            this.btnPower.TabIndex = 11;
            this.btnPower.Text = "^";
            this.btnPower.UseVisualStyleBackColor = true;
            this.btnPower.Click += new System.EventHandler(this.BtnPower_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 456);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.GroupBox1);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CS203/IST203 Project #1";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.TextBox txtArray1;
        internal System.Windows.Forms.Button btnReverse;
        internal System.Windows.Forms.TextBox txtArray2;
        internal System.Windows.Forms.Button btnShiftLeft;
        internal System.Windows.Forms.TextBox txtArray3;
        internal System.Windows.Forms.Button btnShiftRight;
        internal System.Windows.Forms.TextBox txtArray4;
        internal System.Windows.Forms.Button btnRandomize;
        internal System.Windows.Forms.TextBox txtArray5;
        internal System.Windows.Forms.Button btnLoad;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Button btnSave;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Label lblOperator;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox txtValue1;
        internal System.Windows.Forms.TextBox txtValue2;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox txtResultant;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Button btnAdd;
        internal System.Windows.Forms.Button btnSubtract;
        internal System.Windows.Forms.Button btnMultiply;
        internal System.Windows.Forms.Button btnDivide;
        internal System.Windows.Forms.Button btnModulus;
        internal System.Windows.Forms.Button btnPower;
    }
}

