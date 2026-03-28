namespace $safeprojectname$.Forms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.Lbl_ver = new System.Windows.Forms.Label();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.Txt_取込ファイル = new System.Windows.Forms.TextBox();
            this.Btn_取込ファイル参照 = new System.Windows.Forms.Button();
            this.Link_テスト = new System.Windows.Forms.LinkLabel();
            this.Lbl_取込ファイル = new System.Windows.Forms.Label();
            this.Lbl_出力フォルダ = new System.Windows.Forms.Label();
            this.Btn_出力フォルダ参照 = new System.Windows.Forms.Button();
            this.Txt_出力フォルダ = new System.Windows.Forms.TextBox();
            this.ToolTip_ファイル名 = new System.Windows.Forms.ToolTip(this.components);
            this.ToolTip_フォルダパス = new System.Windows.Forms.ToolTip(this.components);
            this.GrpBox_RINDBERG = new System.Windows.Forms.GroupBox();
            this.Txt_RINDログインID = new System.Windows.Forms.TextBox();
            this.Txt_RINDパスワード = new System.Windows.Forms.TextBox();
            this.Lbl_RINDログインID = new System.Windows.Forms.Label();
            this.Lbl_RINDパスワード = new System.Windows.Forms.Label();
            this.ChkBox_RIND入力内容保存 = new System.Windows.Forms.CheckBox();
            this.Btn_ファイル取込 = new System.Windows.Forms.Button();
            this.Btn_チェック管理 = new System.Windows.Forms.Button();
            this.Btn_ファイル出力 = new System.Windows.Forms.Button();
            this.Btn_マスタ管理 = new System.Windows.Forms.Button();
            this.Txt_ツールパスワード = new System.Windows.Forms.TextBox();
            this.Lbl_ツールパスワード = new System.Windows.Forms.Label();
            this.ChkBox_ツールパスワード保存 = new System.Windows.Forms.CheckBox();
            this.PicBox_システム管理 = new System.Windows.Forms.PictureBox();
            this.PicBox_ロゴ = new System.Windows.Forms.PictureBox();
            this.Sts_フッター = new System.Windows.Forms.StatusStrip();
            this.Lbl_経過時間 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.Pnl_取込ファイル拡張子 = new System.Windows.Forms.Panel();
            this.Radio_csv = new System.Windows.Forms.RadioButton();
            this.Radio_xlsx = new System.Windows.Forms.RadioButton();
            this.GrpBox_RINDBERG.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBox_システム管理)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBox_ロゴ)).BeginInit();
            this.Sts_フッター.SuspendLayout();
            this.Pnl_取込ファイル拡張子.SuspendLayout();
            this.SuspendLayout();
            // 
            // Lbl_ver
            // 
            this.Lbl_ver.AutoSize = true;
            this.Lbl_ver.Font = new System.Drawing.Font("メイリオ", 9F);
            this.Lbl_ver.Location = new System.Drawing.Point(18, 81);
            this.Lbl_ver.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_ver.Name = "Lbl_ver";
            this.Lbl_ver.Size = new System.Drawing.Size(58, 18);
            this.Lbl_ver.TabIndex = 0;
            this.Lbl_ver.Text = "ver : 0.0";
            // 
            // Timer
            // 
            this.Timer.Interval = 1000;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // Txt_取込ファイル
            // 
            this.Txt_取込ファイル.AllowDrop = true;
            this.Txt_取込ファイル.Location = new System.Drawing.Point(21, 193);
            this.Txt_取込ファイル.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Txt_取込ファイル.Name = "Txt_取込ファイル";
            this.Txt_取込ファイル.Size = new System.Drawing.Size(486, 27);
            this.Txt_取込ファイル.TabIndex = 5;
            this.Txt_取込ファイル.DragDrop += new System.Windows.Forms.DragEventHandler(this.TextBox_DragDropFile);
            this.Txt_取込ファイル.DragEnter += new System.Windows.Forms.DragEventHandler(this.TextBox_DragEnter);
            this.Txt_取込ファイル.Leave += new System.EventHandler(this.Txt_取込ファイル_Leave);
            // 
            // Btn_取込ファイル参照
            // 
            this.Btn_取込ファイル参照.Location = new System.Drawing.Point(510, 192);
            this.Btn_取込ファイル参照.Name = "Btn_取込ファイル参照";
            this.Btn_取込ファイル参照.Size = new System.Drawing.Size(45, 29);
            this.Btn_取込ファイル参照.TabIndex = 6;
            this.Btn_取込ファイル参照.Text = "…";
            this.Btn_取込ファイル参照.UseVisualStyleBackColor = true;
            this.Btn_取込ファイル参照.Click += new System.EventHandler(this.Btn_取込ファイル参照_Click);
            // 
            // Link_テスト
            // 
            this.Link_テスト.AutoSize = true;
            this.Link_テスト.Location = new System.Drawing.Point(528, 54);
            this.Link_テスト.Name = "Link_テスト";
            this.Link_テスト.Size = new System.Drawing.Size(164, 21);
            this.Link_テスト.TabIndex = 1;
            this.Link_テスト.TabStop = true;
            this.Link_テスト.Text = "マイクロツールセンター";
            this.Link_テスト.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Link_テスト_LinkClicked);
            // 
            // Lbl_取込ファイル
            // 
            this.Lbl_取込ファイル.AutoSize = true;
            this.Lbl_取込ファイル.Location = new System.Drawing.Point(17, 167);
            this.Lbl_取込ファイル.Name = "Lbl_取込ファイル";
            this.Lbl_取込ファイル.Size = new System.Drawing.Size(94, 21);
            this.Lbl_取込ファイル.TabIndex = 6;
            this.Lbl_取込ファイル.Text = "取込ファイル";
            // 
            // Lbl_出力フォルダ
            // 
            this.Lbl_出力フォルダ.AutoSize = true;
            this.Lbl_出力フォルダ.Location = new System.Drawing.Point(17, 289);
            this.Lbl_出力フォルダ.Name = "Lbl_出力フォルダ";
            this.Lbl_出力フォルダ.Size = new System.Drawing.Size(94, 21);
            this.Lbl_出力フォルダ.TabIndex = 9;
            this.Lbl_出力フォルダ.Text = "出力フォルダ";
            // 
            // Btn_出力フォルダ参照
            // 
            this.Btn_出力フォルダ参照.Location = new System.Drawing.Point(510, 314);
            this.Btn_出力フォルダ参照.Name = "Btn_出力フォルダ参照";
            this.Btn_出力フォルダ参照.Size = new System.Drawing.Size(45, 29);
            this.Btn_出力フォルダ参照.TabIndex = 11;
            this.Btn_出力フォルダ参照.Text = "…";
            this.Btn_出力フォルダ参照.UseVisualStyleBackColor = true;
            this.Btn_出力フォルダ参照.Click += new System.EventHandler(this.Btn_出力フォルダ参照_Click);
            // 
            // Txt_出力フォルダ
            // 
            this.Txt_出力フォルダ.AllowDrop = true;
            this.Txt_出力フォルダ.Location = new System.Drawing.Point(21, 315);
            this.Txt_出力フォルダ.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Txt_出力フォルダ.Name = "Txt_出力フォルダ";
            this.Txt_出力フォルダ.Size = new System.Drawing.Size(486, 27);
            this.Txt_出力フォルダ.TabIndex = 10;
            this.Txt_出力フォルダ.DragDrop += new System.Windows.Forms.DragEventHandler(this.TextBox_DragDropFolder);
            this.Txt_出力フォルダ.DragEnter += new System.Windows.Forms.DragEventHandler(this.TextBox_DragEnter);
            this.Txt_出力フォルダ.Leave += new System.EventHandler(this.Txt_出力フォルダ_Leave);
            // 
            // ToolTip_ファイル名
            // 
            this.ToolTip_ファイル名.AutomaticDelay = 100;
            this.ToolTip_ファイル名.AutoPopDelay = 10000;
            this.ToolTip_ファイル名.InitialDelay = 100;
            this.ToolTip_ファイル名.IsBalloon = true;
            this.ToolTip_ファイル名.ReshowDelay = 20;
            this.ToolTip_ファイル名.ToolTipTitle = "ファイル名";
            this.ToolTip_ファイル名.UseFading = false;
            // 
            // ToolTip_フォルダパス
            // 
            this.ToolTip_フォルダパス.AutomaticDelay = 100;
            this.ToolTip_フォルダパス.AutoPopDelay = 10000;
            this.ToolTip_フォルダパス.InitialDelay = 100;
            this.ToolTip_フォルダパス.IsBalloon = true;
            this.ToolTip_フォルダパス.ReshowDelay = 20;
            this.ToolTip_フォルダパス.ToolTipTitle = "フォルダパス";
            this.ToolTip_フォルダパス.UseFading = false;
            // 
            // GrpBox_RINDBERG
            // 
            this.GrpBox_RINDBERG.Controls.Add(this.Txt_RINDログインID);
            this.GrpBox_RINDBERG.Controls.Add(this.Txt_RINDパスワード);
            this.GrpBox_RINDBERG.Controls.Add(this.Lbl_RINDログインID);
            this.GrpBox_RINDBERG.Controls.Add(this.Lbl_RINDパスワード);
            this.GrpBox_RINDBERG.Controls.Add(this.ChkBox_RIND入力内容保存);
            this.GrpBox_RINDBERG.Font = new System.Drawing.Font("メイリオ", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.GrpBox_RINDBERG.Location = new System.Drawing.Point(246, 19);
            this.GrpBox_RINDBERG.Name = "GrpBox_RINDBERG";
            this.GrpBox_RINDBERG.Size = new System.Drawing.Size(249, 117);
            this.GrpBox_RINDBERG.TabIndex = 0;
            this.GrpBox_RINDBERG.TabStop = false;
            this.GrpBox_RINDBERG.Text = "RINDBERG";
            // 
            // Txt_RINDログインID
            // 
            this.Txt_RINDログインID.BackColor = System.Drawing.SystemColors.Window;
            this.Txt_RINDログインID.Font = new System.Drawing.Font("メイリオ", 9F);
            this.Txt_RINDログインID.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.Txt_RINDログインID.Location = new System.Drawing.Point(89, 25);
            this.Txt_RINDログインID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Txt_RINDログインID.Name = "Txt_RINDログインID";
            this.Txt_RINDログインID.Size = new System.Drawing.Size(140, 25);
            this.Txt_RINDログインID.TabIndex = 0;
            // 
            // Txt_RINDパスワード
            // 
            this.Txt_RINDパスワード.BackColor = System.Drawing.SystemColors.Window;
            this.Txt_RINDパスワード.Font = new System.Drawing.Font("メイリオ", 9F);
            this.Txt_RINDパスワード.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.Txt_RINDパスワード.Location = new System.Drawing.Point(89, 58);
            this.Txt_RINDパスワード.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Txt_RINDパスワード.Name = "Txt_RINDパスワード";
            this.Txt_RINDパスワード.Size = new System.Drawing.Size(140, 25);
            this.Txt_RINDパスワード.TabIndex = 1;
            this.Txt_RINDパスワード.UseSystemPasswordChar = true;
            // 
            // Lbl_RINDログインID
            // 
            this.Lbl_RINDログインID.AutoSize = true;
            this.Lbl_RINDログインID.Font = new System.Drawing.Font("メイリオ", 9F);
            this.Lbl_RINDログインID.Location = new System.Drawing.Point(12, 28);
            this.Lbl_RINDログインID.Name = "Lbl_RINDログインID";
            this.Lbl_RINDログインID.Size = new System.Drawing.Size(70, 18);
            this.Lbl_RINDログインID.TabIndex = 0;
            this.Lbl_RINDログインID.Text = "ログインID";
            // 
            // Lbl_RINDパスワード
            // 
            this.Lbl_RINDパスワード.AutoSize = true;
            this.Lbl_RINDパスワード.Font = new System.Drawing.Font("メイリオ", 9F);
            this.Lbl_RINDパスワード.Location = new System.Drawing.Point(12, 61);
            this.Lbl_RINDパスワード.Name = "Lbl_RINDパスワード";
            this.Lbl_RINDパスワード.Size = new System.Drawing.Size(68, 18);
            this.Lbl_RINDパスワード.TabIndex = 0;
            this.Lbl_RINDパスワード.Text = "パスワード";
            // 
            // ChkBox_RIND入力内容保存
            // 
            this.ChkBox_RIND入力内容保存.AutoSize = true;
            this.ChkBox_RIND入力内容保存.Checked = true;
            this.ChkBox_RIND入力内容保存.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkBox_RIND入力内容保存.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ChkBox_RIND入力内容保存.Font = new System.Drawing.Font("メイリオ", 9F);
            this.ChkBox_RIND入力内容保存.Location = new System.Drawing.Point(182, 87);
            this.ChkBox_RIND入力内容保存.Name = "ChkBox_RIND入力内容保存";
            this.ChkBox_RIND入力内容保存.Size = new System.Drawing.Size(51, 22);
            this.ChkBox_RIND入力内容保存.TabIndex = 2;
            this.ChkBox_RIND入力内容保存.Text = "保存";
            this.ChkBox_RIND入力内容保存.UseVisualStyleBackColor = true;
            // 
            // Btn_ファイル取込
            // 
            this.Btn_ファイル取込.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_ファイル取込.Font = new System.Drawing.Font("メイリオ", 10F, System.Drawing.FontStyle.Bold);
            this.Btn_ファイル取込.Location = new System.Drawing.Point(561, 191);
            this.Btn_ファイル取込.Name = "Btn_ファイル取込";
            this.Btn_ファイル取込.Size = new System.Drawing.Size(131, 30);
            this.Btn_ファイル取込.TabIndex = 7;
            this.Btn_ファイル取込.Text = "ファイル取込";
            this.Btn_ファイル取込.UseVisualStyleBackColor = true;
            this.Btn_ファイル取込.Click += new System.EventHandler(this.Btn_ファイル取込_Click);
            // 
            // Btn_チェック管理
            // 
            this.Btn_チェック管理.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_チェック管理.Font = new System.Drawing.Font("メイリオ", 10F);
            this.Btn_チェック管理.Location = new System.Drawing.Point(561, 229);
            this.Btn_チェック管理.Name = "Btn_チェック管理";
            this.Btn_チェック管理.Size = new System.Drawing.Size(131, 30);
            this.Btn_チェック管理.TabIndex = 8;
            this.Btn_チェック管理.Text = "チェック管理";
            this.Btn_チェック管理.UseVisualStyleBackColor = true;
            this.Btn_チェック管理.Click += new System.EventHandler(this.Btn_チェック管理_Click);
            // 
            // Btn_ファイル出力
            // 
            this.Btn_ファイル出力.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_ファイル出力.Enabled = false;
            this.Btn_ファイル出力.Font = new System.Drawing.Font("メイリオ", 10F, System.Drawing.FontStyle.Bold);
            this.Btn_ファイル出力.Location = new System.Drawing.Point(561, 313);
            this.Btn_ファイル出力.Name = "Btn_ファイル出力";
            this.Btn_ファイル出力.Size = new System.Drawing.Size(131, 30);
            this.Btn_ファイル出力.TabIndex = 12;
            this.Btn_ファイル出力.Text = "ファイル出力";
            this.Btn_ファイル出力.UseVisualStyleBackColor = true;
            this.Btn_ファイル出力.Click += new System.EventHandler(this.Btn_ファイル出力_Click);
            // 
            // Btn_マスタ管理
            // 
            this.Btn_マスタ管理.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_マスタ管理.Font = new System.Drawing.Font("メイリオ", 10F);
            this.Btn_マスタ管理.Location = new System.Drawing.Point(561, 267);
            this.Btn_マスタ管理.Name = "Btn_マスタ管理";
            this.Btn_マスタ管理.Size = new System.Drawing.Size(131, 30);
            this.Btn_マスタ管理.TabIndex = 9;
            this.Btn_マスタ管理.Text = "マスタ管理";
            this.Btn_マスタ管理.UseVisualStyleBackColor = true;
            this.Btn_マスタ管理.Click += new System.EventHandler(this.Btn_マスタ管理_Click);
            // 
            // Txt_ツールパスワード
            // 
            this.Txt_ツールパスワード.BackColor = System.Drawing.SystemColors.Window;
            this.Txt_ツールパスワード.Font = new System.Drawing.Font("メイリオ", 9F);
            this.Txt_ツールパスワード.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.Txt_ツールパスワード.Location = new System.Drawing.Point(561, 124);
            this.Txt_ツールパスワード.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Txt_ツールパスワード.Name = "Txt_ツールパスワード";
            this.Txt_ツールパスワード.Size = new System.Drawing.Size(131, 25);
            this.Txt_ツールパスワード.TabIndex = 2;
            this.Txt_ツールパスワード.UseSystemPasswordChar = true;
            // 
            // Lbl_ツールパスワード
            // 
            this.Lbl_ツールパスワード.AutoSize = true;
            this.Lbl_ツールパスワード.Font = new System.Drawing.Font("メイリオ", 9F);
            this.Lbl_ツールパスワード.Location = new System.Drawing.Point(558, 103);
            this.Lbl_ツールパスワード.Name = "Lbl_ツールパスワード";
            this.Lbl_ツールパスワード.Size = new System.Drawing.Size(68, 18);
            this.Lbl_ツールパスワード.TabIndex = 13;
            this.Lbl_ツールパスワード.Text = "パスワード";
            // 
            // ChkBox_ツールパスワード保存
            // 
            this.ChkBox_ツールパスワード保存.AutoSize = true;
            this.ChkBox_ツールパスワード保存.Checked = true;
            this.ChkBox_ツールパスワード保存.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkBox_ツールパスワード保存.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ChkBox_ツールパスワード保存.Font = new System.Drawing.Font("メイリオ", 9F);
            this.ChkBox_ツールパスワード保存.Location = new System.Drawing.Point(641, 102);
            this.ChkBox_ツールパスワード保存.Name = "ChkBox_ツールパスワード保存";
            this.ChkBox_ツールパスワード保存.Size = new System.Drawing.Size(51, 22);
            this.ChkBox_ツールパスワード保存.TabIndex = 3;
            this.ChkBox_ツールパスワード保存.Text = "保存";
            this.ChkBox_ツールパスワード保存.UseVisualStyleBackColor = true;
            // 
            // PicBox_システム管理
            // 
            this.PicBox_システム管理.Image = global::$safeprojectname$.Properties.Resources.setting;
            this.PicBox_システム管理.Location = new System.Drawing.Point(667, 14);
            this.PicBox_システム管理.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PicBox_システム管理.Name = "PicBox_システム管理";
            this.PicBox_システム管理.Size = new System.Drawing.Size(25, 25);
            this.PicBox_システム管理.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicBox_システム管理.TabIndex = 56;
            this.PicBox_システム管理.TabStop = false;
            this.PicBox_システム管理.Click += new System.EventHandler(this.PicBox_システム管理_Click);
            this.PicBox_システム管理.MouseLeave += new System.EventHandler(this.PicBox_システム管理_MouseLeave);
            this.PicBox_システム管理.MouseHover += new System.EventHandler(this.PicBox_システム管理_MouseHover);
            // 
            // PicBox_ロゴ
            // 
            this.PicBox_ロゴ.ErrorImage = null;
            this.PicBox_ロゴ.Image = global::$safeprojectname$.Properties.Resources.template_logo;
            this.PicBox_ロゴ.Location = new System.Drawing.Point(21, 19);
            this.PicBox_ロゴ.Name = "PicBox_ロゴ";
            this.PicBox_ロゴ.Size = new System.Drawing.Size(200, 59);
            this.PicBox_ロゴ.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PicBox_ロゴ.TabIndex = 4;
            this.PicBox_ロゴ.TabStop = false;
            // 
            // Sts_フッター
            // 
            this.Sts_フッター.Font = new System.Drawing.Font("メイリオ", 9F);
            this.Sts_フッター.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Lbl_経過時間,
            this.ProgressBar});
            this.Sts_フッター.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.Sts_フッター.Location = new System.Drawing.Point(0, 369);
            this.Sts_フッター.Name = "Sts_フッター";
            this.Sts_フッター.Size = new System.Drawing.Size(707, 23);
            this.Sts_フッター.SizingGrip = false;
            this.Sts_フッター.TabIndex = 0;
            this.Sts_フッター.Text = "statusStrip";
            // 
            // Lbl_経過時間
            // 
            this.Lbl_経過時間.Name = "Lbl_経過時間";
            this.Lbl_経過時間.Size = new System.Drawing.Size(120, 18);
            this.Lbl_経過時間.Text = "経過時間　00:00:00";
            // 
            // ProgressBar
            // 
            this.ProgressBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.RightToLeftLayout = true;
            this.ProgressBar.Size = new System.Drawing.Size(131, 17);
            // 
            // Pnl_取込ファイル拡張子
            // 
            this.Pnl_取込ファイル拡張子.Controls.Add(this.Radio_csv);
            this.Pnl_取込ファイル拡張子.Controls.Add(this.Radio_xlsx);
            this.Pnl_取込ファイル拡張子.Location = new System.Drawing.Point(118, 163);
            this.Pnl_取込ファイル拡張子.Name = "Pnl_取込ファイル拡張子";
            this.Pnl_取込ファイル拡張子.Size = new System.Drawing.Size(125, 26);
            this.Pnl_取込ファイル拡張子.TabIndex = 4;
            this.Pnl_取込ファイル拡張子.TabStop = true;
            // 
            // Radio_csv
            // 
            this.Radio_csv.AutoSize = true;
            this.Radio_csv.Font = new System.Drawing.Font("メイリオ", 9F);
            this.Radio_csv.Location = new System.Drawing.Point(62, 2);
            this.Radio_csv.Name = "Radio_csv";
            this.Radio_csv.Size = new System.Drawing.Size(49, 22);
            this.Radio_csv.TabIndex = 1;
            this.Radio_csv.TabStop = true;
            this.Radio_csv.Text = ".csv";
            this.Radio_csv.UseVisualStyleBackColor = true;
            this.Radio_csv.CheckedChanged += new System.EventHandler(this.Radio_取込ファイル拡張子_CheckedChanged);
            // 
            // Radio_xlsx
            // 
            this.Radio_xlsx.AutoSize = true;
            this.Radio_xlsx.Checked = true;
            this.Radio_xlsx.Font = new System.Drawing.Font("メイリオ", 9F);
            this.Radio_xlsx.Location = new System.Drawing.Point(3, 2);
            this.Radio_xlsx.Name = "Radio_xlsx";
            this.Radio_xlsx.Size = new System.Drawing.Size(53, 22);
            this.Radio_xlsx.TabIndex = 0;
            this.Radio_xlsx.TabStop = true;
            this.Radio_xlsx.Text = ".xlsx";
            this.Radio_xlsx.UseVisualStyleBackColor = true;
            this.Radio_xlsx.CheckedChanged += new System.EventHandler(this.Radio_取込ファイル拡張子_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 392);
            this.Controls.Add(this.Pnl_取込ファイル拡張子);
            this.Controls.Add(this.Sts_フッター);
            this.Controls.Add(this.PicBox_システム管理);
            this.Controls.Add(this.ChkBox_ツールパスワード保存);
            this.Controls.Add(this.Lbl_ツールパスワード);
            this.Controls.Add(this.Txt_ツールパスワード);
            this.Controls.Add(this.Btn_マスタ管理);
            this.Controls.Add(this.Btn_ファイル出力);
            this.Controls.Add(this.Btn_チェック管理);
            this.Controls.Add(this.Btn_ファイル取込);
            this.Controls.Add(this.GrpBox_RINDBERG);
            this.Controls.Add(this.Lbl_出力フォルダ);
            this.Controls.Add(this.Btn_出力フォルダ参照);
            this.Controls.Add(this.Txt_出力フォルダ);
            this.Controls.Add(this.Lbl_取込ファイル);
            this.Controls.Add(this.Link_テスト);
            this.Controls.Add(this.Btn_取込ファイル参照);
            this.Controls.Add(this.Txt_取込ファイル);
            this.Controls.Add(this.PicBox_ロゴ);
            this.Controls.Add(this.Lbl_ver);
            this.Font = new System.Drawing.Font("メイリオ", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.Text = "ツール名";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.GrpBox_RINDBERG.ResumeLayout(false);
            this.GrpBox_RINDBERG.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBox_システム管理)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBox_ロゴ)).EndInit();
            this.Sts_フッター.ResumeLayout(false);
            this.Sts_フッター.PerformLayout();
            this.Pnl_取込ファイル拡張子.ResumeLayout(false);
            this.Pnl_取込ファイル拡張子.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Lbl_ver;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.PictureBox PicBox_ロゴ;
        private System.Windows.Forms.TextBox Txt_取込ファイル;
        private System.Windows.Forms.Button Btn_取込ファイル参照;
        private System.Windows.Forms.LinkLabel Link_テスト;
        private System.Windows.Forms.Label Lbl_取込ファイル;
        private System.Windows.Forms.Label Lbl_出力フォルダ;
        private System.Windows.Forms.Button Btn_出力フォルダ参照;
        private System.Windows.Forms.TextBox Txt_出力フォルダ;
        private System.Windows.Forms.ToolTip ToolTip_ファイル名;
        private System.Windows.Forms.ToolTip ToolTip_フォルダパス;
        private System.Windows.Forms.GroupBox GrpBox_RINDBERG;
        private System.Windows.Forms.TextBox Txt_RINDログインID;
        private System.Windows.Forms.TextBox Txt_RINDパスワード;
        private System.Windows.Forms.Label Lbl_RINDログインID;
        private System.Windows.Forms.Label Lbl_RINDパスワード;
        private System.Windows.Forms.CheckBox ChkBox_RIND入力内容保存;
        private System.Windows.Forms.Button Btn_ファイル取込;
        private System.Windows.Forms.Button Btn_チェック管理;
        private System.Windows.Forms.Button Btn_ファイル出力;
        private System.Windows.Forms.Button Btn_マスタ管理;
        private System.Windows.Forms.TextBox Txt_ツールパスワード;
        private System.Windows.Forms.Label Lbl_ツールパスワード;
        private System.Windows.Forms.CheckBox ChkBox_ツールパスワード保存;
        private System.Windows.Forms.PictureBox PicBox_システム管理;
        private System.Windows.Forms.StatusStrip Sts_フッター;
        private System.Windows.Forms.ToolStripStatusLabel Lbl_経過時間;
        private System.Windows.Forms.ToolStripProgressBar ProgressBar;
        private System.Windows.Forms.Panel Pnl_取込ファイル拡張子;
        private System.Windows.Forms.RadioButton Radio_xlsx;
        private System.Windows.Forms.RadioButton Radio_csv;
    }
}