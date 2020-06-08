namespace UVS
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
            this.thread_count_nud = new System.Windows.Forms.NumericUpDown();
            this.start_btn = new System.Windows.Forms.Button();
            this.thread_lv = new System.Windows.Forms.ListView();
            this.Data = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ThreadId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.stop_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.thread_count_nud)).BeginInit();
            this.SuspendLayout();
            // 
            // thread_count_nud
            // 
            this.thread_count_nud.Location = new System.Drawing.Point(12, 12);
            this.thread_count_nud.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.thread_count_nud.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.thread_count_nud.Name = "thread_count_nud";
            this.thread_count_nud.Size = new System.Drawing.Size(41, 20);
            this.thread_count_nud.TabIndex = 3;
            this.thread_count_nud.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // start_btn
            // 
            this.start_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.start_btn.Location = new System.Drawing.Point(75, 387);
            this.start_btn.Name = "start_btn";
            this.start_btn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.start_btn.Size = new System.Drawing.Size(149, 27);
            this.start_btn.TabIndex = 4;
            this.start_btn.Text = "Start";
            this.start_btn.UseVisualStyleBackColor = true;
            this.start_btn.Click += new System.EventHandler(this.start_btn_Click);
            // 
            // thread_lv
            // 
            this.thread_lv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.thread_lv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Data,
            this.ThreadId});
            this.thread_lv.FullRowSelect = true;
            this.thread_lv.GridLines = true;
            this.thread_lv.HideSelection = false;
            this.thread_lv.Location = new System.Drawing.Point(75, 12);
            this.thread_lv.MultiSelect = false;
            this.thread_lv.Name = "thread_lv";
            this.thread_lv.Size = new System.Drawing.Size(322, 369);
            this.thread_lv.TabIndex = 5;
            this.thread_lv.UseCompatibleStateImageBehavior = false;
            this.thread_lv.View = System.Windows.Forms.View.Details;
            // 
            // Data
            // 
            this.Data.DisplayIndex = 1;
            this.Data.Text = "Generuojama eilute";
            this.Data.Width = 100;
            // 
            // ThreadId
            // 
            this.ThreadId.DisplayIndex = 0;
            this.ThreadId.Text = "ThreadId";
            this.ThreadId.Width = 109;
            // 
            // stop_btn
            // 
            this.stop_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.stop_btn.Location = new System.Drawing.Point(248, 387);
            this.stop_btn.Name = "stop_btn";
            this.stop_btn.Size = new System.Drawing.Size(149, 27);
            this.stop_btn.TabIndex = 6;
            this.stop_btn.Text = "Stop";
            this.stop_btn.UseVisualStyleBackColor = true;
            this.stop_btn.Click += new System.EventHandler(this.stop_btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 420);
            this.Controls.Add(this.stop_btn);
            this.Controls.Add(this.thread_lv);
            this.Controls.Add(this.start_btn);
            this.Controls.Add(this.thread_count_nud);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.thread_count_nud)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.NumericUpDown thread_count_nud;
        private System.Windows.Forms.Button start_btn;
        private System.Windows.Forms.ListView thread_lv;
        private System.Windows.Forms.Button stop_btn;
        private System.Windows.Forms.ColumnHeader Data;
        private System.Windows.Forms.ColumnHeader ThreadId;
    }
}

