namespace $safeprojectname$.Forms
{
    partial class SysAdminForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SysAdminForm));
            this.Btn_ログイン = new System.Windows.Forms.Button();
            this.Txt_パスワード = new System.Windows.Forms.TextBox();
            this.Btn_キャンセル = new System.Windows.Forms.Button();
            this.Btn_保存 = new System.Windows.Forms.Button();
            this.Lbl_更新日時 = new System.Windows.Forms.Label();
            this.Dgv_ツール一覧 = new System.Windows.Forms.DataGridView();
            this.BS_ツール一覧 = new System.Windows.Forms.BindingSource(this.components);
            this.選択 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ツールID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ツール名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ボタン色 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ツールPW = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.サブドメイン = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kintoneユーザーID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kintoneユーザーPW = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_ツール一覧)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_ツール一覧)).BeginInit();
            this.SuspendLayout();
            // 
            // Btn_ログイン
            // 
            this.Btn_ログイン.AutoSize = true;
            this.Btn_ログイン.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_ログイン.Font = new System.Drawing.Font("メイリオ", 10F);
            this.Btn_ログイン.Location = new System.Drawing.Point(107, 12);
            this.Btn_ログイン.Name = "Btn_ログイン";
            this.Btn_ログイン.Size = new System.Drawing.Size(86, 31);
            this.Btn_ログイン.TabIndex = 1;
            this.Btn_ログイン.Text = "ログイン";
            this.Btn_ログイン.UseVisualStyleBackColor = true;
            this.Btn_ログイン.Click += new System.EventHandler(this.Btn_ログイン_Click);
            // 
            // Txt_パスワード
            // 
            this.Txt_パスワード.Font = new System.Drawing.Font("メイリオ", 10F);
            this.Txt_パスワード.Location = new System.Drawing.Point(12, 14);
            this.Txt_パスワード.Name = "Txt_パスワード";
            this.Txt_パスワード.Size = new System.Drawing.Size(89, 27);
            this.Txt_パスワード.TabIndex = 0;
            this.Txt_パスワード.UseSystemPasswordChar = true;
            // 
            // Btn_キャンセル
            // 
            this.Btn_キャンセル.AutoSize = true;
            this.Btn_キャンセル.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_キャンセル.Enabled = false;
            this.Btn_キャンセル.Font = new System.Drawing.Font("メイリオ", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Btn_キャンセル.Location = new System.Drawing.Point(1031, 12);
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
            this.Btn_保存.Enabled = false;
            this.Btn_保存.Font = new System.Drawing.Font("メイリオ", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Btn_保存.Location = new System.Drawing.Point(924, 12);
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
            this.Lbl_更新日時.Location = new System.Drawing.Point(718, 18);
            this.Lbl_更新日時.Name = "Lbl_更新日時";
            this.Lbl_更新日時.Size = new System.Drawing.Size(200, 18);
            this.Lbl_更新日時.TabIndex = 47;
            this.Lbl_更新日時.Text = "更新日時：yyyy/MM/dd hh:mm";
            this.Lbl_更新日時.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Dgv_ツール一覧
            // 
            this.Dgv_ツール一覧.AllowUserToAddRows = false;
            this.Dgv_ツール一覧.AllowUserToDeleteRows = false;
            this.Dgv_ツール一覧.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Dgv_ツール一覧.AutoGenerateColumns = false;
            this.Dgv_ツール一覧.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Dgv_ツール一覧.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_ツール一覧.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.選択,
            this.ツールID,
            this.ツール名,
            this.ボタン色,
            this.ツールPW,
            this.サブドメイン,
            this.kintoneユーザーID,
            this.kintoneユーザーPW});
            this.Dgv_ツール一覧.DataSource = this.BS_ツール一覧;
            this.Dgv_ツール一覧.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.Dgv_ツール一覧.Location = new System.Drawing.Point(12, 49);
            this.Dgv_ツール一覧.Name = "Dgv_ツール一覧";
            this.Dgv_ツール一覧.RowHeadersWidth = 25;
            this.Dgv_ツール一覧.RowTemplate.Height = 21;
            this.Dgv_ツール一覧.Size = new System.Drawing.Size(1120, 204);
            this.Dgv_ツール一覧.TabIndex = 2;
            this.Dgv_ツール一覧.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_ツール一覧_CellContentClick);
            // 
            // 選択
            // 
            this.選択.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.選択.DataPropertyName = "選択";
            this.選択.HeaderText = "選択";
            this.選択.Name = "選択";
            this.選択.Width = 40;
            // 
            // ツールID
            // 
            this.ツールID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ツールID.DataPropertyName = "ツールID";
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ツールID.DefaultCellStyle = dataGridViewCellStyle2;
            this.ツールID.HeaderText = "ツールID";
            this.ツールID.Name = "ツールID";
            this.ツールID.ReadOnly = true;
            // 
            // ツール名
            // 
            this.ツール名.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ツール名.DataPropertyName = "ツール名";
            this.ツール名.HeaderText = "ツール名";
            this.ツール名.Name = "ツール名";
            this.ツール名.Width = 220;
            // 
            // ボタン色
            // 
            this.ボタン色.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ボタン色.DataPropertyName = "ボタン色(Hex)";
            this.ボタン色.HeaderText = "ボタン色(Hex)";
            this.ボタン色.Name = "ボタン色";
            this.ボタン色.Width = 130;
            // 
            // ツールPW
            // 
            this.ツールPW.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ツールPW.DataPropertyName = "ツールPW";
            this.ツールPW.HeaderText = "ツールPW";
            this.ツールPW.Name = "ツールPW";
            // 
            // サブドメイン
            // 
            this.サブドメイン.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.サブドメイン.DataPropertyName = "サブドメイン";
            this.サブドメイン.HeaderText = "サブドメイン";
            this.サブドメイン.Name = "サブドメイン";
            this.サブドメイン.Width = 170;
            // 
            // kintoneユーザーID
            // 
            this.kintoneユーザーID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.kintoneユーザーID.DataPropertyName = "kintoneユーザーID";
            this.kintoneユーザーID.HeaderText = "kintoneユーザーID";
            this.kintoneユーザーID.Name = "kintoneユーザーID";
            this.kintoneユーザーID.Width = 170;
            // 
            // kintoneユーザーPW
            // 
            this.kintoneユーザーPW.DataPropertyName = "kintoneユーザーPW";
            this.kintoneユーザーPW.HeaderText = "kintoneユーザーPW";
            this.kintoneユーザーPW.Name = "kintoneユーザーPW";
            // 
            // SysAdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1144, 265);
            this.Controls.Add(this.Dgv_ツール一覧);
            this.Controls.Add(this.Btn_ログイン);
            this.Controls.Add(this.Txt_パスワード);
            this.Controls.Add(this.Btn_キャンセル);
            this.Controls.Add(this.Btn_保存);
            this.Controls.Add(this.Lbl_更新日時);
            this.Font = new System.Drawing.Font("メイリオ", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SysAdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "システム管理";
            this.Load += new System.EventHandler(this.SysAdminForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_ツール一覧)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_ツール一覧)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Btn_ログイン;
        private System.Windows.Forms.TextBox Txt_パスワード;
        private System.Windows.Forms.Button Btn_キャンセル;
        private System.Windows.Forms.Button Btn_保存;
        private System.Windows.Forms.Label Lbl_更新日時;
        private System.Windows.Forms.DataGridView Dgv_ツール一覧;
        private System.Windows.Forms.BindingSource BS_ツール一覧;
        private System.Windows.Forms.DataGridViewCheckBoxColumn 選択;
        private System.Windows.Forms.DataGridViewTextBoxColumn ツールID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ツール名;
        private System.Windows.Forms.DataGridViewTextBoxColumn ボタン色;
        private System.Windows.Forms.DataGridViewTextBoxColumn ツールPW;
        private System.Windows.Forms.DataGridViewTextBoxColumn サブドメイン;
        private System.Windows.Forms.DataGridViewTextBoxColumn kintoneユーザーID;
        private System.Windows.Forms.DataGridViewTextBoxColumn kintoneユーザーPW;
    }
}