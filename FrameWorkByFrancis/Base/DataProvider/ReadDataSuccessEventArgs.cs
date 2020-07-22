
using System.Runtime.Remoting.Metadata.W3cXsd2001;
///
/// Order==
///
namespace FrameWorkByFrancis
{
    public sealed class ReadDataSuccessEventArgs:GameFrameworkEventArgs
    {
        public string DataAssetName
        {
            get;
            private set;
        }

        public float Duration
        {
            get;
            private set;
        }

        public object UserData
        {
            get;
            private set;
        }


        public ReadDataSuccessEventArgs()
        {
            DataAssetName = null;
            Duration = 0f;
            UserData = null;
        }

        public static ReadDataSuccessEventArgs Create(string dataAssetName,float duration,object userdata)
        {
            //ReadDataSuccessEventArgs readDataSuccessEventArgs=
           //to do 
            return null;
        }

        public override void Clear()
        {
        }
    }
}