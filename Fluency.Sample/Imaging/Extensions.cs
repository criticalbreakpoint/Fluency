namespace Fluency.Sample.Imaging
{
    using System.Drawing;

    public static class Extensions
    {
        public static ImageTransform Transform(this Image image)
        {
            return new ImageTransform(image);
        }
    }
}