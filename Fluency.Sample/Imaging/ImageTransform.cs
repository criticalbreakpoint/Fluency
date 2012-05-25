namespace Fluency.Sample.Imaging
{
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;

    using Fluency.Framework;

    public class ImageTransform : Fluent<Image, Transform>
    {
        public ImageTransform(Image context)
            : base(context)
        {
        }

        public ImageTransform CompositingMode(CompositingMode value)
        {
            this.Append(new Transform { CompositingMode = value });
            return this;
        }

        public ImageTransform CompositingQuality(CompositingQuality value)
        {
            this.Append(new Transform { CompositingQuality = value });
            return this;
        }

        public ImageTransform Height(int value)
        {
            this.Append(new Transform { Height = value });
            return this;
        }

        public ImageTransform ImageFormat(ImageFormat value)
        {
            this.Append(new Transform { ImageFormat = value });
            return this;
        }

        public ImageTransform InterpolationMode(InterpolationMode value)
        {
            this.Append(new Transform { InterpolationMode = value });
            return this;
        }

        public ImageTransform PixelFormat(PixelFormat value)
        {
            this.Append(new Transform { PixelFormat = value });
            return this;
        }

        public ImageTransform SmoothingMode(SmoothingMode value)
        {
            this.Append(new Transform { SmoothingMode = value });
            return this;
        }

        public ImageTransform Width(int value)
        {
            this.Append(new Transform { Width = value });
            return this;
        }

        public Image End()
        {
            var configuration = this.Configure();

            var newImage = new Bitmap(
                configuration.Width.PropertySet ? configuration.Width.Value : this.Context.Width,
                configuration.Height.PropertySet ? configuration.Height.Value : this.Context.Height,
                configuration.PixelFormat.PropertySet ? configuration.PixelFormat.Value : this.Context.PixelFormat);

            var graphics = Graphics.FromImage(newImage);

            if (configuration.CompositingMode.PropertySet)
            {
                graphics.CompositingMode = configuration.CompositingMode;
            }

            if (configuration.CompositingQuality.PropertySet)
            {
                graphics.CompositingQuality = configuration.CompositingQuality;
            }

            if (configuration.InterpolationMode.PropertySet)
            {
                graphics.InterpolationMode = configuration.InterpolationMode;
            }

            if (configuration.SmoothingMode.PropertySet)
            {
                graphics.SmoothingMode = configuration.SmoothingMode;
            }

            var area = new Rectangle(0, 0, newImage.Width, newImage.Height);

            graphics.DrawImage(this.Context, area);

            graphics.Dispose();

            return newImage;
        }
    }
}
