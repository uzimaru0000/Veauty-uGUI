namespace Veauty.uGUI.Presets
{
    /// <summary>
    /// Deferred widget builder returned by the <see cref="V"/> factory methods. Supply children
    /// with the indexer (<c>V.Button(...)[child1, child2]</c>) or use the Element directly as an
    /// <see cref="IVTree"/> for a childless widget.
    /// </summary>
    /// <remarks>
    /// <para>The indexer invokes the factory <i>every time</i> and does not cache, so one Element
    /// can in principle build several trees. <see cref="Unwrap"/> (the childless path, used when
    /// the Element itself is placed in a tree) builds once and caches the result — after the first
    /// call the same <see cref="IVTree"/> instance is always returned.</para>
    /// <para>Do not keep an Element around and unwrap it across renders expecting a fresh node:
    /// build a new Element per render instead.</para>
    /// </remarks>
    /// <example>
    /// <code>
    /// using Veauty.uGUI.Presets;
    ///
    /// // With children (indexer):
    /// var button = V.Button(onClick: () => Debug.Log("hi"))[
    ///     V.Text("Click me")
    /// ];
    ///
    /// // Without children (Element used directly as IVTree):
    /// var slider = V.Slider(value: 0.5f);
    /// </code>
    /// </example>
    public class Element : IVTreeWrapper
    {
        private readonly System.Func<IVTree[], IVTree> _factory;
        private IVTree _cached;

        internal Element(System.Func<IVTree[], IVTree> factory)
        {
            _factory = factory;
        }

        /// <summary>
        /// Builds the widget with the given children and returns the finished tree. Not cached —
        /// each use of the indexer runs the factory again.
        /// </summary>
        /// <param name="children">The VTree children (and optional <see cref="ISubComponent"/>s)
        /// of the widget.</param>
        public IVTree this[params IVTree[] children] => _factory(children);

        /// <summary>Returns the node type of the unwrapped (childless) tree.</summary>
        public VTreeType GetNodeType() => Unwrap().GetNodeType();

        /// <summary>Returns the descendant count of the unwrapped (childless) tree.</summary>
        public int GetDescendantsCount() => Unwrap().GetDescendantsCount();

        /// <summary>
        /// Builds the widget with no children and caches the result; subsequent calls return the
        /// same instance. Called by the renderer when the Element is used directly as a tree node.
        /// </summary>
        /// <returns>The cached childless widget tree.</returns>
        public IVTree Unwrap()
        {
            if (_cached == null)
                _cached = _factory(System.Array.Empty<IVTree>());
            return _cached;
        }
    }
}
