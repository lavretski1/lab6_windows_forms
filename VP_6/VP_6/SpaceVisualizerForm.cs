using System.Numerics;

namespace VP_6
{
    public partial class SpaceVisualizerForm : Form
    {
        private Matrix3x2 _transform;
        public Matrix3x2 Transform {
            get 
            {
                return _transform;
            }
            set 
            {
                try
                {
                    RefreshVisualizer();
                    _transform = value;
                }
                catch 
                {
                    throw;
                }
            }
        }

        public SpaceVisualizerForm()
        {
            InitializeComponent();
            _transform.M11 = 1;
            _transform.M22 = 1;
        }

        private void RefreshVisualizer() 
        {
            space2dVisualizer1.Transform.MatrixElements = _transform;
            space2dVisualizer1.Refresh();
        }

        private void textBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TextBox senderTextBox = sender as TextBox;
            if (!float.TryParse(senderTextBox.Text, out _))
            {
                errorProvider1.SetError(senderTextBox, "Enter real number");
                e.Cancel = true;
            }
            else 
            {
                errorProvider1.Clear();
            }
        }

        private void textBox6_Validated(object sender, EventArgs e)
        {
            _transform.M32 = float.Parse((sender as TextBox).Text) * -space2dVisualizer1.UnitSize;
        }

        private void textBox5_Validated(object sender, EventArgs e)
        {
            _transform.M31 = float.Parse((sender as TextBox).Text) * space2dVisualizer1.UnitSize;
        }

        private void textBox3_Validated(object sender, EventArgs e)
        {
            _transform.M21 = float.Parse((sender as TextBox).Text);
        }

        private void textBox4_Validated(object sender, EventArgs e)
        {
            _transform.M22 = float.Parse((sender as TextBox).Text);
        }

        private void textBox1_Validated(object sender, EventArgs e)
        {
            _transform.M11 = float.Parse((sender as TextBox).Text);
        }

        private void textBox2_Validated(object sender, EventArgs e)
        {
            _transform.M12 = float.Parse((sender as TextBox).Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RefreshVisualizer();
        }

        private void panel1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!(MathF.Abs(_transform.M11) + MathF.Abs(_transform.M12) > 0 && MathF.Abs(_transform.M21) + MathF.Abs(_transform.M22) > 0) ||
                _transform.M11 / _transform.M21 == _transform.M12 / _transform.M22) 
            {
                var panel = sender as Panel;
                errorProvider1.SetError(panel, "Impossible to create basis with this matrix");
                e.Cancel = true;
            }
        }
    }
}