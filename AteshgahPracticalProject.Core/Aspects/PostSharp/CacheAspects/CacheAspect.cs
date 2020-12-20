using AteshgahPracticalProject.Core.CrossCuttingConcerns.Caching;
using PostSharp.Aspects;
using PostSharp.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AteshgahPracticalProject.Core.Aspects.PostSharp.CacheAspects
{
    [Serializable]
    public class CacheAspect : MethodInterceptionAspect
    {
        private readonly Type _cacheType;
        private readonly int _cacheByMinute;
        private ICacheManager _cacheManager;
        public CacheAspect(Type cacheType, int cacheByMinute = 60)
        {
            _cacheType = cacheType;
            _cacheByMinute = cacheByMinute;
        }

        public override void RuntimeInitialize(MethodBase method)
        {
            if (!typeof(ICacheManager).IsAssignableFrom(_cacheType)) throw new Exception("Wrong Cache Manager Used!");

            _cacheManager = (ICacheManager)Activator.CreateInstance(_cacheType);

            base.RuntimeInitialize(method);
        }

        public override void OnInvoke(MethodInterceptionArgs args)
        {
            var methodName = string.Format($"{args.Method.ReflectedType.Namespace}.{args.Method.ReflectedType.Name}.{args.Method.Name}");

            var arguments = args.Arguments.ToList();

            var key = string.Format($"{methodName}({string.Join(",", arguments.Select(x => x != null ? x.ToString() : "<Null>"))})");

            if (_cacheManager.IsExist(key)) args.ReturnValue = _cacheManager.Get<object>(key);

            base.OnInvoke(args);

            _cacheManager.Add(key, args.ReturnValue, _cacheByMinute);
        }
    }
}
