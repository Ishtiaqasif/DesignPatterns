using DesignPatterns.Iterator;

var history = new BrowseHistory();

history.Push(url: "a");
history.Push(url: "b");
history.Push(url: "c");
history.Pop();
history.Pop();
history.Pop();
history.Push("d");



var iterator = history.GetIterator();

while (iterator.HasNext())
{
    var url = iterator.Current();
    Console.WriteLine(url);

    iterator.Next();
}