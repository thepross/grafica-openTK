using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace grafica_clase1
{
    class Ventana : GameWindow
    {

        float speed = 0.2f;
        Vector3 position = new Vector3(0.0f, 0.0f, 10.0f);
        Vector3 front = new Vector3(0.0f, 0.0f, -1.0f);
        Vector3 up = new Vector3(0.0f, 1.0f, 0.0f);

        public float tx = 0.0f;
        public float ty = 0.0f;
        public float tz = 0.0f;

        Figura figura;
        Figura figura2;
        Figura figura3;

        public Ventana(int width, int height) : base(width, height, GraphicsMode.Default, "Programación Gráfica")
        {
            VSync = VSyncMode.On;
            figura = new Figura(Color4.Aqua, 0, 0, 0);
            figura2 = new Figura(Color4.White, 2, 2, 0);
            figura3 = new Figura(Color4.Red, -2, -2, 0);
        }


        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(0.0f, 0.1f, 0.2f, 0.0f);
            GL.Enable(EnableCap.DepthTest);

            base.OnLoad(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.DepthMask(true);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit | ClearBufferMask.StencilBufferBit);
            Matrix4 modelview = Matrix4.LookAt(position, position + front, up);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref modelview);


            figura.dibujar();
            figura2.dibujar();
            figura3.dibujar();

            
            SwapBuffers();
            base.OnRenderFrame(e);
        }





        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            KeyboardState input = Keyboard.GetState();
            
            // mover
            if (input.IsKeyDown(Key.Left))  figura.cx -= 0.02f;
            if (input.IsKeyDown(Key.Right)) figura.cx += 0.02f;
            if (input.IsKeyDown(Key.Up)) figura.cy += 0.02f;
            if (input.IsKeyDown(Key.Down)) figura.cy -= 0.02f;

            // camara
            if (input.IsKeyDown(Key.W))
            {
                position += front * speed;
            }

            if (input.IsKeyDown(Key.S))
            {
                position -= front * speed;
            }

            if (input.IsKeyDown(Key.A))
            {
                position -= Vector3.Normalize(Vector3.Cross(front, up)) * speed;
            }

            if (input.IsKeyDown(Key.D))
            {
                position += Vector3.Normalize(Vector3.Cross(front, up)) * speed;
            }

            if (input.IsKeyDown(Key.Space))
            {
                position += up * speed;
            }

            if (input.IsKeyDown(Key.LShift))
            {
                position -= up * speed;
            }

            if (input.IsKeyDown(Key.Escape))
            {
                Exit();
            }

            if (!Focused)
            {
                return;
            }
        }


        protected override void OnResize(EventArgs e)
        {

            base.OnResize(e);
            GL.Viewport(0, 0, this.Width, this.Height);

            Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView((float)Math.PI / 4, Width / (float)Height, 1.0f, 64.0f);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref projection);
        }

    }


}
