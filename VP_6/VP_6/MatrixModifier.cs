using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VP_6
{
    public partial class MatrixModifier : Form
    {
        private Matrix _result;

        public Matrix Result { 
            get
            {
                return _result;
            }
        }

        public int XGap { get; set; } = 20;
        public int YGap { get; set; } = 20;

        public bool EnableEditing {
            get {
                return Controls[0].Enabled;
            }
            set {
                foreach (Control control in Controls) 
                {
                    control.Enabled = value;
                }
            }
        }

        public MatrixModifier()
        {
            InitializeComponent();
            _result = new Matrix();
            _result.Dimentions = (1, 1);
        }

        public MatrixModifier(Matrix matrix) 
        {
            InitializeComponent();
            _result = matrix;
            matrixElementInput1.Text = matrix[0, 0].ToString();
            numericUpDown1.Value = matrix.Dimentions.Item1;
            numericUpDown2.Value = matrix.Dimentions.Item2;
        }

        private void matrixElementInput_Validating(object sender, CancelEventArgs e)
        {
            MatrixElementInput senderElement = sender as MatrixElementInput;
            if (!float.TryParse(senderElement.Text, out _))
            {
                errorProvider1.SetError(senderElement, "Enter real number");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void matrixElementInput_Validated(object sender, EventArgs e)
        {
            MatrixElementInput senderElement = sender as MatrixElementInput;
            float value = float.Parse(senderElement.Text);

            _result[senderElement.Row, senderElement.Column] = value;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int currentNumberOfRows = (Controls.Cast<Control>().MaxBy((contr) => (contr as MatrixElementInput)?.Row) as MatrixElementInput).Row + 1;
            int currentNumberOfColumns = (Controls.Cast<Control>().MaxBy((contr) => (contr as MatrixElementInput)?.Column) as MatrixElementInput).Column + 1;

            NumericUpDown upDown = sender as NumericUpDown;
            int desiredNumberOfRows = (int)upDown.Value;

            int numberOfRowsToAdd = desiredNumberOfRows - currentNumberOfRows;

            var position = matrixElementInput1.Location;

            if (numberOfRowsToAdd > 0)
            {
                int xStep = XGap + matrixElementInput1.Size.Width;
                int yStep = YGap + matrixElementInput1.Size.Height;

                position.Y += yStep * currentNumberOfRows;

                for (int i = 0; i < numberOfRowsToAdd; i++)
                {
                    for (int j = 0; j < currentNumberOfColumns; j++)
                    {
                        MatrixElementInput elementInput = new MatrixElementInput();

                        elementInput.Location = position;
                        elementInput.Size = matrixElementInput1.Size;
                        elementInput.Row = currentNumberOfRows + i;
                        elementInput.Column = j;
                        if (_result.Dimentions.Item1 <= elementInput.Row || _result.Dimentions.Item2 <= elementInput.Column)
                        {
                            elementInput.Text = "0";
                        }
                        else
                        {
                            elementInput.Text = _result[elementInput.Row, elementInput.Column].ToString();
                        }
                        elementInput.Validating += matrixElementInput_Validating;
                        elementInput.Validated += matrixElementInput_Validated;

                        Controls.Add(elementInput);

                        position.X += xStep;
                    }

                    position.Y += yStep;
                    position.X = matrixElementInput1.Location.X;
                }
            }
            else 
            {
                var controlsToRemove = Controls.Cast<Control>()
                    .AsQueryable()
                    .Where((cont) => (cont as MatrixElementInput) == null?false:(cont as MatrixElementInput).Row > desiredNumberOfRows - 1)
                    .ToList();
                foreach (var control in controlsToRemove) 
                {
                    Controls.Remove(control);
                }
            }
            var dimentions = _result.Dimentions;
            dimentions.Item1 = desiredNumberOfRows;
            _result.Dimentions = dimentions;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            int currentNumberOfRows = (Controls.Cast<Control>().MaxBy((contr) => (contr as MatrixElementInput)?.Row) as MatrixElementInput).Row + 1;
            int currentNumberOfColumns = (Controls.Cast<Control>().MaxBy((contr) => (contr as MatrixElementInput)?.Column) as MatrixElementInput).Column + 1;

            NumericUpDown upDown = sender as NumericUpDown;
            int desiredNumberOfColumns = (int)upDown.Value;

            int numberOfColumnsToAdd = desiredNumberOfColumns - currentNumberOfColumns;

            var position = matrixElementInput1.Location;

            if (numberOfColumnsToAdd > 0)
            {
                int xStep = XGap + matrixElementInput1.Size.Width;
                int yStep = YGap + matrixElementInput1.Size.Height;

                position.X += xStep * currentNumberOfColumns;

                for (int i = 0; i < numberOfColumnsToAdd; i++)
                {
                    for (int j = 0; j < currentNumberOfRows; j++)
                    {
                        MatrixElementInput elementInput = new MatrixElementInput();

                        elementInput.Location = position;
                        elementInput.Size = matrixElementInput1.Size;
                        elementInput.Row = j;
                        elementInput.Column = currentNumberOfColumns + i;
                        if (_result.Dimentions.Item1 <= elementInput.Row || _result.Dimentions.Item2 <= elementInput.Column)
                        {
                            elementInput.Text = "0";
                        }
                        else 
                        {
                            elementInput.Text = _result[elementInput.Row, elementInput.Column].ToString();
                        }
                        elementInput.Validating += matrixElementInput_Validating;
                        elementInput.Validated += matrixElementInput_Validated;

                        Controls.Add(elementInput);

                        position.Y += yStep;
                    }

                    position.X += xStep;
                    position.Y = matrixElementInput1.Location.Y;
                }
            }
            else
            {
                var controlsToRemove = Controls.Cast<Control>()
                    .AsQueryable()
                    .Where((cont) => (cont as MatrixElementInput) == null ? false : (cont as MatrixElementInput).Column > desiredNumberOfColumns - 1)
                    .ToList();
                foreach (var control in controlsToRemove)
                {
                    Controls.Remove(control);
                }
            }
            var dimentions = _result.Dimentions;
            dimentions.Item2 = desiredNumberOfColumns;
            _result.Dimentions = dimentions;
        }
    }
}
