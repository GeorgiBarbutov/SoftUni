using System;
using System.Collections;
using System.Collections.Generic;

public class Lake : IEnumerable<int>
{
    private int[] data;
    private int index;
    private bool isOdd;

    public Lake(int[] data)
    {
        this.data = data;
        this.index = -2;
        this.isOdd = true;
    }

    public IEnumerator<int> GetEnumerator()
    {
        for (int i = 0; i < this.data.Length; i++)
        {
            if (!this.isOdd && this.index - 2 < 0)
            {
                break;
            }

            if (this.isOdd == true)
            {
                if (this.index + 2 >= this.data.Length)
                {
                    if (this.index + 1 >= this.data.Length)
                    {
                        this.index--;
                        yield return this.data[this.index];
                        this.isOdd = false;
                    }
                    else
                    {
                        this.index++;
                        yield return this.data[this.index];
                        this.isOdd = false;
                    }
                }
                else
                {
                    this.index += 2;
                    yield return this.data[this.index];
                }
            }
            else
            {
                this.index -= 2;
                yield return this.data[this.index];               
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    private class Enumerator
    {

    }
}

