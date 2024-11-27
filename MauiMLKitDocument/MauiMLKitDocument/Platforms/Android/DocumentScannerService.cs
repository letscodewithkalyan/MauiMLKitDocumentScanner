using System;
using Android.App;
using AndroidX.Activity.Result;
using AndroidX.Activity.Result.Contract;
using Com.Google.Mlkit.Vision.Documentscanner;
using Droid = Android;

namespace MauiMLKitDocument.Platforms.Android
{
    public class DocumentScannerService : Java.Lang.Object, IDocumentScannerService, Droid.Gms.Tasks.IOnSuccessListener, Droid.Gms.Tasks.IOnFailureListener, IActivityResultCallback
    {
        private TaskCompletionSource<DocumentScanResult> _taskCompletionSource;

        private ActivityResultLauncher scannerLauncher;

        public DocumentScannerService()
        {
            if (Platform.CurrentActivity is AndroidX.Activity.ComponentActivity activity)
            {
                scannerLauncher = activity.RegisterForActivityResult(new ActivityResultContracts.StartIntentSenderForResult(), this);
                //Firebase.Encoders.IDataEncoder
                      //Com.Google.Firebase.Encoders.IDataEncoder
            }
        }

        public async Task<DocumentScanResult> OpenDocumentScannerAsync()
        {
            _taskCompletionSource = new TaskCompletionSource<DocumentScanResult>();
            var options = new GmsDocumentScannerOptions.Builder()
              .SetGalleryImportAllowed(false)
              .SetPageLimit(40)
              .SetResultFormats(GmsDocumentScannerOptions.ResultFormatJpeg)
              .SetScannerMode(GmsDocumentScannerOptions.ScannerModeFull)
              .Build();

            var scanner = GmsDocumentScanning.GetClient(options);
            var intentSender = scanner.GetStartScanIntent(Platform.CurrentActivity);
            intentSender.AddOnSuccessListener(this);
            intentSender.AddOnFailureListener(this);

            return await _taskCompletionSource.Task;
        }

        public void OnSuccess(Java.Lang.Object result)
        {
            if (result is Droid.Content.IntentSender intent)
            {
                scannerLauncher.Launch(new IntentSenderRequest.Builder(intent).Build());
            }
        }

        public void OnFailure(Java.Lang.Exception e)
        {
        }

        public void OnActivityResult(Java.Lang.Object? result)
        {
            if (result is ActivityResult Aresult)
            {
                if (Aresult.ResultCode == (int)Result.Ok)
                {
                    var scanResult = GmsDocumentScanningResult.FromActivityResultIntent(Aresult.Data);
                    if (scanResult != null)
                    {
                        var pages = scanResult.Pages;
                        var images = new List<Uri>();
                        foreach (var page in pages)
                        {
                            images.Add(ConvertToSystemUri(page.ImageUri));
                        }
                        _taskCompletionSource.TrySetResult(new DocumentScanResult
                        {
                            Images = images,
                        });
                    }
                    else
                    {
                        _taskCompletionSource.TrySetResult(null);
                    }
                }
                else
                {
                    _taskCompletionSource.TrySetResult(null);
                }
            }
        }

        public System.Uri ConvertToSystemUri(Droid.Net.Uri androidUri)
        {
            if (androidUri == null)
                throw new ArgumentNullException(nameof(androidUri));

            // Convert Android.Net.Uri to string
            string uriString = androidUri.ToString();

            // Convert to System.Uri
            return new System.Uri(uriString);
        }
    }
}

