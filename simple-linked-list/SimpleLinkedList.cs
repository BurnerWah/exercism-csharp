using System;
using System.Collections;
using System.Collections.Generic;

public class SimpleLinkedList<T> : IEnumerable<T> {
    private Node head;

    public SimpleLinkedList() { }
    public SimpleLinkedList(T data) => Push(data);
    public SimpleLinkedList(IEnumerable<T> objects) {
        foreach (var item in objects) {
            Push(item);
        }
    }

    public int Count {
        get => head is null ? 0 : head.Count;
        private set {
            // This has to be here for tests yay
        }
    }

    public void Push(T value) {
        var next = new Node(value, head);
        head = next;
    }

    public T Pop() {
        var data = head.Data;
        head = head.Child;
        return data;
    }

    public IEnumerator<T> GetEnumerator() {
        var current = head;
        while (current is not null) {
            yield return current.Data;
            current = current.Child;
        }
    }
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    private class Node(T data, Node child) {
        public T Data => data;
        public Node Child => child;

        public int Count => Child is null ? 1 : Child.Count + 1;
    }
}
