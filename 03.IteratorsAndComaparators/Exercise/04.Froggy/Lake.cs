using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class Lake : IEnumerable<int>
{
    private List<int> stones;

    public Lake(List<int> stones)
    {
        this.stones = stones;
    }

    public IEnumerator<int> GetEnumerator()
    {
        for (int i = 0; i < this.stones.Count; i += 2)
        {
            yield return this.stones[i];
        }

        int startIndex = startIndex = this.stones.Count - 1; 
        if(this.stones.Count % 2 != 0)
        {
            startIndex--;
        }

        for (int i = startIndex; i >= 0; i -= 2)
        {
            yield return this.stones[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}

