using System;
using System.Collections;
using System.Collections.Generic;

namespace FrankBryce.Random.Generator
{
    public class RandomHexEnumerable : IEnumerable<char>
    {
        private Stack<char?> chars = new Stack<char?>( new List<char?> { null } );
        private PppWrapper _pppWrapper;

        public RandomHexEnumerable(PppWrapper pppWrapper)
        {
            _pppWrapper = pppWrapper;
        }
        
        public IEnumerator<char> GetEnumerator()
        {
            while (true)
            {
                if(chars.Peek() == null)
                {
                    foreach(var item in _pppWrapper.GetRandomCharArray())
                    {
                        chars.Push(item);
                    }
                }

                yield return chars.Pop().Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
