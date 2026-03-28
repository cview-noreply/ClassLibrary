namespace $safeprojectname$.Forms
{
    partial class MasterAdminForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MasterAdminForm));
            this.Dgv_マスタ = new System.Windows.Forms.DataGridView();
            this.BS_マスタ = new System.Windows.Forms.BindingSource(this.components);
            this.Btn_キャンセル = new System.Windows.Forms.Button();
            this.Btn_保存 = new System.Windows.Forms.Button();
            this.Lbl_更新日時 = new System.Windows.Forms.Label();
            this.Btn_一括取込 = new System.Windows.Forms.Button();
            this.Btn_一括出力 = new System.Windows.Forms.Button();
            this.項目1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.項目2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.項目3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.項目4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.項目5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_マスタ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_マスタ)).BeginInit();
            this.SuspendLayout();
            // 
            // Dgv_マスタ
            // 
            this.Dgv_マスタ.AllowUserToAddRows = false;
            this.Dgv_マスタ.AllowUserToDeleteRows = false;
            this.Dgv_マスタ.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Dgv_マスタ.AutoGenerateColumns = false;
            this.Dgv_マスタ.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Dgv_マスタ.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.Dgv_マスタ.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_マスタ.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.項目1,
            this.項目2,
            this.項目3,
            this.項目4,
            this.項目5});
            this.Dgv_マスタ.DataSource = this.BS_マスタ;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("メイリオ", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Dgv_マスタ.DefaultCellStyle = dataGridViewCellStyle1;
            this.Dgv_マスタ.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.Dgv_マスタ.Location = new System.Drawing.Point(12, 73);
            this.Dgv_マスタ.Name = "Dgv_マスタ";
            this.Dgv_マスタ.ReadOnly = true;
            this.Dgv_マスタ.RowHeadersWidth = 25;
            this.Dgv_マスタ.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Dgv_マスタ.RowTemplate.Height = 21;
            this.Dgv_マスタ.Size = new System.Drawing.Size(734, 291);
            this.Dgv_マスタ.TabIndex = 2;
            // 
            // Btn_キャンセル
            // 
            this.Btn_キャンセル.AutoSize = true;
            this.Btn_キャンセル.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_キャンセル.Font = new System.Drawing.Font("メイリオ", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Btn_キャンセル.Location = new System.Drawing.Point(645, 12);
            this.Btn_キャンセル.Name = "Btn_キャンセル";
            this.Btn_キャンセル.Size = new System.Drawing.Size(101, 31);
            this.Btn_キャンセル.TabIndex = 4;
            this.Btn_キャンセル.Text = "キャンセル";
            this.Btn_キャンセル.UseVisualStyleBackColor = true;
            this.Btn_キャンセル.Click += new System.EventHandler(this.Btn_キャンセル_Click);
            // 
            // Btn_保存
            // 
            this.Btn_保存.AutoSize = true;
            this.Btn_保存.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_保存.Font = new System.Drawing.Font("メイリオ", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Btn_保存.Location = new System.Drawing.Point(538, 12);
            this.Btn_保存.Name = "Btn_保存";
            this.Btn_保存.Size = new System.Drawing.Size(101, 31);
            this.Btn_保存.TabIndex = 3;
            this.Btn_保存.Text = "保存";
            this.Btn_保存.UseVisualStyleBackColor = true;
            this.Btn_保存.Click += new System.EventHandler(this.Btn_保存_Click);
            // 
            // Lbl_更新日時
            // 
            this.Lbl_更新日時.Font = new System.Drawing.Font("メイリオ", 9F);
            this.Lbl_更新日時.Location = new System.Drawing.Point(546, 50);
            this.Lbl_更新日時.Name = "Lbl_更新日時";
            this.Lbl_更新日時.Size = new System.Drawing.Size(200, 18);
            this.Lbl_更新日時.TabIndex = 50;
            this.Lbl_更新日時.Text = "更新日時：yyyy/MM/dd hh:mm";
            this.Lbl_更新日時.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Btn_一括取込
            // 
            this.Btn_一括取込.AutoSize = true;
            this.Btn_一括取込.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_一括取込.Font = new System.Drawing.Font("メイリオ", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Btn_一括取込.Location = new System.Drawing.Point(320, 12);
            this.Btn_一括取込.Name = "Btn_一括取込";
            this.Btn_一括取込.Size = new System.Drawing.Size(101, 31);
            this.Btn_一括取込.TabIndex = 0;
            this.Btn_一括取込.Text = "一括取込";
            this.Btn_一括取込.UseVisualStyleBackColor = true;
            this.Btn_一括取込.Click += new System.EventHandler(this.Btn_一括取込_Click);
            // 
            // Btn_一括出力
            // 
            this.Btn_一括出力.AutoSize = true;
            this.Btn_一括出力.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_一括出力.Font = new System.Drawing.Font("メイリオ", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Btn_一括出力.Location = new System.Drawing.Point(427, 12);
            this.Btn_一括出力.Name = "Btn_一括出力";
            this.Btn_一括出力.Size = new System.Drawing.Size(101, 31);
            this.Btn_一括出力.TabIndex = 1;
            this.Btn_一括出力.Text = "一括出力";
            this.Btn_一括出力.UseVisualStyleBackColor = true;
            this.Btn_一括出力.Click += new System.EventHandler(this.Btn_一括出力_Click);
            // 
            // 項目1
            // 
            this.項目1.DataPropertyName = "項目1";
            this.項目1.HeaderText = "項目1";
            this.項目1.Name = "項目1";
            this.項目1.ReadOnly = true;
            // 
            // 項目2
            // 
            this.項目2.DataPropertyName = "項目2";
            this.項目2.HeaderText = "項目2";
            this.項目2.Name = "項目2";
            this.項目2.ReadOnly = true;
            // 
            // 項目3
            // 
            this.項目3.DataPropertyName = "項目3";
            this.項目3.HeaderText = "項目3";
            this.項目3.Name = "項目3";
            this.項目3.ReadOnly = true;
            // 
            // 項目4
            // 
            this.項目4.DataPropertyName = "項目4";
            this.項目4.HeaderText = "項目4";
            this.項目4.Name = "項目4";
            this.項目4.ReadOnly = true;
            // 
            // 項目5
            // 
            this.項目5.DataPropertyName = "項目5";
            this.項目5.HeaderText = "項目5";
            this.項目5.Name = "項目5";
            this.項目5.ReadOnly = true;
            // 
            // MasterAdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 376);
            this.Controls.Add(this.Btn_一括出力);
            this.Controls.Add(this.Btn_一括取込);
            this.Controls.Add(this.Btn_キャンセル);
            this.Controls.Add(this.Btn_保存);
            this.Controls.Add(this.Lbl_更新日時);
            this.Controls.Add(this.Dgv_マスタ);
            this.Font = new System.Drawing.Font("メイリオ", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MasterAdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "マスタ管理";
            this.Load += new System.EventHandler(this.MasterAdminForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_マスタ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_マスタ)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Dgv_マスタ;
        private System.Windows.Forms.Button Btn_キャンセル;
        private System.Windows.Forms.Button Btn_保存;
        private System.Windows.Forms.Label Lbl_更新日時;
        private System.Windows.Forms.Button Btn_一括取込;
        private System.Windows.Forms.Button Btn_一括出力;
        private System.Windows.Forms.BindingSource BS_マスタ;
        private System.Windows.Forms.DataGridViewTextBoxColumn 項目1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 項目2;
        private System.Windows.Forms.DataGridViewTextBoxColumn 項目3;
        private System.Windows.Forms.DataGridViewTextBoxColumn 項目4;
        private System.Windows.Forms.DataGridViewTextBoxColumn 項目5;
    }
}