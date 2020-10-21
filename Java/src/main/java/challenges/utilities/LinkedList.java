package challenges.utilities;

public class LinkedList<T> {
    public Node<T> head = null;
    private Node<T> tail = null;

    public void insert(T value) {
        Node node = new Node(value);
        if (this.head != null)
            node.next = this.head;
        else
            this.tail = node;
        this.head = node;
    }

    public boolean includes(T value) {
        Node<T> current = this.head;
        while (current != null) {
            if (current.value == value) {
                return true;
            }
            current = current.next;
        }
        return false;
    }

    public String toString() {
        StringBuilder sb = new StringBuilder();
        Node<T> current = this.head;
        while (current != null) {
            sb.append("{");
            sb.append(current.value);
            sb.append("} -> ");
            current = current.next;
        }
        sb.append("null");
        return sb.toString();
    }

    public void append(T value) {
        Node<T> node = new Node(value);
        if (this.head == null)
            this.insert(value);
        else {
            this.tail.next = node;
            this.tail = node;
        }
    }

    public void insertBefore(T value, T newValue) {
        try {
            if (this.head.value == value)
                this.insert(newValue);
            else {
                Node<T> node = new Node(newValue);
                Node<T> curr = this.head.next;
                Node<T> prev = this.head;
                while (curr.value != value) {
                    prev = curr;
                    curr = curr.next;
                }
                node.next = curr;
                prev.next = node;
            }
        } catch (Exception e) {
            System.out.println("The target value was not found and new value could not be properly inserted.");
        }
    }

    public void insertAfter(T value, T newValue) {
        try {
            Node<T> curr = this.head;
            while (curr.value != value) {
                curr = curr.next;
            }
            Node<T> node = new Node(newValue);
            node.next = curr.next;
            curr.next = node;
        } catch (Exception e) {
            System.out.println("The target value was not found and new value could not be properly inserted.");
        }
    }

    public static LinkedList zipLists(LinkedList list1, LinkedList list2) {
        try {
            Node newHead = (list1.head != null) ? list1.head : list2.head;

            if (list1.head != null && list2.head != null) {
                if (list1.head.value.getClass() != list2.head.value.getClass())
                    throw new Exception("The input LinkedLists were not of the same type");

                Node current1 = list1.head;
                Node current2 = list2.head;
                Node temp1 = current1.next;
                Node temp2 = current2.next;
                while (current1 != null && current2 != null) {
                    current1.next = current2;
                    if (temp1 == null && temp2 != null) break;
                    current2.next = temp1;
                    if (temp2 == null) break;
                    current1 = temp1;
                    current2 = temp2;
                    temp1 = temp1.next;
                    temp2 = temp2.next;
                }
            }
            LinkedList newList = new LinkedList();
            newList.head = newHead;
            return newList;
        } catch (Exception e) {
            System.out.println(e.getMessage());
            return null;
        }
    }

    public T kthFromEnd(int k) throws Exception {
        Node<T> current = this.head;
        Node<T> slower = this.head;
        int counter = 0;
        if (k < 0) {
            int temp = 0;
            while (current != null) {
                temp++;
                current = current.next;
            }
            current = this.head;
            k = temp + k;
        }
        while (current != null) {
            if (counter > k){
                slower = slower.next;
            }
            current = current.next;
            counter ++;
        }
        if (counter < k) {
            throw new Exception("It looks like the linked list is too short!");
        }
        return slower.value;
    }
}

