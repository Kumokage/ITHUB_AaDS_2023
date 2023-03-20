// See https://aka.ms/new-console-template for more information
using System;
using Lesson7;

Stack our_stack = new();
our_stack.Push(1);
our_stack.Push(2);
our_stack.Push(3);
Console.WriteLine(our_stack);
our_stack.Pop();
Console.WriteLine(our_stack);
Console.WriteLine(our_stack.Pop() + "\n");
Console.WriteLine(our_stack.Top());
