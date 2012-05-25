namespace Fluency.Sample.Imaging
{
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;

    using Fluency.Framework;

    public class Transform : IConfiguration<Transform>
    {
        public FluentProperty<CompositingMode> CompositingMode { get; set; }

        public FluentProperty<CompositingQuality> CompositingQuality { get; set; }

        public FluentProperty<int> Height { get; set; }

        public FluentProperty<ImageFormat> ImageFormat { get; set; }

        public FluentProperty<InterpolationMode> InterpolationMode { get; set; }

        public FluentProperty<PixelFormat> PixelFormat { get; set; }

        public FluentProperty<SmoothingMode> SmoothingMode { get; set; }

        public FluentProperty<int> Width { get; set; }

        public Transform Update(Transform next)
        {
            return new Transform
                {
                    CompositingMode = next.CompositingMode.Or(this.CompositingMode),
                    CompositingQuality = next.CompositingQuality.Or(this.CompositingQuality),
                    Height = next.Height.Or(this.Height),
                    Width = next.Width.Or(this.Width),
                    ImageFormat = next.ImageFormat.Or(this.ImageFormat),
                    InterpolationMode = next.InterpolationMode.Or(this.InterpolationMode),
                    PixelFormat = next.PixelFormat.Or(this.PixelFormat),
                    SmoothingMode = next.SmoothingMode.Or(this.SmoothingMode)
                };
        }
    }
}