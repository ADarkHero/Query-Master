namespace QueryMaster
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
            this.sqlListView = new System.Windows.Forms.ListView();
            this.sqlQueryName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxSeperator = new System.Windows.Forms.TextBox();
            this.checkBoxAddHeadline = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // sqlListView
            // 
            this.sqlListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.sqlQueryName});
            this.sqlListView.Location = new System.Drawing.Point(12, 12);
            this.sqlListView.Name = "sqlListView";
            this.sqlListView.Size = new System.Drawing.Size(680, 395);
            this.sqlListView.TabIndex = 0;
            this.sqlListView.UseCompatibleStateImageBehavior = false;
            this.sqlListView.View = System.Windows.Forms.View.Tile;
            this.sqlListView.DoubleClick += new System.EventHandler(this.sqlListView_DoubleClick);
            // 
            // sqlQueryName
            // 
            this.sqlQueryName.Width = 720;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 417);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Seperator";
            // 
            // textBoxSeperator
            // 
            this.textBoxSeperator.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSeperator.Location = new System.Drawing.Point(12, 413);
            this.textBoxSeperator.Name = "textBoxSeperator";
            this.textBoxSeperator.Size = new System.Drawing.Size(13, 20);
            this.textBoxSeperator.TabIndex = 3;
            this.textBoxSeperator.Text = ";";
            this.textBoxSeperator.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxSeperator.TextChanged += new System.EventHandler(this.textBoxSeperator_TextChanged);
            // 
            // checkBoxAddHeadline
            // 
            this.checkBoxAddHeadline.AutoSize = true;
            this.checkBoxAddHeadline.Checked = true;
            this.checkBoxAddHeadline.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAddHeadline.Location = new System.Drawing.Point(121, 415);
            this.checkBoxAddHeadline.Name = "checkBoxAddHeadline";
            this.checkBoxAddHeadline.Size = new System.Drawing.Size(116, 17);
            this.checkBoxAddHeadline.TabIndex = 4;
            this.checkBoxAddHeadline.Text = "Add headline to file";
            this.checkBoxAddHeadline.UseVisualStyleBackColor = true;
            this.checkBoxAddHeadline.CheckedChanged += new System.EventHandler(this.checkBoxAddHeadline_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 441);
            this.Controls.Add(this.checkBoxAddHeadline);
            this.Controls.Add(this.textBoxSeperator);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sqlListView);
            this.Name = "Form1";
            this.Text = "Query Master";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView sqlListView;
        private System.Windows.Forms.ColumnHeader sqlQueryName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxSeperator;
        private System.Windows.Forms.CheckBox checkBoxAddHeadline;
    }
}

