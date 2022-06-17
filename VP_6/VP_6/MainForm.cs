using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace VP_6
{
    public partial class MainForm : Form
    {
        private XmlSerializer _xmlSerializer;

        private Point _position;
        private DraggableLabel? _draggableLabel;

        private Matrix? _result;
        private CurrentOperations _currentOperations = CurrentOperations.None;

        enum CurrentOperations 
        {
            None,
            AddOperation,
            MultiplyOperation
        }

        public MainForm()
        {
            _xmlSerializer = new XmlSerializer(typeof(SerializableElement));
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            label1.Matrix = new Matrix();
            label1.Matrix.Dimentions = (1, 1);
        }

        private void labels_MouseDown(object sender, MouseEventArgs e)
        {
            _position = e.Location;

            _draggableLabel = sender as DraggableLabel;
        }

        private void panel1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text) &&
                _xmlSerializer.CanDeserialize(CreateReaderFromString(e.Data.GetData(DataFormats.Text) as string)))
            {
                e.Effect = DragDropEffects.Copy;
                panel1.BackColor = Color.Silver;
            }
        }

        private void panel1_DragLeave(object sender, EventArgs e)
        {
            panel1.BackColor = Color.Gainsboro;
        }

        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            string draggableType = e.Data.GetData(DataFormats.Text) as string;
            SerializableElement element = _xmlSerializer.Deserialize(CreateReaderFromString(draggableType)) as SerializableElement;

            if (_result != null)//to lazy to improve this part
            {
                if (element.ElementType == DraggableElementTypes.Matrix)
                {
                    if (_currentOperations == CurrentOperations.AddOperation)
                    {
                        Matrix secondOperand = new Matrix();
                        secondOperand.ElementsLists = element.Matrix;
                        try
                        {
                            _result = Matrix.Add(_result, secondOperand);
                            _currentOperations = CurrentOperations.None;
                            label2.Text = $"Matrix {_result.Dimentions}";
                            errorProvider1.Clear();
                        }
                        catch(ArgumentException err)
                        {
                            errorProvider1.SetError(panel1, err.Message);
                        }
                    }
                    else if (_currentOperations == CurrentOperations.MultiplyOperation) 
                    {
                        Matrix secondOperand = new Matrix();
                        secondOperand.ElementsLists = element.Matrix;
                        try
                        {
                            _result = Matrix.Multiply(_result, secondOperand);
                            _currentOperations = CurrentOperations.None;
                            label2.Text = $"Matrix {_result.Dimentions}";
                            errorProvider1.Clear();
                        }
                        catch (ArgumentException err)
                        {
                            errorProvider1.SetError(panel1, err.Message);
                        }
                    }
                    else
                    {
                        errorProvider1.SetError(panel1, "Awaiting operator not matrix");
                    }
                }
                else if (element.ElementType == DraggableElementTypes.TraceOperator) 
                {
                    if (_currentOperations == CurrentOperations.None)
                    {
                        try
                        {
                            float trace = _result.Trace();
                            _result = new Matrix();
                            _result.Dimentions = (1, 1);
                            _result[0, 0] = trace;
                            label2.Text = $"Matrix {_result.Dimentions}";
                            errorProvider1.Clear();
                        }
                        catch (ArgumentException err) 
                        {
                            errorProvider1.SetError(panel1, err.Message);
                        }
                    }
                    else
                    {
                        errorProvider1.SetError(panel1, "Finish burrent operation before applying new one");
                    }
                }
                else
                {
                    if (_currentOperations == CurrentOperations.None)
                    {
                        string operationText = element.ElementType == DraggableElementTypes.AddOperator ? "Add" : "Multiply";
                        label2.Text = $"{operationText} ( Matrix {_result.Dimentions} ,   )";
                        _currentOperations = element.ElementType == DraggableElementTypes.AddOperator ? CurrentOperations.AddOperation : CurrentOperations.MultiplyOperation;
                        errorProvider1.Clear();
                    }
                    else 
                    {
                        errorProvider1.SetError(panel1, "Finish burrent operation before applying new one");
                    }
                }
            }
            else 
            {
                if (element.ElementType == DraggableElementTypes.Matrix)
                {
                    _result = new Matrix();
                    _result.ElementsLists = element.Matrix;
                    label2.Text = $"Matrix {_result.Dimentions}";
                    errorProvider1.Clear();
                }
                else 
                {
                    errorProvider1.SetError(panel1, "Awaiting matrix not operator");
                }
            }
        }

        private XmlReader CreateReaderFromString(string text) 
        {
            return XmlReader.Create(new MemoryStream(Encoding.Unicode.GetBytes(text)));
        }

        private void labels_Click(object sender, MouseEventArgs e)
        {
            var matrixModefierForm = new MatrixModifier(new Matrix(label1.Matrix ?? new Matrix()));
            matrixModefierForm.FormClosing += CreateHandlerForMatrixInput(label1);
            matrixModefierForm.ShowDialog();
        }


        private FormClosingEventHandler CreateHandlerForMatrixInput(DraggableLabel label) 
        {
            return (sender, args) =>
            {
                label.Matrix = (sender as MatrixModifier).Result;
            };
        }

        private void labels_MouseMove(object sender, MouseEventArgs e)
        {
            if (MathF.Sqrt((_position.X - e.Location.X) * (_position.X - e.Location.X) + (_position.Y - e.Location.Y) * (_position.Y - e.Location.Y)) > 4 && _draggableLabel != null) {

                InitiateDragDrop(_draggableLabel);
            }
        }

        private void InitiateDragDrop(DraggableLabel label) 
        {
            SerializableElement data = new SerializableElement();

            data.ElementType = label.ElementType;

            data.Matrix = label.Matrix?.ElementsLists;

            using (var stringWriter = new StringWriter())
            {
                _xmlSerializer.Serialize(stringWriter, data);

                label.DoDragDrop(stringWriter.ToString(), DragDropEffects.Copy);
            }
        }

        private void labels_MouseUp(object sender, MouseEventArgs e)
        {
            _draggableLabel = null;
        }

        private void operationsLabel_MouseDown(object sender, MouseEventArgs e)
        {
            InitiateDragDrop(sender as DraggableLabel);
        }

        private void labels_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
        {
            Rectangle rect = new Rectangle(panel1.Location, new Size(panel1.Width, panel1.Height));

            if (Control.MouseButtons != MouseButtons.Left &&
                !rect.Contains(PointToClient(Control.MousePosition)))
            {
                e.Action = DragAction.Cancel;
                labels_MouseUp(sender, new MouseEventArgs(Control.MouseButtons, 0, Control.MousePosition.X, Control.MousePosition.Y, 0));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_result == null) 
            {
                return;
            }
            var matrixModefierForm = new MatrixModifier(_result);
            matrixModefierForm.EnableEditing = false;
            matrixModefierForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            _currentOperations = CurrentOperations.None;
            _result = null;
            label2.Text = "Empty";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new SpaceVisualizerForm().ShowDialog();
        }
    }
}
