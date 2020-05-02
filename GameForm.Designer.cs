namespace CourseWork
{
    partial class GameForm
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
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.moveDownTimer = new System.Windows.Forms.Timer(this.components);
            this.scoreLabel = new System.Windows.Forms.Label();
            this.timerForDestrou = new System.Windows.Forms.Timer(this.components);
            this.levelLabel = new System.Windows.Forms.Label();
            this.gameoverLabel = new System.Windows.Forms.Label();
            this.timerForMoveLeftRight = new System.Windows.Forms.Timer(this.components);
            this.labelInstryction = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelR = new System.Windows.Forms.Label();
            this.labelScore = new System.Windows.Forms.Label();
            this.labelLevel = new System.Windows.Forms.Label();
            this.MenuOfForm = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuOfForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Enabled = true;
            // 
            // moveDownTimer
            // 
            this.moveDownTimer.Interval = 500;
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.BackColor = System.Drawing.Color.White;
            this.scoreLabel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.scoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.scoreLabel.Location = new System.Drawing.Point(139, 71);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(24, 25);
            this.scoreLabel.TabIndex = 1;
            this.scoreLabel.Text = "0";
            // 
            // timerForDestrou
            // 
            this.timerForDestrou.Interval = 300;
            // 
            // levelLabel
            // 
            this.levelLabel.AutoSize = true;
            this.levelLabel.BackColor = System.Drawing.Color.White;
            this.levelLabel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.levelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.levelLabel.Location = new System.Drawing.Point(139, 131);
            this.levelLabel.Name = "levelLabel";
            this.levelLabel.Size = new System.Drawing.Size(24, 25);
            this.levelLabel.TabIndex = 1;
            this.levelLabel.Text = "1";
            // 
            // gameoverLabel
            // 
            this.gameoverLabel.BackColor = System.Drawing.Color.White;
            this.gameoverLabel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gameoverLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.gameoverLabel.Location = new System.Drawing.Point(68, 106);
            this.gameoverLabel.Name = "gameoverLabel";
            this.gameoverLabel.Size = new System.Drawing.Size(135, 25);
            this.gameoverLabel.TabIndex = 1;
            this.gameoverLabel.Text = "GAMEOVER";
            this.gameoverLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelInstryction
            // 
            this.labelInstryction.AutoSize = true;
            this.labelInstryction.BackColor = System.Drawing.Color.White;
            this.labelInstryction.Location = new System.Drawing.Point(3, 54);
            this.labelInstryction.Name = "labelInstryction";
            this.labelInstryction.Size = new System.Drawing.Size(79, 52);
            this.labelInstryction.TabIndex = 2;
            this.labelInstryction.Text = "← Move left\r\n→ Move right\r\n↑ Scroll colours\r\n↓ Move down\r\n";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(2, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 2;
            // 
            // labelR
            // 
            this.labelR.AutoSize = true;
            this.labelR.BackColor = System.Drawing.Color.White;
            this.labelR.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelR.Location = new System.Drawing.Point(2, 144);
            this.labelR.Name = "labelR";
            this.labelR.Size = new System.Drawing.Size(78, 39);
            this.labelR.TabIndex = 2;
            this.labelR.Text = "\"R\" can make \r\nhorizontal \r\nnext figure";
            // 
            // labelScore
            // 
            this.labelScore.AutoSize = true;
            this.labelScore.Location = new System.Drawing.Point(206, 144);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(35, 13);
            this.labelScore.TabIndex = 3;
            this.labelScore.Text = "Score";
            // 
            // labelLevel
            // 
            this.labelLevel.AutoSize = true;
            this.labelLevel.Location = new System.Drawing.Point(208, 186);
            this.labelLevel.Name = "labelLevel";
            this.labelLevel.Size = new System.Drawing.Size(33, 13);
            this.labelLevel.TabIndex = 3;
            this.labelLevel.Text = "Level";
            // 
            // MenuOfForm
            // 
            this.MenuOfForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.MenuOfForm.Location = new System.Drawing.Point(0, 0);
            this.MenuOfForm.Name = "MenuOfForm";
            this.MenuOfForm.Size = new System.Drawing.Size(284, 24);
            this.MenuOfForm.TabIndex = 4;
            this.MenuOfForm.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pauseToolStripMenuItem,
            this.restartToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(50, 20);
            this.toolStripMenuItem1.Text = "&Game";
            // 
            // pauseToolStripMenuItem
            // 
            this.pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
            this.pauseToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.pauseToolStripMenuItem.Text = "&Pause";
            // 
            // restartToolStripMenuItem
            // 
            this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            this.restartToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.restartToolStripMenuItem.Text = "&Restart";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.labelLevel);
            this.Controls.Add(this.labelScore);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelR);
            this.Controls.Add(this.labelInstryction);
            this.Controls.Add(this.levelLabel);
            this.Controls.Add(this.gameoverLabel);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.MenuOfForm);
            this.MainMenuStrip = this.MenuOfForm;
            this.Name = "GameForm";
            this.RightToLeftLayout = true;
            this.Text = " ";
            this.MenuOfForm.ResumeLayout(false);
            this.MenuOfForm.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Timer moveDownTimer;
        private System.Windows.Forms.Timer timerForDestrou;
        public System.Windows.Forms.Label scoreLabel;
        public System.Windows.Forms.Label levelLabel;
        public System.Windows.Forms.Label gameoverLabel;
        private System.Windows.Forms.Timer timerForMoveLeftRight;
        private System.Windows.Forms.Label labelInstryction;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelR;
        private System.Windows.Forms.Label labelScore;
        private System.Windows.Forms.Label labelLevel;
        private System.Windows.Forms.MenuStrip MenuOfForm;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pauseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;

    }
}

