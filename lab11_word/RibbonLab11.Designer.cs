using Microsoft.Office.Tools.Ribbon;
using System;

namespace lab11_word
{
    partial class RibbonLab11 : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public RibbonLab11()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tab1 = this.Factory.CreateRibbonTab();
            this.lab1 = this.Factory.CreateRibbonGroup();
            this.processLab1Button = this.Factory.CreateRibbonButton();
            this.processLab2Button = this.Factory.CreateRibbonButton();
            this.processLab3Button = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.lab1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.lab1);
            this.tab1.Label = "TabAddIns";
            this.tab1.Name = "tab1";
            // 
            // lab1
            // 
            this.lab1.Items.Add(this.processLab1Button);
            this.lab1.Items.Add(this.processLab2Button);
            this.lab1.Items.Add(this.processLab3Button);
            this.lab1.Label = "Lab Functions";
            this.lab1.Name = "lab1";
            // 
            // processLab1Button
            // 
            this.processLab1Button.Label = "Process Lab 1";
            this.processLab1Button.Name = "processLab1Button";
            this.processLab1Button.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.ProcessLab1Button_Click);
            // 
            // processLab2Button
            // 
            this.processLab2Button.Label = "Process Lab 2";
            this.processLab2Button.Name = "processLab2Button";
            this.processLab2Button.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.ProcessLab2Button_Click);
            // 
            // processLab3Button
            // 
            this.processLab3Button.Label = "Process Lab 3";
            this.processLab3Button.Name = "processLab3Button";
            this.processLab3Button.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.ProcessLab3Button_Click);
            // 
            // RibbonLab11
            // 
            this.Name = "RibbonLab11";
            this.RibbonType = "Microsoft.Word.Document";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.RibbonLab11_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.lab1.ResumeLayout(false);
            this.lab1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup lab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton processLab1Button;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton processLab2Button;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton processLab3Button;

        // Event handlers for each button click
        private void ProcessLab1Button_Click(object sender, Microsoft.Office.Tools.Ribbon.RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.LoadLabContent(1);  // Pass lab number 1
        }

        private void ProcessLab2Button_Click(object sender, Microsoft.Office.Tools.Ribbon.RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.LoadLabContent(2);  // Pass lab number 2
        }

        private void ProcessLab3Button_Click(object sender, Microsoft.Office.Tools.Ribbon.RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.LoadLabContent(3);  // Pass lab number 3
        }
    }

    partial class ThisRibbonCollection
    {
        internal RibbonLab11 RibbonLab11
        {
            get { return this.GetRibbon<RibbonLab11>(); }
        }
    }
}
