using DevvFramework.Core.CrossCuttingConcerns.Caching;
using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DevvFramework.Core.Aspects.PostSharp.CacheAspects
{
    [Serializable]
    public class CacheRemoveAspect : OnMethodBoundaryAspect
    {
        private Type _type;
        private ICacheManager _cacheManager;
        private string _pattern;
        public CacheRemoveAspect(Type type)
        {
            _type = type;
        }
        public CacheRemoveAspect(Type type,string pattern)
        {
            _type = type;
            _pattern = pattern;
        }
        public override void RuntimeInitialize(MethodBase method)
        {
            if (!typeof(ICacheManager).IsAssignableFrom(_type))
            {
                throw new Exception("Wrong cache type!");
            }
            _cacheManager = (ICacheManager)Activator.CreateInstance(_type);
            base.RuntimeInitialize(method);
        }
        public override void OnSuccess(MethodExecutionArgs args)
        {
            _cacheManager.RemoveByPattern(string.IsNullOrEmpty(_pattern) ? string.Format("{0}.{1}.*"
                , args.Method.DeclaringType.Namespace, args.Method.DeclaringType.Name) : _pattern);
        }
    }
}
