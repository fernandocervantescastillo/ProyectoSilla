using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practico3
{
    class Silla
    {

        Cubo pata1;
        Cubo pata2;
        Cubo pata3;
        Cubo pata4;
        Cubo plataforma;
        Cubo horizontal;
        public Silla(float a, float b, float h1, float h2, float z, float posX, float posY, float posZ)
        {
            pata1 = new Cubo(z, h1, z, 0 + posX, 0 + posY, 0 + posZ);
            pata2 = new Cubo(z, h2 - z, z, b - z + posX, 0 + posY, 0 + posZ);
            pata3 = new Cubo(z, h1, z, 0 + posX, 0 + posY, a - z + posZ);
            pata4 = new Cubo(z, h2 - z, z, b - z + posX, 0 + posY, a - z + posZ);

            plataforma = new Cubo(b - z, z, a, z + posX, h2 - z + posY, 0 + posZ);
            horizontal = new Cubo(z, z, a - 2 * z, 0 + posX, h1 - z + posY, z + posZ);
        }

        public void draw(Matrix4 matriz)
        {
            pata1.draw(matriz);
            pata2.draw(matriz);
            pata3.draw(matriz);
            pata4.draw(matriz);
            plataforma.draw(matriz);
            horizontal.draw(matriz);
        }

        public void dispose()
        {
            pata1.dispose();
            pata2.dispose();
            pata3.dispose();
            pata4.dispose();
            plataforma.dispose();
            horizontal.dispose();
        }

    }
}
