using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace grafica_clase1
{
    class Figura
    {
        public float cx, cy, cz;
        private List<Vect3> vertices;
        private Color4 color;
        public Vect3 centro;
        public Figura(Color4 color, float x, float y, float z)
        {
            this.color = color;
            this.cx = x;
            this.cy = y;
            this.cz = z;
            // this.centro = centro;
            vertices = new List<Vect3>();
            addVertice(-1.0f, -1.0f, 0.0f);
            addVertice(1.0f, -1.0f, 0.0f);
            addVertice(0.0f, 1.0f, 0.0f);
        }

        public void addVertice(float x, float y, float z)
        {
            vertices.Add(new Vect3(x, y, z));
        }

        public void dibujar()
        {
            GL.Begin(PrimitiveType.Polygon);
            GL.Color4(color);
            foreach(Vect3 vector in vertices)
            {
                GL.Vertex3(cx + vector.X, cy + vector.Y, cz + vector.Z);
            }
            GL.End();

        }





    }
}
