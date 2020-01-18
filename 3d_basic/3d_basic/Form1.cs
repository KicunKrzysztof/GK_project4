using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace _3d_basic
{
    public partial class Form1 : Form
    {
        private Engine engine;
        private Stopwatch time;
        public Form1()
        {
            InitializeComponent();
            engine = new Engine(pictureBox, backgroundWorker1); 
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            time = Stopwatch.StartNew();
            engine.RunFrame();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            engine.Refresh();
            time.Stop();
            label1.Text = (1000.0 / time.ElapsedMilliseconds).ToString("N1") + " FPS";
        }

        private void ConstantShadingRadioButton_Click(object sender, EventArgs e)
        {
            engine.SetConstantShading();
        }

        private void GouraudRadioButton_Click(object sender, EventArgs e)
        {
            engine.SetGouraud();
        }

        private void PhongRadioButton_Click(object sender, EventArgs e)
        {
            engine.SetPhong();
        }

        private void ConstantCameraRadioButton_Click(object sender, EventArgs e)
        {
            engine.cam_mode = camera.constant;
        }

        private void TrackingCameraRadioButton_Click(object sender, EventArgs e)
        {
            engine.cam_mode = camera.track;
        }

        private void BoundedCameraRadioButton_Click(object sender, EventArgs e)
        {
            engine.cam_mode = camera.bounded;
        }

        private void SpotlightCheckBox_Click(object sender, EventArgs e)
        {
            engine.spotlight = !engine.spotlight;
        }

        private void SunCheckBox_Click(object sender, EventArgs e)
        {
            engine.sun = !engine.sun;
        }

        private void kaTrackBar_ValueChanged(object sender, EventArgs e)
        {
            var ctrl = sender as TrackBar;
            engine.ka = ctrl.Value / 100.0;
            kalabel.Text = (ctrl.Value / 100.0).ToString("N2");
        }

        private void kdTrackBar_ValueChanged(object sender, EventArgs e)
        {
            var ctrl = sender as TrackBar;
            engine.kd = ctrl.Value / 100.0;
            kdlabel.Text = (ctrl.Value / 100.0).ToString("N2");
        }

        private void ksTrackBar_ValueChanged(object sender, EventArgs e)
        {
            var ctrl = sender as TrackBar;
            engine.ks = ctrl.Value / 100.0;
            kslabel.Text = (ctrl.Value / 100.0).ToString("N2");
        }

        private void nTrackBar_ValueChanged(object sender, EventArgs e)
        {
            var ctrl = sender as TrackBar;
            engine.surface_factor_n = ctrl.Value;
            nlabel.Text = (ctrl.Value).ToString("N2");
        }

        private void spotlightAngleTrackBar_ValueChanged(object sender, EventArgs e)
        {
            var ctrl = sender as TrackBar;
            engine.spotlight_angle = Math.Cos((ctrl.Value / 10.0) * Math.PI / 180.0);
            spotlightAngleLabel.Text = ((ctrl.Value / 10.0)).ToString("N2");
        }

        private void spotlightNTrackBar_ValueChanged(object sender, EventArgs e)
        {
            var ctrl = sender as TrackBar;
            engine.spotlight_n = ctrl.Value;
            spotlightNLabel.Text = (ctrl.Value).ToString("N2");
        }
    }
}
