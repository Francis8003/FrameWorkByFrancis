///
/// Order==2 
///
using System;

namespace FrameWorkByFrancis
{
    public abstract class GameFrameworkEventArgs : EventArgs, IRenference
    {
       public GameFrameworkEventArgs()
        {

        }
        public abstract void Clear();
    }
}
