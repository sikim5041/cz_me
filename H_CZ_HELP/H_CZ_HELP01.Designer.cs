namespace cz
{
    partial class H_CZ_HELP01
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(H_CZ_HELP01));
            this.flex = new Dass.FlexGridLight.FlexGrid(this.components);
            this.panelExt1 = new Duzon.Common.Controls.PanelExt();
            this._txt검색 = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this._bnCancel = new Duzon.Common.Controls.RoundedButton(this.components);
            this._bnOk = new Duzon.Common.Controls.RoundedButton(this.components);
            this._bnSearch = new Duzon.Common.Controls.RoundedButton(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.closeButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.flex)).BeginInit();
            this.panelExt1.SuspendLayout();
            this.panel5.SuspendLayout();
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
            this.flex.Location = new System.Drawing.Point(6, 112);
            this.flex.Name = "flex";
            this.flex.Rows.Count = 1;
            this.flex.Rows.DefaultSize = 18;
            this.flex.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this.flex.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.Always;
            this.flex.ShowSort = false;
            this.flex.Size = new System.Drawing.Size(662, 357);
            this.flex.StyleInfo = resources.GetString("flex.StyleInfo");
            this.flex.TabIndex = 27;
            // 
            // panelExt1
            // 
            this.panelExt1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelExt1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelExt1.Controls.Add(this._txt검색);
            this.panelExt1.Controls.Add(this.panel5);
            this.panelExt1.Location = new System.Drawing.Point(6, 53);
            this.panelExt1.Name = "panelExt1";
            this.panelExt1.Size = new System.Drawing.Size(662, 28);
            this.panelExt1.TabIndex = 34;
            // 
            // _txt검색
            // 
            this._txt검색.Location = new System.Drawing.Point(89, 3);
            this._txt검색.Name = "_txt검색";
            this._txt검색.Size = new System.Drawing.Size(566, 21);
            this._txt검색.TabIndex = 16;
            this._txt검색.KeyDown += new System.Windows.Forms.KeyEventHandler(this._txtSearch_KeyDown);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(254)))), ((int)(((byte)(177)))));
            this.panel5.Controls.Add(this.label2);
            this.panel5.Location = new System.Drawing.Point(-1, -1);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(86, 28);
            this.panel5.TabIndex = 32;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(51, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 26;
            this.label2.Text = "검색";
            // 
            // _bnCancel
            // 
            this._bnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._bnCancel.BackColor = System.Drawing.Color.White;
            this._bnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this._bnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._bnCancel.Location = new System.Drawing.Point(607, 87);
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
            this._bnOk.Location = new System.Drawing.Point(545, 87);
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
            this._bnSearch.Location = new System.Drawing.Point(482, 87);
            this._bnSearch.MaximumSize = new System.Drawing.Size(0, 19);
            this._bnSearch.Name = "_bnSearch";
            this._bnSearch.Size = new System.Drawing.Size(61, 19);
            this._bnSearch.TabIndex = 31;
            this._bnSearch.TabStop = false;
            this._bnSearch.Text = "검색";
            this._bnSearch.UseVisualStyleBackColor = true;
            // 
            // H_CZ_HELP01
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(674, 476);
            this.Controls.Add(this.panelExt1);
            this.Controls.Add(this._bnCancel);
            this.Controls.Add(this._bnOk);
            this.Controls.Add(this._bnSearch);
            this.Controls.Add(this.flex);
            this.Name = "H_CZ_HELP01";
            this.Text = "ERP iU";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.closeButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.flex)).EndInit();
            this.panelExt1.ResumeLayout(false);
            this.panelExt1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected Dass.FlexGridLight.FlexGrid flex;
        private Duzon.Common.Controls.PanelExt panelExt1;
        private System.Windows.Forms.TextBox _txt검색;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label2;
        private Duzon.Common.Controls.RoundedButton _bnCancel;
        private Duzon.Common.Controls.RoundedButton _bnOk;
        private Duzon.Common.Controls.RoundedButton _bnSearch;
    }
}