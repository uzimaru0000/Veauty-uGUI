using Veauty.VTree;
using UnityGameObject = UnityEngine.GameObject;
using Veauty.uGUI;

namespace Veauty.uGUI.Presets
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

        public IVTree this[params IVTree[] children] => _factory(children);
    }
}
