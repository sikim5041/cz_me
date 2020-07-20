namespace cz
{
    partial class H_CZ_PARTNER_SUB
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(H_CZ_CARD_SUB));
            this.panelExt1 = new Duzon.Common.Controls.PanelExt();
            this.cbo사용여부 = new Duzon.Common.Controls.DropDownComboBox();
            this.cbo미수금액반영여부 = new Duzon.Common.Controls.DropDownComboBox();
            this.panelExt2 = new Duzon.Common.Controls.PanelExt();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txt검색 = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn취소 = new Duzon.Common.Controls.RoundedButton(this.components);
            this.btn확인 = new Duzon.Common.Controls.RoundedButton(this.components);
            this.btn검색 = new Duzon.Common.Controls.RoundedButton(this.components);
            this.flex = new Dass.FlexGridLight.FlexGrid(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.closeButton)).BeginInit();
            this.panelExt1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flex)).BeginInit();
            this.SuspendLayout();
            // 
            // panelExt1
            // 
            this.panelExt1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelExt1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelExt1.Controls.Add(this.cbo사용여부);
            this.panelExt1.Controls.Add(this.cbo미수금액반영여부);
            this.panelExt1.Controls.Add(this.panelExt2);
            this.panelExt1.Controls.Add(this.panel2);
            this.panelExt1.Controls.Add(this.txt검색);
            this.panelExt1.Controls.Add(this.panel5);
            this.panelExt1.Location = new System.Drawing.Point(7, 52);
            this.panelExt1.Name = "panelExt1";
            this.panelExt1.Size = new System.Drawing.Size(763, 58);
            this.panelExt1.TabIndex = 41;
            // 
            // cbo사용여부
            // 
            this.cbo사용여부.AutoDropDown = true;
            this.cbo사용여부.BackColor = System.Drawing.Color.White;
            this.cbo사용여부.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo사용여부.ItemHeight = 12;
            this.cbo사용여부.Location = new System.Drawing.Point(486, 5);
            this.cbo사용여부.Name = "cbo사용여부";
            this.cbo사용여부.ShowCheckBox = false;
            this.cbo사용여부.Size = new System.Drawing.Size(255, 20);
            this.cbo사용여부.TabIndex = 1;
            this.cbo사용여부.UseKeyEnter = true;
            this.cbo사용여부.UseKeyF3 = true;
            // 
            // cbo미수금액반영여부
            // 
            this.cbo미수금액반영여부.AutoDropDown = true;
            this.cbo미수금액반영여부.BackColor = System.Drawing.Color.White;
            this.cbo미수금액반영여부.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo미수금액반영여부.ItemHeight = 12;
            this.cbo미수금액반영여부.Location = new System.Drawing.Point(122, 5);
            this.cbo미수금액반영여부.Name = "cbo미수금액반영여부";
            this.cbo미수금액반영여부.ShowCheckBox = false;
            this.cbo미수금액반영여부.Size = new System.Drawing.Size(255, 20);
            this.cbo미수금액반영여부.TabIndex = 0;
            this.cbo미수금액반영여부.UseKeyEnter = true;
            this.cbo미수금액반영여부.UseKeyF3 = true;
            // 
            // panelExt2
            // 
            this.panelExt2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelExt2.BackColor = System.Drawing.Color.Transparent;
            this.panelExt2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelExt2.BackgroundImage")));
            this.panelExt2.Location = new System.Drawing.Point(1, 29);
            this.panelExt2.Name = "panelExt2";
            this.panelExt2.Size = new System.Drawing.Size(1183, 1);
            this.panelExt2.TabIndex = 96;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(254)))), ((int)(((byte)(177)))));
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(395, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(86, 27);
            this.panel2.TabIndex = 97;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(30, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 27;
            this.label3.Text = "사용여부";
            // 
            // txt검색
            // 
            this.txt검색.Location = new System.Drawing.Point(122, 32);
            this.txt검색.Name = "txt검색";
            this.txt검색.Size = new System.Drawing.Size(619, 21);
            this.txt검색.TabIndex = 2;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(254)))), ((int)(((byte)(177)))));
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Location = new System.Drawing.Point(1, 1);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(116, 54);
            this.panel5.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 27;
            this.label1.Text = "미수금액반영여부";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(83, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 26;
            this.label2.Text = "검색";
            // 
            // btn취소
            // 
            this.btn취소.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn취소.BackColor = System.Drawing.Color.White;
            this.btn취소.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn취소.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn취소.Location = new System.Drawing.Point(709, 114);
            this.btn취소.MaximumSize = new System.Drawing.Size(0, 19);
            this.btn취소.Name = "btn취소";
            this.btn취소.Size = new System.Drawing.Size(61, 19);
            this.btn취소.TabIndex = 44;
            this.btn취소.TabStop = false;
            this.btn취소.Text = "취소";
            this.btn취소.UseVisualStyleBackColor = true;
            // 
            // btn확인
            // 
            this.btn확인.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn확인.BackColor = System.Drawing.Color.White;
            this.btn확인.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn확인.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn확인.Location = new System.Drawing.Point(645, 114);
            this.btn확인.MaximumSize = new System.Drawing.Size(0, 19);
            this.btn확인.Name = "btn확인";
            this.btn확인.Size = new System.Drawing.Size(61, 19);
            this.btn확인.TabIndex = 43;
            this.btn확인.TabStop = false;
            this.btn확인.Text = "확인";
            this.btn확인.UseVisualStyleBackColor = true;
            // 
            // btn검색
            // 
            this.btn검색.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn검색.BackColor = System.Drawing.Color.White;
            this.btn검색.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn검색.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn검색.Location = new System.Drawing.Point(581, 114);
            this.btn검색.MaximumSize = new System.Drawing.Size(0, 19);
            this.btn검색.Name = "btn검색";
            this.btn검색.Size = new System.Drawing.Size(61, 19);
            this.btn검색.TabIndex = 42;
            this.btn검색.TabStop = false;
            this.btn검색.Text = "검색";
            this.btn검색.UseVisualStyleBackColor = true;
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
            this.flex.Location = new System.Drawing.Point(7, 137);
            this.flex.Name = "flex";
            this.flex.Rows.Count = 1;
            this.flex.Rows.DefaultSize = 18;
            this.flex.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this.flex.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.Always;
            this.flex.ShowSort = false;
            this.flex.Size = new System.Drawing.Size(763, 331);
            this.flex.StyleInfo = resources.GetString("flex.StyleInfo");
            this.flex.TabIndex = 45;
            // 
            // H_CZ_CARD_SUB
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(776, 475);
            this.Controls.Add(this.flex);
            this.Controls.Add(this.btn취소);
            this.Controls.Add(this.btn확인);
            this.Controls.Add(this.btn검색);
            this.Controls.Add(this.panelExt1);
            this.MaximizeBox = false;
            this.Name = "H_CZ_CARD_SUB";
            this.TitleText = "매출처 도움창";
            ((System.ComponentModel.ISupportInitialize)(this.closeButton)).EndInit();
            this.panelExt1.ResumeLayout(false);
            this.panelExt1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flex)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Duzon.Common.Controls.PanelExt panelExt1;
        private Duzon.Common.Controls.DropDownComboBox cbo사용여부;
        private Duzon.Common.Controls.DropDownComboBox cbo미수금액반영여부;
        private Duzon.Common.Controls.PanelExt panelExt2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt검색;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Duzon.Common.Controls.RoundedButton btn취소;
        private Duzon.Common.Controls.RoundedButton btn확인;
        private Duzon.Common.Controls.RoundedButton btn검색;
        protected Dass.FlexGridLight.FlexGrid flex;
    }
}