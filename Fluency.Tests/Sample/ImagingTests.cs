namespace Fluency.Tests.Sample
{
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;

    using Fluency.Sample.Imaging;

    using NUnit.Framework;

    [TestFixture]
    public class ImagingTests
    {
        [Test]
        public void CanPerformFluentTransform()
        {
            var image = Image.FromFile(@"Resources\eso1211a.jpg");

            var newImage = image
                .Transform()
                .Width(1024)
                .Height(768)
                .CompositingMode(CompositingMode.SourceCopy)
                .CompositingQuality(CompositingQuality.HighQuality)
                .SmoothingMode(SmoothingMode.HighQuality)
                .InterpolationMode(InterpolationMode.HighQualityBicubic)
                .ImageFormat(ImageFormat.Png)
                .PixelFormat(PixelFormat.Format24bppRgb)
                .End();

            Assert.IsNotNull(newImage);

            Assert.That(newImage.Width,
                Is.EqualTo(1024));
            Assert.That(newImage.Height,
                Is.EqualTo(768));
            Assert.That(newImage.PixelFormat,
                Is.EqualTo(PixelFormat.Format24bppRgb));

            newImage.Save(@"Resources\transformed.png");
        }
    }
}
