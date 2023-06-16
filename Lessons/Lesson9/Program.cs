// See https://aka.ms/new-console-template for more information
using LessonDict;

Dict test = new();
string key = "Some";
test.Add(key, new Message("Some text", "some author"));
Console.WriteLine(test.Contain(key));
Console.WriteLine(test[key]);
test[key] = new Message("Better text", "better author");
Console.WriteLine(test[key]);
test.Remove(key);
Console.WriteLine(test.Contain(key));

test.Add("Some1", new Message("Some text1", "some author"));
test.Add("Some2", new Message("Some text2", "some author"));
test.Add("Some3", new Message("Some text3", "some author"));
test.Add("Some4", new Message("Some text1", "some author"));
test.Add("Some5", new Message("Some text2", "some author"));
test.Add("Some6", new Message("Some text3", "some author"));
Console.WriteLine(test);
