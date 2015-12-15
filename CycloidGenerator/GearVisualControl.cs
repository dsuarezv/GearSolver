using CycloidGenerator.Solvers;
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
    public class GearVisualControl: Control, IExportClient
    {
        private ISolver mSolver;
        private bool mDrawGrid = true;
        private Matrix mDirectTransform;
        private Matrix mInverseTransform;
        private Pen[] mPens;
        private Graphics mCurrentGraphics;
        private float mMonitorDpis = 93;    // My monitor happens to be 93 dpis ;)


        public ISolver Solver
        {
            get { return mSolver; }
            set { mSolver = value; Invalidate(); }
        }

        public bool DrawGrid
        {
            get { return mDrawGrid; }
            set { mDrawGrid = value; Invalidate(); }
        }


        public GearVisualControl()
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
            base.OnResize(e);

            var scale = ConvertDpi(mMonitorDpis);

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
            if (mSolver == null) return;

            // Apply transformation for centering and any possible rotation correction.
            e.Graphics.Transform = mDirectTransform;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            PaintGrid(e.Graphics);

            // Draw the thing
            mCurrentGraphics = e.Graphics;
            mSolver.Run(this);
            mCurrentGraphics = null;

            // Reset transform
            e.Graphics.Transform = new Matrix();

            PaintDebug(e.Graphics);
        }

        public void Circle(SolverPoint center, double radius, int color, string layer)
        {
            if (mCurrentGraphics == null) return;

            mCurrentGraphics.DrawEllipse(mPens[color], new RectangleF((float)(center.X - radius), (float)(center.Y - radius), (float)(radius * 2), (float)(radius * 2)));
        }

        public void Line(SolverPoint p1, SolverPoint p2, int color, string layer)
        {
            if (mCurrentGraphics == null) return;

            mCurrentGraphics.DrawLine(mPens[color], GetPointF(p1), GetPointF(p2));
        }

        private void PaintDebug(Graphics g)
        {
            g.DrawString(GetDebugInfo(), Font, Brushes.Gray, 5, 0);
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

        private Pen GetPen(string penName)
        {
            switch (penName)
            {
                case "grid": return mPens[3];
                default: return Pens.Black;
            }
        }


        // __ Util ____________________________________________________________

        
        private string GetDebugInfo()
        {
            return string.Format("Grid = 1 cm\nScreen assumed to be {0} dpi.", mMonitorDpis);
        }

        private PointF GetPointF(SolverPoint p)
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

        private static float ConvertDpi(float dpi)
        { 
            // Converts points per inch to points per milimiter
            return dpi / 25.4f;
        }
    }
}
