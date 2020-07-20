namespace cz
{
    partial class H_CZ_SM_PITEM_SUB
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
                  System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(H_CZ_SM_PITEM_SUB));
                  this.flex = new Dass.FlexGridLight.FlexGrid(this.components);
                  this._bnCancel = new Duzon.Common.Controls.RoundedButton(this.components);
                  this._bnOk = new Duzon.Common.Controls.RoundedButton(this.components);
                  this._bnSearch = new Duzon.Common.Controls.RoundedButton(this.components);
                  this.m_pnlSearch = new Duzon.Common.Controls.PanelExt();
                  this.cbo아이템군 = new Duzon.Common.Controls.DropDownComboBox();
                  this.cbo품목타입S = new Duzon.Common.Controls.DropDownComboBox();
                  this.bp예산계정s = new Duzon.Common.BpControls.BpCodeTextBox();
                  this.panel39 = new Duzon.Common.Controls.PanelExt();
                  this.panelExt2 = new Duzon.Common.Controls.PanelExt();
                  this.lbl예산계정 = new Duzon.Common.Controls.LabelExt();
                  this.lbl계정구분S = new Duzon.Common.Controls.LabelExt();
                  this.cbo계정구분S = new Duzon.Common.Controls.DropDownComboBox();
                  this._txt검색 = new Duzon.Common.Controls.TextBoxExt();
                  this.panel37 = new Duzon.Common.Controls.PanelExt();
                  this.lbl아이템군 = new Duzon.Common.Controls.LabelExt();
                  this.lbl아이템타입 = new Duzon.Common.Controls.LabelExt();
                  this.panel36 = new Duzon.Common.Controls.PanelExt();
                  this.lbl공장코드S = new Duzon.Common.Controls.LabelExt();
                  this.lbl검색S = new Duzon.Common.Controls.LabelExt();
                  this.cbo공장코드S = new Duzon.Common.Controls.DropDownComboBox();
                  ((System.ComponentModel.ISupportInitialize)(this.closeButton)).BeginInit();
                  ((System.ComponentModel.ISupportInitialize)(this.flex)).BeginInit();
                  this.m_pnlSearch.SuspendLayout();
                  this.panelExt2.SuspendLayout();
                  this.panel37.SuspendLayout();
                  this.panel36.SuspendLayout();
                  this.SuspendLayout();
                  // 
                  // flex
                  // 
                  this.flex.AllowFreezing = C1.Win.C1FlexGrid.AllowFreezingEnum.Both;
                  this.flex.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Both;
                  this.flex.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                              | System.Windows.Forms.AnchorStyles.Left)
                              | System.Windows.Forms.AnchorStyles.Right)));
                  this.flex.AutoResize = false;
                  this.flex.ColumnInfo = "1,1,0,0,0,90,Columns:0{TextAlign:CenterCenter;TextAlignFixed:CenterCenter;}\t";
                  this.flex.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.OwnerDraw;
                  this.flex.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
                  this.flex.Location = new System.Drawing.Point(6, 138);
                  this.flex.Name = "flex";
                  this.flex.Rows.Count = 1;
                  this.flex.Rows.DefaultSize = 18;
                  this.flex.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
                  this.flex.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.Always;
                  this.flex.ShowSort = false;
                  this.flex.Size = new System.Drawing.Size(772, 300);
                  this.flex.StyleInfo = resources.GetString("flex.StyleInfo");
                  this.flex.TabIndex = 27;
                  // 
                  // _bnCancel
                  // 
                  this._bnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                  this._bnCancel.BackColor = System.Drawing.Color.White;
                  this._bnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
                  this._bnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                  this._bnCancel.Location = new System.Drawing.Point(717, 113);
                  this._bnCancel.MaximumSize = new System.Drawing.Size(0, 19);
                  this._bnCancel.Name = "_bnCancel";
                  this._bnCancel.Size = new System.Drawing.Size(61, 19);
                  this._bnCancel.TabIndex = 33;
                  this._bnCancel.TabStop = false;
                  this._bnCancel.Text = "취소";
                  this._bnCancel.UseVisualStyleBackColor = true;
                  // 
                  // _bnOk
                  // 
                  this._bnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                  this._bnOk.BackColor = System.Drawing.Color.White;
                  this._bnOk.Cursor = System.Windows.Forms.Cursors.Hand;
                  this._bnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                  this._bnOk.Location = new System.Drawing.Point(655, 113);
                  this._bnOk.MaximumSize = new System.Drawing.Size(0, 19);
                  this._bnOk.Name = "_bnOk";
                  this._bnOk.Size = new System.Drawing.Size(61, 19);
                  this._bnOk.TabIndex = 32;
                  this._bnOk.TabStop = false;
                  this._bnOk.Text = "확인";
                  this._bnOk.UseVisualStyleBackColor = true;
                  // 
                  // _bnSearch
                  // 
                  this._bnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                  this._bnSearch.BackColor = System.Drawing.Color.White;
                  this._bnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
                  this._bnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                  this._bnSearch.Location = new System.Drawing.Point(592, 113);
                  this._bnSearch.MaximumSize = new System.Drawing.Size(0, 19);
                  this._bnSearch.Name = "_bnSearch";
                  this._bnSearch.Size = new System.Drawing.Size(61, 19);
                  this._bnSearch.TabIndex = 31;
                  this._bnSearch.TabStop = false;
                  this._bnSearch.Text = "검색";
                  this._bnSearch.UseVisualStyleBackColor = true;
                  // 
                  // m_pnlSearch
                  // 
                  this.m_pnlSearch.BackColor = System.Drawing.Color.White;
                  this.m_pnlSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                  this.m_pnlSearch.Controls.Add(this.cbo아이템군);
                  this.m_pnlSearch.Controls.Add(this.cbo품목타입S);
                  this.m_pnlSearch.Controls.Add(this.bp예산계정s);
                  this.m_pnlSearch.Controls.Add(this.panel39);
                  this.m_pnlSearch.Controls.Add(this.panelExt2);
                  this.m_pnlSearch.Controls.Add(this.cbo계정구분S);
                  this.m_pnlSearch.Controls.Add(this._txt검색);
                  this.m_pnlSearch.Controls.Add(this.panel37);
                  this.m_pnlSearch.Controls.Add(this.panel36);
                  this.m_pnlSearch.Controls.Add(this.cbo공장코드S);
                  this.m_pnlSearch.Font = new System.Drawing.Font("굴림체", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                  this.m_pnlSearch.Location = new System.Drawing.Point(6, 52);
                  this.m_pnlSearch.Name = "m_pnlSearch";
                  this.m_pnlSearch.Size = new System.Drawing.Size(772, 55);
                  this.m_pnlSearch.TabIndex = 35;
                  // 
                  // cbo아이템군
                  // 
                  this.cbo아이템군.AutoDropDown = true;
                  this.cbo아이템군.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                  this.cbo아이템군.FormattingEnabled = true;
                  this.cbo아이템군.ItemHeight = 12;
                  this.cbo아이템군.Location = new System.Drawing.Point(341, 29);
                  this.cbo아이템군.Name = "cbo아이템군";
                  this.cbo아이템군.ShowCheckBox = false;
                  this.cbo아이템군.Size = new System.Drawing.Size(173, 20);
                  this.cbo아이템군.TabIndex = 122;
                  this.cbo아이템군.UseKeyEnter = true;
                  this.cbo아이템군.UseKeyF3 = true;
                  // 
                  // cbo품목타입S
                  // 
                  this.cbo품목타입S.AutoDropDown = true;
                  this.cbo품목타입S.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                  this.cbo품목타입S.FormattingEnabled = true;
                  this.cbo품목타입S.ItemHeight = 12;
                  this.cbo품목타입S.Location = new System.Drawing.Point(341, 3);
                  this.cbo품목타입S.Name = "cbo품목타입S";
                  this.cbo품목타입S.ShowCheckBox = false;
                  this.cbo품목타입S.Size = new System.Drawing.Size(173, 20);
                  this.cbo품목타입S.TabIndex = 1;
                  this.cbo품목타입S.Tag = "TP_ITEM";
                  this.cbo품목타입S.UseKeyEnter = true;
                  this.cbo품목타입S.UseKeyF3 = true;
                  // 
                  // bp예산계정s
                  // 
                  this.bp예산계정s.HelpID = Duzon.Common.Forms.Help.HelpID.P_FI_BGACCT_SUB;
                  this.bp예산계정s.Location = new System.Drawing.Point(598, 30);
                  this.bp예산계정s.Name = "bp예산계정s";
                  this.bp예산계정s.Size = new System.Drawing.Size(167, 21);
                  this.bp예산계정s.TabIndex = 4;
                  this.bp예산계정s.TabStop = false;
                  this.bp예산계정s.Tag = "CD_BGACCT,NM_BGACCT";
                  // 
                  // panel39
                  // 
                  this.panel39.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                              | System.Windows.Forms.AnchorStyles.Right)));
                  this.panel39.BackColor = System.Drawing.Color.Transparent;
                  this.panel39.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel39.BackgroundImage")));
                  this.panel39.Font = new System.Drawing.Font("굴림체", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                  this.panel39.Location = new System.Drawing.Point(5, 26);
                  this.panel39.Name = "panel39";
                  this.panel39.Size = new System.Drawing.Size(2422, 1);
                  this.panel39.TabIndex = 121;
                  // 
                  // panelExt2
                  // 
                  this.panelExt2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(254)))), ((int)(((byte)(177)))));
                  this.panelExt2.Controls.Add(this.lbl예산계정);
                  this.panelExt2.Controls.Add(this.lbl계정구분S);
                  this.panelExt2.Font = new System.Drawing.Font("굴림체", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                  this.panelExt2.Location = new System.Drawing.Point(520, 1);
                  this.panelExt2.Name = "panelExt2";
                  this.panelExt2.Size = new System.Drawing.Size(74, 51);
                  this.panelExt2.TabIndex = 120;
                  // 
                  // lbl예산계정
                  // 
                  this.lbl예산계정.BackColor = System.Drawing.Color.Transparent;
                  this.lbl예산계정.Font = new System.Drawing.Font("굴림체", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                  this.lbl예산계정.Location = new System.Drawing.Point(6, 30);
                  this.lbl예산계정.Name = "lbl예산계정";
                  this.lbl예산계정.Resizeble = true;
                  this.lbl예산계정.Size = new System.Drawing.Size(66, 18);
                  this.lbl예산계정.TabIndex = 162;
                  this.lbl예산계정.Tag = "TP_PROC";
                  this.lbl예산계정.Text = "예산계정";
                  this.lbl예산계정.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                  // 
                  // lbl계정구분S
                  // 
                  this.lbl계정구분S.BackColor = System.Drawing.Color.Transparent;
                  this.lbl계정구분S.Font = new System.Drawing.Font("굴림체", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                  this.lbl계정구분S.Location = new System.Drawing.Point(1, 4);
                  this.lbl계정구분S.Name = "lbl계정구분S";
                  this.lbl계정구분S.Resizeble = true;
                  this.lbl계정구분S.Size = new System.Drawing.Size(71, 18);
                  this.lbl계정구분S.TabIndex = 1;
                  this.lbl계정구분S.Tag = "CLS_ITEM";
                  this.lbl계정구분S.Text = "아이템계정";
                  this.lbl계정구분S.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                  // 
                  // cbo계정구분S
                  // 
                  this.cbo계정구분S.AutoDropDown = true;
                  this.cbo계정구분S.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                  this.cbo계정구분S.Font = new System.Drawing.Font("굴림체", 9F);
                  this.cbo계정구분S.ItemHeight = 12;
                  this.cbo계정구분S.Location = new System.Drawing.Point(598, 3);
                  this.cbo계정구분S.MaxLength = 3;
                  this.cbo계정구분S.Name = "cbo계정구분S";
                  this.cbo계정구분S.ShowCheckBox = false;
                  this.cbo계정구분S.Size = new System.Drawing.Size(165, 20);
                  this.cbo계정구분S.TabIndex = 2;
                  this.cbo계정구분S.Tag = "CLS_ITEM";
                  this.cbo계정구분S.UseKeyEnter = true;
                  this.cbo계정구분S.UseKeyF3 = true;
                  // 
                  // _txt검색
                  // 
                  this._txt검색.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(199)))), ((int)(((byte)(217)))));
                  this._txt검색.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                  this._txt검색.Font = new System.Drawing.Font("굴림체", 9F);
                  this._txt검색.Location = new System.Drawing.Point(79, 30);
                  this._txt검색.MaxLength = 20;
                  this._txt검색.Name = "_txt검색";
                  this._txt검색.SelectedAllEnabled = false;
                  this._txt검색.Size = new System.Drawing.Size(180, 21);
                  this._txt검색.TabIndex = 3;
                  this._txt검색.Tag = "CD_ITEM";
                  this._txt검색.UseKeyEnter = true;
                  this._txt검색.UseKeyF3 = true;
                  // 
                  // panel37
                  // 
                  this.panel37.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(254)))), ((int)(((byte)(177)))));
                  this.panel37.Controls.Add(this.lbl아이템군);
                  this.panel37.Controls.Add(this.lbl아이템타입);
                  this.panel37.Font = new System.Drawing.Font("굴림체", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                  this.panel37.Location = new System.Drawing.Point(263, 1);
                  this.panel37.Name = "panel37";
                  this.panel37.Size = new System.Drawing.Size(74, 51);
                  this.panel37.TabIndex = 119;
                  // 
                  // lbl아이템군
                  // 
                  this.lbl아이템군.BackColor = System.Drawing.Color.Transparent;
                  this.lbl아이템군.Font = new System.Drawing.Font("굴림체", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                  this.lbl아이템군.Location = new System.Drawing.Point(2, 29);
                  this.lbl아이템군.Name = "lbl아이템군";
                  this.lbl아이템군.Resizeble = true;
                  this.lbl아이템군.Size = new System.Drawing.Size(71, 18);
                  this.lbl아이템군.TabIndex = 156;
                  this.lbl아이템군.Tag = "TP_PART";
                  this.lbl아이템군.Text = "아이템군";
                  this.lbl아이템군.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                  // 
                  // lbl아이템타입
                  // 
                  this.lbl아이템타입.BackColor = System.Drawing.Color.Transparent;
                  this.lbl아이템타입.Font = new System.Drawing.Font("굴림체", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                  this.lbl아이템타입.Location = new System.Drawing.Point(2, 3);
                  this.lbl아이템타입.Name = "lbl아이템타입";
                  this.lbl아이템타입.Resizeble = true;
                  this.lbl아이템타입.Size = new System.Drawing.Size(71, 18);
                  this.lbl아이템타입.TabIndex = 155;
                  this.lbl아이템타입.Tag = "TP_PART";
                  this.lbl아이템타입.Text = "아이템타입";
                  this.lbl아이템타입.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                  // 
                  // panel36
                  // 
                  this.panel36.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(254)))), ((int)(((byte)(177)))));
                  this.panel36.Controls.Add(this.lbl공장코드S);
                  this.panel36.Controls.Add(this.lbl검색S);
                  this.panel36.Font = new System.Drawing.Font("굴림체", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                  this.panel36.Location = new System.Drawing.Point(1, 1);
                  this.panel36.Name = "panel36";
                  this.panel36.Size = new System.Drawing.Size(74, 51);
                  this.panel36.TabIndex = 118;
                  // 
                  // lbl공장코드S
                  // 
                  this.lbl공장코드S.BackColor = System.Drawing.Color.Transparent;
                  this.lbl공장코드S.Location = new System.Drawing.Point(2, 4);
                  this.lbl공장코드S.Name = "lbl공장코드S";
                  this.lbl공장코드S.Resizeble = true;
                  this.lbl공장코드S.Size = new System.Drawing.Size(71, 18);
                  this.lbl공장코드S.TabIndex = 14;
                  this.lbl공장코드S.Tag = "CD_PLANT";
                  this.lbl공장코드S.Text = "공장";
                  this.lbl공장코드S.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                  // 
                  // lbl검색S
                  // 
                  this.lbl검색S.BackColor = System.Drawing.Color.Transparent;
                  this.lbl검색S.Font = new System.Drawing.Font("굴림체", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                  this.lbl검색S.Location = new System.Drawing.Point(2, 30);
                  this.lbl검색S.Name = "lbl검색S";
                  this.lbl검색S.Resizeble = true;
                  this.lbl검색S.Size = new System.Drawing.Size(71, 18);
                  this.lbl검색S.TabIndex = 2;
                  this.lbl검색S.Tag = "SEARCH";
                  this.lbl검색S.Text = "검색";
                  this.lbl검색S.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                  // 
                  // cbo공장코드S
                  // 
                  this.cbo공장코드S.AutoDropDown = true;
                  this.cbo공장코드S.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(243)))));
                  this.cbo공장코드S.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                  this.cbo공장코드S.ItemHeight = 12;
                  this.cbo공장코드S.Location = new System.Drawing.Point(79, 3);
                  this.cbo공장코드S.Name = "cbo공장코드S";
                  this.cbo공장코드S.ShowCheckBox = false;
                  this.cbo공장코드S.Size = new System.Drawing.Size(180, 20);
                  this.cbo공장코드S.TabIndex = 0;
                  this.cbo공장코드S.Tag = "CD_PLANT";
                  this.cbo공장코드S.UseKeyEnter = true;
                  this.cbo공장코드S.UseKeyF3 = true;
                  // 
                  // H_CZ_SM_PITEM_SUB
                  // 
                  this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
                  this.ClientSize = new System.Drawing.Size(784, 446);
                  this.Controls.Add(this.m_pnlSearch);
                  this.Controls.Add(this._bnCancel);
                  this.Controls.Add(this._bnOk);
                  this.Controls.Add(this._bnSearch);
                  this.Controls.Add(this.flex);
                  this.Name = "H_CZ_SM_PITEM_SUB";
                  this.TitleText = "아이템 도움창";
                  ((System.ComponentModel.ISupportInitialize)(this.closeButton)).EndInit();
                  ((System.ComponentModel.ISupportInitialize)(this.flex)).EndInit();
                  this.m_pnlSearch.ResumeLayout(false);
                  this.m_pnlSearch.PerformLayout();
                  this.panelExt2.ResumeLayout(false);
                  this.panel37.ResumeLayout(false);
                  this.panel36.ResumeLayout(false);
                  this.ResumeLayout(false);

        }

        #endregion

        protected Dass.FlexGridLight.FlexGrid flex;
        private Duzon.Common.Controls.RoundedButton _bnCancel;
        private Duzon.Common.Controls.RoundedButton _bnOk;
        private Duzon.Common.Controls.RoundedButton _bnSearch;
        private Duzon.Common.Controls.PanelExt m_pnlSearch;
        private Duzon.Common.BpControls.BpCodeTextBox bp예산계정s;
        private Duzon.Common.Controls.PanelExt panel39;
        private Duzon.Common.Controls.PanelExt panelExt2;
        private Duzon.Common.Controls.LabelExt lbl계정구분S;
        private Duzon.Common.Controls.DropDownComboBox cbo계정구분S;
        private Duzon.Common.Controls.TextBoxExt _txt검색;
        private Duzon.Common.Controls.PanelExt panel37;
        private Duzon.Common.Controls.LabelExt lbl아이템타입;
        private Duzon.Common.Controls.PanelExt panel36;
        private Duzon.Common.Controls.LabelExt lbl공장코드S;
        private Duzon.Common.Controls.LabelExt lbl검색S;
        private Duzon.Common.Controls.DropDownComboBox cbo공장코드S;
        private Duzon.Common.Controls.LabelExt lbl예산계정;
        private Duzon.Common.Controls.DropDownComboBox cbo품목타입S;
        private Duzon.Common.Controls.DropDownComboBox cbo아이템군;
        private Duzon.Common.Controls.LabelExt lbl아이템군;
    }
}