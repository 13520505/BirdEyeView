using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Emgu.CV;
using Emgu.CV.Structure;

namespace BirdsEyeEngine
{
    public class BirdsEye
    {
        private Image<Bgr, byte> m_BirdsEyeImage;
        private double PI = 3.14159265;
        private double ALPHA = 45.0;				    // Degree
        private int LENGTH = 2400;			            // Pixels
        private int srcTopY = 0;
        private int H = 0;

        private double sinalpha = 0.0;
        private double cosalpha = 0.0;
        private double tanalpha = 0.0;

        private int vs;
        //private int vt;

        private int[,] arrIndexP;
        private int[,] arrIndexQ;

        public BirdsEye(double dAlpha, int dLength, int iSrcTopY, int iRawImageWd, int iRawImageHt)
        {
            ALPHA = dAlpha;
            LENGTH = dLength;
            srcTopY = iSrcTopY;
            sinalpha = sinradian(ALPHA);
            cosalpha = cosradian(ALPHA);
            tanalpha = tanradian(ALPHA);

            H = GetDstHeight(ALPHA, LENGTH, iRawImageHt, srcTopY);
            this.m_BirdsEyeImage = new Image<Bgr, byte>(iRawImageWd, H);

            vs = GetDstBottomY(ALPHA, LENGTH, iRawImageHt, srcTopY);
            //vt = GetDstTopY(ALPHA, srcTopY);

            int p, q, U, V, P, Q;
            arrIndexP = new int[H, iRawImageWd];
            arrIndexQ = new int[H, iRawImageWd];
            for (int v = 0; v < this.m_BirdsEyeImage.Height; v++)
            {
                V = H - v + this.vs;
                for (int u = 0; u < this.m_BirdsEyeImage.Width; u++)
                {
                    U = u - this.m_BirdsEyeImage.Width / 2;
                    P = MapDstToSrcX(ALPHA, LENGTH, srcTopY, U, V);
                    Q = MapDstToSrcY(ALPHA, LENGTH, srcTopY, V);

                    p = P + this.m_BirdsEyeImage.Width / 2;
                    q = Q + iRawImageHt / 2;
                    q = iRawImageHt - q;

                    if (p < iRawImageWd && 0 <= p &&
                        q < iRawImageHt && 0 <= q)
                    {
                        arrIndexP[v, u] = p;
                        arrIndexQ[v, u] = q;
                    }
                }
            }
        }

        public Image<Bgr, byte> BirdEyeTransform(Image<Bgr, Byte> RawImage)
        {
            int p, q;
            for (int v = 0; v < this.m_BirdsEyeImage.Height; v++)
            {
                for (int u = 0; u < this.m_BirdsEyeImage.Width; u++)
                {
                    p = arrIndexP[v, u];
                    q = arrIndexQ[v, u];
                    if (p < RawImage.Width && 0 <= p &&
                        q < RawImage.Height && 0 <= q)
                    {
                        this.m_BirdsEyeImage.Data[v, u,0] = (byte)RawImage.Data.GetValue(q, p, 0);
                        this.m_BirdsEyeImage.Data[v, u, 1] = (byte)RawImage.Data.GetValue(q, p, 1);
                        this.m_BirdsEyeImage.Data[v, u, 2] = (byte)RawImage.Data.GetValue(q, p, 2);
                    }
                }
            }

            return this.m_BirdsEyeImage;
        }

        private double sinradian(double x)
        {
            return Math.Sin(x * PI / 180.0);
        }

        private double cosradian(double x)
        {
            return Math.Cos(x * PI / 180.0);
        }

        private double tanradian(double x)
        {
            return Math.Tan(x * PI / 180.0);
        }

        private int GetDstTopY(double alpha, int srcTopY)
        {
            double vt;
            vt = srcTopY / this.sinalpha;
            return (int)vt;
        }

        private int GetDstBottomY(double alpha, int length, int srcHeight, int srcTopY)
        {
            double vs;
            double a, d, c;

            a = this.cosalpha * srcTopY;
            d = length * this.sinalpha;
            c = srcHeight * this.cosalpha / 2;

            vs = srcHeight * (a - d) / (c + d) / 2 / this.sinalpha;
            return (int)vs;
        }

        private int GetDstHeight(double alpha, int length, int srcHeight, int srcTopY)
        {
            int H;
            H = GetDstTopY(alpha, srcTopY) - GetDstBottomY(alpha, length, srcHeight, srcTopY);
            return H;
        }

        private int MapDstToSrcX(double alpha, int length, int srcTopY, int srcX, int srcY)
        {
            double p;
            p = length * srcX / (this.cosalpha * srcY + length - srcTopY / this.tanalpha);
            return (int)p;
        }

        private int MapDstToSrcY(double alpha, int length, int srcTopY, int srcY)
        {
            double q;
            q = length * this.sinalpha * srcY / (this.cosalpha * srcY + length - srcTopY / this.tanalpha);
            return (int)q;
        }
    }
}
