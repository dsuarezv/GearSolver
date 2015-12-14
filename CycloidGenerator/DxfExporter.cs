using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using netDxf;
using netDxf.Tables;
using netDxf.Entities;

namespace CycloidGenerator
{
    public class DxfExporter
    {
        public static void ExportCycloid(Cycloid target, string fileName)
        {
            var dxf = new DxfDocument();

            target.CalculateCam(
                (center, radius, layer) =>
                {
                    var l = GetLayer(dxf, layer);
                    var e = new Circle(new Vector2(center.X, center.Y), radius);
                    e.Layer = l;
                    dxf.AddEntity(e);
                },
                (p1, p2, layer) =>
                {
                    var l = GetLayer(dxf, layer);
                    var e = new Line(new Vector2(p1.X, p1.Y), new Vector2(p2.X, p2.Y));
                    e.Layer = l;
                    dxf.AddEntity(e);                    
                }
            );

            dxf.Save(fileName);
        }

        private static Layer GetLayer(DxfDocument dxf, string layerName)
        {
            if (dxf.Layers.Contains(layerName)) return dxf.Layers[layerName];

            return dxf.Layers.Add(new Layer(layerName));
        }
    }
}
