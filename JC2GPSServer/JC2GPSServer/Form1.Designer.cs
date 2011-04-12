namespace JC2GPSServer
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
            this.xlabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ylabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.zlabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.speedlabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // xlabel
            // 
            this.xlabel.AutoSize = true;
            this.xlabel.Font = new System.Drawing.Font("Palatino Linotype", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xlabel.Location = new System.Drawing.Point(56, 10);
            this.xlabel.Name = "xlabel";
            this.xlabel.Size = new System.Drawing.Size(100, 65);
            this.xlabel.TabIndex = 0;
            this.xlabel.Text = "000";
            this.xlabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.xlabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 42);
            this.label2.TabIndex = 1;
            this.label2.Text = "x";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // ylabel
            // 
            this.ylabel.AutoSize = true;
            this.ylabel.Font = new System.Drawing.Font("Palatino Linotype", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ylabel.Location = new System.Drawing.Point(56, 76);
            this.ylabel.Name = "ylabel";
            this.ylabel.Size = new System.Drawing.Size(100, 65);
            this.ylabel.TabIndex = 0;
            this.ylabel.Text = "000";
            this.ylabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ylabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(24, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 42);
            this.label4.TabIndex = 1;
            this.label4.Text = "y";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label4.Click += new System.EventHandler(this.label2_Click);
            // 
            // zlabel
            // 
            this.zlabel.AutoSize = true;
            this.zlabel.Font = new System.Drawing.Font("Palatino Linotype", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zlabel.Location = new System.Drawing.Point(56, 144);
            this.zlabel.Name = "zlabel";
            this.zlabel.Size = new System.Drawing.Size(100, 65);
            this.zlabel.TabIndex = 0;
            this.zlabel.Text = "000";
            this.zlabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.zlabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(24, 154);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 42);
            this.label6.TabIndex = 1;
            this.label6.Text = "z";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label6.Click += new System.EventHandler(this.label2_Click);
            // 
            // speedlabel
            // 
            this.speedlabel.AutoSize = true;
            this.speedlabel.Font = new System.Drawing.Font("Palatino Linotype", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.speedlabel.Location = new System.Drawing.Point(221, 76);
            this.speedlabel.Name = "speedlabel";
            this.speedlabel.Size = new System.Drawing.Size(100, 65);
            this.speedlabel.TabIndex = 0;
            this.speedlabel.Text = "000";
            this.speedlabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.speedlabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(208, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 42);
            this.label3.TabIndex = 1;
            this.label3.Text = "speed";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label3.Click += new System.EventHandler(this.label2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 219);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.zlabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.speedlabel);
            this.Controls.Add(this.ylabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.xlabel);
            this.Name = "Form1";
            this.Text = "Just Cause 2 GPS";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label xlabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label ylabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label zlabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label speedlabel;
        private System.Windows.Forms.Label label3;
    }
}

