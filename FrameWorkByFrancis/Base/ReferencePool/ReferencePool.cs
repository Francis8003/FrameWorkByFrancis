 

using System;
using System.Collections.Generic;

namespace FrameWorkByFrancis
{
    public static partial class ReferencePool
    {
       private static readonly Dictionary<Type,ReferenceColleciton> s_ReferenceCollections=new Dictionary<Type, ReferenceColleciton>();
        private static bool m_EnableStrickCheck=false;

        public static bool EnableStrickCheck
        {
            get
            {
                return m_EnableStrickCheck;
            }
            set 
            {
                m_EnableStrickCheck=value;
            }
        }

        public static int Count
        {
            get 
            {
                return s_ReferenceCollections.Count;
            }
        }

        public static ReferencePoolInfo[] GetAllReferencePoolInfos()
        {
            int index=0;
            ReferencePoolInfo[] results=null;
            lock(s_ReferenceCollections)
            {
                results=new ReferencePoolInfo[s_ReferenceCollections.Count];
                foreach(KeyValuePair<Type,ReferenceColleciton> referenceColleciton in s_ReferenceCollections)
                {
                    results[index++]=
                    new ReferencePoolInfo
                    (referenceColleciton.Key,
                    referenceColleciton.Value.UnusedReferenceCount,
                    referenceColleciton.Value.UsingReferenceCount,
                    referenceCollection.Value.AcquireReferenceCount,
                    referenceCollection.Value.ReleaseReferenceCount,
                    referenceColleciton.Value.AddReferenceCount,
                    referenceCollection.Value.RemoveReferenceCount
                    );
                }
            }
            return results;
        }

        public static void ClearAll()
        {
            lock(s_ReferenceCollections)
            {
                foreach(KeyValuePair <Type,ReferenceCollection> referenceCollection in s_ReferenceCollections)
                {
                    referenceCollection.Value.RemoveAll();
                }
                s_ReferenceCollections.Clear();
            }
        }

        public static T Acquire<T> () where T:class ,IReference,new ()
        {
            return GetReferenceCollection(typeof(T)).Acquire<T>();
        }

        public static IReference Acquire(Type referenceType)
        {
            
        }

        private static void InternalCheckReferenceType(Type referenceType)
        {
            if(!m_EnableStrickCheck)
            {
                return ;
            }
            if(referenceType==null)
            {
                throw new FrameworkException("ReferenceType is invalid.");
            }
            if(!referenceType.IsClass||referenceType.IsAbstract)
            {
                throw new FrameworkException("ReferenceType is not a non-abstact class type");
            }
            if(!typeof(IReference).IsAssignableFrom(referenceType))
            {
                throw new FrameworkException("  ");
            }
        }
        private static ReferenceCollection GetReferenceCollection(Type referenceType)
        {
            if(referenceType==null)
            {
                 throw new FrameworkException("ReferenceType is invalid.");
            }
            ReferenceCollection referenceCollection =null;
            lock(s_ReferenceCollecitons)
            {
                if(!s_ReferenceCollections.TryGetValue(referenceType,out referenceCollection))
                {
                    referenceCollection=new ReferenceCollection(referenceType);
                    s_ReferenceCollections.Add(referenceType,referenceCollection);
                }
            }
            return referenceCollection;
        }
    }
}
