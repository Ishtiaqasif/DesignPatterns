using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Iterator
{
    public class BrowseHistory
    {
        const int _size = 10;
        private readonly string[] _urls = new string[_size];
        private int _count = 0;

        public IIterator<string> GetIterator()
        {
            return new ArrayIterator(this);
        }

        public void Push(string url)
        {
            if (_count < _size)
            {
                _urls[_count++] = url;
            }
            else
            {
                throw new OverflowException();
            }
        }

        public string Pop()
        {
            if (_count > 0)
            {
                return _urls[--_count];
            }
            else
            {
                throw new InvalidOperationException();
            }

            
        }

        public class ArrayIterator : IIterator<string>
        {
            private readonly BrowseHistory _history;
            private int _index;

            public ArrayIterator(BrowseHistory history)
            {
                this._history = history;
            }
            public string Current()
            {
                return _history._urls[_index];
            }

            public bool HasNext()
            {
                return _index < _history._count;
            }

            public void Next()
            {
                _index++;
            }
        }
    }
}
