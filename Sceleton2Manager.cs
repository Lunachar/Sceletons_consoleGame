using System.Collections;

namespace Skeletons;

public class Sceleton2Manager : IEnumerable<Sceleton2>  // that class implements IEnumerable and
                                                        // includes methods for iterating over
                                                        // and managing a list of "Skeleton2" objects,
                                                        // such as calculating the total damage of all skeletons
                                                        // and removing dead skeletons from the list.
{
    public List<Sceleton2> _sceletons = new()
    {

    };
    

    public IEnumerator<Sceleton2> GetEnumerator()
    {
        return new Sceleton2ManagerEnumerator(_sceletons);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    
    public int AllSceletonDamage()
    {
        int summury = 0;
        foreach (var VARIABLE in _sceletons)
        {
            summury += VARIABLE.weapon.Damage;
        }

        return summury;
    }
    public void RemoveSceleton()
    {
        var deadSceletons = new List<Sceleton2>();
        foreach (var scel in _sceletons)
        {
            if (scel.isDead)
            {
                deadSceletons.Add(scel);
            }
        }
        foreach (var deadSceleton in deadSceletons)
        {
            _sceletons.Remove(deadSceleton);
        }
    }


}


class Sceleton2ManagerEnumerator : IEnumerator<Sceleton2>
{
    private readonly List<Sceleton2> _sceleton;
    private int _index = -1;
    private Sceleton2 _current;

    public Sceleton2ManagerEnumerator(List<Sceleton2> sceleton)
    {
        _sceleton = sceleton;
    }

    public bool MoveNext()
    {
        _index++;
        return _index < _sceleton.Count;
    }

    public void Reset()
    {
        _index = -1;
    }

    public Sceleton2 Current => _sceleton[_index];

    object IEnumerator.Current => _current;

    public void Dispose()
    {
        //throw new NotImplementedException();
    }
    
    
}