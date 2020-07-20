namespace cz
{
    partial class P_CZ_ME_SALES_GR
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(P_CZ_ME_SALES_GR));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new Duzon.Common.Controls.PanelExt();
            this.panelExt9 = new Duzon.Common.Controls.PanelExt();
            this.panelExt11 = new Duzon.Common.Controls.PanelExt();
            this.ctxMEDIAGR = new Duzon.Common.BpControls.BpCodeTextBox();
            this.cboMEDIAGR_GUBUN = new Duzon.Common.Controls.DropDownComboBox();
            this.panel7 = new Duzon.Common.Controls.PanelExt();
            this.labelExt1 = new Duzon.Common.Controls.LabelExt();
            this.panel6 = new Duzon.Common.Controls.PanelExt();
            this.lbl매체구분 = new Duzon.Common.Controls.LabelExt();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this._flexM = new Dass.FlexGrid.FlexGrid(this.components);
            this._flexD = new Dass.FlexGrid.FlexGrid(this.components);
            this.btn삭제 = new Duzon.Common.Controls.RoundedButton(this.components);
            this.btn추가 = new Duzon.Common.Controls.RoundedButton(this.components);
            this.mDataArea.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelExt9.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._flexM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._flexD)).BeginInit();
            this.SuspendLayout();
            // 
            // mDataArea
            // 
            this.mDataArea.Controls.Add(this.tableLayoutPanel1);
            this.mDataArea.Size = new System.Drawing.Size(1090, 756);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1090, 756);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panelExt9);
            this.panel1.Controls.Add(this.ctxMEDIAGR);
            this.panel1.Controls.Add(this.cboMEDIAGR_GUBUN);
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1084, 30);
            this.panel1.TabIndex = 1;
            // 
            // panelExt9
            // 
            this.panelExt9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelExt9.BackColor = System.Drawing.Color.Transparent;
            this.panelExt9.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelExt9.BackgroundImage")));
            this.panelExt9.Controls.Add(this.panelExt11);
            this.panelExt9.Font = new System.Drawing.Font("굴림", 9F);
            this.panelExt9.Location = new System.Drawing.Point(4, 29);
            this.panelExt9.Name = "panelExt9";
            this.panelExt9.Size = new System.Drawing.Size(1074, 1);
            this.panelExt9.TabIndex = 185;
            // 
            // panelExt11
            // 
            this.panelExt11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelExt11.BackColor = System.Drawing.Color.Transparent;
            this.panelExt11.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelExt11.BackgroundImage")));
            this.panelExt11.Font = new System.Drawing.Font("굴림", 9F);
            this.panelExt11.Location = new System.Drawing.Point(0, 24);
            this.panelExt11.Name = "panelExt11";
            this.panelExt11.Size = new System.Drawing.Size(1074, 1);
            this.panelExt11.TabIndex = 155;
            // 
            // ctxMEDIAGR
            // 
            this.ctxMEDIAGR.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ctxMEDIAGR.HelpID = Duzon.Common.Forms.Help.HelpID.P_MA_BIZAREA_SUB;
            this.ctxMEDIAGR.Location = new System.Drawing.Point(377, 4);
            this.ctxMEDIAGR.Name = "ctxMEDIAGR";
            this.ctxMEDIAGR.ResultMode = Duzon.Common.Forms.Help.ResultMode.SlowMode;
            this.ctxMEDIAGR.Size = new System.Drawing.Size(163, 21);
            this.ctxMEDIAGR.TabIndex = 1;
            this.ctxMEDIAGR.TabStop = false;
            this.ctxMEDIAGR.Tag = "CD_PARTNER;LN_PARTNER";
            this.ctxMEDIAGR.Visible = false;
            // 
            // cboMEDIAGR_GUBUN
            // 
            this.cboMEDIAGR_GUBUN.AutoDropDown = true;
            this.cboMEDIAGR_GUBUN.BackColor = System.Drawing.Color.White;
            this.cboMEDIAGR_GUBUN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMEDIAGR_GUBUN.Enabled = false;
            this.cboMEDIAGR_GUBUN.ItemHeight = 12;
            this.cboMEDIAGR_GUBUN.Location = new System.Drawing.Point(98, 3);
            this.cboMEDIAGR_GUBUN.Name = "cboMEDIAGR_GUBUN";
            this.cboMEDIAGR_GUBUN.Size = new System.Drawing.Size(187, 20);
            this.cboMEDIAGR_GUBUN.TabIndex = 0;
            this.cboMEDIAGR_GUBUN.UseKeyF3 = false;
            this.cboMEDIAGR_GUBUN.Visible = false;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.panel7.Controls.Add(this.labelExt1);
            this.panel7.Location = new System.Drawing.Point(293, 1);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(80, 27);
            this.panel7.TabIndex = 62;
            this.panel7.Visible = false;
            // 
            // labelExt1
            // 
            this.labelExt1.BackColor = System.Drawing.Color.Transparent;
            this.labelExt1.Location = new System.Drawing.Point(13, 5);
            this.labelExt1.Name = "labelExt1";
            this.labelExt1.Size = new System.Drawing.Size(60, 18);
            this.labelExt1.TabIndex = 55;
            this.labelExt1.Text = "매체";
            this.labelExt1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelExt1.Visible = false;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.panel6.Controls.Add(this.lbl매체구분);
            this.panel6.Location = new System.Drawing.Point(1, -1);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(91, 29);
            this.panel6.TabIndex = 61;
            this.panel6.Visible = false;
            // 
            // lbl매체구분
            // 
            this.lbl매체구분.BackColor = System.Drawing.Color.Transparent;
            this.lbl매체구분.Location = new System.Drawing.Point(27, 5);
            this.lbl매체구분.Name = "lbl매체구분";
            this.lbl매체구분.Size = new System.Drawing.Size(60, 18);
            this.lbl매체구분.TabIndex = 41;
            this.lbl매체구분.Text = "매체구분";
            this.lbl매체구분.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 39);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this._flexM);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this._flexD);
            this.splitContainer1.Size = new System.Drawing.Size(1084, 714);
            this.splitContainer1.SplitterDistance = 361;
            this.splitContainer1.TabIndex = 2;
            // 
            // _flexM
            // 
            this._flexM.AllowFreezing = C1.Win.C1FlexGrid.AllowFreezingEnum.Both;
            this._flexM.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Both;
            this._flexM.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.MultiColumn;
            this._flexM.AutoResize = false;
            this._flexM.ColumnInfo = "1,1,0,0,0,90,Columns:0{TextAlign:CenterCenter;TextAlignFixed:CenterCenter;}\t";
            this._flexM.Dock = System.Windows.Forms.DockStyle.Fill;
            this._flexM.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.OwnerDraw;
            this._flexM.EnabledHeaderCheck = true;
            this._flexM.Font = new System.Drawing.Font("굴림", 9F);
            this._flexM.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this._flexM.Location = new System.Drawing.Point(0, 0);
            this._flexM.Name = "_flexM";
            this._flexM.Rows.Count = 1;
            this._flexM.Rows.DefaultSize = 18;
            this._flexM.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this._flexM.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.Always;
            this._flexM.ShowSort = false;
            this._flexM.Size = new System.Drawing.Size(361, 714);
            this._flexM.StyleInfo = resources.GetString("_flexM.StyleInfo");
            this._flexM.TabIndex = 1;
            this._flexM.UseGridCalculator = true;
            this._flexM.BeforeRowChange += new C1.Win.C1FlexGrid.RangeEventHandler(this._flexM_BeforeRowChange);
            // 
            // _flexD
            // 
            this._flexD.AllowFreezing = C1.Win.C1FlexGrid.AllowFreezingEnum.Both;
            this._flexD.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Both;
            this._flexD.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.MultiColumn;
            this._flexD.AutoResize = false;
            this._flexD.ColumnInfo = "1,1,0,0,0,90,Columns:0{TextAlign:CenterCenter;TextAlignFixed:CenterCenter;}\t";
            this._flexD.Dock = System.Windows.Forms.DockStyle.Fill;
            this._flexD.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.OwnerDraw;
            this._flexD.EnabledHeaderCheck = true;
            this._flexD.Font = new System.Drawing.Font("굴림", 9F);
            this._flexD.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this._flexD.Location = new System.Drawing.Point(0, 0);
            this._flexD.Name = "_flexD";
            this._flexD.Rows.Count = 1;
            this._flexD.Rows.DefaultSize = 18;
            this._flexD.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this._flexD.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.Always;
            this._flexD.ShowSort = false;
            this._flexD.Size = new System.Drawing.Size(719, 714);
            this._flexD.StyleInfo = resources.GetString("_flexD.StyleInfo");
            this._flexD.TabIndex = 2;
            this._flexD.UseGridCalculator = true;
            this._flexD.AfterCodeHelp += new Dass.FlexGrid.AfterCodeHelpEventHandler(this._flexD_AfterCodeHelp);
            this._flexD.DoubleClick += new System.EventHandler(this._flexD_DoubleClick);
            // 
            // btn삭제
            // 
            this.btn삭제.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn삭제.BackColor = System.Drawing.Color.White;
            this.btn삭제.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn삭제.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn삭제.Location = new System.Drawing.Point(1029, 13);
            this.btn삭제.MaximumSize = new System.Drawing.Size(0, 19);
            this.btn삭제.Name = "btn삭제";
            this.btn삭제.Size = new System.Drawing.Size(60, 19);
            this.btn삭제.TabIndex = 6;
            this.btn삭제.TabStop = false;
            this.btn삭제.Text = "삭제";
            this.btn삭제.UseVisualStyleBackColor = false;
            this.btn삭제.Click += new System.EventHandler(this.btn삭제_Click_1);
            // 
            // btn추가
            // 
            this.btn추가.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn추가.BackColor = System.Drawing.Color.White;
            this.btn추가.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn추가.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn추가.Location = new System.Drawing.Point(962, 13);
            this.btn추가.MaximumSize = new System.Drawing.Size(0, 19);
            this.btn추가.Name = "btn추가";
            this.btn추가.Size = new System.Drawing.Size(60, 19);
            this.btn추가.TabIndex = 5;
            this.btn추가.TabStop = false;
            this.btn추가.Text = "추가";
            this.btn추가.UseVisualStyleBackColor = false;
            this.btn추가.Click += new System.EventHandler(this.btn추가_Click_1);
            // 
            // P_CZ_ME_SALES_GR
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.btn삭제);
            this.Controls.Add(this.btn추가);
            this.Name = "P_CZ_ME_SALES_GR";
            this.Size = new System.Drawing.Size(1090, 796);
            this.TitleText = "매체구분등록";
            this.Controls.SetChildIndex(this.mDataArea, 0);
            this.Controls.SetChildIndex(this.btn추가, 0);
            this.Controls.SetChildIndex(this.btn삭제, 0);
            this.mDataArea.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panelExt9.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._flexM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._flexD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Duzon.Common.Controls.PanelExt panel1;
        private Duzon.Common.BpControls.BpCodeTextBox ctxMEDIAGR;
        private Duzon.Common.Controls.DropDownComboBox cboMEDIAGR_GUBUN;
        private Duzon.Common.Controls.PanelExt panel7;
        private Duzon.Common.Controls.LabelExt labelExt1;
        private Duzon.Common.Controls.PanelExt panel6;
        private Duzon.Common.Controls.LabelExt lbl매체구분;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Dass.FlexGrid.FlexGrid _flexM;
        private Duzon.Common.Controls.PanelExt panelExt9;
        private Duzon.Common.Controls.PanelExt panelExt11;
        private Duzon.Common.Controls.RoundedButton btn삭제;
        private Duzon.Common.Controls.RoundedButton btn추가;
        private Dass.FlexGrid.FlexGrid _flexD;

    }
}
