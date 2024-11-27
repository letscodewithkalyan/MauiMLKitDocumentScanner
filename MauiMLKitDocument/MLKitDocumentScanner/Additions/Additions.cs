using System;
using Android.Runtime;

namespace Xamarin.Google.MLKit.Common.Internal
{
    // Metadata.xml XPath class reference: path="/api/package[@name='com.google.mlkit.common.internal']/class[@name='CommonComponentRegistrar']"
    // [global::Android.Runtime.Register ("com/google/mlkit/common/internal/CommonComponentRegistrar", DoNotGenerateAcw=true)]
    public partial class CommonComponentRegistrar : global::Java.Lang.Object, global::Firebase.Components.IComponentRegistrar
    {
        public unsafe global::System.Collections.Generic.IList<global::Firebase.Components.Component> Components
        {
            // Metadata.xml XPath method reference: path="/api/package[@name='com.google.mlkit.common.internal']/class[@name='CommonComponentRegistrar']/method[@name='getComponents' and count(parameter)=0]"
            // [Register ("getComponents", "()Ljava/util/List;", "")]
            get
            {
                const string __id = "getComponents.()Ljava/util/List;";
                try
                {
                    var __rm = _members.InstanceMethods.InvokeNonvirtualObjectMethod(__id, this, null);
                    return (System.Collections.Generic.IList<Firebase.Components.Component>)global::Android.Runtime.JavaList.FromJniHandle(__rm.Handle, JniHandleOwnership.TransferLocalRef);
                }
                finally
                {
                }
            }
        }
    }
}

namespace Com.Google.Android.Datatransport.Runtime.Dagger.Internal
{
    public sealed partial class ProviderOfLazy : Java.Lang.Object, global::JavaX.Inject.IProvider
    {
        public Java.Lang.Object Get()
        {
            return null;
        }
    }

    public sealed partial class SetFactory : Java.Lang.Object, global::JavaX.Inject.IProvider
    {
        public Java.Lang.Object Get()
        {
            return null;
        }
    }
}

