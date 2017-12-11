﻿namespace MathNet.Spatial.Internals
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    internal class AvlNodeItemEnumerator<T> : IEnumerator<T>
    {
        private readonly AvlTreeSet<T> avlTree;

        private AvlNode<T> current = null;

        public AvlNodeItemEnumerator(AvlTreeSet<T> avlTree)
        {
            this.avlTree = avlTree ?? throw new ArgumentNullException("avlTree can't be null");
        }

        public T Current
        {
            get
            {
                if (this.current == null)
                {
                    throw new InvalidOperationException("Current is invalid");
                }

                return this.current.Item;
            }
        }

        object IEnumerator.Current => this.Current;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (this.current == null)
            {
                this.current = this.avlTree.GetFirstNode();
            }
            else
            {
                this.current = this.current.GetNextNode();
            }

            if (this.current == null) // Should check for an empty tree too :-) 
            {
                return false;
            }

            return true;
        }

        public void Reset()
        {
            this.current = null;
        }
    }
}
