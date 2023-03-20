// See https://aka.ms/new-console-template for more information
using LessonQueue;

Queue queue = new();
// 1 branch Push
queue.Push(new Message("text 1", 2));
// 2 branch Push
queue.Push(new Message("text 2", 1));
// 3 branch Push
queue.Push(new Message("text 3", 3));
// 4 branch Push
queue.Push(new Message("text 4", 2));
// Check Pop and push after pop
queue.Pop();
queue.Push(new Message("text 5", 1));
queue.Push(new Message("text 6", 4));
Console.WriteLine(queue);
