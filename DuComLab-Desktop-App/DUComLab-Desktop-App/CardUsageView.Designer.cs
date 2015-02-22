namespace CyberCenterClient
{
    partial class CardUsageView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.CardUsageGridView = new System.Windows.Forms.DataGridView();
            this.LabelTittleCardNumber = new System.Windows.Forms.Label();
            this.ButtonSaveExcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CardUsageGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // CardUsageGridView
            // 
            this.CardUsageGridView.AllowUserToAddRows = false;
            this.CardUsageGridView.AllowUserToDeleteRows = false;
            this.CardUsageGridView.AllowUserToResizeColumns = false;
            this.CardUsageGridView.AllowUserToResizeRows = false;
            this.CardUsageGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.CardUsageGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.CardUsageGridView.BackgroundColor = System.Drawing.Color.White;
            this.CardUsageGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.CardUsageGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CardUsageGridView.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.CardUsageGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this.CardUsageGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.CardUsageGridView.Location = new System.Drawing.Point(0, 49);
            this.CardUsageGridView.Name = "CardUsageGridView";
            this.CardUsageGridView.ReadOnly = true;
            this.CardUsageGridView.Size = new System.Drawing.Size(820, 329);
            this.CardUsageGridView.TabIndex = 0;
            // 
            // LabelTittleCardNumber
            // 
            this.LabelTittleCardNumber.AutoSize = true;
            this.LabelTittleCardNumber.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelTittleCardNumber.Location = new System.Drawing.Point(149, 9);
            this.LabelTittleCardNumber.Name = "LabelTittleCardNumber";
            this.LabelTittleCardNumber.Size = new System.Drawing.Size(446, 31);
            this.LabelTittleCardNumber.TabIndex = 1;
            this.LabelTittleCardNumber.Text = "Card Usage History For Card Number : ";
            // 
            // ButtonSaveExcel
            // 
            this.ButtonSaveExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonSaveExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonSaveExcel.Location = new System.Drawing.Point(12, 5);
            this.ButtonSaveExcel.Name = "ButtonSaveExcel";
            this.ButtonSaveExcel.Size = new System.Drawing.Size(95, 35);
            this.ButtonSaveExcel.TabIndex = 2;
            this.ButtonSaveExcel.Text = "Save History";
            this.ButtonSaveExcel.UseVisualStyleBackColor = true;
            this.ButtonSaveExcel.Click += new System.EventHandler(this.ButtonSaveExcel_Click);
            // 
            // CardUsageView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(819, 379);
            this.Controls.Add(this.ButtonSaveExcel);
            this.Controls.Add(this.LabelTittleCardNumber);
            this.Controls.Add(this.CardUsageGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CardUsageView";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            ((System.ComponentModel.ISupportInitialize)(this.CardUsageGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView CardUsageGridView;
        private System.Windows.Forms.Label LabelTittleCardNumber;
        private System.Windows.Forms.Button ButtonSaveExcel;
    }
}