using System.Collections.Generic;
namespace Lesson7 {
    class Stack {

        class Node {
            int value;
            Node prev;

            public Node(int value, Node prev) {
                this.value = value;
                this.prev = prev;
            }
        }

        private Node top;
        private int size;

        public Stack() {
            top = null;
            size = 0;
        }

        public Stack(IEnumerable<int> collection) {
            foreach(int buf in collection) {
                Push(buf);
            }
        }

        public void Push(int value) {
            top = new Node(value, top);
            ++size;
        }

        public int Top() {
            return top.value;
        }

        public int Pop() {
            if (top is null) {
                throw new System.Exception("Empty stack");
            }

            int buf = top.value;
            top = top.prev;
            --size;
            return buf;
        }

        public bool Empty() {
            return top is null;
        }

    }
}