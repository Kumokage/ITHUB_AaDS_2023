using System;
namespace MyList;

public class List {
    struct Node {
        Node _next;
        Node _prev;
        int _value;

        Node (int value) {
            _next = null;
            _prev = null;
            _value = value;
        }

        Node (int value, ref Node next, ref Node prev) {
            _next = next;
            _prev = prev;
            _value = value;
        }
    }

    Node _head;
    Node _tail;

    public List(int value) {
        _head = new Node(value);
        _tail = new Node(value);
    }

    public List(int[] arr) {
        _head = new Node(arr[0]);
        _tail = new Node(arr[0]);

        for(int i = 1; i < arr.Length; ++i) {
            Push(arr[i]);
        }
    }

    public void Push(int value) {

    }

    public int Pop() {
        throw new NotImplementedException();
    }

    public void FrontPush(int value) {

    }

    public int FrontPop() {
        throw new NotImplementedException();
    }

    public void Insert(int position) {

    }

    public int Remove(int position) {
        throw new NotImplementedException();
    }

    public int this[int i] {
        get {
            // Return i element of list
        }

        set {
            // Insert to i position value
        }
    }
}