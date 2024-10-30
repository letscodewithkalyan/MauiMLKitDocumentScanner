using System;
namespace MauiMLKitDocument
{
	public interface IDocumentScannerService
	{
        Task<DocumentScanResult> OpenDocumentScannerAsync();
    }
}

