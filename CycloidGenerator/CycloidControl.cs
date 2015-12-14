using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CycloidGenerator
{
    public class CycloidControl: Control
    {
        private Cycloid mCycloid;
        private Matrix mDirectTransform;
        private Matrix mInverseTransform;

        public Cycloid Cycloid
        {
            get { return mCycloid; }
            set { mCycloid = value; Invalidate(); }
        }


        public CycloidControl()
        {
            SetStyle(
                ControlStyles.AllPaintingInWmPaint
                | ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.ResizeRedraw
                | ControlStyles.UserPaint
                , true);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            mDirectTransform = new Matrix();
            mDirectTransform.Translate(Width / 2, Height / 2);
            mDirectTransform.Scale(3, -3);
            //mDirectTransform.Rotate(AngleCorrection);

            mInverseTransform = mDirectTransform.Clone();
            mInverseTransform.Invert();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (mCycloid == null) return;
            
            // Apply transformation for centering and any possible rotation correction.
            e.Graphics.Transform = mDirectTransform;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Draw the thing
            mCycloid.CalculateCam(
                (center, radius, layer) =>
                {
                    e.Graphics.DrawEllipse(Pens.Black, new RectangleF((float)(center.X - radius), (float)(center.Y - radius), (float)(radius * 2), (float)(radius * 2)));
                },
                (p1, p2, layer) =>
                {
                    e.Graphics.DrawLine(Pens.Red, GetPointF(p1), GetPointF(p2));
                }
            );

            // Reset transform
            e.Graphics.Transform = new Matrix();
        }




        // __ Util ____________________________________________________________


        private PointF GetPointF(Point p)
        {
            return new PointF((float)p.X, (float)p.Y);
        }


        private PointF SpaceToScreen(PointF p)
        {
            return ApplyMatrixToPoint(p, mDirectTransform);
        }

        private PointF ScreenToSpace(PointF p)
        {
            return ApplyMatrixToPoint(p, mInverseTransform);
        }

        private PointF ApplyMatrixToPoint(PointF p, Matrix m)
        {
            var points = new PointF[] { p };
            m.TransformPoints(points);
            return points[0];
        }
    }
}
