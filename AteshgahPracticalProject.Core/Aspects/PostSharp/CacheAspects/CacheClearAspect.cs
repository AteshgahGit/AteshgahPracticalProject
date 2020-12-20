using AteshgahPracticalProject.Core.CrossCuttingConcerns.Caching;
using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AteshgahPracticalProject.Core.Aspects.PostSharp.CacheAspects
{
    [Serializable]
    public class CacheClearAspect : OnMethodBoundaryAspect
    {
        private readonly Type _cacheType;
        private readonly string _pattern;
        private ICacheManager _cacheManager;

        public CacheClearAspect(Type cacheType)
        {
            _cacheType = cacheType;
        }

        public CacheClearAspect(Type cacheType, string pattern)
        {
            _pattern = pattern;
            _cacheType = cacheType;
        }

        public override void RuntimeInitialize(MethodBase method)
        {
            if (!typeof(ICacheManager).IsAssignableFrom(_cacheType)) throw new Exception("Wrong Cache Manager Is Entered");

            _cacheManager = (ICacheManager)Activator.CreateInstance(_cacheType);

            base.RuntimeInitialize(method);
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            _cacheManager.RemoveByPattern(string.IsNullOrEmpty(_pattern)
                ? string.Format($"{args.Method.ReflectedType.Namespace}.{args.Method.ReflectedType.Name}.*") 
                : _pattern);
        }
    }
}
