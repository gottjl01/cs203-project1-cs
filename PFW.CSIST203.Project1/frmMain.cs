using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PFW.CSIST203.Project1
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private PFW.CSIST203.Project1.Functions.MathFunctions mathFunctions;
        private PFW.CSIST203.Project1.Functions.ArrayFunctions arrayFunctions;

        private void FrmMain_Load(object sender, EventArgs e)
        {
            mathFunctions = new PFW.CSIST203.Project1.Functions.MathFunctions();
            arrayFunctions = new PFW.CSIST203.Project1.Functions.ArrayFunctions();
            log4net.Config.XmlConfigurator.ConfigureAndWatch(new System.IO.FileInfo(System.AppDomain.CurrentDomain.SetupInformation.ConfigurationFile));
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            lblOperator.Text = "+";
            txtResultant.Text = mathFunctions.Add(txtValue1.Text, txtValue2.Text);
        }

        private void BtnSubtract_Click(object sender, EventArgs e)
        {
            lblOperator.Text = "-";
            txtResultant.Text = mathFunctions.Subtract(txtValue1.Text, txtValue2.Text);
        }

        private void BtnMultiply_Click(object sender, EventArgs e)
        {
            lblOperator.Text = "*";
            txtResultant.Text = mathFunctions.Multiply(txtValue1.Text, txtValue2.Text);
        }

        private void BtnDivide_Click(object sender, EventArgs e)
        {
            lblOperator.Text = "/";
            txtResultant.Text = mathFunctions.Divide(txtValue1.Text, txtValue2.Text);
        }

        private void BtnModulus_Click(object sender, EventArgs e)
        {
            lblOperator.Text = "%";
            txtResultant.Text = mathFunctions.Modulus(txtValue1.Text, txtValue2.Text);
        }

        private void BtnPower_Click(object sender, EventArgs e)
        {
            lblOperator.Text = "^";
            txtResultant.Text = mathFunctions.Power(txtValue1.Text, txtValue2.Text);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            log4net.LogManager.Shutdown();
        }

        private void SetArrayValues(string[] data)
        {
            txtArray1.Text = data[0];
            txtArray2.Text = data[1];
            txtArray3.Text = data[2];
            txtArray4.Text = data[3];
            txtArray5.Text = data[4];
        }

        private string[] GetArrayValues()
        {
            string[] arr = new string[5];
            arr[0] = txtArray1.Text;
            arr[1] = txtArray2.Text;
            arr[2] = txtArray3.Text;
            arr[3] = txtArray4.Text;
            arr[4] = txtArray5.Text;
            return arr;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            arrayFunctions.Store(GetArrayValues());
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            SetArrayValues(arrayFunctions.Load(5));
        }

        private void BtnRandomize_Click(object sender, EventArgs e)
        {
            SetArrayValues(arrayFunctions.Randomize(GetArrayValues()));
        }

        private void BtnShiftRight_Click(object sender, EventArgs e)
        {
            SetArrayValues(arrayFunctions.ShiftRight(GetArrayValues()));
        }

        private void BtnShiftLeft_Click(object sender, EventArgs e)
        {
            SetArrayValues(arrayFunctions.ShiftLeft(GetArrayValues()));
        }

        private void BtnReverse_Click(object sender, EventArgs e)
        {
            SetArrayValues(arrayFunctions.Reverse(GetArrayValues()));
        }

    }
}
