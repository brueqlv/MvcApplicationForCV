using DinkToPdf.Contracts;
using DinkToPdf;

namespace MvcApplicationForCV.Models
{
    public class PdfConverter
    {
        private readonly IConverter _converter;

        public PdfConverter(IConverter converter)
        {
            _converter = converter;
        }

        public byte[] ConvertHtmlToPdf(string htmlContent)
        {
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4
            };

            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = htmlContent,
                WebSettings = { DefaultEncoding = "utf-8" }
            };

            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };

            return _converter.Convert(pdf);
        }
    }
}
