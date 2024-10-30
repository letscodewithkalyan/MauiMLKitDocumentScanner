using System;
namespace MauiMLKitDocument
{
    public class DocumentScanResult
    {
        public List<Uri> Images { get; set; }
        public Uri PdfUri { get; set; }
        public int PageCount { get; set; }
    }
}

