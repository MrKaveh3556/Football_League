
namespace Football_League
{
    partial class ShowAll_Form
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
            this.table_TeamsDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.table_TeamsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.footBall_LeagueDataSet = new Football_League.FootBall_LeagueDataSet();
            this.table_TeamsTableAdapter = new Football_League.FootBall_LeagueDataSetTableAdapters.Table_TeamsTableAdapter();
            this.tableAdapterManager = new Football_League.FootBall_LeagueDataSetTableAdapters.TableAdapterManager();
            ((System.ComponentModel.ISupportInitialize)(this.table_TeamsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.table_TeamsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.footBall_LeagueDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // table_TeamsDataGridView
            // 
            this.table_TeamsDataGridView.AllowUserToAddRows = false;
            this.table_TeamsDataGridView.AllowUserToDeleteRows = false;
            this.table_TeamsDataGridView.AllowUserToResizeColumns = false;
            this.table_TeamsDataGridView.AllowUserToResizeRows = false;
            this.table_TeamsDataGridView.AutoGenerateColumns = false;
            this.table_TeamsDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.table_TeamsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.table_TeamsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9});
            this.table_TeamsDataGridView.Cursor = System.Windows.Forms.Cursors.No;
            this.table_TeamsDataGridView.DataSource = this.table_TeamsBindingSource;
            this.table_TeamsDataGridView.Location = new System.Drawing.Point(12, 12);
            this.table_TeamsDataGridView.Name = "table_TeamsDataGridView";
            this.table_TeamsDataGridView.ReadOnly = true;
            this.table_TeamsDataGridView.Size = new System.Drawing.Size(956, 426);
            this.table_TeamsDataGridView.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Team_Name";
            this.dataGridViewTextBoxColumn1.HeaderText = "Team_Name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Tedad_Bazi";
            this.dataGridViewTextBoxColumn2.HeaderText = "Tedad_Bazi";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Win";
            this.dataGridViewTextBoxColumn3.HeaderText = "Win";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Draw";
            this.dataGridViewTextBoxColumn4.HeaderText = "Draw";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Lose";
            this.dataGridViewTextBoxColumn5.HeaderText = "Lose";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Point";
            this.dataGridViewTextBoxColumn6.HeaderText = "Point";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Goal_Zadeh";
            this.dataGridViewTextBoxColumn7.HeaderText = "Goal_Zadeh";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Goal_Khordeh";
            this.dataGridViewTextBoxColumn8.HeaderText = "Goal_Khordeh";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Tafazol";
            this.dataGridViewTextBoxColumn9.HeaderText = "Tafazol";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // table_TeamsBindingSource
            // 
            this.table_TeamsBindingSource.DataMember = "Table_Teams";
            this.table_TeamsBindingSource.DataSource = this.footBall_LeagueDataSet;
            // 
            // footBall_LeagueDataSet
            // 
            this.footBall_LeagueDataSet.DataSetName = "FootBall_LeagueDataSet";
            this.footBall_LeagueDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // table_TeamsTableAdapter
            // 
            this.table_TeamsTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Table_TeamsTableAdapter = this.table_TeamsTableAdapter;
            this.tableAdapterManager.UpdateOrder = Football_League.FootBall_LeagueDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // ShowAll_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(980, 538);
            this.Controls.Add(this.table_TeamsDataGridView);
            this.MaximizeBox = false;
            this.Name = "ShowAll_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ShowAll_Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ShowAll_Form_FormClosing);
            this.Load += new System.EventHandler(this.ShowAll_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.table_TeamsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.table_TeamsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.footBall_LeagueDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FootBall_LeagueDataSet footBall_LeagueDataSet;
        private System.Windows.Forms.BindingSource table_TeamsBindingSource;
        private FootBall_LeagueDataSetTableAdapters.Table_TeamsTableAdapter table_TeamsTableAdapter;
        private FootBall_LeagueDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridView table_TeamsDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
    }
}