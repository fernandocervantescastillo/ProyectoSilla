using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practico3
{
    class Cubo
    {
        private float[] _vertices;

        private uint[] _indices;

        private int _vertexBufferObject;

        private int _vertexArrayObject;

        private Shader _shader;

        private int _elementBufferObject;

        public Cubo(float x, float y, float z, float posX, float posY, float posZ)
        {
            _vertices = new float[24];
            _vertices[0] = 0.0f * x + posX;
            _vertices[1] = 0.0f * y + posY;
            _vertices[2] = 0.0f * z + posZ;

            _vertices[3] = 1f * x + posX;
            _vertices[4] = 0f * y + posY;
            _vertices[5] = 0f * z + posZ;

            _vertices[6] = 0f * x + posX;
            _vertices[7] = 1f * y + posY;
            _vertices[8] = 0f * z + posZ;

            _vertices[9] = 1f * x + posX;
            _vertices[10] = 1f * y + posY;
            _vertices[11] = 0.0f * z + posZ;

            _vertices[12] = 0.0f * x + posX;
            _vertices[13] = 0.0f * y + posY;
            _vertices[14] = 1.0f * z + posZ;

            _vertices[15] = 1f * x + posX;
            _vertices[16] = 0f * y + posY;
            _vertices[17] = 1f * z + posZ;

            _vertices[18] = 0f * x + posX;
            _vertices[19] = 1f * y + posY;
            _vertices[20] = 1f * z + posZ;

            _vertices[21] = 1f * x + posX;
            _vertices[22] = 1f * y + posY;
            _vertices[23] = 1f * z + posZ;




            _indices = new uint[36];
            _indices[0] = 2;
            _indices[1] = 1;
            _indices[2] = 3;
            _indices[3] = 2;
            _indices[4] = 0;
            _indices[5] = 1;

            _indices[6] = 0;
            _indices[7] = 5;
            _indices[8] = 1;
            _indices[9] = 0;
            _indices[10] = 4;
            _indices[11] = 5;

            _indices[12] = 4;
            _indices[13] = 7;
            _indices[14] = 5;
            _indices[15] = 4;
            _indices[16] = 6;
            _indices[17] = 7;

            _indices[18] = 6;
            _indices[19] = 3;
            _indices[20] = 7;
            _indices[21] = 6;
            _indices[22] = 2;
            _indices[23] = 3;

            _indices[24] = 2;
            _indices[25] = 4;
            _indices[26] = 0;
            _indices[27] = 2;
            _indices[28] = 6;
            _indices[29] = 4;

            _indices[30] = 1;
            _indices[31] = 7;
            _indices[32] = 3;
            _indices[33] = 1;
            _indices[34] = 5;
            _indices[35] = 7;

            _vertexBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, _vertices.Length * sizeof(float), _vertices, BufferUsageHint.StaticDraw);

            _vertexArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(_vertexArrayObject);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);

            _elementBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, _elementBufferObject);
            GL.BufferData(BufferTarget.ElementArrayBuffer, _indices.Length * sizeof(uint), _indices, BufferUsageHint.StaticDraw);

            _shader = new Shader("../../../Shaders/shader.vert", "../../../Shaders/shader.frag");

        }

        public void draw(Matrix4 matriz)
        {

            _shader.Use();

            //GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject);
            GL.BindVertexArray(_vertexArrayObject);

            _shader.SetMatrix4("model", Matrix4.Identity);
            _shader.SetMatrix4("view", Matrix4.Identity);
            _shader.SetMatrix4("projection", matriz);

            GL.DrawElements(PrimitiveType.Triangles, _indices.Length, DrawElementsType.UnsignedInt, 0);

        }

        public void dispose()
        {
            // Unbind all the resources by binding the targets to 0/null.
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.BindVertexArray(0);
            GL.UseProgram(0);

            // Delete all the resources.
            GL.DeleteBuffer(_vertexBufferObject);
            GL.DeleteVertexArray(_vertexArrayObject);

            GL.DeleteBuffer(_elementBufferObject);

            GL.DeleteProgram(_shader.Handle);


        }

    }
}
