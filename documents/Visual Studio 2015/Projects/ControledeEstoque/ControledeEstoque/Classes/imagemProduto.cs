using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ControledeEstoque.Classes
{
    class imagemProduto
    {
        private string _path;
        private Image _picture;
        private Image _thumbImage;
        private int _width;
        private int height;
        #region Defining access to the attributes
        public string Path
        {
            get
            {
                return _path;
            }

            set
            {
                _path = value;
            }
        }

        public Image Picture
        {
            get
            {
                return _picture;
            }

            set
            {
                _picture = value;
            }
        }

        public int Width
        {
            get
            {
                return _width;
            }

            set
            {
                _width = value;
            }
        }

        public int Height
        {
            get
            {
                return height;
            }

            set
            {
                height = value;
            }
        }

        public Image ThumbImage
        {
            get
            {
                return _thumbImage;
            }

            set
            {
                _thumbImage = value;
            }
        }
        #endregion
        #region Methods

        public static Image ResizeCenterCropped(Image image, int width, int height)
        {
            var rect = CreateCroppedRectangle(image, width, height);
            rect.X = (image.Width / 2) - (rect.Width / 2);
            rect.Y = (image.Height / 2) - (rect.Height / 2);
            return Resize(image, new Rectangle(0, 0, width, height), rect);
        }

        public static Image Resize(Image image, Rectangle destRectange, Rectangle sourceRectangle)
        {
            var rezisedImage = new Bitmap(destRectange.Width, destRectange.Height);
            using (var g = Graphics.FromImage(rezisedImage))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.DrawImage(image, destRectange, sourceRectangle, GraphicsUnit.Pixel);
                return rezisedImage;
            }
        }

        public static Rectangle CreateCroppedRectangle(Image image, int width, int height)
        {
            var size = new Size(width, height);
            var size2 = new Size(image.Width, image.Height);

            //The maximum scale width we could use
            float maxWidthScale = (float)size2.Width / (float)size.Width;

            //The maximum scale height we could use
            float maxHeightScale = (float)size2.Height / (float)size.Height;

            //Use the smaller of the 2 scales for the scaling
            float scale = Math.Min(maxHeightScale, maxWidthScale);


            size.Width = (int)(size.Width * scale);
            size.Height = (int)(size.Height * scale);

            return new Rectangle(new Point(), size);
        }


        #endregion

        public imagemProduto()
        {
            Picture = null;
            ThumbImage = null;
            Width = 0;
            Height = 0;



        }
        public void populaImagem(string caminho)
        {

            Path = caminho;
            Picture = Image.FromFile(caminho);
            ThumbImage = ResizeCenterCropped(Picture, 315, 310);
            Width = Picture.Width;
            Height = Picture.Height;
            

        }


    }
}
