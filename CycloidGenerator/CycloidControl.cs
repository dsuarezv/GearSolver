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
        private bool mDrawGrid = true;
        private Matrix mDirectTransform;
        private Matrix mInverseTransform;
        private Pen[] mPens;


        public Cycloid Cycloid
        {
            get { return mCycloid; }
            set { mCycloid = value; Invalidate(); }
        }

        public bool DrawGrid
        {
            get { return mDrawGrid; }
            set { mDrawGrid = value; Invalidate(); }
        }


        public CycloidControl()
        {
            SetStyle(
                ControlStyles.AllPaintingInWmPaint
                | ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.ResizeRedraw
                | ControlStyles.UserPaint
                , true);

            SetPenWidth(1);
        }

        public void SetPenWidth(float width)
        {
            mPens = new Pen[] {
                new Pen(Color.Red, width * 2f),
                new Pen(Color.Gray, width),
                new Pen(Color.LightGray, width),
                new Pen(Color.FromArgb(230, 230, 230), width)
            };
        }

        protected override void OnResize(EventArgs e)
        {
            var scale = 3.694f;

            base.OnResize(e);

            mDirectTransform = new Matrix();
            mDirectTransform.Translate(Width / 2, Height / 2);
            mDirectTransform.Scale(scale, -scale);
            //mDirectTransform.Rotate(AngleCorrection);

            SetPenWidth(1 / scale);

            mInverseTransform = mDirectTransform.Clone();
            mInverseTransform.Invert();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (mCycloid == null) return;
            
            // Apply transformation for centering and any possible rotation correction.
            e.Graphics.Transform = mDirectTransform;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            PaintGrid(e.Graphics);

            // Draw the thing
            mCycloid.CalculateCam(
                (center, radius, layer) =>
                {
                    e.Graphics.DrawEllipse(GetPen(layer), new RectangleF((float)(center.X - radius), (float)(center.Y - radius), (float)(radius * 2), (float)(radius * 2)));
                },
                (p1, p2, layer) =>
                {
                    e.Graphics.DrawLine(GetPen(layer), GetPointF(p1), GetPointF(p2));
                }
            );

            // Reset transform
            e.Graphics.Transform = new Matrix();
        }

        private void PaintGrid(Graphics g)
        {
            var gridMin = -100;
            var gridMax = 100;
            var gridStep = 10;

            var p = GetPen("grid");

            for (int x = gridMin; x <= gridMax; x += gridStep) g.DrawLine(p, x, gridMin, x, gridMax);
            for (int y = gridMin; y <= gridMax; y += gridStep) g.DrawLine(p, gridMin, y, gridMax, y);

        }

        private Pen GetPen(string layerName)
        {
            switch (layerName)
            {
                case "cam": return mPens[0];
                case "roller": return mPens[1];
                case "pressure": return mPens[2];
                case "grid": return mPens[3];
                default: return Pens.Black;
            }
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
