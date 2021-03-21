using System.Collections.Generic;

namespace KeyValue.Models
{
    public interface IKeyBoard
    {
        IEnumerable<Key> GetMessage();
        Key GetById(int key);
        Key Add(Key newMessage);
        Key Update(Key updatedMessage);
    }
}
