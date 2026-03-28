namespace $safeprojectname$.Forms
{
    partial class CheckAdminForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckAdminForm));
            this.Dgv_チェック一覧 = new System.Windows.Forms.DataGridView();
            this.BS_チェック一覧 = new System.Windows.Forms.BindingSource(this.components);
            this.Txt_検索 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CbBox_フィルタ = new System.Windows.Forms.ComboBox();
            this.カテゴリ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.チェック内容 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.備考 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_チェック一覧)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_チェック一覧)).BeginInit();
            this.SuspendLayout();
            // 
            // Dgv_チェック一覧
            // 
            this.Dgv_チェック一覧.AllowUserToAddRows = false;
            this.Dgv_チェック一覧.AllowUserToDeleteRows = false;
            this.Dgv_チェック一覧.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Dgv_チェック一覧.AutoGenerateColumns = false;
            this.Dgv_チェック一覧.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Dgv_チェック一覧.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.Dgv_チェック一覧.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_チェック一覧.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.カテゴリ,
            this.No,
            this.チェック内容,
            this.備考});
            this.Dgv_チェック一覧.DataSource = this.BS_チェック一覧;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("メイリオ", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Dgv_チェック一覧.DefaultCellStyle = dataGridViewCellStyle1;
            this.Dgv_チェック一覧.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.Dgv_チェック一覧.Location = new System.Drawing.Point(12, 45);
            this.Dgv_チェック一覧.Name = "Dgv_チェック一覧";
            this.Dgv_チェック一覧.ReadOnly = true;
            this.Dgv_チェック一覧.RowHeadersWidth = 25;
            this.Dgv_チェック一覧.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Dgv_チェック一覧.RowTemplate.Height = 21;
            this.Dgv_チェック一覧.Size = new System.Drawing.Size(933, 408);
            this.Dgv_チェック一覧.TabIndex = 2;
            // 
            // Txt_検索
            // 
            this.Txt_検索.Enabled = false;
            this.Txt_検索.Font = new System.Drawing.Font("メイリオ", 10F);
            this.Txt_検索.Location = new System.Drawing.Point(277, 11);
            this.Txt_検索.Name = "Txt_検索";
            this.Txt_検索.Size = new System.Drawing.Size(316, 27);
            this.Txt_検索.TabIndex = 1;
            this.Txt_検索.TextChanged += new System.EventHandler(this.Txt_検索_TextChanged);
            this.Txt_検索.Enter += new System.EventHandler(this.Txt_検索_Enter);
            this.Txt_検索.Leave += new System.EventHandler(this.Txt_検索_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("メイリオ", 10F);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(593, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 21);
            this.label1.TabIndex = 5;
            this.label1.Text = "🔎";
            // 
            // CbBox_フィルタ
            // 
            this.CbBox_フィルタ.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbBox_フィルタ.Enabled = false;
            this.CbBox_フィルタ.Font = new System.Drawing.Font("メイリオ", 10F);
            this.CbBox_フィルタ.FormattingEnabled = true;
            this.CbBox_フィルタ.Location = new System.Drawing.Point(38, 11);
            this.CbBox_フィルタ.Name = "CbBox_フィルタ";
            this.CbBox_フィルタ.Size = new System.Drawing.Size(233, 28);
            this.CbBox_フィルタ.TabIndex = 0;
            this.CbBox_フィルタ.SelectedIndexChanged += new System.EventHandler(this.CbBox_フィルタ_SelectedIndexChanged);
            // 
            // カテゴリ
            // 
            this.カテゴリ.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.カテゴリ.DataPropertyName = "カテゴリ";
            this.カテゴリ.HeaderText = "カテゴリ";
            this.カテゴリ.Name = "カテゴリ";
            this.カテゴリ.ReadOnly = true;
            this.カテゴリ.Width = 180;
            // 
            // No
            // 
            this.No.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.No.DataPropertyName = "No";
            this.No.HeaderText = "No";
            this.No.Name = "No";
            this.No.ReadOnly = true;
            this.No.Width = 60;
            // 
            // チェック内容
            // 
            this.チェック内容.DataPropertyName = "チェック内容";
            this.チェック内容.HeaderText = "チェック内容";
            this.チェック内容.Name = "チェック内容";
            this.チェック内容.ReadOnly = true;
            // 
            // 備考
            // 
            this.備考.DataPropertyName = "備考";
            this.備考.HeaderText = "備考";
            this.備考.Name = "備考";
            this.備考.ReadOnly = true;
            // 
            // CheckAdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 465);
            this.Controls.Add(this.CbBox_フィルタ);
            this.Controls.Add(this.Txt_検索);
            this.Controls.Add(this.Dgv_チェック一覧);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("メイリオ", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CheckAdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "チェック管理";
            this.Load += new System.EventHandler(this.CheckAdminForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_チェック一覧)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_チェック一覧)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Dgv_チェック一覧;
        private System.Windows.Forms.BindingSource BS_チェック一覧;
        private System.Windows.Forms.TextBox Txt_検索;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CbBox_フィルタ;
        private System.Windows.Forms.DataGridViewTextBoxColumn カテゴリ;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn チェック内容;
        private System.Windows.Forms.DataGridViewTextBoxColumn 備考;
    }
}