using Veauty.VTree;
using UnityGameObject = UnityEngine.GameObject;

namespace Veauty.uGUI
{
    public class Element : Widget<UnityGameObject>
    {
        private readonly System.Func<IVTree[], IVTree> _factory;

        internal Element(System.Func<IVTree[], IVTree> factory)
            : base(System.Array.Empty<IAttribute<UnityGameObject>>())
        {
            _factory = factory;
        }

        public override IVTree Render() => _factory(System.Array.Empty<IVTree>());
        public override UnityGameObject Init(UnityGameObject go) => go;
        public override void Destroy(UnityGameObject go) { }

        public IVTree Of(params IVTree[] children) => _factory(children);

        public IVTree this[IVTree[] children] => _factory(children);
        public IVTree this[IVTree c0] => _factory(new[] { c0 });
        public IVTree this[IVTree c0, IVTree c1] => _factory(new[] { c0, c1 });
        public IVTree this[IVTree c0, IVTree c1, IVTree c2] => _factory(new[] { c0, c1, c2 });
        public IVTree this[IVTree c0, IVTree c1, IVTree c2, IVTree c3] => _factory(new[] { c0, c1, c2, c3 });
    }
}
