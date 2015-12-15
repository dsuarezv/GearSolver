using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CycloidGenerator.Solvers;
using netDxf;
using netDxf.Tables;
using netDxf.Entities;


namespace CycloidGenerator
{
    public class DxfExporter: IExportClient
    {
        private DxfDocument mDxf = new DxfDocument();

        public static void ExportCycloid(ISolver target, string fileName)
        {
            var exporter = new DxfExporter();

            target.Run(exporter);

            exporter.mDxf.Save(fileName);
        }

        public void Circle(SolverPoint center, double radius, int color, string layer)
        {
            var l = GetLayer(mDxf, layer);
            var e = new Circle(new Vector2(center.X, center.Y), radius);
            e.Layer = l;
            mDxf.AddEntity(e);
        }

        public void Line(SolverPoint p1, SolverPoint p2, int color, string layer)
        {
            var l = GetLayer(mDxf, layer);
            var e = new Line(new Vector2(p1.X, p1.Y), new Vector2(p2.X, p2.Y));
            e.Layer = l;
            mDxf.AddEntity(e);    
        }

        private Layer GetLayer(DxfDocument dxf, string layerName)
        {
            if (dxf.Layers.Contains(layerName)) return dxf.Layers[layerName];

            return dxf.Layers.Add(new Layer(layerName));
        }
    }
}
