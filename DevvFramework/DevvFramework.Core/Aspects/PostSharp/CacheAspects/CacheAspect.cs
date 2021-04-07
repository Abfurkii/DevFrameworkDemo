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
    public class CacheAspect : MethodInterceptionAspect
    {
        private Type _type;
        private int _cacheTime;
        private ICacheManager _cacheManager;
        public CacheAspect(Type type,int cacheTime)
        {
            _type = type;
            _cacheTime = cacheTime;
        }

        public override void RuntimeInitialize(MethodBase method)
        {
            if (!typeof(ICacheManager).IsAssignableFrom(_type))
            {
                throw new Exception("Wrong cache type!");
            }
            _cacheManager =(ICacheManager)Activator.CreateInstance(_type);
            base.RuntimeInitialize(method);
        }

        public override void OnInvoke(MethodInterceptionArgs args)
        {
            var methodName = string.Format("{0}.{1}.{2}"
                , args.Method.DeclaringType.Namespace
                , args.Method.DeclaringType.Name
                , args.Method.Name);

            var parameters = args.Arguments.ToList();

            var key = string.Format("{0}({1})", methodName
                , string.Join(",",parameters.Select(x => x != null ? x.ToString() : "<null>")));

            if (_cacheManager.IsAdd(key))
            {
                args.ReturnValue = _cacheManager.Get<object>(key);
            }
            base.OnInvoke(args);
            _cacheManager.Add(key, args.ReturnValue, _cacheTime);
        }
    }
}
