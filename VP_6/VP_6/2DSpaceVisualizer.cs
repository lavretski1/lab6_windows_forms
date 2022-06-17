using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VP_6
{
    internal class Space2DVisualizer : Control
    {
        private int _unitSize = 2;

        private float _step;
        public float UnitSize {
            get 
            {
                return _step;
            }
        }

        public int UnitNumber {
            get 
            {
                return _unitSize;
            }
            set 
            {
                _unitSize = value;
            }
        }

        private System.Drawing.Drawing2D.Matrix _transform = new System.Drawing.Drawing2D.Matrix();
        public System.Drawing.Drawing2D.Matrix Transform {
            get 
            {
                return _transform;
            }
            set 
            {
                _transform = value;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            _step = (float)(MathF.Min(base.Size.Width, base.Size.Height)) / (_unitSize * 2);

            Pen XAxisPen = new Pen(Color.Red, 3);
            Pen YAxisPen = new Pen(Color.Green, 3);
            Pen nonAxisPen = new Pen(Color.Black, 2);
            PointF[] points = new PointF[2];
            (int, int) center = ((int) (_unitSize * _step), (int) (_unitSize * _step));

            //here space is not transformed

            points[0].X = center.Item1;
            points[0].Y = center.Item2;
            points[1] = points[0];
            points[1].X += _step;
            e.Graphics.DrawCurve(XAxisPen, points);
            points[1].X = center.Item1;
            points[1].Y -= _step;
            e.Graphics.DrawCurve(YAxisPen, points);

            var transform = new System.Drawing.Drawing2D.Matrix();
            transform.Translate(center.Item1, center.Item2);
            transform.Multiply(_transform);
            e.Graphics.Transform = transform;
            //now space returned to desired transform
            for (int i = -_unitSize * 20; i < _unitSize * 10 + 1; i++)
            {
                for (int j = -_unitSize * 20; j < _unitSize * 10 + 1; j++)
                {
                    PointF currentPoint = e.ClipRectangle.Location;//this part increases precision
                    currentPoint.X += (i * _step);
                    currentPoint.Y += (j * _step);
                    points[0] = currentPoint;
                    if (i != _unitSize * 20)
                    {
                        PointF currentPointExtentionX = currentPoint;
                        currentPointExtentionX.X += _step;
                        points[1] = currentPointExtentionX;
                        if (j == 0)
                        {
                            e.Graphics.DrawCurve(XAxisPen, points);
                            if (i == _unitSize - 1) 
                            {
                                PointF[] arrowPoints = new PointF[3];
                                arrowPoints[0].X = currentPoint.X + _step * 3 / 4;
                                arrowPoints[0].Y = currentPoint.Y + _step / 4;
                                arrowPoints[1] = currentPointExtentionX;
                                arrowPoints[2].X = arrowPoints[0].X;
                                arrowPoints[2].Y = -arrowPoints[0].Y;
                                e.Graphics.DrawCurve(XAxisPen, arrowPoints);
                            }
                        }
                        else
                        {
                            e.Graphics.DrawCurve(nonAxisPen, points);
                        }
                    }
                    if (j != _unitSize * 20)
                    {
                        PointF currentPointExtentionY = currentPoint;
                        currentPointExtentionY.Y += _step;
                        points[1] = currentPointExtentionY;
                        if (i == 0)
                        {
                            e.Graphics.DrawCurve(YAxisPen, points);
                            if (j == -_unitSize) 
                            {
                                PointF[] arrowPoints = new PointF[3];
                                arrowPoints[0].X = currentPointExtentionY.X + _step / 4;
                                arrowPoints[0].Y = currentPoint.Y + _step / 4;
                                arrowPoints[1] = currentPoint;
                                arrowPoints[2].X = -arrowPoints[0].X;
                                arrowPoints[2].Y = arrowPoints[0].Y;
                                e.Graphics.DrawCurve(YAxisPen, arrowPoints);
                            }
                        }
                        else
                        {
                            e.Graphics.DrawCurve(nonAxisPen, points);
                        }
                    }
                }
            }
        }
    }
}
