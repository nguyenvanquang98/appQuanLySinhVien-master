namespace QuanLySinhVien
{
    partial class ManagerClass
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
            this.lbMaLop = new System.Windows.Forms.Label();
            this.lbNameClass = new System.Windows.Forms.Label();
            this.txtMaLop = new System.Windows.Forms.TextBox();
            this.txtNameClass = new System.Windows.Forms.TextBox();
            this.btnAddClass = new System.Windows.Forms.Button();
            this.btnEditClass = new System.Windows.Forms.Button();
            this.btnDelClass = new System.Windows.Forms.Button();
            this.gvClass = new System.Windows.Forms.DataGridView();
            this.lopBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quanLySinhVienDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnList = new System.Windows.Forms.Button();
            this.gbAction = new System.Windows.Forms.GroupBox();
            this.btn_exit = new System.Windows.Forms.Button();
            this.gbInfoClass = new System.Windows.Forms.GroupBox();
            this.gbListClass = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.gvClass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lopBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLySinhVienDataSetBindingSource)).BeginInit();
            this.gbAction.SuspendLayout();
            this.gbInfoClass.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbMaLop
            // 
            this.lbMaLop.AutoSize = true;
            this.lbMaLop.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbMaLop.Location = new System.Drawing.Point(11, 30);
            this.lbMaLop.Name = "lbMaLop";
            this.lbMaLop.Size = new System.Drawing.Size(67, 21);
            this.lbMaLop.TabIndex = 1;
            this.lbMaLop.Text = "Mã lớp:";
            // 
            // lbNameClass
            // 
            this.lbNameClass.AutoSize = true;
            this.lbNameClass.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbNameClass.Location = new System.Drawing.Point(6, 67);
            this.lbNameClass.Name = "lbNameClass";
            this.lbNameClass.Size = new System.Drawing.Size(72, 21);
            this.lbNameClass.TabIndex = 2;
            this.lbNameClass.Text = "Tên lớp:";
            // 
            // txtMaLop
            // 
            this.txtMaLop.Location = new System.Drawing.Point(94, 30);
            this.txtMaLop.Name = "txtMaLop";
            this.txtMaLop.Size = new System.Drawing.Size(262, 22);
            this.txtMaLop.TabIndex = 5;
            // 
            // txtNameClass
            // 
            this.txtNameClass.Location = new System.Drawing.Point(94, 67);
            this.txtNameClass.Name = "txtNameClass";
            this.txtNameClass.Size = new System.Drawing.Size(262, 22);
            this.txtNameClass.TabIndex = 7;
            this.txtNameClass.TextChanged += new System.EventHandler(this.txtNameClass_TextChanged);
            // 
            // btnAddClass
            // 
            this.btnAddClass.Location = new System.Drawing.Point(28, 39);
            this.btnAddClass.Name = "btnAddClass";
            this.btnAddClass.Size = new System.Drawing.Size(201, 34);
            this.btnAddClass.TabIndex = 9;
            this.btnAddClass.Text = "Thêm lớp";
            this.btnAddClass.UseVisualStyleBackColor = true;
            this.btnAddClass.Click += new System.EventHandler(this.btnAddClass_Click);
            // 
            // btnEditClass
            // 
            this.btnEditClass.Location = new System.Drawing.Point(530, 145);
            this.btnEditClass.Name = "btnEditClass";
            this.btnEditClass.Size = new System.Drawing.Size(201, 34);
            this.btnEditClass.TabIndex = 10;
            this.btnEditClass.Text = "Sửa tên lớp";
            this.btnEditClass.UseVisualStyleBackColor = true;
            this.btnEditClass.Click += new System.EventHandler(this.btnEditClass_Click);
            // 
            // btnDelClass
            // 
            this.btnDelClass.Location = new System.Drawing.Point(28, 192);
            this.btnDelClass.Name = "btnDelClass";
            this.btnDelClass.Size = new System.Drawing.Size(201, 34);
            this.btnDelClass.TabIndex = 11;
            this.btnDelClass.Text = "Xóa lớp";
            this.btnDelClass.UseVisualStyleBackColor = true;
            this.btnDelClass.Click += new System.EventHandler(this.btnDelClass_Click);
            // 
            // gvClass
            // 
            this.gvClass.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gvClass.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvClass.Location = new System.Drawing.Point(35, 254);
            this.gvClass.Name = "gvClass";
            this.gvClass.RowHeadersWidth = 51;
            this.gvClass.RowTemplate.Height = 24;
            this.gvClass.Size = new System.Drawing.Size(407, 166);
            this.gvClass.TabIndex = 12;
            this.gvClass.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnList
            // 
            this.btnList.Location = new System.Drawing.Point(28, 269);
            this.btnList.Name = "btnList";
            this.btnList.Size = new System.Drawing.Size(201, 34);
            this.btnList.TabIndex = 13;
            this.btnList.Text = "Hiển thị danh sách sinh viên";
            this.btnList.UseVisualStyleBackColor = true;
            this.btnList.Click += new System.EventHandler(this.btnList_Click);
            // 
            // gbAction
            // 
            this.gbAction.Controls.Add(this.btn_exit);
            this.gbAction.Controls.Add(this.btnList);
            this.gbAction.Controls.Add(this.btnDelClass);
            this.gbAction.Controls.Add(this.btnAddClass);
            this.gbAction.Location = new System.Drawing.Point(502, 28);
            this.gbAction.Name = "gbAction";
            this.gbAction.Size = new System.Drawing.Size(265, 548);
            this.gbAction.TabIndex = 14;
            this.gbAction.TabStop = false;
            this.gbAction.Text = "Thao tác";
            this.gbAction.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(28, 347);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(201, 30);
            this.btn_exit.TabIndex = 14;
            this.btn_exit.Text = "Thoát";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // gbInfoClass
            // 
            this.gbInfoClass.Controls.Add(this.lbNameClass);
            this.gbInfoClass.Controls.Add(this.lbMaLop);
            this.gbInfoClass.Controls.Add(this.txtNameClass);
            this.gbInfoClass.Controls.Add(this.txtMaLop);
            this.gbInfoClass.Location = new System.Drawing.Point(23, 28);
            this.gbInfoClass.Name = "gbInfoClass";
            this.gbInfoClass.Size = new System.Drawing.Size(435, 104);
            this.gbInfoClass.TabIndex = 15;
            this.gbInfoClass.TabStop = false;
            this.gbInfoClass.Text = "Thông tin";
            // 
            // gbListClass
            // 
            this.gbListClass.Location = new System.Drawing.Point(23, 220);
            this.gbListClass.Name = "gbListClass";
            this.gbListClass.Size = new System.Drawing.Size(435, 356);
            this.gbListClass.TabIndex = 15;
            this.gbListClass.TabStop = false;
            this.gbListClass.Text = "Danh sách lớp";
            // 
            // ManagerClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 607);
            this.Controls.Add(this.gvClass);
            this.Controls.Add(this.btnEditClass);
            this.Controls.Add(this.gbAction);
            this.Controls.Add(this.gbInfoClass);
            this.Controls.Add(this.gbListClass);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ManagerClass";
            this.Text = "ManagerClass";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ManagerClass_FormClosed);
            this.Load += new System.EventHandler(this.ManagerClass_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvClass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lopBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLySinhVienDataSetBindingSource)).EndInit();
            this.gbAction.ResumeLayout(false);
            this.gbInfoClass.ResumeLayout(false);
            this.gbInfoClass.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbMaLop;
        private System.Windows.Forms.Label lbNameClass;
        private System.Windows.Forms.TextBox txtMaLop;
        private System.Windows.Forms.TextBox txtNameClass;
        private System.Windows.Forms.Button btnAddClass;
        private System.Windows.Forms.Button btnEditClass;
        private System.Windows.Forms.Button btnDelClass;
        private System.Windows.Forms.DataGridView gvClass;
        private System.Windows.Forms.BindingSource quanLySinhVienDataSetBindingSource;

        private System.Windows.Forms.BindingSource lopBindingSource;

        private System.Windows.Forms.Button btnList;
        private System.Windows.Forms.GroupBox gbAction;
        private System.Windows.Forms.GroupBox gbInfoClass;
        private System.Windows.Forms.GroupBox gbListClass;
        private System.Windows.Forms.Button btn_exit;
    }
}